using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.Problems {
	public class Problem45 : Problem {

		public override string Solve() {
			var pentagonals = new HashSet<BigInteger>();
			var triangles = new HashSet<BigInteger>();
			var hexagonals = new HashSet<BigInteger>();

			for (int i = 0; i < 1000000; i++) {
				pentagonals.Add(Formulas.Pentagonal(i));
				triangles.Add(Formulas.Triangle(i));
				hexagonals.Add(Formulas.Hexogonal(i));
			}

			var results = new List<BigInteger>();
			foreach (var triangle in triangles) {
				if (pentagonals.Contains(triangle) && hexagonals.Contains(triangle)) {
					results.Add(triangle);
				}
			}

			return results.Last().ToString();
		}
		
		public override string Solution {
			get { return "1533776805"; }
		}
	}
}
