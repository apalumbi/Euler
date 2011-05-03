using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem51 : Problem {
		private HashSet<int> primes;
		public override string Solve() {
			primes = Helper.BuildPrimes(1000000);
			var primeStrings = primes.Select(p => p.ToString());

			var length = 2;

			var pairs = new List<Pair<int, int>>();
			while (length < 3) {
				var numberToReplace = 1;
				foreach (var prime in primeStrings.Where(p => p.Length == length)) {
					while (numberToReplace <= length - 1) {
						for (int index = 0; index < length; index++) {
							for (int replacement = 0; replacement < 10; replacement++) {
								pairs.Add(Formula(index, replacement, prime, numberToReplace));
							}
						}
						numberToReplace++;
					}
				}
				length++;
			}

			return pairs.Where(p => p.Second == pairs.Max(m => m.Second)).First().ToString();
		}

		Pair<int, int> Formula(int index, int replacement, string prime, int numberToReplace) {
			var count = 0;
			var primeOnes = new List<int>();
			while (index + numberToReplace <= prime.Length) {
				var numberList = prime.Select(c => c.ToString()).ToList();
				for (int i = index; i < numberToReplace; i++) {
					numberList[i] = replacement.ToString();
				}
				var newNumber = int.Parse(string.Join("", numberList));
				if (primes.Contains(newNumber)) {
					count++;
					primeOnes.Add(newNumber);
				}
				index++;
			}
			return new Pair<int, int>(primeOnes.Min(), count);
		}
	}
}
