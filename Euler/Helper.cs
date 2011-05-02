using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Euler {
	public static class Helper {
		public static void WriteAndCopy(object output) {
			Write(output);
			Copy(output);
		}

		public static void Write(object output) {
			Console.WriteLine(output.ToString());
		}

		public static void Copy(object result) {
			Clipboard.SetDataObject(result.ToString(), false, 5, 200);
		}

		public static HashSet<int> BuildPrimes(int topNumber, int bottomNumber = 2) {
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
		
		public static int GetWordCount(string name) {
			var points = 0;
			var chars = name.ToCharArray();
			foreach (var c in chars) {
				points += AlphabetPosition(c);
			}
			return points;
		}

		static int AlphabetPosition(char letter) {
			switch (letter.ToString()) {
				case "A":
					return 1;
				case "B":
					return 2;
				case "C":
					return 3;
				case "D":
					return 4;
				case "E":
					return 5;
				case "F":
					return 6;
				case "G":
					return 7;
				case "H":
					return 8;
				case "I":
					return 9;
				case "J":
					return 10;
				case "K":
					return 11;
				case "L":
					return 12;
				case "M":
					return 13;
				case "N":
					return 14;
				case "O":
					return 15;
				case "P":
					return 16;
				case "Q":
					return 17;
				case "R":
					return 18;
				case "S":
					return 19;
				case "T":
					return 20;
				case "U":
					return 21;
				case "V":
					return 22;
				case "W":
					return 23;
				case "X":
					return 24;
				case "Y":
					return 25;
				case "Z":
					return 26;
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

		static Instances CountInstances(string number) {
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

		class Instances {
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
		}
	}
}