using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem33 : Problem {
		public override string Solve() {
			var denominators = new List<decimal>();
			var numbersToSkip = new HashSet<decimal> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
			for (decimal numerator = 10; numerator < 100; numerator++) {
				for (decimal denominator = 10; denominator < 100; denominator++) {
					if (numbersToSkip.Contains(numerator) && numbersToSkip.Contains(denominator)) {
						continue;
					}
					if (numerator == denominator) {
						continue;
					}

					decimal? numberInBoth = GetNumberInboth(numerator, denominator);
					if (numberInBoth != null) {
						var one = numerator / denominator;
						if (one > 1) continue;

						var newDenominator = RemoveNumber(numberInBoth.Value, denominator);

						if (newDenominator == 0) {
							continue;
						}
						var newNumerator = RemoveNumber(numberInBoth.Value, numerator);
						var two = newNumerator / newDenominator;
						if (one == two) {
							denominators.Add(denominator);
							Helper.Write(numerator + "/" + denominator);
							Helper.Write(newNumerator + "/" + newDenominator);
							Helper.Write("----");
						}
					}
				}
			}
			return "did it by hand from output";
		}

		decimal? GetNumberInboth(decimal numerator, decimal denominator) {
			var numers = numerator.ToString().ToList();
			var d = denominator.ToString();

			if (d.StartsWith(numers[0].ToString()) || d.EndsWith(numers[0].ToString())) {
				return decimal.Parse(numers[0].ToString());
			}

			if (d.StartsWith(numers[1].ToString()) || d.EndsWith(numers[1].ToString())) {
				return decimal.Parse(numers[1].ToString());
			}
			return null;
		}

		decimal RemoveNumber(decimal numberInBoth, decimal num) {
			if (num.ToString().StartsWith(numberInBoth.ToString()) && num.ToString().EndsWith(numberInBoth.ToString())) {
				return numberInBoth;
			}
			return decimal.Parse(num.ToString().Replace(numberInBoth.ToString(), ""));
		}
	}
}
