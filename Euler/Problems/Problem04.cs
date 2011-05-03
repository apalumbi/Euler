using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem04 : Problem {

		public override string Solve() {
			long currentMax = -1;
			long bigI = -1;
			long bigJ = -1;
			for (int i = 100; i < 1000; i++) {
				for (int j = 100; j < 1000; j++) {
					long product = i * j;
					if (IsPalindrom(product)) {
						if (product > currentMax) {
							bigI = i;
							bigJ = j;
							currentMax = product;
						}
					}
				}
			}
			return currentMax.ToString() + " from " + bigI + " * " + bigJ;
		}

		bool IsPalindrom(long i) {
			bool result = true;
			char[] numbers = i.ToString().ToCharArray();
			for (int index = 0; index < numbers.Length; index++) {
				if (numbers[index] != numbers[Math.Abs(index - numbers.Length) - 1]) {
					result = false ;
				}
			}
			return result;
		}
	}
}
