using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		class Pair
		{
			public byte[] Letters = new byte[2];
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (tbInput.Text.Length < 2)
			{
				MessageBox.Show("تعداد حروف ورودی حداقل باید دو حرف باشد");
				return;
			}
			var scores = new Dictionary<Pair, int>();
			var pair = new Pair();
			for (byte i = 1; i <= 28; i++)
				for (byte j = 1; j <= 28; j++)
				{
					var score = Score(Constants.Letters[tbInput.Text[0]].Abjad1, Constants.Letters[tbInput.Text[1]].Abjad1, i, j);
					pair.Letters[0] = i;
					pair.Letters[1] = j;
					scores[pair] = score;
				}
		}

		private int Score(byte a, byte b, byte x, byte y)
		{
			var score = 0;
			var ar = new int[16];
			ar[0] = ar[5] = ar[10] = ar[15] = a;
			ar[1] = b;
			ar[2] = x;
			ar[3] = y;
			ar[4] = a - b + a;
			ar[6] = a - b + x;
			ar[7] = a - b + y;
			ar[8] = a - x + a;
			ar[9] = a - x + b;
			ar[11] = a - x + y;
			ar[12] = a - y + a;
			ar[13] = a - y + b;
			ar[14] = a - y + x;
			for (var i = 0; i < ar.Length; i++)
				ar[i] = PutInRange(ar[i]);
			int[] rowsSum =
			{
				ar[0] + ar[1] + ar[2] + ar[3],
				0,  // not used
				0,  // not used
				ar[12] + ar[13] + ar[14] + ar[15],
			};
			// first column is defined to be the rightmost one.
			int[] columnsSum =
			{
				ar[0] + ar[4] + ar[8] + ar[12],
				ar[1] + ar[5] + ar[9] + ar[13],
				ar[2] + ar[6] + ar[10] + ar[14],
				ar[3] + ar[7] + ar[11] + ar[15],
			};
			int[] rows =
			{
				int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[2], ar[1], ar[0])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[7], ar[6], ar[5], ar[4])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[11], ar[10], ar[9], ar[8])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[15], ar[14], ar[13], ar[12])),
			};

			// 1
			score += Score(Diff(Sum(ar[3], ar[2]), Sum(ar[1], ar[0])));

			// 2
			score += Score(rowsSum[0], rowsSum[3]);

			// 3
			score += Score(columnsSum[3], columnsSum[0]);

			// 4
			score += Score(columnsSum[3], rowsSum[0]);

			// 5
			score += Score(rowsSum[3], columnsSum[0]);

			// 6
			score += Score(Diff(Sum(columnsSum[3], columnsSum[0]), Sum(rowsSum[0], rowsSum[3])));
			score += Score(Diff(Sum(columnsSum[3], columnsSum[0]), Diff(rowsSum[0], rowsSum[3])));

			// 7
			score += Score(columnsSum[0] + columnsSum[1] + columnsSum[2] + columnsSum[3]);

			// 8
			score += Score(rows[0] + rows[1] + rows[2] + rows[3]);

			// 9
			score += Score(rows[0] + rows[2]);

			// 10
			score += (int.Parse(string.Format("{0}{0}{0}{0}", ar[0])) % 28 == ar[0]) ? 1 : 0;
			score += (int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12])) % 28 == ar[1]) ? 1 : 0;

			// 11
			score += Score(int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[9], ar[6], ar[3])));

			// 12
			int[] sumOfDigits =
			{
				SumOfDigits(columnsSum[3]),
				SumOfDigits(columnsSum[2]),
				SumOfDigits(columnsSum[1]),
				SumOfDigits(columnsSum[0]),
			};
			score += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[1], sumOfDigits[2], sumOfDigits[3])));
			score += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[2], sumOfDigits[1], sumOfDigits[3])));
			score += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[3], sumOfDigits[2], sumOfDigits[1], sumOfDigits[0])));
			score += Score((sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3]) * 2);

			// 13
			var colMul = columnsSum[0] * columnsSum[3];
			var rowMul = rowsSum[0] * rowsSum[3];
			score += Score(colMul);
			score += Score(Sum(rowMul, colMul));
			score += Score(Diff(rowMul, colMul));

			// 14
			score += Score(Sum(columnsSum[0], columnsSum[3]) * Sum(rowsSum[0], rowsSum[3]));
			score += Score(Sum(columnsSum[0], columnsSum[3]) * Diff(rowsSum[0], rowsSum[3]));
			score += Score(Diff(columnsSum[0], columnsSum[3]) * Sum(rowsSum[0], rowsSum[3]));
			score += Score(Diff(columnsSum[0], columnsSum[3]) * Diff(rowsSum[0], rowsSum[3]));

			score += Score(Sum(rowsSum[0], columnsSum[3]) * Sum(columnsSum[0], rowsSum[3]));
			score += Score(Sum(rowsSum[0], columnsSum[3]) * Diff(columnsSum[0], rowsSum[3]));
			score += Score(Diff(rowsSum[0], columnsSum[3]) * Sum(columnsSum[0], rowsSum[3]));
			score += Score(Diff(rowsSum[0], columnsSum[3]) * Diff(columnsSum[0], rowsSum[3]));

			score += Score(Sum(rowsSum[0], columnsSum[0]) * Sum(columnsSum[3], rowsSum[3]));
			score += Score(Sum(rowsSum[0], columnsSum[0]) * Diff(columnsSum[3], rowsSum[3]));
			score += Score(Diff(rowsSum[0], columnsSum[0]) * Sum(columnsSum[3], rowsSum[3]));
			score += Score(Diff(rowsSum[0], columnsSum[0]) * Diff(columnsSum[3], rowsSum[3]));

			// 15
			int[] rowsRev =
			{
				int.Parse(string.Format("{0}{1}{2}{3}", ar[0], ar[1], ar[2], ar[3])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[4], ar[5], ar[6], ar[7])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[8], ar[9], ar[10], ar[11])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[13], ar[14], ar[15])),
			};
			int[] vars =
			{
				rows[0] - rowsRev[0],
				rows[1] - rowsRev[1],
				rows[2] - rowsRev[2],
				rows[3] - rowsRev[3],
			};
			score += Score(Diff(vars[0], vars[1]));
			score += Score(Sum(vars[2], vars[3]));
			score += Score(Diff(vars[2], vars[3]));
			score += Score(Sum(vars[0], vars[3]));
			score += Score(Diff(vars[0], vars[3]));

			// 16
			score += Score(columnsSum[0] * columnsSum[1] * columnsSum[2] * columnsSum[3]);

			// 17
			int[] columnsMul =
			{
				ar[0] * ar[4] * ar[8] * ar[12],
				ar[1] * ar[5] * ar[9] * ar[13],
				ar[2] * ar[6] * ar[10] * ar[14],
				ar[3] * ar[7] * ar[11] * ar[15],
			};
			score += Score(Sum(columnsMul[0], columnsMul[1]));
			score += Score(Diff(columnsMul[0], columnsMul[1]));
			score += Score(columnsMul[2]);
			score += Score(columnsMul[3]);

			// 18
			score += Score(Sum(rowsSum[0], rowsSum[1]));
			score += Score(Diff(rowsSum[0], rowsSum[1]));
			score += Score(Sum(rowsSum[0], rowsSum[2]));
			score += Score(Diff(rowsSum[0], rowsSum[2]));
			score += Score(Sum(rowsSum[1], rowsSum[3]));
			score += Score(rowsSum[0] * rowsSum[1] * rowsSum[2] * rowsSum[3]);

			// 19
			vars = new []
			{
				4 * Diff(a, y),
				4 * Diff(b, x),
			};
			score += Score(vars[0]);
			score += Score(Sum(vars[0], vars[1]));
			score += Score(Diff(vars[0], vars[1]));

			// 20
			vars = new []
			{
				rowsSum[0] * rowsSum[3] * columnsSum[0] * columnsSum[3],
				columnsSum[0] * columnsSum[1] * columnsSum[2] * columnsSum[3],
			};
			score += Score(Sum(vars[0], vars[1]));
			score += Score(Diff(vars[0], vars[1]));

			// 21
			vars = new[]
			{
				ar[3] * ar[6] * ar[9] * ar[12],
				a * a * a * a,
			};
			score += SumOfDigits(Sum(vars[0], vars[1]), false) == 2 * a ? 1 : 0;
			score += SumOfDigits(Diff(vars[0], vars[1]), false) == 2 * a ? 1 : 0;
			score += Score(SumOfDigits(Sum(vars[0], vars[1]), false));
			score += Score(SumOfDigits(Diff(vars[0], vars[1]), false));

			return score;
		}

		int SumOfDigits(int n, bool untilOneDigit = true)
		{
			while (true)
			{
				int sum = 0;
				do
				{
					sum += n % 10;
					n /= 10;
				} while (n != 0);
				if (sum < 10 || !untilOneDigit)
					return sum;
				n = sum;
			}
		}

		int PutInRange(int n)
		{
			while (n < 1)
				n += 28;
			//while (n > 28)
			//	n -= 28;
			return n;
		}

		int Sum(int n1, int n2)
		{
			return n1 + n2;
		}

		int Diff(int n1, int n2)
		{
			return Math.Abs(n1 - n2);
		}

		int Score(int n1, int n2)
		{
			int score = 0;
			score += Score(Sum(n1, n2));
			score += Score(Diff(n1, n2));
			return score;
		}

		int Score(int n)
		{
			n = PutInRange(n);
			var n28 = (n - 1) % 28 + 1;
			var n9 = (n - 1) % 9 + 1;
			if (n28 == 0 || n28 == 2 || n28 == 8 || n28 == 11 || n28 == 17)
				return 1;
			if (n < 28)
				return 0;
			if (n9 == 2 || n9 == 8)
				return 1;
			return 0;
		}
	}
}

