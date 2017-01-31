struct CsScore951021PersistentItems
{
	char major;
	char minor;
	char numSidesWithScore;
	char priority;
};

class CcScore951021
{
	char d_sentence[29];
	char d_buf[29];
	char d_col[28];
	char d_len;
	char d_n[7];
	char d_nSize;

	void Make(LPCSTR sentence);
	void Reverse();
	bool HasScore951105() const;
	bool HasPriority(char &priority) const;
	bool HasScoreIndependently(char &major, char &minor, bool bAcceptMinor = true) const;
	bool HasScoreDependently(char &major, char &minor) const;
	bool HasScore(char &major, char &minor, char &priority);

public:
	bool HasScore(LPCSTR sentence, CsScore951021PersistentItems &items);
};

