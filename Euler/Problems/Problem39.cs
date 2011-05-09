using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem39 : Problem {

		public override string Solve() {
			var maxCount = 0;
			var result = 0;
			for (int i = 1; i < 1000; i++) {
				var count = FindIntegralsCount(i);
				if (count > maxCount) {
					maxCount = count;
					result = i;
				}
			}
			return result.ToString();
		}

		int FindIntegralsCount(int limit) {
			var integrals = "";
			var count = 0;
			var alreadyAdded = new HashSet<string>();

			for (int a = 1; a < limit; a++) {
				for (int b = 1; b < limit; b++) {
					if (a + b > limit) {
						break;
					}
					var c = Formulas.QuadraticFormula(a, b);
					if (c + a + b == limit) {
						var list = new List<string> { a.ToString(), b.ToString(), c.ToString() };
						list.Sort();
						if (!alreadyAdded.Contains(list[0] + list[1] + list[2])) {
							count++;
							integrals += "{" + list[0] + "," + list[1] + "," + list[2] + "} ";
							alreadyAdded.Add(list[0] + list[1] + list[2]);
						}
					}
				}
			}

			return count;
		}

		public override string Solution {
			get { return "840"; }
		}
	}
}
