using System.Linq;
using System.Numerics;
namespace Euler.Problems {
	public class RoseCode02 : Problem {

		public override string Solve() {
			var fibonaccis = Helper.BuildFibonnaci(10000);

			foreach (var fibonacci in fibonaccis) {
				if (fibonacci.ToString().Select(f => int.Parse(f.ToString())).Sum() > 100) {
					return fibonacci.ToString();
				}
			}

			return "garf";
		}
	}
}