
// t2_2Dlg.h : header file
//

#pragma once

#include <vector>
#include <set>

#include <util.h>
#include "score951021.h"

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

private:
	enum CeOperation
	{
		opAdd,
		opMul,
		opSeq,
		opSeqRev,
	};

	struct CsRow
	{
		int64 r[2];
		char set;
		bool bSameSet;
		char major, minor, score950122;
	};

	struct CsSentenceRow
	{
		int64 r[2];
		char major, minor, score950122;
		char sentenceMajor, sentenceMinor;
		CsScore951021PersistentItems score951021Items;
		string sentence;
	};

	struct CsSentenceRowCompare
	{
		bool operator()(const CsSentenceRow &left, const CsSentenceRow &right);
	};

	struct
	{
		vector<CsRow> pairs;
		int maxLen[3];
	} d_pairsSpec[28];

	int d_iPairWanted;
	HANDLE d_hEvent;
	bool d_bThTerminate;
	set<CsSentenceRow, CsSentenceRowCompare> d_sentences;
	int d_rowNumber;

	void OnInit();
	void OnOK();
	void OnCancel();

	bool CheckInputIntegrity(const CString &);
	void AddSentence(const string &input, const string &dual, int64 r1, int64 r2, char major, char minor, char score950122);
	void AddSelections(const string &input, const string &dual, const CsRow &r);
	void CalculateScore(LPCSTR, char &major, char &minor);
	void Calc(LPCSTR, bool bRev, int memberOffset, int memberSize, CeOperation op, char &major, char &minor);
	// 950219
	int CalculateScore950219(LPCSTR);

	static void CALLBACK Timer(HWND hWnd, UINT nMsg, UINT_PTR nIDEvent, DWORD dwTime);
	static void th_LoadDataFiles(void *);

	afx_msg void OnBnClickedGo();
};

