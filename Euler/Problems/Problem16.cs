using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem16 : Problem {

		public override string Solve() {
			var bigNumber = BigInteger.Pow(2, 1000);
			var numbers = bigNumber.ToString().ToList();

			var sum = 0;
			foreach (var n in numbers) {
				sum += int.Parse(n.ToString());
			}
			return sum.ToString();
		}
	}
}
