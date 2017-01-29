﻿
// t2_2Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "t2_2.h"
#include "t2_2Dlg.h"
#include "afxdialogex.h"
#include <util.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define wm_init WM_USER

using namespace BUtil;

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


// Ct2_2Dlg dialog




Ct2_2Dlg::Ct2_2Dlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(Ct2_2Dlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void Ct2_2Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(Ct2_2Dlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_COMMAND(wm_init, OnInit)
	ON_BN_CLICKED(IDC_GO, &Ct2_2Dlg::OnBnClickedGo)
END_MESSAGE_MAP()


// Ct2_2Dlg message handlers

BOOL Ct2_2Dlg::OnInitDialog()
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
	//PostMessage(WM_COMMAND, wm_init);
	OnInit();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void Ct2_2Dlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void Ct2_2Dlg::OnPaint()
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
HCURSOR Ct2_2Dlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//---------------------------------------------------------------------------------------------------------------
/*
#define LOG(...) Log(__FILE__, __LINE__, __VA_ARGS__)

CString fileName(LPCSTR path)
{
	CString s = path;
	s = s.Right(s.GetLength() - (s.ReverseFind('\\') + 1));
	return s;
}

void Log(LPCSTR file, int line, LPCSTR fmt,...)
{
	static bool firstTime = true;
	va_list ap;
	va_start(ap, fmt);
	FILE *fp = fopen("t2_2.log", firstTime ? "wt" : "at");
	if (!fp)
		return;
	char buf[200];
	sprintf(buf, "%s:%d: ", fileName(file), line);
	vsprintf(buf + strlen(buf), fmt, ap);
	fprintf(fp, "%s", buf);
	fclose(fp);
	va_end(ap);
	firstTime = false;
}
*/

//---------------------------------------------------------------------------------------------------------------
static const Ct2_2Dlg::letterSpec table[] =
{
	'ا', 'س', "الف",  1,  "1",    1,    "1", 1, 1, 2,
	'ب', 'ع', "با",   2,  "2",    2,    "2", 1, 2, 4,
	'ج', 'ف', "جيم",  3,  "3",    3,    "3", 1, 3, 6,
	'د', 'ص', "دال",  4,  "4",    4,    "4", 1, 4, 8,
	'ه', 'ق', "ها",   5,  "5",    5,    "5", 2, 1, 2,
	'و', 'ر', "واو",  6,  "6",    6,    "6", 2, 2, 4,
	'ز', 'ش', "زا",   7,  "7",    7,    "7", 2, 3, 6,
	'ح', 'ت', "حا",   8,  "8",    8,    "8", 2, 4, 8,
	'ط', 'ث', "طا",   9,  "9",    9,    "9", 3, 1, 2,
	'ي', 'خ', "يا",  10, "01",   10,   "01", 3, 2, 4,
	'ک', 'ذ', "کاف", 11, "11",   20,   "02", 3, 3, 6,
	'ل', 'ض', "لام",  12, "21",   30,   "03", 3, 4, 8,
	'م', 'ظ', "ميم", 13, "31",   40,   "04", 4, 1, 2,
	'ن', 'غ', "نون", 14, "41",   50,   "05", 4, 2, 4,
	'س', 'ا', "سين", 15, "51",   60,   "06", 4, 3, 6,
	'ع', 'ب', "عين", 16, "61",   70,   "07", 4, 4, 8,
	'ف', 'ج', "فا",  17, "71",   80,   "08", 5, 1, 2,
	'ص', 'د', "صاد", 18, "81",   90,   "09", 5, 2, 4,
	'ق', 'ه', "قاف", 19, "91",  100,  "001", 5, 3, 6,
	'ر', 'و', "را",  20, "02",  200,  "002", 5, 4, 8,
	'ش', 'ز', "شين", 21, "12",  300,  "003", 6, 1, 2,
	'ت', 'ح', "تا",  22, "22",  400,  "004", 6, 2, 4,
	'ث', 'ط', "ثا",  23, "32",  500,  "005", 6, 3, 6,
	'خ', 'ي', "خا",  24, "42",  600,  "006", 6, 4, 8,
	'ذ', 'ک', "ذال", 25, "52",  700,  "007", 7, 1, 2,
	'ض', 'ل', "ضاد", 26, "62",  800,  "008", 7, 2, 4,
	'ظ', 'م', "ظا",  27, "72",  900,  "009", 7, 3, 6,
	'غ', 'ن', "غين", 28, "82", 1000, "0001", 7, 4, 8,
};

#define RET_IF_NOT_EQ(a, b) if (a > b) return true; if (a < b) return false
bool Ct2_2Dlg::sentenceRowCompare::operator()(const sentenceRow &left, const sentenceRow &right)
{
	RET_IF_NOT_EQ(left.score951021Items.priority, right.score951021Items.priority);
	RET_IF_NOT_EQ(left.score951021Items.numSidesWithScore, right.score951021Items.numSidesWithScore);
	char leftMajor = left.score951021Items.major;
	char rightMajor = right.score951021Items.major;
	char leftMinor = left.score951021Items.minor;
	char rightMinor = right.score951021Items.minor;
	RET_IF_NOT_EQ(leftMajor, rightMajor);
	RET_IF_NOT_EQ(leftMinor, rightMinor);
	leftMajor += left.major + left.score950122 + left.sentenceMajor;
	rightMajor += right.major + right.score950122 + right.sentenceMajor;
	leftMinor += left.minor + left.sentenceMinor;
	rightMinor += right.minor + right.sentenceMinor;
	RET_IF_NOT_EQ(leftMajor, rightMajor);
	RET_IF_NOT_EQ(leftMinor, rightMinor);
	return left.sentence < right.sentence;
}
#undef RET_IF_NOT_EQ

void Ct2_2Dlg::RemoveDuplicates(CString &input)
{
	CString output;
	for (int i = 0; i < input.GetLength(); i++)
	{
		if (output.Find(input[i]) == -1)
			output += input[i];
	}
	input = output;
}

void Ct2_2Dlg::Expand(CString &input)
{
	CString output;
	for (int i = 0; i < input.GetLength(); i++)
		output += d_letters[input[i]].expandedForm;
	input = output;
}

void Ct2_2Dlg::CalculateDual(const CString &input, CString &dual)
{
	dual.Empty();
	for (int i = 0; i < input.GetLength(); i++)
		dual += d_letters[input[i]].dual;
}

//---------------------------------------------------------------------------------------------------------------
void Ct2_2Dlg::OnInit()
{
	for (int i = 0; i < 28; i++)
		memset(d_pairsSpec[i].maxLen, 0, sizeof(d_pairsSpec[i].maxLen));
	d_iPairWanted = -1;
	d_rowNumber = 1;
	d_hEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
	d_bThTerminate = false;
	_beginthread(th_LoadDataFiles, 0, this);
	for (i = 0; i < _countof(table); i++)
		d_letters[table[i].c] = table[i];
	//PostMessage(WM_COMMAND, IDC_GO);
}

void Ct2_2Dlg::th_LoadDataFiles(void *p)
{
	Ct2_2Dlg *pThis = (Ct2_2Dlg *) p;
	row r;
	for (int i = 13; i < 14; i++)
	{
		char buf[80];
		sprintf(buf, "loading pairs of sum %d", i + 1);
		pThis->SetDlgItemText(IDC_STATUS, buf);
		sprintf(buf, "sum-%02d.db", i + 1);
		FILE *fp = fopen(buf, "rt");
		if (!fp)
		{
			CString s;
			s.Format("can't open %s", buf);
			AfxMessageBox(s);
			pThis->EndModalLoop(1);
			return;
		}
		while (fgets(buf, sizeof(buf), fp))
		{
			// scanf in Visual Studio doesn't support %hhd. so we've to use intermediate int or short variables.
			int set, bSameSet, major, minor, score950122;
			sscanf(buf, "%I64d %I64d %d %d %d %d %d", &r.r[0], &r.r[1], &set, &bSameSet, &major, &minor, &score950122);
			r.set = set;
			r.bSameSet = bSameSet ? true : false;
			r.major = major;
			r.minor = minor;
			r.score950122 = score950122;
			pThis->d_pairsSpec[i].pairs.push_back(r);
			pThis->d_pairsSpec[i].maxLen[0] = max(pThis->d_pairsSpec[i].maxLen[0], r.set + 1);
			pThis->d_pairsSpec[i].maxLen[1] = max(pThis->d_pairsSpec[i].maxLen[1], r.bSameSet ? r.set + 1 : r.set);
			if (pThis->d_bThTerminate)
				break;
		}
		if (pThis->d_bThTerminate)
		{
			fclose(fp);
			SetEvent(pThis->d_hEvent);
			return;
		}
		if (pThis->d_iPairWanted >= 0 && pThis->d_iPairWanted <= i)
			SetEvent(pThis->d_hEvent);
		fclose(fp);
	}
	pThis->SetDlgItemText(IDC_STATUS, "");
}

CString Ct2_2Dlg::Separated(const CString &input)
{
	CString s;
	for (int i = 0; i < input.GetLength(); i++)
	{
		s += input[i];
		s += ' ';
	}
	return s;
}

#define CALC(s, bRev, member, op, major, minor)\
	Calc(s, bRev, offsetof(letterSpec, member), sizeof(((letterSpec *)0)->member), op, major, minor)

void Ct2_2Dlg::Calc(const CString &s, bool bRev, int memberOffset, int memberSize, CeOperation op, char &major, char &minor)
{
	int begin = bRev ? s.GetLength() - 1 : 0;
	int end = bRev ? -1 : s.GetLength();
	int step = bRev ? -1 : 1;
	int r = (op == opMul) ? 1 : 0;
	for (int i = begin; i != end; i += step)
	{
		if (op != opSeqRev)  // integral member
		{
			int member = 0;
			memcpy(&member, (char *) &d_letters[s[i]] + memberOffset, memberSize);
			switch (op)
			{
			case opAdd:
				r += member % 28;
				break;
			case opMul:
				r *= member % 28;
				break;
			case opSeq:
				CString seq;
				seq.Format("%d%d", r, member);
				r = atoi(seq);
				break;
			}
		}
		else  // non-integral member (string)
		{
			CString seq;
			seq.Format("%d%s", r, (char *) &d_letters[s[i]] + memberOffset);
			r = atoi(seq);
		}
		r %= 28;
	}
	CheckScore(r, major, minor);
}

void Ct2_2Dlg::CalculateScore(const CString &s, char &major, char &minor)
{
	major = minor = 0;

	CALC(s, false, abjadCol, opAdd, major, minor);  // جمع شماره ستون جدول ابجد
	CALC(s, false, abjadCol, opMul, major, minor);  // ضرب شماره ستون جدول ابجد
	CALC(s, true , abjadCol, opSeq, major, minor);  // کنار هم گذاشتن شماره ستون جدول ابجد
	CALC(s, false, abjadCol, opSeq, major, minor);  // معکوس عددی کنار هم گذاشتن شماره ستون جدول ابجد

	CALC(s, false, bodduh  , opAdd, major, minor);  // جمع بدوح
	CALC(s, false, bodduh  , opMul, major, minor);  // ضرب بدوح
	CALC(s, true , bodduh  , opSeq, major, minor);  // کنار هم گذاشتن بدوح
	CALC(s, false, bodduh  , opSeq, major, minor);  // معکوس عددی کنار هم گذاشتن بدوح

	CALC(s, false, abjadRow, opAdd, major, minor);  // جمع ردیف جدول ابجد
	CALC(s, false, abjadRow, opMul, major, minor);  // ضرب ردیف جدول ابجد
	CALC(s, true , abjadRow, opSeq, major, minor);  // رشتهٔ حاصل از کنار هم گذاشتن ردیف جدول ابجد
	CALC(s, false, abjadRow, opSeq, major, minor);  // عکس رشتهٔ حاصل از کنار هم گذاشتن ردیف جدول ابجد

	major += CalculateScore950219(s);
}

bool Ct2_2Dlg::IsSelfOrSumOfDigitsMajor(int n)
{
	bool bMajor = false;
	while (bMajor = IsMajor(n), !bMajor && n > 28)
		n = DigitsSum(n);
	return bMajor;
}

int Ct2_2Dlg::CalculateScore950219(LPCSTR sentence)
{
	int order[28], diff[14], n[7], m[3][2], i, iDiff, iN, iM, len = strlen(sentence), r;
	char buf[80];
	int score = 0;
	CString s;

	// step 1
	for (i = 0; i < len; i++)
		order[i] = d_letters[sentence[i]].order;
	// step 2
	iDiff = 0;
	if (len % 2)
		diff[iDiff++] = order[len/2];
	for (i = len/2-1; i >= 0 ; i--)
	{
		r = abs(order[i] - order[len-1-i]);
		if (r == 0)
			r = 28;
		diff[iDiff++] = r;
	}
	// step 3
	bool signs[2][6] =
	{
		true, true, false, true, true, false,		// ++- ++-
		false, false, true, true, false, false,		// --+ +--
	};
	for (int iSign = 0; !score && (iSign < 2); iSign++)
	{
		// step 3
		buf[0] = 0;
		iN = 0;
		if (iDiff % 2)
		{
			sprintf(buf, "%d", diff[iDiff/2]);
			n[iN++] = diff[iDiff/2];
		}
		for (i = iDiff/2-1; i >= 0; i--)
		{
			int r1 = diff[i];
			int r2 = diff[iDiff-1-i];
			r = signs[iSign][iN%6] ? (r1+r2) : abs(r1-r2);
			if (r == 0)
				r = 28;
			sprintf(buf+strlen(buf), "%d", r);
			n[iN++] = r;
		}
		// step 4
		if (IsMajor(buf))
			score++;
		bool isAbjadRevValid;
		string abjadRev = AbjadRev(buf, isAbjadRevValid);
		if (!isAbjadRevValid)
		{
			CString s;
			s.Format("pattern %s has no valid abjad rev", buf);
			AfxMessageBox(s);
			exit(1);
		}
		_strrev(buf);
		if (IsMajor(buf))
			score++;
		if (buf != abjadRev && IsMajor(abjadRev.c_str()))
			score++;
		// step 5
		iM = 0;
		if (iN % 2)
		{
			m[0][0] = m[0][1] = n[iN/2];
			iM++;
		}
		for (i = iN/2-1; i >= 0; i--, iM++)
		{
			m[iM][0] = n[i] + n[iN-1-i];
			m[iM][1] = abs(n[i] - n[iN-1-i]);
			if (m[iM][1] == 0)
				m[iM][1] = 28;
		}
		if ((iM % 2) && (IsSelfOrSumOfDigitsMajor(m[iM/2][0]) || IsSelfOrSumOfDigitsMajor(m[iM/2][1])))
		{
			score++;
		}
		else
		{
			for (i = iM/2-1; i >= 0; i--)
			{
				int i2 = iM-1-i;
				if (IsSelfOrSumOfDigitsMajor(m[i][0] + m[i2][0]) || IsSelfOrSumOfDigitsMajor(abs(m[i][0] - m[i2][0])) ||
					IsSelfOrSumOfDigitsMajor(m[i][1] + m[i2][1]) || IsSelfOrSumOfDigitsMajor(abs(m[i][1] - m[i2][1])) ||
					IsSelfOrSumOfDigitsMajor(m[i][0] + m[i2][1]) || IsSelfOrSumOfDigitsMajor(abs(m[i][0] - m[i2][1])) ||
					IsSelfOrSumOfDigitsMajor(m[i][1] + m[i2][0]) || IsSelfOrSumOfDigitsMajor(abs(m[i][1] - m[i2][0])))
				{
					score++;
					break;
				}
			}
		}
	}
	return score;
}

void Ct2_2Dlg::UpdateScore(char &major, char &minor, char major2, char minor2)
{
	if (major2 < major)
		return;
	if (major2 > major || minor2 > minor)
		major = major2, minor = minor2;
}

bool Ct2_2Dlg::HasScore951021Independently(const char n[], char nSize, char &major, char &minor, bool bAcceptMinor)
{
	major = minor = 0;
	for (char i=0; i < nSize-1; i++)
		if (!IsMajor(n[i]))
			break;
	if (i == nSize-1)
	{
		CheckScore(n[i], major, minor);
		if (major || (bAcceptMinor && minor))
		{
			major += nSize-1;
			return true;
		}
	}
	return false;
}

bool Ct2_2Dlg::HasScore951021Dependently(const char n[], char nSize, char &major, char &minor)
{
	major = minor = 0;
	for (char i=0; i < nSize; i++)
	{
		char major2 = 0, minor2 = 0;
		CheckScore(n[i]+n[(i+1)%nSize], major2, minor2);
		CheckScore(abs(n[i]-n[(i+1)%nSize]), major2, minor2, false);
		if (major2)
			minor2 = 0;  // 951104: gharar bar in shod ke agar mesle 9,11 ham emtiaze asli bedeh ham emtiaze sayer, faghat asli dar nazar gerefteh besheh.
		if (!major2 && !minor2)
			break;
		major += major2;
		minor += minor2;
	}
	return (i == nSize);
}

bool Ct2_2Dlg::HasScore951021(const score951021Items &items, char &major, char &minor, bool bReverse)
{
	char n[7], col[28];
	memcpy(n, bReverse ? items.n : items.nRev, sizeof(n));
	memcpy(col, bReverse ? items.col : items.colRev, sizeof(col));
	int j = items.len % 4, pos;
	if (!j)
		return HasScore951021Independently(n, items.nSize, major, minor, false);
	pos = items.len / 4 * 4;
	char major2 = 0, minor2 = 0;
	char major3, minor3;
	if (HasScore951021Independently(n, items.nSize, major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/21
	for (; j<4; j++)
		n[pos/4] += col[j-items.len%4];
	if (HasScore951021Dependently(n, items.nSize, major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/23
	CString lastPart = (bReverse ? items.sentence : items.sentenceRev) + pos;
	if (!bReverse)
		lastPart.MakeReverse();
	Expand(lastPart);
	lastPart = lastPart.Left(4);
	char len = lastPart.GetLength();
	for (j=0; j<len; j++)
		col[pos+j] = d_letters[lastPart[j]].abjadCol;
	n[pos/4] = 0;
	for (j=0; j<len; j++)
		n[pos/4] += col[pos+j];
	// 7/24
	if (HasScore951021Dependently(n, items.nSize, major3, minor3))
		UpdateScore(major2, minor2, major3, minor3);
	// 7/25
	if (j < 4)
	{
		for (; j<4; j++)
			n[pos/4] += col[j-len];
		if (HasScore951021Dependently(n, items.nSize, major3, minor3))
			UpdateScore(major2, minor2, major3, minor3);
		Expand(lastPart);
		lastPart = lastPart.Left(4);
		len = lastPart.GetLength();
		for (j=1; j<len; j++)
			col[pos+j] = d_letters[lastPart[j]].abjadCol;
		n[pos/4] = 0;
		for (j=0; j<len; j++)
			n[pos/4] += col[pos+j];
		if (HasScore951021Dependently(n, items.nSize, major3, minor3))
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

void Ct2_2Dlg::AddSentence(const CString &input, const CString &dual, int64 r1, int64 r2, char major, char minor, char score950122)
{
	sentenceRow sRow = { r1, r2, major, minor, score950122 };
	int i = 0;
	do
	{
		if (r1)
		{
			sRow.sentence += input.Mid(i, r1 % 10);
			i += r1 % 10;
			r1 /= 10;
		}
		if (r2)
		{
			sRow.sentence += dual.Mid(i, r2 % 10);
			i += r2 % 10;
			r2 /= 10;
		}
	} while (r1 || r2);

	int sum = 0;
	int len = sRow.sentence.GetLength();
	for (i = 0; i < len; i++)
		sum += d_letters[sRow.sentence[i]].order;
	if (sum / len > 14)
		return;

	score951021Items score951021Items;
	MakeScore951021Items(sRow.sentence, score951021Items);
	sRow.score951021Items.major = sRow.score951021Items.minor = 0;
	sRow.score951021Items.numSidesWithScore = HasScore951021(score951021Items, sRow.score951021Items.major, sRow.score951021Items.minor, false);
	if (len % 4)
		sRow.score951021Items.numSidesWithScore += sRow.score951021Items.numSidesWithScore * 2 + HasScore951021(score951021Items, sRow.score951021Items.major, sRow.score951021Items.minor, true);
	if (!sRow.score951021Items.numSidesWithScore)
		return;
	if (!HasScore951021Priority(score951021Items, sRow.score951021Items.priority))
		return;
	if (!HasScore951105(score951021Items))
		return;
	CalculateScore(sRow.sentence, sRow.sentenceMajor, sRow.sentenceMinor);
	d_sentences.insert(sRow);
}

void Ct2_2Dlg::MakeScore951021Items(LPCSTR sentence, score951021Items &items)
{
	items.len = strlen(sentence);
	char iN = 0;
	items.nSize = (items.len-1)/4 + 1;
	memset(&items.n, 0, sizeof(items.n));
	memset(&items.nRev, 0, sizeof(items.n));
	for (char i = 0; i < items.len; i++)
	{
		items.colRev[items.len-1-i] = items.col[i] = d_letters[sentence[i]].abjadCol;
		items.bufRev[items.len-1-i] = items.buf[i] = items.col[i] + '0';
		items.n[i/4] += items.col[i];
		items.nRev[(items.len-1-i)/4] += items.col[i];
	}
	items.buf[i] = items.bufRev[i] = 0;
	strcpy(items.sentence, sentence);
	strcpy(items.sentenceRev, sentence);
	_strrev(items.sentenceRev);
}

bool Ct2_2Dlg::HasScore951105(const score951021Items &items)
{
	char m[4];
	char iN1 = (items.nSize + 1) / 2 - 1, iN2 = iN1, iM = 0;
	if (items.nSize % 2)
	{
		m[iM++] = items.nRev[iN1];
		iN1--;
	}
	iN2++;
	while (iN1 >= 0)
	{
		m[iM++] = abs(items.nRev[iN1] - items.nRev[iN2]);
		iN1--;
		iN2++;
	}
	char mSum = 0;  // max is 112
	for (char i = 0; i < iM; i++)
		mSum += m[i];
	if (mSum % 9 != 2)
		return false;
	char buf[80] = "";
	for (i = 0; i < iM; i++)
		sprintf(buf + strlen(buf), "%d", m[i]);
	string s;
	int remainder;
	Divide(buf, 28, s, remainder);
	if (remainder != 0)
		return false;
	buf[0] = 0;
	for (i = iM - 1; i >= 0; i--)
		sprintf(buf + strlen(buf), "%d", m[i]);
	Divide(buf, 28, s, remainder);
	if (remainder % 9 != 0)
		return false;
	return true;
}

bool Ct2_2Dlg::HasScore951021Priority(const score951021Items &items, char &score951021Priority)
{
	int n = 0;
	for (int i=0; i<items.len; i++)
		n += items.col[i];
	if (IsMajor(items.bufRev))
		score951021Priority = 2;
	else if (IsMinor(n))
		score951021Priority = 1;
	else
		return false;
	return true;
}

void Ct2_2Dlg::AddSelections(const CString &input, const CString &dual, const row &row)
{
	AddSentence(input, dual, row.r[0], row.r[1], row.major, row.minor, row.score950122);
	AddSentence(dual, input, row.r[0], row.r[1], row.major, row.minor, row.score950122);
	if (row.bSameSet)
	{
		if (row.r[0] != row.r[1])
		{
			AddSentence(input, dual, row.r[1], row.r[0], row.major, row.minor, row.score950122);
			AddSentence(dual, input, row.r[1], row.r[0], row.major, row.minor, row.score950122);
		}
		int64 r[2] = {Rev(row.r[0]), Rev(row.r[1])};
		if (!((r[0] == row.r[0] && r[1] == row.r[1]) || r[0] == row.r[1]))
		{
			AddSentence(input, dual, r[0], r[1], row.major, row.minor, row.score950122);
			AddSentence(dual, input, r[0], r[1], row.major, row.minor, row.score950122);
			if (r[0] != r[1])
			{
				AddSentence(input, dual, r[1], r[0], row.major, row.minor, row.score950122);
				AddSentence(dual, input, r[1], r[0], row.major, row.minor, row.score950122);
			}
		}
	}
}

bool Ct2_2Dlg::CheckInputIntegrity(const CString &input)
{
	for (int i = 0; i < input.GetLength(); i++)
		if (d_letters.find(input[i]) == d_letters.end())
			return false;
	return true;
}

void Ct2_2Dlg::OnBnClickedGo()
{
/*
	char sentence[] = "يسوصلزينفارقبت";
	char major = 0, minor = 0;
	score951021Items items;
	MakeScore951021Items(sentence, items);
	//bool bHasScore951021;
	//bHasScore951021 = HasScore951021(items, major, minor, false);
	//bHasScore951021 = HasScore951021(items, major, minor, true);
	bool bHasScore951105 = HasScore951105(items);
	return;
*/
	CString input, dual;
	GetDlgItemText(IDC_INPUT, input);
	input = "خودشناسي در ايينه ي بدوح";
	CString fn = input + ".txt";
	input.Remove(' ');
	input.Replace('آ', 'ا');
	if (!CheckInputIntegrity(input))
	{
		AfxMessageBox("invalid character in input");
		return;
	}

	FILE *fp = fopen(fn, "wt");
	if (!fp)
	{
		CString s;
		s.Format("couldn't open output file \"%s\"", fn);
		AfxMessageBox(s);
		return;
	}

	GetDlgItem(IDC_GO)->EnableWindow(FALSE);

	int maxLen = 0;
	CString s;
	fprintf(fp, "original question:        %s\n", input);	maxLen = max(maxLen, input.GetLength());
	RemoveDuplicates(input);
	s = Separated(input);
	fprintf(fp, "duplicates removed:       %s\n", s);		maxLen = max(maxLen, s.GetLength());
	Expand(input);
	s = Separated(input);
	fprintf(fp, "expanded:                 %s\n", s);		maxLen = max(maxLen, s.GetLength());
	RemoveDuplicates(input);
	s = Separated(input);
	fprintf(fp, "duplicates removed again: %s\n", s);		maxLen = max(maxLen, s.GetLength());
	CalculateDual(input, dual);
	fprintf(fp, "dual calculated:          %s\n", Separated(dual));

	int len = input.GetLength(), iPair = len - 1;
	if (!d_pairsSpec[iPair].maxLen[0])  // if not ready yet
	{
		d_iPairWanted = iPair;
		WaitForSingleObject(d_hEvent, INFINITE);
	}
	auto count = d_pairsSpec[iPair].pairs.size();
	int i = 0;
	SetDlgItemText(IDC_PERCENT, "0%");
	for (vector<row>::iterator it = d_pairsSpec[iPair].pairs.begin(); it != d_pairsSpec[iPair].pairs.end(); it++)
	{
		AddSelections(input, dual, *it);
		s.Format("%d%%", ++i * 100 / count);
		SetDlgItemText(IDC_PERCENT, s);
	}
	SetDlgItemText(IDC_PERCENT, "");

	fprintf(fp, "number of sentences:      %d\n", d_sentences.size());
	fprintf(fp, "---------------------------------------------------------------------------------------------------------------------\n", s);
	s.Format("%d", d_sentences.size() + 1);
	int rowNumberMaxLen = s.GetLength();
	i = 0;
	for (auto it = d_sentences.begin(); it != d_sentences.end(); it++)
	{
		fprintf(fp, " %*d  %*I64d,%-*I64d  %2d,%-2d  %2d | %2d,%-2d  %2d,%-2d  %2d,%-2d %d %d  %2d,%-2d | %s\n",
			rowNumberMaxLen, ++i,
			d_pairsSpec[iPair].maxLen[0], it->r[0], d_pairsSpec[iPair].maxLen[1], it->r[1],
			it->major, it->minor, it->score950122,

			it->major + it->score950122, it->minor,
			it->sentenceMajor, it->sentenceMinor,
			it->score951021Items.major, it->score951021Items.minor, it->score951021Items.numSidesWithScore, it->score951021Items.priority,
			it->major + it->score950122 + it->sentenceMajor + it->score951021Items.major, it->minor + it->sentenceMinor + it->score951021Items.minor,

			Separated(it->sentence));
	}

	d_sentences.clear();
	d_rowNumber = 1;
	fclose(fp);
	GetDlgItem(IDC_GO)->EnableWindow(TRUE);
}

void Ct2_2Dlg::OnOK()
{
	OnBnClickedGo();
}

void Ct2_2Dlg::OnCancel()
{
	//if (AfxMessageBox("Are you sure you want to exit?", MB_YESNOCANCEL | MB_ICONQUESTION) == IDYES)
	{
		d_bThTerminate = true;
		WaitForSingleObject(d_hEvent, 0);
		__super::OnCancel();
	}
}

