using System.Linq;

namespace Euler.Problems {
	public class RoseCode01 : Problem {

		public override string Solve() {
			return Helper.BuildPrimes().ToList()[78200 - 1].ToString();
		}

		public override string Solution {
			get { return "995909"; }
		}
	}
}