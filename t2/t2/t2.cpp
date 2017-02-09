// t2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdlib.h>
#include <string>
#include <sstream>
#include <vector>
#include <set>
#include <map>
#include <afx.h>
#include <iostream>
#include <process.h>
#include <conio.h>

#include "t2.h"

#define output printf
//#define output no_printf
#define TEST

void no_printf(const char * /*fmt*/, ...)
{
}

bool CT2::pair::operator <(const CT2::pair &p) const
{
	if (r1 < p.r1)
		return true;
	if (r1 > p.r1)
		return false;
	return r2 < p.r2;
}

CT2::CT2()
{
	memset(d_fp, 0, sizeof(d_fp));
}

void CT2::addSet(byte n[], byte iSet, byte iSumMinusOne)
{
	int64 r = 0;
	for (int i = 0; i <= iSet; i++)
		r = r * 10 + n[i];
	d_sets[iSet][r] = iSumMinusOne + 1;
}

void CT2::openFiles()
{
	for (int i = 0; i < 28; i++)
	{
		char fn[80];
		sprintf(fn, "sum-%02d.dat", i + 1);
		d_fp[i] = fopen(fn, "w");
		if (!d_fp[i])
		{
			fprintf(stderr, "fatal: cannot create file %s\n", fn);
			exit(1);
		}
	}
}

void CT2::closeFiles()
{
	for (int i = 0; i < 28; i++)
		fclose(d_fp[i]);
}

void CT2::addPair(int64 r1, int64 r2, int iSet, bool bSameSet, int digitsSum, char major, char minor, char score950122)
{
#ifdef TEST
	printf("%I64d %I64d %d %d %d %d %d\n", r1, r2, iSet, bSameSet, major, minor, score950122);
#else
	fprintf(d_fp[digitsSum-1], "%I64d %I64d %d %d %d %d %d\n", r1, r2, iSet, bSameSet, major, minor, score950122);
#endif
}

void CT2::calcMajorAndMinor(int64 r1, int64 r2, char &major, char &minor)
{
	major = minor = 0;
	size_t i;

	// step1
	int64 r[] = { r1, r2, Rev(r1), Rev(r2) };
	size_t max = ((r[0] == r[2] && r[1] == r[3]) || r[0] == r[3]) ? 2 : 4;
	size_t max2;
	int mod[4];
	for (i = 0; i < max; i++)
		mod[i] = r[i] % 28;
	int step1[] = { mod[0] + mod[1], abs(mod[0] - mod[1]), mod[2] + mod[3], abs(mod[2] - mod[3]) };
	max2 = max;//removeDuplicates(step1, max2, max);
	for (i = 0; i < max2; i++)
		CheckScore(step1[i], major, minor);

	// step2
	int64 step2[8] = { Sum(r[0], r[1]), Diff(r[0], r[1]), 0, 0, Sum(r[2], r[3]), Diff(r[2], r[3]) };
	bool isValid[8];
	for (i = 0; i < max; i++)
	{
		bool bIsAbjadRevValid;
		step2[i + i/2 * 2 + 2] = AbjadRev(step2[i + i/2 * 2], bIsAbjadRevValid);
		isValid[i + i/2 * 2] = isValid[i + i/2 * 2 + 2] = bIsAbjadRevValid;
	}
	max2 = max * 2;//removeDuplicates(step2, max2, max * 2);
	// ~
	for (i = 0; i < max2; i++)
		if (isValid[i])
			CheckScore(step2[i], major, minor);
}

/*
return values:
	0: don't match
	1: match and are in the same set
	2: are not in the same set and match at first try (r1 & r2)
	3: are not in the same set and don't match at first try, but match at second try (r1 & r3)
*/
int CT2::calcMajorAndMinor(int64 r1, int64 r2, int iSet, bool bSameSet, char &major, char &minor)
{
	calcMajorAndMinor(r1, r2, major, minor);
	if (major || minor)
		return bSameSet ? 1 : 2;
	if (!bSameSet)  // not same number of digits
	{
		static const int64 powersOfTen[] =
		{
			10,
			100,
			1000,
			10000,
			100000,
			1000000,
			10000000,
			100000000,
			1000000000,
			10000000000,
			100000000000,
			1000000000000,
			10000000000000,
		};
		int64 r3 = r2 + (r2 % 10) * powersOfTen[iSet-1];
		calcMajorAndMinor(r1, r3, major, minor);
		if (major || minor)
			return 3;
	}
	return 0;
}

