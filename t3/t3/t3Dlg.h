
// t3Dlg.h : header file
//

#pragma once

#include <vector>
#include <set>

using namespace std;

// Ct3Dlg dialog
class Ct3Dlg : public CDialogEx
{
// Construction
public:
	Ct3Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_t3_DIALOG };

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
		int64 n[2];
		int numDigits;
		bool bSameSet;
		string digitJoin, digitJoinRev;
		int digitJoinMod28, digitJoinRevMod28;
		int major, minor;
	};

	struct sentenceRow
	{
		int64 n[2];
		string digitJoin, digitJoinRev;
		int digitJoinMod28, digitJoinRevMod28;
		byte major, minor;
		byte totalMajor, totalMinor;
		CString sentence;
	};

	struct sentenceRowCompare
	{
		bool operator()(const sentenceRow &left, const sentenceRow &right)
		{
			if (left.totalMajor > right.totalMajor)
				return true;
			if (left.totalMajor < right.totalMajor)
				return false;
			if (left.totalMinor > right.totalMinor)
				return true;
			if (left.totalMinor < right.totalMinor)
				return false;
			/*
			if (left.major > right.major)
				return true;
			if (left.major < right.major)
				return false;
			if (left.minor > right.minor)
				return true;
			if (left.minor < right.minor)
				return false;
			if (left.n[0] < right.n[0])
				return true;
			if (left.n[0] > right.n[0])
				return false;
			if (left.n[1] < right.n[1])
				return true;
			if (left.n[1] > right.n[1])
				return false;
*/
			return left.sentence < right.sentence;
		}
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
	void AddSentence(const CString &input, const CString &dual, int64 r1, int64 r2, const string &digitJoin, const string &digitJoinRev, int digitJoinMod28, int digitJoinRevMod28, int major, int minor);
	void AddSelections(const CString &input, const CString &dual, const row &r);
	void CalculateScore(const CString &s, int &major, int &minor);
	bool IsMajor(int n);
	bool IsMinor(int mod);
	void Check(int r, int &major, int &minor);
	void Calc(const CString &s, bool bRev, int memberOffset, int memberSize, CeOperation op, int &major, int &minor);

	static void CALLBACK Timer(HWND hWnd, UINT nMsg, UINT_PTR nIDEvent, DWORD dwTime);
	static void th_LoadDataFiles(void *);

public:
	afx_msg void OnBnClickedGo();
};
