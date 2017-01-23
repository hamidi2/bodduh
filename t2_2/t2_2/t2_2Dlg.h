
// t2_2Dlg.h : header file
//

#pragma once

#include <vector>
#include <set>
#include <map>

using namespace std;

// Ct2_2Dlg dialog
class Ct2_2Dlg : public CDialogEx
{
// Construction
public:
	Ct2_2Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_T2_2_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

public:
	struct letterSpec
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

private:
	typedef __int64 int64;

	enum CeOperation
	{
		opAdd,
		opMul,
		opSeq,
		opSeqRev,
	};

	struct row
	{
		int64 r[2];
		char set;
		bool bSameSet;
		char major, minor, score950122;
	};

	struct sentenceRow
	{
		int64 r[2];
		char major, minor, score950122;
		char sentenceMajor, sentenceMinor;
		char major951021, minor951021, numSidesWithScore951021;
		CString sentence;
	};

	map<char, letterSpec> d_letters;

	struct sentenceRowCompare
	{
		bool operator()(const sentenceRow &left, const sentenceRow &right);
	};

	struct
	{
		vector<row> pairs;
		int maxLen[3];
	} d_pairsSpec[28];

	int d_iPairWanted;
	HANDLE d_hEvent;
	bool d_bThTerminate;
	set<sentenceRow, sentenceRowCompare> d_sentences;
	int d_rowNumber;

	void OnInit();
	void OnOK();
	void OnCancel();

	bool CheckInputIntegrity(const CString &input);
	void RemoveDuplicates(CString &);
	void Expand(CString &);
	void CalculateDual(const CString &input, CString &dual);
	CString Separated(const CString &input);
	void AddSentence(const CString &input, const CString &dual, int64 r1, int64 r2, char major, char minor, char score950122);
	void AddSelections(const CString &input, const CString &dual, const row &r);
	void CalculateScore(const CString &s, char &major, char &minor);
	void Calc(const CString &s, bool bRev, int memberOffset, int memberSize, CeOperation op, char &major, char &minor);
	int CalculateScore950219(LPCSTR sentence);
	bool IsSelfOrSumOfDigitsMajor(int n);
	void UpdateScore(char &major, char &minor, char major2, char minor2);
	bool HasScore951021(char n[], char nMax, char &major, char &minor);
	bool HasScore951021(LPCSTR sentence, char &major, char &minor, bool bReverse);

	static void CALLBACK Timer(HWND hWnd, UINT nMsg, UINT_PTR nIDEvent, DWORD dwTime);
	static void th_LoadDataFiles(void *);

public:
	afx_msg void OnBnClickedGo();
};
