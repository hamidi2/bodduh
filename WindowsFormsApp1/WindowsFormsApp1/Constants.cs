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
		}

		static public byte[] MainMap = new byte[64];
		static public Dictionary<char, LetterSpec> Letters = new Dictionary<char, LetterSpec>();

		static Constants()
		{
			Letters['ا'] = new LetterSpec { Abjad1 = 1, Abjad2 = 1 };
			Letters['ب'] = new LetterSpec { Abjad1 = 2, Abjad2 = 2 };
			Letters['ج'] = new LetterSpec { Abjad1 = 3, Abjad2 = 3 };
			Letters['د'] = new LetterSpec { Abjad1 = 4, Abjad2 = 4 };
			Letters['ه'] = new LetterSpec { Abjad1 = 5, Abjad2 = 5 };
			Letters['و'] = new LetterSpec { Abjad1 = 6, Abjad2 = 6 };
			Letters['ز'] = new LetterSpec { Abjad1 = 7, Abjad2 = 7 };
			Letters['ح'] = new LetterSpec { Abjad1 = 8, Abjad2 = 8 };
			Letters['ط'] = new LetterSpec { Abjad1 = 9, Abjad2 = 9 };
			Letters['ی'] = new LetterSpec { Abjad1 = 10, Abjad2 = 10 };
			Letters['ک'] = new LetterSpec { Abjad1 = 11, Abjad2 = 20 };
			Letters['ل'] = new LetterSpec { Abjad1 = 12, Abjad2 = 30 };
			Letters['م'] = new LetterSpec { Abjad1 = 13, Abjad2 = 40 };
			Letters['ن'] = new LetterSpec { Abjad1 = 14, Abjad2 = 50 };
			Letters['س'] = new LetterSpec { Abjad1 = 15, Abjad2 = 60 };
			Letters['ع'] = new LetterSpec { Abjad1 = 16, Abjad2 = 70 };
			Letters['ف'] = new LetterSpec { Abjad1 = 17, Abjad2 = 80 };
			Letters['ص'] = new LetterSpec { Abjad1 = 18, Abjad2 = 90 };
			Letters['ق'] = new LetterSpec { Abjad1 = 19, Abjad2 = 100 };
			Letters['ر'] = new LetterSpec { Abjad1 = 20, Abjad2 = 200 };
			Letters['ش'] = new LetterSpec { Abjad1 = 21, Abjad2 = 300 };
			Letters['ت'] = new LetterSpec { Abjad1 = 22, Abjad2 = 400 };
			Letters['ث'] = new LetterSpec { Abjad1 = 23, Abjad2 = 500 };
			Letters['خ'] = new LetterSpec { Abjad1 = 24, Abjad2 = 600 };
			Letters['ذ'] = new LetterSpec { Abjad1 = 25, Abjad2 = 700 };
			Letters['ض'] = new LetterSpec { Abjad1 = 26, Abjad2 = 800 };
			Letters['ظ'] = new LetterSpec { Abjad1 = 27, Abjad2 = 900 };
			Letters['غ'] = new LetterSpec { Abjad1 = 28, Abjad2 = 1000 };

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

		static Abjad1(
	}
}
