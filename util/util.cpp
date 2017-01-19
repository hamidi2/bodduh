#include "stdafx.h"
#include "util.h"

namespace BUtil
{
	void DigitJoin(int64 r1, int64 r2, char *buf)
	{
		int pos = -1;
		while (r1)
		{
			buf[++pos] = '0' + r1 % 10;
			r1 /= 10;
			buf[++pos] = '0' + r2 % 10;
			r2 /= 10;
		}
		if (buf[pos] != '0')  // or !bSameSet
			pos++;
		buf[pos] = 0;
	}

	void RemoveDuplicates(const int64 i_ar[], int i_count, int64 o_ar[], int &o_count)
	{
		memcpy(o_ar, i_ar, i_count * sizeof(int64));
		o_count = i_count;
		for (int i = 0; i < o_count; i++)
			for (int j = i + 1; j < o_count;)
				if (o_ar[i] == o_ar[j])
				{
					if (j + 1 < o_count)
						memcpy(o_ar + j, o_ar + j + 1, (o_count - j - 1) * sizeof(int64));
					o_count--;
					o_ar[o_count] = 0;
				}
				else
				{
					j++;
				}
	}

	bool CheckScore(int64 r, char &major, char &minor, bool bZeroIsAcceptable)
	{
		if (IsMajor(r, bZeroIsAcceptable))
			major++;
		else if (IsMinor(r))
			minor++;
		else
			return false;
		return true;
	}

	int CalcScore950122(LPCSTR r)
	{
		const int divisors[] = {28, 28*9, 28*28};
		string k, notImportantQuotient, k2;
		int n, n2, n3, n3_2, n4, i;
		char score950122 = 0;
		bool isMajor;

		for (i = 0; i < _countof(divisors); i++)
		{
			Divide(r, divisors[i], k, n);

			bool isAbjadRevValid;
			k2 = AbjadRev(k.c_str(), isAbjadRevValid);	// k2 <- varuneye adadi
			if (!isAbjadRevValid)
				continue;

			int sod = DigitsSum(k.c_str());
			while (!(isMajor = IsMajor(sod)) && sod > 28)
				sod = DigitsSum(sod);
			score950122 += isMajor;

			Divide(k.c_str(), 28, notImportantQuotient, n2);
			Rev(k);										// k  <- varuneye raghami
			int lastJ = 4;
			Divide(k2.c_str(), 28, notImportantQuotient, n3_2);
			if (k != k2)
				Divide(k.c_str(), 28, notImportantQuotient, n3);
			else
				lastJ = 2;
			// we assume that both firstJ and lastJ can't be 2 simultaneously.
			int values[] = {n+n2+n3_2, n+abs(n2-n3_2), n+n2+n3, n+abs(n2-n3)};
			isMajor = false;
			for (int j = 0; j < lastJ && !isMajor; j++)
			{
				n4 = values[j];
				while (!(isMajor = IsMajor(n4)) && n4 > 28)
					n4 = DigitsSum(n4);
			}
			score950122 += isMajor;
		}
		return score950122;
	}

	int StringSortFunc(const void *p1, const void *p2)
	{
		string s1 = *(string *)p1;
		string s2 = *(string *)p2;
		return (s1 < s2) ? -1 : (s2 < s1) ? 1 : 0;
	}

	int Int64SortFunc(const void *p1, const void *p2)
	{
		int64 s1 = *(int64 *)p1;
		int64 s2 = *(int64 *)p2;
		return (s1 < s2) ? -1 : (s2 < s1) ? 1 : 0;
	}

	int IntSortFunc(const void *p1, const void *p2)
	{
		int s1 = *(int *)p1;
		int s2 = *(int *)p2;
		return (s1 < s2) ? -1 : (s2 < s1) ? 1 : 0;
	}

