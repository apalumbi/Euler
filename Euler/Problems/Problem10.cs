using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem10 : Problem {

		public override string Solve() {
			var primesToAdd = Helper.BuildPrimes(2000000).Where(p => p < 2000000);

			BigInteger sum = 0;

			foreach (var prime in primesToAdd) {
				sum += prime;
			}

			return sum.ToString();
		}
	}
}
