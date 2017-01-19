#include <string>
#include <wtypes.h>

using namespace std;

typedef unsigned char byte;
typedef __int64 int64;

namespace BUtil
{
	int64 Rev(int64 n);
	void Rev(string &str);
	int64 AbjadRev(int64 n, bool &isValid);
	string AbjadRev(LPCSTR str, bool &isValid);

	int64 Diff(int64 op1, int64 op2);
	int64 Sum(int64 op1, int64 op2);
	void Divide(LPCSTR dividend, int divisor, string &quotient, int &remainder);

	int DigitsSum(int64 r);
	int DigitsSum(LPCSTR str);

	int NumDigits(int64 r);

	bool IsMajor(int64 n, bool bZeroIsAcceptable = true);
	bool IsMajor(LPCSTR str, int *pMod = NULL);
	bool IsMinor(int64 r);

	bool CheckScore(int64 r, char &major, char &minor, bool bZeroIsAcceptable = true);
	int CalcScore950122(LPCSTR r);
	void DigitJoin(int64 r1, int64 r2, char *buf);

	int StringSortFunc(const void *p1, const void *p2);
	int Int64SortFunc(const void *p1, const void *p2);
	int IntSortFunc(const void *p1, const void *p2);

	typedef int (*SortFunc)(const void *, const void *);

	template<typename type, size_t count>
	void RemoveDuplicates(type(&ar)[count], size_t &n, size_t c = count)
	{
		SortFunc f =
			(typeid(type) == typeid(string)) ? StringSortFunc :
			(typeid(type) == typeid(int64)) ? Int64SortFunc :
			(typeid(type) == typeid(int)) ? IntSortFunc : NULL;
		qsort(ar, c, sizeof(type), f);
		n = c;
		int i = 0, j = 1;
		while (true)
		{
			if (j == n)
				break;
			while (ar[i] == ar[j])
			{
				j++;
				if (j == n)
					break;
			}
			if (j == n)
				break;
			ar[++i] = ar[j++];
		}
		n = i + 1;
	}

}

using namespace BUtil;

