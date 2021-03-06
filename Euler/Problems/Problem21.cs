﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem21 : Problem {

		public override string Solve() {
			var amicables = new List<int>();

			for (int i = 1; i <= 10000; i++) {
				GetAmicables(amicables, i);
			}
			return amicables.Sum().ToString();
		}

		void GetAmicables(List<int> amicables, int number) {
			var divisors = Helper.GetDivisors(number);
			var divisors2 = Helper.GetDivisors(divisors.Sum());
			if (divisors2.Sum() == number && divisors.Sum() != divisors2.Sum()) {
				amicables.Add(number);
			}
		}

		public override string Solution {
			get { return "31626"; }
		}
	}
}
