using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem53 : Problem {

		public override string Solve() {
			var count = 0;

			for (int n = 23; n <= 100; n++) {
				for (int r = 1; r < n; r++) {
					var result = nCr(n, r);
					if (result > 1000000) {
						count++;
					}
				}
			}
			return count.ToString();
		}

		BigInteger nCr(int n, int r) {
			var result = Helper.BuildFactorial(n) / (Helper.BuildFactorial(r) * Helper.BuildFactorial(n - r));
			return result;
		}
	}
}
