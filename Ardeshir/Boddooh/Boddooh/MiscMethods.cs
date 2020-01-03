using System;
using System.Collections;
namespace Boddooh
{
	/// <summary>
	/// Summary description for MiscMethods.
	/// </summary>
	public class MiscMethods
	{
		public MiscMethods()
		{			
		}

        public static int IterativelyComputeSummationOfDigits(int i)
        {
            int result = i;
            while (result > 9)
                result = SummationOfDigits(result);
            return result;
        }

        public static int[] FoldAndSummation(int[] Items)
        {
            int Length = Items.Length/2;
            if (Items.Length % 2 ==1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = Items[i] + Items[Items.Length - 1 - i];
            }
            return result;
        }
        public static int[] FoldAndDistance(int[] Items)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);
            }
            return result;
        }
        public static string ToString(int i, int Length)
        {
            string s = i.ToString();
            while (s.Length < Length)
                s = "0" + s;
            return s;
        }
          
        public static int[] FoldAndDistanceIfOddMiddleNoChangeMiddleIsFirst(int[] Items)//ok
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);
            }
            if (Items.Length % 2 == 1)
                result[0] = MiddleElement(Items);
            return result;
        }

        public static int[] FoldAndDistanceOrSummationBasedOnAPattern(int[] Items, int[] PatternArray, int StartingPoint)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                int j = Length - 1 - i;
                int op = PatternArray[(StartingPoint + j) % PatternArray.Length];
                if (op == 0)
                    result[j] = (Items[i] + Items[Items.Length - 1 - i]);
                if (op == 1)
                    result[j] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);

            }
            result = IterativelyComputeSummationOfDigits(result);
            return result;
        }
        public static int[] FoldAndDoPageE1(int[] Items, int[] PatternArray, int StartingPoint)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                if (Items.Length % 2 == 1 && i == 0)
                {
                    result[0] = Items[result.Length-1];
                }
                else
                {
                    int j = Length - 1 - i;
                    int op = PatternArray[(StartingPoint + j) % PatternArray.Length];
                    if (op == 0)
                        result[Length - 1 - i] = (Items[i] + Items[Items.Length - 1 - i]);
                    if (op == 1)
                        result[Length - 1 - i] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);
                }
            }
            result = IterativelyComputeSummationOfDigits(result);
            return result;
        }

        public static string[] TrimAndSplitStringIntoParts(string s, int PartCount)
        {
            s = NormalizeDelimiters(s);

            string[] result = new string[PartCount];
            for (int i = 0; i < PartCount; i++)
            {
                if (s.Length <= FormInputList.PartLength)
                {
                    result[i] = s;
                    s = "";
                }
                else
                {
                    result[i] = s.Substring(0, FormInputList.PartLength);
                    s = s.Substring(FormInputList.PartLength, s.Length - FormInputList.PartLength);
                }
            }
            return result;
        }

        public static int[] FoldAndDoPageE2(int[] Items, int[] PatternArray, int StartingPoint)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                if (Items.Length % 2 == 1 && i == 0)
                {
                    result[0] = Items[result.Length - 1];
                }
                else
                {
                    int j = Length - 1 - i;
                    int op = PatternArray[(StartingPoint + j) % PatternArray.Length];
                    if (op == 0)
                        result[Length - 1 - i] = (Items[i] + Items[Items.Length - 1 - i]);
                    if (op == 1)
                        result[Length - 1 - i] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);
                }
            } 
            return result;
        }

        public static bool HasAPattern(int[] Items, int[] PatternArray)
        {
            for (int StartingPoint = 0; StartingPoint < PatternArray.Length; StartingPoint++)
            {
                bool ok = true;
                for (int i = 0; i < Items.Length; i++)
                {
                    int index = (StartingPoint + i) % PatternArray.Length;
                    int target = PatternArray[index];
                    if (Items[i] != target)
                        ok = false;  
                }
                if (ok)
                    return true;

            }
            return false;
        }

        public static int[] GenerateArrayBasedOnAPattern(int ArrayLength, int[] PatternArray)//ok
        {
            int[] result = new int[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                result[i] = PatternArray[i % PatternArray.Length];
            }
            return result;
        }

        public static int[] GenerateArrayBasedOnAPattern(int ArrayLength, int[] PatternArray, int StartIndex)//ok
        {
            int[] result = new int[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                result[i] = PatternArray[(i + StartIndex) % PatternArray.Length];
            }
            return result;
        }



        public static bool ArraysAreTheSame(int[] Array1, int[] Array2)///ok
        {
            if (Array1.Length != Array2.Length)
                return false;
            for (int i = 0; i < Array1.Length; i++)
            {
                if (Array1[i] != Array2[i])
                    return false;
            }
            return true;
        }
        

        public static int[] PageD1(int[] Items)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = Math.Abs(Items[i] - Items[Items.Length - 1 - i]);
            }
            return result;
        }
        public static int[] FoldAndDifferenceLastMinusFirst(int[] Items)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = (Items[Items.Length - 1 - i] - Items[i]);
            }
            return result;
        }
        public static int[] FoldAndDifferenceFirstMinusLast(int[] Items)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[Length - 1 - i] = (Items[i] - Items[Items.Length - 1 - i]);
            }
            return result;
        }

        public static int JoinItemsAndModN(int[] Items, int N)
        {
            int result = 0;
            int ReminderFactor = 1;
            for (int i = 0; i < Items.Length; i++)
            {
                int NewItem = Items[i];
                int DigitsCount = MiscMethods.DigitsCount(NewItem);
                ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                result = (ReminderFactor * result + NewItem) % N;
            }
            return result;
        }
       

        public static bool IsK28Minus20(int i)
        {
            return (i % 28 == 8);
        }

        public static bool IsK28Plus20(int i)
        {
            return (i % 28 == 20);
        }
        public static bool IsK28(int i)
        {
            return (i % 28 == 0);
        }

        public static int Equivalent1To9(int i)
        {
            int n= (i % 9);
            if (n==0)n=9;
            return n;
        }
        public static int[] Equivalent1To9(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Equivalent1To9(Items[i]);
            }
            return result;
        }
        public static int[] FirstLastSecondPrelastWithoutMiddleInOddCases(int[] Items)
        {
            int ResultLength = Items.Length;
            if (Items.Length%2==1)
                ResultLength = Items.Length - 1;

            int[] result = new int[ResultLength];
            int Side = 1;
            int FSide = 0;
            int LSide = Items.Length - 1;
            for (int i = 0; i < ResultLength; i++)
            {
                if (Side == 1)
                {
                    result[i] = Items[FSide];
                    FSide++;
                }
                if (Side == -1)
                {
                    result[i] = Items[LSide];
                    LSide--;
                }
                Side *= -1;
            }
            return result;
        }

        public static int[] FirstHalf(int[] Items)
        {
            int ResultLength = Items.Length/2;
            int[] result = new int[ResultLength];
            for (int i = 0; i < ResultLength; i++)
            {
                result[i] = Items[i];
            }
            return result;
        }
        public static int[] FirstHalfPlusMiddle(int[] Items)
        {
            int ResultLength = Items.Length / 2;
            if (Items.Length % 2 == 1)
                ResultLength++;
            int[] result = new int[ResultLength];
            for (int i = 0; i < ResultLength; i++)
            {
                result[i] = Items[i];
            }
            return result;
        }
        public static int[] SecondHalf(int[] Items)
        {
            return InverseArray(FirstHalf(InverseArray(Items)));
        }
        public static int[] SecondHalfPlusMiddle(int[] Items)
        {
            return InverseArray(FirstHalfPlusMiddle(InverseArray(Items)));
        }

        public static int[] FirstLastSecondPrelastWithDuplicateMiddleInOddCases(int[] Items)
        {
            int ResultLength = Items.Length;
            if (Items.Length % 2 == 1)
                ResultLength = Items.Length + 1;

            int[] result = new int[ResultLength];
            int Side = 1;
            int FSide = 0;
            int LSide = Items.Length - 1;
            for (int i = 0; i < ResultLength; i++)
            {
                if (Side == 1)
                {
                    result[i] = Items[FSide];
                    FSide++;
                }
                if (Side == -1)
                {
                    result[i] = Items[LSide];
                    LSide--;
                }
                Side *= -1;
            }
            return result;
        }

        public static Elements[] GetElementsArray(int[] Items)
        {
            Elements[] result = new Elements[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Abjad.Element(Items[i]);
            }
            return result;
        }

        public static bool IsEitherK28Plus20OrK28Minus20OrK9Plus2(int i)
        {
            return (IsK28Plus20(i) || IsK28Minus20(i) || IsK9Plus2(i));
        }
        public static bool IsK28Plus20OrK28Minus20(int i)
        {
            return (IsK28Plus20(i) || IsK28Minus20(i));
        }


        public static bool IsK9Plus2(int i)
        {
            return (i % 9 == 2);
        }

        public static bool IsK9Plus8(int i)
        {
            return (i % 9 == 8);
        }
        public static bool SummationOrDistanceIsK28Plus20OrK28Minus20(int i, int j)
        {
            int i1 = i + j;
            int i2 = Math.Abs(i - j);
            return (IsK28Plus20OrK28Minus20(i1) || IsK28Plus20OrK28Minus20(i2));
        }
        public static bool SummationOrDistanceIsEitherK28OrK28Plus20OrK28Minus20(int i, int j)
        {
            int i1 = i + j;
            int i2 = Math.Abs(i - j);
            return (IsK28Plus20OrK28Minus20(i1) || IsK28Plus20OrK28Minus20(i2));
        }

        public static int[] GetArray(int i1, int i2, int i3, int i4)
        {
            int[] result = new int[4]; result[0] = i1; result[1] = i2; result[2] = i3; result[3] = i4;
            return result;
        }

        public static bool SummationOrDistancesMode28AreTheSame(int i1, int i2, int j1, int j2)
        {
            int  si= i1 + i2;
            int di = Math.Abs(i1 - i2);
            int sj = j1 + j2;
            int dj = Math.Abs(j1 - j2);
            return (
                (si % 28 == sj % 28) || (si % 28 == dj % 28) || (di % 28 == sj % 28) || (di % 28 == dj % 28)
                );
        }

        public static bool s1Minuss2Ors2Minuss1Ors1Pluss2PLUSTheSameFortIsK9plus2(int s1, int s2, int t1, int t2)
        {
            int ms1 = s1 - s2;
            int ms2 = s2 - s1;
            int mt1 = t1 - t2;
            int mt2 = t2 - t1;
            int pt = t1 + t2;
            int ps = s1 + s2;
            if (ANumberOrItsEquivalentNumberIsK9Plus2(ms1 + mt1) || ANumberOrItsEquivalentNumberIsK9Plus2(ms1 + mt2) || ANumberOrItsEquivalentNumberIsK9Plus2(ms1 + pt) ||
                ANumberOrItsEquivalentNumberIsK9Plus2(ms2 + mt1) || ANumberOrItsEquivalentNumberIsK9Plus2(ms2 + mt2) || ANumberOrItsEquivalentNumberIsK9Plus2(ms2 + pt) ||
                ANumberOrItsEquivalentNumberIsK9Plus2(ps + mt1) || ANumberOrItsEquivalentNumberIsK9Plus2(ps + mt2) || ANumberOrItsEquivalentNumberIsK9Plus2(ps + pt))
                return true;
            return false;

        }

        public static bool ANumberOrItsEquivalentNumberIsK9Plus2(int i)
        {
            return IsK9Plus2(EquivalentNumber(i)) || IsK9Plus2(i);

        }


        public static string StackToString(Stack stk, int Length, int FirstLetter)
        {
            if (stk.Count==0)
                return "";
            object[] objarray = stk.ToArray();
            int[] Array = new int[3 * objarray.Length];
            
            for (int i = 0; i < stk.Count; i++)
            {
                IntQuadruple IQ = (IntQuadruple)objarray[objarray.Length - 1- i];
                Array[3 * i] = IQ.First; Array[3 * i+1] = IQ.Second; Array[3 * i+2] = IQ.Third;
            }
            ArrayList AL = new ArrayList();
            int ii = 0;
            int Last = 0;
            for (int index = 0; index < Length - 2; index++)
            {
                Last = 0;
                while (ii < Array.Length && Array[ii]==index)
                {
                    int i1 = Array[ii]; int i2 = Array[ii + 1]; int i3 = Array[ii + 2];
                    ii += 3;
                    Last = i2;
                }
                AL.Add(Last);
            }
            

            int[] result = new int[AL.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (int)AL[i];
            }
            return ArrayToCSVString(result);
        }

        //public static Stack StringToStack(string s, int Length, int FirstLetter)
        //{
        //    int LastLetter = FormInputManagment.GetLastLetter(FirstLetter); int MinorAbjadSummation = FormInputManagment.GetMinorAbjadSummation(Length, FirstLetter);
        //    int MiddleLength = Length - 2; int MiddleMinorAbjadSummation = MinorAbjadSummation - (FirstLetter + LastLetter);

        //    int[] items = CSVStringToArray(s);
        //    Stack OptionsStack = new Stack();
        //    if (items.Length==0)
        //        return OptionsStack;
        //    for (int index = 0; index < Length - 2; index++)
        //    {
        //        int last = items[index];
        //        IntQuadruple IQ;
        //        for (int i = 1; i <= last; i++)
        //        {
        //            IQ = new IntQuadruple(index, i, MiddleMinorAbjadSummation - i, -1);
        //            OptionsStack.Push(IQ);
        //        }
        //        MiddleMinorAbjadSummation = MiddleMinorAbjadSummation - last - 1; 
        //    }
          
            
        //    return OptionsStack;
        //}

        public static string ArrayToCSVString(int[] Items)
        {
            if (Items.Length == 0)
                return "";
            string result = Items[0].ToString();
            for (int i = 1; i < Items.Length; i++)
            {
                result += "," + Items[i].ToString();
            }
            return result;
        }

        public static int[] CSVStringToArray(string s)
        {
            ArrayList AL = new ArrayList();
            string ss = RemoveDelimiters(s);
            while (ss.Length > 0)
            {
                int index = ss.IndexOf(",");
                int element;
                if (index == -1)
                {
                    element = Convert.ToInt32(ss);
                    ss = "";
                }
                else
                {
                    element = Convert.ToInt32(ss.Substring(0, index));
                    ss = ss.Substring(index + 1, ss.Length - index - 1);
                }
                AL.Add(element);
            }
            int[] result = new int[AL.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (int) AL[i];
            }
            return result;
        }

        public static bool One8AndOne20(int i1, int i2)
        {
            if (i1 == 8 && i2 == 20)
                return true;
            if (i1 == 20 && i2 == 8)
                return true;
            return false;
        }


        

        public static int GetIndexOf(int[] Items, int x)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == x)
                    return i;
            }
            return -1;
        }

        public static bool SummationOrDistancesAreEquTo20or8(int i1, int i2, int j1, int j2)
        {
            int si = i1 + i2;
            int di = Math.Abs(i1 - i2);
            int sj = j1 + j2;
            int dj = Math.Abs(j1 - j2);
            return (SummationOrDistanceIsK28Plus20OrK28Minus20(si , sj) || SummationOrDistanceIsK28Plus20OrK28Minus20(si , dj) ||
                SummationOrDistanceIsK28Plus20OrK28Minus20(di,sj) || SummationOrDistanceIsK28Plus20OrK28Minus20(di , dj));
        }
        public static bool SummationOrDistanceIsK28PlusXOrK28MinusX(int i, int j, int x)
        {
            int i1 = i + j;
            int i2 = Math.Abs(i - j);
            return ((i1 % 28 == x) || (i1 % 28 == (28 - x)) || (i2 % 28 == x) || (i2 % 28 == (28 - x)));
        }

        public static bool SummationOrDistanceIsK9Plus2(int i, int j)
        {
            int i1 = i + j;
            int i2 = Math.Abs(i - j);
            return (IsK9Plus2(i1) || IsK9Plus2(i2));
        }
        public static bool SummationOrDistanceIsK28(int i, int j)
        {
            int i1 = i + j;
            int i2 = Math.Abs(i - j);
            return (IsK28(i1) || IsK28(i2));
        }

        public static int[] IterativelyComputeSummationOfDigits(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = IterativelyComputeSummationOfDigits(Items[i]);
            }
            return result;
        }

        public static string[] LetterFullNameArray(int[] Items)
        {
            string[] result = new string[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Abjad.LetterFullName(Items[i]);
            }
            return result;
        }
        public static string[] LetterFullNameArray(string Items)
        {
            string[] result = new string[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Abjad.LetterFullName(Abjad.MinorAbjadNumber(Items[i]));
            }
            return result;
        }

        public static int[] StringToMinorAbjadSequence (string s)
        {
            int Length = s.Length;
            int[] QuestionLetters = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                QuestionLetters[i] = Abjad.MinorAbjadNumber(s[i]);
            }
            return QuestionLetters;
        }
        public static byte[] StringToMinorAbjadSequenceByteArray(string s)
        {
            int Length = s.Length;
            byte[] QuestionLetters = new byte[Length];
            for (int i = 0; i < Length; i++)
            {
                QuestionLetters[i] = (byte)Abjad.MinorAbjadNumber(s[i]);
            }
            return QuestionLetters;
        }


        

        public static string JoinStringArrayItems(string[] Items)
        {
            string result = "";
            for (int i = 0; i < Items.Length; i++)
            {
                result += Items[i];
            }
            return result;
        }

        public static int[] ReminderModeN(int[] Items, int N)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Items[i] % N;
            }
            return result;
        }

        public static void Replace(int[] Items, int from, int to)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == from)
                    Items[i] = to;
            }
        }
        public static int[] Distance(int[] ArrayA, int[] ArrayB)
        {
            int[] result = new int[ArrayA.Length];
            try
            {

                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Abs(ArrayA[i] - ArrayB[i]);
                }

            }
            catch 
            {
                throw;
               
            }
            return result;
        }

        //public static int Power(int b, int pow)
        //{
        //    float result = 1;
        //    for (int i = 0; i < pow; i++)
        //    {
        //        result = result * b;
        //    }
        //    return (int)Math.Round(result);
        //}


        public static int[] Difference(int[] ArrayA, int[] ArrayB)
        {
            int[] result = new int[ArrayA.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (ArrayA[i] - ArrayB[i]);
            }
            return result;
        }
        public static int[] Summation(int[] ArrayA, int[] ArrayB)
        {
            int[] result = new int[ArrayA.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (ArrayA[i] + ArrayB[i]);
            }
            return result;
        }
        public static int[] Multiplication(int[] ArrayA, int[] ArrayB)
        {
            int[] result = new int[ArrayA.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (ArrayA[i] * ArrayB[i]);
            }
            return result;
        }
        public static int[] SubArray(int[] Items, int StartIndex, int Length)
        {
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[i] = Items[StartIndex+i];
            }
            return result;
        }
        public static int[] JoinArrays(int[] ArrayA, int[] ArrayB)
        {
            int[] result = new int[ArrayA.Length + ArrayB.Length];
            for (int i = 0; i < ArrayA.Length; i++)
            {
                result[i] = ArrayA[i];
            }
            for (int i = 0; i < ArrayB.Length; i++)
            {
                result[ArrayA.Length + i] = ArrayB[i];
            }
            return result;
        }

        public static int[] EquivalentNumber(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = MiscMethods.EquivalentNumber(Items[i]);
            }
            return result;
        }

        public static int ArrayItemsSummation(int[] Items)
        {
            int result = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                result += Items[i];
            }
            return result;
        }
        public static int MiddleElement(int[] Items)
        {
            return Items[Items.Length / 2];
        }
        

        public static int[] ItemsWithEvenIndices(int[] Items)
        {
            int Length = Items.Length / 2;
            if (Items.Length % 2 == 1)
                Length++;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[i] = Items[2*i];
            }
            return result;
        }
        public static int[] ItemsWithOddIndices(int[] Items)
        {
            int Length = Items.Length / 2;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                result[i] = Items[1 + 2 * i];
            }
            return result;
        }



        public static int ArrayItemsMultiplicationModN(int[] Items, int N)
        {
            int result = Items[0] % N;
            for (int i = 1; i < Items.Length; i++)
            {
                int NewItem = Items[i];
                result = (result * (NewItem % N)) % N;
            }
            return result;
        }

        public static int[] CopySubarrayIntoArray(int[] Items, int[] Subarray, int start)//ok
        {
            int[] result = CopyArray(Items);
            for (int i = 0; i < Subarray.Length; i++)
            {
                result[i + start] = Subarray[i];
            }
            return result;
        }

        public static bool ArrayContainsDuplicateElements(int[] Items)//ok
        {
            for (int i = 1; i < Items.Length; i++) for (int j = 0; j < i; j++)
            {
                if (Items[i] == Items[j])
                    return true;
            }
            return false;
        }

        public static int[] CopyArray(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (Items[i]);
            }
            return result;
        }
        public static byte[] CopyArray(byte[] Items)
        {
            byte[] result = new byte[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (Items[i]);
            }
            return result;
        }
        public static int[] DifferenceOfNeighboringItemsFirstMinusSecond(int[] Items)
        {
            int[] result = new int[Items.Length -1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (Items[i]-Items[i+1]);
            }
            return result;
        }
        public static int[] DistanceOfNeighboringItems(int[] Items)
        {
            int[] result = new int[Items.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Abs(Items[i] - Items[i + 1]);
            }
            return result;
        }
        public static int[] SummationOfNeighboringItems(int[] Items)
        {
            int[] result = new int[Items.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (Items[i] + Items[i + 1]);
            }
            return result;
        }
        public static int[] InverseArray(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[result.Length - 1 - i] = (Items[i]);
            }
            return result;
        }
        public static int[] MajorAbjadArray(int[] Items)
        {
            int[] result = new int[Items.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(Items[i]));
            }
            return result;
        }

		public static string StringInverse(string s)
		{
			string result=string.Empty;
			for (int i=0;i<s.Length;i++)
			{
				result = s[i] + result;				
			}				
			return result;
		}

        public static string PutOneSpaceBetweenAdjacentLetters(string s)
        {
            string t = RemoveDelimiters(s);
            string result = string.Empty;
            if (t.Length > 0)
                result += t[0];
            for (int i = 1; i < t.Length; i++)
            {
                result += (" "+t[i]);
            }
            return result;
        }

		public static int EquivalentNumber(int n)
		{
            int result = n % BoddoohNumbers.TwentyEight;
            while (result <=0) result += BoddoohNumbers.TwentyEight;
            while (result > BoddoohNumbers.TwentyEight) result -= BoddoohNumbers.TwentyEight;			
			return result;
		}



		public static string NormalizeDelimiters(string s)
		{
            s = s.Trim();
			string result=string.Empty;
            bool DelimiterReached = false;
            for (int i=0;i<s.Length;i++)
			{
				char c = s[i];
                if (!char.IsWhiteSpace(c))
                {
                    result += c;
                    DelimiterReached = false;
                }
                else
                {
                    if (!DelimiterReached)
                    {
                        result += c;
                    }
                    DelimiterReached = true;
                }
			}				
			return result;
		}
        public static string RemoveDelimiters(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!char.IsWhiteSpace(c))
                    result += c;
            }
            return result;
        }
        public static string RemoveDots(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c != '.')
                    result += c;
            }
            return result;
        }

		public static string NormalizePersianString(string s)
		{            
			string result=string.Empty;
			result = s;
    		result = result.Replace("ئ","ی");
            result = result.Replace("ي", "ی");

            result = result.Replace("ة", "ه");
            result = result.Replace("ُۀ", "ه");
            result = result.Replace("ؤ", "و");

            result = result.Replace("أ", "ا");
            result = result.Replace("إ", "ا");
            result = result.Replace("آ", "ا");														
			
			return result;
		}

        public static int JoinDigits(int x1, int x2)
        {
            return Convert.ToInt32(Convert.ToString(x1) + Convert.ToString(x2));
        }
        public static decimal JoinDigits(decimal x1, decimal x2)
        {
            return Convert.ToDecimal(Convert.ToString(x1) + Convert.ToString(x2));
        }
        
        public static int JoinDigits(int x1, int x2, int x3)
        {
            return Convert.ToInt32(Convert.ToString(x1) + Convert.ToString(x2) + Convert.ToString(x3));
        }
        public static decimal JoinDigits(decimal x1, decimal x2, decimal x3)
        {
            return Convert.ToDecimal(Convert.ToString(x1) + Convert.ToString(x2) + Convert.ToString(x3));
        }
        public static int JoinDigits(int x1, int x2, int x3, int x4)
		{
            return Convert.ToInt32(Convert.ToString(x1) + Convert.ToString(x2) + Convert.ToString(x3) + Convert.ToString(x4));
		}
        public static decimal JoinDigits(decimal x1, decimal x2, decimal x3, decimal x4)
        {
            return Convert.ToDecimal(Convert.ToString(x1) + Convert.ToString(x2) + Convert.ToString(x3) + Convert.ToString(x4));
        }
        public static int LeftmostDigit(int i)
        {
            int result = 0;
            if (i > 0)
            {
                result = int.Parse(i.ToString().Substring(0, 1));
            }
            return result;
        }

        public static int RightmostDigit(int i)
        {
            i = Math.Abs(i);
            return i % 10;
        }       

        public static int DigitsCount(int i)
        {
            int result = 0;
            result = i.ToString().Length;
            return result;
        }
        public static int DigitsCount(decimal i)
        {
            int result = 0;
            result = i.ToString().Length;
            return result;
        }
        public static int SummationOfDigits(int i)
        {
            i = Math.Abs(i);
            int result = 0;
            while (i > 0)
            {
                result += i % 10;
                i = i / 10;
            }
            return result;
        }
		public static char LeftmostLetter(string s)
		{
			char result= ' ';
			if (s.Length>0)
			{
				result = s[s.Length-1];
			}
			return result;
		}
		public static int TenPowerdN(int n)
		{
			int result=1;
			while (n>0)
			{
				result *= 10;
				n--;
			}
			return result;
		}
        public static int Power(int a, int n)
        {
            int result = 1;
            while (n > 0)
            {
                result *= a;
                n--;
            }
            return result;
        }

        public static int SequentialSearch(int[] Items, int Key)
        {
            int result = -1;
            for (int i = 0; i < Items.Length; i++)
                if (Items[i]==Key)
                    return i;
            return result;
        }

        public static string SetIthCharacterInSToC(string s, int i, char c)
        {
            string result = s.Substring(0,i);
            result += c;
            result += s.Substring(i+1, s.Length - i-1);
            return result;
        }
        public static int GetIthBitInN(long N, int i)
        {
            long T = N;
            int F = Power(2, i);
            T = T / F;
            return (int)(T % 2);
        }
        public static string GetBinaryString(long N)
        {
            string result = "";
            while (N > 0)
            {
                int d= (int)(N % 2);
                if (d==0)
                    result = "0" + result;
                else
                    result = "1" + result;
                N = N / 2;
            }
            return result;
        }
        public static int GetOnesCount(long N)
        {
            int result = 0;
            while (N > 0)
            {
                int d = (int)(N % 2);
                if (d == 1)
                    result++;
                N = N / 2;
            }
            return result;
        }
        public static long SetIthBitInNToB(long N, int i, bool bb)
        {
            int b = 0;
            if (bb)
                b = 1;
            long T = N;
            int F = Power(2, i);
            long R = T % F;
            T = T / F;
            if (b == 0 && (T % 2) == 1)
                T--;
            if (b == 1 && (T % 2) == 0)
                T++;
            T = T * F + R;            
            return T;
        }
        public static decimal JoinItems(int[] Items)
        {
            decimal result = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                int NewItem = Items[i];
                int DC = MiscMethods.DigitsCount(NewItem);
                int F = MiscMethods.TenPowerdN(DC);
                result = result * F + NewItem;
            }
            return result;
        }
        public static string OrderString(int n)
        {
            string s = "";
            if (n == 1) s = "اول"; if (n == 2) s = "دوم"; if (n == 3) s = "سوم";
            if (n == 4) s = "چهارم"; if (n == 5) s = "پنجم"; if (n == 6) s = "ششم";
            if (n == 7) s = "هفتم"; if (n == 8) s = "هشتم"; if (n == 9) s = "نهم";
            return s;
        }
	}

    public class AnswerArrayAndTagTuple
    {
         public int[] AnswerArray;
         public long Tag;
         public AnswerArrayAndTagTuple(int[] answerArray, long tag)
         {
             AnswerArray = answerArray;
             Tag = tag;
         }
    }
     

    public class Counter
    {
        public int VariablesCount;
        public int[] MinValues;
        public int[] MaxValues;
        public int[] CurrentValues;
        public bool Done;
        public Counter(int variablesCount, int Min, int Max)
        {
            VariablesCount = variablesCount;
            MinValues = new int[VariablesCount];
            MaxValues = new int[VariablesCount];
            CurrentValues = new int[VariablesCount];
            for (int i = 0; i < VariablesCount; i++)
            {
                MinValues[i] = Min;
                MaxValues[i] = Max;
            }
        }

        public Counter(int variablesCount, int[] minValues, int[] maxValues)
        {
            VariablesCount = variablesCount;
            MinValues = new int[VariablesCount];
            MaxValues = new int[VariablesCount];
            CurrentValues = new int[VariablesCount];
            for (int i = 0; i < VariablesCount; i++)
            {
                MinValues[i] = minValues[i];
                MaxValues[i] = maxValues[i];
            }
        }
        public Counter(int variablesCount, int Min, int[] maxValues)
        {
            VariablesCount = variablesCount;
            MinValues = new int[VariablesCount];
            MaxValues = new int[VariablesCount];
            CurrentValues = new int[VariablesCount];
            for (int i = 0; i < VariablesCount; i++)
            {
                MinValues[i] = Min;
                MaxValues[i] = maxValues[i];
            }
        }

        public void Restart()
        {
            Done = false;
            CurrentValues = new int[VariablesCount];
            for (int i = 0; i < VariablesCount; i++)
            {
                CurrentValues[i] = MinValues[i];
            }
        }
        public void Next()
        {            
            int i = 0;
            while (i < VariablesCount && CurrentValues[i] == MaxValues[i])
            {
                CurrentValues[i] = MinValues[i];
                i++;
            }
            if (i == VariablesCount)
                Done = true;
            else
                CurrentValues[i]++;

        }
    }


    public class IntegerSolutionVectorsGenerator
    {
        public int VariablesCount;
        public int[] CurrentValues;
        public bool Done;
        public int Summation;
        Stack OptionsStack;
        public IntegerSolutionVectorsGenerator(int variablesCount, int summation)
        {
            VariablesCount = variablesCount;
            CurrentValues = new int[VariablesCount];
            Summation = summation;
        }

        public void Restart()
        {
            Done = false;
            OptionsStack = new Stack();
            CurrentValues = new int[VariablesCount];
            for (int i = 1; i <= 28; i++)
            {                
                IntQuadruple IQ = new IntQuadruple(0, i, Summation-i, -1);
                OptionsStack.Push(IQ);
            }
        }
        public void Next()
        {
            while (OptionsStack.Count > 0)
            {
                IntQuadruple IQ = (IntQuadruple)OptionsStack.Pop();
                int index = IQ.First; int option = IQ.Second; int RemainingSummation = IQ.Third;
                CurrentValues[index] = option;
                if (index == VariablesCount - 1)
                {

                }
                else
                {
                    index++;
                    int RemainingLength = VariablesCount - 1 - index;
                    int MinPossible = RemainingSummation - RemainingLength * 28;
                    int MaxPossible = RemainingSummation - RemainingLength;
                    for (int i = 1; i <= 28; i++)
                        if (MinPossible <= i && i<= MaxPossible)
                            {
                                IQ = new IntQuadruple(index, i, RemainingSummation - i, -1);
                                OptionsStack.Push(IQ);
                            }                    
                }

            }

        }
    }


    public class FSM11222211
    {
        public int[,] TransitionMatrix;
        public int CurrentState;
        public bool InTrap;
        public FSM11222211()
        {
            int StatesCount = 15;
            int AlphabetsCount = 2;
            TransitionMatrix = new int[StatesCount, AlphabetsCount];
            for (int i = 0; i < StatesCount; i++)
                for (int j = 0; j < AlphabetsCount; j++)
                {
                    TransitionMatrix[i, j] = -1;
                }
            TransitionMatrix[0, 0] = 1; TransitionMatrix[1, 0] = 2; TransitionMatrix[2, 0] = 3; TransitionMatrix[3, 0] = 4;
            TransitionMatrix[0, 1] = 5; TransitionMatrix[5, 1] = 6; TransitionMatrix[6, 1] = 7; TransitionMatrix[7, 1] = 8;

            TransitionMatrix[4, 1] = 12; TransitionMatrix[12, 1] = 13; TransitionMatrix[13, 1] = 14; TransitionMatrix[14, 1] = 8;
            TransitionMatrix[8, 0] = 9; TransitionMatrix[9, 0] = 10; TransitionMatrix[10, 0] = 11; TransitionMatrix[11, 0] = 4;

            TransitionMatrix[5, 0] = 9; TransitionMatrix[6, 0] = 9; TransitionMatrix[7, 0] = 9;

            TransitionMatrix[1, 1] = 12; TransitionMatrix[2, 1] = 12; TransitionMatrix[3, 1] = 12; 
        }
        public void Start()
        {
            CurrentState = 0;
            InTrap = false;

        }

        public void Read(int a)
        {
            int NewState = 0;
            if (a == 1)
                NewState = TransitionMatrix[CurrentState, 0];
            if (a == 2)
                NewState = TransitionMatrix[CurrentState, 1];
            if (NewState == -1)
                InTrap = true;
            else
                CurrentState = NewState;
        }

        public static bool Accepts(int[] Items)
        {
            FSM11222211 FSM = new FSM11222211();
            FSM.Start();
            for (int i = 0; i < Items.Length; i++)
            {
                FSM.Read(Items[i]);
                if (FSM.InTrap)
                    return false;
            }
            return true;
        }
    }

}
