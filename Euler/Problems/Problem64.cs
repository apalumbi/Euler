using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem64 : Problem {

		public override string Solve() {
			int results = 0;
			for (int number = 2; number <= 10000; number++) {
				if (number % Math.Sqrt(number) == 0) {
					continue;
				}

				var periods = Helper.ContinuedFraction(number);
				if (periods.Count % 2 == 0)
					results++;

			}
			return results.ToString();
		}

		public override string Solution {
			get { return "1322"; }
		}
	}
}
