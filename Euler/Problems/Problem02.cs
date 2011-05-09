using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem02 : Problem {

		public override string Solve() {
			var fibonaccis = Helper.BuildFibonnaci(10000);

			BigInteger total = 0;
			foreach (var fibonacci in fibonaccis) {
				if ((fibonacci % 2) == 0 && fibonacci < 4000000) {
					total += fibonacci;
				}
			}
			
			return total.ToString();
		}

		public override string Solution {
			get { return "4613732"; }
		}
	}
}
