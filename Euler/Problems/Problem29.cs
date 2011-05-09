using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem29 : Problem {
		public override string Solve() {
			var allResults = new List<double>();
			var limit = 100;

			for (int i = 2; i <= limit; i++) {
				for (int j = 2; j <= limit; j++) {
					allResults.Add(Math.Pow(i, j));
				}
			}

			var distinct = allResults.Distinct();
			
			return distinct.Count().ToString();
		}

		public override string Solution {
			get { return "9183"; }
		}
	}
}
