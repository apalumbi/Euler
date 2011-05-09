using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem05 : Problem {

		public override string Solve() {
			int topNumber = 20;
			long startNumber = 1;
			for (int i = 1; i <= topNumber; i++) {
				startNumber *= i;
			}

			int result;
			for (result = topNumber; result < startNumber; result++) {
				bool isGood = true;
				for (int i = topNumber; i > 0; i--) {
					if (result % i != 0) {
						isGood = false;
						break;
					}
				}
				if (isGood) break;
			}

			return result.ToString();
		}

		public override string Solution {
			get { return "232792560"; }
		}
	}
}
