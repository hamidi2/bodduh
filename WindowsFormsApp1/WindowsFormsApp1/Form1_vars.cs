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
		string[] _acceptable128Patterns =
		{
			"128", "182",
			"218", "281",
			"812", "821",
			"228", "282", "822",
			"882", "828", "288",
		};
		// OBV stands for Output Bodduh Values
		byte _finalOBV;  // به کدام پخش میانگین رسیده‌ایم: 2 یعنی هنوز مشخص نشده
		LetterSpec[] _lettersSpec;
		int _len, _col;
		List<byte[]> _myElementalStrings;
		byte[,] _OBV;
		List<string>[] _step1matched128Patterns = new List<string>[2];
		bool _step1IncludesPatternsIncludingOne;
		bool _step1IncludesPatternsNotIncludingOne;
		List<string> _step2matched128Patterns;
		string[] _step2acceptablePlusMinusPatterns =
		{
			"-+-",
			"--+++-",
			"-++++-",
			"-+++-+",
			"-+++-+++-",
			"--+-+-+--",
			"--+++-++---+",
			"--+++--+++--",
			"-++++-++--++",
			"-+++-++-+-++",
			"-+++-++-+++-",
		};
		List<string> _step2matchedPlusMinusPatterns;
		Pair _previousColumnAnswer; // used for step 6
		byte _step3Mask;
	}
}

