using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Boddooh
{

    public class IntPentuple
    {
        public  int First ;
        public  int Second;
        public  int Third ;
        public  int Forth ;
        public  int Fifth ;

        public IntPentuple(int first, int second, int third, int forth, int fifth)
        {
            First = first; Second = second; Third = third; Forth = forth; Fifth = fifth;
        }
    }

	public class BoddoohNumbers
	{
        public static int One = 1;
        public static int Two = 2;
        public static int Four = 4;
		public static int Six = 6;
		public static int Seven = 7;
        public static int Eight = 8;
		public static int Nine = 9;
		public static int Ten = 10;
		public static int Eleven = 11;		
		public static int Twelve = 12;
		public static int Fourteen = 14;
		public static int TwentyFour = 24;
		public static int TwentyEight = 28;
        public static int ThirtyTwo = 32;
		public static int TwoHundredAndTen = 210;
	}

    public class Boddooh
    {
        public static bool DEBUG = true;

        public static int MinorAbjadSummationForTheQuestion;
        public static int MajorAbjadSummationForTheQuestion;
        public static int MinorAbjadSummationForTheAnswer;
        public static int MajorAbjadSummationForTheAnswer;
        

        public static ArrayList AnswersList= new ArrayList();
        

        public static bool dbg = false;
        public static string Question = string.Empty;
//        public static string Answer = string.Empty;

        public static string LetterSequence = string.Empty;
        public static int[] GivenLetters;
        public static List<int[]> GivenLettersForComputingThreads;
        public static string LetterSequenceWithDots = string.Empty;
        public static string QuestionString = string.Empty;
        public static string QuestionStringWithDots = string.Empty;
        


        public static Elements[] OutputLettersElements;
        public static Elements[] UpperHalfBaseChain;
        public static Elements[] LowerHalfBaseChain;
        public static int[] OneTwoEightPattern1;
        public static int[] OneTwoEightPattern2;
        public static int[] OneTwoEightPattern3;

        public static void ComputeCountAndSummationOfLetters(int[] Letters, ref int[] Count, ref int[] Summation)
        {
            Count = new int[4];
            Summation = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Count[i] = 0;
                Summation[i] = 0;
            }
            for (int i = 0; i < Letters.Length; i++)
            {
                int Letter = MiscMethods.EquivalentNumber(Letters[i]);
                int Index = Abjad.ElementalFactor(Letter) / 2 - 1;
                Count[Index]++;
                Summation[Index] += (Letter);
            }            
        }

        public static int ComputeSummationOfLettersWRTElementalFactors(int[] Letters)
        {
            int [] Count = new int[4];
            for (int i = 0; i < 4; i++)
                Count[i] = 0;
            for (int i = 0; i < Letters.Length; i++)
            {
                int Letter = MiscMethods.EquivalentNumber(Letters[i]);
                int Index = Abjad.ElementalFactor(Letter) / 2 - 1;
                Count[Index]++;
            }            

            int result = 0;
            for (int i = 0; i < 4; i++)
                result += (Abjad.ElementalFactor(i+1)*Count[i]);

            return result;
        }

        public static void InitializeBaseChains()
        {
            Boddooh.UpperHalfBaseChain = new Elements[BoddoohNumbers.ThirtyTwo];
            UpperHalfBaseChain[0] = Elements.Fire;
            UpperHalfBaseChain[1] = Elements.Earth;
            UpperHalfBaseChain[2] = Elements.Fire;
            UpperHalfBaseChain[3] = Elements.Water;
            UpperHalfBaseChain[4] = Elements.Water;
            UpperHalfBaseChain[5] = Elements.Air;
            UpperHalfBaseChain[6] = Elements.Water;
            UpperHalfBaseChain[7] = Elements.Fire;

            UpperHalfBaseChain[8] = Elements.Air;
            UpperHalfBaseChain[9] = Elements.Fire;
            UpperHalfBaseChain[10] = Elements.Air;
            UpperHalfBaseChain[11] = Elements.Earth;
            UpperHalfBaseChain[12] = Elements.Earth;
            UpperHalfBaseChain[13] = Elements.Water;
            UpperHalfBaseChain[14] = Elements.Earth;
            UpperHalfBaseChain[15] = Elements.Air;

            UpperHalfBaseChain[16] = Elements.Water;
            UpperHalfBaseChain[17] = Elements.Air;
            UpperHalfBaseChain[18] = Elements.Water;
            UpperHalfBaseChain[19] = Elements.Fire;
            UpperHalfBaseChain[20] = Elements.Fire;
            UpperHalfBaseChain[21] = Elements.Earth;
            UpperHalfBaseChain[22] = Elements.Fire;
            UpperHalfBaseChain[23] = Elements.Water;

            UpperHalfBaseChain[24] = Elements.Earth;
            UpperHalfBaseChain[25] = Elements.Water;
            UpperHalfBaseChain[26] = Elements.Earth;
            UpperHalfBaseChain[27] = Elements.Air;
            UpperHalfBaseChain[28] = Elements.Air;
            UpperHalfBaseChain[29] = Elements.Fire;
            UpperHalfBaseChain[30] = Elements.Air;
            UpperHalfBaseChain[31] = Elements.Earth;

            Boddooh.LowerHalfBaseChain = new Elements[BoddoohNumbers.ThirtyTwo];
            LowerHalfBaseChain[0] = Elements.Earth;
            LowerHalfBaseChain[1] = Elements.Air;
            LowerHalfBaseChain[2] = Elements.Water;
            LowerHalfBaseChain[3] = Elements.Air;
            LowerHalfBaseChain[4] = Elements.Air;
            LowerHalfBaseChain[5] = Elements.Earth;
            LowerHalfBaseChain[6] = Elements.Fire;
            LowerHalfBaseChain[7] = Elements.Earth;

            LowerHalfBaseChain[8] = Elements.Fire;
            LowerHalfBaseChain[9] = Elements.Water;
            LowerHalfBaseChain[10] = Elements.Earth;
            LowerHalfBaseChain[11] = Elements.Water;
            LowerHalfBaseChain[12] = Elements.Water;
            LowerHalfBaseChain[13] = Elements.Fire;
            LowerHalfBaseChain[14] = Elements.Air;
            LowerHalfBaseChain[15] = Elements.Fire;

            LowerHalfBaseChain[16] = Elements.Air;
            LowerHalfBaseChain[17] = Elements.Earth;
            LowerHalfBaseChain[18] = Elements.Fire;
            LowerHalfBaseChain[19] = Elements.Earth;
            LowerHalfBaseChain[20] = Elements.Earth;
            LowerHalfBaseChain[21] = Elements.Air;
            LowerHalfBaseChain[22] = Elements.Water;
            LowerHalfBaseChain[23] = Elements.Air;

            LowerHalfBaseChain[24] = Elements.Water;
            LowerHalfBaseChain[25] = Elements.Fire;
            LowerHalfBaseChain[26] = Elements.Air;
            LowerHalfBaseChain[27] = Elements.Fire;
            LowerHalfBaseChain[28] = Elements.Fire;
            LowerHalfBaseChain[29] = Elements.Water;
            LowerHalfBaseChain[30] = Elements.Earth;
            LowerHalfBaseChain[31] = Elements.Water;
        }
        public static void InitializeOneTwoEightPattern()
        {
            Boddooh.OneTwoEightPattern1 = new int[1000];
            //Boddooh.OneTwoEightPattern2 = new int[15];
            //Boddooh.OneTwoEightPattern3 = new int[15];
            OneTwoEightPattern1[0] = BoddoohNumbers.One;
            OneTwoEightPattern1[1] = BoddoohNumbers.Two;
            OneTwoEightPattern1[2] = BoddoohNumbers.Eight;
            OneTwoEightPattern1[3] = BoddoohNumbers.Eight;
            OneTwoEightPattern1[4] = BoddoohNumbers.One;
            OneTwoEightPattern1[5] = BoddoohNumbers.Two;
            OneTwoEightPattern1[6] = BoddoohNumbers.Two;
            OneTwoEightPattern1[7] = BoddoohNumbers.Eight;
            OneTwoEightPattern1[8] = BoddoohNumbers.One;
            for (int i = 9; i < OneTwoEightPattern1.Length; i++)
            {
                OneTwoEightPattern1[i] = OneTwoEightPattern1[i%9];
            }
            
            //OneTwoEightPattern2[9] = BoddoohNumbers.Two;
            //OneTwoEightPattern2[10] = BoddoohNumbers.Eight;
            //OneTwoEightPattern2[11] = BoddoohNumbers.One;
            //OneTwoEightPattern2[12] = BoddoohNumbers.One;
            //OneTwoEightPattern2[13] = BoddoohNumbers.Two;
            //OneTwoEightPattern2[14] = BoddoohNumbers.Eight;

            //OneTwoEightPattern3[9] = BoddoohNumbers.Eight;
            //OneTwoEightPattern3[10] = BoddoohNumbers.Two;
            //OneTwoEightPattern3[11] = BoddoohNumbers.One;
            //OneTwoEightPattern3[12] = BoddoohNumbers.One;
            //OneTwoEightPattern3[13] = BoddoohNumbers.Eight;
            //OneTwoEightPattern3[14] = BoddoohNumbers.Two;

        }
        public static void InitializeBaseChainsAndOneTwoEightPattern()
        {
            InitializeBaseChains();
            InitializeOneTwoEightPattern();
        }

        public static void Initialize()
        {
            InitializeBaseChains();
            InitializeBaseChainsAndOneTwoEightPattern();
        }



        public static string OmitDuplicateLetters(string s, bool FromBothSidesToMiddle)
        {
            string ss = MiscMethods.RemoveDelimiters(s);
            if (FromBothSidesToMiddle)
                return OmitDuplicateLettersFromBothSidesToMiddle(ss);
            else
                return OmitDuplicateLettersFromRightToLeft(ss);
        }

        public static string OmitDuplicateLettersFromBothSidesToMiddle(string s)
        {
            int l = s.Length-1;
            int r = 0;
            string right = string.Empty;
            string left = string.Empty;
            string result = string.Empty;
            bool RightToLeft = true;
            while (l >= r)
            {
                if (RightToLeft)
                {
                    if (s[r] == '*' || (right.IndexOf(s[r]) < 0 && left.IndexOf(s[r]) < 0))
                        right = right +  s[r];
                    r++;

                }
                else
                {
                    if (s[l] == '*' || (right.IndexOf(s[l]) < 0 && left.IndexOf(s[l]) < 0))
                        left = s[l] + left;
                    l--;
                }
                RightToLeft = !RightToLeft;
            }
            result = right + left;
            return result;
        }
        public static string OmitDuplicateLettersFromRightToLeft(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*' || result.IndexOf(s[i]) < 0)
                    result += s[i];

            }
            return result;
        }
        
        public enum Errors
        {
            NoInput,
            InputTextContainsNonAlphabetCharacters,
            InputTextContainsNonAbjabAlphabetCharacters,
            None
        }
        public static string RecommendedErrorMessage(Errors error)
        {
            string result = string.Empty;
            if (error == Errors.NoInput)
            {
                result = "لطفا ورودي برنامه را وارد کنيد";
            }
            if (error == Errors.InputTextContainsNonAlphabetCharacters)
            {
                result = "متن ورودی نمی تواند شامل کاراکترهای غیر الفبایی باشد";
            }
            if (error == Errors.InputTextContainsNonAbjabAlphabetCharacters)
            {
                result = "متن ورودی نمی تواند شامل کاراکترهای پ، چ، ژ و یا گ باشد";
            }           
            return result;
        }
        public static void ShowRecommendedErrorMessage(Errors error)
        {
            string ErrorMessageString = RecommendedErrorMessage(error);
            MessageBox.Show(ErrorMessageString, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }
        
       
        
        
        public static bool CheckInput(ref Errors error)
        {
            bool result = true;
            error = Errors.None;

            LetterSequenceWithDots = MiscMethods.RemoveDelimiters(Question);
            LetterSequence = MiscMethods.RemoveDots(LetterSequenceWithDots);

            if (LetterSequence.Length == 0)
            {
                error = Errors.NoInput;
                return false;
            }
            if (Abjad.ContainsNonAlphabet(LetterSequence))
            {
                error = Errors.InputTextContainsNonAlphabetCharacters;
                return false;
            }
            if (Abjad.ContainsNonAbjabAlphabet(LetterSequence))
            {
                error = Errors.InputTextContainsNonAbjabAlphabetCharacters;
                return false;
            }

            return result;
        }

        public static int Next(int index, int StartIndex, int UpperHalfBaseChainLength, bool TBtoM, bool Modular, ref bool DirectionInc)
        {
            int temp ;
            if (index==StartIndex)
            {
                if (DirectionInc == TBtoM)
                {
                    if (DirectionInc)
                        temp = (index + 1) % UpperHalfBaseChainLength;
                    else
                        temp = (index + UpperHalfBaseChainLength - 1) % UpperHalfBaseChainLength;
                    return temp;
                }
                else
                {
                    temp = index;
                    DirectionInc = !DirectionInc;
                    return temp;
                }
            }
            if (DirectionInc)
            {
                 temp = (index + 1) % UpperHalfBaseChainLength;
            }
            else
            {
                temp = (index + UpperHalfBaseChainLength - 1) % UpperHalfBaseChainLength;
            }
            if (temp == StartIndex)
            {
                if (DirectionInc == TBtoM)
                {
                    if (!Modular)
                    {
                        temp = index;
                        DirectionInc = !DirectionInc;
                        return temp;
                    }
                }
                else
                {
                    DirectionInc = !DirectionInc;
                    return temp;
                }
            }
            return temp;
        }

        public static Elements[] GenerateOutputLettersElements(int a1, int a2, int Length, bool TBtoM , bool Modular, bool MelementFromT)
        {
            Elements[] Result = new Elements[Length];
            Elements e1 = Abjad.Element(a1);
            Elements e2 = Abjad.Element(a2);
            int StartIndex ;
            if (TBtoM)
            {
                StartIndex = 0;
                while (UpperHalfBaseChain[StartIndex] != e1 || UpperHalfBaseChain[StartIndex + 1] != e2)
                    StartIndex++;
            }
            else
            {
                StartIndex = UpperHalfBaseChain.Length-1;
                while (UpperHalfBaseChain[StartIndex] != e1 || UpperHalfBaseChain[StartIndex - 1] != e2)
                    StartIndex--;
            }

            int UpperHalfLength = Length / 2;
            bool DirectionInc = TBtoM;

            int i = 0;
            int index = StartIndex;
            while (i < UpperHalfLength)
            {
                Result[i] = UpperHalfBaseChain[index];
                Result[Result.Length - 1 - i] = LowerHalfBaseChain[index];
                i++;
                index = Next(index, StartIndex, LowerHalfBaseChain.Length, TBtoM, Modular, ref DirectionInc);
            }
           
            if (Length % 2 == 1)
            {
                if (MelementFromT)
                    Result[Length / 2] = UpperHalfBaseChain[index];
                else
                    Result[Length / 2] = LowerHalfBaseChain[index];
            }
            return Result;

        }


        public static bool IsASpecialAnswer(byte[] AnswerLetters)
        {
            decimal Sum = AnswerLetters[0] % BoddoohNumbers.Nine; //decimal Join = AnswerLetters[0] % BoddoohNumbers.Nine;
            int ReminderFactor = 1;
            int SumMod28 = ((AnswerLetters[0] % BoddoohNumbers.Nine) * ReminderFactor) % BoddoohNumbers.TwentyEight;
            for (int i = 1; i < AnswerLetters.Length; i++)
            {
                ReminderFactor = (ReminderFactor * 10) % BoddoohNumbers.TwentyEight;
                int ThisDigitMod28 = ((AnswerLetters[i] % BoddoohNumbers.Nine) * ReminderFactor) % BoddoohNumbers.TwentyEight;
                SumMod28 = (SumMod28 + ThisDigitMod28) % BoddoohNumbers.TwentyEight;
                Sum += (AnswerLetters[i] % BoddoohNumbers.Nine);
                //Join = MiscMethods.JoinDigits(AnswerLetters[i] % BoddoohNumbers.Nine, Join);
            }
            SumMod28 += 280;
            decimal Temp = Sum + SumMod28;
            if (Temp % BoddoohNumbers.TwentyEight != 0 && Temp % BoddoohNumbers.TwentyEight != 20 && Temp % BoddoohNumbers.TwentyEight != 8)
                return false;
            Temp = Math.Abs(Sum - SumMod28);
                if (Temp % BoddoohNumbers.TwentyEight != 0 && Temp % BoddoohNumbers.TwentyEight != 20 && Temp % BoddoohNumbers.TwentyEight != 8)
                    return false;
                return true;
        }




        public static int FindMinorAbjadSummationForTheAnswer(int minorAbjadSummationForTheQuestion, Elements[] answerElements)

        {
            int Temp = 0;
            for (int i = 0; i < answerElements.Length; i++)
            {
                if (answerElements[i] == Elements.Fire) { Temp += 1;  }
                if (answerElements[i] == Elements.Air) { Temp += 2;  }
                if (answerElements[i] == Elements.Water) { Temp += 3; }
                if (answerElements[i] == Elements.Earth) { Temp += 4;  }
            }
            Temp = Temp % 4;

            for (int i = 0; i < BoddoohNumbers.Four; i++)
            {
                int t = minorAbjadSummationForTheQuestion - i;
                if ( t % BoddoohNumbers.Four == Temp) 
                    return t;
                t = minorAbjadSummationForTheQuestion + i;
                if (t % BoddoohNumbers.Four == Temp) 
                    return t;
            }          
            return 0;            
        }

        //public static bool ItIsPossibleDueToMinorAndMajorAbjadSummations(Elements[] answerElements, int[] answerLetters, int l, int r)
        //{
        //    bool PossibleDueToMajorAbjadSummation = ItIsPossibleDueToMinorAbjadSummation(answerElements, answerLetters, l, r);
        //    if (!PossibleDueToMajorAbjadSummation)
        //        return false;

        //    bool PossibleDueToMinorAbjadSummation = ItIsPossibleDueToMajorAbjadSummation(answerElements, answerLetters, l, r);
        //    if (!PossibleDueToMinorAbjadSummation)
        //        return false;
        //    return true;
        //}

        //public static bool ItIsPossibleDueToMinorAbjadSummation(Elements[] answerElements, int[] answerLetters, int l, int r)
        //{
        //    int MinSum = Abjad.MinorAbjadSummation(answerLetters, 0, r-1);
        //    MinSum += Abjad.MinorAbjadSummation(answerLetters, l + 1, answerLetters.Length - 1);
        //    int MaxSum = MinSum;            
        //    for (int i = r; i <= l; i++)
        //    {
        //        if (answerElements[i] == Elements.Fire) { MinSum += 1; MaxSum += 25; }
        //        if (answerElements[i] == Elements.Air) { MinSum += 2; MaxSum += 26; }
        //        if (answerElements[i] == Elements.Water) { MinSum += 3; MaxSum += 27; }
        //        if (answerElements[i] == Elements.Earth) { MinSum += 4; MaxSum += 28; }
               
        //    }
        //    if (MinSum <= MinorAbjadSummationForTheAnswer && MinorAbjadSummationForTheAnswer <= MaxSum)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool ItIsPossibleDueToMajorAbjadSummation(Elements[] answerElements, int[] answerLetters, int l, int r)
        //{
        //    int MinSum = Abjad.MajorAbjadSummation(answerLetters, 0, r - 1);
        //    MinSum += Abjad.MajorAbjadSummation(answerLetters, l + 1, answerLetters.Length - 1);
        //    int MaxSum = MinSum;
        //    for (int i = r; i <= l; i++)
        //    {
        //        if (answerElements[i] == Elements.Fire) { MinSum += 1; MaxSum += 700; }
        //        if (answerElements[i] == Elements.Air) { MinSum += 2; MaxSum += 800; }
        //        if (answerElements[i] == Elements.Water) { MinSum += 3; MaxSum += 900; }
        //        if (answerElements[i] == Elements.Earth) { MinSum += 4; MaxSum += 1000; }

        //    }
        //    if (MinSum <= MajorAbjadSummationForTheAnswer && MajorAbjadSummationForTheAnswer <= MaxSum)
        //        return true;
        //    else
        //        return false;
        //}


        //public static ArrayList FindMajorAbjadSummationForTheAnswer(int minorAbjadSummationForTheQuestion, int majorAbjadSummationForTheQuestion,
        //                                                         int minorAbjadSummationForTheAnswer, Elements[] AnswerElements)
        //{
        //    int Length = AnswerElements.Length;
        //    int[] Temp = new int[Length];
            
        //    // Find Min For Major Abjad Summation
        //    int average = (int)Math.Round(Math.Ceiling((double)minorAbjadSummationForTheAnswer / (double)Length));
        //    int t = average * Length - minorAbjadSummationForTheAnswer;
        //    for (int i = 0; i < Length; i++)
        //        Temp[i] = average;

        //    int j = Length - 1;
        //    while (t>0)
        //    {
        //        while (t>0 && Temp[j]>1)
        //        {
        //            Temp[j]--;
        //            t--;
        //        }
        //        j--;
        //    }
        //    int Min = 0;
        //    for (int i = 0; i < Length; i++)
        //        Min+= Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(Temp[i]));

        //    // Find Max For Major Abjad Summation

        //    for (int i = 0; i < Length; i++)
        //        Temp[i] = 0;
        //    int S = 0;
        //    for (int i = Length-1; i >=0; i--)
        //    {
        //        if (AnswerElements[i] == Elements.Fire) {Temp[i] = S + 1; S = Temp[i];}
        //        if (AnswerElements[i] == Elements.Air) {Temp[i] = S + 2; S = Temp[i];}
        //        if (AnswerElements[i] == Elements.Water) {Temp[i] = S + 3; S = Temp[i];}
        //        if (AnswerElements[i] == Elements.Earth) {Temp[i] = S + 4; S = Temp[i]; }
        //    }

        //    S = minorAbjadSummationForTheAnswer;
        //    int index = 0;
        //    bool FirstPhaseDone = false;
        //    while (!FirstPhaseDone)
        //    {
        //        bool done = false;
        //        for (int k = BoddoohNumbers.TwentyEight; k >= 1 && !done; k--)
        //            if (k <= S)
        //            {
        //                if (Abjad.Element(k) == AnswerElements[index])
        //                {
        //                    if (Temp[index + 1] + k <= S)
        //                    {
        //                        Temp[index] = k;
        //                        S -= k;
        //                        done = true;
        //                    }
        //                    else
        //                    {
        //                        Temp[index] = S - Temp[index + 1];
        //                        S -= Temp[index];
        //                        FirstPhaseDone = true;
        //                        done = true;
        //                    }
        //                }
        //            }
        //        index++;
        //    }
        //    for (int i = index; i < Length; i++)
        //    {
        //        if (AnswerElements[i] == Elements.Fire)
        //            Temp[i] = 1;
        //        if (AnswerElements[i] == Elements.Air)
        //            Temp[i] = 2;
        //        if (AnswerElements[i] == Elements.Water)
        //            Temp[i] = 3;
        //        if (AnswerElements[i] == Elements.Earth)
        //            Temp[i] = 4;
        //    }

        //    int Max = 0;
        //    for (int i = 0; i < Length; i++)
        //        Max += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(Temp[i]));

        //    // Find Major Abjad Summation
        //    //Min = 0;
        //    //Max = 9999999
        //    int MaxCount = 0;
        //    int BestOne = 0;
        //    for (int q=Min;q<=Max;q++)
        //    {
        //        int Count = CountMetConditionsForMajorAbjadSummationForTheAnswer(q, minorAbjadSummationForTheQuestion, 
        //            majorAbjadSummationForTheQuestion,  minorAbjadSummationForTheAnswer);

        //        if (Count > MaxCount)
        //        {
        //            MaxCount = Count;
        //            BestOne = q;
        //        }
        //    }

        //    //int C = 0;
        //    ArrayList result = new ArrayList();
        //    for (int q = Min; q <= Max; q++)
        //    {
        //        int Count = CountMetConditionsForMajorAbjadSummationForTheAnswer(q, minorAbjadSummationForTheQuestion,
        //            majorAbjadSummationForTheQuestion, minorAbjadSummationForTheAnswer);
        //        if (Count == MaxCount)
        //        {
        //            ///C++;
        //            result.Add(q);
        //        }
        //    }

        //   // MessageBox.Show(C.ToString());
        //    return result;
        //}

        //public static int CountMetConditionsForMajorAbjadSummationForTheAnswer(int q, int minorAbjadSummationForTheQuestion, 
        //    int majorAbjadSummationForTheQuestion, int minorAbjadSummationForTheAnswer)
        //{
        //    int Count = 0;
        //    int o = q + majorAbjadSummationForTheQuestion;
        //    int n = o % minorAbjadSummationForTheAnswer;
        //    bool condition1 = (n % BoddoohNumbers.Nine == 2 || n % BoddoohNumbers.Nine == 8);
        //    if (condition1)
        //        Count++;

        //    int MinorAbjadSummationForQuestionAndAnswer = minorAbjadSummationForTheQuestion + minorAbjadSummationForTheAnswer;
        //    int l = o % MinorAbjadSummationForQuestionAndAnswer;
        //    int k = l + n;
        //    int jj = 2 * k;
        //    int h = jj - minorAbjadSummationForTheAnswer;
        //    bool condition2 = (h % BoddoohNumbers.Nine == 2 || h % BoddoohNumbers.Nine == 8);
        //    if (condition2)
        //        Count++;

        //    int g = 2 * n;
        //    int f = g % BoddoohNumbers.TwentyEight;
        //    bool condition3 = ((f == 20) || (f == 8) || (f == 2) || (f == 26) || (f % BoddoohNumbers.Nine == 2 || f % BoddoohNumbers.Nine == 8));
        //    if (condition3)
        //        Count++;

        //    int e = Math.Abs(majorAbjadSummationForTheQuestion - q);
        //    int d = e % BoddoohNumbers.TwentyEight;
        //    bool condition4 = ((d == 20) || (d == 8) || (d == 2) || (d == 26) || (d % BoddoohNumbers.Nine == 2 || d % BoddoohNumbers.Nine == 8));
        //    if (condition4)
        //        Count++;

        //    int b = e * MinorAbjadSummationForQuestionAndAnswer;
        //    int a = b % BoddoohNumbers.TwentyEight;
        //    bool condition5 = ((b == 20) || (b == 8) || (b == 2) || (b == 26) || (b % BoddoohNumbers.Nine == 2 || b % BoddoohNumbers.Nine == 8));
        //    if (condition5)
        //        Count++;

        //    return Count;
        //}

        public static bool GetsSecondaryRank(int x)
        {
            int y = x % BoddoohNumbers.TwentyEight;
            if (y == 0 || y == 20 || y == 8  || y % BoddoohNumbers.Nine == 2 || x % BoddoohNumbers.Nine == 8)
                return true;
            return false;
        }

        public static void SortQuadruples(IntQuadruple[] QuadruplesArray)
        {
            for (int i=0;i<QuadruplesArray.Length-1;i++)
            {
                int BestIndex = i;
                for (int j = i+1;j<QuadruplesArray.Length;j++)
                    if ((QuadruplesArray[j].Third > QuadruplesArray[BestIndex].Third) || 
                        (QuadruplesArray[j].Third == QuadruplesArray[BestIndex].Third && QuadruplesArray[j].Forth > QuadruplesArray[BestIndex].Forth))
                        BestIndex = j;

                int t1 = QuadruplesArray[BestIndex].First; QuadruplesArray[BestIndex].First = QuadruplesArray[i].First;QuadruplesArray[i].First=t1;
                int t2 = QuadruplesArray[BestIndex].Second; QuadruplesArray[BestIndex].Second = QuadruplesArray[i].Second; QuadruplesArray[i].Second = t2;
                int t3 = QuadruplesArray[BestIndex].Third; QuadruplesArray[BestIndex].Third = QuadruplesArray[i].Third; QuadruplesArray[i].Third = t3;
                int t4 = QuadruplesArray[BestIndex].Forth; QuadruplesArray[BestIndex].Forth = QuadruplesArray[i].Forth; QuadruplesArray[i].Forth = t4;
            }
        }

        public static IntQuadruple[] OrderTuplesBasedOnTheirRanks(int qi, int qj, Elements xie, Elements xje)
        {
            IntQuadruple[] result;
            if (xie==Elements.None && xje==Elements.None)
            {
                result = new IntQuadruple[BoddoohNumbers.TwentyEight*BoddoohNumbers.TwentyEight];
                int Count = 0;
                for (int xi = 1; xi <= BoddoohNumbers.TwentyEight; xi++)
                    for (int xj = 1; xj <= BoddoohNumbers.TwentyEight; xj++)
                    {
                        int SecondaryRank = 0;
                        int PrimaryRank = CalculateThePrimaryAndSecondaryRank(qi, qj, xi, xj, ref SecondaryRank);
                        result[Count] = new IntQuadruple(xi, xj, PrimaryRank, SecondaryRank);
                        Count++;
                    }
            }
            else
            {
                result = new IntQuadruple[BoddoohNumbers.Seven*BoddoohNumbers.Seven];
                int Count = 0;
                for (int xio = 0; xio < BoddoohNumbers.Seven; xio++)
                    for (int xjo = 0; xjo < BoddoohNumbers.Seven; xjo++)
                    {
                        int xi = Abjad.ElementalOrder(xie) + xio * BoddoohNumbers.Four;
                        int xj = Abjad.ElementalOrder(xje) + xjo * BoddoohNumbers.Four;
                        int SecondaryRank = 0;
                        int PrimaryRank = CalculateThePrimaryAndSecondaryRank(qi, qj, xi, xj, ref SecondaryRank);
                        result[Count] = new IntQuadruple(xi, xj, PrimaryRank, SecondaryRank);
                        Count++;
                    }
            }
            SortQuadruples(result);
            return result;
        }

        public static int CalculateThePrimaryAndSecondaryRank(int a11, int a12, int a13, int a14, ref int SecondaryRank)
        {
            int a21, a22, a23, a24, a31, a32, a33, a34, a41, a42, a43, a44;
            Boddooh4By4Table B4B4T = new Boddooh4By4Table(a11, a12, a13, a14);
            a22 = a33 = a44 = a11;
            a21 = B4B4T.a21;
            a23 = B4B4T.a23;
            a24 = B4B4T.a24;
            a34 = B4B4T.a34;
            a32 = B4B4T.a32;
            a31 = B4B4T.a31;
            a43 = B4B4T.a43;
            a42 = B4B4T.a42;
            a41 = B4B4T.a41;

            int S1 = B4B4T.SummationOfColumn1;
            int S2 = B4B4T.SummationOfColumn2;
            int S3 = B4B4T.SummationOfColumn3;
            int S4 = B4B4T.SummationOfColumn4;

            int ST = B4B4T.SummationOfRow1;
            int SB = B4B4T.SummationOfRow4;
            int SR = B4B4T.SummationOfColumn1;
            int SL = B4B4T.SummationOfColumn4;

            int PrimaryRank = 0;

            #region Conditions 1 through 10

            // Condition 1
            int c1 = Math.Abs((a14 + a13) - (a12 + a11));
            if (c1 % BoddoohNumbers.TwentyEight == 8 || c1 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c1)) 
                    SecondaryRank++;

            // Condition 2
            int c21 = Math.Abs(ST - SB);
            int c22 = ST + SB;
            if (c21 % BoddoohNumbers.TwentyEight == 8 || c21 % BoddoohNumbers.TwentyEight == 20 ||
                c22 % BoddoohNumbers.TwentyEight == 8 || c22 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c21) || GetsSecondaryRank(c22))
                    SecondaryRank++;

            // Condition 3
            int c31 = Math.Abs(SL - SR);
            int c32 = SL + SR;
            if (c31 % BoddoohNumbers.TwentyEight == 8 || c31 % BoddoohNumbers.TwentyEight == 20 ||
                c32 % BoddoohNumbers.TwentyEight == 8 || c32 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c31) || GetsSecondaryRank(c32))
                SecondaryRank++;

            // Condition 4
            int c41 = Math.Abs(SL - ST);
            int c42 = SL + ST;
            if (c41 % BoddoohNumbers.TwentyEight == 8 || c41 % BoddoohNumbers.TwentyEight == 20 ||
                c42 % BoddoohNumbers.TwentyEight == 8 || c42 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c41) || GetsSecondaryRank(c42))
                SecondaryRank++;

            // Condition 5
            int c51 = Math.Abs(SR - SB);
            int c52 = SR + SB;
            if (c51 % BoddoohNumbers.TwentyEight == 8 || c51 % BoddoohNumbers.TwentyEight == 20 ||
                c52 % BoddoohNumbers.TwentyEight == 8 || c52 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c51) || GetsSecondaryRank(c52))
                SecondaryRank++;

            // Condition 6
            int c61 = (SL + SR) - Math.Abs(ST - SB);
            int c62 = (SL + SR) - (ST + SB);
            if (c61 % BoddoohNumbers.TwentyEight == 8 || c61 % BoddoohNumbers.TwentyEight == 20 ||
                c62 % BoddoohNumbers.TwentyEight == 8 || c62 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c61) || GetsSecondaryRank(c62))
                SecondaryRank++;

            // Condition 7
            int c7 = S1 + S2 + S3 + S4;
            if (c7 % BoddoohNumbers.TwentyEight == 8 || c7 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c7))
                SecondaryRank++;

            // Condition 8
            int c81 = MiscMethods.JoinDigits(a14,a13,a12,a11) % BoddoohNumbers.TwentyEight;
            int c82 = MiscMethods.JoinDigits(a24,a23,a22,a21) % BoddoohNumbers.TwentyEight;
            int c83 = MiscMethods.JoinDigits(a34,a33,a32,a31) % BoddoohNumbers.TwentyEight;
            int c84 = MiscMethods.JoinDigits(a44,a43,a42,a41) % BoddoohNumbers.TwentyEight;
            int c8 = (c81 + c82  + c83 + c84);
            if (c8 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c8))
                SecondaryRank++;

            // Condition 9
            int c9 = c81 + c83;
            if (c9 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c9))
                SecondaryRank++;
            

            // Condition 10
            int c101 = MiscMethods.JoinDigits(a11,a11,a11,a11);
            int c102 = MiscMethods.JoinDigits(a14,a23,a32,a41);
            if (c101 % BoddoohNumbers.TwentyEight == a11 && c102 % BoddoohNumbers.TwentyEight == a12)
                PrimaryRank++;
            
            #endregion Conditions 1 through 10

            #region Conditions 11 through 20

            // Condition 11
            int c11 = MiscMethods.JoinDigits(a41,a32,a23,a14);
            if (c11 % BoddoohNumbers.TwentyEight == 20 || c11 % BoddoohNumbers.TwentyEight == 8)
                PrimaryRank++;
            else if (GetsSecondaryRank(c11))
                SecondaryRank++;


            // Condition 12
            int c121 = S4; while (c121 > 9) c121 = MiscMethods.SummationOfDigits(c121);
            int c122 = S3; while (c122 > 9) c122 = MiscMethods.SummationOfDigits(c122);
            int c123 = S2; while (c123 > 9) c123 = MiscMethods.SummationOfDigits(c123);
            int c124 = S1; while (c124 > 9) c124 = MiscMethods.SummationOfDigits(c124);
            int c12A = MiscMethods.JoinDigits(c121, c122, c123, c124) % BoddoohNumbers.TwentyEight;
            int c12B = MiscMethods.JoinDigits(c121, c123, c122, c124) % BoddoohNumbers.TwentyEight;
            int c12C = MiscMethods.JoinDigits(c124, c123, c122, c121) % BoddoohNumbers.TwentyEight;
            int c12D = (c124 +  c123 + c122 + c121) * 2;
            if (c12A % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c12A))
                SecondaryRank++;

            if (c12B % BoddoohNumbers.TwentyEight == 8 || c12B % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c12B))
                SecondaryRank++;

            if (c12C % BoddoohNumbers.TwentyEight == 2 || c12C % BoddoohNumbers.TwentyEight == 26)
                PrimaryRank++;
            else if (GetsSecondaryRank(c12C))
                SecondaryRank++;

            if (c12D % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c12D))
                SecondaryRank++;

            // Condition 13
            int c131 = SL * SR;
            int c132 = ST * SB;
            int c133 = c131 + c132;
            int c134 = Math.Abs(c131 - c132);
            if (c131 % BoddoohNumbers.TwentyEight == 8 || c131 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c131))
                SecondaryRank++;

            if (c133 % BoddoohNumbers.TwentyEight == 8 || c133 % BoddoohNumbers.TwentyEight == 20) 
                PrimaryRank++;
            else if (GetsSecondaryRank(c133))
                SecondaryRank++;

            if (c134 % BoddoohNumbers.Nine == 2)
                PrimaryRank++;
            else if (GetsSecondaryRank(c134))
                SecondaryRank++;


            // Condition 14
            int c14A1 = SL + SR;
            int c14A2 = Math.Abs(SL - SR);
            int c14A3 = ST + SB;
            int c14A4 = Math.Abs(ST - SB);
            int c14A5 = c14A1 * c14A3;
            int c14A6 = c14A1 * c14A4;
            int c14A7 = c14A2 * c14A3;
            int c14A8 = c14A2 * c14A4;
            if (c14A5 % BoddoohNumbers.TwentyEight == 8 || c14A5 % BoddoohNumbers.TwentyEight == 20 ||
                c14A6 % BoddoohNumbers.TwentyEight == 8 || c14A6 % BoddoohNumbers.TwentyEight == 20 ||
                c14A7 % BoddoohNumbers.TwentyEight == 8 || c14A7 % BoddoohNumbers.TwentyEight == 20 ||
                c14A8 % BoddoohNumbers.TwentyEight == 8 || c14A8 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c14A5) || GetsSecondaryRank(c14A6) || GetsSecondaryRank(c14A7) || GetsSecondaryRank(c14A8))
                SecondaryRank++;


            int c14B1 = SL + ST;
            int c14B2 = Math.Abs(SL - ST);
            int c14B3 = SR + SB;
            int c14B4 = Math.Abs(SR - SB);
            int c14B5 = c14B1 * c14B3;
            int c14B6 = c14B1 * c14B4;
            int c14B7 = c14B2 * c14B3;
            int c14B8 = c14B2 * c14B4;
            if (c14B5 % BoddoohNumbers.TwentyEight == 8 || c14B5 % BoddoohNumbers.TwentyEight == 20 ||
                c14B6 % BoddoohNumbers.TwentyEight == 8 || c14B6 % BoddoohNumbers.TwentyEight == 20 ||
                c14B7 % BoddoohNumbers.TwentyEight == 8 || c14B7 % BoddoohNumbers.TwentyEight == 20 ||
                c14B8 % BoddoohNumbers.TwentyEight == 8 || c14B8 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c14B5) || GetsSecondaryRank(c14B6) || GetsSecondaryRank(c14B7) || GetsSecondaryRank(c14B8))
                SecondaryRank++;

            // Condition 15
            int c151 = MiscMethods.JoinDigits(a14,a13,a12,a11);
            int c152 = MiscMethods.JoinDigits(a11,a12,a13,a14);
            int c153 = MiscMethods.JoinDigits(a24,a23,a22,a21);
            int c154 = MiscMethods.JoinDigits(a21,a22,a23,a24);
            int c155 = MiscMethods.JoinDigits(a34,a33,a32,a31);
            int c156 = MiscMethods.JoinDigits(a31,a32,a33,a34);
            int c157 = MiscMethods.JoinDigits(a44,a43,a42,a41);
            int c158 = MiscMethods.JoinDigits(a41,a42,a43,a44);
            int c15A = Math.Abs(c151 - c152);
            int c15B = Math.Abs(c153 - c154);
            int c15C = Math.Abs(c155 - c156);
            int c15D = Math.Abs(c157 - c158);
            int c15E1 = Math.Abs(c15C - c15D);            
            int c15E2 = c15C + c15D;
            int c15F1 = Math.Abs(c15A - c15D);
            int c15F2 = c15A + c15D;
            int c15G = Math.Abs(c15A - c15B);
            if (c15G % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c15G))
                SecondaryRank++;

            if (c15E1 % BoddoohNumbers.TwentyEight == 8 || c15E1 % BoddoohNumbers.TwentyEight == 20 ||
                c15E2 % BoddoohNumbers.TwentyEight == 8 || c15E2 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c15E1) || GetsSecondaryRank(c15E2))
                SecondaryRank++;

            if (c15F1 % BoddoohNumbers.TwentyEight == 0 || c15F2 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c15E1) || GetsSecondaryRank(c15E2))
                SecondaryRank++;

            // Condition 16
            int c16 = S1 * S2 * S3 * S4;
            if (c16 % BoddoohNumbers.Nine == 2)
                PrimaryRank++;
            else if (GetsSecondaryRank(c16))
                SecondaryRank++;

            // Condition 17
            int c171 = a11 * a21 * a31 * a41;
            int c172 = a12 * a22 * a32 * a42;
            int c173 = a13 * a23 * a33 * a43;
            int c174 = a14 * a24 * a34 * a44;
            int c17A = c171 + c172;
            int c17B = Math.Abs(c171 - c172);
            if (c17A % BoddoohNumbers.TwentyEight == 8 || c17A % BoddoohNumbers.TwentyEight == 20 ||
                c17B % BoddoohNumbers.TwentyEight == 8 || c17B % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c17A) || GetsSecondaryRank(c17B))
                SecondaryRank++;

            if (c173 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c173))
                SecondaryRank++;

            if (c174 % BoddoohNumbers.TwentyEight == 0 || c174 % BoddoohNumbers.Nine == 2)
                PrimaryRank++;
            else if (GetsSecondaryRank(c174))
                SecondaryRank++;


            // Condition 18
            int c181 = a14 + a13 + a12 + a11; 
            int c182 = a24 + a23 + a22 + a21;
            int c183 = a34 + a33 + a32 + a31; 
            int c184 = a44 + a43 + a42 + a41;
            int c18A1 = c181 + c182;
            int c18A2 = Math.Abs(c181 - c182);
            int c18B1 = c181 + c183;
            int c18B2 = Math.Abs(c181 - c183);
            int c18C = c182 + c184;
            int c18D = c181 * c182 * c183 * c184;
            if (c18A1 % BoddoohNumbers.TwentyEight == 8 || c18A1 % BoddoohNumbers.TwentyEight == 20 ||
                c18A2 % BoddoohNumbers.TwentyEight == 8 || c18A2 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c18A1) || GetsSecondaryRank(c18A2))
                SecondaryRank++;

            if (c18B1 % BoddoohNumbers.TwentyEight == 8 || c18B1 % BoddoohNumbers.TwentyEight == 20 ||
                c18B2 % BoddoohNumbers.TwentyEight == 8 || c18B2 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c18B1) || GetsSecondaryRank(c18B2))
                SecondaryRank++;

            if (c18C % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c18C))
                SecondaryRank++;

            if (c18D % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c18D))
                SecondaryRank++;


            // Condition 19
            int c191 = Math.Abs(a14 - a11);
            int c192 = Math.Abs(a24 - a21);
            int c193 = Math.Abs(a34 - a31);
            int c194 = Math.Abs(a44 - a41);
            int c195 = Math.Abs(a13 - a12);
            int c196 = Math.Abs(a23 - a22);
            int c197 = Math.Abs(a33 - a32);
            int c198 = Math.Abs(a43 - a42);
            int c19A = c191 + c192 + c193 + c194;
            int c19B = c195 + c196 + c197 + c198;
            int c19C1 = c19A + c19B;
            int c19C2 = Math.Abs(c19A - c19B);
            if (c19A % BoddoohNumbers.TwentyEight == 20 || c19A % BoddoohNumbers.TwentyEight == 8)
                PrimaryRank++;
            else if (GetsSecondaryRank(c19A))
                SecondaryRank++;

            if (c19C1 % BoddoohNumbers.TwentyEight == 8 || c19C1 % BoddoohNumbers.TwentyEight == 20 ||
                c19C2 % BoddoohNumbers.TwentyEight == 8 || c19C2 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c19C1) || GetsSecondaryRank(c19C2))
                SecondaryRank++;


            // Condition 20
            int c201 = S1 * S2 * S3 * S4;
            int c202 = ST * SR * SB * SL;
            int c20A = c201 + c202;
            int c20B = Math.Abs(c201 - c202);
            if (c20A % BoddoohNumbers.TwentyEight == 8 || c20A % BoddoohNumbers.TwentyEight == 20 ||
                c20B % BoddoohNumbers.TwentyEight == 8 || c20B % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c20A) || GetsSecondaryRank(c20B))
                SecondaryRank++;


            #endregion Conditions 11 through 20
            
            #region Conditions 21 through 30

            // Condition 21
            int c211 = a14 * a23 * a32 * a41;
            int c212 = a11 * a11 * a11 * a11;
            int c21A = MiscMethods.SummationOfDigits(c211 + c212);
            int c21B = MiscMethods.SummationOfDigits(Math.Abs(c211 - c212));
            if (c21A == 2 * a11 || c21B == 2 * a11)
                PrimaryRank++;
            if (c21A % BoddoohNumbers.TwentyEight == 0 || c21B % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c21A) || GetsSecondaryRank(c21B))
                SecondaryRank++;


            // Condition 22
            int c221 = MiscMethods.JoinDigits(a14,a24,a34,a44);
            int c222 = MiscMethods.JoinDigits(a44,a34,a24,a14);
            int c223 = MiscMethods.JoinDigits(a13,a23,a33,a43);
            int c224 = MiscMethods.JoinDigits(a43,a33,a23,a13);
            int c225 = MiscMethods.JoinDigits(a12,a22,a32,a42);
            int c226 = MiscMethods.JoinDigits(a42,a32,a22,a12);
            int c227 = MiscMethods.JoinDigits(a11,a21,a31,a41);
            int c228 = MiscMethods.JoinDigits(a41,a31,a21,a11);
            int c22A = Math.Abs(c221 - c222);
            int c22B = Math.Abs(c223 - c224);
            int c22C = Math.Abs(c225 - c226);
            int c22D = Math.Abs(c227 - c228);
            int c22E = (c15A + c15B + c15C + c15D);
            int c22F = (c22A + c22B + c22C + c22D);
            int c22G = Math.Abs(c22E - c22F);
            int c22H = c22E + c22F;
            if (c22E % BoddoohNumbers.Nine == 2)
                PrimaryRank++;
            else if (GetsSecondaryRank(c22E))
                SecondaryRank++;

            if (c22F % BoddoohNumbers.Nine == 2)
                PrimaryRank++;
            else if (GetsSecondaryRank(c22F))
                SecondaryRank++;

            if (c22G % BoddoohNumbers.TwentyEight == 8 || c22G % BoddoohNumbers.TwentyEight == 20 ||
                c22H % BoddoohNumbers.TwentyEight == 8 || c22H % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c22G) || GetsSecondaryRank(c22H))
                SecondaryRank++;

            // Condition 23
            int c231 = Math.Abs(c15A - c22D);
            int c232 = Math.Abs(c22B - c15A) + c22D + c22C;
            int c233 = Math.Abs(c22D - c15D);
            int c234 = Math.Abs(c15C - c22D)+ c15D + c22D;
            if (c231 % BoddoohNumbers.TwentyEight == 8 || c231 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c231))
                SecondaryRank++;

            if (c232 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c232))
                SecondaryRank++;

            if (c233 % BoddoohNumbers.TwentyEight == 8 || c233 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c233))
                SecondaryRank++;

            if (c234 % BoddoohNumbers.TwentyEight == 8 || c234 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c234))
                SecondaryRank++;

            // Condition 24
            int c241 = MiscMethods.JoinDigits(S4, S3, S2, S1);
            int c242 = MiscMethods.JoinDigits(S1, S2, S3, S4); 
            int c24 = c241 + c242;
            if (c24 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c24))
                SecondaryRank++;

            // Condition 25
            int c251 = MiscMethods.JoinDigits(ST, SL, SB, SR);
            int c252 = MiscMethods.JoinDigits(SR, SB, SL, ST); 
            int c25 = c251 + c252;
            if (c25 % BoddoohNumbers.Eight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c25))
                SecondaryRank++;

            // Condition 26
            int c26 = Math.Abs(c251 - c252);
            if (c26 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;

            // Condition 27
            int c271 = MiscMethods.JoinDigits(SL, SB, SR, ST);
            int c272 = MiscMethods.JoinDigits(ST, SR, SB, SL);
            int c27 = c271 + c272;
            if (c27 % BoddoohNumbers.TwentyEight == 8 || c27 % BoddoohNumbers.TwentyEight == 20)
                PrimaryRank++;
            else if (GetsSecondaryRank(c27))
                SecondaryRank++;

            // Condition 28
            int c281 = MiscMethods.JoinDigits(SB, SR, ST, SL);
            int c282 = MiscMethods.JoinDigits(SL, ST, SR, SB);
            int c28 = c281 + c282;
            if (c28 % BoddoohNumbers.Eight == 0)
                PrimaryRank++;

            // Condition 29
            int c291 = MiscMethods.JoinDigits(SR, ST, SL, SB);
            int c292 = MiscMethods.JoinDigits(SB, SL, ST, SR);
            int c29 = c291 + c292;
            if (c29 % BoddoohNumbers.TwentyEight == 0)
                PrimaryRank++;
            else if (GetsSecondaryRank(c29))
                SecondaryRank++;

            // Condition 30
            int b11, b12, b13, b14, b21, b22, b23, b24, b31, b32, b33, b34, b41, b42, b43, b44;
            b11 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a11));
            b22 = b33 = b44 = b11;
            b12 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a12));
            b13 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a13));
            b14 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a14));

            b21 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a21));
            b23 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a23));
            b24 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a24));

            b31 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a31));
            b32 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a32));
            b34 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a34));

            b41 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a41));
            b42 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a42));
            b43 = Abjad.ElementalOrder(Abjad.GetLetterByMinorAbjadNumber(a43));

            int T1 = (b11 + b21 + b31 + b41);
            int T2 = (b12 + b22 + b32 + b42);
            int T3 = (b13 + b23 + b33 + b43);
            int T4 = (b14 + b24 + b34 + b44);

            bool c30A = ((T1 == a11) && (T2 == a12) && (T3 == a13) && (T4 == a14));
            bool c30B = ((T1 - a11) % BoddoohNumbers.Seven == 0 && (T2 - a12) % BoddoohNumbers.Seven == 0 &&
                         (T3 - a13) % BoddoohNumbers.Seven == 0 && (T4 - a14) % BoddoohNumbers.Seven == 0);
            bool c30C = ((T1 + a11) % BoddoohNumbers.Seven == 0 && (T2 + a12) % BoddoohNumbers.Seven == 0 &&
                         (T3 + a13) % BoddoohNumbers.Seven == 0 && (T4 + a14) % BoddoohNumbers.Seven == 0);
            bool c30D = (((T1 - a11) % BoddoohNumbers.Seven + (T2 - a12) % BoddoohNumbers.Seven  +
                         (T3 - a13) % BoddoohNumbers.Seven + (T4 - a14) % BoddoohNumbers.Seven) % BoddoohNumbers.Seven == 0);

            if (c30A)
                PrimaryRank++;
            if (c30B)
                PrimaryRank++;
            if (c30C)
                PrimaryRank++;
            if (c30D)
                PrimaryRank++;

            #endregion Conditions 21 through 30

            return PrimaryRank;
        }
       
        //public static ArrayList FindAllAnswersForTheCaseTest(bool b, ListBox listAnswers, bool NoDuplicateLetters, int first, int second, int prelast, int last, int masfo)
        //{
        //    ArrayList result = new ArrayList();
        //    String QuestionString = Boddooh.LetterSequence;
        //    if (NoDuplicateLetters)
        //        QuestionString = Boddooh.OmitDuplicateLetters(QuestionString);
        //    FindAllAnswers(b, listAnswers, QuestionString, first, second, prelast, last, masfo);
        //    return result;
        //}

        //public static bool CheckValidityOfTopArray(BoddoohLab BL, int CompletedPartLengthFromRight, int CompletedPartLengthFromLeft)
        //{
        //    int l = 0; while (l < CompletedPartLengthFromLeft && BL.Top[BL.ColumnsCount -1 - l] == 0)
        //        l++;
        //    int r = 0; while (r < CompletedPartLengthFromRight && BL.Top[r] == 0)
        //        r++;
        //    int FirstFromRight = 0; if (r<CompletedPartLengthFromRight) FirstFromRight = BL.Top[r];
        //    int FirstFromLeft = 0; if (l<CompletedPartLengthFromLeft) FirstFromLeft = BL.Top[BL.ColumnsCount -1 - l];

        //    if (FirstFromRight == 0 || FirstFromLeft == 0)
        //        return true;

        //    int NextFeasibleSum = FirstFromRight;//Math.Min(FirstFromRight, FirstFromLeft);
        //    NextFeasibleSum++;
        //    while (NextFeasibleSum % BoddoohNumbers.Nine != 2)
        //        NextFeasibleSum++;

        //    int Sum = FirstFromRight + FirstFromLeft;
            
        //    //l++; r++;
        //    while (l < CompletedPartLengthFromLeft && r < CompletedPartLengthFromRight)
        //    {
        //        //Sum += (BL.Top[r] + BL.Top[BL.ColumnsCount - 1 - l]);
        //        if (Sum > NextFeasibleSum)
        //            return false;
        //        if (Sum == NextFeasibleSum)
        //            NextFeasibleSum += 9;
        //        l++; r++;
        //        while (l < CompletedPartLengthFromLeft && BL.Top[BL.ColumnsCount -1 - l] == 0) l++;
        //        while (r < CompletedPartLengthFromRight && BL.Top[r] == 0) r++;
        //        if (l < CompletedPartLengthFromLeft)
        //        {
        //            Sum += BL.Top[BL.ColumnsCount - 1 - l];
        //        }
        //        if (r < CompletedPartLengthFromRight)
        //        {
        //            Sum += BL.Top[r];
        //        }
        //    }

        //    if (Sum > NextFeasibleSum)
        //        return false;

        //    return true;
        //}
        //public static bool CheckValidityOfTopArrayForRightAndLeft(BoddoohLab BL, int Count)
        //{
        //    if (Count == 0)
        //        return true;
        //    int Sum = 0;
        //    int i = 0;
        //    int NextFeasibleSum = 2;
        //    while (i < Count)
        //    {
        //        Sum += (BL.Top[i] + BL.Top[BL.ColumnsCount - 1 - i]);
        //        if (Sum > NextFeasibleSum)
        //            return false;
        //        if (Sum == NextFeasibleSum)
        //            NextFeasibleSum += 9;
        //        i++;
        //    }
        //    return true;
        //}

        //public static bool CheckValidityOfTopArrayForRight(BoddoohLab BL, int Count)
        //{
        //    if (Count == 0)
        //        return true;
        //    int Sum = 0;
        //    int i = 0;
        //    int NextFeasibleSum = 2;
        //    while (i < Count)
        //    {
        //        Sum += BL.Top[i];
        //        if (Sum > NextFeasibleSum)
        //            return false;
        //        if (Sum == NextFeasibleSum)
        //            NextFeasibleSum += 9;
        //        i++;
        //    }
        //    return true;
        //}
        ////public static IntTuple AreFeasibleAnswerLetters(BoddoohLab BL, int[] AnswerLetters, int index, int xi, int xj)
        ////{
        //    BoddoohLab TBL = BL.Clone();
        //    int RightCounterpart = xi;
        //    bool Possible = TBL.CheckIfItsPossibleToStartOrContinueFromRightWithTheDigitsButMakeNoChanges(MiscMethods.JoinDigits(xj, xi));
        //    if (!Possible)
        //        return new IntTuple(0, 0);
        //    int first = TBL.FindTheOutputLetterForTheLeftHalf(AnswerLetters, RightCounterpart, index);
        //    if (first == 0)
        //        return new IntTuple(0, 0);
        //    RightCounterpart = xj;
        //    int second = TBL.FindTheOutputLetterForTheLeftHalf(AnswerLetters, RightCounterpart, index + 1);
        //    if (second == 0)
        //        return new IntTuple(0, 0);
        //   // if (!CheckValidityOfTopArray(TBL, index + 2))
        // //       return new IntTuple(0, 0);
        //        //TBL.ShowTable();
        //    return new IntTuple(first, second);
        //}

        public static bool CheckValidityOfMinorAndMajorAbjadSummations(int[] answerLetters)
        {
            int MinorSummation = 0;
            int MajorSummation = 0;
            for (int i = 0; i < answerLetters.Length; i++)
            {
                MinorSummation += Abjad.MinorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(answerLetters[i]));
                MajorSummation += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(answerLetters[i]));
            }
            if (MinorSummation <= MinorAbjadSummationForTheAnswer && MajorSummation == MajorAbjadSummationForTheAnswer)
                return true;
            else
                return false;
        }

        //public static String FindTheAnswerThatBegginsWith(int[] QuestionLetters, int[] AnswerLetters, int x1, int x2)
        //{
        //    int Length = QuestionLetters.Length;
        //    int HalfLength = Length / 2;
        //    AnswerLetters[0] = x1;
        //    AnswerLetters[1] = x2;
        //    OutputLettersElements = GenerateOutputLettersElements(x1, x2, Length);
        //    MinorAbjadSummationForTheAnswer = FindMinorAbjadSummationForTheAnswer(MinorAbjadSummationForTheQuestion, OutputLettersElements);

        //    ArrayList AllCondidatesForMajorAbjadSummationForTheAnswer = FindMajorAbjadSummationForTheAnswer
        //        (MinorAbjadSummationForTheQuestion, MajorAbjadSummationForTheQuestion, MinorAbjadSummationForTheAnswer, OutputLettersElements);

        //    for (int index = 0; index < AllCondidatesForMajorAbjadSummationForTheAnswer.Count; index++)
        //    {
        //        int majorAbjadSummationForTheAnswer =  (int)AllCondidatesForMajorAbjadSummationForTheAnswer[index];
        //        String AnswerString =  FindTheAnswerWithAGivenMajorAbjadSummationThatBegginsWith(QuestionLetters, AnswerLetters, majorAbjadSummationForTheAnswer, x1, x2);
        //        if (AnswerString != null)
        //        {
        //            MessageBox.Show(AnswerString);
        //        }
        //        break;

        //    }
        //    return null;
                                   
        //}
        //public static String FindTheAnswerThatBegginsWithTest(int[] QuestionLetters, int[] AnswerLetters, int x1, int x2)
        //{
        //    int Length = QuestionLetters.Length;
        //    AnswerLetters[0] = x1;
        //    AnswerLetters[1] = x2;
        //    int[] AnswerCandidates = new int[Length];
        //    OutputLettersElements = GenerateOutputLettersElements(x1, x2, Length);

        //    MinorAbjadSummationForTheAnswer = FindMinorAbjadSummationForTheAnswer(MinorAbjadSummationForTheQuestion, OutputLettersElements);

        //    ArrayList AllCondidatesForMajorAbjadSummationForTheAnswer = FindMajorAbjadSummationForTheAnswer
        //        (MinorAbjadSummationForTheQuestion, MajorAbjadSummationForTheQuestion, MinorAbjadSummationForTheAnswer, OutputLettersElements);

        //    for (int index = 0; index < AllCondidatesForMajorAbjadSummationForTheAnswer.Count; index++)
        //    {
        //        int majorAbjadSummationForTheAnswer = (int)AllCondidatesForMajorAbjadSummationForTheAnswer[index];
        //        String AnswerString = FindTheAnswerWithAGivenMajorAbjadSummationThatBegginsWith(QuestionLetters, AnswerLetters, majorAbjadSummationForTheAnswer, x1, x2);
        //        if (AnswerString != null)
        //        {
        //            MessageBox.Show(AnswerString);
        //        }
        //        break;

        //    }
        //    return null;

        //}      

        //public static bool TryToStartOrContinueWithTheLetters(BoddoohLab BoddoohLabOne, int[] questionLetters, int[] answerLetters, int indexxi, int indexxj, int xi, int xj)
        //{
        //    int Length = questionLetters.Length;
        //    int RemainingLettersCount = Length - 2 * indexxi;
        //    int indexyi = Length - 1 - indexxi;
        //    int indexyj = Length - 1 - indexxj;
        //    int MiddleDigits = -1;
        //    bool Found = false;

        //    #region In Case RemainingLettersCount = 1
        //    //if (RemainingLettersCount == 1)
        //    //{
        //    //    int MinorSum = Abjad.MinorAbjadSummation(answerLetters, 0, indexxi - 1) + Abjad.MinorAbjadSummation(answerLetters, indexxi + 1, Length - 1);
        //    //    int MajorSum = Abjad.MajorAbjadSummation(answerLetters, 0, indexxi - 1) + Abjad.MajorAbjadSummation(answerLetters, indexxi + 1, Length - 1);
        //    //    int MinorAbjadNumberOfTheLastLetter = MinorAbjadSummationForTheAnswer - MinorSum;
        //    //    int MajorAbjadNumberOfTheLastLetter = MajorAbjadSummationForTheAnswer - MajorSum;
        //    //    if (Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(MinorAbjadNumberOfTheLastLetter)) != MajorAbjadNumberOfTheLastLetter)
        //    //        return false;

        //    //    MiddleDigits = answerLetters[indexxi] = MinorAbjadNumberOfTheLastLetter;

        //    //} 
        //    //#endregion
        //    //#region In Case RemainingLettersCount = 2
        //    //if (RemainingLettersCount == 2)
        //    //{
        //    //    answerLetters[indexxi] = xi;
        //    //    answerLetters[indexxj] = xj;

        //    //    int MinorSum = Abjad.MinorAbjadSummation(answerLetters, 0, Length - 1);
        //    //    int MajorSum = Abjad.MajorAbjadSummation(answerLetters, 0, Length - 1);
        //    //    if (MinorAbjadSummationForTheAnswer != MinorSum || MajorAbjadSummationForTheAnswer != MajorSum)
        //    //        return false;

        //    //    MiddleDigits = MiscMethods.JoinDigits(xj, xi);

        //    //} 
        //    //#endregion
        //    //#region In Case RemainingLettersCount = 3
        //    //if (RemainingLettersCount == 3)
        //    //{
        //    //    answerLetters[indexxi] = xi;
        //    //    answerLetters[indexxj] = xj;

        //    //    int MinorSum = Abjad.MinorAbjadSummation(answerLetters, 0, indexxj) + Abjad.MinorAbjadSummation(answerLetters, indexxj + 2, Length - 1);
        //    //    int MajorSum = Abjad.MajorAbjadSummation(answerLetters, 0, indexxj) + Abjad.MajorAbjadSummation(answerLetters, indexxj + 2, Length - 1);
        //    //    int MinorAbjadNumberOfTheLastLetter = MinorAbjadSummationForTheAnswer - MinorSum;
        //    //    int MajorAbjadNumberOfTheLastLetter = MajorAbjadSummationForTheAnswer - MajorSum;
        //    //    if (Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(MinorAbjadNumberOfTheLastLetter)) != MajorAbjadNumberOfTheLastLetter)
        //    //        return false;
        //    //    answerLetters[indexxj + 1] = MinorAbjadNumberOfTheLastLetter;
        //    //    MiddleDigits = MiscMethods.JoinDigits(MinorAbjadNumberOfTheLastLetter, xj, xi);
        //    //} 
        //    #endregion
        //    #region In Case RemainingLettersCount >= 4
        //    if (RemainingLettersCount >= 4)
        //    {
        //        ArrayList AllPossibleMatches = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterparts(xi, xj, indexxi);

        //        for (int option = 0; option < AllPossibleMatches.Count && !Found; option++)
        //        {
        //            #region Check A Possible Match
        //            IntTuple APossibleMatch = (IntTuple)AllPossibleMatches[option];
        //            int yi = APossibleMatch.First; int yj = APossibleMatch.Second;
        //            answerLetters[indexxi] = xi; answerLetters[indexxj] = xj;
        //            answerLetters[indexyi] = yi; answerLetters[indexyj] = yj;

        //            bool PossibleDueToMinorAndMajorAbjadSummations = ItIsPossibleDueToMinorAndMajorAbjadSummations(Boddooh.OutputLettersElements, answerLetters, indexyj - 1, indexxj + 1);
        //            if (!PossibleDueToMinorAndMajorAbjadSummations)
        //                continue;
        //            if (!BoddoohStairwayLab.DoTheCheckingProcess(questionLetters, answerLetters, indexxi + 2))
        //                continue;

        //            int xixjDigits = MiscMethods.JoinDigits(xj, xi); int xixjDigitsCount = MiscMethods.DigitsCount(xixjDigits);
        //            int yiyjDigits = MiscMethods.JoinDigits(yi, yj); int yiyjDigitsCount = MiscMethods.DigitsCount(yiyjDigits);

        //            int NewCompletedPartLengthFromRight = BoddoohLabOne.CompletedPartLengthFromRight + xixjDigitsCount;
        //            int NewCompletedPartLengthFromLeft = BoddoohLabOne.CompletedPartLengthFromLeft + yiyjDigitsCount;
        //            int ContinueIndexFromRight = BoddoohLabOne.CompletedPartLengthFromRight;
        //            int ContinueIndexFromLeft = BoddoohLabOne.ColumnsCount - 1 - BoddoohLabOne.CompletedPartLengthFromLeft;

        //            if (indexxi != 0)
        //            {
        //                int xk = answerLetters[indexxi - 1]; int yk = answerLetters[indexyi + 1];
        //                xixjDigits = MiscMethods.JoinDigits(xixjDigits, MiscMethods.LeftmostDigit(xk));
        //                yiyjDigits = MiscMethods.JoinDigits(MiscMethods.RightmostDigit(yk), yiyjDigits);
        //                xixjDigitsCount++; yiyjDigitsCount++;
        //                ContinueIndexFromRight--; ContinueIndexFromLeft++;
        //            }

        //            BoddoohLab TempBL = BoddoohLabOne.Clone();


        //            #region Find And Sort All Valid Filling Options

        //            ArrayList TheSetOfAllFillingOptionsForRight = TempBL.FindTheSetOfAllFillingOptionsForRight(ContinueIndexFromRight, xixjDigits);

        //            ArrayList TheSetOfAllFillingOptionsForLeft = TempBL.FindTheSetOfAllFillingOptionsForLeft(ContinueIndexFromLeft, yiyjDigits);
        //            if (TheSetOfAllFillingOptionsForRight.Count == 0 || TheSetOfAllFillingOptionsForLeft.Count == 0)
        //                continue;

        //            ArrayList AllValidFillingOptionsForBothRightAndLeft = new ArrayList();
        //            for (int r = 0; r < TheSetOfAllFillingOptionsForRight.Count; r++)
        //                for (int l = 0; l < TheSetOfAllFillingOptionsForLeft.Count; l++)
        //                {
        //                    IntQuadruple[] AFillingOptionForRight = (IntQuadruple[])TheSetOfAllFillingOptionsForRight[r];
        //                    IntQuadruple[] AFillingOptionForLeft = (IntQuadruple[])TheSetOfAllFillingOptionsForLeft[l];
                            
        //                    TempBL.UseSavedColumnsForRight(ContinueIndexFromRight, AFillingOptionForRight);
        //                    TempBL.UseSavedColumnsForLeft(ContinueIndexFromLeft, AFillingOptionForLeft);                            

        //                    bool TopArrayIsValid = CheckValidityOfTopArray(TempBL, TempBL.CompletedPartLengthFromRight + xixjDigitsCount, TempBL.CompletedPartLengthFromLeft + yiyjDigitsCount);
        //                    if (!TopArrayIsValid)
        //                        continue;
                            
        //                    //TempBL.ShowTable(":..:");
        //                    //TopArrayIsValid = CheckValidityOfTopArray(TempBL, TempBL.CompletedPartLengthFromRight + xixjDigitsCount, TempBL.CompletedPartLengthFromLeft + yiyjDigitsCount);
                            
        //                    //if (!TopArrayIsValid)
        //                    //    continue;
                            
        //                    if (RemainingLettersCount <= 4)
        //                    {
        //                        if (!CheckIfMiddleIsOk(TempBL, ContinueIndexFromRight + xixjDigitsCount - 1, ContinueIndexFromLeft - yiyjDigitsCount+1))
        //                            continue;
        //                    }
        //                    AllValidFillingOptionsForBothRightAndLeft.Add(new ObjectTuple(AFillingOptionForRight, AFillingOptionForLeft));
        //                }

        //            SortAllValidFillingOptionsForBothRightAndLeft(AllValidFillingOptionsForBothRightAndLeft);

        //            #endregion;

        //            for (int FillingOptionIndex = 0; FillingOptionIndex < AllValidFillingOptionsForBothRightAndLeft.Count; FillingOptionIndex++)
        //            {
        //                ObjectTuple Current = (ObjectTuple)AllValidFillingOptionsForBothRightAndLeft[FillingOptionIndex];
        //                IntQuadruple[] AFillingOptionForRight = (IntQuadruple[])Current.First;  IntQuadruple[] AFillingOptionForLeft = (IntQuadruple[])Current.Second;

        //                BoddoohLabOne.UseSavedColumnsForRight(ContinueIndexFromRight, AFillingOptionForRight);
        //                BoddoohLabOne.StartOrContinueTheBottomFromRightWithTheDigits(ContinueIndexFromRight, xixjDigits);

        //                BoddoohLabOne.UseSavedColumnsForLeft(ContinueIndexFromLeft, AFillingOptionForLeft);
        //                BoddoohLabOne.StartOrContinueTheBottomFromLefttWithTheDigits(ContinueIndexFromLeft, yiyjDigits);

        //                BoddoohLabOne.CompletedPartLengthFromRight = NewCompletedPartLengthFromRight;
        //                BoddoohLabOne.CompletedPartLengthFromLeft = NewCompletedPartLengthFromLeft;
        //                BoddoohLabOne.ShowTable(".");
        //                if (RemainingLettersCount > 4)
        //                {
        //                    UnapplyTheLastOptionForRight(BoddoohLabOne, AFillingOptionForRight, NewCompletedPartLengthFromRight - 2);
        //                    BoddoohLabOne.SetCarryForNextColumn(NewCompletedPartLengthFromRight - 2);

        //                    UnapplyTheLastOptionForLeft(BoddoohLabOne, AFillingOptionForLeft, BoddoohLabOne.ColumnsCount - 1 - (NewCompletedPartLengthFromLeft - 2));
        //                    BoddoohLabOne.SetBorrowForPreviousColumn(BoddoohLabOne.ColumnsCount - 1 - (NewCompletedPartLengthFromLeft - 2));
        //                }
        //                BoddoohLabOne.ShowTable("..");
        //                if (Found)
        //                {
        //                    MessageBox.Show("دو گزینه شرایط مذکور را برقرار میکنند.");
        //                }
        //                Found = true;
        //                break;
        //            }                    
        //            #endregion Check A Possible Match
        //        }
                

        //    }
        //    #endregion In Case RemainingLettersCount >= 4

        //    return Found;
        //}

        //public static bool CheckIfMiddleIsOk(BoddoohLab BL, int r, int l)
        //{
        //    bool M0OK = (BL.Middle[0, r + 1] == BL.Middle[0, l - 1]);
        //    if (!M0OK) return false;

        //    bool M1OK = (BL.Middle[1, r + 1] == BL.Middle[1, l - 1]);
        //    if (!M1OK) return false;

        //    bool CBOK = (BL.CarryBorrow[r + 1] == BL.CarryBorrow[l - 1]);
        //    if (!CBOK) return false;

        //    return true;
        //}
        
        //public static String FindTheAnswerWithAGivenMajorAbjadSummationThatBegginsWith(int[] questionLetters, int[] answerLetters, int majorAbjadSummationForTheAnswer, int x1, int x2)
        //{
        //    int Length = questionLetters.Length;
        //    int HalfLength = Length / 2;
        //    answerLetters[0] = x1;
        //    answerLetters[1] = x2;
        //    OutputLettersElements = GenerateOutputLettersElements(x1, x2, Length);
        //    MajorAbjadSummationForTheAnswer = majorAbjadSummationForTheAnswer;


        //    BoddoohLab BoddoohLabOne = new BoddoohLab(Length);
        //    int FoundLettersCountFromRight = 0;

        //    while (FoundLettersCountFromRight < HalfLength)
        //    {
        //        int indexxi = FoundLettersCountFromRight;
        //        int indexxj = FoundLettersCountFromRight + 1;
        //        int indexyi = Length - 1 - indexxi;
        //        int indexyj = Length - 1 - indexxj;

        //        Elements xie = OutputLettersElements[indexxi];
        //        Elements xje = OutputLettersElements[indexxj];

        //        int Cumulative = 0;
        //        for (int i = 0; i <= FoundLettersCountFromRight; i++)
        //            Cumulative += questionLetters[i];
        //        Cumulative = MiscMethods.EquivalentNumber(Cumulative);

        //        IntQuadruple[] OptionsForTheNextTwoOutputLetters = null;
        //        if (FoundLettersCountFromRight == 0)
        //        {
        //            OptionsForTheNextTwoOutputLetters = new IntQuadruple[1];
        //            OptionsForTheNextTwoOutputLetters[0] = new IntQuadruple(x1, x2, 0, 0);
        //        }
        //        else
        //        {
        //            OptionsForTheNextTwoOutputLetters = OrderTuplesBasedOnTheirRanks(Cumulative, questionLetters[indexxj], xie, xje);
        //        }
        //        bool Found = false;
        //        for (int index = 0; index < OptionsForTheNextTwoOutputLetters.Length; index++)
        //        {
        //            IntQuadruple AnOptionForFirstTwoOutoutLetters = OptionsForTheNextTwoOutputLetters[index];
        //            int xi = AnOptionForFirstTwoOutoutLetters.First;
        //            int xj = AnOptionForFirstTwoOutoutLetters.Second;
        //            if (xi == 19 && xj == 3)
        //                MessageBox.Show("");
        //            Found = TryToStartOrContinueWithTheLetters(BoddoohLabOne, questionLetters, answerLetters, indexxi, indexxj, xi, xj);
        //            if (Found)
        //                break;                        
        //        }
        //        if (!Found)
        //        {
        //            MessageBox.Show("No Answer");
        //        }
        //        FoundLettersCountFromRight += 2;
        //    }
        //    String AnswerString = String.Empty;
        //    for (int i = 0; i < Length; i++)

        //        if (answerLetters[i] > 0)
        //            AnswerString += Abjad.GetLetterByMinorAbjadNumber(answerLetters[i]);
        //    bool ValidityOfMinorAndMajorAbjadSummations = CheckValidityOfMinorAndMajorAbjadSummations(answerLetters);
        //    if (!ValidityOfMinorAndMajorAbjadSummations)
        //    {
        //        // MessageBox.Show("نادرست");
        //        return null;
        //    }
        //    else
        //    {
        //        //   MessageBox.Show("درست");
        //    }

        //    return AnswerString;
        //}

        //public static void UnapplyTheLastOptionForRight(BoddoohLab BoddoohLabOne, IntQuadruple[] ColumnsData, int ColumnIndex)
        //{
        //    BoddoohLabOne.CarryBorrow[ColumnIndex] = ColumnsData[ColumnsData.Length - 2].First;
        //    BoddoohLabOne.Top[ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Second;
        //    BoddoohLabOne.Middle[0, ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Third;
        //    BoddoohLabOne.Middle[1, ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Forth;

        //    BoddoohLabOne.CarryBorrow[ColumnIndex+1] = ColumnsData[ColumnsData.Length - 1].First;
        //    BoddoohLabOne.Top[ColumnIndex+1] = ColumnsData[ColumnsData.Length - 1].Second;
        //    BoddoohLabOne.Middle[0, ColumnIndex+1] = ColumnsData[ColumnsData.Length - 1].Third;
        //    BoddoohLabOne.Middle[1, ColumnIndex+1] = ColumnsData[ColumnsData.Length - 1].Forth;

        //    BoddoohLabOne.CarryBorrow[ColumnIndex + 2] = 0;
        //    BoddoohLabOne.Top[ColumnIndex + 2] = 0;
        //    BoddoohLabOne.Middle[0, ColumnIndex + 2] = 0;
        //    BoddoohLabOne.Middle[1, ColumnIndex + 2] = 0; 

        //}

        //public static void UnapplyTheLastOptionForLeft(BoddoohLab BoddoohLabOne, IntQuadruple[] ColumnsData, int ColumnIndex)
        //{
        //    BoddoohLabOne.CarryBorrow[ColumnIndex] = ColumnsData[ColumnsData.Length - 2].First;
        //    BoddoohLabOne.Top[ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Second;
        //    BoddoohLabOne.Middle[0, ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Third;
        //    BoddoohLabOne.Middle[1, ColumnIndex] = ColumnsData[ColumnsData.Length - 2].Forth;

        //    BoddoohLabOne.CarryBorrow[ColumnIndex - 1] = ColumnsData[ColumnsData.Length - 1].First;
        //    BoddoohLabOne.Top[ColumnIndex - 1] = ColumnsData[ColumnsData.Length - 1].Second;
        //    BoddoohLabOne.Middle[0, ColumnIndex - 1] = ColumnsData[ColumnsData.Length - 1].Third;
        //    BoddoohLabOne.Middle[1, ColumnIndex - 1] = ColumnsData[ColumnsData.Length - 1].Forth;
        //    BoddoohLabOne.CarryBorrow[ColumnIndex - 2] = 0;
        //    BoddoohLabOne.Top[ColumnIndex - 2] = 0;
        //    BoddoohLabOne.Middle[0, ColumnIndex - 2] = 0;
        //    BoddoohLabOne.Middle[1, ColumnIndex - 2] = 0; 


        //}

        //public static void SortAllValidFillingOptionsForBothRightAndLeft(ArrayList FillingOptionsForBothRightAndLeft)
        //{
        //    int Offset = 3;
        //    for (int i = 0; i < FillingOptionsForBothRightAndLeft.Count-1; i++)
        //    {
        //        int BestIndex = i;
        //        ObjectTuple Best = (ObjectTuple)FillingOptionsForBothRightAndLeft[i];
        //        IntQuadruple[] BestFillingRight = (IntQuadruple[])Best.First;
        //        IntQuadruple[] BestFillingLeft = (IntQuadruple[])Best.Second;
        //        int BestTopNonZeroCount = BestFillingRight[BestFillingRight.Length - Offset].Second + BestFillingLeft[BestFillingLeft.Length - Offset].Second;
        //        int BestIncompleteCount = BestFillingRight[BestFillingRight.Length - Offset].First + BestFillingLeft[BestFillingLeft.Length - Offset].First;

        //        for (int j = i + 1; j < FillingOptionsForBothRightAndLeft.Count; j++)
        //        {
        //            ObjectTuple Current = (ObjectTuple)FillingOptionsForBothRightAndLeft[j];                    
        //            IntQuadruple[] CurrentFillingRight = (IntQuadruple[])Current.First;
        //            IntQuadruple[] CurrentFillingLeft = (IntQuadruple[])Current.Second;
        //            int CurrentTopNonZeroCount = CurrentFillingRight[CurrentFillingRight.Length - Offset].Second + CurrentFillingLeft[CurrentFillingLeft.Length - Offset].Second;
        //            int CurrentIncompleteCount = CurrentFillingRight[CurrentFillingRight.Length - Offset].First + CurrentFillingLeft[CurrentFillingLeft.Length - Offset].First;

        //            //if (CurrentIncompleteCount < BestIncompleteCount || (CurrentIncompleteCount == BestIncompleteCount && CurrentTopNonZeroCount < BestTopNonZeroCount))
        //            if (CurrentTopNonZeroCount < BestTopNonZeroCount || (CurrentTopNonZeroCount == BestTopNonZeroCount && CurrentIncompleteCount < BestIncompleteCount))
        //            {
        //                BestIndex = j;
        //                Best = (ObjectTuple)FillingOptionsForBothRightAndLeft[i];
        //                BestFillingRight = (IntQuadruple[])Best.First;
        //                BestFillingLeft = (IntQuadruple[])Best.Second;
        //                BestTopNonZeroCount = CurrentTopNonZeroCount;
        //                BestIncompleteCount = CurrentIncompleteCount;

        //            }
        //        }

        //        ObjectTuple temp = (ObjectTuple)FillingOptionsForBothRightAndLeft[i];
        //        FillingOptionsForBothRightAndLeft[i] = (ObjectTuple)FillingOptionsForBothRightAndLeft[BestIndex];
        //        FillingOptionsForBothRightAndLeft[BestIndex] = temp;
        //    }

        //}


        //public static String FindTheAnswerThatBegginsWith2(int[] QuestionLetters, int[] AnswerLetters, int x1, int x2)
        //{
        //    int Length = QuestionLetters.Length;
        //    int UpperHalfLength = Length / 2;

        //    AnswerLetters[0] = x1;
        //    AnswerLetters[1] = x2;
        //    OutputLettersElements = GenerateOutputLettersElements(x1, x2, Length);
        //    MajorAbjadSummationForTheAnswer = FindMajorAbjadSummationForTheAnswer(MinorAbjadSummationForTheQuestion, MajorAbjadSummationForTheQuestion, MinorAbjadSummationForTheAnswer, OutputLettersElements);
        //    ArrayList AllPossibleMatches = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterparts(x1, x2, 0);

        //    BoddoohLab BoddoohLabOne = new BoddoohLab(Length);
        //    ArrayList TheSetOfAllFillingOptionsForRight = BoddoohLabOne.FindTheSetOfAllFillingOptionsForRight(0, MiscMethods.JoinDigits(x2, x1));
        //    //ArrayList TheSetOfAllFillingOptionsForLeft = BoddoohLabOne.FindTheSetOfAllFillingOptionsForLeft(0, 4);

        //    bool TheFirstTwoOutoutLettersPassTheBoddoohLabOne = BoddoohLabOne.TryToStartOrContinueFromRightWithTheDigits(MiscMethods.JoinDigits(x2, x1));
        //    if (!TheFirstTwoOutoutLettersPassTheBoddoohLabOne)
        //    {
        //        Boddooh.Errors AWarning = Boddooh.Errors.TheFirstTwoOutoutLettersDontPassTheBoddoohLabOne;
        //        ShowRecommendedErrorMessage(AWarning);
        //        return String.Empty;
        //    }

        //    // BoddoohLabOne.ShowTable("");
        //    for (int RightCounterpartIndex = 0; RightCounterpartIndex < 2; RightCounterpartIndex++)
        //    {
        //        int Letter = BoddoohLabOne.FindTheOutputLetterForTheLeftHalf(AnswerLetters, AnswerLetters[RightCounterpartIndex], RightCounterpartIndex);
        //        if (Letter == 0)
        //            return null;
        //        int LeftCounterpartIndex = Length - 1 - RightCounterpartIndex;
        //        AnswerLetters[LeftCounterpartIndex] = Letter;
        //    }
        //    if (!BoddoohStairwayLab.DoTheCheckingProcess(QuestionLetters, AnswerLetters, 2))
        //        return null;
        //    BoddoohLabOne.ShowTable("Start");

        //    int CompletedPartLength = 2;
        //    while (CompletedPartLength < UpperHalfLength)
        //    {
        //        int indexi = CompletedPartLength;
        //        int indexj = CompletedPartLength + 1;
        //        Elements xie = OutputLettersElements[indexi];
        //        Elements xje = OutputLettersElements[indexj];

        //        int Cumulative = 0;
        //        for (int i = 0; i <= CompletedPartLength; i++)
        //            Cumulative += QuestionLetters[i];
        //        Cumulative = MiscMethods.EquivalentNumber(Cumulative);

        //        IntQuadruple[] OptionsForTheNextTwoOutputLetters = OrderTuplesBasedOnTheirRanks(Cumulative, QuestionLetters[indexj], xie, xje);

        //        for (int index = 0; index < OptionsForTheNextTwoOutputLetters.Length; index++)
        //        {
        //            IntQuadruple AnOptionForFirstTwoOutoutLetters = OptionsForTheNextTwoOutputLetters[index];
        //            int xi = AnOptionForFirstTwoOutoutLetters.First;
        //            int xj = AnOptionForFirstTwoOutoutLetters.Second;
        //            int MajorAbjadSummation = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(xi)) + Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(xj));
        //          //  bool ConstraintDueToMajorAbjadSummationForTheAnswerIsSatisfied =
        //           // CheckIfTheConstraintDueToMajorAbjadSummationForTheAnswerIsSatisfied(Boddooh.OutputLettersElements, AnswerLetters, Length - 1 - CompletedPartLength, CompletedPartLength, CompletedPartLength, CompletedPartLength + 1, MajorAbjadSummation);
        //            //if (!ConstraintDueToMajorAbjadSummationForTheAnswerIsSatisfied)
        //          //      continue;
        //            IntTuple TwoLeftCounterparts = AreFeasibleAnswerLetters(BoddoohLabOne, AnswerLetters, CompletedPartLength, xi, xj);
        //            if (TwoLeftCounterparts.First == 0 || TwoLeftCounterparts.Second == 0)
        //                continue;
        //            AnswerLetters[indexi] = xi;
        //            AnswerLetters[indexj] = xj;
        //            AnswerLetters[Length - 1 - indexi] = TwoLeftCounterparts.First;
        //            AnswerLetters[Length - 1 - indexj] = TwoLeftCounterparts.Second;
        //            if (!BoddoohStairwayLab.DoTheCheckingProcess(QuestionLetters, AnswerLetters, CompletedPartLength + 2))
        //                continue;
        //            //                    String S = Convert.ToString(xi) + ", " + Convert.ToString(xj) + " befor on the right";
        //            //                    BoddoohLabOne.ShowTable(S);
        //            bool Ok = BoddoohLabOne.TryToStartOrContinueFromRightWithTheDigits(MiscMethods.JoinDigits(xj, xi));
        //            if (!Ok)
        //                MessageBox.Show("Error 1");

        //            AnswerLetters[OutputLettersElements.Length - 1 - CompletedPartLength] =
        //                BoddoohLabOne.FindTheOutputLetterForTheLeftHalf(AnswerLetters, AnswerLetters[CompletedPartLength], CompletedPartLength);
        //            if (AnswerLetters[OutputLettersElements.Length - 1 - CompletedPartLength] == 0)
        //                MessageBox.Show("Error 2");
        //            // S = Convert.ToString(AnswerLetters[OutputLettersElements.Length - 1 - FoundPartLength]) + " before on the left befor";
        //            //   BoddoohLabOne.ShowTable(S);
        //            AnswerLetters[OutputLettersElements.Length - 1 - CompletedPartLength - 1] =
        //                BoddoohLabOne.FindTheOutputLetterForTheLeftHalf(AnswerLetters, AnswerLetters[CompletedPartLength + 1], CompletedPartLength + 1);
        //            if (AnswerLetters[OutputLettersElements.Length - 1 - CompletedPartLength - 1] == 0)
        //                MessageBox.Show("Error 3");

        //            break;
        //            //if (!Ok)
        //            //{
        //            //    MessageBox.Show("Error");
        //            //}
        //            //  S = Convert.ToString(xi) + ", " + Convert.ToString(xj) + " after on the right befor";
        //            //     BoddoohLabOne.ShowTable(S);

        //            //AnswerLetters[OutputLettersElements.Length - 1 - FoundPartLength] = BoddoohLabOne.FindTheOutputLetterForTheLeftHalf(AnswerLetters, AnswerLetters[FoundPartLength], OutputLettersElements.Length - 1 - FoundPartLength);
        //            // S = Convert.ToString(AnswerLetters[OutputLettersElements.Length - 1 - FoundPartLength]) + " before on the left befor";
        //            //   BoddoohLabOne.ShowTable(S);

        //            //                  AnswerLetters[OutputLettersElements.Length - 1 - FoundPartLength - 1] = BoddoohLabOne.FindTheOutputLetterForTheLeftHalf(AnswerLetters, AnswerLetters[FoundPartLength + 1], OutputLettersElements.Length - 1 - FoundPartLength - 1);
        //            //   S = Convert.ToString(AnswerLetters[OutputLettersElements.Length - 1 - FoundPartLength - 1]) + " after on the left befor";
        //            //    BoddoohLabOne.ShowTable(S);

        //        }

        //        CompletedPartLength += 2;
        //        BoddoohLabOne.ShowTable("");
        //    }
        //    String AnswerString = String.Empty;
        //    for (int i = 0; i < UpperHalfLength; i++)
        //        AnswerString += Abjad.GetLetterByMinorAbjadNumber(AnswerLetters[i]);
        //    return AnswerString;

        //}


        //public static void FindAllAnswersTest(bool b, ListBox listAnswers, String QuestionString, int first, int second, int prelast, int last, int masfo)
        //{
        //    int Length = QuestionString.Length;
        //    OutputLettersElements = GenerateOutputLettersElements(first, second, Length);
        //    MinorAbjadSummationForTheQuestion = Abjad.MinorAbjadSummation(QuestionString);
        //    MajorAbjadSummationForTheQuestion = Abjad.MajorAbjadSummation(QuestionString);
        //    MinorAbjadSummationForTheAnswer = FindMinorAbjadSummationForTheAnswer(MinorAbjadSummationForTheQuestion, OutputLettersElements);

        //    int[] QuestionLetters = new int[Length];
        //    int[] AnswerLetters = new int[Length];
        //    for (int i = 0; i < Length; i++)
        //    {
        //        QuestionLetters[i] = Abjad.MinorAbjadNumber(QuestionString[i]);
        //        AnswerLetters[i] = 0;
        //    }

        //    ArrayList result = new ArrayList();

        //    AnswerLetters[0] = first; AnswerLetters[1] = second; AnswerLetters[Length - 2] = prelast; AnswerLetters[Length - 1] = last;

        //    int AnswerCandidatesForRightLength = (Length - 4) / 2; if (Length % 2 == 1) AnswerCandidatesForRightLength++;
        //    int[] AnswerCandidatesForRight = new int[AnswerCandidatesForRightLength]; int[] AnswerCandidatesForLeft = new int[(Length - 4) / 2];
        //    ArrayList[] LeftCounterparts = new ArrayList[(Length - 4) / 2];

        //    for (int i = 0; i < AnswerCandidatesForRight.Length; i++)
        //        AnswerCandidatesForRight[i] = 0;
        //    bool DoneRight = false;
        //    int Count = 0, Count2 = 0;

        //    OutputFile OF = new OutputFile(QuestionString + ".txt"); OF.Open();
        //    while (!DoneRight)
        //    {
        //        for (int index = 0; index < AnswerCandidatesForRight.Length; index++)
        //        {
        //            AnswerLetters[2 + index] = AnswerCandidatesForRight[index] * BoddoohNumbers.Four + Abjad.ElementalOrder(OutputLettersElements[2 + index]);
        //            if (Length % 2 == 0 || index < AnswerCandidatesForRightLength - 1)
        //                LeftCounterparts[index] = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(2 + index, AnswerLetters[2 + index]);
        //        }

        //        for (int ii = 0; ii < AnswerCandidatesForLeft.Length; ii++)
        //            AnswerCandidatesForLeft[ii] = 0;

        //        bool DoneLeft = false;
        //        while (!DoneLeft)
        //        {
        //            for (int index = 0; index < AnswerCandidatesForLeft.Length; index++)
        //            {
        //                AnswerLetters[Length - 3 - index] = (int)LeftCounterparts[index][AnswerCandidatesForLeft[index]];
        //            }

        //            //if (Length % 2 == 1)
        //            //{
        //            //    int S = 0;
        //            //    for (int index = 0; index < Length; index++)
        //            //    {
        //            //        if (index != (AnswerLetters.Length / 2))
        //            //            S+=AnswerLetters[index];
        //            //    }
        //            //    AnswerLetters[AnswerLetters.Length / 2] = MinorAbjadSummationForTheAnswer - S;
        //            //}

        //            //String aaa = String.Empty;     for (int i = 0; i < AnswerCandidatesForRight.Length; i++) { aaa += (AnswerCandidatesForRight[i].ToString() + " "); }
        //            //aaa += ( " +++ ");        for (int i = 0; i < AnswerCandidatesForLeft.Length; i++) { aaa += (AnswerCandidatesForLeft[i].ToString() + " "); }

        //            // listAnswers.Items.Add(aaa);
        //            bool Ok = BoddoohStairwayLab.DoTheCheckingProcessForTest(QuestionLetters, AnswerLetters);
        //            if (Ok)
        //            {
        //                decimal Sum = 0; decimal Join = 0; int MinorSum = 0; int MajorSum = 0; String AnswerStringL = String.Empty; String AnswerStringN = String.Empty;
        //                for (int i = 0; i < Length; i++)
        //                {
        //                    MinorSum += AnswerLetters[i]; MajorSum += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(AnswerLetters[i]));
        //                    Sum += (AnswerLetters[i] % BoddoohNumbers.Nine);
        //                    Join = MiscMethods.JoinDigits(AnswerLetters[i] % BoddoohNumbers.Nine, Join);
        //                    AnswerStringL += (Abjad.GetLetterByMinorAbjadNumber(AnswerLetters[i]) + " "); AnswerStringN += (Convert.ToString(AnswerLetters[i]) + " ");
        //                }
        //                AnswerStringN += ("[" + MinorSum.ToString() + "], ");
        //                if (MinorSum % BoddoohNumbers.Nine == 2 && (masfo == 0 || masfo == MajorSum))
        //                {
        //                    bool OK2 = false;
        //                    decimal Temp = Sum + Join;
        //                    if (Temp % BoddoohNumbers.TwentyEight == 0 || Temp % BoddoohNumbers.TwentyEight == 20 || Temp % BoddoohNumbers.TwentyEight == 8)
        //                        OK2 = true;
        //                    Temp = Math.Abs(Sum - Join);
        //                    if (Temp % BoddoohNumbers.TwentyEight == 0 || Temp % BoddoohNumbers.TwentyEight == 20 || Temp % BoddoohNumbers.TwentyEight == 8)
        //                        OK2 = true;
        //                    String Msg = AnswerStringN + "\n" + AnswerStringL + "\n";

        //                    Msg += "\n    آیا برنامه ادامه دهد؟  ";
        //                    if (OK2)
        //                    {
        //                        AnswerStringN += ("  *****  ");
        //                        if (Count < 100)
        //                        {
        //                            listAnswers.Items.Add(AnswerStringL); listAnswers.Items.Add(AnswerStringN); listAnswers.Items.Add("");
        //                        }
        //                        Msg += "\n  شرط مورد نظر برقرار است";

        //                        //DialogResult DR = MessageBox.Show(Msg, "", MessageBoxButtons.YesNo);
        //                        //if (DR.ToString() == "No")
        //                        //    DoneRight = true;
        //                        OF.Write(AnswerStringN);
        //                        //OF.Write(AnswerStringL);
        //                        OF.WriteLine("");
        //                        result.Add(AnswerStringN);
        //                        Count++;

        //                    }
        //                    else
        //                    {

        //                        if (!b)
        //                        {
        //                            if (Count < 100)
        //                            {
        //                                listAnswers.Items.Add(AnswerStringL); listAnswers.Items.Add(AnswerStringN); listAnswers.Items.Add("");

        //                            }

        //                            //DialogResult DR = MessageBox.Show(Msg, "", MessageBoxButtons.YesNo);
        //                            //if (DR.ToString() == "No")
        //                            //    DoneRight = true;
        //                            result.Add(AnswerStringN);
        //                            OF.Write(AnswerStringN);
        //                            //OF.Write(AnswerStringL);
        //                            OF.WriteLine("");

        //                            Count++;
        //                        }
        //                    }
        //                    // listAnswers.Items.Add("");
        //                }
        //            }

        //            int k = 0;
        //            while (k < AnswerCandidatesForLeft.Length && AnswerCandidatesForLeft[k] == LeftCounterparts[k].Count - 1)
        //            {
        //                AnswerCandidatesForLeft[k] = 0; k++;
        //            }
        //            if (k == AnswerCandidatesForLeft.Length) DoneLeft = true; else AnswerCandidatesForLeft[k]++;

        //        }

        //        int j = 0;
        //        while (j < AnswerCandidatesForRight.Length && AnswerCandidatesForRight[j] == 6)
        //        {
        //            AnswerCandidatesForRight[j] = 0; j++;
        //        }
        //        if (j == AnswerCandidatesForRight.Length) DoneRight = true; else AnswerCandidatesForRight[j]++;



        //        Count2++;
        //        //if (Count2 % 1000 == 0) MessageBox.Show(Count.ToString() + " .... ");

        //    }
        //    listAnswers.Items.Add("پایان");
        //    MessageBox.Show(Count.ToString() + " چواب یافت شد ");
        //    MessageBox.Show(result.Count.ToString() + " چواب یافت شد... ");
        //    OF.Close();
        //    //return result;
        //}



        

        public static void SortAnswers(ArrayList Answers, int[] questionLetters, Elements[] answerElements, int FromIndex, int ToIndex, byte[] FirstLetters, int FirstLettersCount)
        {
            int Length = questionLetters.Length;
            int Indexxi = FirstLettersCount;
            int Indexxj = FirstLettersCount+1;
            int Cumulative = 0;
            for (int i = 0; i <= Indexxi; i++)
                Cumulative += questionLetters[i];
            Cumulative = MiscMethods.EquivalentNumber(Cumulative);

            Elements xie = answerElements[Indexxi]; Elements xje = answerElements[Indexxj];
            IntQuadruple[] OptionsForTheNextTwoOutputLetters = OrderTuplesBasedOnTheirRanks(Cumulative, questionLetters[Indexxj], xie, xje);
            int Count = 0;
            for (int OptionIndex = 0; OptionIndex < 49; OptionIndex++)
            {
                int StartIndex = FromIndex + Count;
                IntQuadruple IQ = OptionsForTheNextTwoOutputLetters[OptionIndex];
                for (int i = FromIndex; i <= ToIndex; i++)
                {
                    byte[] AnAnswer = (byte[])Answers[i];
                    if (AnAnswer[Indexxi] == IQ.First && AnAnswer[Indexxj] == IQ.Second)
                    {
                        if (FromIndex + Count != i)
                        {
                            byte[] Answer0 = (byte[])Answers[FromIndex + Count];

                            for (int m = 0; m <Length; m++)
                            {
                                byte Temp = AnAnswer[m]; AnAnswer[m] = Answer0[m]; Answer0[m] = Temp;
                            }
                        }
                        Count++;
                    }                   
                }
                int FinishIndex = FromIndex + Count - 1;
                if (FinishIndex > StartIndex && Indexxj < (Length/2)-2)
                {
                    FirstLetters[Indexxi] = (byte)IQ.First; FirstLetters[Indexxj] = (byte)IQ.Second;
                    SortAnswers(Answers, questionLetters, answerElements, StartIndex, FinishIndex, FirstLetters, FirstLettersCount + 2);
                }
            }
        }


        public static void SortOptionsForOnePairBasedOnTheirMinorAbjadSummation(ArrayList OptionsForOnePair)
        {
            for (int i = 0; i < OptionsForOnePair.Count - 1; i++)
            {
                int BestIndex = i;
                IntTuple Best = (IntTuple)OptionsForOnePair[BestIndex];
                int BestMinorAbjadSummation = Best.First + Best.Second;
                for (int j = i + 1; j < OptionsForOnePair.Count; j++)
                {
                    IntTuple Current = (IntTuple)OptionsForOnePair[j];
                    int CurrentMinorAbjadSummation = Current.First + Current.Second;
                    if (CurrentMinorAbjadSummation < BestMinorAbjadSummation)
                    {
                        BestIndex = j;
                        Best = (IntTuple)OptionsForOnePair[BestIndex];
                        BestMinorAbjadSummation = CurrentMinorAbjadSummation;
                    }
                }
                IntTuple Temp = (IntTuple)OptionsForOnePair[i];
                int t = Temp.First; Temp.First = Best.First; Best.First = t;
                t = Temp.Second; Temp.Second = Best.Second; Best.Second = t;
            }
        }

        
        
    }
      
    public class LetterAndNumberEntity
	{
		public char Letter;
		public int Number;
		public LetterAndNumberEntity(char letter, int number)
		{
			this.Letter = letter;		
			this.Number = number;				
		}	
	}

	public enum Elements
	{
		None, Fire, Air, Water, Earth
	}

    public class IntTuple
    {        
        public int First;
        public int Second;
        public IntTuple(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }
    }
    public class IntTriple
    {
        public int First;
        public int Second;
        public int Third;
        public IntTriple(int first, int second, int third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
    }
    public class ArrayPair
    {
        public int[] FirstArray;
        public int[] SecondArray;
        public ArrayPair(int[] first, int[] second)
        {
            this.FirstArray = first;
            this.SecondArray = second;
        }
    }
    public class ObjectTuple
    {
        public object First;
        public object Second;
        public ObjectTuple(object first, object second)
        {
            this.First = first;
            this.Second = second;
        }
    }
    public class IntQuadruple
    {        
        public int First;
        public int Second;
        public int Third;
        public int Forth;
        public IntQuadruple(int first, int second, int third, int forth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Forth = forth;

        }
    }
        
    public class OptionForAColumn
    {
        public int ColumnIndex;
        public int CarryBorrowDigit;
        public int TopDigit;
        public int Middle0Digit;
        public int Middle1Digit;
        public int Middle0CarryBorrowDigit;
        public int Middle1CarryBorrowDigit;
        public OptionForAColumn(int columnIndex, int carryBorrowDigit, int topDigit, int middle0Digit, int middle1Digit, int middle0CarryBorrowDigit, int middle1CarryBorrowDigit)
        {
            this.ColumnIndex = columnIndex;
            this.CarryBorrowDigit = carryBorrowDigit;
            this.TopDigit = topDigit;
            this.Middle0Digit = middle0Digit;
            this.Middle1Digit = middle1Digit;
            this.Middle0CarryBorrowDigit = middle0CarryBorrowDigit;
            this.Middle1CarryBorrowDigit = middle1CarryBorrowDigit;
        }
        public OptionForAColumn Clone()
        {
            return new OptionForAColumn(ColumnIndex, CarryBorrowDigit, TopDigit, Middle0Digit, Middle1Digit, Middle0CarryBorrowDigit, Middle1CarryBorrowDigit);
        }


    }

	#region AbjadLetter
	public class AbjadLetter
	{
		public char Letter;
		public int MinorAbjadNumber;
		public int MajorAbjadNumber;				
		public AbjadLetter(char letter, int minorAbjadNumber, int majorAbjadNumber)
		{
			this.Letter = letter;		
			this.MinorAbjadNumber = minorAbjadNumber;
			this.MajorAbjadNumber = majorAbjadNumber;
		}	
	}
	
	#endregion AbjadLetter

    public class InputManager
    {
        public int a11, a12, a13, a14, a21, a22, a23, a24, a31, a32, a33, a34, a41, a42, a43, a44;
        public int SummationOfColumn1, SummationOfColumn2, SummationOfColumn3, SummationOfColumn4;
        public int SummationOfRow1, SummationOfRow2, SummationOfRow3, SummationOfRow4;
        public int SummationOfItems;

        public InputManager(int x11, int x12, int x13, int x14)
        {
            a11 = x11;
            a12 = x12;
            a13 = x13;
            a14 = x14;
            a22 = a33 = a44 = a11;
            a21 = MiscMethods.EquivalentNumber((a11 + a22) - a12);
            a23 = MiscMethods.EquivalentNumber((a13 + a22) - a12);
            a24 = MiscMethods.EquivalentNumber((a14 + a23) - a13);
            a34 = MiscMethods.EquivalentNumber((a24 + a33) - a23);
            a32 = MiscMethods.EquivalentNumber((a22 + a33) - a23);
            a31 = MiscMethods.EquivalentNumber((a21 + a32) - a22);
            a43 = MiscMethods.EquivalentNumber((a33 + a44) - a34);
            a42 = MiscMethods.EquivalentNumber((a32 + a43) - a33);
            a41 = MiscMethods.EquivalentNumber((a31 + a42) - a32);

            SummationOfColumn1 = (a11 + a21 + a31 + a41);
            SummationOfColumn2 = (a12 + a22 + a32 + a42);
            SummationOfColumn3 = (a13 + a23 + a33 + a43);
            SummationOfColumn4 = (a14 + a24 + a34 + a44);
            SummationOfRow1 = (a11 + a12 + a13 + a14);
            SummationOfRow2 = (a21 + a22 + a23 + a24);
            SummationOfRow3 = (a31 + a32 + a33 + a34);
            SummationOfRow4 = (a41 + a42 + a43 + a44);
            SummationOfItems = SummationOfColumn1 + SummationOfColumn2 + SummationOfColumn3 + SummationOfColumn4;
        }
    }
	
	public class AbjadLookUpTable
	{
		public LetterAndNumberEntity[] Rows = new LetterAndNumberEntity[BoddoohNumbers.TwentyEight];		
		public int GetNumber(char letter)
		{
			for (int i=0;i<BoddoohNumbers.TwentyEight;i++)
			{
				if (Rows[i].Letter == letter) 
					return Rows[i].Number;
			}
			return 0;
		}
		public int GetOrderNumber(char letter)
		{
			if (Abjad.IsAbjabAlphabet(letter))
			{
				int VirtualMajorAbjadNumber = GetNumber(letter);
				char VirtualLetter = Abjad.GetLetterByMajorAbjadNumber(VirtualMajorAbjadNumber);
				return Abjad.MinorAbjadNumber(VirtualLetter);
			}
			return 0;
		}
		
		public int SimpleSummation(string s)
		{
			int result=0;
			//if (BoddoohPartI.IgnoreAdditionalLettersIfMoreThanThreeLetters && s.Length > 3)
			//	s = s.Substring(s.Length-3,3);
			for (int i=0;i<s.Length;i++)
			{
				result += GetNumber(s[i]);				
			}				
			return result;
		}
		public int OrdinalSummation(string s, int IndexOfCompoundLetter)
		{
			int result=0;
			int LengthOfCompoundLetter = s.Length - 2;
			//if (BoddoohPartI.IgnoreAdditionalLettersIfMoreThanThreeLetters && s.Length > 3)
			//	s = s.Substring(s.Length-3,3);			
			
			int index = 0;
			for (int i=0;i<s.Length;i++)
			{
				if (i >= IndexOfCompoundLetter && i<IndexOfCompoundLetter+LengthOfCompoundLetter)
				{
					result += MiscMethods.LeftmostDigit(GetNumber(s[i])) * MiscMethods.TenPowerdN(index);
					if (i==IndexOfCompoundLetter+LengthOfCompoundLetter-1)
						index++;
				}
				else
				{
					result += MiscMethods.LeftmostDigit(GetNumber(s[i])) * MiscMethods.TenPowerdN(index);
					index++;
				}
			}				
			return result;
		}
		public int OrdinalSummation(string s)
		{
			int result=0;
			//if (BoddoohPartI.IgnoreAdditionalLettersIfMoreThanThreeLetters && s.Length > 3)
				//s = s.Substring(s.Length-3,3);
			for (int i=0;i<s.Length;i++)
			{				
				if (i<3) result += MiscMethods.LeftmostDigit(GetNumber(s[i])) * MiscMethods.TenPowerdN(i);
				else result += MiscMethods.LeftmostDigit(GetNumber(s[i])) * MiscMethods.TenPowerdN(2);
			}				
			return result;
		}
	}
		
	public class Abjad
	{		

		public static AbjadLetter[] AbjadLetters;
        public static string[] AbjadLetterFullName;		
		public Abjad()
		{
		}

		public static void InitializeAbjadLetters()
		{
			#region AbjadLetter Initialization
			AbjadLetters = new AbjadLetter[BoddoohNumbers.TwentyEight]; 
			AbjadLetters[0] = new AbjadLetter('ا',1,1);
			AbjadLetters[1] = new AbjadLetter('ب',2,2);
			AbjadLetters[2] = new AbjadLetter('ج',3,3);
			AbjadLetters[3] = new AbjadLetter('د',4,4);
			AbjadLetters[4] = new AbjadLetter('ه',5,5);
			AbjadLetters[5] = new AbjadLetter('و',6,6);
			AbjadLetters[6] = new AbjadLetter('ز',7,7);
			AbjadLetters[7] = new AbjadLetter('ح',8,8);
			AbjadLetters[8] = new AbjadLetter('ط',9,9);
			AbjadLetters[9] = new AbjadLetter('ی',10,10);
			AbjadLetters[10] = new AbjadLetter('ک',11,20);
			AbjadLetters[11] = new AbjadLetter('ل',12,30);
			AbjadLetters[12] = new AbjadLetter('م',13,40);
			AbjadLetters[13] = new AbjadLetter('ن',14,50);
			AbjadLetters[14] = new AbjadLetter('س',15,60);
			AbjadLetters[15] = new AbjadLetter('ع',16,70);
			AbjadLetters[16] = new AbjadLetter('ف',17,80);
			AbjadLetters[17] = new AbjadLetter('ص',18,90);
			AbjadLetters[18] = new AbjadLetter('ق',19,100);
			AbjadLetters[19] = new AbjadLetter('ر',20,200);
			AbjadLetters[20] = new AbjadLetter('ش',21,300);
			AbjadLetters[21] = new AbjadLetter('ت',22,400);
			AbjadLetters[22] = new AbjadLetter('ث',23,500);
			AbjadLetters[23] = new AbjadLetter('خ',24,600);
			AbjadLetters[24] = new AbjadLetter('ذ',25,700);
			AbjadLetters[25] = new AbjadLetter('ض',26,800);
			AbjadLetters[26] = new AbjadLetter('ظ',27,900);
			AbjadLetters[27] = new AbjadLetter('غ',28,1000);
            AbjadLetterFullName = new string[] { "الف", "با", "جیم", "دال", "ها", "واو", "زا", "حا", "طا", "یا", "کاف", "لام", "میم", "نون", "سین", "عین","فا", "صاد", "قاف", "را", "شین", "تا", "ثا", "خا", "ذال", "ضاد", "ظا", "غین"}; 
            
			#endregion AbjadLetter Initialization
		}
		
		public static void Initialize()
		{
			InitializeAbjadLetters();
		}

		public static char GetLetter(int elementalOrder, int elementalFactor)
		{
			int minorAbjadNumber = (elementalOrder-1)*BoddoohNumbers.Four + (elementalFactor/2);
			return GetLetterByMinorAbjadNumber(minorAbjadNumber);
		}

		public static char GetLetterByMinorAbjadNumber(int minorAbjadNumber)
		{
			 return AbjadLetters[minorAbjadNumber-1].Letter;
		}
		public static char GetLetterByMajorAbjadNumber(int majorAbjadNumber)
		{
			for (int i=0;i<BoddoohNumbers.TwentyEight;i++)
			{
				if (AbjadLetters[i].MajorAbjadNumber == majorAbjadNumber) 
					return AbjadLetters[i].Letter;				
			}	
			return ' ';
		}		
		public static int MajorAbjadNumber(char letter)
		{
			for (int i=0;i<BoddoohNumbers.TwentyEight;i++)
			{
				if (AbjadLetters[i].Letter == letter)
					return AbjadLetters[i].MajorAbjadNumber;				
			}	
			return 0;
		}
		public static int MinorAbjadNumber(char letter)
		{
			for (int i=0;i<BoddoohNumbers.TwentyEight;i++)
			{
				if (AbjadLetters[i].Letter == letter)
					return AbjadLetters[i].MinorAbjadNumber;				
			}	
			return 0;
		}
		public static int ElementalOrder(char letter)
		{
			int minorAbjadNumber = Abjad.MinorAbjadNumber(letter);
			if (minorAbjadNumber>=1 && minorAbjadNumber<=BoddoohNumbers.TwentyEight)
			{
				return ((minorAbjadNumber-1) / 4) + 1;
			}	
			return 0;
		}
		public static int ElementalFactor(char letter)
		{
			int minorAbjadNumber = Abjad.MinorAbjadNumber(letter);
			return ElementalFactor(minorAbjadNumber);			
		}

		public static int ElementalFactor(int minorAbjadNumber)
		{			
			if (minorAbjadNumber>=1 && minorAbjadNumber<=BoddoohNumbers.TwentyEight)
			{
				return (((minorAbjadNumber-1) % 4) + 1) * 2;
			}	
			return 0;
		}

		public static int ElementalFactor(Elements element)
		{
			if (element == Elements.Fire) return 2;
			if (element == Elements.Air) return 4;
			if (element == Elements.Water) return 6;			
			if (element == Elements.Earth) return 8;					
			return 0;
        }
        public static int ElementalOrder(Elements element)
        {
            if (element == Elements.Fire) return 1;
            if (element == Elements.Air) return 2;
            if (element == Elements.Water) return 3;
            if (element == Elements.Earth) return 4;
            return 0;
        }

        public static char ElementalLetter(Elements element)
        {
            int n = ElementalOrder(element);
            switch (n)
                {
                    case 1: return 'ف';
                    case 2: return 'ه';
                    case 3: return 'آ';
                    case 4: return 'خ';
                }
            return ' ';
        }

		public static char ElementalLetter(char letter)
		{
			int minorAbjadNumber = Abjad.MinorAbjadNumber(letter);
			if (minorAbjadNumber>=1 && minorAbjadNumber<=BoddoohNumbers.TwentyEight)
			{				
				switch ((minorAbjadNumber-1) % 4)
				{
					case 0: return 'ف';
					case 1: return 'ه';
					case 2: return 'آ';
					case 3: return 'خ';
				}				
			}	
			return ' ';
		}
        public static string LetterFullName(char letter)
        {
            int minorAbjadNumber = Abjad.MinorAbjadNumber(letter);
            if (minorAbjadNumber >= 1 && minorAbjadNumber <= BoddoohNumbers.TwentyEight)
            {
                return AbjadLetterFullName[minorAbjadNumber - 1];
            }
            return "";
        }

        public static string LetterFullName(int minorAbjadNumber)
        {
            if (minorAbjadNumber >= 1 && minorAbjadNumber <= BoddoohNumbers.TwentyEight)
            {
                return AbjadLetterFullName[minorAbjadNumber - 1];
            }
            return "";
        }

		public static Elements GetElementByElementLetter(char ElementalLetter)
		{	
			switch (ElementalLetter)
			{
				case 'ف' : return Elements.Fire;
				case 'ه' : return Elements.Air;
				case 'ا' :case 'آ' : return Elements.Water;
				case 'خ' : return Elements.Earth;
			}							
			return Elements.None;
		}

		public static Elements Element(char letter)
		{
			int minorAbjadNumber = Abjad.MinorAbjadNumber(letter);				
			return Element(minorAbjadNumber);
		}
		public static Elements Element(int minorAbjadNumber)
		{			
			if (minorAbjadNumber>=1 && minorAbjadNumber<=BoddoohNumbers.TwentyEight)
			{				
				switch ((minorAbjadNumber-1) % 4)
				{
					case 0: return Elements.Fire;
					case 1: return Elements.Air;
					case 2: return Elements.Water;
					case 3: return Elements.Earth;
				}				
			}	
			return Elements.None;
		}

		public static int MajorAbjadSummation(string s)
		{
			int result=0;
			for (int i=0;i<s.Length;i++)
			{
				result += MajorAbjadNumber(s[i]);				
			}				
			return result;
		}
		public static int MinorAbjadSummation(string s)
		{
			int result=0;
			for (int i=0;i<s.Length;i++)
			{
				result += MinorAbjadNumber(s[i]);				
			}				
			return result;
		}
		public static bool IsAbjabAlphabet(char letter)
		{
			if (MajorAbjadNumber(letter)>0)
				return true;
			else
				return false;
		}		
		public static bool IsNonAbjabAlphabet(char letter)
		{
			if (letter == 'پ' || letter == 'چ' || letter == 'ژ' || letter == 'گ')
				return true;
			else
				return false;
		}

		public static bool IsAphabet(char letter)
		{
			if (IsAbjabAlphabet(letter) || letter == 'پ' || letter == 'چ' || letter == 'ژ' || letter == 'گ')
				return true;
			else
				return false;
		}

		public static bool ContainsNonAbjabAlphabet(string s)
		{
			for (int i=0;i<s.Length;i++)
			{
				if (IsNonAbjabAlphabet(s[i]))
					return true;
			}				
			return false;
		}
		public static bool ContainsNonAlphabet(string s)
		{
			for (int i=0;i<s.Length;i++)
			{
				if (!IsAphabet(s[i]))
					return true;
			}				
			return false;
		}

        public static string GetMinorAbjadSequence(string s)
        {
            string result = string.Empty;
            string t = MiscMethods.RemoveDelimiters(s);
            if (t.Length > 0)
                result = Convert.ToString(MinorAbjadNumber(t[0]));
            for (int i = 1; i < t.Length; i++)
            {
                result += (" " + Convert.ToString(MinorAbjadNumber(t[i])));
            }
            return result;
        }

        

        public static decimal JoinItemsAndModN(decimal[] Items, int N)
        {
            decimal result = 0;
            decimal ReminderFactor = 1;
            for (int i = 0; i < Items.Length; i++)
            {
                decimal NewItem = Items[i];
                int DigitsCount = MiscMethods.DigitsCount(NewItem);
                ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                result = (ReminderFactor * result + NewItem) % N;
            }
            return result;
        }

        public static int[] GetMinorAbjadSequenceArray(string s)
        {            
            string t = MiscMethods.RemoveDelimiters(s);
            int Length = t.Length;
            int[] result = new int[Length];
            for (int i = 0; i < Length; i++)
                result[i] = (byte)MinorAbjadNumber(t[i]);
            return result;
        }
        public static string InsertDotsIntoAString(string Pattern, string s)
        {
            int index = -1;
            do
            {
                index = Pattern.IndexOf('.', index + 1);
                if (index >= 0)
                    s = s.Substring(0, index) + "." + s.Substring(index, s.Length - index);
            }
            while (index >= 0);
            return s;
        }
        public static string LettersArrayToString(int[] AnswerArray, string PatternWithAstrics)
        {
            string AnswerString = "";
            for (int index = 0; index < AnswerArray.Length; index++)
                AnswerString += Abjad.GetLetterByMinorAbjadNumber(AnswerArray[index]);
            AnswerString = InsertDotsIntoAString(PatternWithAstrics, AnswerString);
            return MiscMethods.PutOneSpaceBetweenAdjacentLetters(AnswerString);
        }
        public static string LettersArrayToString(byte[] AnswerArray, string PatternWithAstrics)
        {
            string AnswerString = "";
            for (int index = 0; index < AnswerArray.Length; index++)
                AnswerString += Abjad.GetLetterByMinorAbjadNumber(AnswerArray[index]);
            AnswerString = InsertDotsIntoAString(PatternWithAstrics, AnswerString);
            return MiscMethods.PutOneSpaceBetweenAdjacentLetters(AnswerString);
        }
        public static string LettersArrayToString(int[] AnswerArray)
        {
            string AnswerString = "";
            for (int index = 0; index < AnswerArray.Length; index++)
                AnswerString += Abjad.GetLetterByMinorAbjadNumber(AnswerArray[index]);
            return MiscMethods.PutOneSpaceBetweenAdjacentLetters(AnswerString);
        }
        public static string LettersArrayToString(byte[] AnswerArray)
        {
            string AnswerString = "";
            for (int index = 0; index < AnswerArray.Length; index++)
                AnswerString += Abjad.GetLetterByMinorAbjadNumber(AnswerArray[index]);
            return MiscMethods.PutOneSpaceBetweenAdjacentLetters(AnswerString);
        }

        public static int MinorAbjadSummation(int[] answerLetters, int FromIndex, int ToIndex)
        {
            int result = 0;
            for (int i = FromIndex; i <= ToIndex; i++)
            {
                result += answerLetters[i];
            }
            return result;
        }

        public static int MajorAbjadSummation(int[] answerLetters, int FromIndex, int ToIndex)
        {
            int result = 0;
            for (int i = FromIndex; i <= ToIndex; i++)
            {
                result += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(answerLetters[i]));
            }
            return result;
        }

	}

    public class BoddoohLab
    {
        public static int Gap = 7;
        public int ColumnsCount;
        public int[,] Middle;
        public int[] Top;
        public int[] Bottom;
        public int[] CarryBorrow;
        public int CompletedPartLengthFromRight;
        public int CompletedPartLengthFromLeft;

        public BoddoohLab(int Length)
        {
            Initialize(Length);
        }
        public ArrayList FindAllDigitTuplesWithTheRightmostDigitOfSummationForRight(int carryDigit, int RightmostDigitOfSummation)
        {
            ArrayList result = new ArrayList();
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                {
                    int s = i + j + carryDigit;
                    if (s % 10 == RightmostDigitOfSummation)
                        result.Add(new IntTuple(i, j));
                }
            return result;
        }

        public ArrayList FindAllDigitTuplesWithTheRightmostDigitOfSummationForLeft(int borrowFromPreviousDigit, int borrowDigit, int RightmostDigitOfSummation)
        {
            ArrayList result = new ArrayList();
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                {
                    int s = i + j + borrowFromPreviousDigit;
                    if (s % 10 == RightmostDigitOfSummation && s / 10 == borrowDigit)
                        result.Add(new IntTuple(i, j));
                }
            return result;
        }




        public int TheMultipleOfNineWithTheRightmostDigit(int RightmostDigit)
        {
            for (int i = 0; i <=81; i+=9)
                if (i % 10 == RightmostDigit)
                    return i;
            return 0;
        }

        public int TheMultipleOfNineWithTheLeftmostDigit(int LeftmostDigit)
        {
            for (int i = 0; i <= 81; i += 9)
                if (MiscMethods.LeftmostDigit(i) == LeftmostDigit)
                    return i;
            return 0;
        }
       
        public int SecondDigitFromLeft(int x)
        {
            if (x < 10) return 0;
            else return x % 10;
        }
        public int SecondDigitFromRight(int x)
        {
            if (x < 10) return 0;
            else return x / 10;
        }   


        public void Initialize(int Length)
        {
            ColumnsCount = 2 * Length + Gap;
            Top = new int[ColumnsCount];
            Bottom = new int[ColumnsCount];
            CarryBorrow = new int[ColumnsCount];
            Middle = new int[2, ColumnsCount];

            for (int j = 0; j < ColumnsCount; j++)
            {
                Top[j] = 0;
                Bottom[j] = 0;
                CarryBorrow[j] = 0;
                for (int i = 0; i < 2; i++)
                    Middle[i, j] = 0;                
            }
            CompletedPartLengthFromRight = 0;
            CompletedPartLengthFromLeft = 0;
        }

        //public void InitializeAllButBottomArrayFromRight()
        //{
        //    for (int j = 0; j < ColumnsCount/2; j++)
        //    {
        //        Top[j] = 0;
        //        CarryBorrow[j] = 0;
        //        for (int i = 0; i < 2; i++)
        //            Middle[i, j] = 0;
        //    }
        //}
        //public void InitializeAllButBottomArrayFromLeft()
        //{
        //    for (int k = 0; k < ColumnsCount / 2; k++)
        //    {
        //        int j = ColumnsCount - 1 - k;
        //        Top[j] = 0;
        //        CarryBorrow[j] = 0;
        //        for (int i = 0; i < 2; i++)
        //            Middle[i, j] = 0;
        //    }
        //}


        //public void ShowTable(String Title)
        //{
        //    String Line1 = "";
        //    String Line2 = "";
        //    String Line3 = "";
        //    String Line4 = "";
        //    int Sp = 1;
            
        //    for (int i = Top.Length - 1; i >= 0; i--)
        //    {
        //        Line1 += Top[i].ToString(); while (Line1.Length % Sp != 0) Line1 += " ";
        //        Line2 += Middle[0, i].ToString(); while (Line2.Length % Sp != 0) Line2 += " ";
        //        Line3 += Middle[1, i].ToString(); while (Line3.Length % Sp != 0) Line3 += " " ;
        //        Line4 += Bottom[i].ToString(); while (Line4.Length % Sp != 0) Line4 += " ";
        //    }

        //    String Message = Title + ":\n" + Line1 + "\n" + Line2 + "\n" + Line3 + "\n" + Line4;
        //    MessageBox.Show(Message);

        //}
        //public int CalculateSummationOfColumnForMiddle(int ColumnIndex)
        //{
        //    int result = 0;
        //    for (int i = 0; i < 2; i++)
        //        result += Middle[i, ColumnIndex];
        //    return result;
        //}

        //public bool SummationOfAColumnForMiddleIsOK(int SummationOfColumn)
        //{
        //    if (SummationOfColumn == 0 || SummationOfColumn == 2 || SummationOfColumn == 8 || SummationOfColumn == 11)
        //        return true;
        //    else
        //        return false;
        //}
        //public bool SummationOfTwoColumnsForMiddleIsOK(int SummationOfTwoColumns)
        //{
        //    if (SummationOfTwoColumns ==  11 || SummationOfTwoColumns == 22)
        //        return true;
        //    else
        //        return false;
        //}

        //public bool CheckSummationOfColumnsForRight(int length)
        //{
        //    int PreviousNonOKColumnSummation = 0;
        //    for (int j = 0; j < length; j++)
        //    {
        //        int SummationOfColumn = CalculateSummationOfColumnForMiddle(j);
        //        if (SummationOfTwoColumnsForMiddleIsOK(PreviousNonOKColumnSummation + SummationOfColumn))
        //        {
        //            PreviousNonOKColumnSummation = 0;
        //        }
        //        else
        //        {
        //            if (!SummationOfAColumnForMiddleIsOK(SummationOfColumn))
        //            { 
        //                if (PreviousNonOKColumnSummation==0)
        //                {
        //                    PreviousNonOKColumnSummation = SummationOfColumn;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public bool CheckSummationOfColumnsForAll(int r, int l)
        //{
             
        //    int PreviousNonOKColumnSummation = 0;
        //    for (int j = 0; j < ColumnsCount; )
        //    {
        //        int SummationOfColumn = CalculateSummationOfColumnForMiddle(j);
        //        if (SummationOfTwoColumnsForMiddleIsOK(PreviousNonOKColumnSummation + SummationOfColumn))
        //        {
        //            PreviousNonOKColumnSummation = 0;
        //        }
        //        else
        //        {
        //            if (!SummationOfAColumnForMiddleIsOK(SummationOfColumn))
        //            {
        //                if (PreviousNonOKColumnSummation == 0)
        //                {
        //                    PreviousNonOKColumnSummation = SummationOfColumn;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        if (j < r) j++;
        //        if (j >= r && j<l) j = l;
        //        if (j >= l) j++;
        //    }
        //    return true;
        //}

        //public bool CheckSummationOfColumnsForLeft(int length)
        //{
        //    int PreviousNonOKColumnSummation = 0;
        //    for (int k = 0; k < length; k++)
        //    {
        //        int j = ColumnsCount - 1 - k;
        //        int SummationOfColumn = CalculateSummationOfColumnForMiddle(j);
        //        if (SummationOfTwoColumnsForMiddleIsOK(PreviousNonOKColumnSummation + SummationOfColumn))
        //        {
        //            PreviousNonOKColumnSummation = 0;
        //        }
        //        else
        //        { 
        //            if (!SummationOfAColumnForMiddleIsOK(SummationOfColumn))
        //            {
        //                if (PreviousNonOKColumnSummation == 0)
        //                {
        //                    PreviousNonOKColumnSummation = SummationOfColumn;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public void StartOrContinueTheBottomFromRightWithTheDigits(int FromIndex, int digits)
        //{
        //    int i = FromIndex;
        //    while (digits > 0)
        //    {
        //        Bottom[i] = digits % 10;
        //        digits = digits / 10;
        //        i++;
        //    }
        //}
        //public void StartOrContinueTheBottomFromLefttWithTheDigits(int FromIndex, int digits)
        //{
        //    int digitsCount = MiscMethods.DigitsCount(digits);
        //    int i = FromIndex - digitsCount + 1;
        //    while (digits > 0)
        //    {
        //        Bottom[i] = digits % 10;
        //        digits = digits / 10;
        //        i++;
        //    }
        //}
        //public void ClearAllColumnExceptTheTopCell(int completedPartLength, int digits)
        //{
        //    int i = completedPartLength;
        //    while (digits > 0)
        //    {
        //        Bottom[i] = digits % 10;
        //        digits = digits / 10;
        //        i++;
        //    }
        //}

        public int PushAllOptionsForAColumnIntoStackForRight(Stack S, int ColumnIndex)
        {
            int BottomDigit = Bottom[ColumnIndex];
            int middle0Digit = Middle[0, ColumnIndex];
            int middle1Digit = Middle[1, ColumnIndex];
            int carryDigit = CarryBorrow[ColumnIndex];
            int Sum = middle0Digit + middle1Digit + carryDigit;
            int newMiddle0Digit = 0, newMiddle1Digit = 0, newMiddle0CarryDigit = 0, newMiddle1CarryDigit = 0;

            int OptionsCount = 0;
            if (middle0Digit != 0 && middle1Digit != 0)
            {
                if (Sum % 10 == BottomDigit)
                {                    
                    OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, carryDigit, 0, middle0Digit, middle1Digit, 0, 0);
                    S.Push(AnOption);
                    OptionsCount++;
                }
            }
            else
            {
                if (middle0Digit != 0 || middle1Digit != 0)
                {


                    for (int digit = 0; digit < 10; digit++)
                        if ((Sum + digit) % 10 == BottomDigit)
                        {

                            OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, carryDigit, digit, middle0Digit, middle1Digit, 0, 0);
                                S.Push(AnOption);
                                OptionsCount++;
                            
                        }

                    for (int digit = 0; digit < 10; digit++)
                        if ((Sum + digit) % 10 == BottomDigit)
                        {
                            if (middle0Digit == 0)
                            {
                                newMiddle0Digit = digit;
                                newMiddle1Digit = middle1Digit;
                                newMiddle0CarryDigit = TheMultipleOfNineWithTheRightmostDigit(newMiddle0Digit) / 10;
                                newMiddle1CarryDigit = 0;
                            }
                            if (middle1Digit == 0)
                            {
                                newMiddle0Digit = middle0Digit;
                                newMiddle1Digit = digit;
                                newMiddle0CarryDigit = 0;
                                newMiddle1CarryDigit = TheMultipleOfNineWithTheRightmostDigit(newMiddle1Digit) / 10;
                            }

                            OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, carryDigit, 0, newMiddle0Digit, newMiddle1Digit, newMiddle0CarryDigit, newMiddle1CarryDigit);
                            S.Push(AnOption);
                            OptionsCount++;

                           
                        }


                }
                else
                {



                    ArrayList SatisfyingTuples = FindAllDigitTuplesWithTheRightmostDigitOfSummationForRight(carryDigit, BottomDigit);
                    for (int i = 0; i < SatisfyingTuples.Count; i++)
                    {
                        IntTuple ASatisfyingTuple = (IntTuple)SatisfyingTuples[i];
                        int first = (int)ASatisfyingTuple.First;
                        int second = (int)ASatisfyingTuple.Second;

                        newMiddle0Digit = first;
                        newMiddle1Digit = second;
                        newMiddle1CarryDigit = TheMultipleOfNineWithTheRightmostDigit(newMiddle1Digit) / 10;


                        OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, carryDigit, first, 0, newMiddle1Digit, 0, newMiddle1CarryDigit);
                            S.Push(AnOption);
                            OptionsCount++;
                        
                    }

                    for (int i = 0; i < SatisfyingTuples.Count; i++)
                    {
                        IntTuple ASatisfyingTuple = (IntTuple)SatisfyingTuples[i];
                        int first = (int)ASatisfyingTuple.First;
                        int second = (int)ASatisfyingTuple.Second;

                        newMiddle0Digit = first;
                        newMiddle1Digit = second;
                        newMiddle0CarryDigit = TheMultipleOfNineWithTheRightmostDigit(newMiddle0Digit) / 10;
                        newMiddle1CarryDigit = TheMultipleOfNineWithTheRightmostDigit(newMiddle1Digit) / 10;
                        OptionForAColumn AnOption = null;
                        if (newMiddle0CarryDigit == 0 || newMiddle1CarryDigit == 0)
                        {
                            AnOption = new OptionForAColumn(ColumnIndex, carryDigit, 0, newMiddle0Digit, newMiddle1Digit, newMiddle0CarryDigit, newMiddle1CarryDigit);
                            S.Push(AnOption);
                            OptionsCount++;
                        }

                    }


                }
            }
            return OptionsCount;
        }

        //public int PushAllOptionsForAColumnIntoStackForLeft(Stack S, int ColumnIndex)
        //{
        //    int BottomDigit = Bottom[ColumnIndex];
        //    int middle0Digit = Middle[0, ColumnIndex];
        //    int middle1Digit = Middle[1, ColumnIndex];
        //    int BorrowDigit = CarryBorrow[ColumnIndex];
        //    int Sum = middle0Digit + middle1Digit;
        //    int newMiddle0Digit = 0, newMiddle1Digit = 0, newMiddle0BorrowDigit = 0, newMiddle1BorrowDigit = 0;

        //    int OptionsCount = 0;
        //    if (middle0Digit != 0 && middle1Digit != 0)
        //    {
        //        if ((Sum % 10 == BottomDigit && Sum / 10 == BorrowDigit) || ((Sum + 1) % 10 == BottomDigit && (Sum + 1) / 10 == BorrowDigit))
        //        {
        //            OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, BorrowDigit, 0, middle0Digit, middle1Digit, 0, 0);
        //            S.Push(AnOption);
        //            OptionsCount++;
        //        }
        //    }
        //    else
        //    {
        //        if (middle0Digit != 0 || middle1Digit != 0)
        //        {





        //            for (int digit = 0; digit < 10; digit++)
        //                if (
        //                    ((Sum + digit) % 10 == BottomDigit && (Sum + digit) / 10 == BorrowDigit)                                                
        //                    || 
        //                    ((Sum + 1 + digit) % 10 == BottomDigit && (Sum + 1 + digit) / 10 == BorrowDigit)
        //                    )
        //                {
                         
        //                        OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, BorrowDigit, digit, middle0Digit, middle1Digit, 0, 0);
        //                        S.Push(AnOption);
        //                        OptionsCount++;
                            
        //                }


        //            for (int digit = 0; digit < 10; digit++)
        //                if (
        //                    ((Sum + digit) % 10 == BottomDigit && (Sum + digit) / 10 == BorrowDigit)
        //                    ||
        //                    ((Sum + 1 + digit) % 10 == BottomDigit && (Sum + 1 + digit) / 10 == BorrowDigit)
        //                    )
        //                {
        //                    if (middle0Digit == 0)
        //                    {
        //                        newMiddle0Digit = digit;
        //                        newMiddle1Digit = middle1Digit;
        //                        newMiddle0BorrowDigit = SecondDigitFromLeft(TheMultipleOfNineWithTheLeftmostDigit(newMiddle0Digit));
        //                        newMiddle1BorrowDigit = 0;
        //                    }
        //                    if (middle1Digit == 0)
        //                    {
        //                        newMiddle0Digit = middle0Digit;
        //                        newMiddle1Digit = digit;
        //                        newMiddle0BorrowDigit = 0;
        //                        newMiddle1BorrowDigit = SecondDigitFromLeft(TheMultipleOfNineWithTheLeftmostDigit(newMiddle1Digit));
        //                    }

        //                    OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, BorrowDigit, 0, newMiddle0Digit, newMiddle1Digit, newMiddle0BorrowDigit, newMiddle1BorrowDigit);
        //                    S.Push(AnOption);
        //                    OptionsCount++;
                            
        //                }





        //        }
        //        else
        //        {



        //            for (int BorrowFromPreviouDigit = 0; BorrowFromPreviouDigit<2; BorrowFromPreviouDigit++)
        //            {
        //                ArrayList SatisfyingTuples = FindAllDigitTuplesWithTheRightmostDigitOfSummationForLeft(BorrowFromPreviouDigit, BorrowDigit, BottomDigit);
        //                for (int i = 0; i < SatisfyingTuples.Count; i++)
        //                {
        //                    IntTuple ASatisfyingTuple = (IntTuple)SatisfyingTuples[i];
        //                    int first = (int)ASatisfyingTuple.First;
        //                    int second = (int)ASatisfyingTuple.Second;

        //                    newMiddle1Digit = second;
        //                    newMiddle1BorrowDigit = SecondDigitFromLeft(TheMultipleOfNineWithTheLeftmostDigit(newMiddle1Digit));

        //                        OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, BorrowDigit, first, 0, newMiddle1Digit, 0, newMiddle1BorrowDigit);
        //                        S.Push(AnOption);
        //                        OptionsCount++;
        //                }
        //            }
        //            for (int BorrowFromPreviouDigit = 0; BorrowFromPreviouDigit < 2; BorrowFromPreviouDigit++)
        //            {
        //                ArrayList SatisfyingTuples = FindAllDigitTuplesWithTheRightmostDigitOfSummationForLeft(BorrowFromPreviouDigit, BorrowDigit, BottomDigit);
        //                for (int i = 0; i < SatisfyingTuples.Count; i++)
        //                {
        //                    IntTuple ASatisfyingTuple = (IntTuple)SatisfyingTuples[i];
        //                    int first = (int)ASatisfyingTuple.First;
        //                    int second = (int)ASatisfyingTuple.Second;

        //                    newMiddle0Digit = first;
        //                    newMiddle1Digit = second;
        //                    newMiddle0BorrowDigit = SecondDigitFromLeft(TheMultipleOfNineWithTheLeftmostDigit(newMiddle0Digit));
        //                    newMiddle1BorrowDigit = SecondDigitFromLeft(TheMultipleOfNineWithTheLeftmostDigit(newMiddle1Digit));
        //                    if (newMiddle0BorrowDigit == 0 || newMiddle1BorrowDigit == 0)
        //                    {

        //                        OptionForAColumn AnOption = new OptionForAColumn(ColumnIndex, BorrowDigit, 0, newMiddle0Digit, newMiddle1Digit, newMiddle0BorrowDigit, newMiddle1BorrowDigit);
        //                        S.Push(AnOption);
        //                        OptionsCount++;
        //                    }

        //                }
        //            }





        //        }
        //    }
        //    return OptionsCount;
        //}

        //public void ApplyAnOptionOnItsColumnForRight(OptionForAColumn AnOption)
        //{
        //    int ColumnIndex = AnOption.ColumnIndex;
        //    Top[ColumnIndex] = AnOption.TopDigit;
        //    Middle[0, ColumnIndex] = AnOption.Middle0Digit;
        //    Middle[1, ColumnIndex] = AnOption.Middle1Digit;
        //    Middle[0, ColumnIndex+1] = AnOption.Middle0CarryBorrowDigit;
        //    Middle[1, ColumnIndex+1] = AnOption.Middle1CarryBorrowDigit;
        //    CarryBorrow[ColumnIndex] = AnOption.CarryBorrowDigit;
        //}

        //public void ApplyAnOptionOnItsColumnForLeft(OptionForAColumn AnOption)
        //{
        //    int ColumnIndex = AnOption.ColumnIndex;
        //    Top[ColumnIndex] = AnOption.TopDigit;
        //    Middle[0, ColumnIndex] = AnOption.Middle0Digit;
        //    Middle[1, ColumnIndex] = AnOption.Middle1Digit;
        //    Middle[0, ColumnIndex - 1] = AnOption.Middle0CarryBorrowDigit;
        //    Middle[1, ColumnIndex - 1] = AnOption.Middle1CarryBorrowDigit;
        //    CarryBorrow[ColumnIndex] = AnOption.CarryBorrowDigit;
        //}

        //public void SetCarryForNextColumn(int ColumnIndex)
        //{
        //    int Sum = Top[ColumnIndex] + CarryBorrow[ColumnIndex] + Middle[0, ColumnIndex] + Middle[1, ColumnIndex];
        //    int CarryForNextColumn = Sum / 10;
        //    CarryBorrow[ColumnIndex + 1] = CarryForNextColumn;
        //}

        //public void SetBorrowForPreviousColumn(int ColumnIndex)
        //{
        //    int Sum = Top[ColumnIndex] + Middle[0, ColumnIndex] + Middle[1, ColumnIndex];
        //    int BorrowForPreviousColumn = 0;
        //    if ((Sum + 1) % 10 == Bottom[ColumnIndex])
        //        BorrowForPreviousColumn = 1;
        //    CarryBorrow[ColumnIndex - 1] = BorrowForPreviousColumn;
        //}

        //public bool TryToStartOrContinueFromRightWithTheDigitsButMakeNoChangesIfNotPossible(int digits)
        //{
        //    BoddoohLab BL = this.Clone();
        //    bool result = BL.TryToStartOrContinueFromRightWithTheDigits(digits);
        //    if (result)
        //        TryToStartOrContinueFromRightWithTheDigits(digits);
        //    return result;
        //}

        //public bool TryToStartOrContinueFromLeftWithTheDigitsButMakeNoChangesIfNotPossible(int digits)
        //{
        //    BoddoohLab BL = this.Clone();
        //    bool result = BL.TryToStartOrContinueFromLeftWithTheDigits(digits);
        //    if (result)
        //        TryToStartOrContinueFromLeftWithTheDigits(digits);
        //    return result;
        //}

        //public bool CheckIfItsPossibleToStartOrContinueFromRightWithTheDigitsButMakeNoChanges(int digits)
        //{
        //    BoddoohLab BL = this.Clone();
        //    bool result = BL.TryToStartOrContinueFromRightWithTheDigits(digits);
        //    return result;
        //}

        //public bool CheckIfItsPossibleToStartOrContinueFromLeftWithTheDigitsButMakeNoChanges(int digits)
        //{
        //    BoddoohLab BL = this.Clone();
        //    bool result = BL.TryToStartOrContinueFromLeftWithTheDigits(digits);
        //    return result;
        //}

        //public bool TryToStartOrContinueFromRightWithTheDigits(int digits)
        //{
        //    int NewCompletedPartLength = CompletedPartLengthFromRight + MiscMethods.DigitsCount(digits);
        //    StartOrContinueTheBottomFromRightWithTheDigits(digits);
        //    //ShowTable();
        //    InitializeAllButBottomArrayFromRight();
        //    //if (completedPartLength == 0 & != 0)
        //    //throw new Exception("Error In TryToStartOrContinueWithTheLetters");                

        //    Stack OptionsStack = new Stack();
        //    int ColumnIndex = CompletedPartLengthFromRight;
        //    int OptionsCount = PushAllOptionsForAColumnIntoStackForRight(OptionsStack, 0);
        //    if (OptionsCount == 0)
        //        return false;

        //    while (OptionsStack.Count > 0)
        //    {
        //        OptionForAColumn AnOption = (OptionForAColumn)OptionsStack.Pop();
        //        ApplyAnOptionOnItsColumnForRight(AnOption);
        //        SetCarryForNextColumn(AnOption.ColumnIndex);
        //        int length = AnOption.ColumnIndex + 1;
        //        if (AnOption.ColumnIndex + 1 == NewCompletedPartLength)
        //        {
        //            bool Acceptable = CheckSummationOfColumnsForRight(length);
        //            //Acceptable = Acceptable && Boddooh.CheckValidityOfTopArrayForRight(this, NewCompletedPartLength);
        //            if (Acceptable)
        //            {
        //                CompletedPartLengthFromRight = NewCompletedPartLength;
        //                //ShowTable("4!");
        //                if (digits == 191)
        //                    ShowTable("191");
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            bool Acceptable = CheckSummationOfColumnsForRight(length);
        //            if (Acceptable)
        //            {
        //                ShowTable((AnOption.ColumnIndex + 1).ToString());
        //                PushAllOptionsForAColumnIntoStackForRight(OptionsStack, AnOption.ColumnIndex + 1);
        //            }
        //        }
        //        // ShowTable();
        //    }
        //    return false;
        //}

        //public IntQuadruple[] SaveColumnsForRight(int FromIndex, int Count, int PreviousNonOKColumnSummation, OptionForAColumn Option)
        //{
        //    IntQuadruple[] result = new IntQuadruple[Count+3];
        //    int TopNonZeroCount = 0;
        //    for (int i = 0; i < Count; i++)
        //    {
        //        IntQuadruple IQ = new IntQuadruple(CarryBorrow[FromIndex + i], Top[FromIndex + i], Middle[0, FromIndex + i], Middle[1, FromIndex + i]);
        //        result[i] = IQ;
        //        if (Top[FromIndex + i] > 0 && i < Count - 1)
        //            TopNonZeroCount++;
        //    }
        //    result[Count] = new IntQuadruple(PreviousNonOKColumnSummation, TopNonZeroCount, 0, 0);
        //    result[Count + 1] = new IntQuadruple(Option.CarryBorrowDigit, Option.TopDigit, Option.Middle0Digit, Option.Middle1Digit);
        //    result[Count + 2] = new IntQuadruple(0, 0, Option.Middle0CarryBorrowDigit, Option.Middle1CarryBorrowDigit);

        //    return result;
        //}

        //public void ShowColumnsDataForLeft(IntQuadruple[] ColumnsData)
        //{
        //    int Count = ColumnsData.Length;
        //    String S = "";
        //    for (int i = 0; i < Count; i++)
        //        S+= (" " +ColumnsData[i].First.ToString());
        //    S += "\n";
        //    for (int i = 0; i < Count; i++)
        //        S+= (" " +ColumnsData[i].Second.ToString());
        //    S += "\n";
        //    for (int i = 0; i < Count; i++)
        //        S+= (" " +ColumnsData[i].Third.ToString());
        //    S += "\n";
        //    for (int i = 0; i < Count; i++)
        //        S+= (" " +ColumnsData[i].Forth.ToString());
        //    S += "\n";
        //    MessageBox.Show(S);
        //}
        //public void ShowColumnsDataForRight(IntQuadruple[] ColumnsData)
        //{
        //    int Count = ColumnsData.Length;
        //    String S = "";
        //    for (int i = Count - 1; i >= 0; i--)
        //        S += (" " + ColumnsData[i].First.ToString());
        //    S += "\n";
        //    for (int i = Count - 1; i >= 0; i--)
        //        S += (" " + ColumnsData[i].Second.ToString());
        //    S += "\n";
        //    for (int i = Count - 1; i >= 0; i--)
        //        S += (" " + ColumnsData[i].Third.ToString());
        //    S += "\n";
        //    for (int i = Count - 1; i >= 0; i--)
        //        S += (" " + ColumnsData[i].Forth.ToString());
        //    S += "\n";
        //    MessageBox.Show(S);
        //}

        //public void UseSavedColumnsForRight(int FromIndex, IntQuadruple[] ColumnsData)
        //{
        //    int Count = ColumnsData.Length-1; 
        //    for (int i = 0; i < Count-2; i++)
        //    {
        //        CarryBorrow[FromIndex + i] = ColumnsData[i].First;
        //        Top[FromIndex + i] = ColumnsData[i].Second;
        //        Middle[0, FromIndex + i] = ColumnsData[i].Third;
        //        Middle[1, FromIndex + i] = ColumnsData[i].Forth;
        //    }
        //}
        //public void UseSavedColumnsForLeft(int FromIndex, IntQuadruple[] ColumnsData)
        //{
        //    int Count = ColumnsData.Length-1;
        //    for (int i = 0; i < Count-2; i++)
        //    {
        //        CarryBorrow[FromIndex - i] = ColumnsData[i].First;
        //        Top[FromIndex - i] = ColumnsData[i].Second;
        //        Middle[0, FromIndex - i] = ColumnsData[i].Third;
        //        Middle[1, FromIndex - i] = ColumnsData[i].Forth;
        //    }
        //}

        //public IntQuadruple[] SaveColumnsForLeft(int FromIndex, int Count, int PreviousNonOKColumnSummation, OptionForAColumn Option)
        //{
        //    IntQuadruple[] result = new IntQuadruple[Count+3];
        //    int TopNonZeroCount = 0;
        //    for (int i = 0; i < Count; i++)
        //    {
        //        IntQuadruple IQ = new IntQuadruple(CarryBorrow[FromIndex - i], Top[FromIndex - i], Middle[0, FromIndex - i], Middle[1, FromIndex - i]);
        //        result[i] = IQ;
        //        if (Top[FromIndex - i] > 0 && i < Count - 1)
        //            TopNonZeroCount++;

        //    }
        //    result[Count] = new IntQuadruple(PreviousNonOKColumnSummation, TopNonZeroCount, 0, 0);
        //    result[Count + 1] = new IntQuadruple(Option.CarryBorrowDigit, Option.TopDigit, Option.Middle0Digit, Option.Middle1Digit);
        //    result[Count + 2] = new IntQuadruple(0, 0, Option.Middle0CarryBorrowDigit, Option.Middle1CarryBorrowDigit);
        //    return result;
        //}

        //public int NonOKColumnsCountForRight(int FromIndex, int ColumnsCount)
        //{
        //    int Count = 0;
        //    for (int i = 0; i < ColumnsCount; i++)
        //    {
        //        int SummationOfColumn = CalculateSummationOfColumnForMiddle(FromIndex+i);
        //        if (!SummationOfAColumnForMiddleIsOK(SummationOfColumn))
        //            Count++;
        //    }
        //    return Count;
        //}
        //public int NonOKColumnsCountForLeft(int FromIndex, int ColumnsCount)
        //{
        //    int Count = 0;
        //    for (int i = 0; i < ColumnsCount; i++)
        //    {
        //        int SummationOfColumn = CalculateSummationOfColumnForMiddle(FromIndex - i);
        //        if (!SummationOfAColumnForMiddleIsOK(SummationOfColumn))
        //            Count++;
        //    }
        //    return Count;
        //}


        //public ArrayList FindTheSetOfAllFillingOptionsForMiddle(int FromRightIndex, int ToLeftIndex, int MiddleDigits)
        //{
        //    ArrayList result = new ArrayList();
        //    int DigitsCount = MiscMethods.DigitsCount(MiddleDigits);
        //    int NewCompletedPartLength = FromRightIndex + DigitsCount;
        //    StartOrContinueTheBottomFromRightWithTheDigits(FromRightIndex, MiddleDigits);

        //    Stack OptionsStack = new Stack();
        //    int ColumnIndex = FromRightIndex;
        //    int OptionsCount = PushAllOptionsForAColumnIntoStackForRight(OptionsStack, ColumnIndex);
        //    if (OptionsCount == 0)
        //        return result;

        //    OptionForAColumn[] SuitableOptions = new OptionForAColumn[DigitsCount];

        //    while (OptionsStack.Count > 0)
        //    {
        //        OptionForAColumn AnOption = (OptionForAColumn)OptionsStack.Pop();
        //        ApplyAnOptionOnItsColumnForRight(AnOption);
        //        SuitableOptions[AnOption.ColumnIndex - FromRightIndex] = AnOption.Clone();
        //        SetCarryForNextColumn(AnOption.ColumnIndex);
        //        int NewLength = AnOption.ColumnIndex + 1;
        //        if (NewLength == NewCompletedPartLength)
        //        {
        //            if (CheckSummationOfColumnsForAll(FromRightIndex + DigitsCount - 1, ToLeftIndex+1))
        //            {                        
        //                IntQuadruple[] Temp = SaveColumnsForRight(FromRightIndex, DigitsCount + 1, 0, SuitableOptions[SuitableOptions.Length - 2]);
        //                result.Add(Temp);
        //            }

        //        }
        //        else
        //        {
        //            if (CheckSummationOfColumnsForRight(NewLength))
        //                PushAllOptionsForAColumnIntoStackForRight(OptionsStack, NewLength);
        //        }
        //    }
        //    return result;
        //}

        //        public ArrayList FindTheSetOfAllFillingOptionsForRight(int FromIndex, int digits)
        //{
        //   // if (digits == 1911)
        //        //ShowTable("??");
        //    ArrayList result = new ArrayList();
        //    int DigitsCount = MiscMethods.DigitsCount(digits);
        //    int NewCompletedPartLength = FromIndex + DigitsCount;
        //    StartOrContinueTheBottomFromRightWithTheDigits(FromIndex, digits);

        //    Stack OptionsStack = new Stack();
        //    int ColumnIndex = FromIndex;
        //    int OptionsCount = PushAllOptionsForAColumnIntoStackForRight(OptionsStack, ColumnIndex);
        //    if (OptionsCount == 0)
        //        return result;

        //    OptionForAColumn[] SuitableOptions = new OptionForAColumn[DigitsCount];

        //    while (OptionsStack.Count > 0)
        //    {
        //        OptionForAColumn AnOption = (OptionForAColumn) OptionsStack.Pop();
        //        ApplyAnOptionOnItsColumnForRight(AnOption);
        //        SuitableOptions[AnOption.ColumnIndex - FromIndex] = AnOption.Clone();
        //        SetCarryForNextColumn(AnOption.ColumnIndex);
        //        int NewLength = AnOption.ColumnIndex + 1;
        //        if (NewLength == NewCompletedPartLength)
        //        {
        //            if (CheckSummationOfColumnsForRight(NewLength))
        //            {
        //                int NonOKColumnsCount = NonOKColumnsCountForRight(FromIndex, DigitsCount);
        //                IntQuadruple[] Temp = SaveColumnsForRight(FromIndex, DigitsCount + 1, NonOKColumnsCount, SuitableOptions[SuitableOptions.Length - 2]);
        //                result.Add(Temp);

        //                //ShowColumnsDataForRight(SaveColumnsForRight(FromIndex, DigitsCount));
        //            }
                   
        //        }
        //        else
        //        {
        //            if (CheckSummationOfColumnsForRight(NewLength))
        //            {
        //                //if (OptionsStack.Count == 0)
        //                //{
        //                //    int i = 0;

        //                //}
        //                PushAllOptionsForAColumnIntoStackForRight(OptionsStack, NewLength);
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public ArrayList FindTheSetOfAllFillingOptionsForLeft(int FromIndex, int digits)
        //{
        //    //if (digits == 4192)
        //     //   ShowTable("0?");

        //    ArrayList result = new ArrayList();
        //    int DigitsCount = MiscMethods.DigitsCount(digits);
        //    int NewCompletedPartLength = ColumnsCount - 1- (FromIndex - DigitsCount);
        //    StartOrContinueTheBottomFromLefttWithTheDigits(FromIndex, digits);

        //    Stack OptionsStack = new Stack();
        //    int ColumnIndex = FromIndex;
        //    int OptionsCount = PushAllOptionsForAColumnIntoStackForLeft(OptionsStack, ColumnIndex);
        //    if (OptionsCount == 0)
        //        return result;

        //    OptionForAColumn[] SuitableOptions = new OptionForAColumn[DigitsCount];

        //    while (OptionsStack.Count > 0)
        //    {
        //        OptionForAColumn AnOption = (OptionForAColumn)OptionsStack.Pop();
        //        ApplyAnOptionOnItsColumnForLeft(AnOption);
        //        SuitableOptions[FromIndex-AnOption.ColumnIndex] = AnOption.Clone();
        //        SetBorrowForPreviousColumn(AnOption.ColumnIndex);
        //        int NewLength = ColumnsCount - AnOption.ColumnIndex;
                
        //        if (NewLength == NewCompletedPartLength)
        //        {
        //            if (CheckSummationOfColumnsForLeft(NewLength))
        //            {
        //                int NonOKColumnsCount = NonOKColumnsCountForLeft(FromIndex, DigitsCount);
        //                IntQuadruple[] Temp = SaveColumnsForLeft(FromIndex, DigitsCount + 1, NonOKColumnsCount, SuitableOptions[SuitableOptions.Length - 2]);
        //                result.Add(Temp);

        //            }
        //        }
        //        else
        //        {
        //            if (CheckSummationOfColumnsForLeft(NewLength))
        //            {
        //                PushAllOptionsForAColumnIntoStackForLeft(OptionsStack, ColumnsCount - 1 - NewLength);
        //            }
        //        }
        //    }
        //    return result;
        //}
        ////public int FindTheOutputLetterForTheLeftHalf(int[] AnswerLetters, int RightCounterpart, int RightCounterpartIndex)
        ////{
        //    //ShowTable();
        //    //int LeftCounterpartIndex = Boddooh.OutputLettersElements.Length - 1 - RightCounterpartIndex;
        //    ArrayList AllPossibleMatches = FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpartIndex, RightCounterpart);
        //   // ShowTable();
        //    for (int i = 0; i < AllPossibleMatches.Count; i++)
        //    {
        //        if (RightCounterpart == 1 && RightCounterpartIndex == 2)
        //            ShowTable("B");
        //        int APossibleMatch = (int)AllPossibleMatches[i];
        //        bool Possible = CheckIfItsPossibleToStartOrContinueFromLeftWithTheDigitsButMakeNoChanges(APossibleMatch);
        //       // ShowTable();
        //        if (Possible)
        //        {

        //            bool ok = TryToStartOrContinueFromLeftWithTheDigits(APossibleMatch);

        //            if (!ok)
        //            {
        //                MessageBox.Show("eoore");
        //            }
        //            //ShowTable();
        //            return APossibleMatch;
        //        }
        //    }
        //   // ShowTable();
        //    return 0;
        //}

        //public bool TryToStartOrContinueFromLeftWithTheDigits(int digits)
        //{            
        //    int NewCompletedPartLength = CompletedPartLengthFromLeft + MiscMethods.DigitsCount(digits);            
        //    StartOrContinueTheBottomFromLefttWithTheDigits(digits);
        //    //ShowTable();
        //    //if (completedPartLength == 0 & != 0)
        //    //throw new Exception("Error In TryToStartOrContinueWithTheLetters");                
        //    InitializeAllButBottomArrayFromLeft();
        //    Stack OptionsStack = new Stack();
        //    int ColumnIndex = ColumnsCount - 1 - CompletedPartLengthFromLeft;
        //    int OptionsCount = PushAllOptionsForAColumnIntoStackForLeft(OptionsStack, ColumnsCount - 1);
        //    if (OptionsCount == 0)
        //        return false;

        //    while (OptionsStack.Count > 0)
        //    {
        //        OptionForAColumn AnOption = (OptionForAColumn)OptionsStack.Pop();
        //        ApplyAnOptionOnItsColumnForLeft(AnOption);
        //        SetBorrowForPreviousColumn(AnOption.ColumnIndex);
        //        int length = ColumnsCount - AnOption.ColumnIndex;
                
        //        if (ColumnsCount - AnOption.ColumnIndex == NewCompletedPartLength)
        //        {
        //            bool Acceptable = CheckSummationOfColumnsForLeft(length);
        //            //Acceptable = Acceptable && Boddooh.CheckValidityOfTopArrayForRightAndLeft(this, NewCompletedPartLength);
        //            if (Acceptable)
        //            {
        //                if (digits == 7)
        //                    ShowTable("A");
        //                CompletedPartLengthFromLeft = NewCompletedPartLength;
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            bool Acceptable = CheckSummationOfColumnsForLeft(length);
        //            if (Acceptable)
        //                PushAllOptionsForAColumnIntoStackForLeft(OptionsStack, AnOption.ColumnIndex - 1);
        //        }
        //    }
        //    return false;
        //}

        public static ArrayList FindAllPossibleMatchesForTheLeftCounterpart(int RightCounterpartLetterIndex, int RightCounterpart, int OneTwoEightPatternNumber)        
        {
            Elements element = Boddooh.OutputLettersElements[Boddooh.OutputLettersElements.Length - 1 - RightCounterpartLetterIndex];
            int Target = 0;
            if (OneTwoEightPatternNumber==1)
                Target = Boddooh.OneTwoEightPattern1[RightCounterpartLetterIndex];
            if (OneTwoEightPatternNumber == 2)
                Target = Boddooh.OneTwoEightPattern2[RightCounterpartLetterIndex];

            if (OneTwoEightPatternNumber == 3)
                Target = Boddooh.OneTwoEightPattern3[RightCounterpartLetterIndex];

            ArrayList result = FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, element, Target);
            if (result.Count == 0)
            {
                MessageBox.Show("خطا در FindAllPossibleMatchesForTheLeftCounterpart ");
            }
            return result;

        }

        public static ArrayList FindAllPossibleMatchesForTheLeftCounterpart(int RightCounterpart, Elements element, int Target)
        {
            ArrayList result = new ArrayList();            
            for (int order = 0; order < BoddoohNumbers.Seven; order++)
            {
                int LeftCounterpart = Abjad.ElementalOrder(element) + order * BoddoohNumbers.Four;

                int difference = Math.Abs(LeftCounterpart - RightCounterpart);
                if ((difference == 20 || difference == 11) && Target == 8) difference = 8;
                while (difference > 9) difference = MiscMethods.SummationOfDigits(difference);

                int summation = LeftCounterpart + RightCounterpart;
                if ((summation == 20 || difference == 11) && Target == 8) summation = 8;
                while (summation > 9) summation = MiscMethods.SummationOfDigits(summation);

                if (difference == Target || summation == Target || (Target == 2 && difference == 8) || (Target == 2 && summation == 8))
                    result.Add(LeftCounterpart);
                
            }
            //                f228
//26e821
            if (RightCounterpart == 18 && Target == 2 && element == Elements.Fire) result.Add(28);
            if (RightCounterpart == 26 && Target == 8 && element == Elements.Earth) result.Add(21);
            return result;

        }

        public static ArrayList FindAllPossibleMatchesForTheLeftCounterparts(int Ri, int Rj, int IndexOfRi, int OneTwoEightPatternNumber)
        {
            ArrayList PossibleMatchesForTheLeftCounterpartOfRi = FindAllPossibleMatchesForTheLeftCounterpart(IndexOfRi, Ri, OneTwoEightPatternNumber);
            ArrayList PossibleMatchesForTheLeftCounterpartOfRj = FindAllPossibleMatchesForTheLeftCounterpart(IndexOfRi + 1, Rj, OneTwoEightPatternNumber);
            ArrayList result = new ArrayList();
            for (int i = 0; i < PossibleMatchesForTheLeftCounterpartOfRi.Count; i++)
                for (int j = 0; j < PossibleMatchesForTheLeftCounterpartOfRj.Count; j++)
                {
                    IntTuple Temp = new IntTuple((int)PossibleMatchesForTheLeftCounterpartOfRi[i], (int)PossibleMatchesForTheLeftCounterpartOfRj[j]);
                    result.Add(Temp);
                }
            return result;
        }   

        public BoddoohLab Clone()
        {
            int Length = (ColumnsCount - Gap) / 2;
            BoddoohLab result = new BoddoohLab(Length);
            for (int j = 0; j < ColumnsCount; j++)
            {
                result.Top[j] = Top[j];
                result.Bottom[j] = Bottom[j];
                result.CarryBorrow[j] = CarryBorrow[j];
                for (int i = 0; i < 2; i++)
                    result.Middle[i, j] = Middle[i, j];
            }
            result.ColumnsCount = ColumnsCount;
            result.CompletedPartLengthFromRight = CompletedPartLengthFromRight;
            result.CompletedPartLengthFromLeft = CompletedPartLengthFromLeft;
            return result;
        }

    }
    public class Boddooh101Table
    {
        public byte[,] TheElements;
        public int HalfLength;
        public int Length;
        public Boddooh101Table(int[] QuestionLetters, byte[] AnswerLetters)
        {
            HalfLength = QuestionLetters.Length;
            Length = 2 * HalfLength;
            TheElements = new byte[Length, Length];
            for (int i = 0; i < QuestionLetters.Length; i++)
            {
                TheElements[0, i] = (byte)QuestionLetters[i];
                TheElements[0, HalfLength + i] = AnswerLetters[i];
            }
            for (int i = 1; i < Length; i++)
            {
                TheElements[i, i] = TheElements[0, 0];                
            }
            for (int Row = 1; Row < Length; Row++)
            {
                for (int Column = Row-1; Column >= 0; Column--)
                    TheElements[Row, Column] = (byte)MiscMethods.EquivalentNumber((TheElements[Row, Column+1] + TheElements[Row-1, Column]) - TheElements[Row-1, Column+1]);
                for (int Column = Row + 1; Column < Length; Column++)
                    TheElements[Row, Column] = (byte)MiscMethods.EquivalentNumber((TheElements[Row, Column - 1] + TheElements[Row - 1, Column]) - TheElements[Row - 1, Column - 1]);               
            } 
        }
        public static int GetRank(int[] QuestionLetters, byte[] AnswerLetters, int[] StairwayResultArray)
        {
            //AnswerLetters = new byte[] { 13, 16, 1, 19, 15, 10, 12, 22, 2, 19, 14, 12 };
           // QuestionLetters = new int[] { 11, 10, 17, 8, 1, 12, 20, 26, 13, 16, 6, 14 };

            Boddooh101Table B101T = new Boddooh101Table(QuestionLetters, AnswerLetters);
            return B101T.ComputeRank(QuestionLetters, AnswerLetters,  StairwayResultArray);  
            

        }

        public static bool FinalCondition11IsMet(int[] Mod9Array, int[] ChainPM)
        {
            return true;
            bool result = false;
            int LengthMod9Array = Mod9Array.Length;
            int MiddleDigits = 0;
            int HalfLength = 0;
            if (LengthMod9Array % 2 == 0)
            {
                HalfLength = (LengthMod9Array - 2) / 2 - 1;
                MiddleDigits = MiscMethods.JoinDigits(Mod9Array[LengthMod9Array / 2 - 1], Mod9Array[LengthMod9Array / 2]);
            }
            else
            {
                HalfLength = (LengthMod9Array - 1) / 2 - 1;
                MiddleDigits = MiscMethods.JoinDigits(Mod9Array[LengthMod9Array / 2], Mod9Array[LengthMod9Array / 2]);
            }
            int[] THalfSum = new int[HalfLength];   int[] THalfDif = new int[HalfLength];   int[] BHalfSum = new int[HalfLength];   int[] BHalfDif = new int[HalfLength];
            for (int i = 0; i < HalfLength; i++)
            {
                int Sum = Mod9Array[i] + Mod9Array[i + 1];
                int Dif = Math.Abs(Mod9Array[i] - Mod9Array[i+1]);
                THalfSum[i] = Sum % 9;
                THalfDif[i] = Dif % 9;

                Sum = Mod9Array[LengthMod9Array - 1 - i] + Mod9Array[LengthMod9Array - 1 - i - 1];
                Dif = Math.Abs(Mod9Array[LengthMod9Array - 1 - i] - Mod9Array[LengthMod9Array - 1 - i -1]);
                BHalfSum[HalfLength-1-i] = Sum % 9;
                BHalfDif[HalfLength - 1 - i] = Dif % 9;
            }
            int Max = MiscMethods.Power(2, HalfLength-1);
            ArrayList THalfValidItems = new ArrayList(); ArrayList BHalfValidItems = new ArrayList();
            int[] TempT = new int[HalfLength - 1];
            int[] TempB = new int[HalfLength - 1];

            for (int index = 0; index < Max; index++)
            {
                for (int i = 0; i < TempT.Length; i++)
                {
                    int TOperator = ChainPM[i];
                    int BOperator = ChainPM[ChainPM.Length / 2 + i];
                    int TOperand1, TOperand2, BOperand1, BOperand2;
                    if (TOperator == 0)
                    {
                        TOperand1 = THalfSum[i];
                        TOperand2 = THalfSum[i+1];
                    }
                    else
                    {
                        TOperand1 = THalfDif[i];
                        TOperand2 = THalfDif[i + 1];
                    }

                    if (BOperator == 0)
                    {
                        BOperand1 = BHalfSum[i];
                        BOperand2 = BHalfSum[i + 1];
                    }
                    else
                    {
                        BOperand1 = BHalfDif[i];
                        BOperand2 = BHalfDif[i + 1];
                    }                       

                    int Operator = MiscMethods.GetIthBitInN(index, i);
                   // int Operator1 = MiscMethods.GetIthBitInN(index, i + 1);
                    int Tresult=0;
                    int Bresult = 0;
                    if (Operator == 0)
                    {
                        Tresult = TOperand1 + TOperand2;
                        Bresult = BOperand1 + BOperand2;
                    }
                    else
                    {
                        Tresult = Math.Abs(TOperand1 - TOperand2);
                        Bresult = Math.Abs(BOperand1 - BOperand2);
                    }
                    while (Tresult > 9) Tresult = MiscMethods.SummationOfDigits(Tresult);
                    while (Bresult > 9) Bresult = MiscMethods.SummationOfDigits(Bresult);
                    TempT[i] = Tresult;
                    TempB[i] = Bresult;                    
                }
                if (CheckIfAllItemsAreOneOrTwo(TempT))
                {
                    decimal T = MiscMethods.JoinItems(TempT);
                    THalfValidItems.Add(T);
                }
                if (CheckIfAllItemsAreOneOrTwo(TempB))
                {
                    decimal B = MiscMethods.JoinItems(TempB);
                    BHalfValidItems.Add(B);
                }
            }

            for (int i = 0; i < THalfValidItems.Count; i++)
            {
                decimal T = (decimal)THalfValidItems[i];
                for (int j = 0; j < BHalfValidItems.Count; j++)
                {
                    decimal B = (decimal)BHalfValidItems[j];
                    decimal[] TMB = new decimal[3]; TMB[0] = T; TMB[1] = MiddleDigits; TMB[2] = B;
                    //decimal TMB = MiscMethods.JoinDigits(T,MiddleDigits, B);
                    decimal Reminder = Abjad.JoinItemsAndModN(TMB, BoddoohNumbers.TwentyEight);
                    if (Reminder == 8 || Reminder == 20 || Reminder == 0)
                        return true;
                }
            }

            return result;
        }

        public static bool CheckIfAllItemsAreOneOrTwo(int[] Items)
        {
            bool result = true;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] != 1 && Items[i] != 2)
                    return false;
            }
            return result;
        }
        

        public static long Conditions9102(int[] ItemsIPrime, int[] ItemsII)
        {
            int[] ItemsI = new int[ItemsIPrime.Length];
            for (int i = 0; i < ItemsI.Length; i++)
                ItemsI[i] = ItemsIPrime[ItemsIPrime.Length-1-i];
            //int[] ItemsI = new int[11];
            //ItemsI[0] = 176; ItemsI[1] = 404; ItemsI[2] = 408; ItemsI[3] = 608; ItemsI[4] = 584; ItemsI[5] = 728; ItemsI[6] = 984;
            //ItemsI[7] = 1072; ItemsI[8] = 1076; ItemsI[9] = 1136; ItemsI[10] = 1196;
            int LengthI = ItemsI.Length;
            //int[] ItemsII = new int[11];
            //ItemsII[0] = 176; ItemsII[1] = 216; ItemsII[2] = 244; ItemsII[3] = 212; ItemsII[4] = 184; ItemsII[5] = 192; ItemsII[6] = 264;
            //ItemsII[7] = 248; ItemsII[8] = 236; ItemsII[9] = 228; ItemsII[10] = 180;
            int LengthII = ItemsII.Length;

            // Condition 1
            bool Condition1 = false;

            int SumMod28 = 0;
            int ReminderFactor = 1;
            for (int i = 0; i < ItemsI.Length; i++)
            {
                int NewItem = ItemsI[i];
                int DigitsCount = MiscMethods.DigitsCount(NewItem);
                ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
            }
            if (SumMod28 == 0 || SumMod28 == 20 || SumMod28 == 8)
                Condition1 = true;

            // Condition 2
            bool Condition2 = false;
            int L = LengthI;
            if (L % 2 == 1)
                L--;
            SumMod28 = 0;
            for (int i = 0; i < L; i++)
            {
                int NewItem;
                if (i%2==0)
                    NewItem = ItemsI[i/2];
                else
                    NewItem = ItemsI[LengthI - 1 - i / 2];
                int DigitsCount = MiscMethods.DigitsCount(NewItem);
                ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
            }
            if (SumMod28 == 0 || SumMod28 == 20 || SumMod28 == 8)
                Condition2 = true;

            // Condition 3
            bool Condition3 = false;
            L = LengthI;
            if (L % 2 == 1)
                L--;
            SumMod28 = 0;
            for (int i = 0; i < L; i++)
            {
                int NewItem;
                if (i % 2 == 0)
                    NewItem = ItemsI[LengthI - 1 - i / 2];
                else
                    NewItem = ItemsI[(i-1)/2];
                int DigitsCount = MiscMethods.DigitsCount(NewItem);
                ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
            }
            if (SumMod28 == 0 || SumMod28 == 20 || SumMod28 == 8)
                Condition3 = true;

            // Condition 4
            bool Condition4 = false;
            L = LengthI;
            if (L % 2 == 1)
                L++;
            SumMod28 = 0;
            for (int i = 0; i < L; i++)
            {
                int NewItem;
                if (i % 2 == 0)
                    NewItem = ItemsI[i / 2] % 9;
                else
                    NewItem = ItemsI[LengthI - 1 - i / 2] % 9;
                if (NewItem == 0) NewItem = 9;
                SumMod28 = (10 * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
            }
            if (SumMod28 == 0 || SumMod28 == 20 || SumMod28 == 8)
                Condition4 = true;

            // Condition 5
            bool Condition5 = false;
            L = LengthI;
            if (L % 2 == 1)
                L++;
            SumMod28 = 0;
            for (int i = 0; i < L; i++)
            {
                int NewItem;
                if (i % 2 == 1)
                    NewItem = ItemsI[i / 2] % 9;
                else
                    NewItem = ItemsI[LengthI - 1 - i / 2] % 9;
                if (NewItem == 0) NewItem = 9;
                SumMod28 = (10 * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
            }
            if (SumMod28 == 0 || SumMod28 == 20 || SumMod28 == 8)
                Condition5 = true;


            // Condition 6, 7 & 8
            bool Condition6 = false;
            bool Condition7 = false;
            bool Condition8 = false;
            L = LengthI;
            int SumMod9T = 0;
            int SumMod9B = 0;
            for (int i = 0; i < L/2; i++)
            {
                SumMod9T += (ItemsI[i ] % 9);
                SumMod9B += (ItemsI[LengthI - 1 - i] % 9);
            }
             SumMod9T = SumMod9T % 9;
             SumMod9B = SumMod9B % 9;
             if (SumMod9T == 1 || SumMod9T == 2)
                 Condition6 = true;
             if (SumMod9B == 1 || SumMod9B == 2)
                 if (SumMod9T != SumMod9B)
                     Condition8 = true;
             if (L % 2 == 1)
             {
                 if (ItemsI[L / 2] % 9 == 8)
                     Condition7 = true;
             }

             // Condition 9
             bool Condition9 = false;
             L = LengthI;
             int Sum = 0;
             for (int i = 0; i < L; i++)
             {
                 int t = ItemsI[i] % 9;
                     if (t == 0) t = 9;
                 Sum += (t);
             }
             Sum = Sum % BoddoohNumbers.TwentyEight;
             if (Sum == 0 || Sum == 20 || Sum == 8)
                 Condition9 = true;

             // Condition 10
             bool Condition10 = false;
             L = LengthI;
             if (L % 2 == 1)
                 L++;
             int SumMod28T = 0;
             int SumMod28B = 0;
             for (int i = 0; i < L/2; i++)
             {
                 int NewItem = ItemsI[i] % 9;
                 if (NewItem == 0) NewItem = 9;
                 SumMod28T = (10 * SumMod28T + NewItem) % BoddoohNumbers.TwentyEight;

                 int j = L / 2 - 1 - i;
                 NewItem = ItemsI[LengthI - 1 - j] % 9;
                 if (NewItem == 0) NewItem = 9;
                 SumMod28B = (10 * SumMod28B + NewItem) % BoddoohNumbers.TwentyEight;
             }
             SumMod28T = SumMod28T % BoddoohNumbers.TwentyEight;
             SumMod28B = SumMod28B % BoddoohNumbers.TwentyEight;
             if (SumMod28T == SumMod28B)
                 Condition10 = true;


             // Condition New 1
             bool ConditionNew1 = false;
             SumMod28 = 0;
             ReminderFactor = 1;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int NewItem = ItemsII[i];
                 int DigitsCount = MiscMethods.DigitsCount(NewItem);
                 ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                 SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
             }
             if (SumMod28 == 20 || SumMod28 == 8)
                 ConditionNew1 = true;

             // Condition New 2
             bool ConditionNew2 = false;
             SumMod28 = 0;
             ReminderFactor = 1;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int NewItem = ItemsII[ItemsII.Length-1-i];
                 int DigitsCount = MiscMethods.DigitsCount(NewItem);
                 ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                 SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
             }
             if (SumMod28 == 20 || SumMod28 == 8)
                 ConditionNew2 = true;

             // Condition New 3
             bool ConditionNew3 = false;
             SumMod28 = 0;
             ReminderFactor = 1;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int NewItem = ItemsII[i] % BoddoohNumbers.TwentyEight;
                 if (NewItem == 0) NewItem = BoddoohNumbers.TwentyEight;
                 int DigitsCount = MiscMethods.DigitsCount(NewItem);
                 ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                 SumMod28 = (ReminderFactor * SumMod28 + NewItem) % BoddoohNumbers.TwentyEight;
             }
             if (SumMod28 == 20 || SumMod28 == 8)
                 ConditionNew3 = true;

             // Condition New 4
             bool ConditionNew4 = false;
             int SumMod281 = 0;
             int SumMod282 = 0;
             ReminderFactor = 1;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int NewItem = ItemsII[ItemsII.Length - 1 -i] % BoddoohNumbers.TwentyEight;
                 if (NewItem == 0) NewItem = BoddoohNumbers.TwentyEight;
                 int DigitsCount = MiscMethods.DigitsCount(NewItem);
                 ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                 SumMod281 = (ReminderFactor * SumMod281 + NewItem) % BoddoohNumbers.TwentyEight;

                 NewItem = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(NewItem));
                 DigitsCount = MiscMethods.DigitsCount(NewItem);
                 ReminderFactor = MiscMethods.TenPowerdN(DigitsCount);
                 SumMod282 = (ReminderFactor * SumMod282 + NewItem) % BoddoohNumbers.TwentyEight;

             }
             if ((SumMod281 == 4 && SumMod282 == 24) || (SumMod281 == 24 && SumMod282 == 4))
                 ConditionNew4 = true;

             // Condition New 5
             bool ConditionNew5 = false;
              SumMod281 = 0;
              SumMod282 = 0;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int NewItem = ItemsII[i] % BoddoohNumbers.Nine;
                 if (NewItem == 0) NewItem = 9;
                 SumMod281 = (10 * SumMod281 + NewItem) % BoddoohNumbers.TwentyEight;
                 NewItem = ItemsII[ItemsII.Length - 1 - i] % BoddoohNumbers.Nine;
                 if (NewItem == 0) NewItem = 9;
                 SumMod282 = (10 * SumMod282 + NewItem) % BoddoohNumbers.TwentyEight;
             }
             if (SumMod281 == SumMod282)
                 ConditionNew5 = true;

             // Condition New 6
             bool ConditionNew6 = false;
             int SumI = 0;
             int SumII = 0;
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 SumII += ItemsII[i];
                 SumI += ItemsI[i];
             }
             int D = Sum / BoddoohNumbers.TwentyEight;
             string SumString = SumII.ToString();
             int SumD = 0;
             while  (SumString.Length >0)
             {                 
                 int i = 1;
                 while (i < SumString.Length && SumString[i] == '0')
                 {
                     i++;
                 }
                 string StingPart = SumString.Substring(0, i);
                 SumString = SumString.Substring(i, SumString.Length - i);
                 int Part = Convert.ToInt32(StingPart);
                 SumD += Part;
             }
             if (SumII / BoddoohNumbers.TwentyEight == SumD && SumII % BoddoohNumbers.TwentyEight == 0)
                 ConditionNew6 = true;

             // Condition New 21
             bool ConditionNew21 = false;
             int Temp1 = (SumI / BoddoohNumbers.TwentyEight + SumII / BoddoohNumbers.TwentyEight) % BoddoohNumbers.TwentyEight;
             int Temp2 = Math.Abs(SumI / BoddoohNumbers.TwentyEight - SumII / BoddoohNumbers.TwentyEight) % BoddoohNumbers.TwentyEight;
             if (SumI % BoddoohNumbers.TwentyEight == 0 && SumII % BoddoohNumbers.TwentyEight == 0)
             if ((Temp1 == 8 || Temp1 == 20 || Temp1 == 0) || (Temp2 == 8 || Temp2 == 20 || Temp2 == 0))
                 ConditionNew21 = true;

             // Condition New 22
             bool ConditionNew22 = false;
             int[] ItemsIII = new int[LengthI];
             int[] ItemsIV = new int[LengthI];
             for (int i = 0; i < ItemsII.Length; i++)
             {
                 int T1 = ItemsII[i] % BoddoohNumbers.TwentyEight; if (T1==0) T1 = BoddoohNumbers.TwentyEight;
                 int T2 = ItemsI[i] % BoddoohNumbers.TwentyEight; if (T2==0) T2 = BoddoohNumbers.TwentyEight;
                 ItemsIII[i] = Math.Abs(T1 - T2);
                 ItemsIV[i] = T1 - T2;
             }
             L = LengthI;
             if (L % 2 == 1)
                 L++;
             int[] Temp = new int[L/2];
             for (int i = 0; i < Temp.Length; i++)
             {
                 Temp[i] = MiscMethods.EquivalentNumber(ItemsIII[i] + ItemsIII[LengthI - 1 - i]);
             }
             if (LengthI % 2 ==1) 
             {
                 Temp[Temp.Length - 1] = MiscMethods.EquivalentNumber(Temp[Temp.Length - 1] - ItemsIII[Temp.Length - 1]);
            }
             int Len = Temp.Length;
             while (Len > 1)
             {
                 L = Len;
                 if (L % 2 == 1)
                     L++;
                 L = L / 2;
                 for (int i = 0; i < L; i++)
                 {
                     if (Len % 2 == 0 || i < L-1)
                        Temp[i] = MiscMethods.EquivalentNumber(Math.Abs(Temp[i] - Temp[Len - 1 - i]));
                 }
                 Len = L;
             }
             if (Temp[0] == 20 || Temp[0] == 8)
                 ConditionNew22 = true;

             // Condition New 23
             bool ConditionNew23 = false;
             L = LengthI;
             if (L % 2 == 1)
                 L++;
             Temp = new int[L / 2];
             for (int i = 0; i < Temp.Length; i++)
             {
                 Temp[i] = MiscMethods.EquivalentNumber(ItemsIV[i] + ItemsIV[LengthI - 1 - i]);
             }
             if (LengthI % 2 == 1)
             {
                 Temp[Temp.Length - 1] = MiscMethods.EquivalentNumber(Temp[Temp.Length - 1] - ItemsIV[Temp.Length - 1]);
             }
             Len = Temp.Length;
             while (Len > 2)
             {
                 L = Len;
                 if (L % 2 == 1)
                     L++;
                 L = L / 2;
                 for (int i = 0; i < L; i++)
                 {
                     if (Len % 2 == 0 || i < L - 1)
                         Temp[i] = MiscMethods.EquivalentNumber(Math.Abs(Temp[i] - Temp[Len - 1 - i]));
                 }
                 Len = L;
             }
             int Jam = (Temp[0] + Temp[1])% BoddoohNumbers.TwentyEight;
             int Tafriqh =Math.Abs( Temp[0] - Temp[1]) % BoddoohNumbers.TwentyEight;
             if ((Jam == 8 || Jam == 20 || Jam == 0) && (Tafriqh == 8 || Tafriqh == 20 || Tafriqh == 0))
                 ConditionNew23 = true;

             // Condition New 24
             bool ConditionNew24 = false;
             L = LengthI;
             if (L % 2 == 1)
                 L++;
             Temp = new int[L / 2];
             for (int i = 0; i < Temp.Length; i++)
             {
                 Temp[i] = MiscMethods.EquivalentNumber(ItemsIV[i] + ItemsIV[LengthI - 1 - i]);
             }
             if (LengthI % 2 == 1)
             {
                 Temp[Temp.Length - 1] = MiscMethods.EquivalentNumber(Temp[Temp.Length - 1] - ItemsIV[Temp.Length - 1]);
             }
             Len = Temp.Length;
             while (Len > 2)
             {
                 L = Len;
                 if (L % 2 == 1)
                     L++;
                 L = L / 2;
                 for (int i = 0; i < L; i++)
                 {
                     if (Len % 2 == 0 || i < L - 1)
                         Temp[i] = MiscMethods.EquivalentNumber(Math.Abs(Temp[i] + Temp[Len - 1 - i]));
                 }
                 Len = L;
             }
              Jam = (Temp[0] + Temp[1]) % BoddoohNumbers.TwentyEight;
              Tafriqh = Math.Abs(Temp[0] - Temp[1]) % BoddoohNumbers.TwentyEight;
             if ((Jam == 8 || Jam == 20 || Jam == 0) && (Tafriqh == 8 || Tafriqh == 20 || Tafriqh == 0))
                 ConditionNew24 = true;



             // Condition 11
             bool Condition11 = false;
            
             L = LengthI;
             if (L % 2 == 1)
                 L--;
           
            int[] UpC1 =  new int[] {0,0,0,1,1,1,1,0} ;int[] UpC2 =  new int[] {0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,0} ;
            int[] DownC1 = new int[] {0,1,1,1,1,0,0,0} ;int[] DownC2 = new int[] {0,1,1,1,1,0,0,0,0,0,0,1,1,1,1,0} ;
            
            int[] Mod9Array = new int[ItemsI.Length];
            for (int i = 0; i < Mod9Array.Length; i++)
            {
                Mod9Array[i] = ItemsI[i] % 9;
                if (Mod9Array[i] == 0)
                    Mod9Array[i] = 9;
            }
            int[] ChainPM = new int[L - 2];
            for (int i = 0; i < ChainPM.Length / 2; i++)
            {
                ChainPM[i] = UpC1[i % UpC1.Length];
                ChainPM[ChainPM.Length - 1 - i] = DownC1[i % DownC1.Length];
            }
            Condition11 = FinalCondition11IsMet(Mod9Array, ChainPM);
            if (!Condition11)
            {
                for (int i = 0; i < ChainPM.Length / 2; i++)
                {
                    ChainPM[i] = UpC1[i % UpC2.Length];
                    ChainPM[ChainPM.Length - 1 - i] = DownC2[i % DownC2.Length];
                }
                Condition11 = FinalCondition11IsMet(Mod9Array, ChainPM);
            }

             int Rank = 0;
             if (Condition1) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 0, Condition1);  //  }//
             if (Condition2) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 1, Condition2); }
          //   MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (Condition3) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 2, Condition3); }
             if (Condition4) { Rank++; }// Status = MiscMethods.SetIthBitInNToB(Status, 3, Condition4); }
             if (Condition5) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 4, Condition5); }
            // MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (Condition6) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 5, Condition6); }
             if (Condition7) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 6, Condition7); }
             //MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (Condition8) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 7, Condition8); }
             if (Condition9) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 8, Condition9); }
             //MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (Condition10) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status,9, Condition10); }
             if (Condition11) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 10, Condition11); }
         //    MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (ConditionNew1) { Rank++; }// Status = MiscMethods.SetIthBitInNToB(Status, 10, ConditionNew1); }
             if (ConditionNew2) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 11, ConditionNew2); }
             if (ConditionNew3) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 12, ConditionNew3); }
           //  MessageBox.Show(MiscMethods.GetBinaryString(Status));
             if (ConditionNew4) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 13, ConditionNew4); }
           //  if (ConditionNew5) { Rank++; Status = MiscMethods.SetIthBitInNToB(Status, 15, ConditionNew5); }
             if (ConditionNew6) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 14, ConditionNew6); }



             if (ConditionNew21) { Rank++; }// Status = MiscMethods.SetIthBitInNToB(Status, 15, ConditionNew21); }
             if (ConditionNew22) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 16, ConditionNew22); }
             if (ConditionNew23) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 17, ConditionNew23); }
             if (ConditionNew24) { Rank++; }//Status = MiscMethods.SetIthBitInNToB(Status, 18, ConditionNew24); }

             //MessageBox.Show(MiscMethods.GetBinaryString(Status));
             return Rank;
        }

        public static int Conditions_ABCDEFG(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Rank_A = Conditions_A(QuestionLetters, AnswerLetters);//42
            int Rank_B = Conditions_B(QuestionLetters, AnswerLetters);//6
            int Rank_C = Conditions_C(QuestionLetters, AnswerLetters);//7
            int Rank_D = Conditions_D(QuestionLetters, AnswerLetters);//10
            int Rank_E = Conditions_E(QuestionLetters, AnswerLetters);//12
            int Rank_F = Conditions_F(QuestionLetters, AnswerLetters);//4
            int Rank_G = Conditions_G(QuestionLetters, AnswerLetters);//2
            int result = Rank_A + Rank_B + Rank_C + Rank_D + Rank_E + Rank_F + Rank_G;//84
            return result;
           
        }



        


        public static int Conditions_G(int[] QuestionLetters, int[] AnswerLetters)
        {
            ArrayList ElementPatternsForFirstHalf_Sum= new ArrayList();
            ArrayList ElementPatternsForSecondHalf_Sum = new ArrayList();
            Elements[] ElementPatternForFirstHalf_Mul = new Elements[] { Elements.Earth, Elements.Water, Elements.Earth, Elements.Earth, Elements.Air, 
                Elements.Water,  Elements.Earth, Elements.Fire, Elements.Air, Elements.Water, 
                    Elements.Air, Elements.Water, Elements.Water, Elements.Fire,   Elements.Air,
                Elements.Water,  Elements.Earth, Elements.Fire, Elements.Air, Elements.Fire, 
                    Elements.Air, Elements.Air, Elements.Earth, Elements.Fire,   Elements.Air,
                Elements.Water,  Elements.Earth, Elements.Fire, Elements.Earth, Elements.Fire, 
                Elements.Fire, Elements.Water, Elements.Earth, Elements.Fire,   Elements.Air,
            Elements.Water
            };

            Elements[] ElementPatternForSecondHalf_Mul = new Elements[] { Elements.Air, Elements.Water, Elements.Water, Elements.Earth, Elements.Fire,
                Elements.Air, Elements.Air, Elements.Water, Elements.Earth, Elements.Fire, 
                Elements.Fire, Elements.Air, Elements.Water, Elements.Earth, Elements.Earth, 
                Elements.Fire};


            Elements[] ElementPatternForFirstHalf_Sum = new Elements[] { Elements.Air, Elements.Earth, Elements.Fire, Elements.Fire, Elements.Water, Elements.Earth,
                Elements.Water, Elements.Fire, Elements.Air, Elements.Earth, Elements.Air, Elements.Water};
            ElementPatternsForFirstHalf_Sum.Add(ElementPatternForFirstHalf_Sum);
            
            ElementPatternForFirstHalf_Sum = new Elements[] { Elements.Air, Elements.Earth, Elements.Fire, Elements.Fire, Elements.Water, Elements.Earth,
                Elements.Air, Elements.Air, Elements.Water, Elements.Fire, Elements.Earth, Elements.Earth, Elements.Air, Elements.Fire, Elements.Water, Elements.Water};
            ElementPatternsForFirstHalf_Sum.Add(ElementPatternForFirstHalf_Sum);

            ElementPatternForFirstHalf_Sum = new Elements[] { Elements.Air, Elements.Earth, Elements.Fire, Elements.Fire, Elements.Water, Elements.Earth,
                Elements.Water, Elements.Fire, Elements.Air, Elements.Earth, Elements.Water};
            ElementPatternsForFirstHalf_Sum.Add(ElementPatternForFirstHalf_Sum);

            ElementPatternForFirstHalf_Sum = new Elements[] { Elements.Air, Elements.Earth, Elements.Fire, Elements.Fire, Elements.Water, Elements.Earth,
                Elements.Air, Elements.Air, Elements.Water, Elements.Fire, Elements.Earth, Elements.Earth, Elements.Air, Elements.Fire, Elements.Earth, Elements.Earth};
            ElementPatternsForFirstHalf_Sum.Add(ElementPatternForFirstHalf_Sum);




            Elements[] ElementPatternForSecondHalf_Sum = new Elements[] { Elements.Earth, Elements.Air, Elements.Earth, Elements.Air, Elements.Water, Elements.Fire,Elements.Water, Elements.Fire,
                Elements.Air, Elements.Earth, Elements.Air, Elements.Earth, Elements.Fire, Elements.Water, Elements.Fire, Elements.Water};
            ElementPatternsForSecondHalf_Sum.Add(ElementPatternForSecondHalf_Sum);

            ElementPatternForSecondHalf_Sum = new Elements[] { Elements.Earth, Elements.Air, Elements.Earth, Elements.Air, Elements.Water, Elements.Fire,Elements.Water, Elements.Fire,
                Elements.Air, Elements.Earth, Elements.Air, Elements.Earth, Elements.Fire, Elements.Water, Elements.Fire, Elements.Water};
            ElementPatternsForSecondHalf_Sum.Add(ElementPatternForSecondHalf_Sum);

            ElementPatternForSecondHalf_Sum = new Elements[] { Elements.Earth, Elements.Air, Elements.Earth, Elements.Air, Elements.Water, Elements.Fire,Elements.Water, Elements.Fire,
                Elements.Water, Elements.Fire, Elements.Air, Elements.Earth, Elements.Air, Elements.Earth,Elements.Air, Elements.Earth, 
            Elements.Fire, Elements.Water,Elements.Fire, Elements.Water,Elements.Fire, Elements.Water,Elements.Earth, Elements.Air };
            ElementPatternsForSecondHalf_Sum.Add(ElementPatternForSecondHalf_Sum);

            ElementPatternForSecondHalf_Sum = new Elements[] { Elements.Earth, Elements.Air, Elements.Earth, Elements.Air, Elements.Water, Elements.Fire,Elements.Water, Elements.Fire,
                Elements.Water, Elements.Fire, Elements.Air, Elements.Earth, Elements.Air, Elements.Earth,Elements.Air, Elements.Earth, 
            Elements.Fire, Elements.Water,Elements.Fire, Elements.Water,Elements.Fire, Elements.Water,Elements.Earth, Elements.Air };
            ElementPatternsForSecondHalf_Sum.Add(ElementPatternForSecondHalf_Sum);


            int Length = QuestionLetters.Length;
            bool Condition1 = false;
            bool Condition2= false;


            int[] Q1to9 = MiscMethods.Equivalent1To9(QuestionLetters);
            int[] A1to9 = MiscMethods.Equivalent1To9(AnswerLetters);
            int[] APlusB = MiscMethods.Summation(Q1to9, A1to9);
            int[] APlusB1to9 = MiscMethods.Equivalent1To9(APlusB);
            int[] AMulB = MiscMethods.Multiplication(Q1to9, A1to9);
            int[] AMulB1to9 = MiscMethods.Equivalent1To9(AMulB);

//            Elements[] PlusElements = MiscMethods.GetElementsArray(APlusB1to9);
//            Elements[] MulElements = MiscMethods.GetElementsArray(AMulB1to9);


            Elements[] PlusFirstHalf;
            Elements[] PlusSecondHalf;
                        Elements[] MulFirstHalf;
            Elements[] MulSecondHalf;

            int FirstLength;            

            int SecondLength;

            if (Length % 2 == 0)
            {
                FirstLength = Length / 2;
                SecondLength = Length / 2;
                PlusFirstHalf= MiscMethods.GetElementsArray(MiscMethods.SubArray(APlusB1to9, 0, FirstLength));
                PlusSecondHalf = MiscMethods.GetElementsArray(MiscMethods.InverseArray(MiscMethods.SubArray(APlusB1to9, FirstLength, SecondLength)));
                MulFirstHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(AMulB1to9, 0, FirstLength));
                MulSecondHalf = MiscMethods.GetElementsArray(MiscMethods.InverseArray( MiscMethods.SubArray(AMulB1to9, FirstLength, SecondLength)));
                bool P_L0 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[0]);
                bool P_L1 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[1]);
                bool P_L2 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[2]);
                bool P_L3 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[3]);
                bool P_R0 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[0]);
                bool P_R1 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[1]);
                bool P_R2 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[2]);
                bool P_R3 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[3]);
                bool M_L = MatchesTheElementPattern(MulFirstHalf, ElementPatternForFirstHalf_Mul);
                bool M_R = MatchesTheElementPattern(MulSecondHalf, ElementPatternForSecondHalf_Mul);
                if ((P_L0 || P_L1 || P_L2 || P_L3) && (P_R0 || P_R1 || P_R2 || P_R3))
                    Condition1 = true;

                if (M_L && M_R)
                    Condition2 = true;
            }
            else
            {
                FirstLength = Length / 2;
                SecondLength = Length / 2+1;

                PlusFirstHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(APlusB1to9, 0, FirstLength));
                PlusSecondHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(APlusB1to9, FirstLength, SecondLength));
                MulFirstHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(AMulB1to9, 0, FirstLength));
                MulSecondHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(AMulB1to9, FirstLength, SecondLength));
                bool P_L0 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[0]);
                bool P_L1 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[1]);
                bool P_L2 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[2]);
                bool P_L3 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[3]);
                bool P_R0 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[0]);
                bool P_R1 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[1]);
                bool P_R2 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[2]);
                bool P_R3 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[3]);
                bool M_L = MatchesTheElementPattern(MulFirstHalf, ElementPatternForFirstHalf_Mul);
                bool M_R = MatchesTheElementPattern(MulSecondHalf, ElementPatternForSecondHalf_Mul);
                if ((P_L0 || P_L1 || P_L2 || P_L3) && (P_R0 || P_R1 || P_R2 || P_R3))
                    Condition1 = true;

                if (M_L && M_R)
                    Condition2 = true;

                FirstLength = Length / 2+1;
                SecondLength = Length / 2 ;

                PlusFirstHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(APlusB1to9, 0, FirstLength));
                PlusSecondHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(APlusB1to9, FirstLength, SecondLength));
                MulFirstHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(AMulB1to9, 0, FirstLength));
                MulSecondHalf = MiscMethods.GetElementsArray(MiscMethods.SubArray(AMulB1to9, FirstLength, SecondLength));
                 P_L0 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[0]);
                 P_L1 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[1]);
                 P_L2 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[2]);
                 P_L3 = MatchesTheElementPattern(PlusFirstHalf, (Elements[])ElementPatternsForFirstHalf_Sum[3]);
                 P_R0 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[0]);
                 P_R1 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[1]);
                 P_R2 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[2]);
                 P_R3 = MatchesTheElementPattern(PlusSecondHalf, (Elements[])ElementPatternsForSecondHalf_Sum[3]);
                 M_L = MatchesTheElementPattern(MulFirstHalf, ElementPatternForFirstHalf_Mul);
                 M_R = MatchesTheElementPattern(MulSecondHalf, ElementPatternForSecondHalf_Mul);
                if ((P_L0 || P_L1 || P_L2 || P_L3) && (P_R0 || P_R1 || P_R2 || P_R3))
                    Condition1 = true;

                if (M_L && M_R)
                    Condition2 = true;

            }



            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            // Out Of 2
            return Rank;

        }
        public static int Conditions_H(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Length = QuestionLetters.Length;

            bool Condition1 = false;
            bool Condition2 = false;
            bool Condition3 = false;
            bool Condition4 = false;
            bool Condition5 = false;
            int[] EvenItemsAnswerLetters = MiscMethods.ItemsWithEvenIndices(AnswerLetters);
            int[] OddItemsAnswerLetters = MiscMethods.ItemsWithOddIndices(AnswerLetters);
            int[] EvenItemsQuestionLetters = MiscMethods.ItemsWithEvenIndices(QuestionLetters);
            int[] OddItemsQuestionLetters = MiscMethods.ItemsWithOddIndices(QuestionLetters);

            int[] MajorEvenItemsAnswerLetters = MiscMethods.MajorAbjadArray(EvenItemsAnswerLetters);
            int[] MajorOddItemsAnswerLetters = MiscMethods.MajorAbjadArray(OddItemsAnswerLetters);
            int[] MajorEvenItemsQuestionLetters = MiscMethods.MajorAbjadArray(EvenItemsQuestionLetters);
            int[] MajorOddItemsQuestionLetters = MiscMethods.MajorAbjadArray(OddItemsQuestionLetters);

            int C1_A = MiscMethods.ArrayItemsSummation(EvenItemsQuestionLetters);
            int C1_B = MiscMethods.ArrayItemsSummation(OddItemsQuestionLetters);
            int C1_C = MiscMethods.ArrayItemsSummation(EvenItemsAnswerLetters);
            int C1_D = MiscMethods.ArrayItemsSummation(OddItemsAnswerLetters);

            int C4_A = MiscMethods.ArrayItemsSummation(MajorEvenItemsQuestionLetters);
            int C4_B = MiscMethods.ArrayItemsSummation(MajorOddItemsQuestionLetters);
            int C4_C = MiscMethods.ArrayItemsSummation(MajorEvenItemsAnswerLetters);
            int C4_D = MiscMethods.ArrayItemsSummation(MajorOddItemsAnswerLetters);


            if (Length % 2 == 0)
            {
                // Condition 1
                int C1 = Math.Abs(C1_B - C1_C);
                Condition1 = MiscMethods.IsK9Plus2(C1);

                // Condition 2
                int C2 = Math.Abs(C1_A - C1_D);
                Condition2 = (C2 % 28 == 2);

                // Condition 3
                //int[] C3_Summation = MiscMethods.Summation(EvenItemsAnswerLetters, OddItemsAnswerLetters);
                //C3_Summation = MiscMethods.Summation(C3_Summation, EvenItemsQuestionLetters);
                //C3_Summation = MiscMethods.Summation(C3_Summation, OddItemsQuestionLetters);
                //int[] C3_Array = MiscMethods.FoldAndDistance(C3_Summation);
                //C3_Array = MiscMethods.IterativelyComputeSummationOfDigits(C3_Array);
                //while (C3_Array.Length >2)
                //{
                //    C3_Array = MiscMethods.SummationOfNeighboringItems(C3_Array);
                //}
                //Condition3 = (MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C3_Array[0], C3_Array[1])
                //    || MiscMethods.SummationOrDistanceIsK9Plus2(C3_Array[0], C3_Array[1]));

                // Condition 4
                int C4 = Math.Abs(C4_A - C4_C);
                Condition4 = (MiscMethods.IsK28(C4) || MiscMethods.IsK9Plus2(C4));

                // Condition 5
                int C5 = Math.Abs(C4_B - C4_D);
                Condition5 = (C2 % 28 == 2);

            }



            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            //if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            // Out Of 4
            return Rank;

        }

        public static bool MatchesTheElementPattern(Elements[] ItemsElements, Elements[] Pattern)
        {
            for (int start = 0; start < Pattern.Length; start++)
            {
                bool OK = true;
                for (int i = 0; i < ItemsElements.Length && OK; i++)
                {
                    int index = (start + i) % Pattern.Length;
                    if (Pattern[index] != ItemsElements[i])
                        OK = false;
                }
                if (OK)
                    return true;
            }
            return false;
        }


        public static int Conditions_Unknown(int[] UnknownArray)
        {
            // TAFMS
            int Length = UnknownArray.Length;

            int Sum = MiscMethods.ArrayItemsSummation(UnknownArray);

            int C1 = MiscMethods.JoinItemsAndModN(UnknownArray, 28);
            bool Condition1 = (MiscMethods.IsK28Plus20OrK28Minus20(C1) || MiscMethods.IsK28(C1));

            int[] TempArrayC2 = MiscMethods.FirstLastSecondPrelastWithoutMiddleInOddCases(UnknownArray);
            int C2 = MiscMethods.JoinItemsAndModN(TempArrayC2, 28);
            bool Condition2 = (MiscMethods.IsK28Plus20OrK28Minus20(C2) || MiscMethods.IsK28(C2));

            int[] TempArrayC3 = MiscMethods.FirstLastSecondPrelastWithoutMiddleInOddCases(MiscMethods.InverseArray(UnknownArray));
            int C3 = MiscMethods.JoinItemsAndModN(TempArrayC3, 28);
            bool Condition3 = (MiscMethods.IsK28Plus20OrK28Minus20(C3) || MiscMethods.IsK28(C3));

            int[] Reminder9 = MiscMethods.Equivalent1To9(UnknownArray);

            int[] TempArrayC4 = MiscMethods.FirstLastSecondPrelastWithDuplicateMiddleInOddCases(Reminder9);
            int C4 = MiscMethods.JoinItemsAndModN(TempArrayC4, 28);
            bool Condition4 = (MiscMethods.IsK28Plus20OrK28Minus20(C4) || MiscMethods.IsK28(C4));

            int[] TempArrayC5 = MiscMethods.FirstLastSecondPrelastWithDuplicateMiddleInOddCases(MiscMethods.InverseArray(Reminder9));
            int C5 = MiscMethods.JoinItemsAndModN(TempArrayC5, 28);
            bool Condition5 = (MiscMethods.IsK28Plus20OrK28Minus20(C5) || MiscMethods.IsK28(C5));


            int[] TempArrayC6 = MiscMethods.FirstHalf(Reminder9);
            int C6 = MiscMethods.ArrayItemsSummation(TempArrayC6);
            bool Condition6 = false;

            bool Condition7 = (Length % 2 == 1 && MiscMethods.MiddleElement(Reminder9) == 8);

            int[] TempArrayC8 = MiscMethods.SecondHalf(Reminder9);
            int C8 = MiscMethods.ArrayItemsSummation(TempArrayC8);
            bool Condition8 = false;

            if (C6 % 9 == 1 && C8 % 9 == 2)
            {
                Condition6 = true;
                Condition8 = true;
            }
            if (C6 % 9 == 2 && C8 % 9 == 1)
            {
                Condition6 = true;
                Condition8 = true;

            }

            int SumOfReminder9 = MiscMethods.ArrayItemsSummation(Reminder9);
            bool Condition9 = (MiscMethods.IsK28Plus20OrK28Minus20(SumOfReminder9) || MiscMethods.IsK28(SumOfReminder9));

            int[] TempArrayC10FH = MiscMethods.FirstHalfPlusMiddle(Reminder9);
            int[] TempArrayC10SH = MiscMethods.SecondHalfPlusMiddle(Reminder9);
            int SumOfReminder9FH = MiscMethods.JoinItemsAndModN(TempArrayC10FH, 28);
            int SumOfReminder9SH = MiscMethods.JoinItemsAndModN(TempArrayC10SH, 28);
            bool Condition10 = (SumOfReminder9FH == SumOfReminder9SH);






            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;


            // Out Of 10
            return Rank;

        }

        public static int Conditions_InputManagment(int[] QuestionLetters)
        {
            int Length = QuestionLetters.Length;
            Boddooh4By4Table[] B4BTs = new Boddooh4By4Table[Length];
            for (int i = 0; i < Length; i++)
            {
                B4BTs[i] = new Boddooh4By4Table(QuestionLetters[i], QuestionLetters[(i + 1) % Length],
                            QuestionLetters[(i + 2) % Length], QuestionLetters[(i + 3) % Length]);
            }

            int Rank_A = Conditions_InputManagment_A(QuestionLetters, B4BTs);//17
            int Rank_B = Conditions_InputManagment_B(QuestionLetters,  B4BTs);//21
            int Rank_C = Conditions_InputManagment_C(QuestionLetters,  B4BTs);//18
            int Rank_D = Conditions_InputManagment_D(QuestionLetters,  B4BTs);//??
            int result = Rank_A + Rank_B + Rank_C + Rank_D;//62+??
            return result;
        }
        public static int Conditions_InputManagment_A(int[] QuestionLetters, Boddooh4By4Table[] B4BTs)
        {
            int[] InverseQuestionLetters = MiscMethods.InverseArray(QuestionLetters);
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D1
            // Condition 1
            int QuestionLettersMinorAS = MiscMethods.ArrayItemsSummation(QuestionLetters);
            int[] C1_Array = MiscMethods.CopyArray(QuestionLetters);
            for (int i = C1_Array.Length - 2; i>=0; i--)
            {
                C1_Array[i] = Math.Abs(C1_Array[i] -  C1_Array[i+1]);
            }
            int C1 = C1_Array[0];
            bool Condition1 = (
                MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C1 + QuestionLettersMinorAS) ||
                MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(Math.Abs(C1 - QuestionLettersMinorAS))
                );


            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D2
            // Condition 2_1

            string[] C2_Array1 = MiscMethods.LetterFullNameArray(QuestionLetters);
            string C2_1 = MiscMethods.JoinStringArrayItems(C2_Array1);
            C2_1 = Boddooh.OmitDuplicateLetters(C2_1, false);
            int[] MinorArray = MiscMethods.StringToMinorAbjadSequence(C2_1);
            int[] MajorArray = MiscMethods.MajorAbjadArray(MinorArray);
            int[] InverseMinorArray = MiscMethods.InverseArray(MinorArray);
            int[] InverseMajorArray = MiscMethods.InverseArray(MajorArray);

            int C2_A = MiscMethods.JoinItemsAndModN(InverseMajorArray, 28);
            bool Condition2_1 = MiscMethods.IsK28Plus20OrK28Minus20(C2_A);

            // Condition 2_2
            string[] C2_Array2 = MiscMethods.LetterFullNameArray(C2_1);
            string C2_2 = MiscMethods.JoinStringArrayItems(C2_Array2);
            C2_2 = Boddooh.OmitDuplicateLetters(C2_2, false);
            int[] MinorArray2 = MiscMethods.StringToMinorAbjadSequence(C2_2);
            int[] MajorArray2 = MiscMethods.MajorAbjadArray(MinorArray2);
            int[] InverseMinorArray2 = MiscMethods.InverseArray(MinorArray2);
            int[] InverseMajorArray2 = MiscMethods.InverseArray(MajorArray2);

            int C2_B = MiscMethods.JoinItemsAndModN(InverseMajorArray2, 28);
            bool Condition2_2 = MiscMethods.IsK28Plus20OrK28Minus20(C2_B);
            
            // Condition 2_3
            bool Condition2_3 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C2_A, C2_B);

            // Condition 3
            int C3_MinorAS = MiscMethods.ArrayItemsSummation(MinorArray2);
            int C3_MajorAS = MiscMethods.ArrayItemsSummation(MajorArray2);

            int C3_A = C3_MajorAS % C3_MinorAS;
            int C3_B = C3_A - C3_MinorAS;
            int C3_C = Math.Abs(C3_A + C3_B);

            bool Condition3 = MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C3_C) ;

            // Condition 4 & 5
            int C4_A = (C3_MajorAS - C3_MinorAS)/9;
            int C4_B = Math.Abs(C3_MinorAS - C4_A) ;
            int C4_C = (C3_MinorAS + C4_A) ;

            bool Condition4 = false;
            bool Condition5 = false;


            if (MiscMethods.IsK9Plus2(C4_B) || MiscMethods.IsK9Plus8(C4_B))
            {
                Condition4 = true;
            }
            if (MiscMethods.IsK9Plus2(C4_C) || MiscMethods.IsK9Plus8(C4_C))
            {
                Condition5 = true;
            }                        

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D3
            // Condition 6
            int[] MajorQuestionLetters = MiscMethods.MajorAbjadArray(QuestionLetters);
            int C6_MinorSummation = MiscMethods.ArrayItemsSummation(QuestionLetters);
            int C6_MajorSummation = MiscMethods.ArrayItemsSummation(MajorQuestionLetters);

            int[] C6_SummationOfMinorAndMajorArray = MiscMethods.Summation(QuestionLetters, MajorQuestionLetters);
            int[] C6_MultiplicationOfMinorAndMajorArray = MiscMethods.Multiplication(QuestionLetters, MajorQuestionLetters);

            int C6_Summation1 = MiscMethods.ArrayItemsSummation(C6_SummationOfMinorAndMajorArray);
            int C6_Summation2 = MiscMethods.ArrayItemsSummation(C6_MultiplicationOfMinorAndMajorArray);

            int C6_A = C6_Summation1 % 28;
            int C6_B = C6_Summation2 % 28;

            bool Condition6 = (MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C6_A, C6_B) || MiscMethods.SummationOrDistanceIsK9Plus2(C6_A, C6_B));

            // Condition 7 & 8
            bool Condition7 = false;
            bool Condition8 = false;
            int C6_C = C6_Summation2 % C6_Summation1;
            int C6_D = C6_C - C6_Summation1;

            if (MiscMethods.IsK9Plus2(C6_C) && (C6_D % 11 == 0))
            {
                Condition7 = true;
                Condition8 = true;
            }
            if (MiscMethods.IsK9Plus2(C6_D) && (C6_C % 11 == 0))
            {
                Condition7 = true;
                Condition8 = true;
            }

            if (MiscMethods.IsK9Plus2(C6_C) || (MiscMethods.IsK9Plus2(C6_D)))
            {
                Condition7 = true;
                Condition8 = true;
            }
            if ((C6_D % 11 == 0) || (C6_C % 11 == 0))
            {
                Condition8 = true;
            }

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D4
            // Condition 9 & 10

            int[] C9_Array1 = MiscMethods.FoldAndDistance(QuestionLetters);
            int[] C9_Array2 = MiscMethods.FoldAndDifferenceLastMinusFirst(QuestionLetters);
            int C9_A = MiscMethods.ArrayItemsSummation(C9_Array1);
            int C9_B = MiscMethods.ArrayItemsSummation(C9_Array2);

            bool Condition9 = false;
            bool Condition10 = false;

            if (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C9_A) || MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(2 * C9_A))
            {
                Condition9 = true;

            }
            if (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(2 * C9_B) || MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C9_B))
            {
                Condition10 = true;

            }

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D5
            // Condition 11

            int[] C11_Count = new int[4]; int[] C11_Summation = new int[4]; 
            int C11 = Boddooh.ComputeSummationOfLettersWRTElementalFactors(QuestionLetters);
            Boddooh.ComputeCountAndSummationOfLetters(QuestionLetters, ref C11_Count, ref C11_Summation);
            bool Condition11 = (C11 % QuestionLetters.Length == 0);

            // Condition 12

            int C11_A = MiscMethods.JoinItemsAndModN(C11_Count, 28);
            int C11_B = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C11_Count), 28);

            int C11_D = MiscMethods.Equivalent1To9(C11_A);
            int C11_C = MiscMethods.Equivalent1To9(C11_B); ;
            int C11_E = C11_C + C11_D;
            bool Condition12 = (C11_E % 9 == 2 || C11_E % 9 ==8);

            // Condition 13

            int[] C13_Array = MiscMethods.CopyArray(C11_Count);
            C13_Array[0] = 2 * C13_Array[0]; C13_Array[1] = 4 * C13_Array[1]; C13_Array[2] = 6 * C13_Array[2]; C13_Array[3] = 8 * C13_Array[3];
            int C11_F = MiscMethods.JoinItemsAndModN(C13_Array, 28);
            int C11_G = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C13_Array), 28);
            int C11_H = C11_F % 9;
            int C11_I = C11_G % 9;
            int C11_J = (C11_H + C11_I) % 9;
            bool Condition13 = (C11_J % 9 == 2 || C11_J % 9 == 8);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D6
            // Condition 14

            int C14_MinorAS = MiscMethods.ArrayItemsSummation(QuestionLetters);
            int C14_A = MiscMethods.JoinItemsAndModN(InverseQuestionLetters, C14_MinorAS);
            int C14_B = C14_MinorAS - C14_A;
            int C14_C = Math.Abs(C14_B - C14_A);
            bool Condition14 = MiscMethods.IsK28(C14_C);

            // Condition 15

            int C15_MajorAS = MiscMethods.ArrayItemsSummation(MiscMethods.MajorAbjadArray(QuestionLetters));
            int[] InverseMajorQuestionLetters = MiscMethods.MajorAbjadArray(InverseQuestionLetters);
            int C15_A = MiscMethods.JoinItemsAndModN(InverseMajorQuestionLetters, C15_MajorAS);
            int C15_B =  Math.Abs(C15_A - C15_MajorAS);
            bool Condition15 = MiscMethods.IsK28(C15_B);

            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2_1) Rank++;
            if (Condition2_2) Rank++;
            if (Condition2_3) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            if (Condition11) Rank++;
            if (Condition12) Rank++;
            if (Condition13) Rank++;
            if (Condition14) Rank++;
            if (Condition15) Rank++;
            // out of 17
            return Rank;
        }

        public static int Conditions_InputManagment_B(int[] QuestionLetters, Boddooh4By4Table[] B4BTs)
        {
            int Length = QuestionLetters.Length ;
           
            Boddooh4By4TableArray B4B4Array = new Boddooh4By4TableArray(B4BTs);

            // Condition 1
            bool Condition1 = MiscMethods.IsK28(B4B4Array.B4BTSumSumOfCol1Mod28);
            // Condition 2
            bool Condition2 = MiscMethods.IsK28(B4B4Array.B4BTSumSumOfCol2Mod28);
            // Condition 3
            bool Condition3 = MiscMethods.IsK28(B4B4Array.B4BTSumSumOfCol3Mod28);
            // Condition 4
            bool Condition4 = MiscMethods.IsK28(B4B4Array.B4BTSumSumOfCol4Mod28);

            // Condition 5
            int[] C5_ArrayA = MiscMethods.InverseArray(B4B4Array.B4BTMulSumOfColsMod28Array);
            int[] C5_ArrayB = MiscMethods.CopyArray(B4B4Array.B4BTMulSumOfColsMod28Array);

            int C5_C1 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol1, 28));
            int C5_C2 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol2, 28));
            int C5_C3 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol3, 28));
            int C5_C4 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol4, 28));
            int[] C5_ArrayC = MiscMethods.GetArray(C5_C4, C5_C3, C5_C2, C5_C1);
            int C5_JoinA = MiscMethods.JoinDigits(C5_ArrayA[0], C5_ArrayA[1], C5_ArrayA[2], C5_ArrayA[3]);
            int C5_JoinCInverse = MiscMethods.JoinDigits(C5_C4, C5_C3, C5_C2, C5_C1);
            int C5 = Math.Abs(C5_JoinA - C5_JoinCInverse);
            bool Condition5 = MiscMethods.IsK28Plus20(C5);

            // Condition 6
            bool Condition6 = MiscMethods.IsK28Plus20(C5_ArrayA[3]);

            // Condition 7
            bool Condition7 = MiscMethods.IsK28(C5_ArrayA[1]);

            // Condition 8
            bool Condition8 = MiscMethods.IsK28(C5_ArrayA[0]);

            // Condition 9
            int C9_JoinAInverse = MiscMethods.JoinDigits(C5_ArrayA[3], C5_ArrayA[2], C5_ArrayA[1], C5_ArrayA[0]);
            int C9_1 = C9_JoinAInverse % 28;
            int C9_2 = C5_JoinA % 28;
            bool Condition9 = MiscMethods.IsK28(C9_1 + C9_2);

            // Condition 10
            int C10_JoinCInverse = MiscMethods.JoinDigits(C5_ArrayC[3], C5_ArrayC[2], C5_ArrayC[1], C5_ArrayC[0]);
            int C10_JoinC = MiscMethods.JoinDigits(C5_ArrayC[0], C5_ArrayC[1], C5_ArrayC[2], C5_ArrayC[3]);

            int C10_1 = C10_JoinCInverse % 28;
            int C10_2 = C10_JoinC % 28;
            bool Condition10 = MiscMethods.IsK28Minus20(C10_1 + C10_2);


            // Condition 11
            bool Condition11 = MiscMethods.IsK28Minus20(B4B4Array.B4BTJoinSumOfColsMod28Array[0]);

            // Condition 12
            bool Condition12 = MiscMethods.IsK28(B4B4Array.B4BTJoinSumOfColsMod28Array[3]);

            // Condition 13
            int C13_A1 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(B4B4Array.SumCol1, 28));
            int C13_B1 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(B4B4Array.SumCol2, 28));
            int C13_C1 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(B4B4Array.SumCol3, 28));
            int C13_D1 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(B4B4Array.SumCol4, 28));
            int C13_A2 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4Array.SumCol1), 28));
            int C13_B2 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4Array.SumCol2), 28));
            int C13_C2 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4Array.SumCol3), 28));
            int C13_D2 = MiscMethods.EquivalentNumber(MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4Array.SumCol4), 28));

            // Condition 13
            bool Condition13 = MiscMethods.IsK28(C13_A1);

            // Condition 14
            bool Condition14 = MiscMethods.IsK28Plus20(C13_B1);

            // Condition 15
            bool Condition15 = MiscMethods.IsK28(C13_D1);

            // Condition 16
            int C16_1 = MiscMethods.JoinDigits(C13_A1, C13_B1, C13_C1, C13_D1);
            C16_1 = C16_1 % 28;
            int C16_2 = MiscMethods.JoinDigits(C13_A2, C13_B2, C13_C2, C13_D2) ;
            C16_2 = C16_2 % 28;
            int C16_A = C16_1 + C16_2;
            int C16_B = Math.Abs(C16_1 - C16_2);

            bool Condition16 = false;
            if (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C16_A) || MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C16_B))
                Condition16 = true;
            if (MiscMethods.EquivalentNumber(C16_A) == 2 || MiscMethods.EquivalentNumber(C16_B)==2)
                Condition16 = true;

            // Condition 17
            int C17 = (B4B4Array.SumColsMod28_Summation);
            bool Condition17 = MiscMethods.IsK28(C17);

            // Condition 18
            int C18 = (B4B4Array.InverseSumColsMod28_Summation);
            bool Condition18 = MiscMethods.IsK28(C18);

            // Condition 19
            bool Condition19 = true;
            if (Length % 2 == 0)
            {
                for (int i = 0; i < (Length) / 2 && Condition19; i++)
                {
                    int t1 = B4B4Array.SumColsMod28[i];
                    int s1 = B4B4Array.InverseSumColsMod28[i];
                    int t2 = B4B4Array.SumColsMod28[B4B4Array.SumColsMod28.Length - 1 - i];
                    int s2 = B4B4Array.InverseSumColsMod28[B4B4Array.InverseSumColsMod28.Length - 1 - i];
                    if (i<(Length) / 2-1)
                    {
                        if (!MiscMethods.SummationOrDistancesAreEquTo20or8(t1, s1, t2, s2))
                            Condition19 = false;
                    }
                    else
                    {
                        int si = t1 + s1;
                        int di = Math.Abs(t1 - s1);
                        int sj = t2 + s2;
                        int dj = Math.Abs(t2 - s2);
                        if (!(
                            MiscMethods.One8AndOne20(si , sj) || MiscMethods.One8AndOne20(si , dj) ||
                MiscMethods.One8AndOne20(di,sj) || MiscMethods.One8AndOne20(di , dj)


                            ))
                            Condition19 = false;
                    }
                }
                
            }
            else
            {
                for (int i = 0; i < (Length - 1) / 2 && Condition19; i++)
                {
                    int t1 = B4B4Array.SumColsMod28[i];
                    int s1 = B4B4Array.InverseSumColsMod28[i];
                    int t2 = B4B4Array.SumColsMod28[B4B4Array.SumColsMod28.Length - 1 - i];
                    int s2 = B4B4Array.InverseSumColsMod28[B4B4Array.InverseSumColsMod28.Length - 1 - i];
                    
                        if (!MiscMethods.SummationOrDistancesAreEquTo20or8(t1, s1, t2, s2))
                            Condition19 = false;
                    
                }
                if (Condition19)
                {
                    int MiddleIndex = B4B4Array.SumColsMod28.Length / 2;
                    int t1 = B4B4Array.SumColsMod28[MiddleIndex ]; int s1 = B4B4Array.InverseSumColsMod28[MiddleIndex ];
                    int j1 = (t1 + t1); int f1 = Math.Abs(t1 - t1);
                    Condition19 = (Condition19 && (
                        MiscMethods.IsK28(j1) || MiscMethods.IsK28(f1)

                         ));

                }

            }

            // Condition 20
            int C20_1 = MiscMethods.JoinItemsAndModN(B4B4Array.Sum, 28);
            int C20_2 = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray (B4B4Array.Sum), 28);
            bool Condition20 = MiscMethods.IsK28(C20_1 + C20_2);


   
             bool Condition21 = true;
            int QCount = B4B4Array.Sum.Length / 4;
            if (B4B4Array.Sum.Length % 4 != 0)
                QCount++;
            bool K28Seen = false;
            bool K28P20Seen = false;
            bool K28M20Seen = false;
            if (QCount%2==0)
            {
                 for (int i = 0; i < QCount && Condition21; i++)
                {
                    int Sum = 0;
                    Sum += B4B4Array.Sum[(4 * i + 0) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 1) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 2) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 3) % B4B4Array.Sum.Length];
                    if (!MiscMethods.IsK28Plus20OrK28Minus20(Sum))
                    {
                        Condition21 = false;
                    }
                    else
                    {
                        if (MiscMethods.IsK28Plus20(Sum))
                        {
                            if (K28P20Seen)
                                Condition21 = false;
                            K28P20Seen = true;
                            K28M20Seen = false;
                        }
                        else
                        {
                            if (K28M20Seen)
                                Condition21 = false;
                            K28P20Seen = false;
                            K28M20Seen = true;

                        }
                    }  
                }
            }
            else
            {
                 for (int i = 0; i < QCount && Condition21; i++)
                {
                    int Sum = 0;
                    Sum += B4B4Array.Sum[(4 * i + 0) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 1) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 2) % B4B4Array.Sum.Length];
                    Sum += B4B4Array.Sum[(4 * i + 3) % B4B4Array.Sum.Length];
                    if (!MiscMethods.IsK28Plus20OrK28Minus20(Sum) && !MiscMethods.IsK28(Sum))
                    {
                        Condition21 = false;
                    }
                    else
                    {
                        if (MiscMethods.IsK28(Sum))
                        {
                            if (K28Seen)
                                Condition21 = false;
                            K28Seen = true;                            
                        }
                        if (MiscMethods.IsK28Plus20(Sum))
                        {
                            if (K28P20Seen)
                                Condition21 = false;
                            K28P20Seen = true;
                            K28M20Seen = false;
                        }
                        if (MiscMethods.IsK28Minus20(Sum))
                        {
                            if (K28M20Seen)
                                Condition21 = false;
                            K28P20Seen = false;
                            K28M20Seen = true;

                        }
                    }  
                }
            }
           

             
            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            if (Condition11) Rank++;
            if (Condition12) Rank++;
            if (Condition13) Rank++;
            if (Condition14) Rank++;
            if (Condition15) Rank++;
            if (Condition16) Rank++;
            if (Condition17) Rank++;
            if (Condition18) Rank++;
            if (Condition19) Rank++;
            if (Condition20) Rank++;
            if (Condition21) Rank++;

            // Out of 21

            return Rank ;

        }


        public static int Conditions_InputManagment_C(int[] QuestionLetters, Boddooh4By4Table[] B4BTs)
        {
            int Length = QuestionLetters.Length;
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B1

            // Condition 1
            int[] InverseInputArray = MiscMethods.InverseArray(QuestionLetters);
            int[] MajorInverseInputArray = MiscMethods.MajorAbjadArray(InverseInputArray);
            int C1 = MiscMethods.JoinItemsAndModN(MajorInverseInputArray, BoddoohNumbers.TwentyEight);
            bool Condition1 = MiscMethods.IsK28Plus20OrK28Minus20(C1);

            // Condition 2            
            int FirstLetter = QuestionLetters[0];
            int LastLetter = QuestionLetters[QuestionLetters.Length - 1];
            int C2_A = MiscMethods.JoinItemsAndModN(InverseInputArray, BoddoohNumbers.TwentyEight);
            int C2_B = MiscMethods.JoinItemsAndModN(QuestionLetters, BoddoohNumbers.TwentyEight);
            int C2_C = FirstLetter + LastLetter;
            int C2_D = C2_A + C2_B;
            int C2_E = C2_A * C2_B;
            int C2_F = C2_C + C2_D;
            int C2_G = Math.Abs(C2_D - C2_C);
            bool Condition2 = (C2_F % BoddoohNumbers.TwentyEight == 2);
            // Condition 3
            bool Condition3 = (C2_G % BoddoohNumbers.TwentyEight == 8);
            // Condition 4
            bool Condition4 = MiscMethods.IsK9Plus2(C2_E);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B2
            // Condition 5
            int[,] C5_Matrix = new int[Length - 3, 4];
            for (int i = 0; i < Length - 3; i++)
                for (int j = 0; j < 4; j++)
                {
                    C5_Matrix[i, j] = QuestionLetters[i + j];
                }
            int C5_SumOfCol1 = 0;
            int C5_SumOfCol2 = 0;
            int C5_SumOfCol3 = 0;
            int C5_SumOfCol4 = 0;
            int[] C5_SumOfRows = new int[Length - 3];
            for (int i = 0; i < Length - 3; i++)
            {
                C5_SumOfCol1 += C5_Matrix[i, 0];
                C5_SumOfCol2 += C5_Matrix[i, 1];
                C5_SumOfCol3 += C5_Matrix[i, 2];
                C5_SumOfCol4 += C5_Matrix[i, 3];
                C5_SumOfRows[i] = C5_Matrix[i, 0] + C5_Matrix[i, 1] + C5_Matrix[i, 2] + C5_Matrix[i, 3];
            }

            int t = 1;
            int C5_Sum = 0;
            for (int step = Length - 3; step >= 3; step--)
            {
                for (int i = 0; i < C5_SumOfRows.Length - t; i++)
                {
                    C5_SumOfRows[i] = Math.Abs(C5_SumOfRows[i] - C5_SumOfRows[i + 1]);
                    C5_Sum += C5_SumOfRows[i];
                }
                t++;
            }

            bool Condition5 = MiscMethods.IsK28(C5_Sum);

            // Condition 6
            int C5_SumOfCol1Mod9 = C5_SumOfCol1 % 9; int C5_SumOfCol1Mod28 = C5_SumOfCol1 % 28;
            int C5_SumOfCol2Mod9 = C5_SumOfCol2 % 9; int C5_SumOfCol2Mod28 = C5_SumOfCol2 % 28;
            int C5_SumOfCol3Mod9 = C5_SumOfCol3 % 9; int C5_SumOfCol3Mod28 = C5_SumOfCol3 % 28;
            int C5_SumOfCol4Mod9 = C5_SumOfCol4 % 9; int C5_SumOfCol4Mod28 = C5_SumOfCol4 % 28;

            int C5_SumOfCols = C5_SumOfCol1 + C5_SumOfCol2 + C5_SumOfCol3 + C5_SumOfCol4;
            bool Condition6 = MiscMethods.IsK28(C5_SumOfCols);

            // Condition 7
            int C7_A = Math.Abs(C5_SumOfCol1Mod28 - C5_SumOfCol2Mod28);
            int C7_B = Math.Abs(C5_SumOfCol1Mod9 - C5_SumOfCol2Mod9);
            int C7_C = C5_SumOfCol1Mod9 + C5_SumOfCol2Mod9 + C5_SumOfCol3Mod9 + C5_SumOfCol4Mod9;
            int C7_D = Math.Abs(C5_SumOfCol3Mod9 - C5_SumOfCol4Mod9);
            int C7_E = C7_B + C7_D;
            int C7_F = C7_E + C7_C;
            bool Condition7 = MiscMethods.IsK28(C7_F);

            // Condition 8
            int C7_G = Math.Abs(C5_SumOfCol3Mod28 - C5_SumOfCol4Mod28);
            bool Condition8 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C7_A, C7_G);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B3
            // Condition 9
            bool Condition9 = false;
            if (true)
            {
                Condition9 = true;
                for (int i = 0; i < Length/2 && Condition9; i++)
                {
                    int s1 = 0; int s2 = 0; int t1 = 0; int t2 = 0;
                    if (i < Length / 2 - 1)
                    {
                         s1 = QuestionLetters[i];
                         s2 = QuestionLetters[i+1];
                         t1 = QuestionLetters[Length-1-i];
                         t2 = QuestionLetters[Length - 1 - i-1];
                    }
                    else
                    {
                         s1 = QuestionLetters[0];
                         s2 = QuestionLetters[Length - 1];
                         int Mid = Length / 2;
                         t1 = QuestionLetters[Mid];
                         t2 = QuestionLetters[Mid - 1];
                    }
                    if (!MiscMethods.s1Minuss2Ors2Minuss1Ors1Pluss2PLUSTheSameFortIsK9plus2(s1, s2, t1, t2))
                        Condition9 = false;
                }
            }

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B4
            // Condition 10 to 13
            bool Condition10 = false;
            bool Condition11 = false;
            bool Condition12 = false;
            bool Condition13 = false;

            if (Length % 2 == 0)
            {
                int[] C10_EvenItems = MiscMethods.ItemsWithEvenIndices(QuestionLetters);
                int[] C10_OddItems = MiscMethods.ItemsWithOddIndices(QuestionLetters);
                int[] C10_EvenOddItemsDistance = MiscMethods.Distance(C10_EvenItems, C10_OddItems);
                int[] C10_EvenOddItemsSummation = MiscMethods.Summation(C10_EvenItems, C10_OddItems);
                int[] C10_D = MiscMethods.FoldAndDistance(C10_EvenOddItemsSummation);

                int C10_EvenItemsSummationN = MiscMethods.ArrayItemsSummation(C10_EvenItems);
                int C10_OddItemsSummationM = MiscMethods.ArrayItemsSummation(C10_OddItems);
                int C10_A = MiscMethods.ArrayItemsSummation(C10_EvenOddItemsDistance);
                int C10_B = 2 * C10_EvenItemsSummationN * C10_OddItemsSummationM;
                int C10_C = MiscMethods.ArrayItemsSummation(C10_D);
                Condition10 = MiscMethods.IsK9Plus2(C10_A);
                Condition11 = MiscMethods.IsK28Plus20OrK28Minus20(C10_B);
                Condition12 = MiscMethods.IsK9Plus2(C10_C);
                Condition13 = (C10_A == C10_C);

            }

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B5
            // Condition 14 & 15
            bool Condition14 = false;
            bool Condition15 = false;

            if (Length % 2 == 0)
            {
                int[] C14_Distance = MiscMethods.FoldAndDistance(QuestionLetters);
                int[] C14_Difference = MiscMethods.FoldAndDifferenceLastMinusFirst(QuestionLetters);
                int C14_A = MiscMethods.ArrayItemsSummation(C14_Distance);
                int C14_B = MiscMethods.ArrayItemsSummation(C14_Difference);

                if (MiscMethods.IsK28Plus20OrK28Minus20(C14_A) || MiscMethods.IsK28Plus20OrK28Minus20(2 * C14_A))
                {
                    Condition14 = true;
                }
                if (MiscMethods.IsK28Plus20OrK28Minus20(C14_B) || MiscMethods.IsK28Plus20OrK28Minus20(2 * C14_B))
                {
                    Condition15 = true;
                }
            }

            // Condition 16 & 17
            int[] C16_Array = MiscMethods.Multiplication(QuestionLetters, MiscMethods.InverseArray(QuestionLetters));
            int C16_C = MiscMethods.ArrayItemsSummation(C16_Array);
            bool Condition16 = (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(2*C16_C) || (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C16_C/2) && (C16_C%2==0)));
           

            // Condition 18
            int C18 = MiscMethods. ArrayItemsMultiplicationModN(QuestionLetters, 28);
            bool Condition18 = MiscMethods.IsK28(C18);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B6
            // Condition 19 to 
            bool Condition19 = false;
            
       
            int C19_L = Length / 2;
            int C19_R = Length / 2;
            int[] C19_ArrayL = MiscMethods.SubArray(QuestionLetters, 0, C19_L);
            int[] C19_ArrayR = MiscMethods.SubArray(QuestionLetters, C19_L, C19_R);
            int C19_SumL = MiscMethods.ArrayItemsSummation(C19_ArrayL);
            int C19_SumR = MiscMethods.ArrayItemsSummation(C19_ArrayR);
            if (Length % 2 == 0)
            {

                int C19_Dis = Math.Abs(C19_SumL - C19_SumR);
                Condition19 = MiscMethods.IsK28Plus20OrK28Minus20(C19_Dis); 

              
                //Condition19 = Condition19 || (MiscMethods.IsK9Plus2(C19_SumL) || MiscMethods.IsK9Plus2(C19_SumR));
                //Condition20 = Condition20 || (FirstAndSecondHalfSummationIsOk(C19_SumL, C19_SumR));
                //int C21 = (C19_SumL * C19_SumR) % 28;   Condition21 = Condition21 || (MiscMethods.IsK9Plus2(C21));
                //for (int i = 1; i <= 4 && !Condition22; i++)
                //{
                //    if (MiscMethods.IsK9Plus2(C19_SumL) && ((C19_SumL * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumL * i))
                //        Condition22 = true;
                //    if (MiscMethods.IsK9Plus2(C19_SumR) && ((C19_SumR * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumR * i))
                //        Condition22 = true;

                //}




            }
            else
            {
                int MiddleElement = MiscMethods.MiddleElement(QuestionLetters);
                int C19_Dis = Math.Abs((C19_SumL + MiddleElement) - C19_SumR);
                Condition19 = MiscMethods.IsK28Plus20OrK28Minus20(C19_Dis);

                C19_Dis = Math.Abs(C19_SumL - (C19_SumR + MiddleElement));
                Condition19 = Condition19 || MiscMethods.IsK28Plus20OrK28Minus20(C19_Dis);
                

                //int C19_L = Length / 2;
                //int C19_R = Length / 2+1;
                //int[] C19_ArrayL = MiscMethods.SubArray(QuestionLetters, 0, C19_L);
                //int[] C19_ArrayR = MiscMethods.SubArray(QuestionLetters, C19_L, C19_R);
                //int C19_SumL = MiscMethods.ArrayItemsSummation(C19_ArrayL);
                //int C19_SumR = MiscMethods.ArrayItemsSummation(C19_ArrayR);
                //Condition19 = Condition19 || (MiscMethods.IsK9Plus2(C19_SumL) || MiscMethods.IsK9Plus2(C19_SumR));
                //Condition20 = Condition20 || (FirstAndSecondHalfSummationIsOk(C19_SumL, C19_SumR));
                //int C21 = (C19_SumL * C19_SumR) % 28; Condition21 = Condition21 || (MiscMethods.IsK9Plus2(C21));
                //for (int i = 1; i <= 4 && !Condition22; i++)
                //{
                //    if (MiscMethods.IsK9Plus2(C19_SumL) && ((C19_SumL * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumL * i))
                //        Condition22 = true;
                //    if (MiscMethods.IsK9Plus2(C19_SumR) && ((C19_SumR * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumR * i))
                //        Condition22 = true;

                //}



                //C19_L = Length / 2+1;
                //C19_R = Length / 2 ;
                //C19_ArrayL = MiscMethods.SubArray(QuestionLetters, 0, C19_L);
                //C19_ArrayR = MiscMethods.SubArray(QuestionLetters, C19_L, C19_R);
                //C19_SumL = MiscMethods.ArrayItemsSummation(C19_ArrayL);
                //C19_SumR = MiscMethods.ArrayItemsSummation(C19_ArrayR);
                //Condition19 = Condition19 || (MiscMethods.IsK9Plus2(C19_SumL) || MiscMethods.IsK9Plus2(C19_SumR));
                //Condition20 = Condition20 || (FirstAndSecondHalfSummationIsOk(C19_SumL, C19_SumR));
                //C21 = (C19_SumL * C19_SumR) % 28; Condition21 = Condition21 || (MiscMethods.IsK9Plus2(C21));

                //for (int i = 1; i <= 4 && !Condition22; i++)
                //{
                //    if (MiscMethods.IsK9Plus2(C19_SumL) && ((C19_SumL * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumL * i))
                //        Condition22 = true;
                //    if (MiscMethods.IsK9Plus2(C19_SumR) && ((C19_SumR * i) % 4 == 0) && MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C19_SumR * i))
                //        Condition22 = true;

                //}


            }

            

            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            if (Condition11) Rank++;
            if (Condition12) Rank++;
            if (Condition13) Rank++;
            if (Condition14) Rank++;
            if (Condition15) Rank++;
            if (Condition16) Rank++;
            if (Condition18) Rank++;
            if (Condition19) Rank++;
            

            // out of 18;
            return Rank;
        }

        public static int Conditions_InputManagment_D(int[] QuestionLetters, Boddooh4By4Table[] B4BTs)
        {
            int Rank = 0;
            int Length = QuestionLetters.Length;

            int[] Reminder28 = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                Reminder28[i] = MiscMethods.EquivalentNumber(B4BTs[i].SummationOfItems);
            }
            int TriplePairsCount = Length / 6;

            for (int i = 0; i < TriplePairsCount; i++)
            {
                int TUp = Reminder28[i * 3] + Reminder28[i * 3 + 1] + Reminder28[i * 3 + 2];
                int TDown = Reminder28[Length - 1 - (i * 3)] + Reminder28[Length - 1 - (i * 3 + 1)] + Reminder28[Length - 1 - (i * 3 + 2)];
                if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TUp, TDown))
                    Rank++;
            }
            if (Length % 6 > 0)
            {
                if (Length % 6 == 1)
                {
                    int T = Reminder28[Length / 2];
                    if (InputManagement.IsAVerySpecialNumber(T))
                        Rank++;
                }
                if (Length % 6 == 2)
                {
                    int T = Reminder28[Length / 2] + Reminder28[Length / 2 - 1];
                    if (InputManagement.IsAVerySpecialNumber(T))
                        Rank++;
                }
                if (Length % 6 == 3)
                {
                    int T = Reminder28[Length / 2 + 1] + Reminder28[Length / 2] + Reminder28[Length / 2 - 1];
                    if (InputManagement.IsAVerySpecialNumber(T))
                        Rank++;
                }
                if (Length % 6 == 4)
                {
                    int TAU = Reminder28[Length / 2 + 1];
                    int TAD = Reminder28[Length / 2] + Reminder28[Length / 2 - 1] + Reminder28[Length / 2 - 2];
                    int TBU = Reminder28[Length / 2 + 1] + Reminder28[Length / 2] + Reminder28[Length / 2 - 1];
                    int TBD = Reminder28[Length / 2 - 2];
                    if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TAU, TAD))
                    {
                        Rank++;
                    }
                    else
                    {
                        if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TBU, TBD))
                            Rank++;
                    }

                }
                if (Length % 6 == 5)
                {
                    int TAU = Reminder28[Length / 2 + 2] + Reminder28[Length / 2 + 1];
                    int TAD = Reminder28[Length / 2] + Reminder28[Length / 2 - 1] + Reminder28[Length / 2 - 2];
                    int TBU = Reminder28[Length / 2 + 2] + Reminder28[Length / 2 + 1] + Reminder28[Length / 2];
                    int TBD = Reminder28[Length / 2 - 1] + Reminder28[Length / 2 - 2];
                    if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TAU, TAD))
                    {
                        Rank++;
                    }
                    else
                    {
                        if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TBU, TBD))
                            Rank++;
                    }
                }
            }

            int SextuplesCount = Length / 6;
            int TwelevetuplesCount = Length / 12;
            int LengthRem6 = Length % 6;
            int[] Reminder9 = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                Reminder9[i] = MiscMethods.Equivalent1To9(B4BTs[i].SummationOfItems);
            }
            for (int i = 0; i < TwelevetuplesCount; i++)
            {
                int TU1 = Math.Abs(Reminder9[i * 6] - Reminder9[i * 6 + 3]);
                int TU2 = Math.Abs(Reminder9[i * 6 + 1] - Reminder9[i * 6 + 4]);
                int TU3 = Math.Abs(Reminder9[i * 6 + 2] - Reminder9[i * 6 + 5]);

                int TD3 = Math.Abs(Reminder9[Length - 1 - (i * 6)] - Reminder9[Length - 1 - (i * 6 + 3)]);
                int TD2 = Math.Abs(Reminder9[Length - 1 - (i * 6 + 1)] - Reminder9[Length - 1 - (i * 6 + 4)]);
                int TD1 = Math.Abs(Reminder9[Length - 1 - (i * 6 + 2)] - Reminder9[Length - 1 - (i * 6 + 5)]);

                if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TU1, TD1))
                    Rank++;

                if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TU2, TD2))
                    Rank++;

                if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(TU3, TD3))
                    Rank++;

            }

            if (LengthRem6 > 0)
            {
                int FirstOne = 6 * TwelevetuplesCount;
                if (LengthRem6 == 1)
                {
                    int T = Reminder9[FirstOne];
                    if (InputManagement.IsAVerySpecialNumber(T))
                        Rank++;
                }
                if (LengthRem6 == 2)
                {
                    int T1 = Math.Abs(Reminder9[FirstOne]);
                    int T2 = 0;
                    int T3 = Math.Abs(Reminder9[FirstOne + 1]);
                    if (InputManagement.IsAVerySpecialNumber(T1)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T2)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T3)) Rank++;

                }
                if (LengthRem6 == 3)
                {
                    int T1 = Math.Abs(Reminder9[FirstOne]);
                    int T2 = Math.Abs(Reminder9[FirstOne + 1]);
                    int T3 = Math.Abs(Reminder9[FirstOne + 2]);
                    if (InputManagement.IsAVerySpecialNumber(T1)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T2)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T3)) Rank++;
                }
                if (LengthRem6 == 4)
                {
                    int T1 = Math.Abs(Reminder9[FirstOne]);
                    int T2 = Math.Abs(Reminder9[FirstOne + 1] - Reminder9[FirstOne + 2]);
                    int T3 = Math.Abs(Reminder9[FirstOne + 3]);
                    if (InputManagement.IsAVerySpecialNumber(T1)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T2)) Rank++;
                    if (InputManagement.IsAVerySpecialNumber(T3)) Rank++;
                }
                if (LengthRem6 == 5)
                {
                    int TA1 = Math.Abs(Reminder9[FirstOne] - Reminder9[FirstOne + 2]);
                    int TA2 = Math.Abs(Reminder9[FirstOne + 1] - Reminder9[FirstOne + 3]);
                    int TA3 = Math.Abs(Reminder9[FirstOne + 4]);

                    int RankA = 0;
                    if (InputManagement.IsAVerySpecialNumber(TA1)) RankA++;
                    if (InputManagement.IsAVerySpecialNumber(TA2)) RankA++;
                    if (InputManagement.IsAVerySpecialNumber(TA3)) RankA++;

                    int TB1 = Math.Abs(Reminder9[FirstOne]);
                    int TB2 = Math.Abs(Reminder9[FirstOne + 1] - Reminder9[FirstOne + 3]);
                    int TB3 = Math.Abs(Reminder9[FirstOne + 2] - Reminder9[FirstOne + 4]);

                    int RankB = 0;
                    if (InputManagement.IsAVerySpecialNumber(TB1)) RankB++;
                    if (InputManagement.IsAVerySpecialNumber(TB2)) RankB++;
                    if (InputManagement.IsAVerySpecialNumber(TB3)) RankB++;

                    Rank += (Math.Max(RankA, RankB));
                }
            }

            return Rank;
        }



        public static bool FirstAndSecondHalfSummationIsOk(int fhs, int shs)
        {
            if (Boddooh. DEBUG)
                return true;
            int i1 = fhs % shs;
            int i2 = shs % i1;
            int j1 = shs % fhs;
            int j2 = fhs % j1;
            return (MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(i2) || MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(j2));
            

        }
        public static int Conditions_F(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Length = QuestionLetters.Length;

            bool Condition1 = false;
            bool Condition2 = false;
            bool Condition3 = false;
            bool Condition4 = false;
            bool Condition5 = false;
            int[] EvenItemsAnswerLetters = MiscMethods.ItemsWithEvenIndices(AnswerLetters);
            int[] OddItemsAnswerLetters = MiscMethods.ItemsWithOddIndices(AnswerLetters);
            int[] EvenItemsQuestionLetters = MiscMethods.ItemsWithEvenIndices(QuestionLetters);
            int[] OddItemsQuestionLetters= MiscMethods.ItemsWithOddIndices(QuestionLetters);

            int[] MajorEvenItemsAnswerLetters = MiscMethods.MajorAbjadArray(EvenItemsAnswerLetters);
            int[] MajorOddItemsAnswerLetters = MiscMethods.MajorAbjadArray(OddItemsAnswerLetters);
            int[] MajorEvenItemsQuestionLetters = MiscMethods.MajorAbjadArray(EvenItemsQuestionLetters);
            int[] MajorOddItemsQuestionLetters = MiscMethods.MajorAbjadArray(OddItemsQuestionLetters);

            int C1_A = MiscMethods.ArrayItemsSummation(EvenItemsQuestionLetters);
            int C1_B = MiscMethods.ArrayItemsSummation(OddItemsQuestionLetters);
            int C1_C = MiscMethods.ArrayItemsSummation(EvenItemsAnswerLetters);
            int C1_D = MiscMethods.ArrayItemsSummation(OddItemsAnswerLetters);

            int C4_A = MiscMethods.ArrayItemsSummation(MajorEvenItemsQuestionLetters);
            int C4_B = MiscMethods.ArrayItemsSummation(MajorOddItemsQuestionLetters);
            int C4_C = MiscMethods.ArrayItemsSummation(MajorEvenItemsAnswerLetters);
            int C4_D = MiscMethods.ArrayItemsSummation(MajorOddItemsAnswerLetters);


            if (Length % 2 == 0)
            {
                // Condition 1
                int C1 = Math.Abs(C1_B - C1_C);
                Condition1 = MiscMethods.IsK9Plus2(C1);

                // Condition 2
                int C2 = Math.Abs(C1_A - C1_D);
                Condition2 = (C2 % 28 == 2);

                // Condition 3
                //int[] C3_Summation = MiscMethods.Summation(EvenItemsAnswerLetters, OddItemsAnswerLetters);
                //C3_Summation = MiscMethods.Summation(C3_Summation, EvenItemsQuestionLetters);
                //C3_Summation = MiscMethods.Summation(C3_Summation, OddItemsQuestionLetters);
                //int[] C3_Array = MiscMethods.FoldAndDistance(C3_Summation);
                //C3_Array = MiscMethods.IterativelyComputeSummationOfDigits(C3_Array);
                //while (C3_Array.Length >2)
                //{
                //    C3_Array = MiscMethods.SummationOfNeighboringItems(C3_Array);
                //}
                //Condition3 = (MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C3_Array[0], C3_Array[1])
                //    || MiscMethods.SummationOrDistanceIsK9Plus2(C3_Array[0], C3_Array[1]));

                // Condition 4
                int C4 = Math.Abs(C4_A - C4_C);
                Condition4 = (MiscMethods.IsK28(C4) || MiscMethods.IsK9Plus2(C4));

                // Condition 5
                int C5 = Math.Abs(C4_B - C4_D);
                Condition5 = (C2 % 28 == 2);

            }

            

            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            //if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            // Out Of 4
            return Rank;

        }
        public static int Conditions_E(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Length = QuestionLetters.Length - 1;
            Boddooh4By4Table[] B4BTs = new Boddooh4By4Table[Length];
            for (int i = 0; i < Length; i++)
            {
                B4BTs[i] = new Boddooh4By4Table(QuestionLetters[i], QuestionLetters[i + 1], AnswerLetters[i], AnswerLetters[i + 1]);
            }
            Boddooh4By4TableArray B4B4Array = new Boddooh4By4TableArray(B4BTs);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page E1
           // Condition 1

            bool Condition1 = (MiscMethods.IsK28Plus20OrK28Minus20(B4B4Array.BranchMulSumOfCol1Mod28)
                || MiscMethods.IsK28Plus20OrK28Minus20(B4B4Array.BranchMulSumOfCol2Mod28) ||
                MiscMethods.IsK28Plus20OrK28Minus20(B4B4Array.BranchMulSumOfCol3Mod28)
                || MiscMethods.IsK28Plus20OrK28Minus20(B4B4Array.BranchMulSumOfCol4Mod28));
            // Condition 2
            ////B4B4Array.BranchJoinSumOfCol1Mod28 = 2;
           //// B4B4Array.B4BTJoinSumOfColsMod28Array[0] = 2;

            int C2_Temp1 = 0;
            int index1 = 0;
            if (MiscMethods.IsK28(B4B4Array.BranchJoinSumOfCol1Mod28)) { C2_Temp1++; index1 = 1; }
            if (MiscMethods.IsK28(B4B4Array.BranchJoinSumOfCol2Mod28)) { C2_Temp1++; index1 = 2; }
            if (MiscMethods.IsK28(B4B4Array.BranchJoinSumOfCol3Mod28)) { C2_Temp1++; index1 = 3; }
            if (MiscMethods.IsK28(B4B4Array.BranchJoinSumOfCol4Mod28)) { C2_Temp1++; index1 = 4; }
            
            int index2 = 0;
            int C2_Temp2 = 0;
            int BranchJoinSumOfCol1 = B4B4Array.BranchJoin[0] + B4B4Array.BranchJoin[1] + B4B4Array.BranchJoin[2] + B4B4Array.BranchJoin[3];
            int BranchJoinSumOfCol2 = B4B4Array.BranchJoin[4] + B4B4Array.BranchJoin[5] + B4B4Array.BranchJoin[6] + B4B4Array.BranchJoin[7];
            int BranchJoinSumOfCol3 = B4B4Array.BranchJoin[8] + B4B4Array.BranchJoin[9] + B4B4Array.BranchJoin[10] + B4B4Array.BranchJoin[11];
            int BranchJoinSumOfCol4 = B4B4Array.BranchJoin[12] + B4B4Array.BranchJoin[13] + B4B4Array.BranchJoin[14] + B4B4Array.BranchJoin[15];
            if (MiscMethods.IsK9Plus2(BranchJoinSumOfCol1)) { C2_Temp2++; index2 = 1; }
            if (MiscMethods.IsK9Plus2(BranchJoinSumOfCol2)) { C2_Temp2++; index2 = 2; }
            if (MiscMethods.IsK9Plus2(BranchJoinSumOfCol3)) { C2_Temp2++; index2 = 3; }
            if (MiscMethods.IsK9Plus2(BranchJoinSumOfCol4)) { C2_Temp2++; index2 = 4; }

            bool Condition2 = false;
            if (C2_Temp1>=1 && C2_Temp2>=1)
            {
                if (C2_Temp1 > 1 || C2_Temp2 > 1)
                    Condition2 = true;
                else
                {
                    if (index1 != index2)
                        Condition2 = true;
                }
            }

            // Condition 3
            int C3_A = MiscMethods.ArrayItemsSummation(B4B4Array.B4BTMulSumOfColsMod28Array);
            int C3_B = MiscMethods.ArrayItemsSummation(B4B4Array.B4BTJoinSumOfColsMod28Array);


            bool Condition3 = (MiscMethods.IsK28Plus20OrK28Minus20(C3_B) || MiscMethods.IsK28(C3_B));

            // Condition 4
           // bool Condition4 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C3_A, C3_B);


            // Condition 5 
            bool Condition5 = (B4B4Array.SumColsMod28_Summation % 28 == B4B4Array.InverseSumColsMod28_Summation % 28);

            // Condition 6

            bool Condition6 = true;
            if (Length % 2 == 0)
            {
                for (int i = 0; i < Length / 2 && Condition6; i++)
                {
                    int t1 = B4B4Array.SumColsMod28[i];
                    int s1 = B4B4Array.InverseSumColsMod28[i];
                    int t2 = B4B4Array.SumColsMod28[B4B4Array.SumColsMod28.Length - 1 - i];
                    int s2 = B4B4Array.InverseSumColsMod28[B4B4Array.InverseSumColsMod28.Length - 1 - i];
                    if (!MiscMethods.SummationOrDistancesMode28AreTheSame(t1, s1, t2, s2))
                        Condition6 = false;
                }
            }
            else
            {
                for (int i = 0; i < (Length - 3) / 2 && Condition6; i++)
                {
                    int t1 = B4B4Array.SumColsMod28[i];
                    int s1 = B4B4Array.InverseSumColsMod28[i];
                    int t2 = B4B4Array.SumColsMod28[B4B4Array.SumColsMod28.Length - 1 - i];
                    int s2 = B4B4Array.InverseSumColsMod28[B4B4Array.InverseSumColsMod28.Length - 1 - i];
                    if (!MiscMethods.SummationOrDistancesMode28AreTheSame(t1, s1, t2, s2))
                        Condition6 = false;
                }
                if (Condition6)
                {
                    int MiddleIndex = B4B4Array.SumColsMod28.Length / 2;
                    int t1 = B4B4Array.SumColsMod28[MiddleIndex - 1]; int s1 = B4B4Array.InverseSumColsMod28[MiddleIndex - 1];
                    int j1 = (t1 + t1); int f1 = Math.Abs(t1 - t1);
                    int t2 = B4B4Array.SumColsMod28[MiddleIndex]; int s2 = B4B4Array.InverseSumColsMod28[MiddleIndex];
                    int j2 = (t2 + t2); int f2 = Math.Abs(t2 - t2);
                    int t3 = B4B4Array.SumColsMod28[MiddleIndex + 1]; int s3 = B4B4Array.InverseSumColsMod28[MiddleIndex + 1];
                    int j3 = (t3 + t3); int f3 = Math.Abs(t3 - t3);
                    Condition6 = (Condition6 && (
     Conditions_E6_part2Met(j1, j2, j3) || Conditions_E6_part2Met(j1, j2, f3) || Conditions_E6_part2Met(j1, f2, j3) || Conditions_E6_part2Met(j1, f2, f3) ||
     Conditions_E6_part2Met(f1, j2, j3) || Conditions_E6_part2Met(f1, j2, f3) || Conditions_E6_part2Met(f1, f2, j3) || Conditions_E6_part2Met(f1, f2, f3)

                         ));

                }

            }

            // Condition 7
            int C7_1 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol1, 28));
            int C7_2 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol2, 28));
            int C7_3 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol3, 28));
            int C7_4 = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(B4B4Array.SumCol4, 28));

            int C7_A = MiscMethods.JoinItemsAndModN(B4B4Array.SumCol1, 28);
            int C7_B = MiscMethods.JoinItemsAndModN(B4B4Array.SumCol2, 28);
            int C7_C = MiscMethods.JoinItemsAndModN(B4B4Array.SumCol3, 28);
            int C7_D = MiscMethods.JoinItemsAndModN(B4B4Array.SumCol4, 28);

            int[] C7_Array1 = MiscMethods.InverseArray(B4B4Array.B4BTMulSumOfColsMod28Array);
            int[] C7_Array2 = MiscMethods.GetArray(C7_4, C7_3, C7_2, C7_1);
            int[] C7_Array3 = MiscMethods.InverseArray(B4B4Array.B4BTJoinSumOfColsMod28Array);
            int[] C7_Array4 = MiscMethods.GetArray(C7_D, C7_C, C7_B, C7_A);

            int C7_Count = 0;
            if (C7_Array2[0] == 28) C7_Count++;
            if (C7_Array2[1] == 28) C7_Count++;
            if (C7_Array2[2] == 28) C7_Count++;
            if (C7_Array2[3] == 28) C7_Count++;
            bool Condition7 = (C7_Count >= 3);

            // Condition 8

            int C8_A = MiscMethods.JoinItemsAndModN(C7_Array1, 28);
            int C8_B = MiscMethods.JoinItemsAndModN(C7_Array2, 28);
            int C8_Ainv = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C7_Array1), 28);
            int C8_Binv = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C7_Array2), 28);

            bool Condition8 = (MiscMethods.SummationOrDistanceIsK28(C8_Ainv, C8_Binv) || MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C8_Ainv, C8_Binv));
            bool Condition8_new4 = (MiscMethods.SummationOrDistanceIsEitherK28OrK28Plus20OrK28Minus20(C8_A, C8_Binv) || MiscMethods.SummationOrDistanceIsEitherK28OrK28Plus20OrK28Minus20(C8_B, C8_Ainv));

            // Condition 9

            int C9_C = MiscMethods.ArrayItemsSummation(C7_Array1);
            int C9_D = MiscMethods.ArrayItemsSummation(C7_Array2);
            int C9_E = C9_C + C9_D;
            bool Condition9 = MiscMethods.IsK9Plus2(C9_E);

            // Condition 10

            int C10_F = MiscMethods.JoinItemsAndModN(C7_Array3, 28);
            int C10_G = MiscMethods.JoinItemsAndModN(C7_Array4, 28);

            int C10_Finv = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C7_Array3), 28);
            int C10_Ginv = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(C7_Array4), 28);

            bool Condition10 = (MiscMethods.SummationOrDistanceIsEitherK28OrK28Plus20OrK28Minus20(C10_F, C10_Ginv) || MiscMethods.SummationOrDistanceIsEitherK28OrK28Plus20OrK28Minus20(C10_Finv, C10_G));


            // Condition 12

            int C12 = MiscMethods.JoinItemsAndModN(B4B4Array.Sum, 28);
            bool Condition12 = MiscMethods.IsK28Plus20OrK28Minus20(C12);

            // Condition 13
            int[] InverseSum = MiscMethods.InverseArray(B4B4Array.Sum);
            int C13 = MiscMethods.JoinItemsAndModN(InverseSum, 28);
            bool Condition13 = MiscMethods.IsK28Plus20OrK28Minus20(C13);
           
            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition8_new4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
           
            if (Condition12) Rank++;
            if (Condition13) Rank++;
            // Out Of 12
            return Rank;

        }
        public static bool Conditions_E6_part2Met(int i, int j, int k)
        {
            int dik =Math.Abs (i - k);
            bool cond1 = MiscMethods.IsK28Plus20OrK28Minus20(j + dik);
            
            return (cond1 && cond1);
        }       
        public static int Conditions_D(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Length = QuestionLetters.Length;
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page D1
            // Condition 1
            bool Condition1 = false;
            bool Condition2 = false;

            int[] C1_Summation = MiscMethods.Summation(QuestionLetters, AnswerLetters);
            int[] C1_EvenItems = MiscMethods.ItemsWithEvenIndices(C1_Summation);
            int[] C1_OddItems = MiscMethods.ItemsWithOddIndices(C1_Summation);
            if (Length % 2 == 0)
            {
                int[] C1_DistanceEvenAndOdd = MiscMethods.Distance(C1_EvenItems, C1_OddItems);
                int[] C1_SummationEvenAndOdd = MiscMethods.Summation(C1_EvenItems, C1_OddItems);
                int[] C1_CopyDistanceEvenAndOdd = MiscMethods.CopyArray(C1_DistanceEvenAndOdd);
                while (C1_CopyDistanceEvenAndOdd.Length > 1)
                {
                    C1_CopyDistanceEvenAndOdd = MiscMethods.DistanceOfNeighboringItems(C1_CopyDistanceEvenAndOdd);
                }
                int C1_A = C1_CopyDistanceEvenAndOdd[0];
                int[] C1_CopySummationEvenAndOdd = MiscMethods.CopyArray(C1_SummationEvenAndOdd);
                while (C1_CopySummationEvenAndOdd.Length > 1)
                {
                    C1_CopySummationEvenAndOdd = MiscMethods.DistanceOfNeighboringItems(C1_CopySummationEvenAndOdd);
                }
                int C1_B = C1_CopySummationEvenAndOdd[0];
                Condition1 = (C1_A == 1 && C1_B == 1);
            
                // Condition 2
                int[] C2_Distance = MiscMethods.Distance(QuestionLetters, AnswerLetters);
                int[] C2_EvenItems = MiscMethods.ItemsWithEvenIndices(C2_Distance);
                int[] C2_OddItems = MiscMethods.ItemsWithOddIndices(C2_Distance);
                int[] C2_DistanceEvenAndOdd = MiscMethods.Distance(C2_EvenItems, C2_OddItems);
                int[] C2_SummationEvenAndOdd = MiscMethods.Summation(C2_EvenItems, C2_OddItems);
                int[] C2_CopyDistanceEvenAndOdd = MiscMethods.CopyArray(C2_DistanceEvenAndOdd);
                while (C2_CopyDistanceEvenAndOdd.Length > 1)
                {
                    C2_CopyDistanceEvenAndOdd = MiscMethods.DistanceOfNeighboringItems(C2_CopyDistanceEvenAndOdd);
                }
                int C2_A = C2_CopyDistanceEvenAndOdd[0];
                int[] C2_CopySummationEvenAndOdd = MiscMethods.CopyArray(C2_SummationEvenAndOdd);
                while (C2_CopySummationEvenAndOdd.Length > 1)
                {
                    C2_CopySummationEvenAndOdd = MiscMethods.DistanceOfNeighboringItems(C2_CopySummationEvenAndOdd);
                }
                int C2_B = C2_CopySummationEvenAndOdd[0];
                Condition2 = (C2_A == 1 && C2_B == 1);
            }

            // Condition 3
            int[] C3_EvenItemsAnswerLetters = MiscMethods.ItemsWithEvenIndices(AnswerLetters);
            int[] C3_OddItemsAnswerLetters = MiscMethods.ItemsWithOddIndices(AnswerLetters);
            int[] C3_EvenItemsQuestionLetters = MiscMethods.ItemsWithEvenIndices(QuestionLetters);
            int[] C3_OddItemsQuestionLetters = MiscMethods.ItemsWithOddIndices(QuestionLetters);
            int C3_A = MiscMethods.ArrayItemsSummation(C3_EvenItemsQuestionLetters);
            int C3_B = MiscMethods.ArrayItemsSummation(C3_EvenItemsAnswerLetters);
            int C3_C = MiscMethods.ArrayItemsSummation(C3_OddItemsQuestionLetters);
            int C3_D = MiscMethods.ArrayItemsSummation(C3_OddItemsAnswerLetters);

            int C3_E = Math.Abs(C3_A- C3_B);
            bool Condition3 = MiscMethods.IsK9Plus2(C3_E);

            // Condition 4
            int C3_F = Math.Abs(C3_C - C3_D);
            bool Condition4 = (Math.Abs(C3_E - C3_F) == 1);


            // Condition 5
            int C3_G = Math.Abs(C3_A - C3_D);
            bool Condition5 = (C3_G  % 28 == 2);

            // Condition 6
            int C3_H = Math.Abs(C3_C - C3_B);
            bool Condition6 = MiscMethods.IsK9Plus2(C3_H);

            // Condition 7
            bool Condition7 = MiscMethods.IsK28(C3_A * C3_D);

            // Condition 8
            bool Condition8 = ((C3_B * C3_C) % 28 == 2);

            // Condition 9
            bool Condition9 = MiscMethods.IsK28(C3_B * C3_D*2);

            // Condition 9
            int C10 = 0;
            for (int i = 0; i < Length; i++)
            {
                C10 = MiscMethods.EquivalentNumber(C10);
                C10 = C10 + AnswerLetters[i] + QuestionLetters[i];
            }
            bool Condition10 = MiscMethods.IsK9Plus2(C10);            

            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            // Out Of 10
            return Rank;

        }
        public static int Conditions_C(int[] QuestionLetters, int[] AnswerLetters)
        {
            int Length = QuestionLetters.Length;
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page C1 & C2
            // Condition 1 & 2
            int[] SummationQuestionAnswer = MiscMethods.Summation(QuestionLetters, AnswerLetters);
            int[] SummationQuestionAnswerMod9 = MiscMethods.ReminderModeN(SummationQuestionAnswer, 9);
            MiscMethods.Replace(SummationQuestionAnswerMod9, 0, 9);
            int[] Pattern = new int[] { 1,1,0,0,0,1};
            int[] Pattern2 = new int[] { 1, 0 };
            bool Condition1 = false;
            bool Condition2 = false;
            for (int StartingPoint = 0; StartingPoint < 6; StartingPoint++)
            {
                int[] C1_Array1 = MiscMethods.FoldAndDoPageE1(SummationQuestionAnswerMod9, Pattern, StartingPoint);
                int LeftHalfLength = C1_Array1.Length / 2;
                int RightHalfLength = C1_Array1.Length / 2;
                if (C1_Array1.Length % 2 == 0)
                {
                    int[] C1_Array2 = MiscMethods.SubArray(C1_Array1, 0, LeftHalfLength);
                    int[] C1_Array3 = MiscMethods.SubArray(C1_Array1, C1_Array1.Length - RightHalfLength, RightHalfLength);
                    int C1_A = MiscMethods.ArrayItemsSummation(C1_Array2);
                    int C1_B = MiscMethods.ArrayItemsSummation(C1_Array3);
                    if (MiscMethods.IsK9Plus2(C1_A) && MiscMethods.IsK9Plus2(C1_B))
                        Condition1 = true;

                }
                else
                {
                    int[] C1_Array2 = MiscMethods.SubArray(C1_Array1, 0, LeftHalfLength+1);
                    int[] C1_Array3 = MiscMethods.SubArray(C1_Array1, C1_Array1.Length - RightHalfLength, RightHalfLength);
                    int C1_A = MiscMethods.ArrayItemsSummation(C1_Array2);
                    int C1_B = MiscMethods.ArrayItemsSummation(C1_Array3);
                    if (MiscMethods.IsK9Plus2(C1_A) && MiscMethods.IsK9Plus2(C1_B))
                        Condition1 = true;
                    C1_Array2 = MiscMethods.SubArray(C1_Array1, 0, LeftHalfLength);
                    C1_Array3 = MiscMethods.SubArray(C1_Array1, C1_Array1.Length - RightHalfLength-1, RightHalfLength+1);
                    C1_A = MiscMethods.ArrayItemsSummation(C1_Array2);
                    C1_B = MiscMethods.ArrayItemsSummation(C1_Array3);
                    if (MiscMethods.IsK9Plus2(C1_A) && MiscMethods.IsK9Plus2(C1_B))
                        Condition1 = true;
                    C1_Array2 = MiscMethods.SubArray(C1_Array1, 0, LeftHalfLength);
                    C1_Array3 = MiscMethods.SubArray(C1_Array1, C1_Array1.Length - RightHalfLength , RightHalfLength );
                    C1_A = MiscMethods.ArrayItemsSummation(C1_Array2);
                    C1_B = MiscMethods.ArrayItemsSummation(C1_Array3);
                    int C1_C = MiscMethods.MiddleElement(C1_Array1);
                    if (MiscMethods.IsK9Plus2(C1_A) && MiscMethods.IsK9Plus2(C1_B) && (C1_C == 2 || C1_C==8))
                        Condition1 = true;

                }
                int[] C2_Array1 = MiscMethods.FoldAndDoPageE2(C1_Array1, Pattern2, 0);
                int C2_1 = MiscMethods.ArrayItemsSummation(C2_Array1);
                C2_Array1 = MiscMethods.FoldAndDoPageE2(C1_Array1, Pattern2, 1);
                int C2_2 = MiscMethods.ArrayItemsSummation(C2_Array1);
                if (MiscMethods.IsK9Plus2(C2_1) || MiscMethods.IsK9Plus2(C2_2))
                    Condition2 = true;

            }

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page C2
            // Condition 3
            bool Condition3 = false;
            bool Condition4 = false;
            bool Condition5 = false;
            bool Condition6 = false;
            bool Condition7 = false;
            if (Length%2==0)
            {
                int C3_A = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithEvenIndices(QuestionLetters));
                int C3_B = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithOddIndices(QuestionLetters));
                int C3_C = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithEvenIndices(AnswerLetters));
                int C3_D = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithOddIndices(AnswerLetters));

                bool C3Part1 = (MiscMethods.SummationOrDistanceIsK28PlusXOrK28MinusX(C3_B, C3_C, 2) || MiscMethods.SummationOrDistanceIsK9Plus2(C3_B, C3_C));
                bool C3Part2 = (MiscMethods.SummationOrDistanceIsK28PlusXOrK28MinusX(C3_A, C3_D, 2) || MiscMethods.SummationOrDistanceIsK9Plus2(C3_A, C3_D));
                Condition3 = (C3Part1 && C3Part2);

                // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page C3
                // Condition 4
                int[] MajorQuestionLetters = MiscMethods.MajorAbjadArray(QuestionLetters);
                int[] MajorAnswerLetters = MiscMethods.MajorAbjadArray(AnswerLetters);
                int C4_A = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithEvenIndices(MajorQuestionLetters));
                int C4_B = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithOddIndices(MajorQuestionLetters));
                int C4_C = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithEvenIndices(MajorAnswerLetters));
                int C4_D = MiscMethods.ArrayItemsSummation(MiscMethods.ItemsWithOddIndices(MajorAnswerLetters));

                bool C4Part1 = (MiscMethods.SummationOrDistanceIsK28PlusXOrK28MinusX(C4_A, C4_C, 2) || MiscMethods.SummationOrDistanceIsK28(C4_A, C4_C));
                bool C4Part2 = (MiscMethods.SummationOrDistanceIsK28PlusXOrK28MinusX(C4_B, C4_D, 2) || MiscMethods.SummationOrDistanceIsK28(C4_B, C4_D));
                Condition4 = (C4Part1 && C4Part2);


                // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page C4
                // Condition 5
                int[] InverseAnswerLetters = MiscMethods.InverseArray(AnswerLetters);
                int[] FirstHalfOfQuestionLetters = MiscMethods.SubArray(QuestionLetters, 0, QuestionLetters.Length/2);
                int[] SecondHalfOfQuestionLetters = MiscMethods.SubArray(QuestionLetters, QuestionLetters.Length/2, QuestionLetters.Length/2);
                int[] FirstHalfOfInverseAnswerLetters = MiscMethods.SubArray(InverseAnswerLetters, 0, InverseAnswerLetters.Length/2);
                int[] SecondHalfOfInverseAnswerLetters = MiscMethods.SubArray(InverseAnswerLetters, InverseAnswerLetters.Length/2, InverseAnswerLetters.Length/2);
                int[] FirstHalfOfDistance = MiscMethods.Distance(FirstHalfOfQuestionLetters, FirstHalfOfInverseAnswerLetters);
                int[] FirstHalfOfSummation = MiscMethods.Summation(FirstHalfOfQuestionLetters, FirstHalfOfInverseAnswerLetters);
                int[] SecondtHalfOfDistance = MiscMethods.Distance(SecondHalfOfQuestionLetters, SecondHalfOfInverseAnswerLetters);
                int[] SecondHalfOfSummation = MiscMethods.Summation(SecondHalfOfQuestionLetters, SecondHalfOfInverseAnswerLetters);

                int C5_A = MiscMethods.ArrayItemsSummation(FirstHalfOfSummation);
                int C5_B = MiscMethods.ArrayItemsSummation(SecondHalfOfSummation);
                int C5_C = Math.Abs(C5_A - C5_B);
                Condition5 = ((MiscMethods.IsK28(C5_A)||MiscMethods.IsK28(C5_B) )&& (MiscMethods.IsK9Plus2(C5_C)));

                // Condition 6


                int[] FirstHalfOfDistanceMod9 = MiscMethods.ReminderModeN(FirstHalfOfDistance, 9);
                int[] SecondtHalfOfDistanceMod9 = MiscMethods.ReminderModeN(SecondtHalfOfDistance, 9);
                int ZerosInFirstHalf = 0;int ZerosInSecondtHalf = 0;
                for (int i = 0; i < FirstHalfOfDistanceMod9.Length; i++)
                {
                    if (FirstHalfOfDistanceMod9[i] == 0) ZerosInFirstHalf++;
                    if (SecondtHalfOfDistanceMod9[i] == 0) ZerosInSecondtHalf++;
                }
                ZerosInFirstHalf = MiscMethods.Power(2, ZerosInFirstHalf);
                ZerosInSecondtHalf = MiscMethods.Power(2, ZerosInSecondtHalf);
                for (int i = 0; i < ZerosInFirstHalf; i++)
                {
                    for (int j = 0; j < ZerosInSecondtHalf; j++)
                    {
                        int ii=i; int jj = j;
                        int[] FirstHalf = MiscMethods.CopyArray(FirstHalfOfDistanceMod9);
                        int[] SecondtHalf = MiscMethods.CopyArray(SecondtHalfOfDistanceMod9);

                        int t=0;
                        for (int k = 0; k < FirstHalf.Length; k++)
                        {
                            if (FirstHalf[k] == 0)
                            {
                                FirstHalf[k] = MiscMethods.GetIthBitInN(ii, t);
                                t++;                                    
                            }
                        }

                        t = 0;
                        for (int k = 0; k < SecondtHalf.Length; k++)
                        {
                            if (SecondtHalf[k] == 0)
                            {
                                SecondtHalf[k] = MiscMethods.GetIthBitInN(jj, t);
                                t++;
                            }
                        }

                        int C6_Azegond = MiscMethods.JoinItemsAndModN(FirstHalf, 28);
                        int C6_Bzegond = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(SecondtHalf), 28);
                        int C6_Aprime = MiscMethods.JoinItemsAndModN(MiscMethods. InverseArray(FirstHalf), 28);
                        int C6_Bprime = MiscMethods.JoinItemsAndModN(SecondtHalf, 28);
                        Condition6 = (MiscMethods.SummationOrDistanceIsK9Plus2(C6_Aprime, C6_Azegond) || MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C6_Aprime, C6_Azegond)) ;

                        // Condition 7
            
                        int C6_C = Math.Abs(C6_Bprime - C6_Bzegond);
                        int C6_D = Math.Abs(C6_Aprime - C6_Azegond);
                        Condition7 = (MiscMethods.SummationOrDistanceIsK9Plus2(C6_C, C6_D) || MiscMethods.SummationOrDistanceIsK28(C6_C, C6_D)) ;

                    }
                }


            }


            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            // out of 7

            return Rank;

        }
        public static int Conditions_B(int[] QuestionLetters, int[] AnswerLetters)
        {
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B1
            // Condition 1
            int[] C1_Array1 = MiscMethods.FoldAndDistance(AnswerLetters);
            int C1_Aprime = MiscMethods.ArrayItemsSummation(C1_Array1);
            bool Condition1 = MiscMethods.IsK9Plus2(C1_Aprime) || MiscMethods.IsK28Plus20OrK28Minus20(C1_Aprime);

            // Condition 2

            int[] C2_Array1 = MiscMethods.FoldAndDifferenceLastMinusFirst(AnswerLetters);
            int C2_Bprime = MiscMethods.ArrayItemsSummation(C2_Array1);

            int[] C2_Array2 = MiscMethods.FoldAndDistance(QuestionLetters);
            int C2_A = MiscMethods.ArrayItemsSummation(C2_Array2);
            int[] C2_Array3 = MiscMethods.FoldAndDifferenceLastMinusFirst(QuestionLetters);
            int C2_B = MiscMethods.ArrayItemsSummation(C2_Array3);
            int C2_Summation = (C2_A + C2_B) + (C1_Aprime + C2_Bprime);
            int C2_Distance = Math.Abs((C2_A + C2_B) - (C1_Aprime + C2_Bprime));

            bool Condition2 = MiscMethods.IsK28(C2_Summation) || MiscMethods.IsK28(C2_Distance);

            // Condition 3
            bool Condition3 = false;
            if (QuestionLetters.Length % 2==0)
            {
                int[] C3_Array1 = MiscMethods.SubArray(AnswerLetters, 0, AnswerLetters.Length / 2);
                int[] C3_Array2 = MiscMethods.SubArray(AnswerLetters, AnswerLetters.Length / 2, AnswerLetters.Length / 2);
                int[] C3_Array3 = MiscMethods.InverseArray(C3_Array2);
                int[] C3_Array4 = MiscMethods.Multiplication(C3_Array1, C3_Array3);
                int C3 = 4 * MiscMethods.ArrayItemsSummation(C3_Array4);
                Condition3 = MiscMethods.IsK28Plus20OrK28Minus20(C3) || MiscMethods.IsK9Plus2(C3);
            }
            // Condition 4
            int C4 = MiscMethods.ArrayItemsMultiplicationModN(AnswerLetters, 28);
            bool Condition4 = (C4==0);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page B2
            // Condition 5

            int[] C5_Array1 = MiscMethods.DifferenceOfNeighboringItemsFirstMinusSecond(QuestionLetters);
            int C5_G = MiscMethods.ArrayItemsSummation(C5_Array1);
            int C5_F = MiscMethods.ArrayItemsSummation(C5_Array1) - (C5_Array1[0] + C5_Array1[C5_Array1.Length-1]);

            int[] C5_Array2 = MiscMethods.DifferenceOfNeighboringItemsFirstMinusSecond(AnswerLetters);
            int C5_Gprime = MiscMethods.ArrayItemsSummation(C5_Array2);
            int C5_Fprime = MiscMethods.ArrayItemsSummation(C5_Array2) - (C5_Array2[0] + C5_Array2[C5_Array2.Length - 1]);

            int C5 = C5_F - C5_Fprime + (C5_G + C5_Gprime);
            bool Condition5 = MiscMethods.IsK28(C5);

            // Condition 6

            int C6 = Math.Abs((C5_F + C5_Fprime) - (C5_G + C5_Gprime));
            bool Condition6 = MiscMethods.IsEitherK28Plus20OrK28Minus20OrK9Plus2(C6);


            int Rank = 0;
            if (Condition1) Rank++; 
            if (Condition2) Rank++; 
            if (Condition3) Rank++; 
            if (Condition4) Rank++; 
            if (Condition5) Rank++; 
            if (Condition6) Rank++; 


            // Out of 6
            return Rank;
        }
        public static int Conditions_A(int[] QuestionLetters, int[] AnswerLetters) 
        {
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A1
            int[] ArrayA = MiscMethods.CopyArray(QuestionLetters);
            int[] ArrayB = MiscMethods.CopyArray(AnswerLetters);
            int[] ArrayC = MiscMethods.Summation(ArrayA, ArrayB);
            int[] ArrayD = MiscMethods.ReminderModeN(ArrayC, BoddoohNumbers.Nine);
            MiscMethods.Replace(ArrayD, 0, 9);
            int[] ArrayE = MiscMethods.Distance(ArrayA, ArrayB);
            int[] ArrayF = MiscMethods.ReminderModeN(ArrayE, BoddoohNumbers.Nine);
            int[] ArrayG = MiscMethods.Difference(ArrayB, ArrayA);
            int[] ArrayH = MiscMethods.EquivalentNumber(ArrayG);
            int[] ArrayI = MiscMethods.ReminderModeN(ArrayH, BoddoohNumbers.Nine);

            int SummationOfArrayA = MiscMethods.ArrayItemsSummation(ArrayA);
            int SummationOfArrayB = MiscMethods.ArrayItemsSummation(ArrayB);
            int SummationOfArrayC = MiscMethods.ArrayItemsSummation(ArrayC);
            int SummationOfArrayD = MiscMethods.ArrayItemsSummation(ArrayD);
            int SummationOfArrayE = MiscMethods.ArrayItemsSummation(ArrayE);
            int SummationOfArrayF = MiscMethods.ArrayItemsSummation(ArrayF);
            int SummationOfArrayG = MiscMethods.ArrayItemsSummation(ArrayG);
            int SummationOfArrayH = MiscMethods.ArrayItemsSummation(ArrayH);
            int SummationOfArrayI = MiscMethods.ArrayItemsSummation(ArrayI);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A2

            // Condition 1
            bool Condition1 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(SummationOfArrayC, SummationOfArrayD);
            //if (Condition1) return 1; return 0;
            // Condition 2
            bool Condition2 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(SummationOfArrayE, SummationOfArrayF);
            // Condition 3
            int C3_a = SummationOfArrayC - SummationOfArrayG;//SMV 
            int C3_b = SummationOfArrayH - SummationOfArrayG;//SMV 
            int C3_c = C3_a - C3_b;//SMV abs?
            int C3_bp = MiscMethods.Equivalent1To9(C3_b);
            int C3_cp = MiscMethods.Equivalent1To9(C3_c);
            bool Condition3 = ((C3_bp == C3_cp + 1) || (C3_cp == C3_bp + 1));
            // Condition 4
            int C4 = 2 * (SummationOfArrayD + SummationOfArrayF);
            bool Condition4 = MiscMethods.IsK28(C4);
            // Condition 5
            int C5 = 2 * (SummationOfArrayD + SummationOfArrayI);
            bool Condition5 = MiscMethods.IsK28Plus20OrK28Minus20(C5);
            // Condition 6
            int C6 = (SummationOfArrayF + SummationOfArrayI);
            bool Condition6 = MiscMethods.IsK28(C6);
            // Condition 7
            int C7 = Math.Abs(SummationOfArrayD - SummationOfArrayF) + Math.Abs(SummationOfArrayD - SummationOfArrayI);
            bool Condition7 = MiscMethods.IsK9Plus2(C7);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A3
            // Condition 8
            int[] C8_Array = MiscMethods.MajorAbjadArray(MiscMethods.InverseArray(AnswerLetters));
            int C8 = MiscMethods.JoinItemsAndModN(C8_Array, BoddoohNumbers.TwentyEight);
            bool Condition8 = MiscMethods.IsK28Plus20OrK28Minus20(C8);//SMV
            // Condition 9
            int C9 = MiscMethods.JoinItemsAndModN(AnswerLetters, BoddoohNumbers.TwentyEight);
            bool Condition9 = MiscMethods.IsK28Plus20OrK28Minus20(C9);//SMV 
            // Condition 10 & 11
            int[] C10_Array1 = MiscMethods.JoinArrays(QuestionLetters, AnswerLetters);
            int[] C10_Array2 = MiscMethods.InverseArray(C10_Array1);
            int[] C10_Array3 = MiscMethods.MajorAbjadArray(C10_Array2);
            int C10 = MiscMethods.JoinItemsAndModN(C10_Array3, BoddoohNumbers.TwentyEight);
            bool Condition10 = MiscMethods.IsK28Plus20OrK28Minus20(C10);//SMV
            int C11 = MiscMethods.JoinItemsAndModN(C10_Array1, BoddoohNumbers.TwentyEight);
            bool Condition11 = (C11 == 0);


            // Condition 12
            bool Condition12 = true;
            int[] C10_SummationArray = MiscMethods.Summation(QuestionLetters, AnswerLetters);
            int[] C10_DistanceArray = MiscMethods.Distance(QuestionLetters, AnswerLetters);
            int C10_Length = C10_SummationArray.Length / 2;
            if (C10_SummationArray.Length % 2 == 1) C10_Length++;
            ArrayList[] C10_ArrayList = new ArrayList[C10_Length];
            int[] C10_MaxLength = new int[C10_Length];
            for (int i = 0; i < C10_Length && Condition12; i++)
            {                
                C10_ArrayList[i] = new ArrayList();
                int C10_A1 = C10_SummationArray[i]; int C10_B1 = C10_SummationArray[C10_SummationArray.Length - 1 - i];
                int C10_A2 = C10_DistanceArray[i]; int C10_B2 = C10_DistanceArray[C10_DistanceArray.Length - 1 - i];

                int C10_Dis1 = Math.Abs(C10_A1- C10_B1);
                int C10_Dis2 = Math.Abs(C10_A2 - C10_B2);
                int C10_SCDis1 = C10_Dis1; while (C10_SCDis1 > 9) C10_SCDis1 = MiscMethods.SummationOfDigits(C10_SCDis1);
                int C10_SCDis2 = C10_Dis2; while (C10_SCDis2 > 9) C10_SCDis2 = MiscMethods.SummationOfDigits(C10_SCDis2);
                int C10_Sum1 = C10_A1 + C10_B1;
                int C10_Sum2 = C10_A2 + C10_B2;
                int C10_SCSum1 = C10_Sum1; while (C10_SCSum1 > 9) C10_SCSum1 = MiscMethods.SummationOfDigits(C10_SCSum1);
                int C10_SCSum2 = C10_Sum2; while (C10_SCSum2 > 9) C10_SCSum2 = MiscMethods.SummationOfDigits(C10_SCSum2);

                int C10_EqSum1 = (C10_Sum1);
                int C10_EqSum2 = (C10_Sum2);
                int C10_SCEqSum1 = C10_SCSum1; 
                int C10_SCEqSum2 = C10_SCSum2; 
                int C10_EqDis1 = (C10_Dis1);
                int C10_EqDis2 = (C10_Dis2);
                int C10_SCEqDis1 = C10_SCDis1; 
                int C10_SCEqDis2 = C10_SCDis2;

                if (i <= C10_Length-1)
                {
                    C10_EqDis1 = MiscMethods.EquivalentNumber(C10_Dis1);
                 C10_EqDis2 = MiscMethods.EquivalentNumber(C10_Dis2);
                 C10_SCEqDis1 = C10_EqDis1; while (C10_SCEqDis1 > 9) C10_SCEqDis1 = MiscMethods.SummationOfDigits(C10_SCEqDis1);
                 C10_SCEqDis2 = C10_EqDis2; while (C10_SCEqDis2 > 9) C10_SCEqDis2 = MiscMethods.SummationOfDigits(C10_SCEqDis2);

                     C10_EqSum1 = MiscMethods.EquivalentNumber(C10_Sum1);
                     C10_EqSum2 = MiscMethods.EquivalentNumber(C10_Sum2);
                     C10_SCEqSum1 = C10_EqSum1; while (C10_SCEqSum1 > 9) C10_SCEqSum1 = MiscMethods.SummationOfDigits(C10_SCEqSum1);
                     C10_SCEqSum2 = C10_EqSum2; while (C10_SCEqSum2 > 9) C10_SCEqSum2 = MiscMethods.SummationOfDigits(C10_SCEqSum2);
                }
                bool C10_1 = false; bool C10_2 = false; bool C10_8 = false;
                if (C10_Dis1 == 1 || C10_EqDis1 == 1 || C10_SCDis1 == 1 || C10_SCEqDis1 == 1 || C10_Sum1 == 1 || C10_EqSum1 == 1 || C10_SCSum1 == 1 || C10_SCEqSum1 == 1) C10_1 = true;
                if (C10_Dis2 == 1 || C10_EqDis2 == 1 || C10_SCDis2 == 1 || C10_SCEqDis2 == 1 || C10_Sum2 == 1 || C10_EqSum2 == 1 || C10_SCSum2 == 1 || C10_SCEqSum2 == 1) C10_1 = true;
                if (C10_Dis1 == 2 || C10_EqDis1 == 2 || C10_SCDis1 == 2 || C10_SCEqDis1 == 2 || C10_Sum1 == 2 || C10_EqSum1 == 2 || C10_SCSum1 == 2 || C10_SCEqSum1 == 2) C10_2 = true;
                if (C10_Dis2 == 2 || C10_EqDis2 == 2 || C10_SCDis2 == 2 || C10_SCEqDis2 == 2 || C10_Sum2 == 2 || C10_EqSum2 == 2 || C10_SCSum2 == 2 || C10_SCEqSum2 == 2) C10_2 = true;
                if (C10_Dis1 == 8 || C10_EqDis1 == 8 || C10_SCDis1 == 8 || C10_SCEqDis1 == 8 || C10_Sum1 == 8 || C10_EqSum1 == 8 || C10_SCSum1 == 8 || C10_SCEqSum1 == 8) C10_8 = true;
                if (C10_Dis2 == 8 || C10_EqDis2 == 8 || C10_SCDis2 == 8 || C10_SCEqDis2 == 8 || C10_Sum2 == 8 || C10_EqSum2 == 8 || C10_SCSum2 == 8 || C10_SCEqSum2 == 8) C10_8 = true;
                if (C10_Dis1 == 20 || C10_EqDis1 == 20 || C10_SCDis1 == 20 || C10_SCEqDis1 == 20 || C10_Sum1 == 20 || C10_EqSum1 == 20 || C10_SCSum1 == 20 || C10_SCEqSum1 == 20) C10_8 = true;
                if (C10_Dis2 == 20 || C10_EqDis2 == 20 || C10_SCDis2 == 20 || C10_SCEqDis2 == 20 || C10_Sum2 == 20 || C10_EqSum2 == 20 || C10_SCSum2 == 20 || C10_SCEqSum2 == 20) C10_8 = true;
                if (C10_1) C10_ArrayList[i].Add(1);
                if (C10_2) C10_ArrayList[i].Add(2);
                if (C10_8) C10_ArrayList[i].Add(8);
                if (!C10_1 && !C10_2 && !C10_8)
                    Condition12 = false;
                C10_MaxLength[i] = C10_ArrayList[i].Count;
            }
            int[] C10_PatternArray = new int[] { 2, 1, 8 };
            if (Condition12)
            {
                bool C10_result = false;
                Counter C10_Counter = new Counter(C10_Length, 1, C10_MaxLength); 
                 C10_Counter.Restart();
                 while (!C10_Counter.Done && !C10_result)
                {
                    int[] C10_temp = new int[C10_Length];
                    for (int j = 0; j < C10_Length; j++)
                        C10_temp[j] = (int)C10_ArrayList[j][C10_Counter.CurrentValues[j]-1];
                    C10_result = MiscMethods.HasAPattern(C10_temp, C10_PatternArray);
                        C10_Counter.Next();
                }
                Condition12 = !C10_result;                    
            }
                
                
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A4
            // Condition 13, 14  & 15
            int[] C13_Array1 = MiscMethods.MajorAbjadArray(QuestionLetters);
            int[] C13_Array2 = MiscMethods.MajorAbjadArray(AnswerLetters);
            int[] C13_Array3 = MiscMethods.JoinArrays(C13_Array2, C13_Array1);
            int C13_A = MiscMethods.JoinItemsAndModN(C13_Array1, BoddoohNumbers.TwentyEight);
            int C13_B = MiscMethods.JoinItemsAndModN(C13_Array2, BoddoohNumbers.TwentyEight);
            int C13_C = MiscMethods.JoinItemsAndModN(C13_Array3, BoddoohNumbers.TwentyEight);

            int C13_D = Math.Abs(C13_A - C13_B);
            bool Condition13 = MiscMethods.IsK28Plus20OrK28Minus20(C13_D);

            int C13_E = C13_Array1[C13_Array1.Length - 1] + C13_C;
            bool Condition14 = MiscMethods.IsK28(C13_E);

            int[] C13_Array4 = MiscMethods.InverseArray(C13_Array3);
            int C13_F = MiscMethods.JoinItemsAndModN(C13_Array4, BoddoohNumbers.TwentyEight);

            int C13_G = Math.Abs(C13_Array4[C13_Array4.Length - 1] - C13_F);
            bool Condition142 = MiscMethods.IsK28Plus20OrK28Minus20(C13_G);

            int C13_H = Math.Abs(C13_F - C13_C);
            bool Condition15 = MiscMethods.IsK9Plus2(C13_H);

            // Condition 16 - 19
            int[] ArrayCInverse = MiscMethods.InverseArray(ArrayC);
            int[] ArrayCEquivalentNumber = MiscMethods.EquivalentNumber(ArrayC);
            int[] ArrayCEquivalentNumberMajor = MiscMethods.MajorAbjadArray(ArrayCEquivalentNumber);
            int[] ArrayCEquivalentNumberInverse = MiscMethods.InverseArray(ArrayCEquivalentNumber);
            int[] ArrayCEquivalentNumberMajorInverse = MiscMethods.InverseArray(ArrayCEquivalentNumberMajor);
            int C16_A = MiscMethods.JoinItemsAndModN(ArrayCEquivalentNumberMajor, BoddoohNumbers.TwentyEight);
            int C16_B = MiscMethods.JoinItemsAndModN(ArrayCEquivalentNumberMajorInverse, BoddoohNumbers.TwentyEight);
            bool Condition16 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C16_A, C16_B) || MiscMethods.SummationOrDistanceIsK28(C16_A, C16_B);

            int C17_B = MiscMethods.JoinItemsAndModN(ArrayCEquivalentNumber, BoddoohNumbers.TwentyEight);
            int C17_Bprime = MiscMethods.JoinItemsAndModN(ArrayC, BoddoohNumbers.TwentyEight);
            bool Condition17 = MiscMethods.SummationOrDistanceIsK28Plus20OrK28Minus20(C17_B, C17_Bprime);

            int C18_Cprime = MiscMethods.JoinItemsAndModN(ArrayCInverse, BoddoohNumbers.TwentyEight);
            int C18_C = MiscMethods.JoinItemsAndModN(ArrayCEquivalentNumberInverse, BoddoohNumbers.TwentyEight);
            bool Condition18 = MiscMethods.IsK28Plus20OrK28Minus20(Math.Abs(C18_C - C18_Cprime));

            bool Condition19 = ((C17_B + C18_C) % 28 == (C17_Bprime + C18_Cprime) % 289);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A5
            // Condition 20
            int[] ArrayEFoldAndSummation = MiscMethods.FoldAndSummation(ArrayE);
            int C20 = MiscMethods.JoinItemsAndModN(ArrayEFoldAndSummation, BoddoohNumbers.TwentyEight);
            bool Condition20 = MiscMethods.IsK28Plus20OrK28Minus20(C20);

            // Condition 21
            int[] ArrayFInverse = MiscMethods.InverseArray(ArrayF);
            int C21_M = MiscMethods.JoinItemsAndModN(ArrayF, BoddoohNumbers.TwentyEight);
            int C21_N = MiscMethods.JoinItemsAndModN(ArrayFInverse, BoddoohNumbers.TwentyEight);
            bool Condition21 = MiscMethods.IsK28(C21_M + C21_N);
            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A6 
            // Condition 22
            int[] ArrayHFoldAndDistance = MiscMethods.FoldAndDistance(ArrayH);
            int C22 = MiscMethods.JoinItemsAndModN(ArrayHFoldAndDistance, BoddoohNumbers.TwentyEight);
            bool Condition22 = MiscMethods.IsK28Plus20OrK28Minus20(C22);

            // Condition 23
            int[] ArrayIInverse = MiscMethods.InverseArray(ArrayI);
            int C23_M = MiscMethods.JoinItemsAndModN(ArrayI, BoddoohNumbers.TwentyEight);
            int C23_N = MiscMethods.JoinItemsAndModN(ArrayIInverse, BoddoohNumbers.TwentyEight);
            bool Condition23 = MiscMethods.IsK9Plus2(C23_M + C23_N);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A7
            // Condition 24 - 27
            int[] C24_Count_1 = new int[4];
            int[] C24_Summation_1 = new int[4];
            int[] C24_Count_2 = new int[4];
            int[] C24_Summation_2 = new int[4];
            Boddooh.ComputeCountAndSummationOfLetters(AnswerLetters, ref C24_Count_1, ref  C24_Summation_1);
            Boddooh.ComputeCountAndSummationOfLetters(QuestionLetters, ref  C24_Count_2, ref  C24_Summation_2);

            int C24_Summation_F = C24_Summation_1[0] + C24_Summation_2[0];
            int C24_Distance_F = Math.Abs(C24_Summation_1[0] - C24_Summation_2[0]);

            int C24_Summation_A = C24_Summation_1[1] + C24_Summation_2[1];
            int C24_Distance_A = Math.Abs(C24_Summation_1[1] - C24_Summation_2[1]);

            int C24_Summation_W = C24_Summation_1[2] + C24_Summation_2[2];
            int C24_Distance_W = Math.Abs(C24_Summation_1[2] - C24_Summation_2[2]);

            int C24_Summation_E = C24_Summation_1[3] + C24_Summation_2[3];
            int C24_Distance_E = Math.Abs(C24_Summation_1[3] - C24_Summation_2[3]);

            int C24_A = C24_Summation_F + C24_Summation_A;
            int C24_B = C24_Distance_F + C24_Distance_A + C24_Distance_W + C24_Distance_E;
            int C24_C = C24_Summation_W + C24_Summation_E;

            int C24_E = C24_Count_1[1] + C24_Count_2[1] + C24_Count_1[2] + C24_Count_2[2];
            int C24_F = C24_Count_1[0] + C24_Count_2[0] + C24_Count_1[3] + C24_Count_2[3];
            int C24_G = 0;
            for (int i = 0; i < 4; i++)
                C24_G += ((Abjad.ElementalFactor(i + 1)) * (C24_Count_1[i] + C24_Count_2[i]));
            C24_G = 2 * C24_G;

            // Condition 24
            bool Condition24 = MiscMethods.IsK9Plus2(C24_B);

            // Condition 25
            bool Condition25 = MiscMethods.IsK28Plus20OrK28Minus20(C24_C);

            // Condition 26
            bool Condition26 = MiscMethods.SummationOrDistanceIsK9Plus2(C24_A, C24_C);

            // Condition 27
            bool Condition27 = MiscMethods.IsK28Plus20OrK28Minus20(C24_G);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A8

            // Condition 28
            int C28 = Boddooh.ComputeSummationOfLettersWRTElementalFactors(ArrayC);
            bool Condition28 = MiscMethods.IsK9Plus2(C28);

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Page A9

            // Condition 29
            int[] C29_Count = new int[4];
            int[] C29_Summation = new int[4];
            Boddooh.ComputeCountAndSummationOfLetters(ArrayH, ref C29_Count, ref C29_Summation);

            int C29_A1 = C29_Count[0] * 2;
            int C29_A2 = C29_Count[1] * 4;
            int C29_B1 = C29_Count[2] * 6;
            int C29_B2 = C29_Count[3] * 8;
            int C29_A = C29_A1 + C29_A2;
            int C29_B = C29_B1 + C29_B2;

            bool Condition29 = (C29_B == 2 * C29_A);

            // Condition 30
            int C30 = Math.Abs(C29_B2 - C29_A1) + Math.Abs(C29_B1 - C29_A2);
            bool Condition30 = MiscMethods.IsK9Plus2(C30);

            // Condition 31
            int C31 = Math.Abs((C29_B2 + C29_A1) - (C29_B1 + C29_A2));
            bool Condition31 = MiscMethods.IsK9Plus2(C31);

            // Condition 39
            int[] C39_Count = new int[4];
            int[] C39_Summation = new int[4];
            Boddooh.ComputeCountAndSummationOfLetters(ArrayD, ref C39_Count, ref C39_Summation);

            int C39_C1 = C39_Count[0] * 2;
            int C39_C2 = C39_Count[1] * 4;
            int C39_D1 = C39_Count[2] * 6;
            int C39_D2 = C39_Count[3] * 8;
            int C39_C = C39_Count[0] + C39_Count[1];
            int C39_D = C39_Count[2] + C39_Count[3];

            bool Condition39 = (C39_C == C39_D );


            // Condition 32
            
            
            
            

            int[] C31_Array = MiscMethods.Summation(C39_Count, C29_Count);

            int C32_Eprime = C31_Array[0];
            int C32_Ezegond = C31_Array[1];
            int C32_Fprime = C31_Array[2];
            int C32_Fzegond = C31_Array[3];

            int C32_E1 = C31_Array[0] * 2;
            int C32_E2 = C31_Array[1] * 4;
            int C32_F1 = C31_Array[2] * 6;
            int C32_F2 = C31_Array[3] * 8;
            int C32_G = C32_E1 + C32_E2 + C32_F1 + C32_F2;

            bool Condition32 = MiscMethods.IsK9Plus2(C32_G);

       
            // Condition 33
            //int[] DifferenceOfArrayHAndArrayD = MiscMethods.Difference(ArrayD, ArrayH);
           // int[] C33_Count = new int[4];
           // int[] C33_Summation = new int[4];
          //  Boddooh.ComputeCountAndSummationOfLetters(DifferenceOfArrayHAndArrayD, ref C33_Count, ref  C33_Summation);

            //int C33_E1 = C32_Count[0] * 2;
            //int C33_E2 = C32_Count[1] * 4;
            //int C33_F1 = C32_Count[2] * 6;
            //int C33_F2 = C32_Count[3] * 8;

            int[] C33_Array = MiscMethods.Difference(C39_Count, C29_Count);
            

         

            bool Condition33 = ((C33_Array[0]== 2 && C33_Array[1]==-2 && C33_Array[2]==0 && C33_Array[3]==0) ||
                (C33_Array[0]== -2 && C33_Array[1]==0 && C33_Array[2]==0 && C33_Array[3]==2) ||
                (C33_Array[0]== 0 && C33_Array[1]==0 && C33_Array[2]==2 && C33_Array[3]==-2) ||
                (C33_Array[0] == 0 && C33_Array[1] == 2 && C33_Array[2] == -2 && C33_Array[3] == 0));


            // Condition 34

            bool Condition34 = (C32_Eprime == C32_Fprime);

            // Condition 35

            bool Condition35 = (C32_Ezegond == C32_Fzegond);
            // Condition 36
            int C36 = Math.Abs(C32_E1 - C32_F2);
            bool Condition36 = MiscMethods.IsK28(C36);

            // Condition 37
            int C37 = (C32_E2 + C32_F1);
            bool Condition37 = MiscMethods.IsK28(C37);

            // Condition 38
            int C38 = (C32_E2 + C32_F2);
            bool Condition38 = (C38 % (C32_E1 + C32_F1) == 0);

           

            // Condition 40
            int C40 = Math.Abs(Math.Abs(C39_D2 - C39_C1) - Math.Abs(C39_D1 + C39_C2));
            bool Condition40 = MiscMethods.IsK9Plus2(C40);

            // Condition 41
            int C41 = Math.Abs((C39_D2 + C39_C1) - Math.Abs(C39_D1 - C39_C2));
            bool Condition41 = MiscMethods.IsK9Plus2(C41);


            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition5) Rank++;
            if (Condition6) Rank++;
            if (Condition7) Rank++;
            if (Condition8) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            if (Condition11) Rank++;
            if (Condition12) Rank++; 
            if (Condition13) Rank++;
            if (Condition14) Rank++;
            if (Condition142) Rank++;
            if (Condition15) Rank++;
            if (Condition16) Rank++;
            if (Condition17) Rank++;
            if (Condition18) Rank++;
            if (Condition19) Rank++;
            if (Condition20) Rank++;
            if (Condition21) Rank++;
            if (Condition22) Rank++;
            if (Condition23) Rank++;
            if (Condition24) Rank++;
            if (Condition25) Rank++;
            if (Condition26) Rank++;
            if (Condition27) Rank++;
            if (Condition28) Rank++;
            if (Condition29) Rank++;
            if (Condition30) Rank++;
            if (Condition31) Rank++;
            if (Condition32) Rank++;
            if (Condition33) Rank++;
            if (Condition34) Rank++;
            if (Condition35) Rank++;
            if (Condition36) Rank++;
            if (Condition37) Rank++;
            if (Condition38) Rank++;
            if (Condition39) Rank++;
            if (Condition40) Rank++;
            if (Condition41) Rank++;
            // Out Of 42
            return Rank;
        }

        
        public int ComputeRankForMinorAndMajorAbjadSummationOfQuestionAndAnswer(int MinorASOQ, int MajorASOQ, int MinorASOA, int MajorASOA)
        {
            int Var1 = MajorASOA - MinorASOA;
            int Var2 = MajorASOQ - MinorASOQ;
            int Var3 = MinorASOQ * MajorASOQ; 
            int Var4 = MinorASOA * MajorASOA;
            int Var5 = Var3;
            bool Condition1 = false;
            while (!Condition1 && Var5 >= -2 * Var4)
            {
                Var5 = Var5 - Var4;
                if (K28_K9(Math.Abs(Var5)))
                    Condition1 = true;
            }
            int Var6 = MajorASOQ;
            int Var7 = MajorASOA;
            bool Condition2 = false;
            while (!Condition2 && Var6 >= -2 * Var7)
            {
                Var6 = Var6 - Var7;
                if (K28_K9(Math.Abs(Var6)))
                    Condition2 = true;
            }

            int Var8 = Var1 / BoddoohNumbers.Nine;
            int Var9 = Var2 / BoddoohNumbers.Nine;

            int Var101 = Var8 + Var9;
            int Var102 = Math.Abs(Var8 - Var9);
            bool Condition3 = K28_K9(Var101);

            int Var111 = MajorASOQ - MajorASOA;
            int Var112 = MinorASOQ - MinorASOA;
            bool Condition4 = false;
            while (!Condition4 && Var111 >= -2 * Var112)
            {
                Var111 = Var111 - Var112;
                if (K28_K9(Math.Abs(Var111)))
                    Condition4 = true;
            }
            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;


            return Rank;

        }

        public bool K28_K9(int i)
        {
            if (i % BoddoohNumbers.TwentyEight == 0) return true;
            if (i % BoddoohNumbers.TwentyEight == 20) return true;
            if (i % BoddoohNumbers.TwentyEight == 8) return true;
            if (i % BoddoohNumbers.Nine == 2) return true;
            if (i % BoddoohNumbers.Nine == 8) return true;
            if (i % BoddoohNumbers.TwentyEight == 2) return true;
            i = i % BoddoohNumbers.TwentyEight;
            if (i % BoddoohNumbers.Nine == 2) return true;
            if (i % BoddoohNumbers.Nine == 8) return true;
            return false;
        }




        public int ComputeRank(int[] QuestionLetters, byte[] AnswerLetters, int[] StairwayResultArray)
        {
            int[] NestedSquaresResultArray = new int[AnswerLetters.Length-1];
            int MinorASOQ = 0; int MajorASOQ = 0; int MinorASOA = 0; int MajorASOA = 0;
             for (int i = 0; i < HalfLength; i++)
            {
                MinorASOQ += QuestionLetters[i];
                 MajorASOQ += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber (QuestionLetters[i]));
                MinorASOA += AnswerLetters[i];
                 MajorASOA += Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber (AnswerLetters[i]));

            }
            int[,] Table110 = new int[HalfLength, 4];
            int[,] Table1191 = new int[HalfLength, 4];
            int[,] Table1192 = new int[HalfLength, 4];

            int LL = Length - 1;
            int RR = 0;
            int TT = 0;
            int BB = Length - 1;
            for (int Row = HalfLength - 2; Row >= 0; Row--)
            {              
                int T = 0;
                for (int i=RR;i<=LL;i++)
                    T += TheElements[TT, i];
                Table110[Row, 0] = T;

                int R = 0;
                for (int i = TT; i <= BB; i++)
                    R += TheElements[i, RR];
                Table110[Row, 1] = R;

                int B = 0;
                for (int i = RR; i <= LL; i++)
                    B += TheElements[BB, i];
                Table110[Row, 2] = B;

                int L = 0;
                for (int i = TT; i <= BB; i++)
                    L += TheElements[i, LL];
                Table110[Row, 3] = L;

                LL--;   RR++;   TT++;   BB --;
            }
            for (int Column = 0; Column < 4; Column++)
            {
                int Temp = 0;
                for (int Row = 0; Row < HalfLength - 1; Row++)
                    Temp += Table110[Row, Column];
                Table110[HalfLength - 1, Column] = Temp;
            }
            int SumC0 = 0; int SumC1 = 0; int SumC2 = 0; int SumC3 = 0;
            for (int Column = 0; Column < 4; Column++)
                for (int Row = 0; Row < HalfLength; Row++)
                {
                    int Temp = MiscMethods.EquivalentNumber(Table110[Row, Column]);
                    Table1191[Row, Column] = Temp;
                    while (Temp > 9) Temp = MiscMethods.SummationOfDigits(Temp);
                    Table1192[Row, Column] = Temp;

                    if (Column == 0) SumC0 += Temp;
                    if (Column == 1) SumC1 += Temp;
                    if (Column == 2) SumC2 += Temp;
                    if (Column == 3) SumC3 += Temp;
                }


            for (int Row = 0; Row < HalfLength-1; Row++)
            {
                int temp = Table110[Row, 0] + Table110[Row, 1] + Table110[Row, 2] + Table110[Row, 3];
                NestedSquaresResultArray[NestedSquaresResultArray.Length - 1 - Row] = temp;
            }


            int C0 = Table110[HalfLength - 1, 0]; int C1 = Table110[HalfLength - 1, 1]; int C2 = Table110[HalfLength - 1, 2]; int C3 = Table110[HalfLength - 1, 3];

            int Var1 = C3 + C2;
            bool Condition1 = K28_K9(Var1);
            if (Condition1) return 1; return 0;///
            int Var2 = C2 + C1;
            bool Condition2 = K28_K9(Var2);
            

            int Var3 = C1 + C0;
            bool Condition3 = K28_K9(Var3);

            int Var4 = C0 + C3;
            bool Condition4 = K28_K9(Var4);

            int Var51 = Math.Abs(C3 - C2); int Var52 = Math.Abs(C2 - C1); int Var53 = Var51 + Var52; int Var54 = Math.Abs(Var51 - Var52);
            bool Condition51 = K28_K9(Var53);
            bool Condition52 = K28_K9(Var54);

            int Var61 = Math.Abs(C2 - C1); int Var62 = Math.Abs(C1 - C0); int Var63 = Var61 + Var62; int Var64 = Math.Abs(Var61 - Var62);
            bool Condition61 = K28_K9(Var63);
            bool Condition62 = K28_K9(Var64);

            int Var71 = Math.Abs(C0 - C3); int Var72 = Math.Abs(C3 - C2); int Var73 = Var71 + Var72; int Var74 = Math.Abs(Var71 - Var72);
            bool Condition71 = K28_K9(Var73);
            bool Condition72 = K28_K9(Var74);

            int CSum = C0 + C1 + C2 + C3;
            bool Condition81 = (CSum % HalfLength == 8);
            bool Condition82 = K28_K9(CSum);
            bool Condition83 = K28_K9(CSum);
            //-------------------------------------------------------------
            int Var91 = SumC3 - SumC0;
            int Var92 = SumC2 - SumC1;
            int Var93 = SumC3 + SumC0;
            int Var94 = SumC2 + SumC1;

            int Var95 = Math.Abs(Var91 - Var92);
            int Var96 = Math.Abs(Var91 - Var94);
            int Var97 = Math.Abs(Var93 - Var92);
            int Var98 = Math.Abs(Var93 - Var94);

            int Var99 = Var91 + Var92;
            int Var910 = Var91 + Var94;
            int Var911 = Var93 + Var92;
            int Var912 = Var93 + Var94;

            bool Condition9 = (K28_K9(Var95) || K28_K9(Var96) || K28_K9(Var97) || K28_K9(Var98) || K28_K9(Var98) || K28_K9(Var99) || K28_K9(Var910) || K28_K9(Var911) || K28_K9(Var912));
                 
             int D0 = Table1192[HalfLength - 1, 0]; int D1 = Table1192[HalfLength - 1, 1];  int D2 = Table1192[HalfLength - 1, 2];  int D3 = Table1192[HalfLength - 1, 3];
            
             bool Condition10 = ( 
                 MiscMethods.JoinDigits(D0, D1, D2, D3) == CSum 
                 || MiscMethods.JoinDigits(D0, D1, D3, D2) == CSum 
                 || MiscMethods.JoinDigits(D0, D2, D1, D3) == CSum  
                 || MiscMethods.JoinDigits(D0, D2, D3, D1) == CSum
                 || MiscMethods.JoinDigits(D0, D3, D1, D2) == CSum  
                 || MiscMethods.JoinDigits(D0, D3, D2, D1) == CSum

               ||  MiscMethods.JoinDigits(D1, D0, D2, D3) == CSum
               ||  MiscMethods.JoinDigits(D1, D0, D3, D2) == CSum
               ||  MiscMethods.JoinDigits(D1, D2, D0, D3) == CSum
               ||  MiscMethods.JoinDigits(D1, D2, D3, D0) == CSum
               ||  MiscMethods.JoinDigits(D1, D3, D0, D2) == CSum
               ||  MiscMethods.JoinDigits(D1, D3, D2, D0) == CSum

               ||  MiscMethods.JoinDigits(D2, D0, D1, D3) == CSum
               ||  MiscMethods.JoinDigits(D2, D0, D3, D1) == CSum
               ||  MiscMethods.JoinDigits(D2, D1, D0, D3) == CSum
               ||  MiscMethods.JoinDigits(D2, D1, D3, D0) == CSum
               ||  MiscMethods.JoinDigits(D2, D3, D0, D1) == CSum
               ||  MiscMethods.JoinDigits(D2, D3, D1, D0) == CSum

               ||  MiscMethods.JoinDigits(D3, D0, D1, D2) == CSum
               ||  MiscMethods.JoinDigits(D3, D0, D2, D1) == CSum
               ||  MiscMethods.JoinDigits(D3, D1, D0, D2) == CSum
               ||  MiscMethods.JoinDigits(D3, D1, D2, D0) == CSum
               ||  MiscMethods.JoinDigits(D3, D2, D0, D1) == CSum
               ||  MiscMethods.JoinDigits(D3, D2, D1, D0) == CSum
               );

             int RankForMinorAndMajorAbjadSummationOfQuestionAndAnswer = ComputeRankForMinorAndMajorAbjadSummationOfQuestionAndAnswer(MinorASOQ, MajorASOQ, MinorASOA, MajorASOA);

            //---------------------------------------
             int[] TempArray = new int[Length];
             int Average = (int)Math.Round(Math.Floor((double)MinorASOA / (double)Length));
             int Remaining = MinorASOA - Average * Length;
             for (int i = 0; i < Length; i++)
                 TempArray[i] = Average;

             if (Remaining >= HalfLength)
             {
                 int index = 0;
                 while (Remaining > 0)
                 {
                     TempArray[index]++;
                     Remaining--;
                     index++;
                 }
             }
             else
             {
                 int index = Length - 1;
                 while (Remaining > 0)
                 {
                     TempArray[index]++;
                     Remaining--;
                     index--;
                 }
             }
            int Var12 = 0;
            for (int i = 0; i < HalfLength;i++)
            {
                Var12 += (AnswerLetters[i] - TempArray[i]);
            }

            bool Condition11 = K28_K9(Var12);

            int Rank = 0;            
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;
            if (Condition51 || Condition52) Rank++;
            
            if (Condition61 || Condition62) Rank++;
            
            if (Condition71 || Condition72) Rank++;
            
            if (Condition81) Rank++;
            if (Condition82) Rank++;
            if (Condition83) Rank++;
            if (Condition9) Rank++;
            if (Condition10) Rank++;
            if (Condition11) Rank++;

            Rank+=RankForMinorAndMajorAbjadSummationOfQuestionAndAnswer;
            Rank += (int) Conditions9102(NestedSquaresResultArray, StairwayResultArray);
            int[] IntAnswerLetters = new int[AnswerLetters.Length];
            for (int i = 0; i < AnswerLetters.Length; i++)
            {
                IntAnswerLetters[i] = AnswerLetters[i];
            }
            Rank += Conditions_ABCDEFG(QuestionLetters, IntAnswerLetters);            
            return Rank ;


        }
    }

    public class SaveToExcel
    {
        public int a11, a12, a13, a14, a21, a22, a23, a24, a31, a32, a33, a34, a41, a42, a43, a44;
        public int SummationOfColumn1, SummationOfColumn2, SummationOfColumn3, SummationOfColumn4;
        public int SummationOfRow1, SummationOfRow2, SummationOfRow3, SummationOfRow4;
        public int SummationOfItems;

        
    }

    public class Boddooh4By4TableArray
    {

            public Boddooh4By4Table[] B4BTs;
            public Boddooh4By4Table B4BTSum;

            public int[] Cell11;
            public int[] Cell12  ;
            public int[] Cell13  ;
            public int[] Cell14  ;
            public int[] Cell21  ;
            public int[] Cell22  ;
            public int[] Cell23  ;
            public int[] Cell24  ;
            public int[] Cell31  ;
            public int[] Cell32  ;
            public int[] Cell33  ;
            public int[] Cell34  ;
            public int[] Cell41  ;
            public int[] Cell42  ;
            public int[] Cell43  ;
            public int[] Cell44  ;

            public int[] SumCol1  ;
            public int[] SumCol2  ;
            public int[] SumCol3  ;
            public int[] SumCol4  ;
            public int[] Sum ;
            public int[] SumColsMod28 ; 
            public int SumColsMod28_Summation ;
            public int[] InverseSumColsMod28 ; 
            public int InverseSumColsMod28_Summation ;

            public int[] BranchSum ;
            public int[] BranchJoin ;
            public int[] BranchMul ;

            public int B4BTSumSumOfCol1Mod28;
            public int B4BTSumSumOfCol2Mod28;
            public int B4BTSumSumOfCol3Mod28;
            public int B4BTSumSumOfCol4Mod28;
            public int[] B4BTSumSumOfColsMod28Array;

            public int BranchMulSumOfCol1Mod28 ;
            public int BranchMulSumOfCol2Mod28;
            public int BranchMulSumOfCol3Mod28;
            public int BranchMulSumOfCol4Mod28;
            public int[] B4BTMulSumOfColsMod28Array;

            public int BranchJoinSumOfCol1Mod28;
            public int BranchJoinSumOfCol2Mod28;
            public int BranchJoinSumOfCol3Mod28;
            public int BranchJoinSumOfCol4Mod28;
            public int[] B4BTJoinSumOfColsMod28Array;

            public Boddooh4By4TableArray(Boddooh4By4Table[] b4BTs)
            {
                 Initialize(b4BTs);
            }
             
            public void Initialize(Boddooh4By4Table[] b4BTs)
            {
                int Length = b4BTs.Length;
                B4BTSum = new Boddooh4By4Table(0,0,0,0);
                B4BTSum.SetAllToZero();
                Cell11 = new int[Length]; Cell12 = new int[Length]; Cell13 = new int[Length]; Cell14 = new int[Length];
                Cell21 = new int[Length]; Cell22 = new int[Length]; Cell23 = new int[Length]; Cell24 = new int[Length];
                Cell31 = new int[Length]; Cell32 = new int[Length]; Cell33 = new int[Length]; Cell34 = new int[Length];
                Cell41 = new int[Length]; Cell42 = new int[Length]; Cell43 = new int[Length]; Cell44 = new int[Length];
                Sum = new int[Length];
                SumColsMod28 = new int[Length];
                InverseSumColsMod28 = new int[Length];
                BranchSum = new int[16];
                BranchJoin = new int[16];
                BranchMul = new int[16];
                SumCol1 = new int[Length];
                SumCol2 = new int[Length];
                SumCol3 = new int[Length];
                SumCol4 = new int[Length];
                

                B4BTs = new Boddooh4By4Table[b4BTs.Length];
                for (int i = 0; i < Length; i++)
                {                    
                    B4BTs[i] = new Boddooh4By4Table(b4BTs[i].a11, b4BTs[i].a12, b4BTs[i].a13, b4BTs[i].a14);
                    Cell11[i] = B4BTs[i].a11; Cell12[i] = B4BTs[i].a12; Cell13[i] = B4BTs[i].a13; Cell14[i] = B4BTs[i].a14;
                    Cell21[i] = B4BTs[i].a21; Cell22[i] = B4BTs[i].a22; Cell23[i] = B4BTs[i].a23; Cell24[i] = B4BTs[i].a24;
                    Cell31[i] = B4BTs[i].a31; Cell32[i] = B4BTs[i].a32; Cell33[i] = B4BTs[i].a33; Cell34[i] = B4BTs[i].a34;
                    Cell41[i] = B4BTs[i].a41; Cell42[i] = B4BTs[i].a42; Cell43[i] = B4BTs[i].a43; Cell44[i] = B4BTs[i].a44;
                    SumCol1[i] = B4BTs[i].SummationOfColumn1; SumCol2[i] = B4BTs[i].SummationOfColumn2; SumCol3[i] = B4BTs[i].SummationOfColumn3; SumCol4[i] = B4BTs[i].SummationOfColumn4;
                    Sum[i] = B4BTs[i].SummationOfItems;
                    int[] Temp = new int[4];
                    Temp[0] = B4BTs[i].SummationOfColumn4; Temp[1] = B4BTs[i].SummationOfColumn3; Temp[2] = B4BTs[i].SummationOfColumn2; Temp[3] = B4BTs[i].SummationOfColumn1;
                    SumColsMod28[i] = MiscMethods.JoinItemsAndModN(Temp,28);
                    SumColsMod28_Summation += SumColsMod28[i];
                    Temp[0] = B4BTs[i].SummationOfColumn1; Temp[1] = B4BTs[i].SummationOfColumn2; Temp[2] = B4BTs[i].SummationOfColumn3; Temp[3] = B4BTs[i].SummationOfColumn4;
                    InverseSumColsMod28[i] =  MiscMethods.JoinItemsAndModN(Temp, 28);
                    InverseSumColsMod28_Summation += InverseSumColsMod28[i];
                    B4BTSum = Boddooh4By4Table.Sum(B4BTSum, B4BTs[i]);
                }

                BranchSum[0] = B4BTSum.a11;                BranchMul[0] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell11, 28));
                BranchJoin[0] = MiscMethods.JoinItemsAndModN(Cell11, 28);
                BranchSum[1] = B4BTSum.a21;                BranchMul[1] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell21, 28));
                BranchJoin[1] = MiscMethods.JoinItemsAndModN(Cell21, 28);
                BranchSum[2] = B4BTSum.a31;                BranchMul[2] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell31, 28));
                BranchJoin[2] = MiscMethods.JoinItemsAndModN(Cell31, 28);
                BranchSum[3] = B4BTSum.a41;                BranchMul[3] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell41, 28));
                BranchJoin[3] = MiscMethods.JoinItemsAndModN(Cell41, 28);
                BranchSum[4] = B4BTSum.a12;                BranchMul[4] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell12, 28));
                BranchJoin[4] = MiscMethods.JoinItemsAndModN(Cell12, 28);
                BranchSum[5] = B4BTSum.a22;                BranchMul[5] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell22, 28));
                BranchJoin[5] = MiscMethods.JoinItemsAndModN(Cell22, 28);
                BranchSum[6] = B4BTSum.a32;                BranchMul[6] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell32, 28));
                BranchJoin[6] = MiscMethods.JoinItemsAndModN(Cell32, 28);
                BranchSum[7] = B4BTSum.a42;                BranchMul[7] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell42, 28));
                BranchJoin[7] = MiscMethods.JoinItemsAndModN(Cell42, 28);
                BranchSum[8] = B4BTSum.a13;                BranchMul[8] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell13, 28));
                BranchJoin[8] = MiscMethods.JoinItemsAndModN(Cell13, 28);
                BranchSum[9] = B4BTSum.a23;                BranchMul[9] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell23, 28));
                BranchJoin[9] = MiscMethods.JoinItemsAndModN(Cell23, 28);
                BranchSum[10] = B4BTSum.a33;                BranchMul[10] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell33, 28));
                BranchJoin[10] = MiscMethods.JoinItemsAndModN(Cell33, 28);
                BranchSum[11] = B4BTSum.a43;                BranchMul[11] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell43, 28));
                BranchJoin[11] = MiscMethods.JoinItemsAndModN(Cell43, 28);                
                BranchSum[12] = B4BTSum.a14;                BranchMul[12] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell14, 28));
                BranchJoin[12] = MiscMethods.JoinItemsAndModN(Cell14, 28);
                BranchSum[13] = B4BTSum.a24;                BranchMul[13] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell24, 28));
                BranchJoin[13] = MiscMethods.JoinItemsAndModN(Cell24, 28);
                BranchSum[14] = B4BTSum.a34;                BranchMul[14] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell34, 28));
                BranchJoin[14] = MiscMethods.JoinItemsAndModN(Cell34, 28);
                BranchSum[15] = B4BTSum.a44;                BranchMul[15] = MiscMethods.EquivalentNumber(MiscMethods.ArrayItemsMultiplicationModN(Cell44, 28));
                BranchJoin[15] = MiscMethods.JoinItemsAndModN(Cell44, 28);

                 B4BTSumSumOfCol1Mod28 = MiscMethods.EquivalentNumber(B4BTSum.SummationOfColumn1 % 28);
                 B4BTSumSumOfCol2Mod28 = MiscMethods.EquivalentNumber(B4BTSum.SummationOfColumn2 % 28);
                 B4BTSumSumOfCol3Mod28 = MiscMethods.EquivalentNumber(B4BTSum.SummationOfColumn3 % 28);
                 B4BTSumSumOfCol4Mod28 = MiscMethods.EquivalentNumber(B4BTSum.SummationOfColumn4 % 28);
                 B4BTSumSumOfColsMod28Array = MiscMethods.GetArray(B4BTSumSumOfCol1Mod28, B4BTSumSumOfCol2Mod28, B4BTSumSumOfCol3Mod28, B4BTSumSumOfCol4Mod28);

                  BranchMulSumOfCol1Mod28 = MiscMethods.EquivalentNumber((BranchMul[0] + BranchMul[1] + BranchMul[2] + BranchMul[3]) % 28);
                  BranchMulSumOfCol2Mod28 = MiscMethods.EquivalentNumber((BranchMul[4] + BranchMul[5] + BranchMul[6] + BranchMul[7]) % 28);
                  BranchMulSumOfCol3Mod28 = MiscMethods.EquivalentNumber((BranchMul[8] + BranchMul[9] + BranchMul[10] + BranchMul[11]) % 28);
                  BranchMulSumOfCol4Mod28 = MiscMethods.EquivalentNumber((BranchMul[12] + BranchMul[13] + BranchMul[14] + BranchMul[15]) % 28);
                  B4BTMulSumOfColsMod28Array = MiscMethods.GetArray(BranchMulSumOfCol1Mod28, BranchMulSumOfCol2Mod28, BranchMulSumOfCol3Mod28, BranchMulSumOfCol4Mod28);

                  BranchJoinSumOfCol1Mod28 = MiscMethods.EquivalentNumber((BranchJoin[0] + BranchJoin[1] + BranchJoin[2] + BranchJoin[3]) % 28);
                  BranchJoinSumOfCol2Mod28 = MiscMethods.EquivalentNumber((BranchJoin[4] + BranchJoin[5] + BranchJoin[6] + BranchJoin[7]) % 28);
                  BranchJoinSumOfCol3Mod28 = MiscMethods.EquivalentNumber((BranchJoin[8] + BranchJoin[9] + BranchJoin[10] + BranchJoin[11]) % 28);
                  BranchJoinSumOfCol4Mod28 = MiscMethods.EquivalentNumber((BranchJoin[12] + BranchJoin[13] + BranchJoin[14] + BranchJoin[15]) % 28);
                  B4BTJoinSumOfColsMod28Array = MiscMethods.GetArray(BranchJoinSumOfCol1Mod28, BranchJoinSumOfCol2Mod28, BranchJoinSumOfCol3Mod28, BranchJoinSumOfCol4Mod28);

          

  
           }
    }

    public class Boddooh4By4Table
    {
        public int a11, a12, a13, a14, a21, a22, a23, a24, a31, a32, a33, a34, a41, a42, a43, a44;
        public int SummationOfColumn1, SummationOfColumn2, SummationOfColumn3, SummationOfColumn4;
        public int SummationOfRow1, SummationOfRow2, SummationOfRow3, SummationOfRow4;
        public int SummationOfItems;

        public void SetAllToZero()
        {
            a11 = 0; a12= 0;  a13= 0;a14= 0;
            a21 = 0; a22= 0;  a23= 0;a24= 0;
            a31 = 0; a32= 0;  a33= 0;a34= 0;
            a41= 0; a42 = 0;  a43= 0;a44= 0;
          SummationOfColumn1= 0; SummationOfColumn2= 0; SummationOfColumn3= 0; SummationOfColumn4= 0;
          SummationOfRow1 = 0; SummationOfRow2 = 0; SummationOfRow3 = 0; SummationOfRow4 = 0;
          SummationOfItems = 0;

        }

        public static Boddooh4By4Table Sum(Boddooh4By4Table B1, Boddooh4By4Table B2)
        {
            Boddooh4By4Table result = new Boddooh4By4Table(0,0,0,0);
            result.a11 = B1.a11 + B2.a11; result.a12 = B1.a12 + B2.a12; result.a13 = B1.a13 + B2.a13; result.a14 = B1.a14 + B2.a14; 
            result.a21 = B1.a21 + B2.a21; result.a22 = B1.a22 + B2.a22; result.a23 = B1.a23 + B2.a23; result.a24 = B1.a24 + B2.a24; 
            result.a31 = B1.a31 + B2.a31; result.a32 = B1.a32 + B2.a32; result.a33 = B1.a33 + B2.a33; result.a34 = B1.a34 + B2.a34; 
            result.a41 = B1.a41 + B2.a41; result.a42 = B1.a42 + B2.a42; result.a43 = B1.a43 + B2.a43; result.a44 = B1.a44 + B2.a44; 
            result.SummationOfColumn1 = B1.SummationOfColumn1 + B2.SummationOfColumn1; result.SummationOfColumn2 = B1.SummationOfColumn2 + B2.SummationOfColumn2; result.SummationOfColumn3 = B1.SummationOfColumn3 + B2.SummationOfColumn3; result.SummationOfColumn4 = B1.SummationOfColumn4 + B2.SummationOfColumn4; 
            result.SummationOfRow1 = B1.SummationOfRow1 + B2.SummationOfRow1; result.SummationOfRow2 = B1.SummationOfRow2 + B2.SummationOfRow2; result.SummationOfRow3 = B1.SummationOfRow3 + B2.SummationOfRow3; result.SummationOfRow4 = B1.SummationOfRow4 + B2.SummationOfRow4; 
            result.SummationOfItems = B1.SummationOfItems + B2.SummationOfItems;
            return result;
        }
        public Boddooh4By4Table(int x11, int x12, int x13, int x14)
        {
            a11 = x11;
            a12 = x12;
            a13 = x13;
            a14 = x14;
            a22 = a33 = a44 = a11;
            a21 = MiscMethods.EquivalentNumber((a11 + a22) - a12);
            a23 = MiscMethods.EquivalentNumber((a13 + a22) - a12);
            a24 = MiscMethods.EquivalentNumber((a14 + a23) - a13);
            a34 = MiscMethods.EquivalentNumber((a24 + a33) - a23);
            a32 = MiscMethods.EquivalentNumber((a22 + a33) - a23);
            a31 = MiscMethods.EquivalentNumber((a21 + a32) - a22);
            a43 = MiscMethods.EquivalentNumber((a33 + a44) - a34);
            a42 = MiscMethods.EquivalentNumber((a32 + a43) - a33);
            a41 = MiscMethods.EquivalentNumber((a31 + a42) - a32);

            SummationOfColumn1 = (a11 + a21 + a31 + a41);
            SummationOfColumn2 = (a12 + a22 + a32 + a42);
            SummationOfColumn3 = (a13 + a23 + a33 + a43);
            SummationOfColumn4 = (a14 + a24 + a34 + a44);
            SummationOfRow1 = (a11 + a12 + a13 + a14);
            SummationOfRow2 = (a21 + a22 + a23 + a24);
            SummationOfRow3 = (a31 + a32 + a33 + a34);
            SummationOfRow4 = (a41 + a42 + a43 + a44);
            SummationOfItems = SummationOfColumn1 + SummationOfColumn2 + SummationOfColumn3 + SummationOfColumn4;
        }
    }

    public class BoddoohStairwayLab
    {
        //public int ColumnsCount;
        //public int[,] Middle;
        //public int[] Top;
        //public int[] Bottom;
        //public int[] CarryBorrow;
        //public int CompletedPartLengthFromRight;
        //public int CompletedPartLengthFromLeft;
              
        //public static bool CheckSummationOfRowsAndColumns(Boddooh4By4Table[] B4B4Ts)
        //{
        //    int SummationOfColumn1 = 0;
        //    int SummationOfColumn2 = 0;
        //    int SummationOfColumn3 = 0;
        //    int SummationOfColumn4 = 0;
        //    int SummationOfRow1 = 0;
        //    int SummationOfRow2 = 0;
        //    int SummationOfRow3 = 0;
        //    int SummationOfRow4 = 0;

        //    for (int i = 0; i < B4B4Ts.Length; i++)
        //    {
        //        SummationOfColumn1 += B4B4Ts[i].SummationOfColumn1;
        //        SummationOfColumn2 += B4B4Ts[i].SummationOfColumn2;
        //        SummationOfColumn3 += B4B4Ts[i].SummationOfColumn3;
        //        SummationOfColumn4 += B4B4Ts[i].SummationOfColumn4;
        //        SummationOfRow1 += B4B4Ts[i].SummationOfRow1;
        //        SummationOfRow2 += B4B4Ts[i].SummationOfRow2;
        //        SummationOfRow3 += B4B4Ts[i].SummationOfRow3;
        //        SummationOfRow4 += B4B4Ts[i].SummationOfRow4;
        //    }
        //    int Column1Reminder = SummationOfColumn1 % BoddoohNumbers.TwentyEight;
        //    int Column2Reminder = SummationOfColumn2 % BoddoohNumbers.TwentyEight;
        //    int Column3Reminder = SummationOfColumn3 % BoddoohNumbers.TwentyEight;
        //    int Column4Reminder = SummationOfColumn4 % BoddoohNumbers.TwentyEight;
        //    int Row1Reminder = SummationOfRow1 % BoddoohNumbers.TwentyEight;
        //    int Row2Reminder = SummationOfRow2 % BoddoohNumbers.TwentyEight;
        //    int Row3Reminder = SummationOfRow3 % BoddoohNumbers.TwentyEight;
        //    int Row4Reminder = SummationOfRow4 % BoddoohNumbers.TwentyEight; 
        //    int[] BagItems = {Row1Reminder, Row2Reminder, Row3Reminder, Row4Reminder}, AllowedItems = {0, 8, 24}, MaximumFrequencies = {1, 1, 2};
        //    if (!CheckValidityOfTheBag(BagItems, AllowedItems, MaximumFrequencies))
        //        return false;
        //    BagItems = new int[]{ Column1Reminder, Column2Reminder, Column3Reminder, Column4Reminder };
        //    int[] AllowedItems1 = new int[] { 0, 4, 20 };
        //    int[] AllowedItems2 = new int[] { 0, 4, 8 };
        //    MaximumFrequencies = new int[] { 1, 2, 1 };
        //    if (!CheckValidityOfTheBag(BagItems, AllowedItems1, MaximumFrequencies) && !CheckValidityOfTheBag(BagItems, AllowedItems2, MaximumFrequencies))
        //        return false;
        //    return true;
        //}

        public static bool DoTheCheckingProcess(int[] questionLetters, byte[] answerLetters, int [] StairwayResultArray)
        {
            int Length = questionLetters.Length;
            Boddooh4By4Table[] B4B4Ts = new Boddooh4By4Table[Length - 1];
            for (int i = 0; i < Length - 1; i++)
            {
                B4B4Ts[i] = new Boddooh4By4Table(questionLetters[i], questionLetters[i + 1], answerLetters[i], answerLetters[i + 1]);
                StairwayResultArray[i] = B4B4Ts[i].SummationOfItems;

            }
            return CheckSummationOfRowsAndColumns(B4B4Ts);
        }

        public static bool CheckSummationOfRowsAndColumns(Boddooh4By4Table[] B4B4Ts)
        {
            int SummationOfColumn1 = 0;
            int SummationOfColumn2 = 0;
            int SummationOfColumn3 = 0;
            int SummationOfColumn4 = 0;
            int SummationOfRow1 = 0;
            int SummationOfRow2 = 0;
            int SummationOfRow3 = 0;
            int SummationOfRow4 = 0;

            for (int i = 0; i < B4B4Ts.Length; i++)
            {
                SummationOfColumn1 += B4B4Ts[i].SummationOfColumn1;
                SummationOfColumn2 += B4B4Ts[i].SummationOfColumn2;
                SummationOfColumn3 += B4B4Ts[i].SummationOfColumn3;
                SummationOfColumn4 += B4B4Ts[i].SummationOfColumn4;
                SummationOfRow1 += B4B4Ts[i].SummationOfRow1;
                SummationOfRow2 += B4B4Ts[i].SummationOfRow2;
                SummationOfRow3 += B4B4Ts[i].SummationOfRow3;
                SummationOfRow4 += B4B4Ts[i].SummationOfRow4;
            }
            int Column1Reminder = SummationOfColumn1 % BoddoohNumbers.TwentyEight;
            int Column2Reminder = SummationOfColumn2 % BoddoohNumbers.TwentyEight;
            int Column3Reminder = SummationOfColumn3 % BoddoohNumbers.TwentyEight;
            int Column4Reminder = SummationOfColumn4 % BoddoohNumbers.TwentyEight;
            int Row1Reminder = SummationOfRow1 % BoddoohNumbers.TwentyEight;
            int Row2Reminder = SummationOfRow2 % BoddoohNumbers.TwentyEight;
            int Row3Reminder = SummationOfRow3 % BoddoohNumbers.TwentyEight;
            int Row4Reminder = SummationOfRow4 % BoddoohNumbers.TwentyEight;
            int SummationForAll = Column1Reminder + Column2Reminder + Column3Reminder + Column4Reminder;

            if (SummationForAll % BoddoohNumbers.TwentyEight != 0)
                return false;

            if (Column4Reminder % BoddoohNumbers.TwentyEight != 0)
                return false;

            if (Column1Reminder % BoddoohNumbers.TwentyEight == 20 || Column1Reminder % BoddoohNumbers.TwentyEight == 8)
                return true;

            return false;

        }

        //public static bool DoTheCheckingProcess(int[] questionLetters, int[] answerLetters, int CompletedPartCount)
        //{
        //    int Length = questionLetters.Length;
        //    Boddooh4By4Table[] B4B4Ts = new Boddooh4By4Table[Length-1];
        //    for (int i = 0; i < Length - 1; i++)
        //    {
        //        B4B4Ts[i] = new Boddooh4By4Table(questionLetters[i], questionLetters[i + 1], answerLetters[i], answerLetters[i + 1]);
        //        B4B4Ts[Length - 2 - i] = new Boddooh4By4Table(questionLetters[Length - 1 - i - 1], questionLetters[Length - 1 - i], answerLetters[Length - 1 - i - 1], answerLetters[Length - 1 - i]); 
        //    }
        //    if (!CheckSummationsAndDifferences(B4B4Ts, CompletedPartCount))
        //        return false;
        //    if (CompletedPartCount == Length / 2)
        //        if (!CheckSummationOfRowsAndColumns(B4B4Ts))
        //         return false;
        //    return true;
        //}
        

        //public static bool CheckValidityOfTheBag(int[] BagItems, int[] AllowedItems, int[] MaximumFrequencies)
        //{
        //    int[] Frequencies = new int[MaximumFrequencies.Length];
        //    for (int i = 0; i < Frequencies.Length; i++)
        //        Frequencies[i] = 0;                        
        //    for (int i = 0; i < BagItems.Length; i++)
        //    {
        //        int index = MiscMethods.SequentialSearch(AllowedItems, BagItems[i]);
        //        if (index==-1)
        //            return false;
        //        Frequencies[index]++;
        //        if (Frequencies[index] > MaximumFrequencies[index])
        //            return false;
        //    }
        //    return true;
        //}

       

        //public static bool CheckDifferencesOrSummation(int[] Differences, int LengthThreeOrFour, bool DifferenceNoSummation)
        //{
        //    int Count = Differences.Length - 1;
        //    int AllCombinationsCount = MiscMethods.Power(2, LengthThreeOrFour);
        //    int[,] AllCombinations = new int[AllCombinationsCount, LengthThreeOrFour];
        //    for (int i = 0; i < AllCombinationsCount; i++)
        //        for (int j = 0; j < LengthThreeOrFour; j++)
        //            AllCombinations[i, j] = 0;

        //    int[] AllowedItems = null, MaximumFrequencies = null;
        //    if (LengthThreeOrFour == 3)
        //    {
        //        AllowedItems = new int[]{1, 2, 8}; MaximumFrequencies = new int[]{1, 1, 1};
        //    }
        //    if (LengthThreeOrFour == 4)
        //    {
        //        AllowedItems = new int[]{2, 4, 6, 8}; MaximumFrequencies = new int[]{1, 1, 1, 1};
        //    }

        //    for (int i = 0; i < Count; i++)
        //    {
        //        int index = i % LengthThreeOrFour;
        //        int Module = MiscMethods.Power(2, index);
        //        int Summation = Differences[i] + Differences[i + 1];
        //        int Difference = Math.Abs(Differences[i] - Differences[i + 1]);
        //        while (Summation > 9) Summation = MiscMethods.SummationOfDigits(Summation);
        //        while (Difference > 9) Difference = MiscMethods.SummationOfDigits(Difference);

        //        for (int j = 0; j < AllCombinationsCount; j++)
        //        {
        //            int temp = (j / Module);
        //            if (temp % 2 == 0)
        //                AllCombinations[j, index] = Summation;
        //            else
        //                AllCombinations[j, index] = Difference;
        //        }
        //        if (index == LengthThreeOrFour-1)
        //        {
        //            bool OK = false;
        //            for (int k = 0; k < AllCombinationsCount; k++)
        //            {
        //                int[] a = new int [LengthThreeOrFour];                        
        //                for (int l = 0; l < LengthThreeOrFour; l++)
        //                    a[l] = AllCombinations[k, l];
        //                if (CheckValidityOfTheBag(a, AllowedItems, MaximumFrequencies))
        //                    OK = true;

        //            }
        //            if (!OK)
        //                return false;
        //        }
        //        else
        //        {
        //            if (i == Count - 1)
        //            {
        //                bool OK = false;
        //                for (int k = 0; k < AllCombinationsCount; k++)
        //                {
        //                    int[] a = new int[Count % LengthThreeOrFour];
        //                    for (int l = 0; l < a.Length; l++)
        //                        a[l] = AllCombinations[k, l];
        //                    if (CheckValidityOfTheBag(a, AllowedItems, MaximumFrequencies))
        //                        OK = true;
        //                }
        //                if (!OK)
        //                    return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public static bool CheckSummationsAndDifferences(Boddooh4By4Table[] B4B4Ts, int Count)
        //{
        //    int Length = B4B4Ts.Length + 1;
        //    int ChainItemsCount = Count - 1;
        //    if (Length % 2 == 0 && Count == Length / 2)
        //        ChainItemsCount++;

        //    int[] Summations = new int[ChainItemsCount];
        //    int[] Differences = new int[ChainItemsCount];

        //    for (int i = 0; i < ChainItemsCount; i++)
        //    {
        //        if (i < B4B4Ts.Length - 1 - i)
        //        {
        //            Summations[i] = (B4B4Ts[i].SummationOfItems + B4B4Ts[B4B4Ts.Length - 1 - i].SummationOfItems) % 9;
        //            Differences[i] = (Math.Abs(B4B4Ts[i].SummationOfItems - B4B4Ts[B4B4Ts.Length - 1 - i].SummationOfItems)) % 9;
        //        }
        //        else
        //        {
        //            Summations[i] = B4B4Ts[i].SummationOfItems % 9;
        //            Differences[i] = B4B4Ts[i].SummationOfItems % 9; 
        //        }
        //    }
        //    if (!CheckDifferencesOrSummation(Summations, 4, false))
        //        return false;
        //    if (!CheckDifferencesOrSummation(Differences, 3, true))
        //        return false;
        //    return true;
        //}
    }

    public class AllBoddooh4By4Tables
    {
        public static List<int> AllPossibleSummations;
        //public int ColumnsCount;
       // public Boddooh4By4Table'
        public static ArrayList[] AllB4B4TablesGroupedBySum;
        public static Boddooh4By4Table[,,,] AllB4B4Tables;
        //public int[,] Middle;
        //public int[] Top;
        //public int[] Bottom;
        //public int[] CarryBorrow;
        //public int CompletedPartLengthFromRight;
        //public int CompletedPartLengthFromLeft;
        public static Boddooh4By4Table GetB4B4Table(int A, int B, int C, int D)
        {
            return AllB4B4Tables[A - 1, B - 1, C - 1, D - 1];
        }
        public static ArrayList GetB4B4TablesList(int sum)
        {
            return AllB4B4TablesGroupedBySum[(sum-64)/4];
        }
        public static int Get_B(Boddooh4By4Table B4B4T)
        {
            return MiscMethods.Equivalent1To9(B4B4T.SummationOfItems);
        }
        public static int Get_D(Boddooh4By4Table B4B4T)
        {
            return MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(B4B4T.SummationOfItems)); ;
        }
        public static int Get_B(int B4B4TSummationOfItems)
        {
            return MiscMethods.Equivalent1To9(B4B4TSummationOfItems);
        }
        public static int Get_D(int B4B4TSummationOfItems)
        {
            return MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(B4B4TSummationOfItems)); 
        }

        public static List<int> GetAllPossible_D_ValuesForSecondBoddooh4By4Table(int A, int B, int C, int D)
        {
            List<int> result = new List<int>();
            IntSet RemainingLetters = InputManagement.GetRemainingLetters(A, B, C, D);
            for (int i = 0; i < RemainingLetters.Members.Count; i++)
            {
                Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table(B, C, D, RemainingLetters.Members[i]);
                int D_Value = Get_D(B4B4T);
                if (!result.Contains(D_Value))
                    result.Add(D_Value);
            }
            return result;
        }

        public static List<int> GetAllPossible_B_ValuesForSecondBoddooh4By4Table(int A, int B, int C, int D)
        {
            List<int> result = new List<int>();
            IntSet RemainingLetters = InputManagement.GetRemainingLetters(A, B, C, D);
            for (int i = 0; i < RemainingLetters.Members.Count; i++)
            {
                Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table(B, C, D, RemainingLetters.Members[i]);
                int B_Value = Get_B(B4B4T);
                if (!result.Contains(B_Value))
                    result.Add(B_Value);
            }
            return result;
        }

        public static List<int> GetAllPossible_D_ValuesForTheOneBeforeTheLastBoddooh4By4Table(int A, int B, int C, int D)
        {
            List<int> result = new List<int>();
            int LastLetter = InputManagement.GetLastLetter(A);
            IntSet RemainingLetters = InputManagement.GetRemainingLetters(A, B, C, D);
            for (int i = 0; i < RemainingLetters.Members.Count; i++)
            {
                Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table(RemainingLetters.Members[i], LastLetter, A, B);
                int D_Value = Get_D(B4B4T);
                if (!result.Contains(D_Value))
                    result.Add(D_Value);
            }
            return result;
        }

        public static List<int> GetAllPossible_B_ValuesForTheOneBeforeTheLastBoddooh4By4Table(int A, int B, int C, int D)
        {
            List<int> result = new List<int>();
            int LastLetter = InputManagement.GetLastLetter(A);
            IntSet RemainingLetters = InputManagement.GetRemainingLetters(A, B, C, D);
            for (int i = 0; i < RemainingLetters.Members.Count; i++)
            {
                Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table(RemainingLetters.Members[i], LastLetter, A, B);
                int B_Value = Get_B(B4B4T);
                if (!result.Contains(B_Value))
                    result.Add(B_Value);
            }
            return result;
        }

        public static List<int[]> GetAllFirstBoddooh4By4TablesStartingWithA(int A)//OK
        {
            List<int[]> result = new List<int[]>();
            int LastLetter = InputManagement.GetLastLetter(A);
            for (int B = 1; B <= 28; B++)
                if (A != B && LastLetter != B)
                {
                    for (int C = 1; C <= 28; C++)
                        if (C != B && C != A && C != LastLetter)
                        {
                            for (int D = 1; D <= 28; D++)
                                if (D != C && D != B && D != A && D != LastLetter)
                                {
                                    int[] temp = new int[4]; temp[0] = A; temp[1] = B; temp[2] = C; temp[3] = D;
                                    result.Add(temp);
                                }
                        }
                }
            return result;
        }
        public static List<int[]> GetAllFirstBoddooh4By4TablesStartingWithA(int L1, int L2, int L3, int L4)//OK
        {
            List<int[]> result = new List<int[]>();
            int LastLetter = InputManagement.GetLastLetter(L1);
            for (int B = 1; B <= 28; B++)
                if (L1 != B && LastLetter != B) 
                {
                    if (L2 == 0 || L2==B)
                    for (int C = 1; C <= 28; C++)
                        if (C != B && C != L1 && C != LastLetter)
                        {
                            if (L3 == 0 || L3 == C)
                            for (int D = 1; D <= 28; D++)

                                if (D != C && D != B && D != L1 && D != LastLetter)
                                    if (L4 == 0 || L4 == D)
                                    {
                                        int[] temp = new int[4]; temp[0] = L1; temp[1] = B; temp[2] = C; temp[3] = D;
                                        result.Add(temp);
                                    }
                        }
                }
            return result;
        }
        

        public static void Initialize()
        {
            AllPossibleSummations = new List<int>();
            int[] TempAllPossibleSummations = new int[85];

            AllB4B4TablesGroupedBySum = new ArrayList[85];
            for (int i = 0; i < 85; i++)
            {
                TempAllPossibleSummations[i] = 0;
                //AllB4B4TablesGroupedBySum[i] = new ArrayList();

            }
            AllB4B4Tables = new Boddooh4By4Table[28, 28, 28, 28];
            int[,] ALLC = new int[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    ALLC[i, j] = 0;

            for (int A = 1; A <= 28; A++)
            {
                for (int B = 1; B <= 28; B++)
                    if (A!=B)
                    {
                        for (int C = 1; C <= 28; C++)
                            if (C!=B && C!=A)
                            {
                                for (int D = 1; D <= 28; D++)
                                if (D!=C && D!=B && D!=A)
                                {
                                    Boddooh4By4Table B4B4T = new Boddooh4By4Table(A, B, C, D);
                                    
                                    int Sum = B4B4T.SummationOfItems;
                                    AllB4B4Tables[A - 1, B - 1, C - 1, D - 1] = B4B4T;
                                    int index = (Sum - 64) / 4;
                                    TempAllPossibleSummations[index] = 1;
                                    //AllB4B4TablesGroupedBySum[index].Add(B4B4T);

                                }
                            }
                    }
            }
            for (int i = 0; i < 85; i++)
            {
                if (TempAllPossibleSummations[i] == 1)
                    AllPossibleSummations.Add(64 + i * 4);
                //AllB4B4TablesGroupedBySum[i] = new ArrayList();

            }

            for (int i = 64; i <= 400; i++)
            {
                int BB = Get_B(i);
                int DD = Get_D(i);
                ALLC[BB, DD]++;
            }
            //for (int i = 1; i < 10; i++)
            //    for (int j = 1; j < 9; j++) if (j != 5)
            //        {
            //           // if (ALLC[i, j] != 0)
            //            //MessageBox.Show(i.ToString() + ", " + j.ToString() + ":        " + ALLC[i, j].ToString());
            //        }

            //MessageBox.Show("Done");
        }

        public static bool CheckSummationOfRowsAndColumns(Boddooh4By4Table[] B4B4Ts)
        {
            int SummationOfColumn1 = 0;
            int SummationOfColumn2 = 0;
            int SummationOfColumn3 = 0;
            int SummationOfColumn4 = 0;
            int SummationOfRow1 = 0;
            int SummationOfRow2 = 0;
            int SummationOfRow3 = 0;
            int SummationOfRow4 = 0;

            for (int i = 0; i < B4B4Ts.Length; i++)
            {
                SummationOfColumn1 += B4B4Ts[i].SummationOfColumn1;
                SummationOfColumn2 += B4B4Ts[i].SummationOfColumn2;
                SummationOfColumn3 += B4B4Ts[i].SummationOfColumn3;
                SummationOfColumn4 += B4B4Ts[i].SummationOfColumn4;
                SummationOfRow1 += B4B4Ts[i].SummationOfRow1;
                SummationOfRow2 += B4B4Ts[i].SummationOfRow2;
                SummationOfRow3 += B4B4Ts[i].SummationOfRow3;
                SummationOfRow4 += B4B4Ts[i].SummationOfRow4;
            }
            int Column1Reminder = SummationOfColumn1 % BoddoohNumbers.TwentyEight;
            int Column2Reminder = SummationOfColumn2 % BoddoohNumbers.TwentyEight;
            int Column3Reminder = SummationOfColumn3 % BoddoohNumbers.TwentyEight;
            int Column4Reminder = SummationOfColumn4 % BoddoohNumbers.TwentyEight;
            int Row1Reminder = SummationOfRow1 % BoddoohNumbers.TwentyEight;
            int Row2Reminder = SummationOfRow2 % BoddoohNumbers.TwentyEight;
            int Row3Reminder = SummationOfRow3 % BoddoohNumbers.TwentyEight;
            int Row4Reminder = SummationOfRow4 % BoddoohNumbers.TwentyEight;
            int SummationForAll = Column1Reminder + Column2Reminder + Column3Reminder + Column4Reminder;

            if (SummationForAll % BoddoohNumbers.TwentyEight != 0)
                return false;

            if (Column4Reminder % BoddoohNumbers.TwentyEight != 0)
                return false;

            if (Column1Reminder % BoddoohNumbers.TwentyEight == 20 || Column1Reminder % BoddoohNumbers.TwentyEight == 8)
                return true;

            return false;

        }


    }
    public class IntSubarrayForBAndD//ok
    {
        public static int[,] Valid_B_TuplesMapping = new int[10, 10];
        public static int[,] Valid_D_TuplesMapping = new int[10, 10];
        public static int[, , ,] Valid_BAndD_TuplesMapping = new int[10, 10, 10, 10];

        public static List<int[]>[] IntSubarraysForB2 = new List<int[]>[28];
        public static List<int[]>[] IntSubarraysForB3 = new List<int[]>[28];
        public static List<int[]>[] IntSubarraysForD2 = new List<int[]>[28];
        public static List<int[]>[] IntSubarraysForD3 = new List<int[]>[28];


        public static void Initialize_BAndD_TuplesMapping()//ok
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Valid_B_TuplesMapping[i, j] = 0;
                    Valid_D_TuplesMapping[i, j] = 0;
                    for (int ii = 0; ii < 10; ii++)
                        for (int jj = 0; jj < 10; jj++)
                            Valid_BAndD_TuplesMapping[i, j, ii, jj] = 0;
                }
            for (int i = 0; i < InputManagement.AllPossiblePentuplesOfAllLetters.Count; ++i)
            {
                int[] APentuple = InputManagement.AllPossiblePentuplesOfAllLetters[i];
                int B4B4T0 = AllBoddooh4By4Tables.GetB4B4Table(APentuple[0], APentuple[1], APentuple[2], APentuple[3]).SummationOfItems;
                int B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(APentuple[1], APentuple[2], APentuple[3], APentuple[4]).SummationOfItems;
                int D_Value0 = AllBoddooh4By4Tables.Get_D(B4B4T0);
                int B_Value0 = AllBoddooh4By4Tables.Get_B(B4B4T0);
                int D_Value1 = AllBoddooh4By4Tables.Get_D(B4B4T1);
                int B_Value1 = AllBoddooh4By4Tables.Get_B(B4B4T1);
                Valid_B_TuplesMapping[B_Value0, B_Value1] = 1;
                Valid_D_TuplesMapping[D_Value0, D_Value1] = 1;
                Valid_BAndD_TuplesMapping[B_Value0, B_Value1, D_Value0, D_Value1] = 1;
            }
        }

        public static void Initialize()//ok
        {
            Initialize_BAndD_TuplesMapping();

            IntSubarraysForB2 = new List<int[]>[28];
            IntSubarraysForB3 = new List<int[]>[28];
            IntSubarraysForD2 = new List<int[]>[28];
            IntSubarraysForD3 = new List<int[]>[28];
            for (int i = 0; i <= 27; i++)
            {
                IntSubarraysForB2[i] = IntSubarraysForSum(i, false, 2);
                IntSubarraysForB3[i] = IntSubarraysForSum(i, false, 3);
                IntSubarraysForD2[i] = IntSubarraysForSum(i, true, 2);
                IntSubarraysForD3[i] = IntSubarraysForSum(i, true, 3);
            }
        }

        public static List<int[]> GetIntSubarraysForB(int Sum, int length)//ok
        {
            if (length == 2)
                return GetIntSubarraysForB_2(Sum);
            else
                return GetIntSubarraysForB_3(Sum);
        }
        public static List<int[]> GetIntSubarraysForB_2(int Sum)//ok
        {
            //List<int[]> result = new List<int[]>();
            return IntSubarraysForB2[Sum];
        }
        public static List<int[]> GetIntSubarraysForB_3(int Sum)//ok
        {
            //List<int[]> result = new List<int[]>();
            return IntSubarraysForB3[Sum];
        }
        public static List<int[]> GetIntSubarraysForD_2(int Sum)//ok
        {
            //List<int[]> result = new List<int[]>();
            return IntSubarraysForD2[Sum];
        }
        public static List<int[]> GetIntSubarraysForD_3(int Sum)//ok
        {
            //List<int[]> result = new List<int[]>();
            return IntSubarraysForD3[Sum];
        }
        public static List<int[]> GetIntSubarraysForD(int Sum, int length)//ok
        {
            if (length == 2)
                return GetIntSubarraysForD_2(Sum);
            else
                return GetIntSubarraysForD_3(Sum);
        }
        public static List<int[]> StartingWith(List<int[]> IntSubarrays, int Start)//ok
        {
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < IntSubarrays.Count; i++)
            {
                int[] IntSubarray = IntSubarrays[i];
                if (IntSubarray[0] == Start)
                    result.Add(IntSubarray);
            }
            return result;
        }     
        public static List<int[]> IntSubarraysForSum(int Sum, bool ForD, int length)//ok
        {
            if (length == 2)
                return IntSubarraysForSum_2(Sum, ForD);
            else
                return IntSubarraysForSum_3(Sum, ForD);

        }
        public static List<int[]> IntSubarraysForSum_2(int Sum, bool ForD)//ok
        {
            List<int[]> result = new List<int[]>();
            for (int i = 1; i <= 9; i++) for (int j = 1; j <= 9; j++)
                {
                    int S = i + j;
                    if (!ForD || (i != 5 && i != 9 && j != 5 && j != 9))
                    if (Sum == S)                    
                    {
                        if (ForD)
                        {
                            if (Valid_D_TuplesMapping[i, j] == 1)                            
                            {
                                int[] IntSubarray = new int[] { i, j };
                                result.Add(IntSubarray);
                            }
                        }
                        else
                        {
                            if (Valid_B_TuplesMapping[i, j] == 1)
                            {
                                int[] IntSubarray = new int[] { i, j };
                                result.Add(IntSubarray);
                            }
                        }
                    }
                }

            return result;
        }
        public static List<int[]> IntSubarraysForSum_3(int Sum, bool ForD)//ok
        {
            List<int[]> result = new List<int[]>();
            for (int i = 1; i <= 9; i++) for (int j = 1; j <= 9; j++) for (int k = 1; k <= 9; k++)
            {
                int S = i + j + k;
                if (!ForD || (i != 5 && i != 9 && j != 5 && j != 9 && k != 5 && k != 9))
                if (Sum == S)
                {
                    if (ForD)
                    {
                        if (Valid_D_TuplesMapping[i, j] == 1 && Valid_D_TuplesMapping[j, k] == 1)
                        {
                                int[] IntSubarray = new int[] { i, j, k };
                                result.Add(IntSubarray);

                            }
                    }
                    else
                    {
                        if (Valid_B_TuplesMapping[i, j] == 1 && Valid_B_TuplesMapping[j, k] == 1)
                        {
                            int[] IntSubarray = new int[] { i, j, k };
                            result.Add(IntSubarray);
                        }

                    }

                }
            }
            return result;
        }

    }

    public class IntSet
    {
        public List<int> Members;


        public  IntSet()
        {
            Members = new List<int>();
        }

        public int BinarySearch(int item)
        {
            int index = -1;
            if (Members.Count>0)
            {
                int L = 0;
                int R = Members.Count - 1;
                while (L <= R)
                {
                    int M = (L + R) / 2;
                    if (Members[M] == item)
                        return M;
                    if (item > Members[M])
                        L = M + 1;
                    if (item < Members[M])
                        R = M - 1;
                }
            }
            
            return index;
        }


        public bool Contains(int item)
        {
            int index = BinarySearch(item);
            return (index>=0);
        }

        public IntSet Clone()
        {
            IntSet result = new IntSet();
            for (int i = 0; i < Members.Count; i++)
                result.Add(Members[i]);
            return result;
        }

        public void Add(int item)
        {
            if (!Contains(item))
            {
                int index = 0;
                while (index < Members.Count && item > Members[index]) index++;
                Members.Insert(index, item);
            }
        }
        public void Add(int item1, int item2)
        {
            Add(item1);
            Add(item2);
        }
        public void Add(int item1, int item2, int item3)
        {
            Add(item1, item2);
            Add(item3);
        }
        public void Add(int item1, int item2, int item3, int item4)
        {
            Add(item1, item2, item3);
            Add(item4);
        }
        public void Add(int item1, int item2, int item3, int item4, int item5)
        {
            Add(item1, item2, item3, item4);
            Add(item5);
        }

        public void Remove(int item1, int item2)
        {
            Remove(item1);
            Remove(item2);
        }
        public void Remove(int item1, int item2, int item3)
        {
            Remove(item1, item2);
            Remove(item3);
        }
        public void Remove(int item1, int item2, int item3, int item4)
        {
            Remove(item1, item2, item3);
            Remove(item4);
        }
        public void Remove(int item1, int item2, int item3, int item4, int item5)
        {
            Remove(item1, item2, item3, item4);
            Remove(item5);
        }

        public void Remove(int item)
        {
            int index = BinarySearch(item);
            if (index>=0)
            {
                Members.RemoveAt(index);
            }
        }

        
    }

    public class PatternsForBAndDInputManagment//ok
    {
        public static void InitializePatterns()///ok
        {
            int[] Pattern;
            Pattern = new int[] { 14, 15, 19, 9, 15, 14, 19, 9 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 19, 9 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 9, 19, 15, 14, 9, 19 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 9, 19 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 15, 14 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 9, 19, 15, 14, 19, 9 };
            B_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 14, 15, 19, 9, 15, 14, 9, 19 };
            B_PatternsUpperHalf.Add(Pattern);


            Pattern = new int[] { 19, 9, 15, 14, 9, 19, 15, 14 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 15, 14 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 14, 15, 9, 19, 14, 15 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 14, 15 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 9, 19 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 14, 15, 9, 19, 15, 14 };
            B_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 19, 9, 15, 14, 9, 19, 14, 15 };
            B_PatternsLowerHalf.Add(Pattern);


            Pattern = new int[] { 12, 20, 8, 12, 20, 12, 8, 12 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 8, 12 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 12, 8, 20, 12, 12, 8 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 12, 8 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 20, 12 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 12, 8, 20, 12, 8, 12 };
            D_PatternsUpperHalf.Add(Pattern);
            Pattern = new int[] { 12, 20, 8, 12, 20, 12, 12, 8 };
            D_PatternsUpperHalf.Add(Pattern);


            Pattern = new int[] { 8, 12, 20, 12, 12, 8, 20, 12 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 20, 12 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 12, 20, 12, 8, 12, 20 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 12, 20 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 12, 8 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 12, 20, 12, 8, 20, 12 };
            D_PatternsLowerHalf.Add(Pattern);
            Pattern = new int[] { 8, 12, 20, 12, 12, 8, 12, 20 };
            D_PatternsLowerHalf.Add(Pattern);
        }
        public static void Initialize()//ok
        {
            InitializePatterns();            
            B_Patterns9MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD(9, true, false);
            D_Patterns9MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD(9, true, true);
            B_Patterns9MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD(9, false, false);
            D_Patterns9MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD(9, false, true);

            B_Patterns11 = GenerateAllPatternsForColumnsBAndD( 11, false, false);
            D_Patterns11 = GenerateAllPatternsForColumnsBAndD( 11, false, true);

            B_Patterns12 = GenerateAllPatternsForColumnsBAndD( 12, false, false);
            D_Patterns12 = GenerateAllPatternsForColumnsBAndD( 12, false, true);

            B_Patterns14MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 14, true, false);
            D_Patterns14MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 14, true, true);
            B_Patterns14MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 14, false, false);
            D_Patterns14MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 14, false, true);

            B_Patterns18 = GenerateAllPatternsForColumnsBAndD( 18, false, false);
            D_Patterns18 = GenerateAllPatternsForColumnsBAndD( 18, false, true);

            B_Patterns20MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 20, true, false);
            D_Patterns20MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 20, true, true);
            B_Patterns20MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 20, false, false);
            D_Patterns20MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 20, false, true);

            B_Patterns26MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 26, true, false);
            D_Patterns26MiddleElementFromUpperHalf = GenerateAllPatternsForColumnsBAndD( 26, true, true);
            B_Patterns26MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 26, false, false);
            D_Patterns26MiddleElementFromLowerHalf = GenerateAllPatternsForColumnsBAndD( 26, false, true);

            B_Patterns28 = GenerateAllPatternsForColumnsBAndD( 28, false, false);
            D_Patterns28 = GenerateAllPatternsForColumnsBAndD( 28, false, true);
        } 
        public static List<int[]> B_Patterns9MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> B_Patterns9MiddleElementFromLowerHalf = new List<int[]>();
        public static List<int[]> D_Patterns9MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> D_Patterns9MiddleElementFromLowerHalf = new List<int[]>();

        public static List<int[]> B_Patterns11 = new List<int[]>();
        public static List<int[]> D_Patterns11 = new List<int[]>();

        public static List<int[]> B_Patterns12 = new List<int[]>();
        public static List<int[]> D_Patterns12 = new List<int[]>();

        public static List<int[]> B_Patterns14MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> B_Patterns14MiddleElementFromLowerHalf = new List<int[]>();
        public static List<int[]> D_Patterns14MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> D_Patterns14MiddleElementFromLowerHalf = new List<int[]>();

        public static List<int[]> B_Patterns18 = new List<int[]>();
        public static List<int[]> D_Patterns18 = new List<int[]>();

        public static List<int[]> B_Patterns20MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> B_Patterns20MiddleElementFromLowerHalf = new List<int[]>();
        public static List<int[]> D_Patterns20MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> D_Patterns20MiddleElementFromLowerHalf = new List<int[]>();

        public static List<int[]> B_Patterns26MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> B_Patterns26MiddleElementFromLowerHalf = new List<int[]>();
        public static List<int[]> D_Patterns26MiddleElementFromUpperHalf = new List<int[]>();
        public static List<int[]> D_Patterns26MiddleElementFromLowerHalf = new List<int[]>();

        public static List<int[]> B_Patterns28 = new List<int[]>();
        public static List<int[]> D_Patterns28 = new List<int[]>();


       // public static List<int[]> AllB_Patterns = new List<int[]>();
        public static List<int[]> B_PatternsUpperHalf = new List<int[]>();
        public static List<int[]> B_PatternsLowerHalf = new List<int[]>();
        public static List<int[]> D_PatternsUpperHalf = new List<int[]>();
        public static List<int[]> D_PatternsLowerHalf = new List<int[]>();


        public static List<int[]> GenerateAllPatternsForColumnsBAndD(int Length, bool MiddleElementFromUpperHalf, bool ForD)//ok
        {
            int Count = Length / 3;
            if (Length % 3 != 0)
                Length++;
            int UpperPartLength = Count / 2;
            int LowerPartLength = Count / 2;
            if (Count % 2 == 1)
            {
                if (MiddleElementFromUpperHalf)
                    UpperPartLength++;
                else
                    LowerPartLength++;
            }
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < 8; i++)
            {
                List<int[]> ListPatternForColumnBAndDUpperHalf = new List<int[]>();
                List<int[]> ListPatternForColumnBAndDLowerHalf = new List<int[]>();

                if (!ForD)
                {
                    for (int StartIndex = 0; StartIndex < B_PatternsUpperHalf[i].Length; StartIndex++)
                    {
                        ListPatternForColumnBAndDUpperHalf.Add(MiscMethods.GenerateArrayBasedOnAPattern(UpperPartLength, B_PatternsUpperHalf[i], StartIndex));
                    }
                    for (int StartIndex = 0; StartIndex < B_PatternsUpperHalf[i].Length; StartIndex++)
                    {
                        ListPatternForColumnBAndDLowerHalf.Add(MiscMethods.GenerateArrayBasedOnAPattern(LowerPartLength, B_PatternsLowerHalf[i], StartIndex));
                    }
                }
                else
                {
                    for (int StartIndex = 0; StartIndex < D_PatternsUpperHalf[i].Length; StartIndex++)
                    {
                        ListPatternForColumnBAndDUpperHalf.Add(MiscMethods.GenerateArrayBasedOnAPattern(UpperPartLength, D_PatternsUpperHalf[i], StartIndex));
                    }
                    for (int StartIndex = 0; StartIndex < D_PatternsLowerHalf[i].Length; StartIndex++)
                    {
                        ListPatternForColumnBAndDLowerHalf.Add(MiscMethods.GenerateArrayBasedOnAPattern(LowerPartLength, D_PatternsLowerHalf[i], StartIndex));
                    }
                }

                for (int ii = 0; ii < ListPatternForColumnBAndDUpperHalf.Count; ii++)
                {
                    int[] PatternForColumnBAndDUpperHalf = ListPatternForColumnBAndDUpperHalf[ii];
                    for (int jj = 0; jj < ListPatternForColumnBAndDLowerHalf.Count; jj++)
                    {
                        int[] PatternForColumnBAndDLowerHalf = ListPatternForColumnBAndDLowerHalf[jj];
                        int[] PatternForColumnBAndD = MiscMethods.JoinArrays(PatternForColumnBAndDUpperHalf, MiscMethods.InverseArray(PatternForColumnBAndDLowerHalf));
                        if (!ListOfArraysContainsAnArray(result, PatternForColumnBAndD))
                        {
                            result.Add(PatternForColumnBAndD);
                        }
                    }
                }                                
            }
            return result;
        }

        public static bool ListOfArraysContainsAnArray(List<int[]> ListOfArrays, int[] Array)///ok
        {
            for (int i = 0; i < ListOfArrays.Count; i++)
            {
                if (MiscMethods.ArraysAreTheSame(ListOfArrays[i], Array))
                    return true;
            }
            return false;
        }

        public static List<int[]> GetB_Options(int Length, int A, int B, int C, int D, int[] PatternForColumnB, IntSet RemainingLetters, List<int[]> AllPossibleTuplesOfRemainingLetters)//ok
        {
            List<int[]> result = new List<int[]>();
            Boddooh4By4Table FirstB4B4Table = AllBoddooh4By4Tables.GetB4B4Table(A, B, C, D);
            int LastLetter = InputManagement.GetLastLetter(A);
            Boddooh4By4Table LastB4B4Table = AllBoddooh4By4Tables.GetB4B4Table(LastLetter, A, B, C);

            int[] B_Array = new int[Length];
            B_Array[0] = AllBoddooh4By4Tables.Get_B(FirstB4B4Table);
            B_Array[Length - 1] = AllBoddooh4By4Tables.Get_B(LastB4B4Table);

            int ULTriplesCount = (Length / 3) / 2;
            int MiddlePartStartIndex = ULTriplesCount;
            int MiddlePartLenght = Length % 6;
            List<int[]>[] B_OptionsForUpperTriples = new List<int[]>[ULTriplesCount];
            List<int[]>[] B_OptionsForLowerTriples = new List<int[]>[ULTriplesCount];
            List<ArrayPair>[] B_OptionsForULTriples = new List<ArrayPair>[ULTriplesCount];

            List<int[]> B_MiddlePart = new List<int[]>();
            int[] B_OptionsCount = new int[ULTriplesCount];
            int OptionsCount = 1;
            for (int index = 0; index < ULTriplesCount && OptionsCount > 0; index++)
            {
                if (index == 0)
                {
                    B_OptionsForUpperTriples[index] = new List<int[]>();
                    B_OptionsForLowerTriples[index] = new List<int[]>();
                    for (int i = 0; i < AllPossibleTuplesOfRemainingLetters.Count; i++)
                    {
                        int[] ATuple = AllPossibleTuplesOfRemainingLetters[i];
                        Boddooh4By4Table B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(B, C, D, ATuple[0]);
                        Boddooh4By4Table B4B4T2 = AllBoddooh4By4Tables.GetB4B4Table(C, D, ATuple[0], ATuple[1]);
                        
                        int Temp0 = AllBoddooh4By4Tables.Get_B(FirstB4B4Table);
                        int Temp1 = AllBoddooh4By4Tables.Get_B(B4B4T1);
                        int Temp2 = AllBoddooh4By4Tables.Get_B(B4B4T2);
                        if ((Temp0 + Temp1 + Temp2) == PatternForColumnB[0])
                        {
                            int[] TempOption = new int[] { Temp0, Temp1, Temp2 };
                            if (!PatternsForBAndDInputManagment.ListOfArraysContainsAnArray(B_OptionsForUpperTriples[index], TempOption))
                                B_OptionsForUpperTriples[index].Add(TempOption);
                        }
                        B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(ATuple[0], LastLetter, A, B);
                        B4B4T2 = AllBoddooh4By4Tables.GetB4B4Table(ATuple[1], ATuple[0], LastLetter, A);
                        Temp0 = AllBoddooh4By4Tables.Get_B(LastB4B4Table);
                         Temp1 = AllBoddooh4By4Tables.Get_B(B4B4T1);
                         Temp2 = AllBoddooh4By4Tables.Get_B(B4B4T2);
                         if ((Temp0 + Temp1 + Temp2) == PatternForColumnB[PatternForColumnB.Length-1])
                         {
                             int[] TempOption = new int[] { Temp2, Temp1, Temp0 };
                             if (!PatternsForBAndDInputManagment.ListOfArraysContainsAnArray(B_OptionsForLowerTriples[index], TempOption))
                                 B_OptionsForLowerTriples[index].Add(TempOption);
                         }
                    }

                    //B_OptionsForUpperTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[index], 3);
                    //B_OptionsForLowerTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[PatternForColumnB.Length - 1 - index], 3);

                    //B_OptionsForUpperTriples[index] = IntSubarrayForBAndD.StartingWith(B_OptionsForUpperTriples[index], B_Array[0]);
                    //B_OptionsForLowerTriples[index] = IntSubarrayForBAndD.StartingWith(B_OptionsForLowerTriples[index], B_Array[Length - 1]);
                }
                else
                {
                    B_OptionsForUpperTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[index], 3);
                    B_OptionsForLowerTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[PatternForColumnB.Length - 1 - index], 3);
                }
                B_OptionsForULTriples[index] = new List<ArrayPair>();
                for (int i = 0; i < B_OptionsForUpperTriples[index].Count; i++)
                {
                    int[] B_AnOptionForBU = B_OptionsForUpperTriples[index][i];
                    B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, B_AnOptionForBU, 3 * index);
                    for (int j = 0; j < B_OptionsForLowerTriples[index].Count; j++)
                    {
                        int[] B_AnOptionForBL = B_OptionsForLowerTriples[index][j];
                        B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, (B_AnOptionForBL), Length - 1 - (3 * index + 2));
                        //if (CheckB_ArrayBasedOnItsRequirements1(B_Array, 3 * index + 0, 3 * index + 2))//, FoldAndSummationEq9ArrayForColumnB))
                        //{
                            B_OptionsForULTriples[index].Add(new ArrayPair(B_AnOptionForBU, B_AnOptionForBL));
                        //}
                    }
                }
                OptionsCount *= (B_OptionsForULTriples[index].Count);
                B_OptionsCount[index] = B_OptionsForULTriples[index].Count - 1;
            }

            if (OptionsCount > 0)
            {
                if (MiddlePartLenght > 0)
                {
                    List<int[]> MiddleOptions = new List<int[]>();
                    if (MiddlePartLenght == 2)
                    {                        
                        MiddleOptions = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[MiddlePartStartIndex], 2);
                    }
                    if (MiddlePartLenght == 3)
                    {
                        MiddleOptions = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[MiddlePartStartIndex], 3);
                    }
                    if (MiddlePartLenght > 3)
                    {
                        List<int[]> MiddleOptionsU = new List<int[]>();
                        if (MiddlePartLenght==4)
                            MiddleOptionsU = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[MiddlePartStartIndex], 2);
                        else
                            MiddleOptionsU = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[MiddlePartStartIndex], 3);
                        List<int[]> MiddleOptionsL = IntSubarrayForBAndD.GetIntSubarraysForB(PatternForColumnB[MiddlePartStartIndex+1], 2);
                        for (int i=0;i<MiddleOptionsU.Count;i++)
                            for (int j=0;j<MiddleOptionsL.Count;j++)
                            {
                                MiddleOptions.Add(MiscMethods.JoinArrays(MiddleOptionsU[i], MiddleOptionsL[j]));
                            }
                    }
                    for (int i=0;i<MiddleOptions.Count;i++)
                    {
                        B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, MiddleOptions[i], MiddlePartStartIndex);
                       // if (CheckB_ArrayBasedOnItsRequirements1(B_Array, MiddlePartStartIndex, MiddlePartStartIndex+MiddlePartLenght-1))//, FoldAndSummationEq9ArrayForColumnB))
                        //{
                            B_MiddlePart.Add(MiddleOptions[i]);
                        //}                        
                    }                                        
                }

                Counter B_OptionsCounter = new Counter(B_OptionsCount.Length, 0, B_OptionsCount);

                for (B_OptionsCounter.Restart(); !B_OptionsCounter.Done;B_OptionsCounter.Next())
                {
                    for (int index = 0; index < B_OptionsCount.Length; index++)
                    {
                        int[] B_AnOptionForBU = B_OptionsForULTriples[index][B_OptionsCounter.CurrentValues[index]].FirstArray;
                        int[] B_AnOptionForBL = B_OptionsForULTriples[index][B_OptionsCounter.CurrentValues[index]].SecondArray;
                        B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, B_AnOptionForBU, 3 * index);
                        B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, (B_AnOptionForBL), Length - 1 - (3 * index + 2));
                    }
                    //if (B_Array[0] == 5 && B_Array[1] == 8 && B_Array[2] == 1 && B_Array[3] == 6 && B_Array[4] == 4 && B_Array[5] == 5
                    //     && B_Array[6] == 3 && B_Array[7] == 5 && B_Array[8] == 1 && B_Array[9] == 4 && B_Array[10] == 7 && B_Array[11] == 8)
                    //    MessageBox.Show("");
                    if (MiddlePartLenght > 0)
                    {
                        for (int i = 0; i < B_MiddlePart.Count; i++)
                        {
                            B_Array = MiscMethods.CopySubarrayIntoArray(B_Array, B_MiddlePart[i], MiddlePartStartIndex);
                            if (IsAValidBColumn(B_Array) && CheckB_ArrayBasedOnItsRequirements2(B_Array))
                            {
                                //if (CheckB_ArrayBasedOnItsRequirements1(B_Array))
                                result.Add(MiscMethods.CopyArray(B_Array));
                            }
                        }
                    }
                    else
                    {
                        if (IsAValidBColumn(B_Array) && CheckB_ArrayBasedOnItsRequirements2(B_Array))
                        {
                            //if (CheckB_ArrayBasedOnItsRequirements1(B_Array))
                            result.Add(MiscMethods.CopyArray(B_Array));
                        }
                    }

                }
            }
            return result;
        }

        public static List<int[]> GetD_Options(int Length, int A, int B, int C, int D, int[] PatternForColumnD, IntSet RemainingLetters, List<int[]> AllPossibleTuplesOfRemainingLetters)//ok
        {
            List<int[]> result = new List<int[]>();

            //IntSet LettersSet = new IntSet();
            //for (int i = 1; i <= 28; i++)
            //    LettersSet.Add(i);
            //LettersSet.Remove(A); LettersSet.Remove(B); LettersSet.Remove(C); LettersSet.Remove(D);

            Boddooh4By4Table FirstB4B4Table = AllBoddooh4By4Tables.GetB4B4Table(A, B, C, D);
            int LastLetter = InputManagement.GetLastLetter(A);
            Boddooh4By4Table LastB4B4Table = AllBoddooh4By4Tables.GetB4B4Table(LastLetter, A, B, C);

            int[] D_Array = new int[Length];
            D_Array[0] = AllBoddooh4By4Tables.Get_D(FirstB4B4Table);
            D_Array[Length - 1] = AllBoddooh4By4Tables.Get_D(LastB4B4Table);

            int ULTriplesCount = (Length / 3) / 2;
            int MiddlePartStartIndex = ULTriplesCount ;
            int MiddlePartLenght = Length % 6;
            List<int[]>[] D_OptionsForUpperTriples = new List<int[]>[ULTriplesCount];
            List<int[]>[] D_OptionsForLowerTriples = new List<int[]>[ULTriplesCount];
            List<ArrayPair>[] D_OptionsForULTriples = new List<ArrayPair>[ULTriplesCount];

            List<int[]> D_MiddlePart = new List<int[]>();
            int[] D_OptionsCount = new int[ULTriplesCount];
            int OptionsCount = 1;
            //IntSet RemainingLetters = InputManagment.GetRemainingLetters(A, B, C, D);
            //List<int[]> AllPossibleTuples = InputManagment.GetAllPermutations(2, RemainingLetters);
            for (int index = 0; index < ULTriplesCount && OptionsCount>0; index++)
            {
                if (index == 0)
                {
                    D_OptionsForUpperTriples[index] = new List<int[]>();
                    D_OptionsForLowerTriples[index] = new List<int[]>();
                    for (int i = 0; i < AllPossibleTuplesOfRemainingLetters.Count; i++)
                    {
                        int[] ATuple = AllPossibleTuplesOfRemainingLetters[i];
                        Boddooh4By4Table B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(B, C, D, ATuple[0]);
                        Boddooh4By4Table B4B4T2 = AllBoddooh4By4Tables.GetB4B4Table(C, D, ATuple[0], ATuple[1]);

                        //if (ATuple[0] == 1 && ATuple[0]==12)
                        //{
                        //    int iii =23;
                        //}
                        int Temp0 = AllBoddooh4By4Tables.Get_D(FirstB4B4Table);
                        int Temp1 = AllBoddooh4By4Tables.Get_D(B4B4T1);
                        int Temp2 = AllBoddooh4By4Tables.Get_D(B4B4T2);
                        if ((Temp0 + Temp1 + Temp2) == PatternForColumnD[0])
                        {
                            int[] TempOption = new int[] { Temp0, Temp1, Temp2 };
                            if (!PatternsForBAndDInputManagment.ListOfArraysContainsAnArray(D_OptionsForUpperTriples[index], TempOption))
                                D_OptionsForUpperTriples[index].Add(TempOption);
                        }

                        B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(ATuple[0], LastLetter, A, B);
                        B4B4T2 = AllBoddooh4By4Tables.GetB4B4Table(ATuple[1], ATuple[0], LastLetter, A);
                        Temp0 = AllBoddooh4By4Tables.Get_D(LastB4B4Table);
                        Temp1 = AllBoddooh4By4Tables.Get_D(B4B4T1);
                        Temp2 = AllBoddooh4By4Tables.Get_D(B4B4T2);
                        if ((Temp0 + Temp1 + Temp2) == PatternForColumnD[PatternForColumnD.Length - 1])
                        {
                            int[] TempOption = new int[] { Temp2, Temp1, Temp0 };
                            if (!PatternsForBAndDInputManagment.ListOfArraysContainsAnArray(D_OptionsForLowerTriples[index], TempOption))
                                D_OptionsForLowerTriples[index].Add(TempOption);
                        }
                    }
                    //D_OptionsForUpperTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[index], 3);
                    //D_OptionsForLowerTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[PatternForColumnD.Length - 1 - index], 3);

                    //D_OptionsForUpperTriples[index] = IntSubarrayForBAndD.StartingWith(D_OptionsForUpperTriples[index], D_Array[0]);
                    //D_OptionsForLowerTriples[index] = IntSubarrayForBAndD.StartingWith(D_OptionsForLowerTriples[index], D_Array[Length - 1]);
                }
                else
                {
                    D_OptionsForUpperTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[index], 3);
                    D_OptionsForLowerTriples[index] = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[PatternForColumnD.Length - 1 - index], 3);
                }

                D_OptionsForULTriples[index] = new List<ArrayPair>();
                for (int i = 0; i < D_OptionsForUpperTriples[index].Count; i++)
                {
                    int[] D_AnOptionForDU = D_OptionsForUpperTriples[index][i];
                    D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, D_AnOptionForDU, 3 * index);
                    for (int j = 0; j < D_OptionsForLowerTriples[index].Count; j++)
                    {
                        int[] D_AnOptionForDL = D_OptionsForLowerTriples[index][j];
                        D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, (D_AnOptionForDL), Length - 1 - (3 * index + 2));
                        if (CheckD_ArrayBasedOnItsRequirements1(D_Array, 3 * index + 0, 3 * index + 2))
                        {
                            D_OptionsForULTriples[index].Add(new ArrayPair(D_AnOptionForDU, D_AnOptionForDL));
                        }
                    }
                }
                D_OptionsCount[index] = D_OptionsForULTriples[index].Count - 1;
                OptionsCount *= (D_OptionsForULTriples[index].Count);
                //MessageBox.Show(D_OptionsForULTriples[index].Count.ToString());
            }
            if (OptionsCount > 0)
            {
                if (MiddlePartLenght > 0)
                {
                    List<int[]> MiddleOptions = new List<int[]>();
                    if (MiddlePartLenght == 2)
                    {
                        MiddleOptions = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[MiddlePartStartIndex], 2);
                    }
                    if (MiddlePartLenght == 3)
                    {
                        MiddleOptions = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[MiddlePartStartIndex], 3);
                    }
                    if (MiddlePartLenght > 3)
                    {
                        List<int[]> MiddleOptionsU = new List<int[]>();
                        if (MiddlePartLenght == 4)
                            MiddleOptionsU = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[MiddlePartStartIndex], 2);
                        else
                            MiddleOptionsU = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[MiddlePartStartIndex], 3);
                        List<int[]> MiddleOptionsL = IntSubarrayForBAndD.GetIntSubarraysForD(PatternForColumnD[MiddlePartStartIndex + 1], 2);
                        for (int i = 0; i < MiddleOptionsU.Count; i++)
                            for (int j = 0; j < MiddleOptionsL.Count; j++)
                            {
                                MiddleOptions.Add(MiscMethods.JoinArrays(MiddleOptionsU[i], MiddleOptionsL[j]));
                            }
                    }
                    for (int i = 0; i < MiddleOptions.Count; i++)
                    {
                        D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, MiddleOptions[i], MiddlePartStartIndex);
                        if (CheckD_ArrayBasedOnItsRequirements1(D_Array, MiddlePartStartIndex, MiddlePartStartIndex + MiddlePartLenght - 1))
                        {
                            D_MiddlePart.Add(MiddleOptions[i]);
                        }
                    }
                }



                Counter D_OptionsCounter = new Counter(D_OptionsCount.Length, 0, D_OptionsCount);
                
                for (D_OptionsCounter.Restart();!D_OptionsCounter.Done;D_OptionsCounter.Next())
                {
                    for (int index = 0; index < D_OptionsCount.Length; index++)
                    {
                        int[] D_AnOptionForBU = D_OptionsForULTriples[index][D_OptionsCounter.CurrentValues[index]].FirstArray;
                        int[] D_AnOptionForBL = D_OptionsForULTriples[index][D_OptionsCounter.CurrentValues[index]].SecondArray;
                        D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, D_AnOptionForBU, 3 * index);
                        D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, D_AnOptionForBL, Length - 1 - (3 * index + 2));
                        //if (MiscMethods.ArraysAreTheSame(D_Array, new int[]{8,2,2,7,7,6,3,6,3,4,3,1}))
                        //{
                        //    int e=33;
                        //}
                    }

                    if (MiddlePartLenght > 0)
                    {
                        for (int i = 0; i < D_MiddlePart.Count; i++)
                        {
                            D_Array = MiscMethods.CopySubarrayIntoArray(D_Array, D_MiddlePart[i], MiddlePartStartIndex);
                            if (IsAValidDColumn(D_Array) && CheckD_ArrayBasedOnItsRequirements2(D_Array))
                            {
                                
                                result.Add(MiscMethods.CopyArray(D_Array));
                            }

                        }

                    }
                    else
                    {
                        if (IsAValidDColumn(D_Array) && CheckD_ArrayBasedOnItsRequirements2(D_Array))
                        {
                            result.Add(MiscMethods.CopyArray(D_Array));
                        }
                    }                    
                }
            }
            return result;

        }

        public static bool CheckB_ArrayBasedOnItsRequirements1(int[] B_Array, int FromIndex, int ToIndex)//ok
        {           
            int Length = ToIndex-FromIndex+1;
            int[] TempArray= new int [Length];
            for (int i = FromIndex; i <= ToIndex; i++)
            {
                int j = B_Array.Length - 1 - i;
                int Temp = MiscMethods.Equivalent1To9(B_Array[i] + B_Array[j]);
                if (i == j)
                    Temp = MiscMethods.Equivalent1To9(B_Array[i]);
                TempArray[i-FromIndex]=Temp;
            }
            int[] DistanceArray= new int [Length-1];
            for (int i = 0; i <Length-1; i++)
            {                
                int Temp = Math.Abs(TempArray[i] - TempArray[i+1]);
                if (Temp==7)Temp=2;
                if (Temp==8)Temp=1;
                if (Temp!=1 && Temp!=2)
                    return false;
                DistanceArray[i]=Temp;               
            }
            return MiscMethods.HasAPattern(DistanceArray, InputManagement.PatternForDistancesForBArrayRequirement);
        }

        public static bool CheckB_ArrayBasedOnItsRequirements1(int[] B_Array)//ok
        {
            int Length = B_Array.Length;
            int HalfLength = Length / 2;
            if (Length % 2 == 1)
                HalfLength++;
            int[] TempArray = new int[HalfLength];
            for (int i = 0; i < HalfLength; i++)
            {
                int j = Length - 1 - i;
                int Temp = MiscMethods.Equivalent1To9(B_Array[i] + B_Array[j]);
                if (i == j)
                    Temp = MiscMethods.Equivalent1To9(B_Array[i]);
                TempArray[i] = Temp;
            }
            int[] DistanceArray = new int[HalfLength - 1];
            for (int i = 0; i < HalfLength - 1; i++)
            {
                int Temp = Math.Abs(TempArray[i] - TempArray[i + 1]);
                if (Temp == 7) Temp = 2;
                if (Temp == 8) Temp = 1;
                if (Temp != 1 && Temp != 2)
                    return false;
                DistanceArray[i] = Temp;
            }
            return MiscMethods.HasAPattern(DistanceArray, InputManagement.PatternForDistancesForBArrayRequirement);
        }
        
        public static bool BAndD_ArraysCombinationIsOk(int[] B_Array, int[] D_Array)//ok
        {
            int Length = B_Array.Length;
            int HalfLength = Length / 2;
            if (Length % 2 == 1)
                HalfLength++;

            int[] FoldAndSummationEq9ArrayForColumnB = new int[HalfLength];
            int[] FoldAndSummationEq9ArrayForColumnD = new int[HalfLength];
            int[] Summation = new int[HalfLength];
            for (int i = 0; i < HalfLength; i++)
            {
                int j = Length - 1 - i;
                int Temp = MiscMethods.Equivalent1To9(B_Array[i] + B_Array[j]);
                if (i == j)
                    Temp = MiscMethods.Equivalent1To9(B_Array[i]);
                FoldAndSummationEq9ArrayForColumnB[i] = Temp;

                Temp = MiscMethods.Equivalent1To9(D_Array[i] + D_Array[j]);
                if (i == j)
                    Temp = MiscMethods.Equivalent1To9(D_Array[i]);
                FoldAndSummationEq9ArrayForColumnD[i] = Temp;

                Summation[i] = MiscMethods.Equivalent1To9(FoldAndSummationEq9ArrayForColumnB[i] + FoldAndSummationEq9ArrayForColumnD[i]);
            }

            int TriplesCount = HalfLength / 3;
            int Reminder = HalfLength % 3;

            bool WaitingFor8 = true;
            bool WaitingFor20 = true;
            for (int i = 0; i < TriplesCount; i++)
            {
                int S = Summation[3 * i] + Summation[3 * i+1] + Summation[3 * i+2];
                if (S == 8 && WaitingFor8)
                {
                    WaitingFor8 = false;
                    WaitingFor20 = true;
                }
                else
                {
                    if (S == 20 && WaitingFor20)
                    {
                        WaitingFor8 = true;
                        WaitingFor20 = false;
                    }
                    else
                    {
                        return false;
                    }
                }
               
            }
            if (Reminder > 0)
            {
                int S = 0;
                for (int i = 0; i < Reminder; i++)
                    S += Summation[3 * TriplesCount+i];
                if (S != 8 && S != 20)
                    return false;
            }

            return true;
        }
        public static bool CheckD_ArrayBasedOnItsRequirements1(int[] D_Array, int FromIndex, int ToIndex)//ok
        {
            if (FromIndex % 2 == 1)
                FromIndex++;
            if (ToIndex % 2 == 1)
                ToIndex--;
            int Count = (ToIndex - FromIndex + 1) / 2;
            for (int i = 0; i < Count; i++)
            {
                int bu0 = D_Array[FromIndex + 2 * i];
                int bu1 = D_Array[FromIndex + 2 * i + 1];
                int bb0 = D_Array[D_Array.Length - 1 - (FromIndex + 2 * i)];
                int bb1 = D_Array[D_Array.Length - 1 - (FromIndex + 2 * i + 1)];
                int y0 = MiscMethods.Equivalent1To9(Math.Abs(bu0 - bb0));
                int y1 = MiscMethods.Equivalent1To9(Math.Abs(bu1 - bb1));
                int x = y0 + y1;
                if (x > 9)
                    return false;
            }
            return true;
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2(int[] B_Array)//ok
        {
            //return true;
            bool result = false;
            int Length = B_Array.Length;
            if (Length == 9) result = CheckB_ArrayBasedOnItsRequirements2_9(B_Array);
            if (Length == 11) result = CheckB_ArrayBasedOnItsRequirements2_11(B_Array);
            if (Length == 12) result = CheckB_ArrayBasedOnItsRequirements2_12(B_Array);
            if (Length == 14) result = CheckB_ArrayBasedOnItsRequirements2_14(B_Array);
            if (Length == 18) result = CheckB_ArrayBasedOnItsRequirements2_18(B_Array);
            if (Length == 20) result = CheckB_ArrayBasedOnItsRequirements2_20(B_Array);
            if (Length == 26) result = CheckB_ArrayBasedOnItsRequirements2_26(B_Array);
            if (Length == 28) result = CheckB_ArrayBasedOnItsRequirements2_28(B_Array);
            return result;
        }
        public static bool IsAValidBColumn(int[] B_Array)//ok
        {
            bool result = true;
            for (int i = 0; i < B_Array.Length - 1; i++)
                if (IntSubarrayForBAndD.Valid_B_TuplesMapping[B_Array[i], B_Array[i + 1]] != 1)
                    return false;
            return result;
        }
        public static bool IsAValidDColumn(int[] D_Array)//ok
        {
            bool result = true;
            for (int i = 0; i < D_Array.Length - 1; i++)
                if (IntSubarrayForBAndD.Valid_D_TuplesMapping[D_Array[i], D_Array[i + 1]] != 1)
                    return false;
            return result;
        }
        public static bool IsAValidPairForBAndDColumns(int[] B_Array, int[] D_Array)//ok
        {
            bool result = true;
            for (int i = 0; i < B_Array.Length - 1; i++)
                if (IntSubarrayForBAndD.Valid_BAndD_TuplesMapping[B_Array[i], B_Array[i + 1], D_Array[i], D_Array[i + 1]] != 1)
                    return false;
            return result;
        }


        public static bool CheckB_ArrayBasedOnItsRequirements2_6And6(int[] B_Array, int Part1, int Part2)//ok
        {
            int StartIndex = Part1;
            int a1 = Math.Abs(B_Array[StartIndex] - B_Array[StartIndex + 3]);
            int a2 = Math.Abs(B_Array[StartIndex + 1] - B_Array[StartIndex + 4]);
            int a3 = Math.Abs(B_Array[StartIndex + 2] - B_Array[StartIndex + 5]);

            StartIndex = Part2;
            int b1 = Math.Abs(B_Array[StartIndex] - B_Array[StartIndex + 3]);
            int b2 = Math.Abs(B_Array[StartIndex + 1] - B_Array[StartIndex + 4]);
            int b3 = Math.Abs(B_Array[StartIndex + 2] - B_Array[StartIndex + 5]);

            bool C1 = InputManagement.SummationOrDistanceIsASpecialNumber(a1, b1);
            bool C2 = InputManagement.SummationOrDistanceIsASpecialNumber(a2, b2);
            bool C3 = InputManagement.SummationOrDistanceIsASpecialNumber(a3, b3);

            return (C1 && C2 && C3);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_4And4(int[] B_Array, int Part1, int Part2)//ok
        {
            int StartIndex = Part1;
            int a1 = Math.Abs(B_Array[StartIndex] - B_Array[StartIndex + 2]);
            int a2 = Math.Abs(B_Array[StartIndex + 1] - B_Array[StartIndex + 3]);

            StartIndex = Part2;
            int b1 = Math.Abs(B_Array[StartIndex] - B_Array[StartIndex + 2]);
            int b2 = Math.Abs(B_Array[StartIndex + 1] - B_Array[StartIndex + 3]);

            bool C1 = InputManagement.SummationOrDistanceIsASpecialNumber(a1, b1);
            bool C2 = InputManagement.SummationOrDistanceIsASpecialNumber(a2, b2);


            return (C1 && C2);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_3And3(int[] B_Array, int Part1, int Part2)//ok
        {
            int a1 = Math.Abs(B_Array[Part1] - B_Array[Part2]);
            int a2 = Math.Abs(B_Array[Part1 + 1] - B_Array[Part2 + 1]);
            int a3 = Math.Abs(B_Array[Part1 + 2] - B_Array[Part2 + 2]);

            bool C1 = InputManagement.IsASpecialNumber(a1);
            bool C2 = InputManagement.IsASpecialNumber(a2);
            bool C3 = InputManagement.IsASpecialNumber(a3);

            return (C1 && C2 && C3);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_2And2(int[] B_Array, int Part1, int Part2)//ok
        {
            int a1 = Math.Abs(B_Array[Part1] - B_Array[Part2]);
            int a2 = Math.Abs(B_Array[Part1 + 1] - B_Array[Part2 + 1]);

            bool C1 = InputManagement.IsASpecialNumber(a1);
            bool C2 = InputManagement.IsASpecialNumber(a2);

            return (C1 && C2);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_1And1(int[] B_Array, int Part1, int Part2)//ok
        {
            int a1 = Math.Abs(B_Array[Part1] - B_Array[Part2]);
            bool C1 = InputManagement.IsASpecialNumber(a1);

            return (C1);
        }

        public static bool CheckB_ArrayBasedOnItsRequirements2_28(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 22);
            bool C2 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 6, 16);
            bool C3 = CheckB_ArrayBasedOnItsRequirements2_2And2(B_Array, 12, 14);

            return (C1 && C2 && C3);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_26(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 20);
            bool C2 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 6, 14);
            bool C3 = CheckB_ArrayBasedOnItsRequirements2_1And1(B_Array, 12, 13);

            return (C1 && C2 && C3);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_20(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 14);
            bool C2 = CheckB_ArrayBasedOnItsRequirements2_3And3(B_Array, 6, 11);
            bool C3 = CheckB_ArrayBasedOnItsRequirements2_1And1(B_Array, 9, 10);

            return (C1 && C2 && C3);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_18(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 12);
            bool C2 = CheckB_ArrayBasedOnItsRequirements2_3And3(B_Array, 6, 9);

            return (C1 && C2);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_14(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 8);
            bool C2 = CheckB_ArrayBasedOnItsRequirements2_1And1(B_Array, 6, 7);

            return (C1 && C2);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_12(int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_6And6(B_Array, 0, 6);
            return (C1);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_11(int[] B_Array)//ok
        {
            int[] B_Array2 = new int[12];
            B_Array2 = MiscMethods.CopySubarrayIntoArray(B_Array2, B_Array, 0);
            B_Array2[11] = 0;

            bool C1 = CheckB_ArrayBasedOnItsRequirements2_12(B_Array2);

            return (C1);
        }
        public static bool CheckB_ArrayBasedOnItsRequirements2_9 (int[] B_Array)//ok
        {
            bool C1 = CheckB_ArrayBasedOnItsRequirements2_4And4(B_Array, 0, 5);
            bool C2 = InputManagement.IsASpecialNumber(B_Array[4]);
            return (C1 && C2);
        }

        public static bool CheckD_ArrayBasedOnItsRequirements2(int[] D_Array)//ok
        {
            int Length = D_Array.Length;

            int Y = 0;
            int[] Fold = MiscMethods.FoldAndDistanceIfOddMiddleNoChangeMiddleIsFirst(D_Array);
            Fold = MiscMethods.Equivalent1To9(Fold);
            int[] Fold2 = MiscMethods.FoldAndDistanceIfOddMiddleNoChangeMiddleIsFirst(Fold);
            
            Fold = MiscMethods.InverseArray(Fold);
            Y = (int)MiscMethods.JoinItems(Fold2);
            int X = Fold[0] + Fold[1];
            if (X > 9)
                return false;
            for (int index = 1; index < Fold.Length / 2; index++)
            {
                int x = Fold[2 * index] + Fold[2 * index + 1];
                if (x > 9)
                    return false;
                X = MiscMethods.JoinDigits(x, X);
            }
            if (Fold.Length % 2==1)
                X = MiscMethods.JoinDigits(Fold[Fold.Length-1], X);
            if (MiscMethods.IsK28Minus20(X) && MiscMethods.IsK28Plus20(Y))
                return true;
            if (MiscMethods.IsK28Plus20(X) && MiscMethods.IsK28Minus20(Y))
                return true;
            return false;

        }


    }

    public class BDTableOrPattern
    {
        public static List<BDTableOrPattern> AllBDPatternTablesFor9;
        public static List<BDTableOrPattern> AllBDPatternTablesFor14;
        public static List<BDTableOrPattern> AllBDPatternTablesFor11And12;

        public static List<int[]>[] RepeatPatternsFor ;

        public static BDTableOrPattern ApplyARepeatPatternOnABDPatternTablesFor11And12(int[] PatternArray, BDTableOrPattern ABDTableOrPattern)
        {
            int Length =PatternArray.Length;
            BDTableOrPattern result = new BDTableOrPattern();
            int[] ColB = new int[Length];
            for (int j = 0; j < Length; j++)
                ColB[j] = ABDTableOrPattern.ColumnB[PatternArray[j]];
            int[] ColD;
            result.SetB(ColB);
            
            for (int i = 0; i < ABDTableOrPattern.ColumnsD.Count; i++)
            {
                ColD = new int[Length];
                for (int j = 0; j < Length; j++)
                    ColD[j] = ABDTableOrPattern.ColumnsD[i][PatternArray[j]];
                result.AddD(ColD);
            }
            return result;
        }
        public static BDTableOrPattern ApplyARepeatPatternOnABDPatternTablesFor14(int[] PatternArray, BDTableOrPattern ABDTableOrPattern, int index)
        {
            int Length = 5;
            BDTableOrPattern result = new BDTableOrPattern();
            int[] ColB = new int[Length];

            if (PatternArray[0]<2)
                ColB[0] = ABDTableOrPattern.ColumnB[PatternArray[0]];
            else
                ColB[0] = ABDTableOrPattern.ColumnB[ABDTableOrPattern.ColumnB.Length -4 -PatternArray[0]];

            if (PatternArray[1] < 2)
                ColB[1] = ABDTableOrPattern.ColumnB[PatternArray[1]];
            else
                ColB[1] = ABDTableOrPattern.ColumnB[ABDTableOrPattern.ColumnB.Length - 4 - PatternArray[1]];


            ColB[2] = ABDTableOrPattern.ColumnB[index];

            if (PatternArray[2] < 2)
                ColB[3] = ABDTableOrPattern.ColumnB[PatternArray[2]];
            else
                ColB[3] = ABDTableOrPattern.ColumnB[ABDTableOrPattern.ColumnB.Length - 4 - PatternArray[2]];

            if (PatternArray[3] < 2)
                ColB[4] = ABDTableOrPattern.ColumnB[PatternArray[3]];
            else
                ColB[4] = ABDTableOrPattern.ColumnB[ABDTableOrPattern.ColumnB.Length - 4 - PatternArray[3]];

            int[] ColD;
            result.SetB(ColB);

            for (int i = 0; i < ABDTableOrPattern.ColumnsD.Count; i++)
            {
                ColD = new int[Length];

                if (PatternArray[0] < 2)
                    ColD[0] = ABDTableOrPattern.ColumnsD[i][PatternArray[0]];
                else
                    ColD[0] = ABDTableOrPattern.ColumnsD[i][ABDTableOrPattern.ColumnsD[i].Length - 4 - PatternArray[0]];

                if (PatternArray[1] < 2)
                    ColD[1] = ABDTableOrPattern.ColumnsD[i][PatternArray[1]];
                else
                    ColD[1] = ABDTableOrPattern.ColumnsD[i][ABDTableOrPattern.ColumnsD[i].Length - 4 - PatternArray[1]];


                ColD[2] = ABDTableOrPattern.ColumnsD[i][index];

                if (PatternArray[2] < 2)
                    ColD[3] = ABDTableOrPattern.ColumnsD[i][PatternArray[2]];
                else
                    ColD[3] = ABDTableOrPattern.ColumnsD[i][ABDTableOrPattern.ColumnsD[i].Length - 4 - PatternArray[2]];

                if (PatternArray[3] < 2)
                    ColB[4] = ABDTableOrPattern.ColumnsD[i][PatternArray[3]];
                else
                    ColD[4] = ABDTableOrPattern.ColumnsD[i][ABDTableOrPattern.ColumnsD[i].Length - 4 - PatternArray[3]];

                result.AddD(ColD);
            }
            return result;
        }
       


        public static void InitializeTables()
        {
            RepeatPatternsFor = new List<int[]>[11];
            for (int i=0;i<11;i++)
                RepeatPatternsFor[i] = new List<int[]>();
            
            int[] Temp;
            // 0, 1, 0, 1, 0, 1, 0, 1,   2, 3, 2, 3, 2, 3, 2, 3
            // 1, 0, 1, 0, 1, 0, 1, 0 ,  3, 2, 3, 2, 3, 2, 3, 2
            // 0, 1, 1, 0, 0, 1, 1, 0,   3, 2, 2, 3, 3, 2, 2, 3
            // 1, 0, 0, 1, 1, 0, 0, 1 ,  2, 3, 3, 2, 2, 3, 3, 2


            // For 4
            Temp = new int[] { 0, 1,  2, 3 }; RepeatPatternsFor[4].Add(Temp);

            Temp = new int[] { 1, 0,  3, 2 }; RepeatPatternsFor[4].Add(Temp);

            Temp = new int[] { 0, 1,  2, 3 }; RepeatPatternsFor[4].Add(Temp);

            Temp = new int[] { 1, 0,  3, 2 }; RepeatPatternsFor[4].Add(Temp);


            // For 5
            Temp = new int[] { 0, 1, 0,  2, 3 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 0, 1, 3, 2, 3 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 1, 0, 1,  3, 2 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 1, 0,  2, 3, 2 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 0, 1, 1,  2, 3 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 0, 1,  2, 2, 3 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 1, 0, 0, 3, 2 }; RepeatPatternsFor[5].Add(Temp);
            Temp = new int[] { 1, 0, 3, 3, 2 }; RepeatPatternsFor[5].Add(Temp);

            // For 6
            Temp = new int[] { 0, 1, 0,  3, 2, 3 }; RepeatPatternsFor[6].Add(Temp);
            Temp = new int[] { 1, 0, 1, 2, 3, 2 }; RepeatPatternsFor[6].Add(Temp);
            Temp = new int[] { 0, 1, 1,  2, 2, 3 }; RepeatPatternsFor[6].Add(Temp);
            Temp = new int[] { 1, 0, 0,  3, 3, 2 }; RepeatPatternsFor[6].Add(Temp);

            // For 7
            Temp = new int[] { 0, 1, 0, 1,  3, 2, 3 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 0, 1, 0, 2, 3, 2, 3 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 1, 0, 1, 0,  2, 3, 2 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 1, 0, 1,  3, 2, 3, 2 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 0, 1, 1, 0,  2, 2, 3 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 0, 1, 1, 3, 2, 2, 3 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 1, 0, 0, 1,  3, 3, 2 }; RepeatPatternsFor[7].Add(Temp);
            Temp = new int[] { 1, 0, 0,  2, 3, 3, 2 }; RepeatPatternsFor[7].Add(Temp);

            // For 8
            Temp = new int[] { 0, 1, 0, 1,  2, 3, 2, 3 }; RepeatPatternsFor[8].Add(Temp);
            Temp = new int[] { 1, 0, 1, 0,  3, 2, 3, 2 }; RepeatPatternsFor[8].Add(Temp);
            Temp = new int[] { 0, 1, 1, 0, 3, 2, 2, 3 }; RepeatPatternsFor[8].Add(Temp);
            Temp = new int[] { 1, 0, 0, 1,  2, 3, 3, 2 }; RepeatPatternsFor[8].Add(Temp);


            // For 9
            Temp = new int[] { 0, 1, 0, 1, 0,  2, 3, 2, 3 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 0, 1, 0, 1,  3, 2, 3, 2, 3 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 1, 0, 1, 0, 1, 3, 2, 3, 2 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 1, 0, 1, 0,  2, 3, 2, 3, 2 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 0, 1, 1, 0, 0,  3, 2, 2, 3 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 0, 1, 1, 0,  3, 3, 2, 2, 3 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 1, 0, 0, 1, 1, 2, 3, 3, 2 }; RepeatPatternsFor[9].Add(Temp);
            Temp = new int[] { 1, 0, 0, 1, 2, 2, 3, 3, 2 }; RepeatPatternsFor[9].Add(Temp);

            // For 10
            Temp = new int[] { 0, 1, 0, 1, 0, 3, 2, 3, 2, 3 }; RepeatPatternsFor[10].Add(Temp);
            Temp = new int[] { 1, 0, 1, 0, 1, 2, 3, 2, 3, 2 }; RepeatPatternsFor[10].Add(Temp);
            Temp = new int[] { 0, 1, 1, 0, 0,  3, 3, 2, 2, 3 }; RepeatPatternsFor[10].Add(Temp);
            Temp = new int[] { 1, 0, 0, 1, 1,  2, 2, 3, 3, 2 }; RepeatPatternsFor[10].Add(Temp);



            AllBDPatternTablesFor9 = new List<BDTableOrPattern>();
            AllBDPatternTablesFor11And12 = new List<BDTableOrPattern>();
            AllBDPatternTablesFor14 = new List<BDTableOrPattern>();
            BDTableOrPattern BDTP = new BDTableOrPattern();
            BDTP.SetBFor9(8, 15, 13); BDTP.AddDFor9(8, 10, 10); BDTP.AddDFor9(8, 18, 2); BDTP.AddDFor9(20, 10, 10); BDTP.AddDFor9(20, 18,2); 
            AllBDPatternTablesFor9.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor9(11,12,16); BDTP.AddDFor9(8,13,7); BDTP.AddDFor9(8,15,5); BDTP.AddDFor9(20,13,7); BDTP.AddDFor9(20,15,5);
            AllBDPatternTablesFor9.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor9(17,6,22); BDTP.AddDFor9(8,19,1); BDTP.AddDFor9(8,9,11); BDTP.AddDFor9(20,19,1); BDTP.AddDFor9(20,9,11);
            AllBDPatternTablesFor9.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor9(20,3,25); BDTP.AddDFor9(8,22,26); BDTP.AddDFor9(8,6,14); BDTP.AddDFor9(20,22,26); BDTP.AddDFor9(20,6,14);
            AllBDPatternTablesFor9.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor9(26,25,3); BDTP.AddDFor9(8,28,20); BDTP.AddDFor9(20,28,20); 
            AllBDPatternTablesFor9.Add(BDTP);
            ///----

            
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(3, 8, 20, 8); BDTP.AddDFor11And12(5, 13, 5, 15); BDTP.AddDFor11And12(5, 13, 23, 25); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(3, 17, 20, 8); BDTP.AddDFor11And12(5, 22, 5, 15); BDTP.AddDFor11And12(5, 22, 23, 25); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(3, 26, 20, 8); BDTP.AddDFor11And12(5, 3, 5, 15); BDTP.AddDFor11And12(5, 3, 23, 25); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(4, 7, 19, 9); BDTP.AddDFor11And12(6,14,6,14); BDTP.AddDFor11And12(6,14,22,26); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(4,16,19,9); BDTP.AddDFor11And12(6, 23, 6, 14); BDTP.AddDFor11And12(6, 23, 22, 26); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(4, 25, 19, 9); BDTP.AddDFor11And12(6, 4, 6, 14); BDTP.AddDFor11And12(6, 4, 22, 26); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(5, 6, 18, 10); BDTP.AddDFor11And12(7,15,7,13); BDTP.AddDFor11And12(7,15,21,27); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(5, 15, 18, 10); BDTP.AddDFor11And12(7, 24, 7, 13); BDTP.AddDFor11And12(7, 24, 21, 27); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(5, 24, 18, 10); BDTP.AddDFor11And12(7, 5, 7, 13); BDTP.AddDFor11And12(7, 5, 21, 27); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(6, 5, 17, 11); BDTP.AddDFor11And12(8,16,8,12); BDTP.AddDFor11And12(8,16,20,25); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(6, 14, 17, 11); BDTP.AddDFor11And12(8, 25, 8, 12); BDTP.AddDFor11And12(8, 25, 20, 25); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(6, 23, 17, 11); BDTP.AddDFor11And12(8, 6, 8, 12); BDTP.AddDFor11And12(8, 6, 20, 25); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(7,4,16,12); BDTP.AddDFor11And12(9,17,9,11); BDTP.AddDFor11And12(9,17,19,1); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(7, 13, 16, 12); BDTP.AddDFor11And12(9, 26, 9, 11); BDTP.AddDFor11And12(9, 26, 19, 1); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(7, 22, 16, 12); BDTP.AddDFor11And12(9, 8, 9, 11); BDTP.AddDFor11And12(9, 8, 19, 1); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(8,3,15,13); BDTP.AddDFor11And12(10,18,10,10); BDTP.AddDFor11And12(10,18,18,2); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(8, 12, 15, 13); BDTP.AddDFor11And12(10, 27, 10, 10); BDTP.AddDFor11And12(10, 27, 18, 2); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(8, 21, 15, 13); BDTP.AddDFor11And12(10, 8, 10, 10); BDTP.AddDFor11And12(10, 8, 18, 2); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(9, 2, 14, 14); BDTP.AddDFor11And12(11,19,11,9); BDTP.AddDFor11And12(11,19,17,3); AllBDPatternTablesFor11And12.Add(BDTP);

            ////BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(9, 11, 14, 14); BDTP.AddDFor11And12(11, 28, 11, 9); BDTP.AddDFor11And12(11, 28, 17, 3); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(9, 20, 14, 14); BDTP.AddDFor11And12(11, 9, 11, 9); BDTP.AddDFor11And12(11, 9, 17, 3); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(10,1,13,15); BDTP.AddDFor11And12(12,20,12,8); BDTP.AddDFor11And12(12,20,16,4); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(10, 10, 13, 15); BDTP.AddDFor11And12(12, 1, 12, 8); BDTP.AddDFor11And12(12, 1, 16, 4); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(10, 19, 13, 15); BDTP.AddDFor11And12(12, 10, 12, 8); BDTP.AddDFor11And12(12, 10, 16, 4); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(11, 9, 12, 16); BDTP.AddDFor11And12(13,21,13,7); BDTP.AddDFor11And12(13,21,15,5); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(11, 18, 12, 16); BDTP.AddDFor11And12(13, 2, 13, 7); BDTP.AddDFor11And12(13, 2, 15, 5); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(11, 27, 12, 16); BDTP.AddDFor11And12(13, 11, 13, 7); BDTP.AddDFor11And12(13, 11, 15, 5); AllBDPatternTablesFor11And12.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(12, 8, 11, 17); BDTP.AddDFor11And12(14,22,14,6); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(12, 17, 11, 17); BDTP.AddDFor11And12(14, 3, 14, 6); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(12, 26, 11, 17); BDTP.AddDFor11And12(14, 12, 14, 6); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(13,7,10,18); BDTP.AddDFor11And12(15,23,15,5); BDTP.AddDFor11And12(15,23,13,7); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(13, 16, 10, 18); BDTP.AddDFor11And12(15, 4, 15, 5); BDTP.AddDFor11And12(15, 4, 13, 7); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(13, 25, 10, 18); BDTP.AddDFor11And12(15, 13, 15, 5); BDTP.AddDFor11And12(15, 13, 13, 7); AllBDPatternTablesFor11And12.Add(BDTP);
            
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(14, 6, 9, 19); BDTP.AddDFor11And12(16, 24, 16, 4); BDTP.AddDFor11And12(16,24,12,8); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(14, 15, 9, 19); /*BDTP.AddDFor11And12(12, 5, 16, 4); BDTP.AddDFor11And12(12, 5, 12, 8); */BDTP.AddDFor11And12(12, 20, 12, 8); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(14, 24, 9, 19); BDTP.AddDFor11And12(12, 14, 16, 4); BDTP.AddDFor11And12(12, 14, 12, 8); AllBDPatternTablesFor11And12.Add(BDTP);
            
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(15, 5, 8, 20); BDTP.AddDFor11And12(17, 25, 17, 3); BDTP.AddDFor11And12(17,25,11,9); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(15, 14, 8, 20); BDTP.AddDFor11And12(17, 6, 17, 3); BDTP.AddDFor11And12(17, 6, 11, 9); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(15, 23, 8, 20); BDTP.AddDFor11And12(17, 15, 17, 3); BDTP.AddDFor11And12(17, 15, 11, 9); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(16, 4, 7, 21); BDTP.AddDFor11And12(18,26,18,2); BDTP.AddDFor11And12(18,26,10,10); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(16, 13, 7, 21); BDTP.AddDFor11And12(18, 7, 18, 2); BDTP.AddDFor11And12(18, 7, 10, 10); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(16, 22, 7, 21); BDTP.AddDFor11And12(18, 16, 18, 2); BDTP.AddDFor11And12(18, 16, 10, 10); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(17,3,6,22); BDTP.AddDFor11And12(19,27,19,1); BDTP.AddDFor11And12(19,27,9,11); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(17, 12, 6, 22); BDTP.AddDFor11And12(19, 8, 19, 1); BDTP.AddDFor11And12(19, 8, 9, 11); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(17, 21, 6, 22); BDTP.AddDFor11And12(19, 17, 19, 1); BDTP.AddDFor11And12(19, 17, 9, 11); AllBDPatternTablesFor11And12.Add(BDTP);

            ////BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(18,2,5,23); BDTP.AddDFor11And12(20,28,20,28); BDTP.AddDFor11And12(20,28,8,12); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(18, 11, 5, 23);  BDTP.AddDFor11And12(20, 9, 8, 12); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(18, 20, 5, 23); BDTP.AddDFor11And12(20, 18, 8, 12); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(19,1,4,24); BDTP.AddDFor11And12(21,1,21,27); BDTP.AddDFor11And12(21,1,7,13); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(19, 10, 4, 24); BDTP.AddDFor11And12(21, 10, 21, 27); BDTP.AddDFor11And12(21, 10, 7, 13); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(19, 9, 4, 24); BDTP.AddDFor11And12(21, 19, 21, 27); BDTP.AddDFor11And12(21, 19, 7, 13); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(20,9,3,25); BDTP.AddDFor11And12(22,2,22,26); BDTP.AddDFor11And12(22,2,6,14); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(20,18, 3, 25); BDTP.AddDFor11And12(22, 11, 22, 26); BDTP.AddDFor11And12(22, 11, 6, 14); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(20, 27, 3, 25); BDTP.AddDFor11And12(22, 20, 22, 26); BDTP.AddDFor11And12(22, 20, 6, 14); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(21,8,2,26); BDTP.AddDFor11And12(23,3,23,25); BDTP.AddDFor11And12(23,3,5,15); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(21, 17, 2, 26); BDTP.AddDFor11And12(23, 12, 23, 25); BDTP.AddDFor11And12(23, 12, 5, 15); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(21, 26, 2, 26); BDTP.AddDFor11And12(23, 21, 23, 25); BDTP.AddDFor11And12(23, 21, 5, 15); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(22,7,1,27); BDTP.AddDFor11And12(24,4,24,24); BDTP.AddDFor11And12(24,4,4,16); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(22, 16, 1, 27); BDTP.AddDFor11And12(24, 13, 24, 24); BDTP.AddDFor11And12(24, 13, 4, 16); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(22, 25, 1, 27); BDTP.AddDFor11And12(24, 22, 24, 24); BDTP.AddDFor11And12(24, 22, 4, 16); AllBDPatternTablesFor11And12.Add(BDTP);

           //// BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(23,6,28,28); BDTP.AddDFor11And12(25,5,25,23); BDTP.AddDFor11And12(25,5,3,17); AllBDPatternTablesFor11And12.Add(BDTP);
           //// BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(23, 15, 28, 28); BDTP.AddDFor11And12(25, 14, 25, 23); BDTP.AddDFor11And12(25, 14, 3, 17); AllBDPatternTablesFor11And12.Add(BDTP);
           //// BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(23, 24, 28, 28); BDTP.AddDFor11And12(25, 23, 25, 23); BDTP.AddDFor11And12(25, 23, 3, 17); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(24,5,27,1); BDTP.AddDFor11And12(26,6,26,22); BDTP.AddDFor11And12(26,6,2,18); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(24, 14, 27, 1); BDTP.AddDFor11And12(26, 15, 26, 22); BDTP.AddDFor11And12(26, 15, 2, 18); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(24, 23, 27, 1); BDTP.AddDFor11And12(26, 24, 26, 22); BDTP.AddDFor11And12(26, 24, 2, 18); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(25,4,26,2); BDTP.AddDFor11And12(27,7,27,21); BDTP.AddDFor11And12(27,7,1,19); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(25, 13, 26, 2); BDTP.AddDFor11And12(27, 16, 27, 21); BDTP.AddDFor11And12(27, 16, 1, 19); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(25, 22, 26, 2); BDTP.AddDFor11And12(27, 25, 27, 21); BDTP.AddDFor11And12(27, 25, 1, 19); AllBDPatternTablesFor11And12.Add(BDTP);

            ////BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(26,3,25,3); BDTP.AddDFor11And12(28,8,28,20); AllBDPatternTablesFor11And12.Add(BDTP);
            ////BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(26, 12, 25, 3); BDTP.AddDFor11And12(28, 17, 28, 20); AllBDPatternTablesFor11And12.Add(BDTP);
            ////BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(26, 21, 25, 3); BDTP.AddDFor11And12(28, 26, 28, 20); AllBDPatternTablesFor11And12.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(27, 2, 24, 4); BDTP.AddDFor11And12(1, 9, 1, 19); BDTP.AddDFor11And12(1, 9, 27, 21); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(27, 11, 24, 4); BDTP.AddDFor11And12(1, 18, 1, 19); BDTP.AddDFor11And12(1, 18, 27, 21); AllBDPatternTablesFor11And12.Add(BDTP);
            BDTP = new BDTableOrPattern(); BDTP.SetBFor11And12(27, 20, 24, 4); BDTP.AddDFor11And12(1, 27, 1, 19); BDTP.AddDFor11And12(1, 27, 27, 21); AllBDPatternTablesFor11And12.Add(BDTP);


            
            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(3,8,3,20,8,20,8); BDTP.AddDFor14(5,13,5,15,25,5,15); BDTP.AddDFor14(5,13,5,15,25,23,25); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(3, 17, 3, 17, 20, 8, 20, 8); BDTP.AddDFor14(5, 22, 5, 15, 15, 25, 5, 15);
            BDTP.AddDFor14(5, 22, 5, 15, 15, 25, 23, 25); 
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(3, 26, 3, 26, 20, 8, 20, 8); BDTP.AddDFor14(5, 3, 5, 3, 15, 25, 5, 15); 
            BDTP.AddDFor14(5, 3, 5, 3, 15, 25, 23, 25); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(4, 7, 4, 9, 19, 9); BDTP.AddDFor14(6, 14, 6, 26, 6, 14); 
            BDTP.AddDFor14(6, 14, 6, 26, 22, 26); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(4, 16, 4, 16, 9, 19, 9); BDTP.AddDFor14(6, 23, 6, 23, 26, 6, 14); 
            BDTP.AddDFor14(6, 23, 6, 23, 26, 22,26); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(4, 25, 4, 25, 9, 19, 9); BDTP.AddDFor14(6, 4, 6, 4, 26, 6, 14); 
            BDTP.AddDFor14(6, 4, 6, 4, 26, 22, 26); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(5, 6, 5, 5, 18, 10, 10, 10, 18, 10); BDTP.AddDFor14(7, 15, 7, 15, 7, 27, 21, 7, 7, 13); 
            BDTP.AddDFor14(7, 15, 7, 15, 7, 27, 21, 7, 21, 27); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(5, 15, 5, 5, 15, 15, 18, 10, 10, 10, 18, 10); BDTP.AddDFor14(7, 24, 7, 24, 7, 24, 7, 27, 21, 7, 7, 13);
            BDTP.AddDFor14(7, 24, 7, 24, 7, 24, 7, 27, 21, 7, 21, 27); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(5, 24, 5, 24, 24, 18, 10, 10, 10, 18, 10); BDTP.AddDFor14(7, 5, 7, 7, 5, 7, 27, 21, 7, 7, 13);
            BDTP.AddDFor14(7, 5, 7, 7, 5, 7, 27, 21, 7, 21, 27); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(6, 5, 6, 5, 17, 11, 17, 17, 11); BDTP.AddDFor14(8,16,8,16,25,25,12,8,12);
            BDTP.AddDFor14(8, 16, 8, 16, 25, 25, 12, 20, 25); AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(6, 14, 6, 14, 17, 17, 11, 17, 11); BDTP.AddDFor14(8, 25, 8, 25, 25,  12,25, 8, 12);
            BDTP.AddDFor14(8, 25, 8, 25, 25, 12, 25, 20, 25); AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(6, 23, 6, 23, 17, 17, 11, 17, 11); BDTP.AddDFor14(8, 6, 8, 6, 25, 12, 25, 8, 12);
            BDTP.AddDFor14(8, 6, 8, 6, 25, 12, 25, 20, 25); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(7,4,7,16,16,12,16,12); BDTP.AddDFor14(9,17,9,19,1,1,9,11);
            BDTP.AddDFor14(9, 17, 9, 19, 1, 1, 19, 1); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(7, 13, 7, 13, 16, 16, 12, 16, 12); BDTP.AddDFor14(9, 26, 9, 26, 19, 1, 1, 9, 11);
            BDTP.AddDFor14(9, 26, 9, 26, 19, 1, 1, 19, 1); AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(7, 22, 7, 16, 16, 12, 16, 12); BDTP.AddDFor14(9, 8, 9, 19, 1, 1, 9, 11);
            BDTP.AddDFor14(9, 8, 9, 19, 1, 1, 19, 1); AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(8,3,8,8,3,15,13,15,13); BDTP.AddDFor14(10,8,10,26,8,2,2,10,10);
            BDTP.AddDFor14(10, 8, 10, 26, 8, 2, 2, 18,2); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(8, 12, 8, 8, 12, 12, 15, 13, 15, 13); BDTP.AddDFor14(10,27,10,27,10,27,2,2,10,10);
            BDTP.AddDFor14(10, 27, 10, 27, 10, 27, 2, 2, 18, 2); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(8, 21, 8, 21, 21, 15, 13, 15, 13); BDTP.AddDFor14(10, 8, 10, 8, 10, 2, 2, 10, 10);
            BDTP.AddDFor14(10, 8, 10, 8, 10, 2, 2, 18, 2); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(9, 2, 9, 9, 2, 14, 14, 14); BDTP.AddDFor14(11,19,11,19,19,3,11,9);
            BDTP.AddDFor14(11, 19, 11, 19, 19, 3, 17, 3); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(9, 11, 9, 11, 14, 14, 14); BDTP.AddDFor14(11, 28, 11, 28, 3, 11, 9);
            BDTP.AddDFor14(1, 28, 11, 28, 3, 17, 3); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(9, 20, 9, 20, 14, 14, 14); BDTP.AddDFor14(11, 9, 11, 9, 3, 11, 9);
            BDTP.AddDFor14(11, 9, 11, 9, 3, 17, 3); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(10, 1, 10, 10, 1, 13, 13,13,15); BDTP.AddDFor14(12,20,12,20,12,4,16,12,8);
            BDTP.AddDFor14(12, 20, 12, 20, 12, 4, 16, 16, 4); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(10, 10, 10, 10, 13, 13, 13, 15); BDTP.AddDFor14(12, 1, 12, 1, 4, 16, 12, 8);
            BDTP.AddDFor14(12, 1, 12, 1, 4, 16, 16, 4); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(10, 19, 10, 10, 19, 13, 13, 15); BDTP.AddDFor14(12, 10, 12, 10, 10, 4, 12, 8);
            BDTP.AddDFor14(12, 10, 12, 10, 10, 4, 16, 4); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(11, 9, 11, 9, 12, 16, 12, 16); BDTP.AddDFor14(13,21,13,21,5,5,13,7);
            BDTP.AddDFor14(13, 21, 13, 21, 5, 5, 15,5); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(11, 18, 11, 18, 12, 16, 12, 16); BDTP.AddDFor14(13, 2, 13, 2, 5, 5, 13, 7);
            BDTP.AddDFor14(13, 2, 13, 2, 5, 5, 15, 5); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(11, 27, 11, 27, 12, 16, 12, 16); BDTP.AddDFor14(13, 11, 13, 11, 5, 5, 13, 7);
            BDTP.AddDFor14(13, 11, 13, 11, 5, 5, 15, 5); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(12, 8, 12, 8, 11, 17, 11, 17); BDTP.AddDFor14(14, 22, 14, 22, 6, 6, 14, 6);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(12, 17, 12, 17, 11, 17, 11, 17); BDTP.AddDFor14(14, 3, 14, 3, 6, 6, 14, 6);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(12, 26, 12, 26, 11, 17, 11, 17); BDTP.AddDFor14(14, 12, 14, 12, 6, 6, 14, 6);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(13, 7, 13, 13, 7, 7, 10, 18, 10, 18); BDTP.AddDFor14(15, 23, 15, 23, 15, 23, 7, 7, 15, 5); 
            BDTP.AddDFor14(15, 23, 15, 23, 15, 23, 7, 7, 13, 7);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(13, 16, 13, 13, 16, 10, 18, 10, 18); BDTP.AddDFor14(15, 4, 15, 4, 4, 7, 7, 15, 5); 
            BDTP.AddDFor14(15, 4, 15, 4, 4, 7, 7, 13, 7);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(13, 25, 13, 13, 25, 18, 10, 18); BDTP.AddDFor14(15, 13, 15, 13, 13, 7, 15, 5); 
            BDTP.AddDFor14(15, 13, 15, 13, 13, 7, 13, 7);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(14, 6, 14, 14, 6, 9, 19, 9, 19); BDTP.AddDFor14(16, 24, 16, 24, 24, 8, 16, 16, 4);
            BDTP.AddDFor14(16, 24, 16, 24, 24, 8, 16, 12, 8);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(14, 15, 14, 15, 9, 19, 9, 19); BDTP.AddDFor14(12, 5, 12, 5, 8, 16, 16, 4); 
            BDTP.AddDFor14(12, 5, 12, 5, 8, 16, 12, 8);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(14, 24, 14, 14, 24, 24, 9, 19, 9, 19); BDTP.AddDFor14(12, 14, 12, 14, 12, 14, 8, 16, 16, 4);
            BDTP.AddDFor14(12, 14, 12, 14, 12, 14, 8, 16, 12, 8);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(15, 5, 15, 5, 8, 8, 20, 20, 8, 20); BDTP.AddDFor14(17, 25, 17, 25, 9, 3, 9, 3, 17, 3); 
            BDTP.AddDFor14(17, 25, 17, 25, 9, 3, 9, 3, 11, 9);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(15, 14, 15, 14, 8, 8, 20, 20, 8, 20); BDTP.AddDFor14(17, 6, 17, 6, 9, 3, 9, 3, 17, 3); 
            BDTP.AddDFor14(17, 6, 17, 6, 9, 3, 9, 3, 11, 9);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(15, 23, 15, 15, 23, 8, 8, 20, 20, 8, 20); BDTP.AddDFor14(17, 15, 17, 15, 15, 9, 3, 9, 3, 17, 3); 
            BDTP.AddDFor14(17, 15, 17, 15, 15, 9, 3, 9, 3, 11, 9);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(16, 4, 16, 4, 7, 7, 21, 21, 7, 21); BDTP.AddDFor14(18, 26, 18, 26, 18, 10, 18, 10, 18, 2); 
            BDTP.AddDFor14(18, 26, 18, 26, 18, 10, 18, 10, 10, 10);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(16, 13, 16, 13, 7, 7, 21, 21, 7, 21); BDTP.AddDFor14(18, 7, 18, 7, 18, 10, 18, 10, 18, 2); 
            BDTP.AddDFor14(18, 7, 18, 7, 18, 10, 18, 10, 10, 10);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(16, 22, 16, 22, 7, 7, 21, 21, 7, 21); BDTP.AddDFor14(18, 16, 18, 16, 18, 10, 18, 10, 18, 2); 
            BDTP.AddDFor14(18, 16, 18, 16, 18, 10, 18, 10, 10, 10);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(17, 3, 17, 17, 3, 6, 22, 6, 22); BDTP.AddDFor14(19, 27, 19, 27, 27, 11, 11, 19, 1); 
            BDTP.AddDFor14(19, 27, 19, 27, 27, 11, 11, 9, 11);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(17, 12, 17, 12,  6, 22, 6, 22); BDTP.AddDFor14(19, 8, 19, 8,  11, 11, 19, 1); 
            BDTP.AddDFor14(19, 8, 19, 8, 11, 11, 9, 11);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(17, 21, 17, 21, 21, 6, 22, 6, 22); BDTP.AddDFor14(19, 17, 19, 17, 19, 11, 11, 19, 1);
            BDTP.AddDFor14(19, 17, 19, 17, 19, 11, 11, 9, 11);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(18, 2, 18, 2, 5, 23, 5, 23); BDTP.AddDFor14(20, 28, 20, 28, 12, 12, 20, 28); 
            BDTP.AddDFor14(20, 28, 20, 28, 12, 12, 8, 12);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(18, 11, 18, 11, 5, 23, 5, 23); BDTP.AddDFor14(20, 9, 20, 9, 12, 12, 20, 28); 
            BDTP.AddDFor14(20, 9, 20, 9, 12, 12, 8, 12);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(18, 20, 18, 18, 20, 5, 23, 5, 23); BDTP.AddDFor14(20, 18, 20, 18, 18, 12, 12, 20, 28); 
            BDTP.AddDFor14(20, 18, 20, 18, 18, 12, 12, 8, 12);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(19, 1, 19, 19, 1, 1, 4, 4, 24, 24, 4, 24); 
            BDTP.AddDFor14(21, 1, 21, 1, 1, 21, 13, 21, 7, 13, 21, 27); 
            BDTP.AddDFor14(21, 1, 21, 1, 1, 21, 13, 21, 7, 13, 7, 13);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(19, 10, 19, 19, 10, 10, 4, 4, 24, 24, 4, 24); 
            BDTP.AddDFor14(21, 10, 21, 10, 10, 21, 13, 21, 7, 13, 21, 27);
            BDTP.AddDFor14(21, 10, 21, 10, 10, 21, 13, 21, 7, 13, 7, 13);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(19, 19, 19, 19, 4, 4, 24, 24, 4, 24); BDTP.AddDFor14(21, 19, 21, 19, 13, 21, 7, 13, 21, 27);
            BDTP.AddDFor14(21, 19, 21, 19, 13, 21, 7, 13, 7, 13);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(20, 9, 20, 9, 3, 3, 25, 3, 25); BDTP.AddDFor14(22, 2, 22, 2, 14, 26, 14, 22, 26); 
            BDTP.AddDFor14(22, 2, 22, 2, 14, 26, 14, 6, 14);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(20, 18, 20, 18, 3, 3, 25, 3, 25); BDTP.AddDFor14(22, 11, 22, 11, 14, 26, 14, 22, 26); 
            BDTP.AddDFor14(22, 11, 22, 11, 14, 26, 14, 6, 14);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(20, 27, 20, 27, 3, 3, 25, 3, 25); BDTP.AddDFor14(22, 20, 22, 20, 14, 26, 14, 22, 26);
            BDTP.AddDFor14(22, 20, 22, 20, 14, 26, 14, 6, 14);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(21, 8, 21, 8, 2, 26, 2, 26); BDTP.AddDFor14(23, 3, 23, 3, 15, 15, 23, 25); 
            BDTP.AddDFor14(23, 3, 23, 3, 15, 15, 5, 15);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(21, 17, 21, 17, 2, 26, 2, 26); BDTP.AddDFor14(23, 12, 23, 12, 15, 15, 23, 25);
            BDTP.AddDFor14(23, 12, 23, 12, 15, 15, 5, 15);
            AllBDPatternTablesFor14.Add(BDTP);



            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(21, 26, 21, 26, 2, 26, 2, 26); BDTP.AddDFor14(23, 21, 23, 21, 15, 15, 23, 25); 
            BDTP.AddDFor14(23, 21, 23, 21, 15, 15, 5, 15);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(22, 27, 22, 22, 1, 27, 1, 27); BDTP.AddDFor14(24, 4, 24, 4, 16, 16, 24, 24); 
            BDTP.AddDFor14(24, 4, 24, 4, 16, 16, 4, 16);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(22, 16, 22, 22, 16, 16, 1, 27, 1, 27); BDTP.AddDFor14(24, 13, 24, 13, 13, 24, 16, 16, 24, 24); 
            BDTP.AddDFor14(24, 13, 24, 13, 13, 24, 16, 16, 4, 16);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(22, 25, 22, 22, 25, 1, 27, 1, 27); BDTP.AddDFor14(24, 22, 24, 22, 22, 16, 16, 24, 24);
            BDTP.AddDFor14(24, 22, 24, 22, 22, 16, 16, 4, 16);
            AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(23, 6, 23, 23, 6, 28, 28, 28, 28); BDTP.AddDFor14(25, 5, 25, 5, 5, 25, 17, 25, 23); 
            BDTP.AddDFor14(25, 5, 25, 5, 5, 25, 17, 3, 17);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(23, 15, 23, 15, 28, 28, 28, 28); BDTP.AddDFor14(25, 14, 25, 14, 25, 17, 25, 23); 
            BDTP.AddDFor14(25, 14, 25, 14, 25, 17, 3, 17);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(23, 24, 23, 24, 28, 28, 28, 28); BDTP.AddDFor14(25, 23, 25, 23, 25, 17, 25, 23); 
            BDTP.AddDFor14(25, 23, 25, 23, 25, 17, 3, 17);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(24, 5, 24, 24, 5, 27, 27, 27, 1, 27, 1); BDTP.AddDFor14(26, 6, 26, 6, 6, 26, 2, 18, 18, 26, 22); 
            BDTP.AddDFor14(26, 6, 26, 6, 6, 26, 2, 18, 18, 2, 18);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(24, 14, 24, 24, 14, 27, 27, 27, 1, 27, 1); BDTP.AddDFor14(26, 15, 26, 15, 15, 26, 2, 18, 18, 26, 22); 
            BDTP.AddDFor14(26, 15, 26, 15, 15, 26, 2, 18, 18, 2, 18);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(24, 23, 24, 24, 23, 27, 27, 27, 1, 27, 1); BDTP.AddDFor14(26, 24, 26, 24, 24, 26, 2, 18, 18, 26, 22);
            BDTP.AddDFor14(26, 24, 26, 24, 24, 26, 2, 18, 18, 2, 18);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(25, 4, 25, 4, 26, 26, 2, 2, 26, 2); BDTP.AddDFor14(27, 7, 27, 7, 21, 27, 27, 19, 27, 21); 
            BDTP.AddDFor14(27, 7, 27, 7, 21, 27, 27, 19, 1, 19);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(25, 13, 25, 13, 26, 26, 2, 2, 26, 2); BDTP.AddDFor14(27, 16, 27, 16, 21, 27, 27, 19, 27, 21); 
            BDTP.AddDFor14(27, 16, 27, 16, 21, 27, 27, 19, 1, 19);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(25, 22, 25, 22, 26, 26, 2, 2, 26, 2); BDTP.AddDFor14(27, 25, 27, 25, 21, 27, 27, 19, 27, 21); 
            BDTP.AddDFor14(27, 25, 27, 25, 21, 27, 27, 19, 1, 19);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(26, 3, 26, 3, 25, 3, 25, 3); BDTP.AddDFor14(28, 8, 28, 8, 28, 20, 28, 20); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(26, 12, 26, 12, 25, 3, 25, 3); BDTP.AddDFor14(28, 17, 28, 17, 28, 20, 28, 20); AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(26, 21, 26, 21, 25, 3, 25, 3); BDTP.AddDFor14(28, 26, 28, 26, 28, 20, 28, 20); AllBDPatternTablesFor14.Add(BDTP);


            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(27, 2, 27, 27, 2, 4, 24, 4); BDTP.AddDFor14(1, 9, 1, 9, 9, 21, 1, 19); BDTP.AddDFor14(1, 9, 1, 9, 9, 21, 27, 21);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(27, 11, 27, 11, 4, 24, 4); BDTP.AddDFor14(1, 18, 1, 18, 21, 1, 19);
            BDTP.AddDFor14(1, 18, 1, 18, 21, 27, 21);
            AllBDPatternTablesFor14.Add(BDTP);

            BDTP = new BDTableOrPattern(); BDTP.SetBFor14(27, 20, 27, 27, 20, 4, 24, 4); BDTP.AddDFor14(1, 27, 1, 27, 27, 21, 1, 19); 
            BDTP.AddDFor14(1, 27, 1, 27, 27, 21, 27, 21);
            AllBDPatternTablesFor14.Add(BDTP);
        }

        public void SetBFor9(int a, int b, int c)
        {
            ColumnB = new int[] { a, b , c };
        }
        public void AddDFor9(int a, int b, int c)
        {
            int[] ColumnD = new int[] { a, b, c };
            ColumnsD.Add(ColumnD);            
        }

        public void SetBFor11And12(int a, int b, int c, int d)
        {
            ColumnB = new int[] { a, b, c ,d };
        }
        public void AddDFor11And12(int a, int b, int c, int d)
        {
            int[] ColumnD = new int[] { a, b, c, d };
            ColumnsD.Add(ColumnD);
        }

        public void SetBFor14(int a, int b, int c, int d, int e, int f)
        {
            ColumnB = new int[] { a, b, c, d ,e,f};
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f };
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g)
        {
            ColumnB = new int[] { a, b, c, d, e, f,g };
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f ,g};
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            ColumnB = new int[] { a, b, c, d, e, f, g,h };
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f, g ,h};
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i)
        {
            ColumnB = new int[] { a, b, c, d, e, f, g, h,i };
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f, g, h,i };
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j)
        {
            ColumnB = new int[] { a, b, c, d, e, f, g, h, i ,j};
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f, g, h, i,j };
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k)
        {
            ColumnB = new int[] { a, b, c, d, e, f, g, h, i, j,k };
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f, g, h, i, j,k };
            ColumnsD.Add(ColumnD);
        }
        public void SetBFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l)
        {
            ColumnB = new int[] { a, b, c, d, e, f, g, h, i, j, k,l };
        }
        public void AddDFor14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l)
        {
            int[] ColumnD = new int[] { a, b, c, d, e, f, g, h, i, j, k ,l};
            ColumnsD.Add(ColumnD);
        }

        public void SetB(int[] columnB)
        {
            ColumnB = columnB;
        }
        public void AddD(int[] columnD)
        {
            ColumnsD.Add(columnD);
        }
        public void ClearD()
        {
            ColumnsD.Clear();
        }

        public BDTableOrPattern()
        {
            ColumnsD = new List<int[]>();
        }
        public int[] Get28MinusArray(int[] a)
        {
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = 28- a[i];
            return result;
        }
        public BDTableOrPattern Get28MinusBDTableOrPattern()
        {
            BDTableOrPattern result = new BDTableOrPattern();
            result.SetB(Get28MinusArray(this.ColumnB));
            for (int i = 0; i < ColumnsD.Count; i++)
            {
                result.AddD(Get28MinusArray(this.ColumnsD[i]));
            }
            return result;
        }


        public BDTableOrPattern RotateFor11And12_UL()
        {
            BDTableOrPattern result = new BDTableOrPattern();
            result.SetB(MiscMethods.CopyArray(this.ColumnB));
            int t = result.ColumnB[0]; result.ColumnB[0] = result.ColumnB[1]; result.ColumnB[1] = t;
            t = result.ColumnB[2]; result.ColumnB[2] = result.ColumnB[3]; result.ColumnB[3] = t;
            for (int i = 0; i < ColumnsD.Count; i++)
            {
                result.AddD(MiscMethods.CopyArray(this.ColumnsD[i]));
                t = result.ColumnsD[i][0]; result.ColumnsD[i][0] = result.ColumnsD[i][1]; result.ColumnsD[i][1] = t;
                t = result.ColumnsD[i][2]; result.ColumnsD[i][2] = result.ColumnsD[i][3]; result.ColumnsD[i][3] = t;

            }
            return result;
        }

        public BDTableOrPattern RotateFor11And12_U()
        {
            BDTableOrPattern result = new BDTableOrPattern();
            result.SetB(MiscMethods.CopyArray(this.ColumnB));
            int t = result.ColumnB[0]; result.ColumnB[0] = result.ColumnB[1]; result.ColumnB[1] = t;
           
            for (int i = 0; i < ColumnsD.Count; i++)
            {
                result.AddD(MiscMethods.CopyArray(this.ColumnsD[i]));
                t = result.ColumnsD[i][0]; result.ColumnsD[i][0] = result.ColumnsD[i][1]; result.ColumnsD[i][1] = t;
                

            }
            return result;
        }

        public BDTableOrPattern RotateFor11And12_L()
        {
            BDTableOrPattern result = new BDTableOrPattern();
            result.SetB(MiscMethods.CopyArray(this.ColumnB));
            int 
            t = result.ColumnB[2]; result.ColumnB[2] = result.ColumnB[3]; result.ColumnB[3] = t;
            for (int i = 0; i < ColumnsD.Count; i++)
            {
                result.AddD(MiscMethods.CopyArray(this.ColumnsD[i]));                
                t = result.ColumnsD[i][2]; result.ColumnsD[i][2] = result.ColumnsD[i][3]; result.ColumnsD[i][3] = t;

            }
            return result;
        }
        public BDTableOrPattern RotateFor9_L()
        {
            BDTableOrPattern result = new BDTableOrPattern();
            result.SetB(MiscMethods.CopyArray(this.ColumnB));
            int
            t = result.ColumnB[2]; result.ColumnB[2] = result.ColumnB[1]; result.ColumnB[1] = t;
            for (int i = 0; i < ColumnsD.Count; i++)
            {
                result.AddD(MiscMethods.CopyArray(this.ColumnsD[i]));
                t = result.ColumnsD[i][2]; result.ColumnsD[i][2] = result.ColumnsD[i][1]; result.ColumnsD[i][1] = t;

            }
            return result;
        }


        public static List<BDTableOrPattern> BD_PatternsForLength(int Length)
        {
            if (Length < 8 && Length > 28)
                return null;

            if (8 <= Length && Length<=9)
                return BD_PatternsFor[9 - 1];

            if (10 <= Length && Length <= 12)
                return BD_PatternsFor[12 - 1];

            if (13 == Length || Length == 15)
                return BD_PatternsFor[15 - 1];

            if (Length == 14)
                return BD_PatternsFor[14 - 1];

            if (16 <= Length && Length <= 18)
                return BD_PatternsFor[18 - 1];

            if (19 <= Length && Length <= 21)
                return BD_PatternsFor[21 - 1];

            if (22 <= Length && Length <= 24)
                return BD_PatternsFor[24 - 1];

            if (25 <= Length && Length <= 27)
                return BD_PatternsFor[27 - 1];            
            return BD_PatternsFor[30 - 1];

        }

        public static void InitializePatterns()
        {
            InitializeTables();
            BD_PatternsFor = new List<BDTableOrPattern>[31];
            for (int i = 7; i < 31; i++)
            {
                BD_PatternsFor[i] = new List<BDTableOrPattern>();
            }

            for (int i = 0; i < AllBDPatternTablesFor9.Count; i++)
            {
                BDTableOrPattern TempBDTableOrPattern = AllBDPatternTablesFor9[i];
                BDTableOrPattern TempBDTableOrPattern28Minus = TempBDTableOrPattern.Get28MinusBDTableOrPattern();

                BD_PatternsFor[9 - 1].Add(TempBDTableOrPattern);
                BD_PatternsFor[9 - 1].Add(TempBDTableOrPattern28Minus);
                BD_PatternsFor[9 - 1].Add(TempBDTableOrPattern.RotateFor9_L());
                BD_PatternsFor[9 - 1].Add(TempBDTableOrPattern28Minus.RotateFor9_L());

            }
            for (int i = 0; i < AllBDPatternTablesFor11And12.Count; i++)
            {
                BDTableOrPattern TempBDTableOrPattern = AllBDPatternTablesFor11And12[i];
                BDTableOrPattern TempBDTableOrPattern28Minus = TempBDTableOrPattern.Get28MinusBDTableOrPattern();

                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern);
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern28Minus);
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern.RotateFor11And12_L());
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern28Minus.RotateFor11And12_L());
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern.RotateFor11And12_U());
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern28Minus.RotateFor11And12_U());
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern.RotateFor11And12_UL());
                BD_PatternsFor[12 - 1].Add(TempBDTableOrPattern28Minus.RotateFor11And12_UL());
            }
            for (int i = 0; i < AllBDPatternTablesFor14.Count; i++)
            {
                BDTableOrPattern TempBDTableOrPattern = AllBDPatternTablesFor14[i];
                BDTableOrPattern TempBDTableOrPattern28Minus = TempBDTableOrPattern.Get28MinusBDTableOrPattern();

                BD_PatternsFor[14 - 1].Add(TempBDTableOrPattern);
                BD_PatternsFor[14 - 1].Add(TempBDTableOrPattern28Minus);

                for (int j = 6; j < BDTableOrPattern.RepeatPatternsFor[4].Count; j++)
                for (int k = 0; k < TempBDTableOrPattern.ColumnB.Length ; k++)
                {

                    BDTableOrPattern T1 = BDTableOrPattern.ApplyARepeatPatternOnABDPatternTablesFor14(BDTableOrPattern.RepeatPatternsFor[4][j], TempBDTableOrPattern, k);
                    BD_PatternsFor[14 - 1].Add(T1);
                    BDTableOrPattern T2 = BDTableOrPattern.ApplyARepeatPatternOnABDPatternTablesFor14(BDTableOrPattern.RepeatPatternsFor[4][j], TempBDTableOrPattern28Minus, k);
                    BD_PatternsFor[14 - 1].Add(T2);
                }
              
            }

            for (int i = 0; i < AllBDPatternTablesFor11And12.Count; i++)                 
            {
                BDTableOrPattern TempBDTableOrPattern = AllBDPatternTablesFor11And12[i];
                BDTableOrPattern TempBDTableOrPattern28Minus = TempBDTableOrPattern.Get28MinusBDTableOrPattern();
                for (int j = 5; j < 11; j++)
                {
                    BD_PatternsFor[j * 3 - 1].Add(TempBDTableOrPattern);
                    BD_PatternsFor[j * 3 - 1].Add(TempBDTableOrPattern28Minus);
                    for (int k = 6; k < BDTableOrPattern.RepeatPatternsFor[j].Count; k++)
                    {
                        BDTableOrPattern T1 = BDTableOrPattern.ApplyARepeatPatternOnABDPatternTablesFor11And12(BDTableOrPattern.RepeatPatternsFor[j][k], TempBDTableOrPattern);
                        BD_PatternsFor[j * 3 - 1].Add(T1);
                        BDTableOrPattern T2 = BDTableOrPattern.ApplyARepeatPatternOnABDPatternTablesFor11And12(BDTableOrPattern.RepeatPatternsFor[j][k], TempBDTableOrPattern28Minus);
                        BD_PatternsFor[j * 3 - 1].Add(T2);
                    }
                }
            }

        }

        //public static List<BDTableOrPattern> AddBDPatternsFor14(List<BDTableOrPattern> BD_PatternsFor14, BDTableOrPattern BDTP)
        //{
        //    int Length = BDTP.ColumnB.Length;
        //    int[] OptionForColumnB = new int[5];
        //    OptionForColumnB[0] = BDTP.ColumnB[0]; OptionForColumnB[1] = BDTP.ColumnB[1];
        //    OptionForColumnB[4] = BDTP.ColumnB[Length - 1]; OptionForColumnB[1] = BDTP.ColumnB[Length-2];
        //    for (int i = 0; i < Length - 4; i++)
        //    {
        //        BDTableOrPattern OptionForBAndOptionsForD = new BDTableOrPattern();
        //        OptionForBAndOptionsForD.ClearD();
        //        OptionForBAndOptionsForD.SetB(MiscMethods.CopyArray(OptionForColumnB));
        //        OptionForColumnB[2] = BDTP.ColumnB[2 + i];
        //        for (int j = 0; j < BDTP.ColumnsD.Count ; j++)
        //        {
        //            int[] OptionForColumnD = new int[5];
        //            OptionForColumnD[0] = BDTP.ColumnsD[j][0]; OptionForColumnD[1] = BDTP.ColumnsD[j][1];
        //            OptionForColumnD[4] = BDTP.ColumnsD[j][Length - 1]; OptionForColumnD[1] = BDTP.ColumnsD[j][Length - 2];
        //            OptionForColumnD[2] = BDTP.ColumnsD[j][2 + i];
        //            OptionForBAndOptionsForD.AddD(MiscMethods.CopyArray(OptionForColumnD));

        //        }
        //        BD_PatternsFor14.Add(OptionForBAndOptionsForD);
        //    }
        //    return BD_PatternsFor14;
        //}

        public int[] ColumnB;
        public List<int[]> ColumnsD;

        public static List<BDTableOrPattern>[] BD_PatternsFor;// = new List<BDTableOrPattern>[28];

        //public static List<BDTableOrPattern> BD_PatternsFor9 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor11And12 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor14 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor18 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor20 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor26 = new List<BDTableOrPattern>();
        //public static List<BDTableOrPattern> BD_PatternsFor28 = new List<BDTableOrPattern>();

    }
        
    public class InputManagement
    {
        public static int[] PatternForDistancesForBArrayRequirement;
        public static Form FrmInputManagment;
        public static DataGridView DGV;
        public static ListBox LB;
        public static IntSet AllLetters = new IntSet();
        public static List<int[]> PossibleQuadrapleSummations = new List<int[]>();
        public static IntSet RemainingLetters = new IntSet();
        public static void ProcessAGeneratedInput(int Length, int A, int B, int C, int D, int[] InputArray)
        {
            DGV.Rows.Add();

            int index = DGV.Rows.Count - 1;
            string s = FormInputManagment.GetInputText(InputArray);
            int Rank = Boddooh101Table.Conditions_InputManagment(InputArray);

            DGV.Rows[index].Cells[1].Value = Rank.ToString();
            //FormInputManagment.AddTextTolistIM(
            //LB.Items.Add(s);
            DGV.Rows[index].Cells[0].Value = s;

        }

        //public void AddTextTolistIM(string s)
        //{
        //    if (LB.InvokeRequired)
        //    {
        //        stringDelegate sd = new stringDelegate(AddTextTolistIM);
        //        this.Invoke(sd, new object[] { s });
        //    }
        //    else
        //    {
        //        LB.Items.Add(s);
        //    }
        //}

        //public static IntSet RemainingLetters = new IntSet();
        public static List<int[]> AllPossiblePentuplesOfAllLetters = new List<int[]>();
        //public static List<int[]> AllPossibleTuplesOfRemainingLetters = new List<int[]>();
        
        public static List<int[]> GenerateAllInputs(int Length, int StartLetter)//Ok
        {
            List<int[]> All_ABCDs = AllBoddooh4By4Tables.GetAllFirstBoddooh4By4TablesStartingWithA(StartLetter);

            List<int[]> result = new List<int[]>();
            for (int i = 0; i < All_ABCDs.Count; i++)
            {
                int[] ABCD = All_ABCDs[i];
                List<int[]> TempResult = GenerateAllInputs(Length, ABCD[0], ABCD[1], ABCD[2], ABCD[3]);
                result.AddRange(TempResult);
            }
            return result;

        }

        public static List<int[]> GenerateAllInputs(int Length, int A, int B, int C, int D)//ok
        {
            //PossibleQuadrapleSummations = GetAllPossibleQuadrapleSummations(Length, A, B, C, D);
            RemainingLetters = GetRemainingLetters(A, B, C, D);
            
            List<int[]> AllPossibleTuplesOfRemainingLetters = InputManagement.GetAllPermutations(2, RemainingLetters);

            List<int[]> AllB4B4TablesSummationArrays = GetB4B4TablesSummationArray(Length, A, B, C, D, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            //if (AllB4B4TablesSummationArrays.Count > 0)
            //    MessageBox.Show(A.ToString()+" " + B.ToString()+" " +  C.ToString()+" " +  D.ToString()+" ");
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < AllB4B4TablesSummationArrays.Count; i++)
            {
                int[] B4B4TablesSummationArray = AllB4B4TablesSummationArrays[i];
                //if (MiscMethods.ArraysAreTheSame(B4B4TablesSummationArray, new int[] { 176, 188, 244, 240, 184, 248, 264, 248, 208, 256, 124, 224 }))
                //{                //    int e = 33;                                    //}
                List<int[]> TempResult = GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArray(Length, A, B, C, D, B4B4TablesSummationArray);
                result.AddRange(TempResult);                
            }
            return result;            
        }
      
        public static void Initialize(Form frm)//ok
        {
            FrmInputManagment = frm;
            AllBoddooh4By4Tables.Initialize();
            PatternForDistancesForBArrayRequirement = new int[] { 2,1,2,2,1,2,1,1,2,1,2,2,1,2};
            AllLetters = new IntSet();
            for (int i = 1; i <= 28; ++i)
            {
                AllLetters.Add(i);
            }
            //AllPossiblePentuplesOfAllLetters = InputManagment.GetAllPermutations(5, AllLetters);
            AllPossiblePentuplesOfAllLetters = InputManagement.GetAllPermutations(5, AllLetters);

            PatternsForBAndDInputManagment.Initialize();
            IntSubarrayForBAndD.Initialize();
            BDTableOrPattern.InitializePatterns();

            //int[,] a = new int[85,85];
            //for (int i = 0; i < 85; ++i)
            //for (int j = 0; j < 85; ++j)
            //    a[i,j] =0;
            //for (int i = 0; i < AllPossiblePentuplesOfAllLetters.Count; ++i)
            //{
            //    int[] APentuple = AllPossiblePentuplesOfAllLetters[i];
            //    int B0 = AllBoddooh4By4Tables.GetB4B4Table(APentuple[0], APentuple[1], APentuple[2], APentuple[3]).SummationOfItems;
            //    if (B0 == 70)
            //    {
            //        int f4 = 0;
                    
            //    }
            //    int B1 = AllBoddooh4By4Tables.GetB4B4Table(APentuple[1], APentuple[2], APentuple[3], APentuple[4]).SummationOfItems;
            //    if (B0%4!=0)
            //        MessageBox.Show("   ********");
            //    if (B1 % 4 != 0 || B1<64)
            //        MessageBox.Show("   ********");

            //    B0 = (B0 - 64) / 4;
            //    B1 = (B1 - 64) / 4;
            //    a[B0, B1] = 1;
            //}
            //int C =0;
            //string s = "";
            //for (int i = 0; i < 85; ++i)
            //{
            //    for (int j = 0; j < 85; ++j)
            //    {
            //        if (a[i, j] == 0)
            //        {
            //            C++;
            //            s += ("0");
            //        }
            //        else
            //        {
            //            s += ("1");
            //        }
            //    }
            //    s+= (" $$  ");
            //}
            //MessageBox.Show(C.ToString() + "   ********");
        }       
        
        public static List<int[]> GetAllPossibleQuadrapleSummations(int Length, int A, int B, int C, int D)
        {
            int MinorAbjadSummation = GetMinorAbjadSummation(Length, A);
            
            List<int> OptionsForMinorAbjadSummation = new List<int>();
            OptionsForMinorAbjadSummation.Add(MinorAbjadSummation);
            OptionsForMinorAbjadSummation.Add(MinorAbjadSummation-28);
            if (Length != 28)
                OptionsForMinorAbjadSummation.Add(MinorAbjadSummation + 28);

            List<int[]> result = new List<int[]>();
            for (int i = 0; i < OptionsForMinorAbjadSummation.Count; i++)
            {
                List<int[]> TempResult = GetAllPossibleQuadrapleSummationsForAGivenMinorAbjadSummation(Length, A, B, C, D, OptionsForMinorAbjadSummation[i]);
                result.AddRange(TempResult);
            }
            return result;
        }

        public static List<int[]> GetAllPossibleQuadrapleSummationsForAGivenMinorAbjadSummation(int Length, int A, int B, int C, int D, int MinorAbjadSummation)
        {            
            int LastLetter = GetLastLetter(A);

            int QSALength = 2 * (Length / 8);
            if (QSALength % 4 != 0)
                QSALength++;

            List<int[]> result = new List<int[]>();

            int[] QuadrapleSummationsArray = new int[QSALength];
            QuadrapleSummationsArray[QSALength - 1] = (A + B + C + LastLetter);
            for (int i = -28; i <= 28; i++)
            {
                if (InputManagement.IsASpecialNumber(i))
                {
                    QuadrapleSummationsArray[0] = QuadrapleSummationsArray[QSALength - 1] + i;
                    List<int[]> TempResult = CompleteQuadrapleSummations(MinorAbjadSummation, QuadrapleSummationsArray, 1, QSALength - 2);
                    result.AddRange(TempResult);
                }            
            }
            return result;
        }
        public static List<int[]> CompleteQuadrapleSummations(int MinorAbjadSummation, int[] QuadrapleSummationsArray, int FromIndex, int ToIndex)
        {
            List<int[]> result = new List<int[]>();
            int DL = 20;
            int DR = 9;
            if (FromIndex % 2 == 0)
            {
                DL = 9;
                DR = 20;
            }
            int RemainingLength = ToIndex - FromIndex + 1;
            int RemainingSum = MinorAbjadSummation;
            for (int i=0;i<QuadrapleSummationsArray.Length;i++)
                if (i < FromIndex || i > ToIndex)
                    RemainingSum -= QuadrapleSummationsArray[i];

            if (RemainingLength == 0)
            {
                if (RemainingSum==0)
                {
                    result.Add(MiscMethods.CopyArray(QuadrapleSummationsArray));
                }
            }
 
            if (RemainingLength == 1)
            {
                if (RemainingSum>0)
                {
                    QuadrapleSummationsArray[QuadrapleSummationsArray.Length/2] = RemainingSum;
                    result.Add(MiscMethods.CopyArray(QuadrapleSummationsArray));
                }
            }
            if (RemainingLength > 1)
            {                
                int L = QuadrapleSummationsArray[FromIndex-1];
                int R = QuadrapleSummationsArray[ToIndex+1];
                int L1 = L + DL; int R1 = R + DR;
                int L2 = L + DL; int R2 = R - DR;
                int L3 = L - DL; int R3 = R + DR;
                int L4 = L - DL; int R4 = R - DR;
                if (IsASpecialNumber(Math.Abs(L1 - R1)))
                {
                    QuadrapleSummationsArray[FromIndex] = L1;QuadrapleSummationsArray[ToIndex] = R1;
                    List<int[]> TempResult = CompleteQuadrapleSummations(MinorAbjadSummation, QuadrapleSummationsArray, FromIndex+1, ToIndex - 1);
                    result.AddRange(TempResult);
                }
                if (IsASpecialNumber(Math.Abs(L2 - R2)))
                {
                    QuadrapleSummationsArray[FromIndex] = L2;QuadrapleSummationsArray[ToIndex] = R2;
                    List<int[]> TempResult = CompleteQuadrapleSummations(MinorAbjadSummation, QuadrapleSummationsArray, FromIndex+1, ToIndex - 1);
                    result.AddRange(TempResult);
                }
                if (IsASpecialNumber(Math.Abs(L3 - R3)))
                {
                    QuadrapleSummationsArray[FromIndex] = L3;QuadrapleSummationsArray[ToIndex] = R3;
                    List<int[]> TempResult = CompleteQuadrapleSummations(MinorAbjadSummation, QuadrapleSummationsArray, FromIndex+1, ToIndex - 1);
                    result.AddRange(TempResult);
                }
                if (IsASpecialNumber(Math.Abs(L4 - R4)))
                {
                    QuadrapleSummationsArray[FromIndex] = L4;QuadrapleSummationsArray[ToIndex] = R4;
                    List<int[]> TempResult = CompleteQuadrapleSummations(MinorAbjadSummation, QuadrapleSummationsArray, FromIndex+1, ToIndex - 1);
                    result.AddRange(TempResult);
                }
            }

            return result;
        }

        public static int[] Clause14ArrayToInputArray(int[] Clause14Array)
        {
            int Length = Clause14Array.Length;
            int[] result = new int[Length];
            result[0] = Clause14Array[Length - 3]; result[1] = Clause14Array[Length - 2]; result[2] = Clause14Array[Length - 1];
            for (int i = 3; i < Length; i++)
            {
                result[i] = Clause14Array[i - 3];
            }
            return result;

        }
        
        //public static List<int[]> CompleteClause14ArrayOldVersion(int Length, int A, int B, int C, int D, int[] Clause14Array, int FromIndex, int ToIndex, int[] B4B4TablesSummationArray, int[] QuadrapleSummation)//ok
        //{
        //    List<int[]> result = new List<int[]>();

        //    IntSet RemainingLettersUpToNow = GetRemainingLetters(Clause14Array[Length - 3], Clause14Array[Length - 2], Clause14Array[Length - 1], Clause14Array[0]);
        //    for (int i = 1; i < Length-4; i++)
        //        if (i < FromIndex || i > ToIndex)
        //            RemainingLettersUpToNow.Remove(Clause14Array[i]);

        //    int RemainingLength = ToIndex - FromIndex + 1;
        //    if (RemainingLength == 0)
        //    {
        //        result.Add(MiscMethods.CopyArray(Clause14Array));
        //        ProcessAGeneratedInput(Length, A, B, C, D, Clause14ArrayToInputArray(Clause14Array));

        //    }
        //    if (RemainingLength>0 && RemainingLength < 8)
        //    {
        //        int RemainingSum = MiscMethods.MiddleElement(QuadrapleSummation);
        //        List<int[]> ArraysForMiddlePart = GetAllArraysOfItemsWithAGivenSummation(RemainingLength, RemainingSum, RemainingLettersUpToNow);
        //        for (int i = 0; i < ArraysForMiddlePart.Count; i++)
        //        {
        //            int[] MiddlePartArray = ArraysForMiddlePart[i];
        //            Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, MiddlePartArray, FromIndex);
        //            bool Ok = false;
        //            if (RemainingLength == 1)
        //            {
        //                if (CheckForClause13(MiscMethods.MiddleElement(Clause14Array)))
        //                    Ok = true;
        //            }
        //            if (RemainingLength == 2)
        //            {
        //                if (CheckForClause13(Clause14Array[FromIndex], Clause14Array[ToIndex]))
        //                    Ok = true;
        //            }
        //            if (RemainingLength == 3)
        //            {
        //                if (CheckForClause13(Clause14Array[FromIndex], Clause14Array[ToIndex]))
        //                    if (CheckForClause13(MiscMethods.MiddleElement(Clause14Array)))
        //                        Ok = true;
        //            }
        //            if (RemainingLength == 4)
        //            {
        //               // if (MiddlePartArray[0] == 26 && MiddlePartArray[1] == 13 && MiddlePartArray[2] == 16 && MiddlePartArray[3] == 6)
        //                 //   MessageBox.Show("");
        //                if (CheckForClause13(Clause14Array[FromIndex] + Clause14Array[FromIndex + 1], Clause14Array[ToIndex - 1] + Clause14Array[ToIndex]))
        //                    Ok = true;
        //            }
        //            if (RemainingLength == 6)
        //            {
        //                if (CheckForClause13(Clause14Array[FromIndex] + Clause14Array[FromIndex + 1] + Clause14Array[FromIndex + 2],
        //                    Clause14Array[ToIndex - 2] + Clause14Array[ToIndex - 1] + Clause14Array[ToIndex]))
        //                    Ok = true;
        //            }
        //            if (Ok)
        //            {
        //                bool StillOk = true;
        //                Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, MiddlePartArray, FromIndex);
        //                for (int k = 0; k < RemainingLength; k++)
        //                {
        //                    Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table
        //                        (Clause14Array[FromIndex + k - 3], Clause14Array[FromIndex + k - 2], Clause14Array[FromIndex + k - 1], Clause14Array[FromIndex + k]);
        //                    if (B4B4T.SummationOfItems != B4B4TablesSummationArray[FromIndex + k])
        //                    {
        //                        StillOk = false;
        //                        break;
        //                    }
        //                }
        //                if (StillOk)
        //                {
        //                    result.Add(MiscMethods.CopyArray(Clause14Array));                                                        //string s = Abjad.LettersArrayToString(MiscMethods.CopyArray(Clause14Array));                           // MessageBox.Show(s);
        //                    ProcessAGeneratedInput(Length, A, B, C, D, Clause14ArrayToInputArray(Clause14Array));
        //                }
        //            }
        //        }
        //    }
               
        //    if (RemainingLength >=8)
        //    {
        //        int n = FromIndex / 4;
        //        int SumForLeftQuadraple = QuadrapleSummation[n];
        //        int SumForRightQuadraple = QuadrapleSummation[QuadrapleSummation.Length - 1 - n];

        //        List<int[]> OptionsForLeftQuadraple = GetAllArraysOfItemsWithAGivenSummation(4, SumForLeftQuadraple, RemainingLettersUpToNow);
        //        for (int index = OptionsForLeftQuadraple.Count - 1; index >= 0; index--)
        //        {
        //            int[] AnOptionForLeftQuadraple = OptionsForLeftQuadraple[index];
        //            Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, AnOptionForLeftQuadraple, FromIndex);
        //            for (int k = 0; k < 4; k++)
        //            {
        //                Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table
        //                    (Clause14Array[FromIndex+k - 3], Clause14Array[FromIndex+k - 2], Clause14Array[FromIndex+k- 1], Clause14Array[FromIndex+k]);
        //                if (B4B4T.SummationOfItems!=B4B4TablesSummationArray[FromIndex+k])
        //                {
        //                    OptionsForLeftQuadraple.RemoveAt(index);
        //                    break;
        //                }
        //            }
        //        }
               
        //        //List<int[]> OptionsForBoth = new List<int[]>();
        //        for (int i = 0; i < OptionsForLeftQuadraple.Count; i++)
        //        {
        //            int[] AnOptionForLeftQuadraple = OptionsForLeftQuadraple[i];
        //            RemainingLettersUpToNow.Remove(AnOptionForLeftQuadraple[0], AnOptionForLeftQuadraple[1], AnOptionForLeftQuadraple[2], AnOptionForLeftQuadraple[3]);
        //            List<int[]> OptionsForRightQuadraple = GetAllArraysOfItemsWithAGivenSummation(4, SumForRightQuadraple, RemainingLettersUpToNow);
        //            for (int index = OptionsForRightQuadraple.Count - 1; index >= 0; index--)
        //            {
        //                int[] AnOptionForRightQuadraple = OptionsForRightQuadraple[index];
        //                Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, AnOptionForLeftQuadraple, ToIndex - 3);
        //                for (int k = 0; k < 4; k++)
        //                {
        //                    Boddooh4By4Table B4B4T = AllBoddooh4By4Tables.GetB4B4Table
        //                        (Clause14Array[ToIndex - k - 3], Clause14Array[ToIndex - k - 2], Clause14Array[ToIndex - k - 1], Clause14Array[ToIndex - k]);
        //                    if (B4B4T.SummationOfItems != B4B4TablesSummationArray[ToIndex - k])
        //                    {
        //                        OptionsForRightQuadraple.RemoveAt(index);
        //                        break;
        //                    }
        //                }
        //            }
        //            for (int j = 0; j < OptionsForRightQuadraple.Count; j++)
        //            {
        //                int[] AnOptionForRightQuadraple = OptionsForRightQuadraple[j];

        //                Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, AnOptionForLeftQuadraple, FromIndex);
        //                Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, AnOptionForLeftQuadraple, ToIndex - 3);
        //                List<int[]> TempResult = CompleteClause14Array(Length, A, B, C, D, Clause14Array, FromIndex + 4, ToIndex - 4, B4B4TablesSummationArray, QuadrapleSummation);
        //                result.AddRange(TempResult);

        //            }
        //            RemainingLetters.Add(AnOptionForLeftQuadraple[0], AnOptionForLeftQuadraple[1], AnOptionForLeftQuadraple[2], AnOptionForLeftQuadraple[3]);
        //        }
        //    }
        //    return result;
        //}       

        public static bool CheckForClause13(int c)//ok
        {
            //return true;
            if (c < 0)
                c = MiscMethods.EquivalentNumber(c);
            if (c % 28 == 0)
                return true;
            if (MiscMethods.IsK9Plus2(c % 28))
                return true;
            if (MiscMethods.IsK9Plus8(c % 28))
                return true;
            return false;

        }

        public static bool SummationOrDistanceIsASpecialNumber(int a, int b)//ok
        {
            return (IsASpecialNumber(a + b) || IsASpecialNumber(Math.Abs(a - b)));

        }

        public static bool SummationOrDistanceIsAVerySpecialNumber(int a, int b)//ok
        {
            return (IsAVerySpecialNumber(a + b) || IsAVerySpecialNumber(Math.Abs(a - b)));

        }

        public static bool IsASpecialNumber(int c)//ok
        {
            if (c < 0)
                c = MiscMethods.EquivalentNumber(c);
            if (c % 28 == 0)
                return true;
            if (MiscMethods.IsK9Plus2(c % 28))
                return true;
            if (MiscMethods.IsK9Plus8(c % 28))
                return true;
            return false;

        }

        public static bool IsAVerySpecialNumber(int c)//ok
        {
            if (c < 0)
                c = MiscMethods.EquivalentNumber(c);
            if (c % 28 == 0)
                return true;
            if (MiscMethods.IsK9Plus2(c % 28))
                return true;
            if (MiscMethods.IsK9Plus8(c % 28))
                return true;
            if (MiscMethods.IsK28Plus20OrK28Minus20(c))
                return true;

            return false;

        }
        
        public static bool CheckForClause13(int Left, int Right)//ok
        {

            //return (CheckForClause13(Right - Left) || CheckForClause13(Right + Left));
            return (CheckForClause13(Math.Abs(Right - Left)) || CheckForClause13(Right + Left));
        }

        //public static List<int[]> GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArrayAndAGivenQuadrapleSummation(int Length, int A, int B, int C, int D, int[] B4B4TablesSummationArray, int[] QuadrapleSummation)//ok
        //{
        //    int LastLetter = GetLastLetter(A);
        //    List<int[]> result = new List<int[]>();

        //    int[] Clause14Array = new int[Length];
        //    Clause14Array[0] = D; Clause14Array[Length - 1] = C; Clause14Array[Length - 2] = B; Clause14Array[Length - 3] = A; Clause14Array[Length - 4] = LastLetter;

        //    List<int[]> Arrays = GetAllArraysOfItemsWithAGivenSummation(3, QuadrapleSummation[0] - D, RemainingLetters);
        //    List<int[]> OptionsForFourFirstElements = new List<int[]>();
        //    for (int i = 0; i < Arrays.Count; i++)
        //    {
        //        int[] Array = Arrays[i];
        //        Boddooh4By4Table B4B4T1 = AllBoddooh4By4Tables.GetB4B4Table(B, C, D, Array[0]);
        //        Boddooh4By4Table B4B4T2 = AllBoddooh4By4Tables.GetB4B4Table(C, D, Array[0], Array[1]);
        //        Boddooh4By4Table B4B4T3 = AllBoddooh4By4Tables.GetB4B4Table(D, Array[0], Array[1], Array[2]);
        //        if (B4B4T1.SummationOfItems == B4B4TablesSummationArray[1] &&
        //            B4B4T2.SummationOfItems == B4B4TablesSummationArray[2] &&
        //            B4B4T3.SummationOfItems == B4B4TablesSummationArray[3])
        //        {
        //            int[] Temp = new int[4]; Temp[0] = D; Temp[1] = Array[0]; Temp[2] = Array[1]; Temp[3] = Array[2];
        //            OptionsForFourFirstElements.Add(Temp);
        //        }                
        //    }
        //    for (int i = 0; i < OptionsForFourFirstElements.Count; i++)
        //    {
        //        int[] AnOptionForFourFirstElements = OptionsForFourFirstElements[i];
        //        Clause14Array = MiscMethods.CopySubarrayIntoArray(Clause14Array, AnOptionForFourFirstElements, 0);
        //        List<int[]> TempResult = CompleteClause14Array(Length, A, B, C, D, Clause14Array, 4,  Length - 5, B4B4TablesSummationArray, QuadrapleSummation);
                
        //        result.AddRange(TempResult);
        //    }

        //    return result;
        //}

        public static List<int[]> CompleteClause14Array(int[] Clause14Array, int FromIndex, int[] B4B4TablesSummationArray, IntSet RemainingLettersTillNow)//ok
        {
            int Length = Clause14Array.Length;
            List<int> Options = new List<int>();

            for (int i = 0; i < RemainingLettersTillNow.Members.Count; i++)
            {
                int Letter = RemainingLettersTillNow.Members[i];
                if (MiscMethods.EquivalentNumber(16 * Letter) == MiscMethods.EquivalentNumber(B4B4TablesSummationArray[FromIndex+3]))
                {
                    Boddooh4By4Table B4B4T = new Boddooh4By4Table(Letter, Clause14Array[FromIndex + 1], Clause14Array[FromIndex + 2], Clause14Array[FromIndex + 3]);
                    if (B4B4T.SummationOfItems == B4B4TablesSummationArray[FromIndex+3])
                    {
                        Options.Add(Letter);
                    }
                }                    
            }      

            List<int[]> result = new List<int[]>();
            for (int i = 0; i < Options.Count; i++)
            {
                int Letter = Options[i];
                Clause14Array[FromIndex] = Letter;                
                if (FromIndex == 1)
                {

                    int[] TempArray = Clause14ArrayToInputArray(Clause14Array);
                    ((FormInputManagment)(FrmInputManagment)).ProcessAGeneratedInput(Length, TempArray[0], TempArray[1], TempArray[2], TempArray[3], TempArray, 1);

                    //result.Add(MiscMethods.CopyArray(Clause14Array));
                }
                else
                {
                    RemainingLettersTillNow.Remove(Letter);
                    List<int[]> TempResult = CompleteClause14Array(Clause14Array, FromIndex-1, B4B4TablesSummationArray, RemainingLettersTillNow);
                    if (TempResult.Count > 0)
                        result.AddRange(TempResult);
                    RemainingLettersTillNow.Add(Letter);
                }
            }
            return result;
        }

        public static List<int[]> GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArray(int Length, int A, int B, int C, int D, int[] B4B4TablesSummationArray)//ok
        {
            List<int[]> result = new List<int[]>();

            int LastLetter = GetLastLetter(A);       
            int[] Clause14Array = new int[Length];
            Clause14Array[0] = D; Clause14Array[Length - 1] = C; Clause14Array[Length - 2] = B; Clause14Array[Length - 3] = A; Clause14Array[Length - 4] = LastLetter;

            IntSet RemainingLettersTillNow = RemainingLetters.Clone();
            int FromIndex = Length-5;
            result = CompleteClause14Array(Clause14Array, FromIndex, B4B4TablesSummationArray, RemainingLettersTillNow);
           
            return result;
        }
        //public static List<int[]> GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArrayOldVersion(int Length, int A, int B, int C, int D, int[] B4B4TablesSummationArray)//ok
        //{
        //    List<int[]> result = new List<int[]>();
        //    for (int i = 0; i < PossibleQuadrapleSummations.Count; i++)
        //    {
        //        int[] QuadrapleSummation = PossibleQuadrapleSummations[i];
        //        List<int[]> TempResult = GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArrayAndAGivenQuadrapleSummation(Length, A, B, C, D, B4B4TablesSummationArray, QuadrapleSummation);
        //        if (TempResult.Count > 0)
        //            result.AddRange(TempResult);
        //    }
        //    return result;
        //}

        public static List<int[]> GetB4B4TablesSummationArrayNewVersion(int Length, int A, int B, int C, int D, IntSet RemainingLetters, List<int[]> AllPossibleTuplesOfRemainingLetters)//ok
        {
            int LastLetter = GetLastLetter(A);
            int FirstB4B4TablesSummation = AllBoddooh4By4Tables.GetB4B4Table(A, B, C, D).SummationOfItems;
            int LastB4B4TablesSummation = AllBoddooh4By4Tables.GetB4B4Table(LastLetter, A, B, C).SummationOfItems;

            List<int[]> result = new List<int[]>();

            List<int[]> B_Patterns = new List<int[]>();
            List<int[]> B_PatternsMiddleElementFromUpperHalf = new List<int[]>();
            List<int[]> B_PatternsMiddleElementFromLowerHalf = new List<int[]>();

            List<int[]> D_Patterns = new List<int[]>();
            List<int[]> D_PatternsMiddleElementFromUpperHalf = new List<int[]>();
            List<int[]> D_PatternsMiddleElementFromLowerHalf = new List<int[]>();

            if (Length == 9)
            {
                B_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.B_Patterns9MiddleElementFromUpperHalf;
                B_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.B_Patterns9MiddleElementFromLowerHalf;
                D_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.D_Patterns9MiddleElementFromUpperHalf;
                D_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.D_Patterns9MiddleElementFromLowerHalf;
            }
            if (Length == 14)
            {
                B_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.B_Patterns14MiddleElementFromUpperHalf;
                B_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.B_Patterns14MiddleElementFromLowerHalf;
                D_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.D_Patterns14MiddleElementFromUpperHalf;
                D_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.D_Patterns14MiddleElementFromLowerHalf;
            }
            if (Length == 20)
            {
                B_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.B_Patterns20MiddleElementFromUpperHalf;
                B_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.B_Patterns20MiddleElementFromLowerHalf;
                D_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.D_Patterns20MiddleElementFromUpperHalf;
                D_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.D_Patterns20MiddleElementFromLowerHalf;
            }
            if (Length == 26)
            {
                B_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.B_Patterns26MiddleElementFromUpperHalf;
                B_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.B_Patterns26MiddleElementFromLowerHalf;
                D_PatternsMiddleElementFromUpperHalf = PatternsForBAndDInputManagment.D_Patterns26MiddleElementFromUpperHalf;
                D_PatternsMiddleElementFromLowerHalf = PatternsForBAndDInputManagment.D_Patterns26MiddleElementFromLowerHalf;
            }

            if (Length == 11)
            {
                B_Patterns = PatternsForBAndDInputManagment.B_Patterns11;
                D_Patterns = PatternsForBAndDInputManagment.D_Patterns11;
            }
            if (Length == 12)
            {
                B_Patterns = PatternsForBAndDInputManagment.B_Patterns12;
                D_Patterns = PatternsForBAndDInputManagment.D_Patterns12;
            }
            if (Length == 18)
            {
                B_Patterns = PatternsForBAndDInputManagment.B_Patterns18;
                D_Patterns = PatternsForBAndDInputManagment.D_Patterns18;
            }
            if (Length == 28)
            {
                B_Patterns = PatternsForBAndDInputManagment.B_Patterns28;
                D_Patterns = PatternsForBAndDInputManagment.D_Patterns28;
            }
            if (Length == 11 || Length == 12 || Length == 18 || Length == 28)
            {
                for (int i = 0; i < B_Patterns.Count; i++)
                {
                    int[] TheB_Pattern = B_Patterns[i];
                    for (int j = 0; j < D_Patterns.Count; j++)
                    {
                        int[] TheD_Pattern = D_Patterns[j];
                        List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, false, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
                        result.AddRange(TempResult);
                    }
                }
            }
            else
            {
                for (int i = 0; i < B_PatternsMiddleElementFromUpperHalf.Count; i++)
                {
                    int[] TheB_Pattern = B_PatternsMiddleElementFromUpperHalf[i];
                    for (int j = 0; j < D_PatternsMiddleElementFromUpperHalf.Count; j++)
                    {
                        int[] TheD_Pattern = D_PatternsMiddleElementFromUpperHalf[j];
                        List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, true, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
                        result.AddRange(TempResult);
                    }
                }
                for (int i = 0; i < B_PatternsMiddleElementFromLowerHalf.Count; i++)
                {
                    int[] TheB_Pattern = B_PatternsMiddleElementFromLowerHalf[i];
                    for (int j = 0; j < D_PatternsMiddleElementFromLowerHalf.Count; j++)
                    {
                        int[] TheD_Pattern = D_PatternsMiddleElementFromLowerHalf[j];
                        List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, false, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
                        result.AddRange(TempResult);
                    }
                }

            }

            return result;
        }

        public static List<int[]> GetB4B4TablesSummationArray(int Length, int A, int B, int C, int D, IntSet RemainingLetters, List<int[]> AllPossibleTuplesOfRemainingLetters)//ok
        {
            int LastLetter = GetLastLetter(A);
            int FirstB4B4TablesSummation = AllBoddooh4By4Tables.GetB4B4Table(A, B, C, D).SummationOfItems;
            int LastB4B4TablesSummation = AllBoddooh4By4Tables.GetB4B4Table(LastLetter, A, B, C).SummationOfItems;

            List<int[]> result = new List<int[]>();
            //List<int[]> B_Patterns= new List<int[]>();
            //List<int[]> D_Patterns= new List<int[]>();

            List<BDTableOrPattern> BD_Patterns = new List<BDTableOrPattern>();

            BD_Patterns = BDTableOrPattern.BD_PatternsForLength(Length);

            for (int i = 0; i < BD_Patterns.Count; i++)
            {
                BDTableOrPattern A_BD_Pattern = BD_Patterns[i];
                int[] TheB_Pattern = A_BD_Pattern.ColumnB;
                for (int j = 0; j < A_BD_Pattern.ColumnsD.Count; j++)
                {
                    int[] TheD_Pattern = A_BD_Pattern.ColumnsD[j];
                    List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, false, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
                    result.AddRange(TempResult);
                }
                
            }
            // Hazf Shod
            //////if (Length == 11 || Length == 12 || Length == 18 || Length == 28)
            //////{
            //////    for (int i = 0; i < B_Patterns.Count; i++)
            //////    {
            //////        int[] TheB_Pattern = B_Patterns[i];
            //////        for (int j = 0; j < D_Patterns.Count; j++)
            //////        {
            //////            int[] TheD_Pattern = D_Patterns[j];
            //////            List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, false, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            //////            result.AddRange(TempResult);
            //////        }
            //////    }
            //////}
            //////else
            //////{
            //////    for (int i = 0; i < B_PatternsMiddleElementFromUpperHalf.Count; i++)
            //////    {
            //////        int[] TheB_Pattern = B_PatternsMiddleElementFromUpperHalf[i];
            //////        for (int j = 0; j < D_PatternsMiddleElementFromUpperHalf.Count; j++)
            //////        {
            //////            int[] TheD_Pattern = D_PatternsMiddleElementFromUpperHalf[j];
            //////            List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, true, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            //////            result.AddRange(TempResult);
            //////        }
            //////    }
            //////    for (int i = 0; i < B_PatternsMiddleElementFromLowerHalf.Count; i++)
            //////    {
            //////        int[] TheB_Pattern = B_PatternsMiddleElementFromLowerHalf[i];
            //////        for (int j = 0; j < D_PatternsMiddleElementFromLowerHalf.Count; j++)
            //////        {
            //////            int[] TheD_Pattern = D_PatternsMiddleElementFromLowerHalf[j];
            //////            List<int[]> TempResult = GetB4B4TablesSummationArray(Length, A, B, C, D, FirstB4B4TablesSummation, LastB4B4TablesSummation, TheB_Pattern, TheD_Pattern, false, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            //////            result.AddRange(TempResult);
            //////        }
            //////    }

            //////}

            return result;
        }

        public static List<int[]> GetB4B4TablesSummationArray(int Length, int A, int B, int C, int D, int FirstB4B4TablesSummation, int LastB4B4TablesSummation, int[] PatternForColumnB, int[] PatternForColumnD, bool MiddleElementFromUpperHalf, IntSet RemainingLetters, List<int[]> AllPossibleTuplesOfRemainingLetters)//ok
        {
            List<int[]> result = new List<int[]>();
            List<int[]> B_Options = PatternsForBAndDInputManagment.GetB_Options(Length, A, B, C, D, PatternForColumnB, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            List<int[]> D_Options = PatternsForBAndDInputManagment.GetD_Options(Length, A, B, C, D, PatternForColumnD, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            for (int i = 0; i < B_Options.Count; i++)
            {
                int[] AnOptionForB = B_Options[i];
                for (int j = 0; j < D_Options.Count; j++)
                {
                    int[] AnOptionForD = D_Options[j];
                    if (PatternsForBAndDInputManagment.BAndD_ArraysCombinationIsOk(AnOptionForB, AnOptionForD))
                    {
                        if (PatternsForBAndDInputManagment.IsAValidPairForBAndDColumns(AnOptionForB, AnOptionForD))
                        {
                            List<int[]> TempResult = GetB4B4TablesSummationArrayForGivenOptionsForBAndD(Length, A, B, C, D,
                                FirstB4B4TablesSummation, LastB4B4TablesSummation, AnOptionForB, AnOptionForD, MiddleElementFromUpperHalf);
                            result.AddRange(TempResult);
                        }
                    }
                }
            }
            return result;
        }

        public static List<int[]> GetB4B4TablesSummationArrayForGivenOptionsForBAndD(int Length, int A, int B, int C, int D,
            int FirstB4B4TablesSummation, int LastB4B4TablesSummation, int[] AnOptionForB, int[] AnOptionForD, bool MiddleElementFromUpperHalf)//ok
        {
            List<int[]> result = new List<int[]>();
            List<int>[] Options = new List<int>[Length];
            int[] OptionsCount = new int[Length - 2];
            for (int index = 1; index < Length-1; index++)
            {
                int B_Value = AnOptionForB[index];
                int D_Value = AnOptionForD[index];
                Options[index] = GetAllB4B4TablesSummationsForAGivenBAndD(B_Value, D_Value);
                OptionsCount[index - 1] = Options[index].Count - 1;
            }
            Counter Counter = new Counter(Length - 2, 0, OptionsCount);
            int[] B4B4TablesSummation = new int[Length];

            B4B4TablesSummation[0] = FirstB4B4TablesSummation;
            B4B4TablesSummation[Length - 1] = LastB4B4TablesSummation;
            for (Counter.Restart(); !Counter.Done; Counter.Next())
            {
                for (int i = 0; i < Counter.CurrentValues.Length; i++)
                {
                    B4B4TablesSummation[i + 1] = Options[i+1][Counter.CurrentValues[i]];
                }
                if (IsAValidB4B4TablesSummationArray(Length, B4B4TablesSummation, MiddleElementFromUpperHalf))
                    result.Add(MiscMethods.CopyArray(B4B4TablesSummation));
            }
            return result;
        }
        public static bool IsAValidB4B4TablesSummationArray(int Length, int[] B4B4TablesSummation)//ok
        {
            int Summation = MiscMethods.ArrayItemsSummation(B4B4TablesSummation);
            if (Summation % 28 != 0)
                return false;
            int Direct = MiscMethods.JoinItemsAndModN(B4B4TablesSummation, 28);
            int Inverse = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4TablesSummation), 28);
            if (Direct == 20 && Inverse == 8)
                return true;
            if (Direct == 8 && Inverse == 20)
                return true;
            //if (Direct == 24 && Inverse == 4)
            //    return true;
            //if (Direct == 4 && Inverse == 24)
            //    return true;
            return false;

        }

        public static bool IsAValidB4B4TablesSummationArray(int Length, int[] B4B4TablesSummation, bool MiddleElementFromUpperHalf)//ok
        {
            //if (!IsAValidB4B4TablesSummationArray(Length, B4B4TablesSummation))
               // return false;
            int Count = Length / 6;
            int UpperSum = 0;
            int LowerSum = 0;
            for (int i = 0; i < Count; i++)
            {
                int Upper0 = B4B4TablesSummation[3*i];int Upper1 = B4B4TablesSummation[3*i+1];int Upper2 = B4B4TablesSummation[3*i+2];
                int Lower0 = B4B4TablesSummation[Length-1-(3*i)];int Lower1 = B4B4TablesSummation[Length-1-(3*i+1)];int Lower2 = B4B4TablesSummation[Length-1-(3*i+2)];
                int UpperDirect = MiscMethods.JoinDigits(Upper0, Upper1, Upper2);
                int UpperInverse = MiscMethods.JoinDigits(Upper2, Upper1, Upper0);
                int LowerDirect = MiscMethods.JoinDigits(Lower0, Lower1, Lower2);
                int LowerInverse = MiscMethods.JoinDigits(Lower2, Lower1, Lower0);

                if (UpperDirect % 28 != UpperInverse % 28)
                    return false;
                if (LowerDirect % 28 != LowerInverse % 28)
                    return false;

                UpperSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(UpperDirect));
                LowerSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(LowerDirect));
            }
            int RemainingLength = Length % 6;
            if (RemainingLength == 2)
            {
                if (MiddleElementFromUpperHalf)
                {
                    int Upper0 = B4B4TablesSummation[3 * Count]; int Upper1 = B4B4TablesSummation[3 * Count + 1];
                    int UpperDirect = MiscMethods.JoinDigits(Upper0, Upper1);
                    int UpperInverse = MiscMethods.JoinDigits(Upper1, Upper0);

                    if (UpperDirect % 28 != UpperInverse % 28)
                        return false;

                    UpperSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(UpperDirect));
                }
                else
                {
                    int Lower0 = B4B4TablesSummation[Length - 1 - (3 * Count)]; int Lower1 = B4B4TablesSummation[Length - 1 - (3 * Count + 1)];
                    int LowerDirect = MiscMethods.JoinDigits(Lower0, Lower1);
                    int LowerInverse = MiscMethods.JoinDigits(Lower1, Lower0);

                    if (LowerDirect % 28 != LowerInverse % 28)
                        return false;

                    LowerSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(LowerDirect));

                }
            }
            if (RemainingLength == 3)
            {
                if (MiddleElementFromUpperHalf)
                {
                    int Upper0 = B4B4TablesSummation[3*Count];int Upper1 = B4B4TablesSummation[3*Count+1];int Upper2 = B4B4TablesSummation[3*Count+2];
                    int UpperDirect = MiscMethods.JoinDigits(Upper0, Upper1, Upper2);
                    int UpperInverse = MiscMethods.JoinDigits(Upper2, Upper1, Upper0);

                    if (UpperDirect % 28 != UpperInverse % 28)
                        return false;
                                       
                    UpperSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(UpperDirect));                    
                }
                else
                {

                    int Lower0 = B4B4TablesSummation[Length-1-(3*Count)];int Lower1 = B4B4TablesSummation[Length-1-(3*Count+1)];int Lower2 = B4B4TablesSummation[Length-1-(3*Count+2)];
                    int LowerDirect = MiscMethods.JoinDigits(Lower0, Lower1, Lower2);
                    int LowerInverse = MiscMethods.JoinDigits(Lower2, Lower1, Lower0);

                    if (LowerDirect % 28 != LowerInverse % 28)
                        return false;

                    LowerSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(LowerDirect));

                }
            }

            
            if (RemainingLength == 4)
            {
                int Upper0 = B4B4TablesSummation[3*Count];int Upper1 = B4B4TablesSummation[3*Count+1];
                int Lower0 = B4B4TablesSummation[Length-1-(3*Count)];int Lower1 = B4B4TablesSummation[Length-1-(3*Count+1)];
                int UpperDirect = MiscMethods.JoinDigits(Upper0, Upper1);
                int UpperInverse = MiscMethods.JoinDigits( Upper1, Upper0);
                int LowerDirect = MiscMethods.JoinDigits(Lower0, Lower1);
                int LowerInverse = MiscMethods.JoinDigits( Lower1, Lower0);

                if (UpperDirect % 28 != UpperInverse % 28)
                    return false;
                if (LowerDirect % 28 != LowerInverse % 28)
                    return false;

                UpperSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(UpperDirect));
                LowerSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(LowerDirect));
            }
            if (RemainingLength == 5)
            {
                int Upper0 = B4B4TablesSummation[3 * Count]; int Upper1 = B4B4TablesSummation[3 * Count + 1]; int Upper2 = B4B4TablesSummation[3 * Count + 2];
                int Lower0 = B4B4TablesSummation[Length - 1 - (3 * Count)]; int Lower1 = B4B4TablesSummation[Length - 1 - (3 * Count + 1)]; 
                int UpperDirect = MiscMethods.JoinDigits(Upper0, Upper1, Upper2);
                int UpperInverse = MiscMethods.JoinDigits(Upper2, Upper1, Upper0);
                int LowerDirect = MiscMethods.JoinDigits(Lower0, Lower1);
                int LowerInverse = MiscMethods.JoinDigits( Lower1, Lower0);

                if (UpperDirect % 28 != UpperInverse % 28)
                    return false;
                if (LowerDirect % 28 != LowerInverse % 28)
                    return false;

                UpperSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(UpperDirect));
                LowerSum += MiscMethods.Equivalent1To9(MiscMethods.EquivalentNumber(LowerDirect));
            }
            if (!MiscMethods.IsK9Plus8(UpperSum + LowerSum))
                return false;
            if (!MiscMethods.IsK9Plus2(Math.Abs(UpperSum - LowerSum)))
                return false;

            return true; 
        }
        
        public static List<int> GetAllB4B4TablesSummationsForAGivenBAndD(int B_Value, int D_Value)//ok
        {
            List<int> result = new List<int>();
            for (int i = 0; i < AllBoddooh4By4Tables.AllPossibleSummations.Count; i++)
            {
                int Sum = AllBoddooh4By4Tables.AllPossibleSummations[i];
                if (B_Value == AllBoddooh4By4Tables.Get_B(Sum) && D_Value == AllBoddooh4By4Tables.Get_D(Sum))
                    result.Add(Sum);
            }
            return result;
        }

        public static int GetLastLetter(int FirstLetter)
        {
            return (FirstLetter - 1 + 3) % BoddoohNumbers.TwentyEight + 1;
        }

        public static IntSet GetRemainingLetters(int A, int B, int C, int D)//ok
        {
            IntSet result = new IntSet();
            int LastLetter = GetLastLetter(A);
            for (int i = 1; i <= 28; i++)
            {
                if (i != A && i != B && i != C && i != D && i != LastLetter)
                    result.Add(i);
            }           
            return result;
        }

        public static List<int[]> GetAllPermutations(int Length, IntSet UniversalSet)//ok
        {
            List<int[]> result = new List<int[]>();

            Counter Counter = new Counter(Length, 0, UniversalSet.Members.Count - 1);
            for (Counter.Restart(); !Counter.Done; Counter.Next())
            {
                if (!MiscMethods.ArrayContainsDuplicateElements(Counter.CurrentValues))
                {
                    int[] Temp = new int[Length];
                    for (int i = 0; i < Length; i++)
                        Temp[i] = UniversalSet.Members[Counter.CurrentValues[i]];
                    result.Add(Temp);
                }
            }

            return result;
        }

        public static List<int[]> GetAllArraysOfItemsWithAGivenSummation(int Length, int Summation, IntSet UniversalSet)//ok
        {
            List<int[]> result = new List<int[]>();

            Counter Counter = new Counter(Length, 0, UniversalSet.Members.Count-1);
            for (Counter.Restart(); !Counter.Done; Counter.Next())
            {
                if (!MiscMethods.ArrayContainsDuplicateElements(Counter.CurrentValues))
                {
                    int[] Temp = new int[Length];
                    int Sum = 0;
                    for (int i = 0; i < Length; i++)
                    {
                        Temp[i] = UniversalSet.Members[Counter.CurrentValues[i]];
                        Sum += Temp[i];
                    }
                    if (Sum == Summation)
                        result.Add(Temp);

                }
            }

            return result;
        }

        public static bool B4B4TablesSummationArrayIsValid(int Length, int A, int B, int C, int D, int[] B4B4TablesSummationArray)
        {
            int ArrayItemsSummation = MiscMethods.ArrayItemsSummation(B4B4TablesSummationArray);
            if (!MiscMethods.IsK28(ArrayItemsSummation))
                return true;
            int JoinItemsAndModN = MiscMethods.JoinItemsAndModN(B4B4TablesSummationArray, 28);
            int JoinItemsOfInverseArrayAndModN = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(B4B4TablesSummationArray), 28);
            if (MiscMethods.IsK28Minus20(JoinItemsAndModN) && MiscMethods.IsK28Plus20(JoinItemsOfInverseArrayAndModN))
                return true;
            if (MiscMethods.IsK28Minus20(JoinItemsOfInverseArrayAndModN) && MiscMethods.IsK28Plus20(JoinItemsAndModN))
                return true;
            return true;
        }
        
        public static int[] InputLengthArray = new int[] { 9, 11, 12, 14, 18, 20, 26, 28 };

        public static int GetMinorAbjadSummation(int Length, int FirstLetter)
        {
            int result = -1;
            int LastLetter = GetLastLetter(FirstLetter);
            if (Length == 6)
                result = 7 + LastLetter;
            if (Length == 9)
                result = 84 + LastLetter;
            if (Length == 11)
                result = 112 + LastLetter;
            if (Length == 12)
                result = 140 + LastLetter;
            if (Length == 14)
                result = 168 + LastLetter;
            if (Length == 18)
                result = 196 + LastLetter;
            if (Length == 20)
                result = 224 + LastLetter;
            if (Length == 26)
                result = 252 + LastLetter;
            if (Length == 28)
                result = 406;
            return result ;
        }
        


    }

    public class ComplementaryInputManagement
    {
        public static bool Initialized = false;
        public static Form FormInputManagment;
        public static int[] PatternFor8;
        public static int[] PatternFor9And10;
        public static int[] PatternFor11And12;
        public static int[] PatternFor13And14;
        public static int[] PatternFor15And16;
        public static int[] PatternFor17And18;
        public static int[] PatternFor19And20;
        public static int[] PatternFor21And22;
        public static int[] PatternFor23And24;
        public static int[] PatternFor25And26;
        public static int[] PatternFor27And28;


        public static void Initialize(Form frm)
        {
            FormInputManagment = frm;
            PatternFor8 = new int[] { 3, 4, 3, 4 };//ok
            PatternFor9And10 = new int[] { 3, 4, 1, 3, 4 };//ok
            PatternFor11And12 = new int[] { 3, 4, 5, 5, 3, 4 };//ok          
            PatternFor13And14 = new int[] { 3, 4, 5, 1, 6, 3, 4 };//ok
            PatternFor15And16 = new int[] { 3, 4, 5, 6, 6, 5, 3, 4 };//ok
            PatternFor17And18 = new int[] { 3, 4, 5, 6, 1, 6, 5, 3, 4 };//ok
            PatternFor19And20 = new int[] { 3, 4, 5, 6, 7, 8, 6, 5, 3, 4 };//ok
            PatternFor21And22 = new int[] { 3, 4, 5, 6, 7, 1, 8, 6, 5, 3, 4 };//ok
            PatternFor23And24 = new int[] { 3, 4, 5, 6, 7, 9, 10, 8, 6, 5, 3, 4 };//ok
            PatternFor25And26 = new int[] { 3, 4, 5, 6, 7, 9, 1, 10, 8, 6, 5, 3, 4 };//ok
            PatternFor27And28 = new int[] { 3, 4, 5, 6, 7, 9, 11, 12, 10, 8, 6, 5, 3, 4 };//ok
            Initialized = true;
        }

        public static List<int[]> GetAllQuadraplesStartingWithA(int Letter1, int Letter2, int Letter3, int Letter4)//OK
        {
            List<int[]> result = new List<int[]>();            
            for (int B = 1; B <= 28; B++)
                if (Letter1 != B)
                {
                    if (Letter2 == 0 || Letter2==B)
                    for (int C = 1; C <= 28; C++)
                        if (C != B && C != Letter1)
                        {
                            if (Letter3 == 0 || Letter3 == C)
                            for (int D = 1; D <= 28; D++)
                                if (D != C && D != B && D != Letter1)
                                if (Letter4 == 0 || Letter4 == D)
                                {

                                    int[] temp = new int[4]; temp[0] = Letter1; temp[1] = B; temp[2] = C; temp[3] = D;
                                    result.Add(temp);
                                }
                        }
                }
            return result;
        }

        public static int[] GetPattern(int Length)
        {
            if (!Initialized)
                Initialize(null);

            if (Length == 8)
                return PatternFor8;
            if (Length == 9 || Length == 10)
                return PatternFor9And10;
            if (Length == 11 || Length == 12)
                return PatternFor11And12;
            if (Length == 13 || Length == 14)
                return PatternFor13And14;
            if (Length == 15 || Length == 16)
                return PatternFor15And16;
            if (Length == 17 || Length == 18)
                return PatternFor17And18;
            if (Length == 19 || Length == 20)
                return PatternFor19And20;
            if (Length == 21 || Length == 22)
                return PatternFor21And22;
            if (Length == 23 || Length == 24)
                return PatternFor23And24;
            if (Length == 25 || Length == 26)
                return PatternFor25And26;
            if (Length == 27 || Length == 28)
                return PatternFor27And28;
            return null;

        }

        public static bool TheTwoTiplesAreOk(int[] InputArray, int index)
        {
            int Length = InputArray.Length;
            int LeftTipleSummation = InputArray[index] + InputArray[index+1] + InputArray[index+2];
            int RightTipleSummation = InputArray[Length-1-index] + InputArray[Length-1-index-1] + InputArray[Length-1-index-2];
            if (InputManagement.SummationOrDistanceIsASpecialNumber(LeftTipleSummation, RightTipleSummation))
                return true;
            return false;
        }

        public static List<int[]> CompleteInput(int[] InputArray, int StartIndex, IntSet RemaningLettersTillNow)
        {
            int Length = InputArray.Length;
            int RemainingLength = Length - 2 * (StartIndex); 
            List<int[]> result = new List<int[]>();
            if (RemainingLength == 0)
            {
                int CurrentSummation = MiscMethods.ArrayItemsSummation(InputArray);
               // int Summation = InputArray[InputArray.Length-1];
                int Summation = InputArray[0];
                if (Math.Abs(Summation - CurrentSummation) % 28 == 0)
                {
                    ((FormInputManagment)FormInputManagment).ProcessAGeneratedInput(InputArray.Length, InputArray[0], InputArray[1], InputArray[2], InputArray[3], MiscMethods.CopyArray(InputArray), 2);
                }
                return result;
            }
            if (RemainingLength == 1)
            {
                for (int index = 0; index < RemaningLettersTillNow.Members.Count; index++)
                {
                    int Letter = RemaningLettersTillNow.Members[index];
                   InputArray[Length / 2] = Letter;
                        int CurrentSummation = MiscMethods.ArrayItemsSummation(InputArray);
                        int Summation = InputArray[0];
                        if (Math.Abs(Summation - CurrentSummation) % 28 == 0)
                        {
                            ((FormInputManagment)FormInputManagment).ProcessAGeneratedInput(InputArray.Length, InputArray[0], InputArray[1], InputArray[2], InputArray[3], MiscMethods.CopyArray(InputArray),2);
                        }
                    
                }
                return result;               
            }
           
            for (int indexI = 0; indexI < RemaningLettersTillNow.Members.Count; indexI++)
            {
                int ii = RemaningLettersTillNow.Members[indexI];
                for (int indexJ = 0; indexJ < RemaningLettersTillNow.Members.Count; indexJ++)
                {
                    int jj = RemaningLettersTillNow.Members[indexJ];
                    if (ii != jj)
                    {
                        InputArray[StartIndex] = ii;
                        InputArray[Length - 1 - StartIndex] = jj;
                        if (TheTwoTiplesAreOk(InputArray, StartIndex-2))
                        {
                            RemainingLength = Length - 2 * (1+StartIndex);   
                            if (RemainingLength == 0)
                            {
                                int CurrentSummation = MiscMethods.ArrayItemsSummation(InputArray);
                                int Summation = InputArray[0];
                                if (Math.Abs(Summation - CurrentSummation) % 28 == 0)
                                 {
                                     ((FormInputManagment)FormInputManagment).ProcessAGeneratedInput(InputArray.Length, InputArray[0], InputArray[1], InputArray[2], InputArray[3], MiscMethods.CopyArray(InputArray),2);
                                     //result.Add(MiscMethods.CopyArray(InputArray));
                                }
                               
                            }                           
                            else
                            {
                                RemaningLettersTillNow.Remove(ii,jj);
                                List<int[]> TempResult = CompleteInput(InputArray, StartIndex+1, RemaningLettersTillNow);
                                result.AddRange(TempResult);
                                RemaningLettersTillNow.Add(ii, jj);
                            }
                        }

                    }
                }
            }
            return result;
        }

        

       

        public static List<int[]> FindInputs(int Length, int A, int B, int C, int D)
        {
            int[] Pattern = GetPattern(Length);

            IntSet RemaningLettersTillNow = new IntSet();
            for (int i = 1; i <= 28; i++)
                RemaningLettersTillNow.Add(i);
            RemaningLettersTillNow.Remove(A,B,C,D);


            int[] InputArray = new int[Length];
            InputArray[0] = A; InputArray[1] = B; InputArray[2] = C; InputArray[3] = D;
            List<int[]> result = new List<int[]>();
            List<int>[] Options = new List<int>[Length];
            for (int i = 0; i < Length; i++)
            {
                Options[i] = new List<int>();
            }
            Options[0].Add(A); Options[1].Add(B); Options[2].Add(C); Options[3].Add(D);
            for (int i = 0; i < 4; i++)
            {
                Options[Length-1-i] = new List<int>();
                for (int index = 0; index < RemaningLettersTillNow.Members.Count; index++) 
                {
                    int ii = RemaningLettersTillNow.Members[index];
                    if (
                        Pattern[i] == Math.Abs(Options[i][0] - ii) 
                        ||
                        (Pattern[i] == Math.Abs(Options[i][0] + 28 - ii) && (Options[i][0] < ii))
                        ||
                        (Pattern[i] == Math.Abs(ii + 28 - Options[i][0]) && (Options[i][0] > ii))
                        )
                        Options[Length - 1 - i].Add(ii);
                    else
                    {
                        if (Pattern[i] == MiscMethods.EquivalentNumber(Options[i][0] + ii))
                            Options[Length - 1 - i].Add(ii);
                    }
                }
            }
            for (int ii = 0; ii < Options[Length - 1].Count; ii++)
            {
                int I = Options[Length - 1][ii];
                InputArray[Length - 1] = I;
                for (int jj = 0; jj < Options[Length - 1 - 1].Count; jj++) 
                {
                    int J = Options[Length - 1-1][jj];
                    InputArray[Length - 1 - 1] = J;

                    if (J != I) 
                    for (int kk = 0; kk < Options[Length - 1 - 2].Count; kk++)
                    {
                        int K = Options[Length - 1 - 2][kk];
                        InputArray[Length - 1 - 2] = K;
                        if (K != I && K != J) 
                        for (int ll = 0; ll < Options[Length - 1 - 3].Count; ll++)
                        {
                            int L = Options[Length - 1 - 3][ll];
                            InputArray[Length - 1 - 3] = L;
                            if (L != I && L != J && L != K)
                            {
                                if (TheTwoTiplesAreOk(InputArray, 0) && TheTwoTiplesAreOk(InputArray, 1))
                                {
                                    RemaningLettersTillNow.Remove(I, J, K, L);
                                    result = CompleteInput(InputArray, 4, RemaningLettersTillNow);
                                    RemaningLettersTillNow.Add(I, J, K, L);
                                }
                            }
                        }
                    }
                }

            }

            //string s = "";

            //for (int i = 0; i < result.Count; i++)
            //{
            //    int Sum = MiscMethods.ArrayItemsSummation(result[i]);
            //    Sum = (Sum-154)/28;
            //    s += (" ," + Sum.ToString());
                
            //}

            //MessageBox.Show(s);
            return result;
        } 

    }
}

