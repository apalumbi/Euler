using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.Problems {
	public class Problem44 : Problem {

		public override string Solve() {
			var pentagonals = new HashSet<BigInteger>();
			var triangles = new HashSet<BigInteger>();
			var hexagonals = new HashSet<BigInteger>();

			for (int i = 0; i < 1000000; i++) {
				pentagonals.Add(Pentagonal(i));
				triangles.Add(Triangle(i));
				hexagonals.Add(Hexogonal(i));
			}

			var results = new List<BigInteger>();
			foreach (var triangle in triangles) {
				if (pentagonals.Contains(triangle) && hexagonals.Contains(triangle)) {
					results.Add(triangle);
				}
			}

			Helper.Write(string.Join(Environment.NewLine, results));
			return results.Last().ToString();
		}

		BigInteger Pentagonal(BigInteger number) {
			return number * ((3 * number) - 1) / 2;
		}

		BigInteger Triangle(BigInteger number) {
			return number * (number + 1) / 2;
		}

		BigInteger Hexogonal(BigInteger number) {
			return number * ((2 * number) - 1);
		}
	}
}
