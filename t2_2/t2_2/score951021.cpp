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
	for (char i=0, i2=d_len-1-i; i < d_len/2; i++, i2--)
	{
		swap(d_sentence[i], d_sentence[i2]);
		swap(d_col[i], d_col[i2]);
		swap(d_buf[i], d_buf[i2]);
	}
	memset(&d_n, 0, sizeof(d_n));
	for (char i=0; i < d_len; i++)
		d_n[i/4] += d_col[i];
}

bool CcScore951021::HasScore951105() const
{
	char m0 = 0, m[3][2], i;
	char iN1 = (d_nSize+1)/2-1, iN2=iN1, iM=0;
	if (d_nSize % 2)
	{
		m0 = d_n[iN1];
		iN1--;
	}
	while (iN1 >= 0)
	{
		iN2++;
		m[iM][0] = d_n[iN1] + d_n[iN2];
		while (m[iM][0] > 9)
			m[iM][0] = DigitsSum(m[iM][0]);
		m[iM][1] = abs(d_n[iN1] - d_n[iN2]);
		iM++;
		iN1--;
	}

	for (char op = 0; op < 1 << iM; op++)
	{
		char mSum = m0;  // mSum holds x1+x2. max is less than 112.
		for (i = 0; i < iM; i++)
			mSum += m[i][(op >> i) & 1];

		int64 x1x2, x2x1;
		char buf[80] = "";
		if (m0)
			sprintf(buf, "%d", m0);
		for (i = 0; i < iM; i++)
			sprintf(buf + strlen(buf), "%d", m[i][(op >> i) & 1]);
		sscanf(buf, "%I64d", &x1x2);
		buf[0] = 0;
		for (i--; i >= 0; i--)
			sprintf(buf + strlen(buf), "%d", m[i][(op >> i) & 1]);
		if (m0)
			sprintf(buf + strlen(buf), "%d", m0);
		sscanf(buf, "%I64d", &x2x1);

		int r = x1x2 % 28 + x2x1 % 28;
		bool cond2 = IsMajorOrMinor(r);
		bool x1x2cond2 = cond2 || IsMajorOrMinor(x1x2 + x2x1 % 28);
		bool x2x1cond2 = cond2 || IsMajorOrMinor(x2x1 + x1x2 % 28);

		if (!((x1x2 % 9 == 2) || (IsMajorOrMinor(x1x2) && x1x2cond2) ||
			  (x2x1 % 9 == 2) || (IsMajorOrMinor(x2x1) && x2x1cond2)))
			continue;

		// sharte jam'e baghimandehha
		if (!(IsMajorOrMinor(r+mSum) || IsMajorOrMinor(r+mSum%28) || IsMajorOrMinor(r+mSum%9)))
			continue;

		return true;
	}

	return false;
}

bool CcScore951021::HasPriority(char &/*priority*/) const
{
	int sum = 0;
	for (int i=0; i<d_nSize; i++)
		sum += d_n[i];
	if (IsMajorOrMinor(sum))
		return true;
	
	char buf[80] = "";
	for (i=0; i<d_nSize; i++)
		sprintf(buf+strlen(buf), "%d", i);
	if (IsMajorOrMinor(buf))
		return true;

	buf[0] = 0;
	for (i=d_nSize-1; i>=0; i--)
		sprintf(buf+strlen(buf), "%d", i);
	if (IsMajorOrMinor(buf))
		return true;

	return false;
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

