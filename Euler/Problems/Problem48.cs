using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Euler.Problems {
	public class Problem48 : Problem {
		public override string Solve() {
			BigInteger sum = 0;
			for (BigInteger i = 1; i <= 1000; i++) {
				sum += BigInteger.Pow(i, int.Parse(i.ToString()));
			}

			var result = sum.ToString();
			return result.Substring(result.Length - 10, 10);
		}

		public override string Solution {
			get { return "9110846700"; }
		}
	}
}
