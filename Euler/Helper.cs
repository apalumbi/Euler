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
	}
}
