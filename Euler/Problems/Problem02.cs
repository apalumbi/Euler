using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem02 : Problem {

		public override string Solve() {
			int million = 4000000;
			int i = 1;
			int j = 2;
			int total = j;
			while (i < million || j < million) {
				int sum = i + j;
				if ((sum % 2) == 0) {
					total += sum;
				}
				i = j;
				j = sum;
			}
			return total.ToString();
		}
	}
}
