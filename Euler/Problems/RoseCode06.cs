using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;

namespace Euler.Problems {
	public class RoseCode06 : Problem {

		public override string Solve() {
			var results = new List<BigInteger>();
			for (BigInteger i = 0; i < 8000000; i++) {
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

			BigInteger sum = 0;
			foreach (var result in results) {
				sum += result;
			}
			return sum.ToString();
		}

		public override string Solution {
			get { return "10976698"; }
		}
	}
}