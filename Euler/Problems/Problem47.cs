using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem47 : Problem {
		
		public override string Solve() {
			var primes = Helper.BuildPrimes().OrderByDescending(p => p).ToList();
			var numberToLookFor = 4;
			var consecutive = 0;
			var results = new List<int>();
			var allNumbers = new List<int>();
			for (int i = 130000; i < 140000; i++) {
				allNumbers.Add(i);
			}

			foreach (var i in allNumbers) {
				if (primes.Contains(i)) {
					consecutive = 0;
					results.Clear();
					continue;
				}
				var factors = GetFactors(i, primes);

				if (factors.Count == numberToLookFor) {
					consecutive++;
					results.Add(i);
				}
				else {
					consecutive = 0;
					results.Clear();
				}

				if (consecutive == numberToLookFor) {
					return results.Min().ToString();
				}
			}

			return Helper.GARF;
		}

		List<int> GetFactors(int i, IEnumerable<int> primes) {
			foreach (var prime in primes.Where(p => p < i)) {
				if (i % prime == 0) {
					var listOne = GetFactors(prime, primes);
					var listTwo = GetFactors(i/prime, primes);
					return listOne.Union(listTwo).ToList();
				}
			}
			return new List<int>{ i };
		}

		public override string Solution {
			get { return "134043"; }
		}
	}
}
