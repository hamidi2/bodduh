
// t2_3Dlg.h : header file
//

#pragma once
#include "afxwin.h"

typedef __int64 int64;

// Ct2_3Dlg dialog
class Ct2_3Dlg : public CDialogEx
{
	static int64 rev(int64 n);
	static int64 abjadRev(int64 n);
	static int64 sum(int64 op1, int64 op2);
	static int64 diff(int64 op1, int64 op2);
	static int sumDigits(int64 i);
	static bool isMajor(int n);
	static bool isMinor(int n);
	static void removeDuplicates(const int64 i_ar[], int i_count, int64 o_ar[], int &o_count);

	CBitmap d_bmpMajor, d_bmpMinor, d_bmpNone, d_bmpEmpty;

	void calc();
	void setDlgItemText(int ctrlId, int64 n);
	void setDlgItemImage(int ctrlId, int n);

// Construction
public:
	Ct2_3Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_T2_3_DIALOG };

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
	afx_msg void OnEnChangefirst();
	afx_msg void OnEnChangesecond();
};

