using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem37 : Problem {
		
		public override string Solve() {
			var primes = Helper.BuildPrimes(1000000);

			var results = new List<int>();
			foreach (var prime in primes) {
				if (IsTruncatable(prime, primes)) {
					results.Add(prime);
				}
			}

			foreach (var item in results) {
				Helper.Write(item);
			}

			return results.Sum().ToString();
		}

		static bool IsTruncatable(int prime, HashSet<int> primes) {

			if (prime < 10) return false;
			var numberList = prime.ToString().ToList();

			while (numberList.Count != 0) {
				if (!primes.Contains(int.Parse(string.Join("", numberList.ToArray())))) {
					return false;
				}
				numberList.RemoveAt(0);
			}

			var numberList2 = prime.ToString().ToList();

			while (numberList2.Count != 0) {
				if (!primes.Contains(int.Parse(string.Join("", numberList2.ToArray())))) {
					return false;
				}
				numberList2.RemoveAt(numberList2.Count - 1);
			}

			return true;
		}
	}
}
