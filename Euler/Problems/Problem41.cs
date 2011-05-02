using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem41 : Problem {

		public override string Solve() {
			var primes = Helper.BuildPrimes(9999999, 1111111);

			foreach (var p in primes.OrderByDescending(p => p)) {
				if (Helper.IsPandigital(p.ToString(), false, ninesCount: 0, eightsCount: 0)) {
					return p.ToString();
				}
			}

			return "garf";
		}
	}
}
