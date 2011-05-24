using System.Linq;
using System.Numerics;

namespace Euler.Problems {
	public class Problem65 : Problem {

		public override string Solve() {
			BigInteger previousNumerator = 2;
			BigInteger previousDenominator = 1;
			BigInteger numerator = 3;
			BigInteger denominator = 1;

			var convergentCount = 2;
			var middleStep = 2;
			var limit = 100;

			while (true) {
				var tempNumerator = numerator;
				var tempDenominator = denominator;
				numerator = (numerator * middleStep) + previousNumerator;
				denominator = (denominator * middleStep) + previousDenominator;
				previousDenominator = tempDenominator;
				previousNumerator = tempNumerator;
				middleStep += 2;

				convergentCount++;
				if (convergentCount == limit) break;

				tempNumerator = numerator;
				tempDenominator = denominator;
				numerator = (numerator * 1) + previousNumerator;
				denominator = (denominator * 1) + previousDenominator;
				previousDenominator = tempDenominator;
				previousNumerator = tempNumerator;

				convergentCount++;
				if (convergentCount == limit) break;

				tempNumerator = numerator;
				tempDenominator = denominator;
				numerator = (numerator * 1) + previousNumerator;
				denominator = (denominator * 1) + previousDenominator;
				previousDenominator = tempDenominator;
				previousNumerator = tempNumerator;

				convergentCount++;
				if (convergentCount == limit) break;
			}

			return numerator.ToStringList().Sum(i => int.Parse(i)).ToString();
		}

		public override string Solution {
			get { return "272"; }
		}
	}
}