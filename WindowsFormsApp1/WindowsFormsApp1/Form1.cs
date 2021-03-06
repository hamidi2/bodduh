﻿using System;
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
	public static class Form1Ext
	{
		public static void Add(this List<Form1.ByteWithDirection> list, byte n, bool bWithInterfering28 = false)
		{
			var item = new Form1.ByteWithDirection();
			item.n = n;
			item.bWithInterfering28 = bWithInterfering28;
			list.Add(item);
		}
	}

	public partial class Form1 : Form
	{
		void DebugFunc1()
		{
			int[] colsSum = new int[4];
			byte[] n = { 3, 20, 18, 24, 12 };
			// khorujie barnameh
			int output_score1, output_score2;
			int[] output_scores;
			Score(n[0], n[1], n[2], n[3], out colsSum, false, out output_scores, out output_score1, out output_score2);
			// morede entezar
			int desired_score1, desired_score2;
			int[] desired_scores;
			Score(n[0], n[1], n[2], n[4], out colsSum, false, out desired_scores, out desired_score1, out desired_score2);
			Debug.WriteLine("\t{0}\t{1}", n[3], n[4]);
			for (var i = 0; i < output_scores.Length; i++)
				if (output_scores[i] > desired_scores[i])
					Debug.WriteLine("{0}\t{1}\t{2}", i + 1, output_scores[i], desired_scores[i]);
			Debug.WriteLine("\t{0}\t{1}", output_score2, desired_score2);
		}

		void DebugFunc2()
		{
			int[] colsSum = new int[4];
			int output_score1, output_score2;
			int[] output_scores;
			Score(21, 17, 1, 1, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(10, 8, 2, 19, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(18, 1, 21, 15, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(19, 12, 8, 10, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(3, 20, 18, 12, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(23, 26, 2, 22, out colsSum, false, out output_scores, out output_score1, out output_score2);
			Score(21, 13, 24, 6, out colsSum, false, out output_scores, out output_score1, out output_score2);
		}

		void DebugFunc3()
		{
			Table table;
			var scores = new Dictionary<Table, Scores>();
			byte a = 6, b = 14;
			for (byte x = 2; x <= 28; x += 4)
				for (byte y = 4; y <= 28; y += 4)
				{
					table = new Table();
					int[] output_scores;
					int output_score1, output_score2;
					Score(a, b, x, y, out table.colsSum, false, out output_scores, out output_score1, out output_score2);
					table.x = x;
					table.y = y;
					scores[table] = new Scores { score1 = output_score1, score2 = output_score2 };
				}
			var list = scores.ToList();
			list.Sort((item1, item2) => Scores.Compare(item2.Value, item1.Value));
			table = list[0].Key;
		}

		public Form1()
		{
			InitializeComponent();
			DebugFunc3();
		}

		void FindBestTable(byte a, byte b, byte xOrXMod4, byte yMod4, bool bChangeX, out Table[] tables)
		{
			var scores = new Dictionary<Table, Scores>();
			byte xFrom = bChangeX ? (byte)(xOrXMod4 + 1) : xOrXMod4, xTo = bChangeX ? (byte)28 : xFrom;
			byte yFrom = (byte)(yMod4 + 1), yTo = 28;
			for (byte x = xFrom; x <= xTo; x += 4)
				for (byte y = yFrom; y <= yTo; y += 4)
				{
					var table = new Table();
					int[] output_scores;
					int output_score1, output_score2;
					Score(a, b, x, y, out table.colsSum, bChangeX, out output_scores, out output_score1, out output_score2);
					table.x = x;
					table.y = y;
					scores[table] = new Scores { score1 = output_score1, score2 = output_score2 };
				}
			var list = scores.ToList();
			list.Sort((item1, item2) => Scores.Compare(item2.Value, item1.Value));
			tables = new Table[list.Count];
			for (var i = 0; i < list.Count; i++)
				tables[i] = list[i].Key;
		}

		bool Lab2Cond(long n, ref int exceptionCounter)
		{
			if (n % 5 == 0 || SumOfDigits(n, false) % 5 == 0 ||
				Diff(28, n) % 5 == 0 || (28 + n) % 5 == 0 ||
				Diff(56, n) % 5 == 0 || (56 + n) % 5 == 0)
				return true;
			if (Diff(84, n) % 5 == 0)
			{
				exceptionCounter++;
				return true;
			}
			return false;
		}

		void Lab2Check(byte[] letters)
		{
			var len = letters.Length;
			var mid = len / 2;
			var exceptionCounter = 0;
			for (var i = 0; i < mid; i++)
			{
				long[] vars =
				{
					letters[i] + letters[len - 1 - i],
					Diff(letters[i], letters[len - 1 - i]),
				};
				var found = false;
				foreach (var n in vars)
					if (Lab2Cond(n, ref exceptionCounter))
					{
						found = true;
						break;
					}
				Debug.Assert(found);
			}
			if (len % 2 == 1)
			{
				var n = letters[mid];
				Debug.Assert(Lab2Cond(n, ref exceptionCounter));
			}
			Debug.Assert(exceptionCounter < 2);
		}

		byte[] FindBestLetters(LetterSpec[] lettersSpec)
		{
			var len = lettersSpec.Length;
			var letters = new byte[len];

			// 1
			for (var c = 0; c < len; c++)
			{
				var inputLetter = lettersSpec[c].InputLetter;
				var outputLetters = lettersSpec[c].OutputLetters;
				byte foundOutputLetter = 0;
				foreach (var outputLetter in outputLetters)
				{
					long[] vars =
					{
						Diff(inputLetter, outputLetter.Letter),
						inputLetter + outputLetter.Letter,
					};
					foreach (var n in vars)
					{
						if (n % 9 == 1 || n % 9 == 2 || n % 9 == 8 ||
							n % 8 == 0 || n % 28 == 8 || n % 28 == 20)
						{
							foundOutputLetter = outputLetter.Letter;
							break;
						}
					}
					if (foundOutputLetter != 0)
						break;
				}
				Debug.Assert(foundOutputLetter != 0);  // all letters have been examined and none are appropriate.
				letters[c] = foundOutputLetter;
			}

			// 2
			var l = new byte[len];
			var i = 0;
			for (; i < len; i++)
				l[i] = (byte)(letters[i] + lettersSpec[i].InputLetter);
			Lab2Check(l);

			// 3
			for (i = 0; i < len; i++)
				l[i] = (byte)SumOfDigits(Diff(letters[i], lettersSpec[i].InputLetter));
			var mid = len / 2;
			var pattern = "+--";
			var iPattern = 0;
			var str = "";
			for (i = 0; i < mid; i++)
			{
				if (pattern[iPattern] == '+')
					str += SumOfDigits(l[i] + l[len - 1 - i]);
				else
					str += Diff(l[i], l[len - 1 - i]);
				iPattern++;
				if (iPattern == pattern.Length)
					iPattern = 0;
			}
			if (len % 2 != 0)
				str += l[mid];
			var n2 = long.Parse(str);
			Debug.Assert(Score(n2) != 0);
			Debug.Assert(Score(Reverse(n2)) != 0);

			// 4
			len = str.Length;
			mid = len / 2;
			foreach (var pat in new string[] { "+--", "++-" })
			{
				var str2 = "";
				iPattern = 0;
				if (len % 2 != 0)
					str2 += str[mid];
				for (i = mid - 1; i >= 0; i--)
				{
					if (pat[iPattern] == '+')
						str2 += str[i] - '0' + str[len - 1 - i] - '0';
					else
						str2 += Diff(str[i] - '0', str[len - 1 - i] - '0');
					iPattern++;
					if (iPattern == pat.Length)
						iPattern = 0;
				}
				Debug.Assert(Score(long.Parse(str2)) != 0);
			}

			return letters;
		}

		List<Result128> Distinct(List<Result128> list)
		{
			int[] res = { 2, 2, 2 };
			foreach (var item in list)
			{
				var index = item.n == 1 ? 0 : item.n == 2 ? 1 : 2;
				res[index] = Math.Min(res[index], item.bWithInterfering28 ? 1 : 0);
			}
			var ret = new List<Result128>();
			if (res[0] != 2)
				ret.Add(new Result128(1, res[0] == 1 ? true : false));
			if (res[1] != 2)
				ret.Add(new Result128(2, res[1] == 1 ? true : false));
			if (res[2] != 2)
				ret.Add(new Result128(8, res[2] == 1 ? true : false));
			return ret;
		}

		List<ResultBodduh> Distinct(List<ResultBodduh> list)
		{
			int[] res = { 2, 2, 2, 2 };
			foreach (var item in list)
			{
				Debug.Assert(item.n > 0 && item.n < 9 && item.n % 2 == 0);
				var index = item.n / 2 - 1;
				res[index] = Math.Min(res[index], item.bWithInterfering28 ? 1 : 0);
			}
			var ret = new List<ResultBodduh>();
			for (var i = 0; i < res.Length; i++)
				if (res[i] != 2)
					ret.Add(new ResultBodduh((i + 1) * 2, res[i] == 1 ? true : false));
			return ret;
		}

		// not providing letter indicates being sure that n is not 0
		List<Result128> ResultOf128(long n, byte letter = 0)
		{
			var list = new List<Result128>();
			if (n == 0)  // تفاضل صفر شده و عدد صاحب امتیاز بوده
			{
				if (Score(letter) != 0)
					list.Add(new Result128(1, false));
				return list;
			}
			Result128[] res =
			{
				new Result128(n % 9, false),
				new Result128(Diff(28, n) % 9, true),
				new Result128((28 + n) % 9, true),
				new Result128(Diff(56, n) % 9, true),
				new Result128((56 + n) % 9, true),
			};
			foreach (var r in res)
				if (r.n == 1 || r.n == 2 || r.n == 8)
					list.Add(r);
			return Distinct(list);
		}

		List<ResultBodduh> ResultOfBodduh(long n, byte mask)
		{
			var list = new List<ResultBodduh>();
			ResultBodduh[] res =
			{
				new ResultBodduh(n % 9, false),
				new ResultBodduh(Diff(28, n) % 9, true),
				new ResultBodduh((28 + n) % 9, true),
				new ResultBodduh(Diff(56, n) % 9, true),
				new ResultBodduh((56 + n) % 9, true),
			};
			foreach (var r in res)
			{
				var m = r.n % 9;
				if (m != 0 && m % 2 == 0 && (mask & (0x01 << (m / 2 - 1))) != 0)
					list.Add(r);
			}
			return Distinct(list);
		}

		void Add(List<Pair> pairs, Pair pair)
		{
			foreach (var p in pairs)
			{
				if (p.Left == pair.Left && p.Right == pair.Right)
				{
					p.SecondStepResults128.AddRange(pair.SecondStepResults128);
					p.SecondStepResults128 = Distinct(p.SecondStepResults128);
					return;
				}
			}
			pairs.Add(pair);
		}

		// محاسبه پخش میانگین
		void CalculateOBVs(byte iMyElementalStrings)
		{
			int inputSum = 0;
			for (var col = 0; col < _len; col++)
				inputSum += _lettersSpec[col].InputLetter;
			var outputElementalSum = 0;
			for (var col = 0; col < _len; col++)
				outputElementalSum += _myElementalStrings[iMyElementalStrings][col] + 1;
			_outputSum = (inputSum + 6) / 9 * 9 + 2;  // round it to first greater or equal 9k+2
			while (_outputSum % 4 != outputElementalSum % 4)
				_outputSum += 9;
			_OBV = new byte[2, _len];
			for (var col = 0; col < _len; col++)
				_OBV[0, col] = _OBV[1, col] = (byte)(_outputSum / _len);
			for (var j = 0; j < _outputSum % _len; j++)
			{
				_OBV[0, j]++;
				_OBV[1, _len - 1 - j]++;
			}
		}

		// first step: remove numbers which don't match with input
		void Step1()
		{
			if (_col % 3 == 0)
			{
				if (_col == 0)
				{
					_step1IncludesPatternsIncludingOne = true;
					_step1IncludesPatternsNotIncludingOne = true;
				}
				else
				{
					bool[] includeOne = {false, false};
					bool[] notIncludeOne = {false, false};
					for (var direction = 0; direction < 2; direction++)
					{
						foreach (var pattern in _step1matched128Patterns[direction])
						{
							if (pattern.Contains('1'))
								includeOne[direction] = true;
							else
								notIncludeOne[direction] = true;
						}
					}
					_step1IncludesPatternsIncludingOne = includeOne[0] && includeOne[1];
					_step1IncludesPatternsNotIncludingOne = notIncludeOne[0] && notIncludeOne[1];
					Debug.Assert(_step1IncludesPatternsIncludingOne || _step1IncludesPatternsNotIncludingOne);
				}
				_step1matched128Patterns[0] = new List<string>();
				if (_step1IncludesPatternsIncludingOne)
					_step1matched128Patterns[0].AddRange(_acceptable128Patterns.Take(6));
				if (_step1IncludesPatternsNotIncludingOne)
					_step1matched128Patterns[0].AddRange(_acceptable128Patterns.Skip(6));
				_step1matched128Patterns[1] = new List<string>();
				_step1matched128Patterns[1].AddRange(_step1matched128Patterns[0]);
			}
			for (var direction = 0; direction < 2; direction++)
			{
				Debug.WriteLine("step1 128 patterns {0}: (count={1})", direction == 0 ? "right" : "left", _step1matched128Patterns[direction].Count);
				foreach (var str in _step1matched128Patterns[direction])
					Debug.WriteLine(str);
			}
			// 0 for right, 1 for left
			for (var direction = 0; direction < 2; direction++)
			{
				var realCol = direction == 0 ? _col : _len - 1 - _col;
				var inputLetter = _lettersSpec[realCol].InputLetter;
				var outputLetters = _lettersSpec[realCol].OutputLetters.ToArray();
				foreach (var outputLetter in outputLetters)
				{
					var numbers = new long[]
					{
						Diff(inputLetter, outputLetter.Letter),
						inputLetter + outputLetter.Letter,
					};
					var res128 = new List<Result128>();
					foreach (var n in numbers)
						res128.AddRange(ResultOf128(n, inputLetter));
					res128 = Distinct(res128);
					if (res128.Count != 0)
					{
						foreach (var matchedPattern in _step1matched128Patterns[direction])
						{
							var expectedNumber = matchedPattern[_col % matchedPattern.Length] - '0';
							foreach (var res in res128)
								if (res.n == expectedNumber)
								{
									outputLetter.Results128WithInput.Add(res);
									break;
								}
						}
					}
					if (outputLetter.Results128WithInput.Count == 0) // this letter can't satisfy the first condition
						_lettersSpec[realCol].OutputLetters.Remove(outputLetter);
					else
						outputLetter.Results128WithInput = Distinct(outputLetter.Results128WithInput);
				}
			}
		}

		List<Pair> AllPairs()
		{
			Debug.WriteLine("col={0}", _col);
			Debug.WriteLine("left: (count={0})", _lettersSpec[_len - 1 - _col].OutputLetters.Count);
			foreach (var outputLetter in _lettersSpec[_len - 1 - _col].OutputLetters)
			{
				Debug.Write(string.Format("{0}: ", outputLetter.Letter));
				foreach (var res in outputLetter.Results128WithInput)
					Debug.Write(string.Format("{0}{1} ", res.n, res.bWithInterfering28 ? "" : "d"));
			}
			Debug.WriteLine("\nright: (count={0})", _lettersSpec[_col].OutputLetters.Count);
			foreach (var outputLetter in _lettersSpec[_col].OutputLetters)
			{
				Debug.Write(string.Format("{0}: ", outputLetter.Letter));
				foreach (var res in outputLetter.Results128WithInput)
					Debug.Write(string.Format("{0}{1} ", res.n, res.bWithInterfering28 ? "" : "d"));
			}
			Debug.WriteLine("");
			var pairs = new List<Pair>();
			foreach (var left in _lettersSpec[_len - 1 - _col].OutputLetters)
				foreach (var right in _lettersSpec[_col].OutputLetters)
				{
					var pair = new Pair(left.Letter, right.Letter);
					pair.LeftLetterResults128 = left.Results128WithInput;
					pair.RightLetterResults128 = right.Results128WithInput;
					pairs.Add(pair);
				}
			return pairs;
		}

		// find matching numbers from two sides
		List<Pair> Step2(List<Pair> pairs)
		{
			if (_col % 3 == 0)
				_step2matched128Patterns = _acceptable128Patterns.ToList().Take(6).ToList();
			Debug.WriteLine("step2 128 patterns: (count={0})", _step2matched128Patterns.Count);
			foreach (var str in _step2matched128Patterns)
				Debug.WriteLine(str);
			Debug.WriteLine("step2 +- patterns: (count={0})", _step2matchedPlusMinusPatterns.Count);
			foreach (var str in _step2matchedPlusMinusPatterns)
				Debug.WriteLine(str);
			var includePlus = false;
			var includeMinus = false;
			foreach (var pattern in _step2matchedPlusMinusPatterns)
			{
				var sign = pattern[_col % pattern.Length];
				if (sign == '-')
					includeMinus = true;
				else
					includePlus = true;
			}
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				var left = pair.Left;
				var right = pair.Right;
				var list = new List<Result128>();
				if (includeMinus)
					list.AddRange(ResultOf128(Diff(left, right), left));
				if (includePlus)
					list.AddRange(ResultOf128(left + right));
				list = Distinct(list);
				list = PreferDirect(list);
				foreach (var res in list)
					foreach (var matchedPattern in _step2matched128Patterns)
						if (matchedPattern[_col % matchedPattern.Length] - '0' == res.n)
							pair.SecondStepResults128.Add(res);
				if (pair.SecondStepResults128.Count != 0)
				{
					pair.SecondStepResults128 = Distinct(pair.SecondStepResults128);
					Add(pairs2, pair);
				}
			}
			Debug.WriteLine("step 2 pairs: (count={0})", pairs2.Count);
			foreach (var pair in pairs2)
			{
				Debug.Write(string.Format("{0},{1}: ", pair.Left, pair.Right));
				foreach (var res in pair.SecondStepResults128)
					Debug.Write(string.Format("{0}{1} ", res.n, res.bWithInterfering28 ? "" : "d"));
			}
			Debug.WriteLine("");
			return pairs2;
		}

		// از دو سر اونهایی که جمع یا تفاضلشون یک یا دو یا هشت نمیشده رو حذف کرده‌ایم
		// باز رسیده‌ایم به بیش از یک جفت عدد. حالا نوبت بدوح خروجیه
		List<Pair> Step3(List<Pair> pairs)
		{
			if (_col < 4)
				_step3Mask = (byte)(1 << _col);
			else if (_col % 4 == 0)
				_step3Mask = 0x0F;
			Debug.WriteLine("step3 mask: 0x0{0:X}", _step3Mask);
			var pairs2 = new List<Pair>();
			byte iOBVFirst = _finalOBV == 2 ? (byte)0 : _finalOBV;
			byte iOBVLast = _finalOBV == 2 ? (byte)1 : _finalOBV;
			for (byte iOBV = iOBVFirst; iOBV <= iOBVLast; iOBV++)
			{
				//var pattern2 = "++-+";
				foreach (var pair in pairs)
				{
					var lefts = new List<ByteWithDirection>();
					var rights = new List<ByteWithDirection>();
					var n = (byte)Diff(_OBV[iOBV, _len - 1 - _col], pair.Left);
					lefts.Add(n);
					if (n == 0 && Score(pair.Left) != 0)
						lefts.Add(1, true);
					n = (byte)Diff(_OBV[iOBV, _col], pair.Right);
					rights.Add(n);
					if (n == 0 && Score(pair.Right) != 0)
						rights.Add(1, true);
					int minIndirectionCount = 4;
					var resBodduhOfMinDirectionCount = new List<ResultBodduh>();
					if (lefts[0].n == 11 && rights[0].n == 9 ||
						lefts[0].n == 9 && rights[0].n == 11)
					{
						Debug.Assert((_step3Mask & 0x08) != 0);
						minIndirectionCount = 0;
						resBodduhOfMinDirectionCount.Add(new ResultBodduh(8, false));
					}
					else
					{
						foreach (var left in lefts)
							foreach (var right in rights)
							{
								var res = new List<ResultBodduh>();
								var numbers = new long[]
								{
									Diff(left.n, right.n),
									left.n + right.n,
								};
								foreach (var n2 in numbers)
									res.AddRange(ResultOfBodduh(n2, _step3Mask));
								res = Distinct(res);
								res = PreferDirect(res);
								if (res.Count == 0)
									continue;
								var indirectionCount = 3;
								foreach (var r in res)
									if (r.bWithInterfering28 == false)
									{
										indirectionCount--;
										break;
									}
								if (left.bWithInterfering28 == false)
									indirectionCount--;
								if (right.bWithInterfering28 == false)
									indirectionCount--;
								if (indirectionCount < minIndirectionCount)
								{
									minIndirectionCount = indirectionCount;
									resBodduhOfMinDirectionCount = res;
								}
							}
					}
					if (minIndirectionCount != 4)
					{
						var p = new Pair(pair);
						p.OBV = iOBV;
						p.ThirdStepIndirectionCount = minIndirectionCount;
						p.ThirdStepResultsBodduh = resBodduhOfMinDirectionCount;
						pairs2.Add(p);
					}
				}
			}
			pairs = pairs2;
			pairs.Sort((x, y) => x.ThirdStepIndirectionCount.CompareTo(y.ThirdStepIndirectionCount));
			Debug.WriteLine("step 3 pairs: (count={0})", pairs.Count);
			foreach (var pair in pairs)
				Debug.Write(string.Format("{0},{1},{2}: {3} ", pair.Left, pair.Right, pair.OBV, pair.ThirdStepIndirectionCount));
			Debug.WriteLine("");
			return pairs;
		}

		// بدوح ورودی و خروجی
		List<Pair> Step4(List<Pair> pairs)
		{
			//var pattern2 = "--+++-";
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				long[] vars =
				{
					Diff(_lettersSpec[_len - 1 - _col].InputLetter, pair.Left),
					_lettersSpec[_len - 1 - _col].InputLetter + pair.Left,
					Diff(_lettersSpec[_col].InputLetter, pair.Right),
					_lettersSpec[_col].InputLetter + pair.Right,
				};
				long[] vars2 = new long[]
				{
					Diff(vars[0], vars[2]),
					Diff(vars[0], vars[3]),
					Diff(vars[1], vars[2]),
					Diff(vars[1], vars[3]),
					vars[0] + vars[2],
					vars[0] + vars[3],
					vars[1] + vars[2],
					vars[1] + vars[3],
				};
				foreach (var n in vars2)
					pair.FourthStepResultsBodduh.AddRange(ResultOfBodduh(n, 0x0F));
				pair.FourthStepResultsBodduh = Distinct(pair.FourthStepResultsBodduh);
				if (pair.FourthStepResultsBodduh.Count != 0)
					pairs2.Add(pair);
			}
			pairs = pairs2;
			Debug.WriteLine("step 4 pairs: (count={0})", pairs.Count);
			foreach (var pair in pairs)
			{
				Debug.Write(string.Format("{0},{1}: ", pair.Left, pair.Right));
				foreach (var res in pair.FourthStepResultsBodduh)
					Debug.Write(string.Format("{0}{1} ", res.n, res.bWithInterfering28 ? "" : "d"));
			}
			Debug.WriteLine("");
			return pairs;
		}

		// جمع یا تفاضل طرفینی تفاضل ورودی و خروجی باید صفر یا یک یا دو باشد
		List<Pair> Step5(List<Pair> pairs)
		{
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				var left = Diff(pair.Left, _lettersSpec[_len - 1 - _col].InputLetter);
				if (left == 0)
					left++;
				var right = Diff(pair.Right, _lettersSpec[_col].InputLetter);
				if (right == 0)
					right++;
				long[] vars =
				{
					Diff(left, right) % 9,
					(left + right) % 9,
				};
				foreach (var n in vars)
				if (n < 3)
				{
					pairs2.Add(pair);
					break;
				}
			}
			pairs = pairs2;
			Debug.WriteLine("step 5 pairs: (count={0})", pairs.Count);
			foreach (var pair in pairs)
				Debug.Write(string.Format("{0},{1} ", pair.Left, pair.Right));
			Debug.WriteLine("");
			return pairs;
		}

		List<Pair> Step6(List<Pair> pairs)
		{
			if (_col == 0)
				return pairs;
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				long[] n1 =
				{
					(pair.Left + _previousColumnAnswer.Left) % 28,
					Diff(pair.Left, _previousColumnAnswer.Left),
					(pair.Right + _previousColumnAnswer.Right) % 28,
					Diff(pair.Right, _previousColumnAnswer.Right),
				};
				long[] n2 =
				{
					n1[0] + n1[2], Diff(n1[0], n1[2]),
					n1[0] + n1[3], Diff(n1[0], n1[3]),
					n1[1] + n1[2], Diff(n1[1], n1[2]),
					n1[1] + n1[3], Diff(n1[1], n1[3]),
				};
				foreach (var n in n2)
					if (n % 5 == 0)
					{
						pairs2.Add(pair);
						break;
					}
			}
			Debug.WriteLine("step 6 pairs: (count={0})", pairs2.Count);
			foreach (var pair in pairs2)
				Debug.Write(string.Format("{0},{1} ", pair.Left, pair.Right));
			Debug.WriteLine("");
			return pairs2;
		}

		List<Pair> Step7(List<Pair> pairs)
		{
			var pairs2 = new List<Pair>();
			if (_col == 0)
			{
				var d = (_outputSum / (double)_len) * 3;
				_maxPairSum = (int) d;
				if (_maxPairSum != d)
					_maxPairSum++;  // round up
				_foundPairsSum = 0;
			}
			if (_col == _len / 2 - 1)
			{
				var n = _outputSum - _foundPairsSum;
				Debug.Assert(n > 0);
				foreach (var pair in pairs)
					if (pair.Left + pair.Right == n)
						pairs2.Add(pair);
			}
			else
			{
				foreach (var pair in pairs)
					if (pair.Left + pair.Right <= _maxPairSum)
						pairs2.Add(pair);
			}
			Debug.WriteLine("step 7 pairs: (count={0})", pairs2.Count);
			foreach (var pair in pairs2)
				Debug.Write(string.Format("{0},{1} ", pair.Left, pair.Right));
			Debug.WriteLine("");
			return pairs2;
		}

		List<Pair> Step9(List<Pair> pairs)
		{
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				// I didn't add an extra variable to Pair and use this as a variable to hold number of 2 in left and right of step 1.
				pair.IndirectionCount = 0;
				foreach (var res in pair.LeftLetterResults128)
					if (res.n == 2)
					{
						pair.IndirectionCount++;
						break;
					}
				foreach (var res in pair.RightLetterResults128)
					if (res.n == 2)
					{
						pair.IndirectionCount++;
						break;
					}
				if (pair.IndirectionCount == 2)
					pairs2.Add(pair);
			}
			return pairs2;
		}

		List<Pair> Step10(List<Pair> pairs)
		{
			// TODO: فعلاً فرض رو بر این میذاریم که تا مشخص شدن اینکه کدام پخش میانگین برای ما قابل قبول است نیازی به فیلتر کردن خروجی‌ها بر اساس گام دهم نداریم. اگر بعداً دیدیم لازم شد بیاییم و پیاده سازیش رو انجام بدیم.
			if (_finalOBV == 2)
				return pairs;
			var pairs2 = new List<Pair>();
			foreach (var pair in pairs)
			{
				long[] numbers =
				{
					pair.Left + _OBV[_finalOBV, _col],
					Diff(pair.Left, _OBV[_finalOBV, _col]),
					pair.Right + _OBV[_finalOBV, _len - 1 - _col],
					Diff(pair.Right, _OBV[_finalOBV, _len - 1 - _col]),
				};
				var match = 0;
				for (var i = 0; i < 4; i += 2)
				{
					for (var j = 0; j < 2; j++)
					{
						var m = numbers[i + j] % 9;
						if (m < 3 || m >= 7)
						{
							match++;
							break;
						}
					}
				}
				if (match == 2)
					pairs2.Add(pair);
			}
			return pairs2;
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
			_len = tbInput.Text.Length;
			if (_len == 0)
			{
				tbInput.Text = "کیفحالالرضامعالمامون";
				_len = tbInput.Text.Length;
			}
			if (_len < 2)
			{
				MessageBox.Show("ورودی حداقل باید شامل دو حرف باشد");
				return;
			}
			if (!Constants.ValidateString(tbInput.Text))
			{
				MessageBox.Show("ورودی شامل حروف غیر ابجد میباشد");
				return;
			}
			tbOutput1.Text = "";
			byte[][] elementalStrings =
			{
				// first
				new byte[]
				{
					0, 3, 0, 2, 2, 1, 2, 0,
					1, 0, 1, 3, 3, 2, 3, 1,
					2, 1, 2, 0, 0, 3, 0, 2,
					3, 2, 3, 1, 1, 0, 1, 3,
				},
				// reverse of first
				null,
				// second
				new byte[]
				{
					2, 3, 2, 0, 0, 1, 0, 2,
					1, 2, 1, 3, 3, 0, 3, 1,
					0, 1, 0, 2, 2, 3, 2, 0,
					3, 0, 3, 1, 1, 2, 1, 3,
				},
				// reverse of second
				null,
			};
			elementalStrings[1] = elementalStrings[0].Reverse().ToArray();
			elementalStrings[3] = elementalStrings[2].Reverse().ToArray();
			_myElementalStrings = new List<byte[]>();
			var patternSize = elementalStrings[0].Length;
			var mids = _len % 2 == 0 ? new int[] { _len / 2 } : new int[] { _len / 2, _len / 2 + 1 };
			var expandPatterns = new byte[][]
			{
				new byte[] { 0, 0, 2, 2 },
				new byte[] { 0, 1, 2, 3 },
			};
			foreach (var mid in mids)
			{
				foreach (var expandPattern in expandPatterns)
				{
					var str = new byte[_len];
					var n = mid;
					var iStr = 0;
					var iExpandPattern = 0;
					do
					{
						var n2 = Math.Min(n, patternSize);
						Array.Copy(elementalStrings[expandPattern[iExpandPattern]], 0, str, iStr, n2);
						iExpandPattern = (iExpandPattern + 1) % 2;
						n -= n2;
						iStr += n2;
					} while (n != 0);
					n = _len - mid;
					iStr = _len;
					iExpandPattern = 0;
					do
					{
						var n2 = Math.Min(n, patternSize);
						Array.Copy(elementalStrings[expandPattern[2 + iExpandPattern]], patternSize - n2, str, iStr - n2, n2);
						iExpandPattern = (iExpandPattern + 1) % 2;
						n -= n2;
						iStr -= n2;
					} while (n != 0);
					_myElementalStrings.Add(str);
					if (_len <= 2 * patternSize)
						break;
				}
			}
			tbOutput1.Text = tbOutput2.Text = tbOutput3.Text = tbOutput4.Text = "";
			Debug.Assert(
				_myElementalStrings.Count == 1 ||
				_myElementalStrings.Count == 2 ||
				_myElementalStrings.Count == 4);
			var tbOutputs = new TextBox[]
			{
				tbOutput1, tbOutput2, tbOutput3, tbOutput4,
				tbOutput5, tbOutput6, tbOutput7, tbOutput8,
			};
			for (byte i = 0; i < _myElementalStrings.Count; i++)
			{
				_lettersSpec = new LetterSpec[_len];
				for (var col = 0; col < _len; col++)
					_lettersSpec[col].OutputLetters = new List<OutputLetter>();
				Table[] tables;
				var iInput = 0;
				var a = Constants.Letters[tbInput.Text[0]].Abjad1;
				var b = Constants.Letters[tbInput.Text[1]].Abjad1;
				FindBestTable(a, b, _myElementalStrings[i][0], _myElementalStrings[i][1], true, out tables);
				_lettersSpec[0].InputLetter = a;
				_lettersSpec[1].InputLetter = b;
				for (var j = 0; j < tables.Length; j++)
				{
					_lettersSpec[0].OutputLetters.Add(new OutputLetter(tables[j].x));
					_lettersSpec[1].OutputLetters.Add(new OutputLetter(tables[j].y));
				}
				for (iInput += 2; iInput < _len; iInput++)
				{
					a += b;
					if (a > 28)
						a -= 28;
					b = Constants.Letters[tbInput.Text[iInput]].Abjad1;
					var x = (byte)(tables[0].x + tables[0].y);
					if (x > 28)
						x -= 28;
					FindBestTable(a, b, x, _myElementalStrings[i][iInput], false, out tables);
					_lettersSpec[iInput].InputLetter = b;
					for (var j = 0; j < tables.Length; j++)
						_lettersSpec[iInput].OutputLetters.Add(new OutputLetter(tables[j].y));
				}
				// temporarily disable first method and concentrate on the second one. in the first method i get exceptions.
				/*
				var letters = FindBestLetters(lettersSpec);
				tbOutputs[i].Text = "";
				for (var j = 0; j < len; j++)
					tbOutputs[i].Text += Constants.Abjad1ToLetter(letters[j]);
				*/
				// instead of the above code, i temporarily use this one:
				var letters = new byte[_len];
				tbOutputs[i].Text = "";
				for (var j = 0; j < _len; j++)
				{
					letters[j] = _lettersSpec[j].OutputLetters[0].Letter;
					tbOutputs[i].Text += Constants.Abjad1ToLetter(letters[j]);
				}

				// second method

				CalculateOBVs(i);
				_finalOBV = 2;  // نشان دهنده این است که تکلیف ما از بابت پخش میانگین که کدام را انتخاب کنیم هنوز مشخص نیست
				_lettersSpec[0].OutputLetters.RemoveRange(1, _lettersSpec[0].OutputLetters.Count - 1);
				_lettersSpec[1].OutputLetters.RemoveRange(1, _lettersSpec[1].OutputLetters.Count - 1);
				_step2matchedPlusMinusPatterns = _step2acceptablePlusMinusPatterns.ToList();
				for (_col = 0; _col < _len / 2; _col++)
				{
					Step1();
					List<Pair> pairs = AllPairs();  // all pairs that are available and could pass step1
					pairs = Step5(pairs);
					pairs = Step2(pairs);
					pairs = Step4(pairs);
					pairs = Step3(pairs);
					pairs = Step6(pairs);
					pairs = Step7(pairs);

					pairs = pairs.Distinct().ToList();
					Debug.Write(string.Format("finalOBV: {0} --> Prioritize({1} pairs)", _finalOBV, pairs.Count));
					pairs[0] = Prioritize(pairs);
					Debug.WriteLine(" --> {0}, {1},{2}\n", _finalOBV, pairs[0].Left, pairs[0].Right);
					_previousColumnAnswer = pairs[0];
					letters[_len - 1 - _col] = pairs[0].Left;
					letters[_col] = pairs[0].Right;
					_foundPairsSum += pairs[0].Left + pairs[0].Right;
					RefineStep1Matches(pairs[0]);
					RefineStep2Matches(pairs[0]);
					RefineStep3Matches(pairs[0]);
					tbOutputs[4 + i].Text = "";
					for (var j = 0; j < _len; j++)
						tbOutputs[4 + i].Text += Constants.Abjad1ToLetter(letters[j]);
				}
			}
		}

		bool CanSatisfyStep1Matches(Pair pair)
		{
			var step1matched128Patterns = new List<string>[2];
			step1matched128Patterns[0] = _step1matched128Patterns[0];
			step1matched128Patterns[1] = _step1matched128Patterns[1];
			// 0 for right, 1 for left
			for (var direction = 0; direction < 2; direction++)
			{
				var realCol = direction == 0 ? _col : _len - 1 - _col;
				var inputLetter = _lettersSpec[realCol].InputLetter;
				var outputLetter = direction == 0 ? pair.Right : pair.Left;
				var numbers = new long[]
				{
					Diff(inputLetter, outputLetter),
					inputLetter + outputLetter,
				};
				var res128 = new List<Result128>();
				foreach (var n in numbers)
					res128.AddRange(ResultOf128(n, inputLetter));
				res128 = Distinct(res128);
				if (!_step1IncludesPatternsIncludingOne)
					res128 = RemoveOne(res128);
				res128 = PreferDirect(res128);
				Debug.Assert(res128.Count != 0);
				var refinedMatched128Patterns = new List<string>();
				foreach (var matchedPattern in step1matched128Patterns[direction])
				{
					var expectedNumber = matchedPattern[_col % matchedPattern.Length] - '0';
					var keepPattern = false;
					foreach (var res in res128)
						if (res.n == expectedNumber)
						{
							keepPattern = true;
							break;
						}
					if (keepPattern)
						refinedMatched128Patterns.Add(matchedPattern);
				}
				step1matched128Patterns[direction] = refinedMatched128Patterns;
			}
			return ConcordStep1LeftAndRight128Matches(step1matched128Patterns);
		}

		bool ConcordStep1LeftAndRight128Matches(List<string>[] step1matched128Patterns)
		{
			// اگر چپ سه تایی نداره از راست حذف کن و بالعکس
			bool[] includesOne = { false, false };
			for (var direction = 0; direction < 2; direction++)
				foreach (var match in step1matched128Patterns[direction])
					if (match.Contains('1'))
					{
						includesOne[direction] = true;
						break;
					}
			if (includesOne[0] != includesOne[1])
			{
				var i = includesOne[0] == true ? 0 : 1;
				var matches = new List<string>();
				foreach (var match in step1matched128Patterns[i])
					if (!match.Contains('1'))
						matches.Add(match);
				step1matched128Patterns[i] = matches;
			}
			return step1matched128Patterns[0].Count != 0 && step1matched128Patterns[1].Count != 0;
		}

		// update _step1matched128Patterns based on the found pair
		void RefineStep1Matches(Pair pair)
		{
			// 0 for right, 1 for left
			for (var direction = 0; direction < 2; direction++)
			{
				var realCol = direction == 0 ? _col : _len - 1 - _col;
				var inputLetter = _lettersSpec[realCol].InputLetter;
				var outputLetter = direction == 0 ? pair.Right : pair.Left;
				var numbers = new long[]
				{
					Diff(inputLetter, outputLetter),
					inputLetter + outputLetter,
				};
				var res128 = new List<Result128>();
				foreach (var n in numbers)
					res128.AddRange(ResultOf128(n, inputLetter));
				res128 = Distinct(res128);
				if (!_step1IncludesPatternsIncludingOne)
					res128 = RemoveOne(res128);
				res128 = PreferDirect(res128);
				Debug.Assert(res128.Count != 0);
				var refinedMatched128Patterns = new List<string>();
				foreach (var matchedPattern in _step1matched128Patterns[direction])
				{
					var expectedNumber = matchedPattern[_col % matchedPattern.Length] - '0';
					var keepPattern = false;
					foreach (var res in res128)
						if (res.n == expectedNumber)
						{
							keepPattern = true;
							break;
						}
					if (keepPattern)
						refinedMatched128Patterns.Add(matchedPattern);
				}
				_step1matched128Patterns[direction] = refinedMatched128Patterns;
			}
		}

		List<Result128> PreferDirect(List<Result128> res128)
		{
			var includesDirect = false;
			foreach (var res in res128)
				if (!res.bWithInterfering28)
				{
					includesDirect = true;
					break;
				}
			if (!includesDirect)
				return res128;
			var list = new List<Result128>();
			foreach (var res in res128)
				if (!res.bWithInterfering28)
					list.Add(res);
			return list;
		}

		List<ResultBodduh> PreferDirect(List<ResultBodduh> res)
		{
			var includesDirect = false;
			foreach (var r in res)
				if (!r.bWithInterfering28)
				{
					includesDirect = true;
					break;
				}
			if (!includesDirect)
				return res;
			var list = new List<ResultBodduh>();
			foreach (var r in res)
				if (!r.bWithInterfering28)
					list.Add(r);
			return list;
		}

		List<Result128> RemoveOne(List<Result128> res)
		{
			var ret = new List<Result128>();
			foreach (var r in res)
				if (r.n != 1)
					ret.Add(r);
			return ret;
		}

		// update _step2matched128Patterns and _step2matchedPlusMinusPatterns based on the found pair
		void RefineStep2Matches(Pair pair)
		{
			var refinedMatchedPlusMinusPatterns = new List<string>();
			var includePlus = false;
			var includeMinus = false;
			foreach (var pattern in _step2matchedPlusMinusPatterns)
			{
				var sign = pattern[_col % pattern.Length];
				if (sign == '-')
					includeMinus = true;
				else
					includePlus = true;
			}

			var left = pair.Left;
			var right = pair.Right;
			var minusMatches128Patterns = 2;  // 2: no match, 0: matches directly, 1: matches indirectly
			var plusMatches128Patterns = 2;  // 2: no match, 0: matches directly, 1: matches indirectly
			var minusRefinedMatched128Patterns = new List<string>();
			var plusRefinedMatched128Patterns = new List<string>();
			var list = new List<Result128>();
			if (includeMinus)
			{
				list = ResultOf128(Diff(left, right), left);
				list = PreferDirect(list);
				foreach (var res in list)
					foreach (var matchedPattern in _step2matched128Patterns)
						if (matchedPattern[_col % matchedPattern.Length] - '0' == res.n)
						{
							minusMatches128Patterns = Math.Min(minusMatches128Patterns, res.bWithInterfering28 ? 1 : 0);
							minusRefinedMatched128Patterns.Add(matchedPattern);
						}
			}
			if (includePlus)
			{
				list = ResultOf128(left + right);
				list = PreferDirect(list);
				foreach (var res in list)
					foreach (var matchedPattern in _step2matched128Patterns)
						if (matchedPattern[_col % matchedPattern.Length] - '0' == res.n)
						{
							plusMatches128Patterns = Math.Min(plusMatches128Patterns, res.bWithInterfering28 ? 1 : 0);
							plusRefinedMatched128Patterns.Add(matchedPattern);
						}
			}

			if (minusMatches128Patterns < plusMatches128Patterns)  // if so, prefer minus
			{
				_step2matched128Patterns = minusRefinedMatched128Patterns;
				var patterns = new List<string>();
				foreach (var pattern in _step2matchedPlusMinusPatterns)
				{
					var sign = pattern[_col % pattern.Length];
					if (sign == '-')
						patterns.Add(pattern);
				}
				_step2matchedPlusMinusPatterns = patterns;
			}
			else if (minusMatches128Patterns > plusMatches128Patterns)
			{
				_step2matched128Patterns = plusRefinedMatched128Patterns;
				var patterns = new List<string>();
				foreach (var pattern in _step2matchedPlusMinusPatterns)
				{
					var sign = pattern[_col % pattern.Length];
					if (sign == '+')
						patterns.Add(pattern);
				}
				_step2matchedPlusMinusPatterns = patterns;
			}
			else  // are equal
			{
				_step2matched128Patterns = minusRefinedMatched128Patterns;
				_step2matched128Patterns.AddRange(plusRefinedMatched128Patterns);
			}
		}

		// update _step3Mask based on the found pair
		void RefineStep3Matches(Pair pair)
		{
			Debug.Assert(pair.ThirdStepResultsBodduh.Count == 1);
			_step3Mask &= (byte)~(0x01 << (pair.ThirdStepResultsBodduh[0].n / 2 - 1));
		}

		Pair Prioritize(List<Pair> pairs)
		{
            Debug.WriteLine("\nprioritizing...\npairs:");
            foreach (var pair in pairs)
                Debug.WriteLine("{0},{1} ", pair.Left, pair.Right);
            // اگر تکلیف پخش میانگین مشخص شده جفت اعدادی که با آن سازگار نیستند را حذف کن
			// TODO: آیا لازمه؟
            var pairs2 = new List<Pair>();
            if (_finalOBV != 2)
			{
				foreach (var pair in pairs)
					if (pair.OBV == _finalOBV)
						pairs2.Add(pair);
				pairs = pairs2;
			}
			Debug.Assert(pairs.Count != 0);
			if (pairs.Count < 2)
			{
				_finalOBV = pairs[0].OBV;
				return pairs[0];
			}
			foreach (var pair in pairs)
				pair.IndirectionCount += pair.ThirdStepIndirectionCount;
			pairs.Sort((x, y) => x.IndirectionCount.CompareTo(y.IndirectionCount));
            Debug.WriteLine("ordering pairs by step3 score");
            foreach (var pair in pairs)
                Debug.WriteLine("{0},{1}\t{2}", pair.Left, pair.Right, pair.IndirectionCount);
            var i = 1;
			for (; i < pairs.Count; i++)
				if (pairs[i].IndirectionCount != pairs[0].IndirectionCount)
					break;
			if (i == 1)
			{
				_finalOBV = pairs[0].OBV;
				return pairs[0];
			}
			if (i == 2 && pairs[0].Left == pairs[1].Left && pairs[0].Right == pairs[1].Right)
				return pairs[0];
	
			pairs.RemoveRange(i, pairs.Count - i);
			foreach (var pair in pairs)
			{
				pair.IndirectionCount = 0;
				if (!IncludesDirect(pair.LeftLetterResults128))
					pair.IndirectionCount++;
				if (!IncludesDirect(pair.RightLetterResults128))
					pair.IndirectionCount++;
				if (!IncludesDirect(pair.SecondStepResults128))
					pair.IndirectionCount++;
				pair.IndirectionCount += pair.ThirdStepIndirectionCount;
				if (!IncludesDirect(pair.FourthStepResultsBodduh))
					pair.IndirectionCount++;
			}
			pairs.Sort((x, y) => x.IndirectionCount.CompareTo(y.IndirectionCount));
            Debug.WriteLine("ordering pairs by total score");
            foreach (var pair in pairs)
				Debug.WriteLine("{0},{1}\t{2}", pair.Left, pair.Right, pair.IndirectionCount);
			for (i = 1; i < pairs.Count; i++)
				if (pairs[i].IndirectionCount != pairs[0].IndirectionCount)
					break;
			if (i == 1)
			{
				_finalOBV = pairs[0].OBV;
				return pairs[0];
			}
			if (i == 2 && pairs[0].Left == pairs[1].Left && pairs[0].Right == pairs[1].Right)
				return pairs[0];

			pairs.RemoveRange(i, pairs.Count - i);
            Debug.WriteLine("removing pairs with lower scores");
            foreach (var pair in pairs)
                Debug.WriteLine("{0},{1}\t{2}", pair.Left, pair.Right, pair.IndirectionCount);
            pairs2 = new List<Pair>();
			foreach (var pair in pairs)
				if (CanSatisfyStep1Matches(pair))
					pairs2.Add(pair);
			pairs = pairs2;
            Debug.WriteLine("after applying CanSatisfyStep1Matches");
            foreach (var pair in pairs)
                Debug.WriteLine("{0},{1}\t{2}", pair.Left, pair.Right, pair.IndirectionCount);
            if (pairs.Count == 1)
				return pairs[0];

			// step 8
			foreach (var pair in pairs)
			{
				pair.IndirectionCount = 0;
				if (!IncludesDirect(pair.SecondStepResults128))
					pair.IndirectionCount++;
			}
			pairs.Sort((x, y) => x.IndirectionCount.CompareTo(y.IndirectionCount));
			Debug.WriteLine("ordering pairs by step 2 score");
			foreach (var pair in pairs)
				Debug.WriteLine("{0},{1}\t{2}", pair.Left, pair.Right, pair.IndirectionCount);
			for (i = 1; i < pairs.Count; i++)
				if (pairs[i].IndirectionCount != pairs[0].IndirectionCount)
					break;
			if (i == 1)
			{
				_finalOBV = pairs[0].OBV;
				return pairs[0];
			}
			if (i == 2 && pairs[0].Left == pairs[1].Left && pairs[0].Right == pairs[1].Right)
				return pairs[0];
			pairs.RemoveRange(i, pairs.Count - i);
			// ~step 8

			pairs = Step9(pairs);
			if (pairs.Count == 1)
			{
				_finalOBV = pairs[0].OBV;
				return pairs[0];
			}
			if (pairs.Count == 2 && pairs[0].Left == pairs[1].Left && pairs[0].Right == pairs[1].Right)
				return pairs[0];

			if (_finalOBV != 2)  // فرض رو بر این میذاریم که گام دهم به بعد وقتی نیاز میشه که تکلیف پخش میانگین مشخص شده باشه
			{
				pairs = Step10(pairs);
				if (pairs.Count == 1)
					return pairs[0];
			}

			Debug.WriteLine("\nremained pairs:");
			foreach (var pair in pairs)
				Debug.WriteLine("{0},{1},{2}\t{3}", pair.Left, pair.Right, pair.OBV, pair.IndirectionCount);
			Debug.Assert(false);
			return null;
		}

		bool IncludesDirect(List<Result128> results)
		{
			foreach (var res in results)
				if (res.bWithInterfering28 == false)
					return true;
			return false;
		}

		bool IncludesDirect(List<ResultBodduh> results)
		{
			foreach (var res in results)
				if (res.bWithInterfering28 == false)
					return true;
			return false;
		}

		private void Score(byte a, byte b, byte x, byte y, out int[] c, bool bCalculateForTwoInitialLetters, out int[] scores, out int score1, out int score2)
		{
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
			var i = 0;
			for (; i < ar.Length; i++)
				ar[i] = (ar[i] + 27) % 28 + 1;
			int[] r =
			{
				ar[0] + ar[1] + ar[2] + ar[3],
				ar[4] + ar[5] + ar[6] + ar[7],
				ar[8] + ar[9] + ar[10] + ar[11],
				ar[12] + ar[13] + ar[14] + ar[15],
			};
			// first column is defined to be the rightmost one.
			c = new int[]
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
			scores = new int[36];

			// 1
			long[] vars = new long[2];
			scores[0] += ScoreDiff(ar[0] + ar[1], ar[2] + ar[3]);
			if (scores[0] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[0] = ar[0] + ar[1] + Diff(ar[2], ar[3]);
				scores[0] += Score(vars[0]);
				if (scores[0] == 0)
					scores[0] += vars[0] % 11 == 0 ? 1 : 0;
				if (scores[0] == 0)
				{
					vars[0] = ar[0] + ar[3] + Diff(ar[1], ar[2]);
					scores[0] += Score(vars[0]);
					if (scores[0] == 0)
						scores[0] += vars[0] % 11 == 0 ? 1 : 0;
					if (scores[0] == 0)
						scores[0] += vars[0] % 17 == 0 ? 1 : 0;
				}
			}

			// 2
			scores[1] = Score(r[0], r[3]);
			if (scores[1] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[1] += Score(Diff(r[0], r[3]) * 2);
				if (scores[1] == 0)
					scores[1] += Score((r[0] + r[3]) * 2);
			}

			// 3
			scores[2] = Score(c[0], c[3]);
			if (scores[2] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[2] += Score(Diff(c[0], c[3]) * 2);
				if (scores[2] == 0)
					scores[2] += Score((c[0] + c[3]) * 2);
			}

			// 4
			scores[3] = Score(r[0], c[3]);
			if (scores[3] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[3] += Score(Diff(r[0], c[3]) * 2);
				if (scores[3] == 0)
					scores[3] += Score((r[0] + c[3]) * 2);
			}

			// 5
			scores[4] = Score(c[0], r[3]);
			if (scores[4] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[4] = Score((c[0] + r[3]) * 2);
				if (scores[4] == 0)
					scores[4] = Score(Diff(c[0], r[3]) * 2);
			}

			// 6
			scores[5] = ScoreDiff(c[0] + c[3], r[0] + r[3]);
			scores[5] += ScoreDiff(c[0] + c[3], Diff(r[0], r[3]));
			if (scores[5] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[5] += Score(c[0] + c[3] + r[0] + r[3]);
				if (scores[5] == 0)
					scores[5] += Score(c[0] + c[3] + Diff(r[0], r[3]));
			}

			// 7
			vars[0] = c[0] + c[1] + c[2] + c[3];
			scores[6] = Score(vars[0]);
			if (scores[6] == 0 && !bCalculateForTwoInitialLetters)
				scores[6] += Score(Reverse(vars[0]));

			// 8
			vars[0] = rows[0] + rows[1] + rows[2] + rows[3];
			scores[7] = Score(vars[0]);
			if (scores[7] == 0 && !bCalculateForTwoInitialLetters)
				scores[7] = Score(vars[0], Reverse(vars[0]), true);

			// 9
			scores[8] = Score(rows[0] + rows[2]);
			if (scores[8] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[8] = Score(rowsRev[0], rowsRev[2], true);
				if (scores[8] == 0)
					scores[8] += Score(Reverse(rows[0]), Reverse(rows[2]), true);
			}

			// 10
			do
			{
				vars[0] = int.Parse(string.Format("{0}{0}{0}{0}", ar[0])) % 28;
				vars[1] = int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12])) % 28;
				scores[9] = vars[0] == ar[0] ? 1 : 0;
				scores[9] += vars[1] == ar[1] ? 1 : 0;
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[9] == 0)
					scores[9] += Score(vars[0], vars[1], true);
				if (scores[9] == 0)
					scores[9] += Score(vars[0]) != 0 || vars[0] % 11 == 0 || vars[0] % 17 == 0 ? 1 : 0;
				if (scores[9] == 0)
					scores[9] += Score(vars[1]) != 0 || vars[1] % 11 == 0 || vars[1] % 17 == 0 ? 1 : 0;
			} while (false);

			// 11
			vars[0] = int.Parse(string.Format("{0}{1}{2}{3}", ar[12], ar[9], ar[6], ar[3]));
			scores[10] = Score(vars[0]);
			if (scores[10] == 0 && !bCalculateForTwoInitialLetters)
			{
				vars[1] = int.Parse(string.Format("{0}{1}{2}{3}", ar[3], ar[6], ar[9], ar[12]));
				scores[10] = Score(vars[0], vars[1], true);
			}

			// 12
			vars[0] = (c[0] + c[1] + c[2] + c[3]) % 9;
			if (vars[0] == 2 || vars[0] == 8)
				scores[11]++;
			vars[0] = c[3] % 9;
			if (vars[0] == 2 || vars[0] == 8)
				scores[11]++;
			int[] sumOfDigits =
			{
				SumOfDigits(c[0]),
				SumOfDigits(c[1]),
				SumOfDigits(c[2]),
				SumOfDigits(c[3]),
			};
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[3], sumOfDigits[2], sumOfDigits[1], sumOfDigits[0])), false);
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[3], sumOfDigits[1], sumOfDigits[2], sumOfDigits[0])), false);
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[1], sumOfDigits[2], sumOfDigits[3])), false);
			vars[0] = sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3];
			scores[11] += Score(vars[0] * 2, false);
			scores[11] += Score(cols[3], false);
			scores[11] += Score(colsRev[3], false);
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[3]), SumOfDigits(ar[7]), SumOfDigits(ar[11]), SumOfDigits(ar[15]))), false);
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[15]), SumOfDigits(ar[11]), SumOfDigits(ar[7]), SumOfDigits(ar[3]))), false);
			scores[11] += Score(int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[3], sumOfDigits[2], sumOfDigits[0], sumOfDigits[1])), false);
			sumOfDigits[0] = int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[3]), SumOfDigits(ar[2]), SumOfDigits(ar[1]), SumOfDigits(ar[0])));
			sumOfDigits[1] = int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[7]), SumOfDigits(ar[6]), SumOfDigits(ar[5]), SumOfDigits(ar[4])));
			sumOfDigits[2] = int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[11]), SumOfDigits(ar[10]), SumOfDigits(ar[9]), SumOfDigits(ar[8])));
			sumOfDigits[3] = int.Parse(string.Format("{0}{1}{2}{3}", SumOfDigits(ar[15]), SumOfDigits(ar[14]), SumOfDigits(ar[13]), SumOfDigits(ar[12])));
			vars[0] = sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3];
			scores[11] += Score(vars[0], false);
			vars[1] = Reverse(sumOfDigits[0]) + Reverse(sumOfDigits[1]) + Reverse(sumOfDigits[2]) + Reverse(sumOfDigits[3]);
			scores[11] += Score(vars[1], false);
			sumOfDigits[0] = SumOfDigits(r[0]);
			sumOfDigits[1] = SumOfDigits(c[3]);
			sumOfDigits[2] = SumOfDigits(r[3]);
			sumOfDigits[3] = SumOfDigits(c[0]);
			scores[11] += Score(sumOfDigits[0], sumOfDigits[1]);
			scores[11] += Score(sumOfDigits[1], sumOfDigits[2]);
			scores[11] += Score(sumOfDigits[2], sumOfDigits[3]);
			scores[11] += Score(sumOfDigits[3], sumOfDigits[0]);
			scores[11] += Score(sumOfDigits[0] + sumOfDigits[1] + sumOfDigits[2] + sumOfDigits[3]);
			vars = new long[9];
			vars[0] = Diff(ar[0], ar[3]);
			vars[1] = Diff(ar[1], ar[2]);
			vars[2] = int.Parse(string.Format("{0}{1}", vars[0], vars[1]));
			vars[3] = int.Parse(string.Format("{0}{1}", vars[1], vars[0]));
			vars[4] = vars[0] + vars[1];
			vars[5] = Diff(vars[0], vars[1]);
			vars[6] = Diff(vars[2], vars[3]);
			vars[7] = int.Parse(string.Format("{0}{1}", vars[4], vars[5]));
			vars[8] = int.Parse(string.Format("{0}{1}", vars[5], vars[4]));
			scores[11] += Score(vars[4]);
			scores[11] += ScoreDiff(vars[0], vars[1]);
			scores[11] += ScoreDiff(vars[2], vars[3]);
			scores[11] += Score(vars[7]);
			scores[11] += Score(vars[8]);

			// 13
			var colMul = c[0] * c[3];
			var rowMul = r[0] * r[3];
			scores[12] = Score(colMul);
			scores[12] += Score(rowMul, colMul);
			if (scores[12] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[12] += Score(rowMul);
				if (scores[12] == 0)
				{
					colMul = SumOfDigits(c[0]) * SumOfDigits(c[3]);
					rowMul = SumOfDigits(r[0]) * SumOfDigits(r[3]);
					scores[12] = Score(colMul) != 0 || Score(rowMul) != 0 || Score(rowMul, colMul, true) != 0 ? 1 : 0;
				}
			}

			// 14
			scores[13] = Score((c[0] + c[3]) * (r[0] + r[3]));
			if (Diff(r[0], r[3]) != 0)
				scores[13] += Score((c[0] + c[3]) * Diff(r[0], r[3]));
			if (Diff(c[0], c[3]) != 0)
				scores[13] += Score(Diff(c[0], c[3]) * (r[0] + r[3]));
			if (Diff(c[0], c[3]) != 0 && Diff(r[0], r[3]) != 0)
				scores[13] += Score(Diff(c[0], c[3]) * Diff(r[0], r[3]));

			scores[13] += Score((r[0] + c[3]) * (c[0] + r[3]));
			if (Diff(c[0], r[3]) != 0)
				scores[13] += Score((r[0] + c[3]) * Diff(c[0], r[3]));
			if (Diff(r[0], c[3]) != 0)
				scores[13] += Score(Diff(r[0], c[3]) * (c[0] + r[3]));
			if (Diff(r[0], c[3]) != 0 && Diff(c[0], r[3]) != 0)
				scores[13] += Score(Diff(r[0], c[3]) * Diff(c[0], r[3]));

			// 15
			vars = new long[]
			{
				Diff(rows[0], rowsRev[0]),
				Diff(rows[1], rowsRev[1]),
				Diff(rows[2], rowsRev[2]),
				Diff(rows[3], rowsRev[3]),
			};
			if (vars[0] == 0 && vars[1] == 0)
			{
				scores[14] = 3;
			}
			else
			{
				scores[14] = ScoreDiff(vars[0], vars[1]);
				scores[14] += Score(vars[1], vars[2], true);
				scores[14] += Score(vars[2], vars[3], true);
				scores[14] += Score(vars[0], vars[3], true);
			}

			// 16
			vars[0] = c[0] * c[1];
			vars[1] = c[2] * c[3];
			vars[2] = vars[0] * vars[1];
			scores[15] += Score(vars[2]);
			if (scores[15] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[15] = Score(vars[0], vars[1], true);
				if (scores[15] == 0)
					scores[15] = Score(vars[2], Reverse(vars[2]), true);
				if (scores[15] == 0)
					scores[15] = Score(vars[2] * 2);
				if (scores[15] == 0)
					scores[15] = Score(Reverse(vars[2]) * 2);
			}

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
			scores[16] += Score(columnsMul[0] + columnsMul[1] + columnsMul[2] + columnsMul[3]);

			// 18
			scores[17] += Score(r[0], r[1]);
			scores[17] += Score(r[0], r[2]);
			scores[17] += Score(r[1] + r[3]);
			scores[17] += Score(r[0] * r[1] * r[2] * r[3]);
			if (scores[17] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[17] += Score(r[1], r[2], true);
				if (scores[17] == 0)
					scores[17] += ScoreDiff(r[1], r[3]);
				if (scores[17] == 0)
					scores[17] += Score(r[2], r[3], true);
			}

			// 19
			vars = new long[]
			{
				Diff(ar[0], ar[3]), Diff(ar[4], ar[7]), Diff(ar[8], ar[11]), Diff(ar[12], ar[15]), 0,
				Diff(ar[1], ar[2]), Diff(ar[5], ar[6]), Diff(ar[9], ar[10]), Diff(ar[13], ar[14]), 0,
			};
			vars[4] = vars[0] + vars[1] + vars[2] + vars[3];
			vars[9] = vars[5] + vars[6] + vars[7] + vars[8];
			if (vars[4] != 0)
				scores[18] += Score(vars[4]);
			if (vars[4] != vars[9])
				scores[18] += Score(vars[4], vars[9]);
			if (scores[18] == 0 && !bCalculateForTwoInitialLetters)
			{
				if (vars[9] != 0)
					scores[18] += Score(vars[9]);
				if (scores[18] == 0)
					scores[18] =
						Score(vars[0], vars[5], true) != 0 &&
						Score(vars[1], vars[6], true) != 0 &&
						Score(vars[2], vars[7], true) != 0 &&
						Score(vars[3], vars[8], true) != 0 ? 1 : 0;
			}

			// 20
			vars = new long[]
			{
				c[0] * c[3],
				r[0] * r[3],
			};
			scores[19] = Score(vars[0] * vars[1], vars[0] * c[1] * c[2]);
			if (scores[19] == 0 && !bCalculateForTwoInitialLetters)
				scores[19] = Score(vars[0], vars[1], true);

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
			scores[20] += Score(vars[3] == 0 ? vars[0] : vars[3]);
			if (scores[20] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[20] += vars[2] % 11 == 0 ? 1 : 0;
				if (scores[20] == 0)
					scores[20] += vars[3] % 11 == 0 ? 1 : 0;
				if (scores[20] == 0)
				{
					vars[2] = vars[0] % 28;
					vars[3] = vars[1] % 28;
					scores[20] += Score(vars[2], vars[3], true);
				}
			}

			// 22
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
			scores[21] +=
				(vars[4] == 0 ?
					Score(rows[0]) != 0 && Score(rows[1]) != 0 && Score(rows[2]) != 0 && Score(rows[3]) != 0 :
					vars[4] % 9 == 0) ? 1 : 0;
			scores[21] +=
				(vars[9] == 0 ?
					Score(cols[0]) != 0 && Score(cols[1]) != 0 && Score(cols[2]) != 0 && Score(cols[3]) != 0 :
					vars[9] % 9 == 0) ? 1 : 0;
			if (vars[4] != 0 && vars[9] != 0)
				scores[21] += Score(vars[4], vars[9]);
			if (scores[21] == 0 && !bCalculateForTwoInitialLetters)
			{
				scores[21] += Score(vars[4]);
				if (scores[21] == 0)
					scores[21] += Score(vars[9]);
			}

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
				long.Parse(string.Format("{0}{1}{2}{3}", c[3], c[2], c[1], c[0])),  // 0. 58463438
				long.Parse(string.Format("{0}{1}{2}{3}", c[0], c[1], c[2], c[3])),  // 1. 38344658
				long.Parse(string.Format("{0}{1}{2}{3}", r[3], c[3], r[0], c[0])),  // 2. 30585038
				long.Parse(string.Format("{0}{1}{2}{3}", r[0], c[3], r[3], c[0])),  // 3. 50583038
				long.Parse(string.Format("{0}{1}{2}{3}", c[3], r[3], c[0], r[0])),  // 4. 58303850
				long.Parse(string.Format("{0}{1}{2}{3}", c[0], r[3], c[3], r[0])),  // 5. 38305850
				long.Parse(string.Format("{0}{1}{2}{3}", r[3], c[0], r[0], c[3])),  // 6. 30385058
				long.Parse(string.Format("{0}{1}{2}{3}", r[0], c[0], r[3], c[3])),  // 7. 50383058
				long.Parse(string.Format("{0}{1}{2}{3}", c[3], r[0], c[0], r[3])),  // 8. 58503830
				long.Parse(string.Format("{0}{1}{2}{3}", c[0], r[0], c[3], r[3])),  // 9. 38505830
				0,
				0,
				0,
				};
			var list1 = new List<long>();  // for holding the original number
			var list2 = new List<long>();  // for holding the valuable number

			// 24
			do
			{
				vars[10] = vars[0] + vars[1];
				scores[23] = Score(vars[10]);
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[23] == 0)
					scores[23] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				scores[23] += Score(vars[10] * 2);
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10] * 2);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[23] += vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = Diff(vars[0], vars[1]);
				scores[23] += ScoreDiff(vars[0], vars[1]);
				if (scores[23] == 0)
					scores[23] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				scores[23] += Score(vars[10] * 2);
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10] * 2);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[23] += vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[23] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				scores[23] += Score(vars[0] * 2);
				if (scores[23] != 0)
				{
					list1.Add(vars[0]);
					list2.Add(vars[0] * 2);
					break;
				}
				scores[23] += Score(vars[1] * 2);
				if (scores[23] != 0)
				{
					list1.Add(vars[1]);
					list2.Add(vars[1] * 2);
					break;
				}
			} while (false);

			// 25
			do
			{
				vars[10] = vars[3] + vars[5];
				scores[24] = Score(vars[10]) != 0 || vars[10] % 8 == 0 ? 1 : 0;
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[24] == 0)
					scores[24] = vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[24] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = vars[2] + vars[9] + vars[10];
				scores[24] = Score(vars[11]);
				if (scores[24] != 0)
				{
					list1.Add(vars[11]);
					list2.Add(vars[11]);
					break;
				}
				vars[11] = Diff(vars[2] + vars[9], vars[10]);
				scores[24] = ScoreDiff(vars[2] + vars[9], vars[10]);
				if (scores[24] != 0)
				{
					list1.Add(vars[11]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = SumOfDigits(vars[10], false);
				scores[24] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				vars[11] = vars[3] + vars[9];
				scores[24] = Score(vars[11]);
				if (scores[24] != 0)
				{
					list1.Add(vars[11]);
					list2.Add(vars[11]);
					break;
				}
				vars[11] = Diff(vars[3], vars[9]);
				scores[24] = ScoreDiff(vars[3], vars[9]);
				if (scores[24] != 0)
				{
					list1.Add(vars[11]);
					list2.Add(vars[11]);
					break;
				}
			} while (false);

			// 26
			do
			{
				scores[25] = ScoreDiff(vars[3], vars[5]);
				if (bCalculateForTwoInitialLetters)
					break;
				vars[10] = Diff(vars[3], vars[5]);
				if (scores[25] == 0)
					scores[25] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[25] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[25] += vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[25] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
			} while (false);

			// 27
			do
			{
				vars[10] = vars[4] + vars[7];
				scores[26] = Score(vars[10]);
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[26] == 0)
					scores[26] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[26] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = Diff(vars[4], vars[7]);
				scores[26] += ScoreDiff(vars[4], vars[7]);
				if (scores[26] == 0)
					scores[26] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[26] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = vars[3] + vars[4];
				scores[26] = Score(vars[10]);
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[10] = Diff(vars[3], vars[4]);
				scores[26] += ScoreDiff(vars[4], vars[7]);
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
			} while (false);

			// 28
			do
			{
				vars[10] = vars[6] + vars[8];
				scores[27] = Score(vars[10]) != 0 || vars[10] % 8 == 0 ? 1 : 0;
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[27] == 0)
					scores[27] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[27] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[27] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[27] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = Diff(vars[6], vars[8]);
				scores[27] = ScoreDiff(vars[6], vars[8]);
				if (scores[27] == 0)
					scores[27] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[27] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[27] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[27] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = vars[4] + vars[6];
				scores[27] = Score(vars[10]);
				if (scores[27] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[10] = Diff(vars[4], vars[6]);
				scores[26] += ScoreDiff(vars[4], vars[6]);
				if (scores[26] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
			} while (false);

			// 29
			do
			{
				vars[10] = vars[2] + vars[9];
				scores[28] = Score(vars[10]);
				if (bCalculateForTwoInitialLetters)
					break;
				if (scores[28] == 0)
					scores[28] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[28] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[28] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[28] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
				vars[10] = Diff(vars[2], vars[9]);
				scores[28] = ScoreDiff(vars[2], vars[9]);
				if (scores[28] == 0)
					scores[28] += vars[10] % 11 == 0 || vars[10] % 17 == 0 || vars[10] % 28 % 11 == 0 || vars[10] % 28 % 17 == 0 ? 1 : 0;
				if (scores[28] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[10]);
					break;
				}
				vars[11] = SumOfDigits(vars[10], false);
				scores[28] = vars[11] % 11 == 0 || vars[11] % 17 == 0 || vars[11] % 28 % 11 == 0 || vars[11] % 28 % 17 == 0 ? 1 : 0;
				if (scores[28] != 0)
				{
					list1.Add(vars[10]);
					list2.Add(vars[11]);
					break;
				}
			} while (false);

			// 30
			vars = new long[]
			{
				(ar[0] - 1) / 4 + (ar[4] - 1) / 4 + (ar[8] - 1) / 4 + (ar[12] - 1) / 4 + 4,
				(ar[1] - 1) / 4 + (ar[5] - 1) / 4 + (ar[9] - 1) / 4 + (ar[13] - 1) / 4 + 4,
				(ar[2] - 1) / 4 + (ar[6] - 1) / 4 + (ar[10] - 1) / 4 + (ar[14] - 1) / 4 + 4,
				(ar[3] - 1) / 4 + (ar[7] - 1) / 4 + (ar[11] - 1) / 4 + (ar[15] - 1) / 4 + 4,
				};
			scores[29] += ar[0] == vars[0] && ar[1] == vars[1] && ar[2] == vars[2] && ar[3] == vars[3] ? 1 : 0;
			scores[29] += Diff(ar[0], vars[0]) % 7 == 0 && Diff(ar[1], vars[1]) % 7 == 0 && Diff(ar[2], vars[2]) % 7 == 0 && Diff(ar[3], vars[3]) % 7 == 0 ? 1 : 0;
			scores[29] += (r[0] + vars[0] + vars[1] + vars[2] + vars[3]) % 7 == 0 ? 1 : 0;
			scores[29] += (vars[0] + vars[1] + vars[2] + vars[3]) % 7 == 0 ? 1 : 0;
			sumOfDigits = new int[]
			{
				SumOfDigits(c[3]), SumOfDigits(c[2]), SumOfDigits(c[1]), SumOfDigits(c[0]),
				SumOfDigits(vars[3]), SumOfDigits(vars[2]), SumOfDigits(vars[1]), SumOfDigits(vars[0]),
			};
			for (i = 0; i < 4; i++)
			{
				vars[0] = Diff(sumOfDigits[i], sumOfDigits[4 + i]);
				if (vars[0] == 1 || vars[0] == 2 || vars[0] == 8)
					continue;
				vars[0] = SumOfDigits(sumOfDigits[i] + sumOfDigits[4 + i]);
				if (vars[0] == 1 || vars[0] == 2 || vars[0] == 8)
					continue;
				break;
			}
			vars[0] = int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[0], sumOfDigits[1], sumOfDigits[2], sumOfDigits[3]));
			vars[1] = int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[4], sumOfDigits[5], sumOfDigits[6], sumOfDigits[7]));
			vars[2] = SumOfDigits(vars[0], false);
			vars[3] = SumOfDigits(vars[1], false);
			if (Score(vars[2], vars[3], true) != 0)
			{
				if ((vars[0] + vars[1]) % 7 == 0 || Diff(vars[0], vars[1]) % 7 == 0)
				{
					vars[1] = int.Parse(string.Format("{0}{1}{2}{3}", sumOfDigits[7], sumOfDigits[6], sumOfDigits[5], sumOfDigits[4]));
					if (ScoreDiff(vars[0], vars[1]) != 0)
					{
						vars[0] = int.Parse(string.Format("{0}{1}{2}{3}",
							SumOfDigits(sumOfDigits[3] + sumOfDigits[4]),
							SumOfDigits(sumOfDigits[2] + sumOfDigits[5]),
							SumOfDigits(sumOfDigits[1] + sumOfDigits[6]),
							SumOfDigits(sumOfDigits[0] + sumOfDigits[7])));
						if (Score(vars[0]) != 0)
						{
							vars[0] = int.Parse(string.Format("{0}{1}{2}{3}",
								sumOfDigits[0] + sumOfDigits[7],
								sumOfDigits[1] + sumOfDigits[6],
								sumOfDigits[2] + sumOfDigits[5],
								sumOfDigits[3] + sumOfDigits[4]));
							scores[29] += Score(vars[0]);
						}
					}
				}
			}

			// 31
			if (!bCalculateForTwoInitialLetters)
			{
				scores[30] = Score(r[0]) + Score(r[3]) + Score(c[0]) + Score(c[3]);
				if (scores[30] == 0)
				{
					vars[0] = r[0] + r[3] + c[0] + c[3];
					scores[30] = Score(SumOfDigits(vars[0]));
				}
			}

			// 33
			if (!bCalculateForTwoInitialLetters)
			{
				vars = list1.ToArray();
				for (i = 0; i < vars.Length - 1; i++)
					for (var j = i + 1; j < vars.Length; j++)
					{
						scores[32] += Score(vars[i], vars[j], true);
						if (scores[32] != 0)
							break;
					}
				vars = list2.ToArray();
				for (i = 0; i < vars.Length - 1; i++)
					for (var j = i + 1; j < vars.Length; j++)
					{
						scores[32] += Score(vars[i], vars[j], true);
						if (scores[32] != 0)
							break;
					}
			}

			// 34
			if (!bCalculateForTwoInitialLetters)
			{
				scores[33] = Score(c[0], c[1], true);
				if (scores[33] == 0)
					scores[33] = Score(c[2], c[3], true);
				if (scores[33] == 0)
					scores[33] = Score(c[0] + c[1], c[2] + c[3], true);
				if (scores[33] == 0)
					scores[33] = Score(Diff(c[0], c[1]), Diff(c[2], c[3]), true);
			}

			// 35
			if (!bCalculateForTwoInitialLetters)
			{
				scores[34] += Score(c[0], c[3], true);
				if (scores[34] == 0)
					scores[34] += (c[0] + c[3]) % 28 % 11 == 0 ? 1 : 0;
				if (scores[34] == 0)
					scores[34] += (c[0] - c[3]) % 28 % 11 == 0 ? 1 : 0;
				if (scores[34] == 0)
					scores[34] += Score(c[1], c[2], true);
				if (scores[34] == 0)
					scores[34] += (c[1] + c[2]) % 28 % 11 == 0 ? 1 : 0;
				if (scores[34] == 0)
					scores[34] += (c[1] - c[2]) % 28 % 11 == 0 ? 1 : 0;
				if (scores[34] == 0)
				{
					vars[0] = Diff(c[0], c[3]) + Diff(c[1], c[2]);
					scores[34] += Score(vars[0]);
					if (scores[34] == 0)
						scores[34] += vars[0] % 28 % 11 == 0 ? 1 : 0;
				}
			}

			score1 = score2 = 0;
			foreach (var sc in scores)
			{
				score1 += sc == 0 ? 0 : 1;
				score2 += sc;
			}
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

		int ScoreDiff(long n1, long n2, bool bK9 = true)
		{
			var diff = Diff(n1, n2);
			if (diff == 0)
				return Score(n1, bK9);
			return Score(diff, bK9);
		}

		int Score(long n, bool bK9 = true)
		{
			if (n == 0)
				return 0;
			if (bK9)
			{
				var n9 = n % 9;
				if (n9 == 2 || n9 == 8)
					return 1;
			}
			n %= 28;
			if (n == 0 || n == 2 || n == 8 || n == 11 || n == 17 || n == 20 || n == 26)
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

