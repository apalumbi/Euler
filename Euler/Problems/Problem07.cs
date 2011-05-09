using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem07 : Problem {

		public override string Solve() {
			return Helper.BuildPrimes().ToList()[10000].ToString();
		}

		public override string Solution {
			get { return "104743"; }
		}
	}
}
