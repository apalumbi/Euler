using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem07 : Problem {

		public override string Solve() {
			return Helper.BuildPrimes(1000000).ToList()[10001].ToString();
		}
	}
}
