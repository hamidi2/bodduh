
// t2_3Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "t2_3.h"
#include "t2_3Dlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// Ct2_3Dlg dialog




Ct2_3Dlg::Ct2_3Dlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(Ct2_3Dlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void Ct2_3Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(Ct2_3Dlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_EN_CHANGE(IDC_first, &Ct2_3Dlg::OnEnChangefirst)
	ON_EN_CHANGE(IDC_second, &Ct2_3Dlg::OnEnChangesecond)
END_MESSAGE_MAP()


// Ct2_3Dlg message handlers

BOOL Ct2_3Dlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	d_bmpEmpty.LoadBitmap(IDB_EMPTY);
	d_bmpMajor.LoadBitmap(IDB_MAJOR);
	d_bmpMinor.LoadBitmap(IDB_MINOR);
	d_bmpNone.LoadBitmap(IDB_NONE);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void Ct2_3Dlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void Ct2_3Dlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR Ct2_3Dlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void Ct2_3Dlg::OnEnChangefirst()
{
	calc();
}

void Ct2_3Dlg::OnEnChangesecond()
{
	calc();
}

void Ct2_3Dlg::calc()
{
	int64 op1 = 0, op2 = 0;
	CString s;
	GetDlgItemText(IDC_first, s);
	sscanf(s, "%I64d", &op1);
	GetDlgItemText(IDC_second, s);
	sscanf(s, "%I64d", &op2);

	int i;

	// step1
	int64 op[] = { op1, op2, rev(op1), rev(op2) };
	int max = 4;
	if (op[0] == op[2] && op[1] == op[3])
	{
		max = 2;
		op[2] = op[3] = -1;
	}
	setDlgItemText(IDC_firstRev, op[2]);
	setDlgItemText(IDC_secondRev, op[3]);
	int mod[4] = {0, 0, -1, -1};
	for (i = 0; i < max; i++)
		mod[i] = op[i] % 28;
	setDlgItemText(IDC_firstMod28, mod[0]);
	setDlgItemText(IDC_secondMod28, mod[1]);
	setDlgItemText(IDC_firstRevMod28, mod[2]);
	setDlgItemText(IDC_secondRevMod28, mod[3]);
	int step1[] = { mod[0] + mod[1], abs(mod[0] - mod[1]), mod[2] + mod[3], abs(mod[2] - mod[3]) };
	if (max == 2)
		step1[2] = step1[3] = -1;
	setDlgItemText(IDC_firstMod28PlusSecondMod28, step1[0]);
	setDlgItemText(IDC_firstMod28DiffSecondMod28, step1[1]);
	setDlgItemText(IDC_firstRevMod28PlusSecondRevMod28, step1[2]);
	setDlgItemText(IDC_firstRevMod28DiffSecondRevMod28, step1[3]);
	setDlgItemImage(IDC_bmp1, step1[0]);
	setDlgItemImage(IDC_bmp2, step1[1]);
	setDlgItemImage(IDC_bmp3, step1[2]);
	setDlgItemImage(IDC_bmp4, step1[3]);

	// step2
	int64 step2[] =
	{
		sum(op[0], op[1]), diff(op[0], op[1]), 0, 0,
		(max == 2) ? -1 : sum(op[2], op[3]), (max == 2) ? -1 : diff(op[2], op[3]), -1, -1
	};
	for (i = 0; i < max; i++)
		step2[i + i/2 * 2 + 2] = abjadRev(step2[i + i/2 * 2]);

	setDlgItemText(IDC_sum, step2[0]);
	setDlgItemText(IDC_digitalDiff, step2[1]);
	setDlgItemText(IDC_sumRev, step2[2]);
	setDlgItemText(IDC_digitalDiffRev, step2[3]);

	setDlgItemText(IDC_sumOfRev, step2[4]);
	setDlgItemText(IDC_digitalDiffOfRev, step2[5]);
	setDlgItemText(IDC_sumOfRevRev, step2[6]);
	setDlgItemText(IDC_digitalDiffOfRevRev, step2[7]);

	setDlgItemText(IDC_sumMod28, step2[0] % 28);
	setDlgItemText(IDC_digitalDiffMod28, step2[1] % 28);
	setDlgItemText(IDC_sumRevMod28, step2[2] % 28);
	setDlgItemText(IDC_digitalDiffRevMod28, step2[3] % 28);

	setDlgItemText(IDC_sumOfRevMod28, step2[4] % 28);
	setDlgItemText(IDC_digitalDiffOfRevMod28, step2[5] % 28);
	setDlgItemText(IDC_sumOfRevRevMod28, step2[6] % 28);
	setDlgItemText(IDC_digitalDiffOfRevRevMod28, step2[7] % 28);

	setDlgItemImage(IDC_bmp5, step2[0] % 28);
	setDlgItemImage(IDC_bmp6, step2[1] % 28);
	setDlgItemImage(IDC_bmp7, step2[2] % 28);
	setDlgItemImage(IDC_bmp8, step2[3] % 28);
	setDlgItemImage(IDC_bmp9, step2[4] % 28);
	setDlgItemImage(IDC_bmp10, step2[5] % 28);
	setDlgItemImage(IDC_bmp11, step2[6] % 28);
	setDlgItemImage(IDC_bmp12, step2[7] % 28);
}

void Ct2_3Dlg::setDlgItemText(int ctrlId, int64 n)
{
	if (n != -1)
	{
		char buf[80];
		sprintf(buf, "%I64d", n);
		SetDlgItemText(ctrlId, buf);
	}
	else
	{
		SetDlgItemText(ctrlId, "");
	}
}

int64 Ct2_3Dlg::rev(int64 n)
{
	int64 r = 0;
	while (n)
	{
		r = r * 10 + n % 10;
		n /= 10;
	}
	return r;
}

int64 Ct2_3Dlg::abjadRev(int64 n)
{
	char src[80], dest[80] = "";
	sprintf(src, "%I64d", n);
	int pos = strlen(src) - 1;
	do 
	{
		if (src[pos] != '0')
		{
			strcat(dest, src + pos);
			src[pos] = 0;
		}
		pos--;
	} while (pos != -1);
	int64 r = 0;
	sscanf(dest, "%I64d", &r);
	return r;
}

int64 Ct2_3Dlg::sum(int64 op1, int64 op2)
{
	return op1 + op2;
}

int64 Ct2_3Dlg::diff(int64 op1, int64 op2)
{
	char buf[80] = {};
	int i = 0;
	while (op1)
	{
		buf[i++] = '0' + abs((op1 % 10) - (op2 % 10));
		op1 /= 10;
		op2 /= 10;
	}
	buf[i] = 0;
	int64 r = 0;
	sscanf(strrev(buf), "%I64d", &r);
	return r;
}

int Ct2_3Dlg::sumDigits(int64 i)
{
	int r = 0;
	while (i)
	{
		r += i % 10;
		i /= 10;
	}
	return r;
}

void Ct2_3Dlg::setDlgItemImage(int ctrlId, int n)
{
	CBitmap &bmp = (n == -1) ? d_bmpEmpty : isMajor(n) ? d_bmpMajor : isMinor(n) ? d_bmpMinor : d_bmpNone;
	//CStatic *pStatic = dynamic_cast<CStatic *>(GetDlgItem(ctrlId));
	//if (!pStatic)
	//	return;
	CStatic *pStatic = (CStatic *) GetDlgItem(ctrlId);
	pStatic->SetBitmap(HBITMAP(bmp));
}

bool Ct2_3Dlg::isMajor(int mod)
{
	const int mods[] = {0, 8, 11, 17, 20};
	for (int i = 0; i < _countof(mods); i++)
		if (mod == mods[i])
			return true;
	return false;
}

bool Ct2_3Dlg::isMinor(int mod)
{
	const int mods[] = {2, 26, 30, 35, 38, 44, 47, 54};
	for (int i = 0; i < _countof(mods); i++)
		if (mod == mods[i])
			return true;
	return false;
}

