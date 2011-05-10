using System.Linq;
using System.Numerics;
namespace Euler.Problems {
	public class Problem56 : Problem {

		public override string Solve() {
			BigInteger maxSum = 0;
			for (int i = 0; i <= 100; i++) {
				for (int j = 0; j <= 100; j++) {
					var product = BigInteger.Pow(i, j);
					var productList = product.ToString().Select(c => BigInteger.Parse(c.ToString()));
					BigInteger sum = 0;
					foreach (var number in productList) {
						sum += number;
					}

					if (sum > maxSum) {
						maxSum = sum;
					}
				}
			}
			return maxSum.ToString();
		}

		public override string Solution {
			get { return "972"; }
		}
	}
}