using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem50 : Problem {

		public override string Solve() {
			var limit = 1000000;
			var primes = Helper.BuildPrimes(limit).ToList();

			var mostConsecutive = 0;
			var lastPrimeUsed = 0;
			for (int i = 0; i < limit; i++) {
				var sum = 0;
				var consecutive = 0;
				var index = i;
				while (sum < limit && index < primes.Count - 1) {
					consecutive++;
					var lastPrime = primes[index];
					sum += lastPrime;
					if (primes.Contains(sum) && mostConsecutive < consecutive) {
						mostConsecutive = consecutive;
						lastPrimeUsed = lastPrime;
					}
					index++;	
				}
			}

			return lastPrimeUsed.ToString() + " -- " + mostConsecutive.ToString();

		}
	}
}
