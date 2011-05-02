using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem23 : Problem {

		public override string Solve() {
			var abundandts = new List<int>();
			for (int i = 0; i < 28123; i++) {
				var divisors = Helper.GetDivisors(i);
				if (divisors.Sum() > i) {
					abundandts.Add(i);
				}
			}

			var sums = new HashSet<int>();
			for (int i = 0; i < abundandts.Count; i++) {
				for (int j = 0; j < abundandts.Count; j++) {
					var sum = abundandts[i] + abundandts[j];
					if (!sums.Contains(sum)) {
						sums.Add(sum);
					}
				}
			}

			var total = 0;
			for (int i = 0; i < 28123; i++) {
				if (!sums.Contains(i)) {
					total += i;
				}
			}


			return total.ToString();
		}
	}
}
