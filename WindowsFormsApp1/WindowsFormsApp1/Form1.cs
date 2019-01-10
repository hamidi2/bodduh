using System;
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
        public Form1()
        {
            InitializeComponent();
			//Score(21, 17, 1, 1, out _colsSum);
			//Score(21, 17, 1, 21, out _colsSum);
		}

		class Table
        {
			public byte x, y;
			public int[] colsSum;// = new int[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
			// 4077 4117 3953 4069 کیفحالالرضامعالمامون
			// 3042 3106 2918 3030 کیفحالرضمعون
			// 2334 2454 2290 2358 کیهوزتادسرغمن 
			// 1238 1270 1102 1294 کیهوزتوایدکهدهیدولتمان
			// 1764 1808 1608 1776 کیهوزتادلمن
			if (tbInput.Text.Length < 2)
            {
                MessageBox.Show("ورودی حداقل باید شامل دو حرف باشد");
                return;
            }
			tbOutput.Text = "";
            var scores = new Dictionary<Table, int>();
			Table table = null;
			var a = Constants.Letters[tbInput.Text[0]].Abjad1;
			var b = Constants.Letters[tbInput.Text[1]].Abjad1;
			var iInput = 2;
			for (byte i = 1; i <= 28; i++)
                for (byte j = 1; j <= 28; j++)
                {
					table = new Table();
					var score = Score(a, b, i, j, out table.colsSum);
					table.x = i;
                    table.y = j;
                    scores[table] = score;
                }
			var list = scores.ToList();
			list.Sort((item1, item2) => item2.Value.CompareTo(item1.Value));
			table = list[0].Key;
			_colsSum[0] += table.colsSum[0];
			_colsSum[1] += table.colsSum[1];
			_colsSum[2] += table.colsSum[2];
			_colsSum[3] += table.colsSum[3];
			foreach (var letter in Constants.Letters)
				if (letter.Value.Abjad1 == table.x)
					tbOutput.Text += letter.Key;
			foreach (var letter in Constants.Letters)
				if (letter.Value.Abjad1 == table.y)
					tbOutput.Text += letter.Key;
			while (true)
			{
				a = PutInRange(a + b);
				b = Constants.Letters[tbInput.Text[iInput]].Abjad1;
				var x = PutInRange(table.x + table.y);
				scores = new Dictionary<Table, int>();
				for (byte j = 1; j <= 28; j++)
				{
					table = new Table();
					var score = Score(a, b, x, j, out table.colsSum);
					table.x = x;
					table.y = j;
					scores[table] = score;
				}
				list = scores.ToList();
				list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
				table = list[0].Key;
				_colsSum[0] += table.colsSum[0];
				_colsSum[1] += table.colsSum[1];
				_colsSum[2] += table.colsSum[2];
				_colsSum[3] += table.colsSum[3];
				foreach (var letter in Constants.Letters)
					if (letter.Value.Abjad1 == table.y)
						tbOutput.Text += letter.Key;
				iInput++;
				if (iInput == tbInput.Text.Length)
					break;
			}
			Debug.WriteLine("{0} {1} {2} {3}", _colsSum[3], _colsSum[2], _colsSum[1], _colsSum[0]);
		}

		int[] _colsSum = new int[4];

		private int Score(byte a, byte b, byte x, byte y, out int[] colsSum)
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
				ar[4] + ar[5] + ar[6] + ar[7],
				ar[8] + ar[9] + ar[10] + ar[11],
				ar[12] + ar[13] + ar[14] + ar[15],
            };
            // first column is defined to be the rightmost one.
            colsSum = new int[]
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
			int[] scores = new int[30];

            // 1
			scores[0] = Score(Diff(Sum(ar[3], ar[2]), Sum(ar[1], ar[0])));

            // 2
            scores[1] = Score(rowsSum[0], rowsSum[3]);

			// 3
			scores[2] = Score(colsSum[3], colsSum[0]);

			// 4
			scores[3] = Score(colsSum[3], rowsSum[0]);

			// 5
			scores[4] = Score(rowsSum[3], colsSum[0]);

			// 6
			scores[5] = Score(Diff(Sum(colsSum[3], colsSum[0]), Sum(rowsSum[0], rowsSum[3])));
			scores[5] += Score(Diff(Sum(colsSum[3], colsSum[0]), Diff(rowsSum[0], rowsSum[3])));

			// 7
			scores[6] = Score(colsSum[0] + colsSum[1] + colsSum[2] + colsSum[3]);

			// 8
			scores[7] = Score(rows[0] + rows[1] + rows[2] + rows[3]);

			// 9
			scores[8] = Score(rows[0] + rows[2]);

			// 10
			scores[9] = (int.Parse(string.Format("{0}{0}{0}{0}", ar[0])) % 28 == ar[0]) ? 1 : 0;
			scores[9] += (int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12])) % 28 == ar[1]) ? 1 : 0;

			// 11
			scores[10] = Score(int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[9], ar[6], ar[3])));

            // 12
            int[] sumOfDigits =
            {
                SumOfDigits(colsSum[3]),
                SumOfDigits(colsSum[2]),
                SumOfDigits(colsSum[1]),
                SumOfDigits(colsSum[0]),
            };
			scores[11] = Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[1], sumOfDigits[2], sumOfDigits[3])));
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[2], sumOfDigits[1], sumOfDigits[3])));
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[3], sumOfDigits[2], sumOfDigits[1], sumOfDigits[0])));
			scores[11] += Score((sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3]) * 2);

            // 13
            var colMul = colsSum[0] * colsSum[3];
            var rowMul = rowsSum[0] * rowsSum[3];
			scores[12] = Score(colMul);
			scores[12] += Score(Sum(rowMul, colMul));
			scores[12] += Score(Diff(rowMul, colMul));

			// 14
			scores[13] = Score(Sum(colsSum[0], colsSum[3]) * Sum(rowsSum[0], rowsSum[3]));
			scores[13] += Score(Sum(colsSum[0], colsSum[3]) * Diff(rowsSum[0], rowsSum[3]));
			scores[13] += Score(Diff(colsSum[0], colsSum[3]) * Sum(rowsSum[0], rowsSum[3]));
			scores[13] += Score(Diff(colsSum[0], colsSum[3]) * Diff(rowsSum[0], rowsSum[3]));

			scores[13] += Score(Sum(rowsSum[0], colsSum[3]) * Sum(colsSum[0], rowsSum[3]));
			scores[13] += Score(Sum(rowsSum[0], colsSum[3]) * Diff(colsSum[0], rowsSum[3]));
			scores[13] += Score(Diff(rowsSum[0], colsSum[3]) * Sum(colsSum[0], rowsSum[3]));
			scores[13] += Score(Diff(rowsSum[0], colsSum[3]) * Diff(colsSum[0], rowsSum[3]));

			scores[13] += Score(Sum(rowsSum[0], colsSum[0]) * Sum(colsSum[3], rowsSum[3]));
			scores[13] += Score(Sum(rowsSum[0], colsSum[0]) * Diff(colsSum[3], rowsSum[3]));
			scores[13] += Score(Diff(rowsSum[0], colsSum[0]) * Sum(colsSum[3], rowsSum[3]));
			scores[13] += Score(Diff(rowsSum[0], colsSum[0]) * Diff(colsSum[3], rowsSum[3]));

            // 15
            int[] rowsRev =
            {
                int.Parse(string.Format("{0}{1}{2}{3}", ar[0], ar[1], ar[2], ar[3])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[4], ar[5], ar[6], ar[7])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[8], ar[9], ar[10], ar[11])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[13], ar[14], ar[15])),
            };
            long[] vars =
            {
                rows[0] - rowsRev[0],
                rows[1] - rowsRev[1],
                rows[2] - rowsRev[2],
                rows[3] - rowsRev[3],
            };
			scores[14] = Score(Diff(vars[0], vars[1]));
			scores[14] += Score(Sum(vars[2], vars[3]));
			scores[14] += Score(Diff(vars[2], vars[3]));
			scores[14] += Score(Sum(vars[0], vars[3]));
			scores[14] += Score(Diff(vars[0], vars[3]));

			// 16
			scores[15] += Score(colsSum[0] * colsSum[1] * colsSum[2] * colsSum[3]);

            // 17
            int[] columnsMul =
            {
                ar[0] * ar[4] * ar[8] * ar[12],
                ar[1] * ar[5] * ar[9] * ar[13],
                ar[2] * ar[6] * ar[10] * ar[14],
                ar[3] * ar[7] * ar[11] * ar[15],
            };
			scores[16] = Score(Sum(columnsMul[0], columnsMul[1]));
			scores[16] += Score(Diff(columnsMul[0], columnsMul[1]));
			scores[16] += Score(columnsMul[2]);
			scores[16] += Score(columnsMul[3]);

			// 18
			scores[17] += Score(Sum(rowsSum[0], rowsSum[1]));
			scores[17] += Score(Diff(rowsSum[0], rowsSum[1]));
            scores[17] += Score(Sum(rowsSum[0], rowsSum[2]));
            scores[17] += Score(Diff(rowsSum[0], rowsSum[2]));
            scores[17] += Score(Sum(rowsSum[1], rowsSum[3]));
            scores[17] += Score(rowsSum[0] * rowsSum[1] * rowsSum[2] * rowsSum[3]);

            // 19
            vars = new long[]
            {
                4 * Diff(a, y),
                4 * Diff(b, x),
            };
            scores[18] = Score(vars[0]);
            scores[18] += Score(vars[1]);
            scores[18] += Score(Sum(vars[0], vars[1]));
            scores[18] += Score(Diff(vars[0], vars[1]));

			vars = new long[]
			{
				Diff(ar[0], ar[3]) + Diff(ar[4], ar[7]) + Diff(ar[8], ar[11]) + Diff(ar[12], ar[15]),
				Diff(ar[1], ar[2]) + Diff(ar[5], ar[6]) + Diff(ar[9], ar[10]) + Diff(ar[13], ar[14]),
			};
			scores[18] = Score(vars[0]);
			scores[18] += Score(vars[1]);
			scores[18] += Score(Sum(vars[0], vars[1]));
			scores[18] += Score(Diff(vars[0], vars[1]));

			// 20
			vars = new long[]
            {
                rowsSum[0] * rowsSum[3] * colsSum[0] * colsSum[3],
                colsSum[0] * colsSum[1] * colsSum[2] * colsSum[3],
            };
            scores[19] = Score(Sum(vars[0], vars[1]));
            scores[19] += Score(Diff(vars[0], vars[1]));

            // 21
            vars = new long[]
            {
                ar[3] * ar[6] * ar[9] * ar[12],
                a * a * a * a,
                SumOfDigits(Sum(vars[0], vars[1]), false),
                SumOfDigits(Diff(vars[0], vars[1]), false),
            };
            scores[20] = vars[2] % a == 0 ? 1 : 0;
            scores[20] += vars[3] % a == 0 ? 1 : 0;
            scores[20] += Score(vars[2]);
            scores[20] += Score(vars[3]);

            // 22
            int[] cols =
            {
                int.Parse(string.Format("{0}{1}{2}{3}", ar[0], ar[4], ar[8], ar[12])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[1], ar[5], ar[9], ar[13])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[2], ar[6], ar[10], ar[14])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[7], ar[11], ar[15])),
            };
            int[] colsRev =
            {
                int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[8], ar[4], ar[0])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[13], ar[9], ar[5], ar[1])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[14], ar[10], ar[6], ar[2])),
                int.Parse(string.Format("{0}{1}{2}{3}", ar[15], ar[11], ar[7], ar[3])),
            };
            vars = new long[]
            {
                Diff(rows[0], rowsRev[0]),
                Diff(rows[1], rowsRev[1]),
                Diff(rows[2], rowsRev[2]),
                Diff(rows[3], rowsRev[3]),
                0,
                Diff(cols[3], colsRev[3]),
                Diff(cols[2], colsRev[2]),
                Diff(cols[1], colsRev[1]),
                Diff(cols[0], colsRev[0]),
				0,
            };
			vars[4] = vars[0] + vars[1] + vars[2] + vars[3];
			vars[9] = vars[5] + vars[6] + vars[7] + vars[8];
			scores[21] = vars[4] % 9 == 0 ? 1 : 0;
            scores[21] += vars[9] % 9 == 0 ? 1 : 0;
            scores[21] += Score(Sum(vars[4], vars[9]));
            scores[21] += Score(Diff(vars[4], vars[9]));

            // 23
            scores[22] = Score(Diff(vars[0], vars[8]));
            scores[22] += Score(Diff(vars[0], vars[6]) + vars[7] + vars[8]);
            scores[22] += Score(Diff(vars[3], vars[8]));
            scores[22] += Score(vars[2] + vars[3]);

            // 24 -> 29
            vars = new long[]
            {
				// 50: rowsSum[0], 30: rowsSum[3]
				// 58: colsSum[3], 46: colsSum[2], 34: colsSum[1], 38: colsSum[0]
                long.Parse(string.Format("{0}{1}{2}{3}", colsSum[3], colsSum[2], colsSum[1], colsSum[0])),  // 0. 58463438
				long.Parse(string.Format("{0}{1}{2}{3}", colsSum[0], colsSum[1], colsSum[2], colsSum[3])),  // 1. 38344658
				long.Parse(string.Format("{0}{1}{2}{3}", rowsSum[3], colsSum[3], rowsSum[0], colsSum[0])),  // 2. 30585038
				long.Parse(string.Format("{0}{1}{2}{3}", rowsSum[0], colsSum[3], rowsSum[3], colsSum[0])),  // 3. 50583038
				long.Parse(string.Format("{0}{1}{2}{3}", colsSum[3], rowsSum[3], colsSum[0], rowsSum[0])),  // 4. 58303850
				long.Parse(string.Format("{0}{1}{2}{3}", colsSum[0], rowsSum[3], colsSum[3], rowsSum[0])),  // 5. 38305850
				long.Parse(string.Format("{0}{1}{2}{3}", rowsSum[3], colsSum[0], rowsSum[0], colsSum[3])),  // 6. 30385058
				long.Parse(string.Format("{0}{1}{2}{3}", rowsSum[0], colsSum[0], rowsSum[3], colsSum[3])),  // 7. 50383058
				long.Parse(string.Format("{0}{1}{2}{3}", colsSum[3], rowsSum[0], colsSum[0], rowsSum[3])),  // 8. 58503830
				long.Parse(string.Format("{0}{1}{2}{3}", colsSum[0], rowsSum[0], colsSum[3], rowsSum[3])),  // 9. 38505830
			};
			scores[23] = Score(Sum(vars[0], vars[1]));
			scores[24] = Sum(vars[3], vars[5]) % 8 == 0 ? 1 : 0;
			scores[25] = Score(Diff(vars[3], vars[5]));
			scores[26] = Score(Sum(vars[4], vars[7]));
			scores[27] = Sum(vars[6], vars[8]) % 8 == 0 ? 1 : 0;
			scores[28] = Score(Sum(vars[9], vars[2]));

			// 30
			vars = new long[]
			{
				(ar[0] - 1) / 4 + (ar[4] - 1) / 4 + (ar[8] - 1) / 4 + (ar[12] - 1) / 4 + 4,
				(ar[1] - 1) / 4 + (ar[5] - 1) / 4 + (ar[9] - 1) / 4 + (ar[13] - 1) / 4 + 4,
				(ar[2] - 1) / 4 + (ar[6] - 1) / 4 + (ar[10] - 1) / 4 + (ar[14] - 1) / 4 + 4,
				(ar[3] - 1) / 4 + (ar[7] - 1) / 4 + (ar[11] - 1) / 4 + (ar[15] - 1) / 4 + 4,
			};
			scores[29] = ar[0] == vars[0] ? 1 : 0;
			scores[29] += ar[1] == vars[1] ? 1 : 0;
			scores[29] += ar[2] == vars[2] ? 1 : 0;
			scores[29] += ar[3] == vars[3] ? 1 : 0;
			scores[29] += Diff(colsSum[0], vars[0]) % 7 == 0 ? 1 : 0;
			scores[29] += Diff(colsSum[1], vars[1]) % 7 == 0 ? 1 : 0;
			scores[29] += Diff(colsSum[2], vars[2]) % 7 == 0 ? 1 : 0;
			scores[29] += Diff(colsSum[3], vars[3]) % 7 == 0 ? 1 : 0;
			scores[29] += Sum(colsSum[0], vars[0]) % 7 == 0 ? 1 : 0;
			scores[29] += Sum(colsSum[1], vars[1]) % 7 == 0 ? 1 : 0;
			scores[29] += Sum(colsSum[2], vars[2]) % 7 == 0 ? 1 : 0;
			scores[29] += Sum(colsSum[3], vars[3]) % 7 == 0 ? 1 : 0;
			scores[29] += (vars[0] + vars[1] + vars[2] + vars[3]) % 7 == 0 ? 1 : 0;

			foreach (var sc in scores)
				score += sc;

			return score;
        }

        int SumOfDigits(long n, bool untilOneDigit = true)
        {
            while (true)
            {
                int sum = 0;
                do
                {
                    sum += (byte)(n % 10);
                    n /= 10;
                } while (n != 0);
                if (sum < 10 || !untilOneDigit)
                    return sum;
                n = sum;
            }
        }

        byte PutInRange(long n)
        {
			n = (n - 1) % 28 + 1;
			if (n <= 0)
				n += 28;
			return (byte)n;
        }

        long Sum(long n1, long n2)
        {
            return n1 + n2;
        }

        long Diff(long n1, long n2)
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

        int Score(long n)
        {
            n = PutInRange(n);
            var n28 = (n - 1) % 28 + 1;
            var n9 = (n - 1) % 9 + 1;
            if (n28 == 2 || n28 == 8 || n28 == 11 || n28 == 17 || n28 == 20 || n28 == 28)
                return 1;
            if (n < 28)
                return 0;
            if (n9 == 2 || n9 == 8)
                return 1;
            return 0;
        }

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
	}
}

