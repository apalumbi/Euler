using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem60 : Problem {

		public override string Solve() {
			var primes = Helper.BuildPrimes().ToList();
			for (int i = 1; i < 100; i++) {
				for (int j = 100; j < 200; j++) {
					for (int k = 200; k < 300; k++) {
						for (int m = 300; m < 400; m++) {
							for (int n = 400; n < 500; n++) {
								var one = primes[i];
								var two = primes[j];
								var three = primes[k];
								var four = primes[m];
								var five = primes[n];

								var primesSorted = new List<int> { one, two, three, four, five, }.OrderBy(p => p).ToList();
								var allPrimes = true;
								for (int a = 0; a < 5; a++) {
									for (int b = 0; b < 5; b++) {
										var number = primesSorted[a].ToString() + primesSorted[b].ToString();
										allPrimes = Helper.IsPrime(int.Parse(number));
										if (!allPrimes) break;
									}
								}

								if (allPrimes) {
									return (one + two + three + four + five).ToString();
								}
							}
						}
					}
				}
			}
			return Helper.GARF;
		}
	}
}
