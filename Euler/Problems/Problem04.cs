using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem04 : Problem {

		public override string Solve() {
			long currentMax = -1;
			long bigI = -1;
			long bigJ = -1;
			for (int i = 100; i < 1000; i++) {
				for (int j = 100; j < 1000; j++) {
					long product = i * j;
					if (Helper.IsPalindrome(product.ToString())) {
						if (product > currentMax) {
							bigI = i;
							bigJ = j;
							currentMax = product;
						}
					}
				}
			}
			return currentMax.ToString();
		}

		public override string Solution {
			get { return "906609"; }
		}
	}
}
