using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.Problems {
	public class Problem43 : Problem {
		List<int> divisors = new List<int> { 2, 3, 5, 7, 11, 13, 17 };


		public override string Solve() {
			var generator = new PermutationGenerator<string>(new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
			BigInteger sum = 0;
			while (generator.HasMore) {
			  var perm = generator.GetNext();

			  sum += HasSpecialProperty(perm.Select(e => e.Second).ToList());
			}

			return sum.ToString();
		}

		BigInteger HasSpecialProperty(List<string> numberString) {
			var index = 1;
			bool wasDivisible = true;
			foreach (var divisor in divisors) {
				if (index > 7) {
					break;
				}

				var first = numberString[index];
				var second = numberString[index + 1];
				var third = numberString[index + 2];
				var number = BigInteger.Parse(first + second + third);

				if ((number % divisor) != 0) {
					wasDivisible = false;
					break;
				}
				index++;
			}

			return wasDivisible ? BigInteger.Parse(string.Join("", numberString)) : 0;
		}
	}
}
