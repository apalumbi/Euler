using System;
using System.Collections.Generic;
using System.Numerics;
namespace Euler.Problems {
	public class Problem55 : Problem {

		public override string Solve() {
			var lychrelNumbers = new List<BigInteger>();
			for (BigInteger i = 0; i < 10000; i++) {
				BigInteger result = i;
				var iterationCount = 0;
				do {
					var number = result;
					var reverse = result.Reverse();
					result = number + reverse;
					iterationCount++;
				} while (!Helper.IsPalindrome(result.ToString()) && iterationCount <= 50);
				if (!Helper.IsPalindrome(result.ToString()) && iterationCount > 50) {
					lychrelNumbers.Add(result);
				}
			}

			return lychrelNumbers.Count.ToString();
		}

		public override string Solution {
			get { return "249"; }
		}
	}
}