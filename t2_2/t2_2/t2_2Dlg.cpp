
// t2_2Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "t2_2.h"
#include "t2_2Dlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define wm_init WM_USER

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
	PostMessage(WM_COMMAND, wm_init);

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
#define RET_IF_NOT_EQ(a, b) if (a > b) return true; if (a < b) return false
bool Ct2_2Dlg::CsSentenceRowCompare::operator()(const CsSentenceRow &left, const CsSentenceRow &right)
{
	RET_IF_NOT_EQ(right.score951021Items.priority, left.score951021Items.priority);
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
}

void Ct2_2Dlg::th_LoadDataFiles(void *p)
{
	Ct2_2Dlg *pThis = (Ct2_2Dlg *) p;
	CsRow r;
	for (int i = 15; i < 16; i++)
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

void Ct2_2Dlg::Calc(LPCSTR s, bool bRev, int memberOffset, int memberSize, CeOperation op, char &major, char &minor)
{
	int begin = bRev ? strlen(s) - 1 : 0;
	int end = bRev ? -1 : strlen(s);
	int step = bRev ? -1 : 1;
	int r = (op == opMul) ? 1 : 0;
	for (int i = begin; i != end; i += step)
	{
		if (op != opSeqRev)  // integral member
		{
			int member = 0;
			memcpy(&member, (char *) &letters[s[i]] + memberOffset, memberSize);
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
			seq.Format("%d%s", r, (char *) &letters[s[i]] + memberOffset);
			r = atoi(seq);
		}
		r %= 28;
	}
	CheckScore(r, major, minor);
}

#define CALC(s, bRev, member, op, major, minor)\
	Calc(s, bRev, offsetof(CsLetterSpec, member), sizeof(((CsLetterSpec *)0)->member), op, major, minor)
void Ct2_2Dlg::CalculateScore(LPCSTR s, char &major, char &minor)
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
#undef CALC

int Ct2_2Dlg::CalculateScore950219(LPCSTR sentence)
{
	int order[28], diff[14], n[7], m[3][2], i, iDiff, iN, iM, len = strlen(sentence), r;
	char buf[80];
	int score = 0;
	string s;

	// step 1
	for (i = 0; i < len; i++)
		order[i] = letters[sentence[i]].order;
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

void Ct2_2Dlg::AddSentence(const string &input, const string &dual, int64 r1, int64 r2, char major, char minor, char score950122)
{
	CsSentenceRow sRow = { r1, r2, major, minor, score950122 };
	int i = 0;
	do
	{
		if (r1)
		{
			sRow.sentence += input.substr(i, r1 % 10);
			i += r1 % 10;
			r1 /= 10;
		}
		if (r2)
		{
			sRow.sentence += dual.substr(i, r2 % 10);
			i += r2 % 10;
			r2 /= 10;
		}
	} while (r1 || r2);

	int sum = 0;
	int len = sRow.sentence.size();
	for (i = 0; i < len; i++)
		sum += letters[sRow.sentence[i]].order;
	if (sum / len > 14)
		return;

	CcScore951021 score951021;
	if (!score951021.HasScore(sRow.sentence.c_str(), sRow.score951021Items))
		return;
	CalculateScore(sRow.sentence.c_str(), sRow.sentenceMajor, sRow.sentenceMinor);
	d_sentences.insert(sRow);
}

void Ct2_2Dlg::AddSelections(const string &input, const string &dual, const CsRow &row)
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
		if (letters.find(input[i]) == letters.end())
			return false;
	return true;
}

void Ct2_2Dlg::OnBnClickedGo()
{
	char sentence[] = "تبقورشامصحنيبفلا";
	CcScore951021 score951021;
	CsScore951021PersistentItems items;
	bool bHasScore951021 = score951021.HasScore(sentence, items);
	//return;
	CString str;
	GetDlgItemText(IDC_INPUT, str);
	if (!str.GetLength())
		//str = "خودشناسي در آيينه ي بدوح";
		str = "اعتدال سازماني در آيينه ي بدوح";
	CString fn = str + ".txt";
	str.Remove(' ');
	str.Replace('آ', 'ا');
	if (!CheckInputIntegrity(str))
	{
		AfxMessageBox("invalid character in input");
		return;
	}

	FILE *fp = fopen(fn, "wt");
	if (!fp)
	{
		str.Format("couldn't open output file \"%s\"", fn);
		AfxMessageBox(str);
		return;
	}

	GetDlgItem(IDC_GO)->EnableWindow(FALSE);

	size_t maxLen = 0;
	string s, input = str, dual;
	fprintf(fp, "original question:        %s\n", input.c_str());	maxLen = max(maxLen, input.size());
	RemoveDuplicates(input);
	s = Separated(input);
	fprintf(fp, "duplicates removed:       %s\n", s.c_str());		maxLen = max(maxLen, s.size());
	Expand(input);
	s = Separated(input);
	fprintf(fp, "expanded:                 %s\n", s.c_str());		maxLen = max(maxLen, s.size());
	RemoveDuplicates(input);
	s = Separated(input);
	fprintf(fp, "duplicates removed again: %s\n", s.c_str());		maxLen = max(maxLen, s.size());
	CalculateDual(input, dual);
	fprintf(fp, "dual calculated:          %s\n", Separated(dual).c_str());

	int len = input.size(), iPair = len - 1;
	if (!d_pairsSpec[iPair].maxLen[0])  // if not ready yet
	{
		d_iPairWanted = iPair;
		WaitForSingleObject(d_hEvent, INFINITE);
	}
	auto count = d_pairsSpec[iPair].pairs.size();
	int i = 0;
	SetDlgItemText(IDC_PERCENT, "0%");
	for (vector<CsRow>::iterator it = d_pairsSpec[iPair].pairs.begin(); it != d_pairsSpec[iPair].pairs.end(); it++)
	{
		AddSelections(input, dual, *it);
		str.Format("%d%%", ++i * 100 / count);
		SetDlgItemText(IDC_PERCENT, str);
	}
	SetDlgItemText(IDC_PERCENT, "");

	fprintf(fp, "number of sentences:      %d\n", d_sentences.size());
	fprintf(fp, "---------------------------------------------------------------------------------------------------------------------\n");
	str.Format("%d", d_sentences.size() + 1);
	int rowNumberMaxLen = str.GetLength();
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

			Separated(it->sentence).c_str());
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

