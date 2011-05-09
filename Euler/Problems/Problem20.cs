using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem20 : Problem {

		public override string Solve() {
			BigInteger answer = 1;
			for (int i = 1; i <= 100; i++) {
				answer = answer * i;
			}

			return answer.ToString().Select(c => int.Parse(c.ToString())).Sum().ToString();
		}

		public override string Solution {
			get { return "648"; }
		}
	}
}
