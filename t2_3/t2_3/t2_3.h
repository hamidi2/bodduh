
// t2_3.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// Ct2_3App:
// See t2_3.cpp for the implementation of this class
//

class Ct2_3App : public CWinApp
{
public:
	Ct2_3App();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern Ct2_3App theApp;