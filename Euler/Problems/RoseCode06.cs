using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;

namespace Euler.Problems {
	public class RoseCode06 : Problem {

		public override string Solve() {
			var results = new List<long>();
			for (long i = 0; i < 8000000; i++) {
				var baseFour = Helper.ConvertToBase(i, 4);
				if (!Helper.IsPalindrome(baseFour)) {
					continue;
				}
				var baseSix = Helper.ConvertToBase(i, 6);
				if (!Helper.IsPalindrome(baseSix)) {
					continue;
				}
				results.Add(i);
			}

			return results.Sum().ToString();
		}

		public override string Solution {
			get { return "10976698"; }
		}
	}
}