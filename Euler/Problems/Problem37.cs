using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem37 : Problem {
		
		public override string Solve() {
			var primes = Helper.BuildPrimes();

			var results = new List<int>();
			foreach (var prime in primes) {
				if (IsTruncatable(prime, primes)) {
					results.Add(prime);
				}
			}
			
			return results.Sum().ToString();
		}

		bool IsTruncatable(int prime, HashSet<int> primes) {

			if (prime < 10) return false;
			var numberList = prime.ToString().ToList();

			while (numberList.Count != 0) {
				if (!primes.Contains(int.Parse(new string(numberList.ToArray())))) {
					return false;
				}
				numberList.RemoveAt(0);
			}

			var numberList2 = prime.ToString().ToList();

			while (numberList2.Count != 0) {
				if (!primes.Contains(int.Parse(new string(numberList2.ToArray())))) {
					return false;
				}
				numberList2.RemoveAt(numberList2.Count - 1);
			}

			return true;
		}

		public override string Solution {
			get { return "748317"; }
		}
	}
}
