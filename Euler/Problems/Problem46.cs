using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem46 : Problem {

		public override string Solve() {
			var primes = Helper.BuildPrimes(100000);

			for (int i = 3; i < 100000; i = i + 2) {
				if (primes.Contains(i)) {
					continue;
				}

				bool isGoldy = false;
				for (int j = 0; j < i; j++) {
					foreach (var prime in primes) {
						var numberToCheck = GoldBach(j, prime);
						if (numberToCheck > i) {
							break;
						}

						if (numberToCheck == i) {
							j = i;
							isGoldy = true;
							continue;
						}
					}
				}
				if (!isGoldy) {
					return i.ToString();
				}
			}
			return Helper.GARF;
		}

		int GoldBach(int j, int prime) {
			return prime + (2*j*j);
		}

		public override string Solution {
			get { return "5777"; }
		}
	}
}
