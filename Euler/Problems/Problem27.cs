using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem27 : Problem {
		public override string Solve() {
			var primes = Helper.BuildPrimes(1000000);

			var primeCount = 0;
			var bigA = 0;
			var bigB = 0;
			var answers = new List<string>();

			for (int a = 1; a < 1000; a++) {
				for (int b = 0; b < 1000; b++) {
					for (int i = 0; i < 100000000; i++) {
						var result = Formula(i, a, b);
						if (!primes.Contains(result)) {
							if (i + 1 > primeCount) {
								bigA = a;
								bigB = b;
								primeCount = i + 1;
								answers.Add(bigA + " and " + bigB + " produced " + primeCount + " consecutive primes.    " + bigA * bigB);
							}
							break;
						}
					}

				}
			}

			foreach (var a in answers) {
				Helper.Write(a);
			}

			return answers.Last();
		}

		int Formula(int i, int a, int b) {
			return (i * i) - (a * i) + b;
		}
	}
}