void CT2::makePairs()
{
	fprintf(stderr, "\ncreating database...\n\n");
	for (int iSumMinusOne = 0; iSumMinusOne < 14; iSumMinusOne++)
	{
		byte n[14];
		memset(&n, 0, sizeof(n));
		int sum = 0;
		for (int i = 0; ;)
		{
			if (n[i] == 9)
			{
				if (i == 0)
					break;
				sum -= n[i];
				n[i] = 0;
				i--;
				continue;
			}
			else
			{
				ASSERT(n[i] < 9);
				n[i]++;
				sum++;
			}
			if (sum < iSumMinusOne + 1)
			{
				if (i < _countof(n) - 1)
					i++;
			}
			else
			{
				ASSERT(sum == iSumMinusOne + 1);
				addSet(n, i, iSumMinusOne);
				if (i == 0)
					break;
				sum -= n[i];
				n[i] = 0;
				i--;
			}
		}
	}
	
	for (int iSet = 0; iSet < 14; iSet++)
	{
		char fn[80];
		sprintf(fn, "set-%02d.txt", iSet + 1);
		FILE *fp = fopen(fn, "wt");
		for (auto iRow = d_sets[iSet].begin(); iRow != d_sets[iSet].end(); iRow++)
			fprintf(fp, "%I64d\t%d\n", iRow->first, iRow->second);
		fclose(fp);
	}
	
	processThreadData data[14][2];
	for (int iSet = 0; iSet < 14; iSet++)
	{
		data[iSet][0].This = data[iSet][1].This = this;
		data[iSet][0].iSet = data[iSet][1].iSet = iSet;
		data[iSet][0].done = data[iSet][1].done = false;
		data[iSet][0].bSameSet = true;
		data[iSet][1].bSameSet = false;
	}
	memset(d_threadsStatus, 0, _countof(d_threadsStatus));
	showThreadsStatus();
	HANDLE threadHandles[14][2];
	for (int iSet = 0; iSet < 14; iSet++)
	{
		threadHandles[iSet][0] = (HANDLE) _beginthread(processThread, 0, &data[iSet][0]);
		threadHandles[iSet][1] = (HANDLE) _beginthread(processThread, 0, &data[iSet][1]);
	}
	DWORD stat = WaitForMultipleObjects(14 * 2, (const HANDLE *) threadHandles, TRUE, INFINITE);
	if (stat)
		printf("WaitForMultipleObjects returns %d, GetLastError returns %d\n", stat, GetLastError());
	bool allDone = true;
	for (iSet = 0; iSet < 14; iSet++)
		if (!data[iSet][0].done || !data[iSet][1].done)
		{
			printf("%2d x\n", iSet);
			allDone = false;
		}
	if (allDone)
		printf("\n\ndatabase created.\n");
}

void CT2::showThreadsStatus()
{
	char buf[80];
	for (int i = 0; i < _countof(d_threadsStatus); i++)
		buf[i] = d_threadsStatus[i] ? '+' : '-';
	buf[i] = 0;
	printf("\r%s", buf);
}

void CT2::processThread(void *p)
{
	Sleep(100);
	processThreadData *pData = (processThreadData *) p;
	if (pData->bSameSet)
	{
		for (auto i1Row = pData->This->d_sets[pData->iSet].begin(); i1Row != pData->This->d_sets[pData->iSet].end(); i1Row++)
			for (auto i2Row = i1Row; i2Row != pData->This->d_sets[pData->iSet].end(); i2Row++)
				pData->This->process(i1Row->first, i2Row->first, i1Row->second + i2Row->second, pData->iSet, true);
		pData->This->d_threadsStatus[pData->iSet * 2] = true;
	}
	else
	{
		if (pData->iSet)
		{
			for (auto i1Row = pData->This->d_sets[pData->iSet].begin(); i1Row != pData->This->d_sets[pData->iSet].end(); i1Row++)
				for (auto i2Row = pData->This->d_sets[pData->iSet-1].begin(); i2Row != pData->This->d_sets[pData->iSet-1].end(); i2Row++)
					pData->This->process(i1Row->first, i2Row->first, i1Row->second + i2Row->second, pData->iSet, false);
			pData->This->d_bAdded[pData->iSet].clear();
		}
		pData->This->d_threadsStatus[pData->iSet * 2 + 1] = true;
	}
	pData->done = true;
	pData->This->showThreadsStatus();
}

void CT2::process(int64 r1, int64 r2, int digitsSum, int iSet, bool bSameSet)
{
	char buf[80];
	int64 r1rev = Rev(r1), r2rev = Rev(r2);

	if (bSameSet)
	{
		string pairs[4], thisPair;
		size_t numPairs = 0;
		sprintf(buf, "%I64d %I64d", r1, r2);
		pairs[numPairs++] = thisPair = buf;
		sprintf(buf, "%I64d %I64d", r1rev, r2rev);
		pairs[numPairs++] = buf;
		sprintf(buf, "%I64d %I64d", r2, r1);
		pairs[numPairs++] = buf;
		sprintf(buf, "%I64d %I64d", r2rev, r1rev);
		pairs[numPairs++] = buf;
		RemoveDuplicates(pairs, numPairs, numPairs);
		if (thisPair != pairs[0])
			return;
	}
	else
	{
		pair p = {r1, r2};
		if (d_bAdded[iSet][p])
			return;
	}
	
	string joins[4];
	size_t numJoins = 0, i, len;

	DigitJoin(r1, r2, buf);
	joins[numJoins++] = buf;
	_strrev(buf);
	joins[numJoins++] = buf;
	if (bSameSet)
	{
		DigitJoin(r2, r1, buf);
		joins[numJoins++] = buf;
		_strrev(buf);
		joins[numJoins++] = buf;
	}
	RemoveDuplicates(joins, numJoins, numJoins);

	char major, minor;
	int group = calcMajorAndMinor(r1, r2, iSet, bSameSet, major, minor);

	char score950122 = 0;
	if (group)
		for (i = 0; i < numJoins; i++)
			score950122 += CalcScore950122(joins[i].c_str());

	switch (group)
	{
	case 2:
		if (r1 != r1rev && r2 != r2rev)
		{
			addPair(r1rev, r2rev, iSet, bSameSet, digitsSum, major, minor, score950122);
			pair p = {r1rev, r2rev};
			d_bAdded[iSet][p] = true;
		}
	case 1:
	case 3:
		addPair(r1, r2, iSet, bSameSet, digitsSum, major, minor, score950122);
	}
}

void CT2::makeDB()
{
#ifdef TEST
	int64 r1 = 121, r2 = 11;
	process(r1, r2, DigitsSum(r1) + DigitsSum(r2), NumDigits(r1) - 1, NumDigits(r1) == NumDigits(r2));
	if (!_getch())
		_getch();
#else
	openFiles();
	makePairs();
	closeFiles();
#endif
}

void main()
{
	CT2().makeDB();
}

