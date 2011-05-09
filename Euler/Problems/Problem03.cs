using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem03 : Problem {
		List<int> primes = new List<int>();
		long value = 600851475143;
		public override string Solve() {
			primes = Helper.BuildPrimes().ToList();

			var result = ValueGetsUsThere();
			return primes[result].ToString();
		}

		int ValueGetsUsThere() {
			for (int i = primes.Count - 1; i > 0; i--) {
				if ((value % primes[i]) == 0) return i;
			}
			return -1;
		}

		public override string Solution {
			get { return "6857"; }
		}
	}
}