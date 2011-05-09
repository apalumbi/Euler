using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem38 : Problem {

		public override string Solve() {
			BigInteger largestPandigital = 987654321;
			var results = new List<Pair<int, int>>();

			for (BigInteger i = largestPandigital; i > 918273645; i--) {
				if (Helper.CannotBePandigital(i.ToString())) {
					continue;
				}
				results = Do(i);
				if (results.Count() > 0) {
					break;
				}
			}

			return results.Last().Second.ToString();
		}

		List<Pair<int, int>> Do(BigInteger numberToCheck) {
			for (int i = 9000; i < 10000; i++) {
				var shouldContinue = true;
				var pairs = new List<Pair<int, int>>();
				var n = 1;
				var numberString = numberToCheck.ToString();
				var productString = "";
				while (shouldContinue) {
					var product = i * n;
					productString += product.ToString();
					if (numberString.StartsWith(productString)) {
						pairs.Add(new Pair<int, int>(n, i));
					}
					else {
						shouldContinue = false;
					}

					if (productString == numberString) {
						pairs.Add(new Pair<int, int>(0, int.Parse(numberString)));
						return pairs;
					}
					n++;
				}
			}
			return new List<Pair<int, int>>();
		}

		public override string Solution {
			get { return "932718654"; }
		}
	}
}
