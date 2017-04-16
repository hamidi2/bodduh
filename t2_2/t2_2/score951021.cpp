#include "stdafx.h"
#include "score951021.h"
#include <util.h>

void CcScore951021::Make(LPCSTR sentence)
{
	strcpy(d_sentence, sentence);
	_strrev(d_sentence);
	d_len = (char) strlen(d_sentence);
	d_nSize = (d_len-1)/4 + 1;
	memset(&d_n, 0, sizeof(d_n));
	char i = 0;
	for (; i < d_len; i++)
	{
		d_col[i] = letters[d_sentence[i]].abjadCol;
		d_buf[i] = d_col[i] + '0';
		d_n[i/4] += d_col[i];
	}
	d_buf[i] = 0;
}

void CcScore951021::Reverse()
{
	char tmp;
	for (char i=0, i2=d_len-1-i; i < d_len/2; i++, i2--)
	{
		tmp = d_sentence[i];	d_sentence[i] = d_sentence[i2];		d_sentence[i2] = tmp;
		tmp = d_col[i];			d_col[i] = d_col[i2];				d_col[i2] = tmp;
		tmp = d_buf[i];			d_buf[i] = d_buf[i2];				d_buf[i2] = tmp;
	}
	memset(&d_n, 0, sizeof(d_n));
	for (char i=0; i < d_len; i++)
		d_n[i/4] += d_col[i];
}

bool CcScore951021::HasScore951105() const
{
	char m[4], i;
	char iN1 = (d_nSize+1)/2-1, iN2=iN1, iM=0;
	if (d_nSize % 2)
	{
		m[iM++] = d_n[iN1];
		iN1--;
	}
	iN2++;
	while (iN1 >= 0)
	{
		m[iM++] = abs(d_n[iN1] - d_n[iN2]);
		iN1--;
		iN2++;
	}
	
	char mSum = 0;  // max is 112
	for (i = 0; i < iM; i++)
		mSum += m[i];
	if (!IsMajor(mSum) || !IsMinor(mSum))
		return false;

	char x1x2[80] = {}, x2x1[80] = {};
	for (i = 0; i < iM; i++)
		sprintf(x1x2 + strlen(x1x2), "%d", m[i]);
	for (i--; i >= 0; i--)
		sprintf(x2x1 + strlen(x2x1), "%d", m[i]);

	// cond1: asli ya sayer budan
	bool x1x2cond1, x2x1cond1;
	x1x2cond1 = IsMajor(x1x2) || IsMinor(x1x2);
	x2x1cond1 = IsMajor(x2x1) || IsMinor(x2x1);
	
	// cond2: 28k+9k or 28k+11 or 28k+17 budan
	bool x1x2cond2, x2x1cond2;
	string s;
	int x1x2rem, x2x1rem;
	Divide(x1x2, 28, s, x1x2rem);
	x1x2cond2 = x1x2rem % 9 == 0 || x1x2rem == 11 || x1x2rem == 17;
	Divide(x2x1, 28, s, x2x1rem);
	x2x1cond2 = x2x1rem % 9 == 0 || x2x1rem == 11 || x2x1rem == 17;
	
	// cond3: 9k+2 or 28k+9k+2 budan
	bool x1x2cond3, x2x1cond3;
	int rem;
	Divide(x1x2, 9, s, rem);
	x1x2cond3 = rem == 2 || x1x2rem % 9 == 2;
	Divide(x2x1, 9, s, rem);
	x2x1cond3 = rem == 2 || x2x1rem % 9 == 2;

	if (x1x2cond1 && x2x1cond2)
	{
	}
	else if (x2x1cond1 && x1x2cond2)
	{
	}
	else
	{
		return false;
	}

	return true;
}

bool CcScore951021::HasPriority(char &priority) const
{
	int n = 0;
	for (int i=0; i<d_len; i++)
		n += d_col[i];
	if (IsMajor(d_buf))
		priority = 1;
	else if (IsMinor(n))
		priority = 2;
	else
		return false;
	return true;
}

bool CcScore951021::HasScoreIndependently(char &major, char &minor, bool bAcceptMinor) const
{
	major = minor = 0;
	char i = 0;
	for (; i < d_nSize-1; i++)
		if (!IsMajor(d_n[i]))
			break;
	if (i == d_nSize-1)
	{
		CheckScore(d_n[i], major, minor);
		if (major || (bAcceptMinor && minor))
		{
			major += d_nSize-1;
			return true;
		}
	}
	return false;
}

bool CcScore951021::HasScoreDependently(char &major, char &minor) const
{
	major = minor = 0;
	char i = 0;
	for (; i < d_nSize; i++)
	{
		char major2 = 0, minor2 = 0;
		CheckScore(d_n[i]+d_n[(i+1)%d_nSize], major2, minor2);
		CheckScore(abs(d_n[i]-d_n[(i+1)%d_nSize]), major2, minor2, false);
		if (major2)
			minor2 = 0;  // 951104: gharar bar in shod ke agar mesle 9,11 ham emtiaze asli bedeh ham emtiaze sayer, faghat asli dar nazar gerefteh besheh.
		if (!major2 && !minor2)
			break;
		major += major2;
		minor += minor2;
	}
	return (i == d_nSize);
}

bool CcScore951021::HasScore(char &major, char &minor, char &priority)
{
	if (!HasPriority(priority))
		return false;
	if (!HasScore951105())
		return false;
	int j = d_len % 4, pos;
	if (!j)
		return HasScoreIndependently(major, minor, false);
	pos = d_len / 4 * 4;
	char major2 = 0, minor2 = 0;
	char major3, minor3;
	if (HasScoreIndependently(major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/21
	for (; j<4; j++)
		d_n[pos/4] += d_col[j-d_len%4];
	if (HasScoreDependently(major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/23
	string lastPart = d_sentence + pos;
	reverse(lastPart.begin(), lastPart.end());
	Expand(lastPart);
	lastPart = lastPart.substr(0, 4);
	char len = (char) lastPart.size();
	d_n[pos/4] = 0;
	for (j=0; j<len; j++)
		d_n[pos/4] += letters[lastPart[j]].abjadCol;
	// 7/24
	if (HasScoreDependently(major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/25
	if (j < 4)
	{
		for (; j<4; j++)
			d_n[pos/4] += d_col[j-len];
		if (HasScoreDependently(major3, minor3))
			UpdateScore(major2, minor2, major3, minor3);
		Expand(lastPart);
		lastPart = lastPart.substr(0, 4);
		len = (char) lastPart.size();
		d_n[pos/4] = 0;
		for (j=0; j<len; j++)
			d_n[pos/4] += letters[lastPart[j]].abjadCol;
		if (HasScoreDependently(major3, minor3))
			UpdateScore(major2, minor2, major3, minor3);
	}
	if (major2 || minor2)
	{
		major += major2;
		minor += minor2;
		return true;
	}
	return false;
}

bool CcScore951021::HasScore(LPCSTR sentence, CsScore951021PersistentItems &items)
{
	Make(sentence);
	items.numSidesWithScore = HasScore(items.major, items.minor, items.priority);
	if (d_len % 4)
	{
		Reverse();
		items.numSidesWithScore = items.numSidesWithScore * 2 + HasScore(items.major, items.minor, items.priority);
	}
	if (!items.numSidesWithScore)
		return false;
	if (!items.priority)
		return false;
	return true;
}