	void Divide(LPCSTR dividend, int divisor, string &quotient, int &remainder)
	{
		const int maxNumDigits = 18;  // an int64 may hold until 18 decimal digits.
		int64 r;
		int len = strlen(dividend);
		char buf[80];
		quotient = "";
		if (len > maxNumDigits)
		{
			int pos = 0;
			strncpy(buf, dividend, maxNumDigits);
			buf[maxNumDigits] = 0;
			pos += maxNumDigits;
			while (true)
			{
				sscanf(buf, "%I64d", &r);
				if (pos >= len)
					break;
				sprintf(buf, "%I64d", r / divisor);
				quotient += buf;
				r %= divisor;
				sprintf(buf, "%I64d%c", r, dividend[pos++]);
			}
		}
		else
		{
			sscanf(dividend, "%I64d", &r);
		}
		remainder = r % divisor;
		sprintf(buf, "%I64d", r / divisor);
		quotient += buf;
	}

	int DigitsSum(LPCSTR str)
	{
		int r = 0;
		for (; *str; str++)
			r += *str - '0';
		return r;
	}

	int DigitsSum(int64 r)
	{
		int n = 0;
		while (r)
		{
			n += r % 10;
			r /= 10;
		}
		return n;
	}

	int NumDigits(int64 r)
	{
		int n = 1;
		while ((r /= 10))
			n++;
		return n;
	}

	bool IsMajor(int64 r, bool bZeroIsAcceptable)
	{
		if (!bZeroIsAcceptable && r == 0)
			return false;
		static const int mods[] = {0, 8, 11, 17, 20};
		r %= 28;
		for (int i = 0; i < _countof(mods); i++)
			if (r == mods[i])
				return true;
		return false;
	}

	bool IsMajor(LPCSTR str, int *pMod)
	{
		int strLen = strlen(str);
		if (strLen > 18)  // an int64 may hold until 18 decimal digits.
		{
			char buf[80] = "";
			buf[18] = 0;
			int strPos = 0;
			int64 r;
			while (true)
			{
				int bufLen = strlen(buf);
				strncpy(buf + bufLen, str + strPos, 18 - bufLen);
				strPos += 18 - bufLen;
				sscanf(buf, "%I64d", &r);
				if (strPos >= strLen)
				{
					if (pMod) *pMod = r % 28;
					return IsMajor(r);
				}
				else
				{
					r %= 28;
					sprintf(buf, "%I64d", r);
				}
			}
		}
		else
		{
			int64 r;
			sscanf(str, "%I64d", &r);
			if (pMod) *pMod = r % 28;
			return IsMajor(r);
		}
	}

	bool IsMinor(int64 r)
	{
		int m9 = r % 9;
		int m28 = r % 28;
		return m9 == 2 || m9 == 8 || m28 == 2 || m28 == 26;
	}

	int64 Rev(int64 n)
	{
		int64 r = 0;
		while (n)
		{
			r = r * 10 + n % 10;
			n /= 10;
		}
		return r;
	}

	int64 Sum(int64 op1, int64 op2)
	{
		return op1 + op2;
	}

	int64 Diff(int64 op1, int64 op2)
	{
		char buf[80] = {};
		int i = 0;
		while (op1)
		{
			buf[i++] = '0' + (int) abs((op1 % 10) - (op2 % 10));
			op1 /= 10;
			op2 /= 10;
		}
		buf[i] = 0;
		int64 r;
		sscanf(_strrev(buf), "%I64d", &r);
		return r;
	}

	string AbjadRev(LPCSTR str, bool &isValid)
	{
		isValid = true;
		char dest[80] = "", *src = _strdup(str);
		int pos = strlen(src) - 1, prevPos = pos;
		do 
		{
			if (src[pos] != '0')
			{
				strcat(dest, src + pos);
				if (prevPos - pos > 5 || (prevPos - pos == 4 && src[pos] > 1))
					isValid = false;
				src[pos] = 0;
				prevPos = pos;
			}
			pos--;
		} while (pos != -1);
		free(src);
		return dest;
	}

	int64 AbjadRev(int64 r, bool &isValid)
	{
		char buf[80];
		sprintf(buf, "%I64d", r);
		sscanf(AbjadRev(buf, isValid).c_str(), "%I64d", &r);
		return r;
	}

	void Rev(string &str)
	{
		reverse(str.begin(), str.end());
	}

}

