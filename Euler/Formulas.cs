using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler {
	public static class Formulas {
		public static BigInteger Pentagonal(BigInteger number) {
			return number * ((3 * number) - 1) / 2;
		}

		public static BigInteger Triangle(BigInteger number) {
			return number * (number + 1) / 2;
		}

		public static BigInteger Square(BigInteger number) {
			return number * number;
		}

		public static BigInteger Hexogonal(BigInteger number) {
			return number * ((2 * number) - 1);
		}

		public static BigInteger Heptagonal(BigInteger number) {
			return number * (5 * number - 3) / 2;
		}

		public static BigInteger Octogonal(BigInteger number) {
			return number * (3 * number - 2);
		}

		public static double QuadraticFormula(int a, int b) {
			var aSquaredPlusbSquared = (a * a) + (b * b);
			var c = Math.Sqrt(aSquaredPlusbSquared);
			return c;
		}

		public static BigInteger nCr(int n, int r) {
			return Helper.BuildFactorial(n) / (Helper.BuildFactorial(r) * Helper.BuildFactorial(n - r));
		}
	}
}
