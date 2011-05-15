using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem63 : Problem {

		public override string Solve() {

			var numberCounted = 0;
			for (int exp = 1; exp < 1000; exp++) {
				for (int number = 1; number < 1000; number++) {

					var result = BigInteger.Pow(number, exp);
					var resultLength = result.ToString().Length;
					if (resultLength == exp) {
						numberCounted++;
					}
					if (resultLength > exp) {
						break;
					}
				}
			}

			return numberCounted.ToString();
		}

		public override string Solution {
			get { return "49"; }
		}
	}
}
