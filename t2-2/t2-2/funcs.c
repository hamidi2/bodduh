#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef char bool;
const bool false = 0;
const bool true = 1;

typedef __int64 int64;

typedef struct
{
	int64 r1, r2;
	bool bSameSet;
	int major, minor;
} row;

#define SGN(r1, r2)\
	(((r1) < (r2)) ? -1 : ((r1) > (r2)) ? 1 : 0)

row *db;
int pos, size;

int sortFunc(const void *p1, const void *p2)
{
	row *r1 = (row *)p1, *r2 = (row *)p2;
	if (r1->major > r2->major)
		return 1;
	if (r1->major < r2->major)
		return -1;
	if (r1->minor > r2->minor)
		return 1;
	if (r1->minor < r2->minor)
		return -1;
	if (r1->r1 < r2->r1)
		return 1;
	if (r1->r1 > r2->r1)
		return -1;
	return SGN(r1->r2, r2->r2);
}

void insert(const row *r)
{
	if (pos == size)
	{
		db = (row *)realloc(db, size + sizeof(row));
		if (!db)
		{
			fprintf(stderr, "fatal: cannot allocate more than %lld bytes\n", size);
			exit(1);
		}
		size += sizeof(row);
	}
	memcpy((char *)db + pos, r, sizeof(row));
	pos += sizeof(row);
}

void clear()
{
	pos = 0;
}

void sortDB()
{
	int i, numRows;
	char buf[80];
	FILE *fp;
	row *rp, *rp2, r;

	fprintf(stderr, "\nsorting database...\n");
	for (i = 0; i < 28; i++)
	{
		fprintf(stderr, "sum=%d\n", i+1);
		sprintf(buf, "sum-%02d.db", i + 1);
		fp = fopen(buf, "r");
		if (!fp)
		{
			fprintf(stderr, "fatal: cannot open input file %s\n", buf);
			exit(1);
		}
		while (fgets(buf, sizeof(buf), fp))
		{
			sscanf(buf, "%I64d %I64d %d %d, %d", &r.r1, &r.r2, &r.bSameSet, &r.major, &r.minor);
			insert(&r);
		}
		fclose(fp);
		sprintf(buf, "sum-%02d-sorted.db", i + 1);
		fp = fopen(buf, "w");
		if (!fp)
		{
			fprintf(stderr, "fatal: cannot open output file %s\n", buf);
			exit(1);
		}
		numRows = pos / sizeof(row);
		qsort(db, numRows, sizeof(row), sortFunc);
		rp2 = (row *)((char *)db + pos);
		for (rp = db; rp != rp2; rp++)
			fprintf(fp, "%I64d %I64d\t%d\t%d,%d\n", rp->r1, rp->r2, rp->bSameSet, rp->major, rp->minor);
		fclose(fp);
		clear();
	}
}

