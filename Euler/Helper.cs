﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Numerics;

namespace Euler {
	public static class Helper {
		public static string GARF { get { return "garf!"; } }

		public static void WriteAndCopy(object output) {
			Write(output);
			Copy(output);
		}

		public static void Write(object output) {
			Console.WriteLine(output.ToString());
		}

		public static void Copy(object result) {
			//Clipboard.SetText(result.ToString());
		}

		public static HashSet<int> BuildPrimes(int topNumber = 1000000, int bottomNumber = 2) {
			var primeNumbers = new HashSet<int>();
			var numbers = new BitArray(topNumber, true);
			for (int i = 2; i < topNumber; i++)
				if (numbers[i]) {
					for (int j = i * 2; j < topNumber; j += i)
						numbers[j] = false;
				}

			int primes = 0;

			for (int i = bottomNumber; i < topNumber; i++)
				if (numbers[i]) {
					primeNumbers.Add(i);
					primes++;
				}
			return primeNumbers;
		}

		public static bool IsPrime(long number) {
			if (number == 1) return false;
			if (number < 4) return true;
			if (number % 2 == 0) return false;
			if (number < 9) return true;
			if (number % 3 == 0) return false;

			var floor = Math.Floor(Math.Sqrt(number));
			var plusMinus = 5;
			while (plusMinus <= floor) {
				if (number % plusMinus == 0) return false;

				if (number % (plusMinus + 2) == 0) return false;
				plusMinus = plusMinus + 6;
			}

			return true;
		}

		public static bool IsPalindrome(string text) {
			var j = text.Length - 1;
			for (int i = 0; i < text.Length; i++) {
				if (text[i] != text[j]) {
					return false;
				}
				j--;
			}
			return true;
		}

		public static List<BigInteger> BuildFibonnaci(int numberOfTerms) {
			var fibs = new List<BigInteger> { 0, 1 };

			for (int termCount = 0; termCount < numberOfTerms; termCount++) {
				var newTerm = fibs[termCount] + fibs[termCount + 1];
				fibs.Add(newTerm);
			}

			return fibs;
		}

		public static List<int> GetDivisors(int number) {
			var divisors = new List<int>();
			for (int i = 1; i <= (number / 2); i++) {
				var divisor = number % i;
				if (divisor == 0) {
					divisors.Add(i);
				}
			}
			return divisors;
		}

		public static List<int> GetFactors(int number, IEnumerable<int> primes) {
			foreach (var prime in primes.Where(p => p < number)) {
				if (number % prime == 0) {
					var listOne = GetFactors(prime, primes);
					var listTwo = GetFactors(number / prime, primes);
					return listOne.Union(listTwo).ToList();
				}
			}
			return new List<int> { number };
		}

		public static long BuildFactorialUsingLongs(long number) {
			var temp = number;
			for (int i = 1; i < number; i++) {
				temp *= i;
			}
			return temp;
		}

		public static BigInteger BuildFactorial(BigInteger number) {
			var temp = number;
			for (int i = 1; i < number; i++) {
				temp *= i;
			}
			return temp;
		}

		public static int GetWordCount(string name) {
			var points = 0;
			var chars = name.ToCharArray();
			foreach (var c in chars) {
				points += AlphabetPosition(c, true);
			}
			return points;
		}

		public static int AlphabetPosition(char letter, bool ignoreSpaces = false) {
			switch (letter.ToString()) {
				case "A":
				case "a":
					return 1;
				case "B":
				case "b":
					return 2;
				case "C":
				case "c":
					return 3;
				case "D":
				case "d":
					return 4;
				case "E":
				case "e":
					return 5;
				case "F":
				case "f":
					return 6;
				case "G":
				case "g":
					return 7;
				case "H":
				case "h":
					return 8;
				case "I":
				case "i":
					return 9;
				case "J":
				case "j":
					return 10;
				case "K":
				case "k":
					return 11;
				case "L":
				case "l":
					return 12;
				case "M":
				case "m":
					return 13;
				case "N":
				case "n":
					return 14;
				case "O":
				case "o":
					return 15;
				case "P":
				case "p":
					return 16;
				case "Q":
				case "q":
					return 17;
				case "R":
				case "r":
					return 18;
				case "S":
				case "s":
					return 19;
				case "T":
				case "t":
					return 20;
				case "U":
				case "u":
					return 21;
				case "V":
				case "v":
					return 22;
				case "W":
				case "w":
					return 23;
				case "X":
				case "x":
					return 24;
				case "Y":
				case "y":
					return 25;
				case "Z":
				case "z":
					return 26;
				case " ":
					return ignoreSpaces ? 0 : 1234;
				default:
					return 0;
			}
		}

