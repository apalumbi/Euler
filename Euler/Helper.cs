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

		public static HashSet<int> BuildPrimes(int topNumber) {
			var primeNumbers = new HashSet<int>();
			var numbers = new BitArray(topNumber, true);
			for (int i = 2; i < topNumber; i++)
				if (numbers[i]) {
					for (int j = i * 2; j < topNumber; j += i)
						numbers[j] = false;
				}

			int primes = 0;

			for (int i = 2; i < topNumber; i++)
				if (numbers[i]) {
					primeNumbers.Add(i);
					primes++;
				}
			return primeNumbers;
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

		public static bool IsPandigital(string number) {
			if (number.Length != 9) {
				return false;
			}

			var i = CountInstances(number);

			return i.Ones == 1 && i.Twos == 1 && i.Threes == 1 && i.Fours == 1 &&
						 i.Fives == 1 && i.Sixes == 1 && i.Sevens == 1 && i.Eights == 1 &&
						 i.Nines == 1 && i.Zeros == 0;
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