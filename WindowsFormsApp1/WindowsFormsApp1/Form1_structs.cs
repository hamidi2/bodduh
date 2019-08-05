using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		class Table
		{
			public byte x, y;
			public int[] colsSum;
		}

		class Scores
		{
			public int score1, score2;
			public static int Compare(Scores sc1, Scores sc2)
			{
				if (sc1.score1 < sc2.score1)
					return -1;
				if (sc1.score1 > sc2.score1)
					return 1;
				if (sc1.score2 < sc2.score2)
					return -1;
				if (sc1.score2 > sc2.score2)
					return 1;
				return 0;
			}
		}

		class OutputLetter
		{
			public byte Letter;
			public List<Result128> Results128WithInput;
			public OutputLetter(byte letter)
			{
				Letter = letter;
				Results128WithInput = new List<Result128>();
			}
		}

		struct LetterSpec
		{
			public byte InputLetter;
			public List<OutputLetter> OutputLetters;
		}

		class Pair
		{
			public byte Left, Right;
			public List<Result128> LeftLetterResults128;
			public List<Result128> RightLetterResults128;
			public List<Result128> SecondStepResults128 = new List<Result128>();
			public List<ResultBodduh> ThirdStepResultsBodduh = new List<ResultBodduh>();
			public List<ResultBodduh> FourthStepResultsBodduh = new List<ResultBodduh>();
			public int IndirectionCount;
			public byte OBV;  // this pair belongs to what OBV? مشخص میکند که این جفت عدد متعلق به کدام پخش میانگین است
			public Pair(byte left, byte right)
			{
				Left = left;
				Right = right;
			}
			public Pair(Pair from)
			{
				Left = from.Left;
				Right = from.Right;
				LeftLetterResults128 = new List<Result128>();
				LeftLetterResults128.AddRange(from.LeftLetterResults128);
				RightLetterResults128 = new List<Result128>();
				RightLetterResults128.AddRange(from.RightLetterResults128);
				SecondStepResults128 = new List<Result128>();
				SecondStepResults128.AddRange(from.SecondStepResults128);
				ThirdStepResultsBodduh = new List<ResultBodduh>();
				ThirdStepResultsBodduh.AddRange(from.ThirdStepResultsBodduh);
				FourthStepResultsBodduh = new List<ResultBodduh>();
				FourthStepResultsBodduh.AddRange(from.FourthStepResultsBodduh);
				IndirectionCount = from.IndirectionCount;
				OBV = from.OBV;
			}
		}

		struct Result128
		{
			public readonly byte n;  // 1, 2 or 8
			public readonly bool bWithInterfering28;
			public Result128(long l, bool w) { n = (byte)l; bWithInterfering28 = w; }
		}

		struct ResultBodduh
		{
			public readonly byte n;  // 2, 4, 6 or 8
			public readonly bool bWithInterfering28;
			public ResultBodduh(long l, bool w) { n = (byte)l; bWithInterfering28 = w; }
		}

	}
}

