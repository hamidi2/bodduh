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
			int[] colsSum = new int[4];
			//Score(21, 17, 1, 1, out colsSum);
			//Score(21, 17, 1, 21, out colsSum);
			Score(10, 8, 2, 19, out colsSum, false);
			Score(10, 8, 2, 7, out colsSum, false);
		}

		class Table
        {
			public byte x, y;
			public int[] colsSum;// = new int[4];
        }

		void FindBestTable(byte a, byte b, byte x, out Table table, ref int[] colsSum, byte yMod4)
		{
			var scores = new Dictionary<Table, int>();
			byte xFrom, xTo, yFrom, yStep;
			if (yMod4 == 4)  // no limit for x
			{
				xFrom = 1;
				xTo = 28;
				yFrom = 1;
				yStep = 1;
			}
			else
			{
				xFrom = x;
				xTo = x;
				yFrom = (byte)(yMod4 + 1);
				yStep = 4;
			}
			for (x = xFrom; x <= xTo; x++)
				for (byte y = yFrom; y <= 28; y += yStep)
				{
					table = new Table();
					var score = Score(a, b, x, y, out table.colsSum, yMod4 == 4);
					table.x = x;
					table.y = y;
					scores[table] = score;
				}
			var list = scores.ToList();
			list.Sort((item1, item2) => item2.Value.CompareTo(item1.Value));
			table = list[0].Key;
			colsSum[0] += table.colsSum[0];
			colsSum[1] += table.colsSum[1];
			colsSum[2] += table.colsSum[2];
			colsSum[3] += table.colsSum[3];
		}

		private void button1_Click(object sender, EventArgs e)
        {
			// 4077 4117 3953 4069 کیفحالالرضامعالمامون
			// 3042 3106 2918 3030 کیفحالرضمعون
			// 2334 2454 2290 2358 کیهوزتادسرغمن
			// 1238 1270 1102 1294 کیهوزتوایدکهدهیدولتمان
			// 1764 1808 1608 1776 کیهوزتادلمن
            // کیفرهماییبرسدازشهجان
            // کیفرهمابسدزشجن
			if (tbInput.Text.Length == 0)
				tbInput.Text = "کیفحالرضمعون";
			if (tbInput.Text.Length < 2)
            {
                MessageBox.Show("ورودی حداقل باید شامل دو حرف باشد");
                return;
            }
			tbOutput.Text = "";
			int[] colsSum = new int[4];
			var a = Constants.Letters[tbInput.Text[0]].Abjad1;
			var b = Constants.Letters[tbInput.Text[1]].Abjad1;
			Table table;
			FindBestTable(a, b, 0, out table, ref colsSum, 4);
			var iInput = 2;
			tbOutput.Text += Constants.Abjad1ToLetter(table.x);
			tbOutput.Text += Constants.Abjad1ToLetter(table.y);
			byte[] onsori = { 0, 3, 0, 2, 2, 1, 3, 1, 1, 2, 1, 3 };
			while (true)
			{
				a += b;
				if (a > 28)
					a -= 28;
				b = Constants.Letters[tbInput.Text[iInput]].Abjad1;
				var x = (byte)(table.x + table.y);
				if (x > 28)
					x -= 28;
				FindBestTable(a, b, x, out table, ref colsSum, onsori[iInput]);
				tbOutput.Text += Constants.Abjad1ToLetter(table.y);
				iInput++;
				if (iInput == tbInput.Text.Length)
					break;
			}
			Debug.WriteLine("{0} {1} {2} {3}", colsSum[3], colsSum[2], colsSum[1], colsSum[0]);
		}

		private int Score(byte a, byte b, byte x, byte y, out int[] colsSum, bool bCalculateForTwoInitialLetters)
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
				ar[i] = (ar[i] + 27) % 28 + 1;
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
			int[] rowsRev =
			{
				int.Parse(string.Format("{0}{1}{2}{3}", ar[0], ar[1], ar[2], ar[3])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[4], ar[5], ar[6], ar[7])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[8], ar[9], ar[10], ar[11])),
				int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[13], ar[14], ar[15])),
			};
			int[] scores = new int[34];

            // 1
			scores[0] += ScoreDiff(ar[3] + ar[2], ar[1] + ar[0]);
			if (scores[0] == 0 && !bCalculateForTwoInitialLetters)
				scores[0] += Score(Diff(ar[3], ar[2]) + ar[1] + ar[0]);

			// 2
			scores[1] = Score(rowsSum[0], rowsSum[3]);

			// 3
			scores[2] = Score(colsSum[3], colsSum[0]);

			// 4
			scores[3] = Score(colsSum[3], rowsSum[0]);

			// 5
			scores[4] = Score(rowsSum[3], colsSum[0]);
			if (scores[4] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[4] = Score((rowsSum[3] + colsSum[0]) * 2);
				if (scores[4] == 0)
					scores[4] = Score(Diff(rowsSum[3], colsSum[0]) * 2);
			}

			// 6
			scores[5] = ScoreDiff(colsSum[3] + colsSum[0], rowsSum[0] + rowsSum[3]);
			scores[5] += ScoreDiff(colsSum[3] + colsSum[0], Diff(rowsSum[0], rowsSum[3]));
			if (scores[5] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[5] += Score(colsSum[3] + colsSum[0] + rowsSum[0] + rowsSum[3]);
				scores[5] += Score(colsSum[3] + colsSum[0] + Diff(rowsSum[0], rowsSum[3]));
			}

			// 7
			scores[6] = Score(colsSum[0] + colsSum[1] + colsSum[2] + colsSum[3]);

			// 8
			long[] vars = new long[2];
			vars[0] = rows[0] + rows[1] + rows[2] + rows[3];
			scores[7] = Score(vars[0]);
			if (scores[7] == 0 && !bCalculateForTwoInitialLetters)
				scores[7] = Score(vars[0], Reverse(vars[0]), true);

			// 9
			scores[8] = Score(rows[0] + rows[2]);
			if (scores[8] == 0 && !bCalculateForTwoInitialLetters)
				scores[8] = Score(rowsRev[0] + rowsRev[2]);

			// 10
			scores[9] = (int.Parse(string.Format("{0}{0}{0}{0}", ar[0])) % 28 == ar[0]) ? 1 : 0;
			scores[9] += (int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12])) % 28 == ar[1]) ? 1 : 0;

			// 11
			vars[0] = int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[9], ar[6], ar[3]));
			scores[10] = Score(vars[0]);
			if (scores[10] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[1] = int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12]));
				scores[10] = Score(vars[0], vars[1], true);
			}

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
			vars[0] = sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3];
			scores[11] += Score(vars[0] * 2);
			if (scores[11] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[0] %= 9;
				scores[11] += (vars[0] == 2 || vars[0] == 8) ? 1 : 0;
			}

			// 13
			var colMul = colsSum[0] * colsSum[3];
            var rowMul = rowsSum[0] * rowsSum[3];
			scores[12] = Score(colMul);
			scores[12] += Score(rowMul, colMul);

			// 14
			scores[13] = Score((colsSum[0] + colsSum[3]) * (rowsSum[0] + rowsSum[3]));
			if (Diff(rowsSum[0], rowsSum[3]) != 0)
				scores[13] += Score((colsSum[0] + colsSum[3]) * Diff(rowsSum[0], rowsSum[3]), false);
			if (Diff(colsSum[0], colsSum[3]) != 0)
			scores[13] += Score(Diff(colsSum[0], colsSum[3]) * (rowsSum[0] + rowsSum[3]), false);
			if (Diff(colsSum[0], colsSum[3]) != 0 && Diff(rowsSum[0], rowsSum[3]) != 0)
			scores[13] += Score(Diff(colsSum[0], colsSum[3]) * Diff(rowsSum[0], rowsSum[3]), false);

			scores[13] += Score((rowsSum[0] + colsSum[3]) * (colsSum[0] + rowsSum[3]));
			if (Diff(colsSum[0], rowsSum[3]) != 0)
				scores[13] += Score((rowsSum[0] + colsSum[3]) * Diff(colsSum[0], rowsSum[3]), false);
			if (Diff(rowsSum[0], colsSum[3]) != 0)
				scores[13] += Score(Diff(rowsSum[0], colsSum[3]) * (colsSum[0] + rowsSum[3]), false);
			if (Diff(rowsSum[0], colsSum[3]) != 0 && Diff(colsSum[0], rowsSum[3]) != 0)
				scores[13] += Score(Diff(rowsSum[0], colsSum[3]) * Diff(colsSum[0], rowsSum[3]), false);

            // 15
			vars = new long[]
            {
                Diff(rows[0], rowsRev[0]),
				Diff(rows[1], rowsRev[1]),
				Diff(rows[2], rowsRev[2]),
				Diff(rows[3], rowsRev[3]),
            };
			scores[14] = ScoreDiff(vars[0], vars[1]);
			scores[14] += Score(vars[2], vars[3]);
			scores[14] += Score(vars[0], vars[3]);

			// 16
			vars[0] = colsSum[2] * colsSum[3];
			vars[1] = colsSum[0] * colsSum[1];
			scores[15] += Score(vars[0] * vars[1]);
			if (scores[15] == 0 && !bCalculateForTwoInitialLetters)
				scores[15] = Score(vars[0], vars[1], true);

			// 17
			int[] columnsMul =
            {
                ar[0] * ar[4] * ar[8] * ar[12],
                ar[1] * ar[5] * ar[9] * ar[13],
                ar[2] * ar[6] * ar[10] * ar[14],
                ar[3] * ar[7] * ar[11] * ar[15],
            };
			scores[16] = Score(columnsMul[0], columnsMul[1]);
			scores[16] += Score(columnsMul[2]);
			scores[16] += Score(columnsMul[3]);

			// 18
			scores[17] += Score(rowsSum[0], rowsSum[1]);
            scores[17] += Score(rowsSum[0], rowsSum[2]);
            scores[17] += Score(rowsSum[1] + rowsSum[3]);
            scores[17] += Score(rowsSum[0] * rowsSum[1] * rowsSum[2] * rowsSum[3]);

            // 19
			vars = new long[]
			{
				Diff(ar[0], ar[3]) + Diff(ar[4], ar[7]) + Diff(ar[8], ar[11]) + Diff(ar[12], ar[15]),
				Diff(ar[1], ar[2]) + Diff(ar[5], ar[6]) + Diff(ar[9], ar[10]) + Diff(ar[13], ar[14]),
			};
			if (vars[0] != 0)
				scores[18] += Score(vars[0]);
			if (vars[1] != 0)
				scores[18] += Score(vars[1]);
			scores[18] += Score(vars[0], vars[1]);

			// 20
			vars = new long[]
            {
				rowsSum[0] * rowsSum[3],
				colsSum[0] * colsSum[3],
				0,
				0,
			};
			scores[19] = Score(vars[0] + vars[1]);
			if (scores[19] == 0 && !bCalculateForTwoInitialLetters)
				scores[19] = ScoreDiff(vars[0], vars[1]);
			if (scores[19] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[2] = vars[0] * vars[1];
				vars[3] = vars[1] * colsSum[1] * colsSum[2];
				scores[19] = Score(vars[2], vars[3], true);
			}

			// 21
			vars = new long[]
            {
                ar[3] * ar[6] * ar[9] * ar[12],
                a * a * a * a,
				0,
				0,
            };
			vars[2] = SumOfDigits(vars[0] + vars[1], false);
			vars[3] = SumOfDigits(Diff(vars[0], vars[1]), false);
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
            scores[21] += Score(vars[4], vars[9]);

            // 23
            scores[22] = ScoreDiff(vars[0], vars[8]);
            scores[22] += Score(Diff(vars[0], vars[6]) + vars[7] + vars[8]);
            scores[22] += ScoreDiff(vars[3], vars[8]);
            scores[22] += Score(vars[2] + vars[3]);
			if (scores[22] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[22] += Score(vars[5], vars[8], true);
				if (scores[22] == 0)
					scores[22] += Score(vars[5] + vars[6] + Diff(vars[7], vars[8]));
				if (scores[22] == 0)
					scores[22] += Score(vars[3]);
				if (scores[22] == 0)
					scores[22] += Score(vars[3], vars[8], true);
				if (scores[22] == 0)
					scores[22] += Score(vars[2], vars[8], true);
			}

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
				0,
				0,
				0,
			};
			var list = new List<long>();

			// 24
			vars[10] = vars[0] + vars[1];
			scores[23] = Score(vars[10]);
			if (scores[23] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[11] = vars[10] % 28;
				vars[12] = Diff(vars[0], vars[1]) % 28;
				scores[23] = Score(vars[11], vars[12], true);
			}

			// 25
			vars[10] = vars[3] + vars[5];
			scores[24] = Score(vars[10]) != 0 || vars[10] % 8 == 0 ? 1 : 0;
			if (scores[24] == 0)
				list.Add(vars[10]);

			// 26
			scores[25] = ScoreDiff(vars[3], vars[5]);
			if (scores[25] == 0 && !bCalculateForTwoInitialLetters)
				scores[25] = Score(vars[3] + vars[5]);

			// 27
			scores[26] = Score(vars[4], vars[7], true);
			if (scores[26] == 0)
			{
				list.Add(vars[4] + vars[7]);
				list.Add(Diff(vars[4], vars[7]));
			}

			// 28
			vars[10] = vars[6] + vars[8];
			scores[27] = Score(vars[10]) != 0 || vars[10] % 8 == 0 ? 1 : 0;
			if (scores[27] == 0)
			{
				list.Add(vars[6] + vars[8]);
				list.Add(Diff(vars[6], vars[8]));
			}

			// 29
			scores[28] = Score(vars[9], vars[2], true);
			if (scores[28] == 0)
			{
				list.Add(vars[9] + vars[2]);
				list.Add(Diff(vars[9], vars[2]));
			}

			// 32
			scores[31] = Score(vars[2] + vars[3] + vars[4] + vars[5] + vars[6] + vars[7] + vars[8] + vars[9]);

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
			scores[29] += (colsSum[0] + vars[0]) % 7 == 0 ? 1 : 0;
			scores[29] += (colsSum[1] + vars[1]) % 7 == 0 ? 1 : 0;
			scores[29] += (colsSum[2] + vars[2]) % 7 == 0 ? 1 : 0;
			scores[29] += (colsSum[3] + vars[3]) % 7 == 0 ? 1 : 0;
			scores[29] += (vars[0] + vars[1] + vars[2] + vars[3]) % 7 == 0 ? 1 : 0;

			// 31
			scores[30] = Score(rowsSum[0]) + Score(rowsSum[3]) + Score(colsSum[0]) + Score(colsSum[3]);

			// 33
			vars = list.ToArray();
			for (var i = 0; i < vars.Length - 1; i++)
				for (var j = i + 1; j < vars.Length; j++)
					scores[32] += Score(vars[i], vars[j], true);

			// 34
			if (!bCalculateForTwoInitialLetters)
			{
				scores[33] = Score(colsSum[3], colsSum[2], true);
				if (scores[33] == 0)
					scores[33] = Score(colsSum[1], colsSum[0], true);
			}

			foreach (var sc in scores)
				score += sc;

			return score;
        }

		long Reverse(long n)
		{
			return long.Parse(Reverse(string.Format("{0}", n)));
		}

		string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
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

        long Diff(long n1, long n2)
        {
            return Math.Abs(n1 - n2);
        }

        int Score(long n1, long n2, bool bEither = false)
        {
            int score = 0;
            score += Score(n1 + n2);
			if (!bEither || score == 0)
				score += ScoreDiff(n1, n2);
            return score;
        }

		int ScoreDiff(long n1, long n2)
		{
			var diff = Diff(n1, n2);
			if (diff == 0)
				return Score(n1);
			return Score(diff);
		}

        int Score(long n, bool bZeroIsAcceptable = true)
        {
			Debug.Assert(n >= 0);
			if (n == 0)
				return 0;
			var n9 = n % 9;
			if (n9 == 2 || n9 == 8)
				return 1;
			n %= 28;
			if (n == 0)
				return bZeroIsAcceptable ? 1 : 0;
            if (n == 2 || n == 8 || n == 11 || n == 17 || n == 20 || n == 26)
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

