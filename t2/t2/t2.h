// t2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdlib.h>
#include <string>
#include <sstream>
#include <vector>
#include <set>
#include <map>
#include <afx.h>
#include <iostream>

#include <util.h>

#define output printf
//#define output no_printf

class CT2
{
	map<int64, byte> d_sets[14];
	FILE *d_fp[28];
	struct pair
	{
		int64 r1, r2;
		bool operator <(const pair &) const;
	};
	map<pair, bool> d_bAdded[14];
	struct processThreadData 
	{
		CT2 *This;
		int iSet;
		bool bSameSet;
		bool done;
	};
	bool d_threadsStatus[28];

	static void processThread(void *);

	void calcMajorAndMinor(int64 r1, int64 r2, char &major, char &minor);
	int calcMajorAndMinor(int64 r1, int64 r2, int iSet, bool bSameSet, char &major, char &minor);
	
	void openFiles();
	void closeFiles();

	void addSet(byte n[], byte iSet, byte iSumMinusOne);
	void addPair(int64 r1, int64 r2, int iSet, bool bSameSet, int digitsSum, char major, char minor, char score950122);
	void makePairs();
	void process(int64 r1, int64 r2, int digitsSum, int iSet, bool bSameSet);
	void showThreadsStatus();
	void refineDB();

public:
	CT2();

	void makeDB();
};

