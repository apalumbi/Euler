using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem44 : Problem {

		public override string Solve() {
			var pentagonals = new List<BigInteger>();
			var pentagonalsLookup = new HashSet<BigInteger>();
			for (BigInteger i = 1; i < 5000; i++) {
				var p = Formulas.Pentagonal(i);
				pentagonals.Add(p);
				pentagonalsLookup.Add(p);
			}

			var results = new List<string>();
			for (int i = 0; i < pentagonals.Count; i++) {
				for (int j = 0; j < pentagonals.Count; j++) {
					var sum = pentagonals[i] + pentagonals[j];
					var diff = pentagonals[j] - pentagonals[i];

					if (pentagonalsLookup.Contains(sum) && pentagonalsLookup.Contains(diff)) {
						results.Add(diff.ToString());
					}
				}
			}

			return results.Last();
		}
		
		public override string Solution {
			get { return "5482660"; }
		}
	}
}