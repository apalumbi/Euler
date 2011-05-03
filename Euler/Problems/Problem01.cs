using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem01 : Problem {

		public override string Solve() {
			int sum = 0;
			for (int i = 0; i < 1000; i++) {
				if (((i % 3) == 0) || ((i % 5) == 0)) {
					sum += i;
				}
			}
			return sum.ToString();
		}
	}
}