		public static bool CannotBePandigital(string number) {
			var i = CountInstances(number);

			return i.Ones > 1 || i.Twos > 1 || i.Threes > 1 || i.Fours > 1 ||
						 i.Fives > 1 || i.Sixes > 1 || i.Sevens > 1 || i.Eights > 1 ||
						 i.Nines > 1 || i.Zeros > 0;
		}

		public static Instances CountInstances(string number) {
			var instances = new Instances();
			foreach (var n in number) {
				if (n == '1') instances.Ones++;
				else if (n == '2') instances.Twos++;
				else if (n == '3') instances.Threes++;
				else if (n == '4') instances.Fours++;
				else if (n == '5') instances.Fives++;
				else if (n == '6') instances.Sixes++;
				else if (n == '7') instances.Sevens++;
				else if (n == '8') instances.Eights++;
				else if (n == '9') instances.Nines++;
				else if (n == '0') instances.Zeros++;
			}
			return instances;
		}

		public static bool IsPandigital(string number, bool checkLength = true, int onesCount = 1, int twosCount = 1, int threesCount = 1,
																		int foursCount = 1, int fivesCount = 1, int sixesCount = 1, int sevensCount = 1,
																		int eightsCount = 1, int ninesCount = 1, int zerosCount = 0) {
			if (checkLength && number.Length != 9) {
				return false;
			}

			var i = CountInstances(number);

			return i.Ones == onesCount && i.Twos == twosCount && i.Threes == threesCount && i.Fours == foursCount &&
						 i.Fives == fivesCount && i.Sixes == sixesCount && i.Sevens == sevensCount && i.Eights == eightsCount &&
						 i.Nines == ninesCount && i.Zeros == zerosCount;
		}

		public static string ConvertToBase(long numberToConvert, int toBase) {
			var result = "";
			var remainderIsGreaterThanBase = true;
			var workingNumber = numberToConvert;
			while (remainderIsGreaterThanBase) {
				var remainder = workingNumber / toBase;

				var product = remainder * toBase;
				var difference = workingNumber - product;
				result = difference + result;
				if (remainder < toBase) {
					remainderIsGreaterThanBase = false;
					result = remainder + result;
				}
				else {
					workingNumber = remainder;
				}
			}
			return result.TrimStart('0');
		}

		public static List<long> ContinuedFraction(long number) {
			var periods = new List<long>();
			var square = (long)Math.Sqrt(number);
			var period = square;
			long numerator = 0;
			long denominator = 1;
			do {
				periods.Add(period);
				numerator = period * denominator - numerator;
				denominator = (number - numerator * numerator) / denominator;
				period = (numerator + square) / denominator;
			} while (denominator != 1);

			periods.Add(period);
			return periods;
		}
	}
	
	public class Instances : IComparable {
		public int Ones = 0;
		public int Twos = 0;
		public int Threes = 0;
		public int Fours = 0;
		public int Fives = 0;
		public int Sixes = 0;
		public int Sevens = 0;
		public int Eights = 0;
		public int Nines = 0;
		public int Zeros = 0;

		string stringValue = "";
		public string StringValue {
			get {
				if (string.IsNullOrEmpty(stringValue)) {
					stringValue = Ones.ToString() + Twos.ToString() +
												Threes.ToString() + Fours.ToString() +
												Fives.ToString() + Sixes.ToString() +
												Sevens.ToString() + Eights.ToString() +
												Nines.ToString() + Nines.ToString();
				}
				return stringValue;
			}
		}

		public override bool Equals(object obj) {
			var that = obj as Instances;
			if (that == null) return false;

			return this.StringValue == that.StringValue;
		}

		public override int GetHashCode() {
			return this.StringValue.GetHashCode();
		}

		public int CompareTo(object obj) {
			var that = obj as Instances;
			if (that == null) return -1;

			return this.StringValue.CompareTo(that.StringValue);
		}
	}
}