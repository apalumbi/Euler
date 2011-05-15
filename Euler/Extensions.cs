using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler {
	public static class Extensions {
		public static List<string> ToStringList(this int number) {
			return number.ToString().Select(c => c.ToString()).ToList();
		}

		public static List<string> ToStringList(this string text) {
			return text.Select(c => c.ToString()).ToList();
		}

		public static List<string> ToStringList(this BigInteger number) {
			return number.ToString().Select(c => c.ToString()).ToList();
		}

		public static List<string> ToStringList(this long number) {
			return number.ToString().Select(c => c.ToString()).ToList();
		}

		public static BigInteger Reverse(this BigInteger number) {
			return BigInteger.Parse(new string(number.ToString().Reverse().ToArray()));
		}

		public static int Reverse(this int number) {
			return int.Parse(new string(number.ToString().Reverse().ToArray()));
		}
	}
}
