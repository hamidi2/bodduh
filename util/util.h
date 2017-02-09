#include <string>
#include <wtypes.h>
#include <map>

using namespace std;

typedef unsigned char byte;
typedef __int64 int64;

namespace BUtil
{
	struct CsLetterSpec
	{
		char c;
		char dual;
		char expandedForm[4];
		char order;
		char orderRev[3];
		short abjad;
		char abjadRev[5];
		char abjadRow, abjadCol, bodduh;
	};

	extern map<char, CsLetterSpec> letters;

	void Init();

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
	bool IsMajor(LPCSTR str);
	bool IsMinor(int64 r);
	bool IsMinor(LPCSTR str);

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

	void UpdateScore(char &major, char &minor, char major2, char minor2);
	void RemoveDuplicates(string &);
	void Expand(string &);
	void CalculateDual(const string &input, string &dual);
	string Separated(const string &input);
	bool IsSelfOrSumOfDigitsMajor(int n);
}

using namespace BUtil;

