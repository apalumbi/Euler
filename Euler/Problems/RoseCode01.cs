using System.Linq;

namespace Euler.Problems {
	public class RoseCode01 : Problem{

		public override string Solve() {
			return Helper.BuildPrimes(1000000).ToList()[78200 - 1].ToString();
		}
	}
}