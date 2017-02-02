#include "stdafx.h"
#include "util.h"

namespace BUtil
{
	map<char, CsLetterSpec> letters;

	class CBUtilInitializer
	{
	public:
		CBUtilInitializer() { Init(); }
		~CBUtilInitializer() {}
	} BUtilInitializer;

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

			Divide(k.c_str(), 9, notImportantQuotient, n2);
			score950122 += IsMajor(n2);

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
				isMajor = IsMajor(n4);
				if (isMajor)
					break;
				n4 %= 9;
				isMajor = IsMajor(n4);
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

	bool IsMinor(int64 r)
	{
		int m9 = r % 9;
		int m28 = r % 28;
		return
			m9 == 2 || m9 == 8 ||	// 9k+2 or 9k-1
			m28 == 2 || m28 == 6 || m28 == 11 || m28 == 17 || m28 == 22 || m28 == 26;	// 28k±2 or 28k±11k'
	}

	bool IsMajorOrMinor(LPCSTR str, bool bLookingForMajor)
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
					return bLookingForMajor ? IsMajor(r) : IsMinor(r);
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
			return bLookingForMajor ? IsMajor(r) : IsMinor(r);
		}
	}

	bool IsMajor(LPCSTR str)
	{
		return IsMajorOrMinor(str, true);
	}

	bool IsMinor(LPCSTR str)
	{
		return IsMajorOrMinor(str, false);
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

	void UpdateScore(char &major, char &minor, char major2, char minor2)
	{
		if (major2 < major)
			return;
		if (major2 > major || minor2 > minor)
			major = major2, minor = minor2;
	}

	const CsLetterSpec table[] =
	{
		'«', '”', "«·›",  1,  "1",    1,    "1", 1, 1, 2,
		'»', '⁄', "»«",   2,  "2",    2,    "2", 1, 2, 4,
		'Ã', '›', "ÃÌ„",  3,  "3",    3,    "3", 1, 3, 6,
		'œ', '’', "œ«·",  4,  "4",    4,    "4", 1, 4, 8,
		'Â', 'ﬁ', "Â«",   5,  "5",    5,    "5", 2, 1, 2,
		'Ê', '—', "Ê«Ê",  6,  "6",    6,    "6", 2, 2, 4,
		'“', '‘', "“«",   7,  "7",    7,    "7", 2, 3, 6,
		'Õ', ' ', "Õ«",   8,  "8",    8,    "8", 2, 4, 8,
		'ÿ', 'À', "ÿ«",   9,  "9",    9,    "9", 3, 1, 2,
		'Ì', 'Œ', "Ì«",  10, "01",   10,   "01", 3, 2, 4,
		'ò', '–', "ò«›", 11, "11",   20,   "02", 3, 3, 6,
		'·', '÷', "·«„",  12, "21",   30,   "03", 3, 4, 8,
		'„', 'Ÿ', "„Ì„", 13, "31",   40,   "04", 4, 1, 2,
		'‰', '€', "‰Ê‰", 14, "41",   50,   "05", 4, 2, 4,
		'”', '«', "”Ì‰", 15, "51",   60,   "06", 4, 3, 6,
		'⁄', '»', "⁄Ì‰", 16, "61",   70,   "07", 4, 4, 8,
		'›', 'Ã', "›«",  17, "71",   80,   "08", 5, 1, 2,
		'’', 'œ', "’«œ", 18, "81",   90,   "09", 5, 2, 4,
		'ﬁ', 'Â', "ﬁ«›", 19, "91",  100,  "001", 5, 3, 6,
		'—', 'Ê', "—«",  20, "02",  200,  "002", 5, 4, 8,
		'‘', '“', "‘Ì‰", 21, "12",  300,  "003", 6, 1, 2,
		' ', 'Õ', " «",  22, "22",  400,  "004", 6, 2, 4,
		'À', 'ÿ', "À«",  23, "32",  500,  "005", 6, 3, 6,
		'Œ', 'Ì', "Œ«",  24, "42",  600,  "006", 6, 4, 8,
		'–', 'ò', "–«·", 25, "52",  700,  "007", 7, 1, 2,
		'÷', '·', "÷«œ", 26, "62",  800,  "008", 7, 2, 4,
		'Ÿ', '„', "Ÿ«",  27, "72",  900,  "009", 7, 3, 6,
		'€', '‰', "€Ì‰", 28, "82", 1000, "0001", 7, 4, 8,
	};

	void Init()
	{
		for (char i = 0; i < _countof(table); i++)
			letters[table[i].c] = table[i];
	}

	void RemoveDuplicates(string &input)
	{
		string output;
		for (size_t i = 0; i < input.size(); i++)
		{
			if (output.find(input[i]) == -1)
				output += input[i];
		}
		input = output;
	}

	void Expand(string &input)
	{
		string output;
		for (size_t i = 0; i < input.size(); i++)
			output += letters[input[i]].expandedForm;
		input = output;
	}

	void CalculateDual(const string &input, string &dual)
	{
		dual.clear();
		for (size_t i = 0; i < input.size(); i++)
			dual += letters[input[i]].dual;
	}

	string Separated(const string &input)
	{
		string s;
		for (size_t i = 0; i < input.size(); i++)
		{
			s += input[i];
			s += ' ';
		}
		return s;
	}

	bool IsSelfOrSumOfDigitsMajor(int n)
	{
		if (IsMajor(n))
			return true;
		n %= 9;
		if (IsMajor(n))
			return true;
		return false;
	}

}

