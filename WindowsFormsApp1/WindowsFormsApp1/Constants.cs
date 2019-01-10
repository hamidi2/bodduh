using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	static public class Constants
	{
		enum LetterType
		{
			ltForoughi,
			ltHavayi,
			ltAbi,
			ltKhaki
		}

		public class LetterSpec
		{
			public byte Abjad1;
			public short Abjad2;
			public byte Row;  // مرتبه عنصری همان شماره ردیف در جدول داده شده است
		}

		static public byte[] MainMap = new byte[64];
		static public Dictionary<char, LetterSpec> Letters = new Dictionary<char, LetterSpec>();

		static Constants()
		{
			Letters['ا'] = new LetterSpec { Abjad1 = 1, Abjad2 = 1, Row = 1 };
			Letters['ب'] = new LetterSpec { Abjad1 = 2, Abjad2 = 2, Row = 1 };
			Letters['ج'] = new LetterSpec { Abjad1 = 3, Abjad2 = 3, Row = 1 };
			Letters['د'] = new LetterSpec { Abjad1 = 4, Abjad2 = 4, Row = 1 };
			Letters['ه'] = new LetterSpec { Abjad1 = 5, Abjad2 = 5, Row = 2 };
			Letters['و'] = new LetterSpec { Abjad1 = 6, Abjad2 = 6, Row = 2 };
			Letters['ز'] = new LetterSpec { Abjad1 = 7, Abjad2 = 7, Row = 2 };
			Letters['ح'] = new LetterSpec { Abjad1 = 8, Abjad2 = 8, Row = 2 };
			Letters['ط'] = new LetterSpec { Abjad1 = 9, Abjad2 = 9, Row = 3 };
			Letters['ی'] = new LetterSpec { Abjad1 = 10, Abjad2 = 10, Row = 3 };
			Letters['ک'] = new LetterSpec { Abjad1 = 11, Abjad2 = 20, Row = 3 };
			Letters['ل'] = new LetterSpec { Abjad1 = 12, Abjad2 = 30, Row = 3 };
			Letters['م'] = new LetterSpec { Abjad1 = 13, Abjad2 = 40, Row = 4 };
			Letters['ن'] = new LetterSpec { Abjad1 = 14, Abjad2 = 50, Row = 4 };
			Letters['س'] = new LetterSpec { Abjad1 = 15, Abjad2 = 60, Row = 4 };
			Letters['ع'] = new LetterSpec { Abjad1 = 16, Abjad2 = 70, Row = 4 };
			Letters['ف'] = new LetterSpec { Abjad1 = 17, Abjad2 = 80, Row = 5 };
			Letters['ص'] = new LetterSpec { Abjad1 = 18, Abjad2 = 90, Row = 5 };
			Letters['ق'] = new LetterSpec { Abjad1 = 19, Abjad2 = 100, Row = 5 };
			Letters['ر'] = new LetterSpec { Abjad1 = 20, Abjad2 = 200, Row = 5 };
			Letters['ش'] = new LetterSpec { Abjad1 = 21, Abjad2 = 300, Row = 6 };
			Letters['ت'] = new LetterSpec { Abjad1 = 22, Abjad2 = 400, Row = 6 };
			Letters['ث'] = new LetterSpec { Abjad1 = 23, Abjad2 = 500, Row = 6 };
			Letters['خ'] = new LetterSpec { Abjad1 = 24, Abjad2 = 600, Row = 6 };
			Letters['ذ'] = new LetterSpec { Abjad1 = 25, Abjad2 = 700, Row = 7 };
			Letters['ض'] = new LetterSpec { Abjad1 = 26, Abjad2 = 800, Row = 7 };
			Letters['ظ'] = new LetterSpec { Abjad1 = 27, Abjad2 = 900, Row = 7 };
			Letters['غ'] = new LetterSpec { Abjad1 = 28, Abjad2 = 1000, Row = 7 };

			MainMap[0] = Letters['ف'].Abjad1;
			MainMap[1] = Letters['خ'].Abjad1;
			MainMap[2] = Letters['ف'].Abjad1;
			MainMap[3] = Letters['ا'].Abjad1;
			MainMap[4] = Letters['ا'].Abjad1;
			MainMap[5] = Letters['ه'].Abjad1;
			MainMap[58] = Letters['خ'].Abjad1;
			MainMap[59] = Letters['ه'].Abjad1;
			MainMap[60] = Letters['ه'].Abjad1;
			MainMap[61] = Letters['ا'].Abjad1;
			MainMap[62] = Letters['ه'].Abjad1;
			MainMap[63] = Letters['خ'].Abjad1;
		}

		public static char Abjad1ToLetter(byte abjad1)
		{
			foreach (var letter in Letters)
				if (letter.Value.Abjad1 == abjad1)
					return letter.Key;
			throw new Exception(string.Format("No letter has abjad1 code of {0}", abjad1));
		}
	}
}
