using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem52 : Problem {
		public override string Solve() {
			for (int i = 2; i < 1000000; i++) {
				if (ContainsSameNumberWhenMultiplied(i, 6) &&
						ContainsSameNumberWhenMultiplied(i, 5) &&
						ContainsSameNumberWhenMultiplied(i, 4) &&
						ContainsSameNumberWhenMultiplied(i, 3) &&
						ContainsSameNumberWhenMultiplied(i, 2)) {
					return i.ToString();
				}
			}
			return Helper.GARF;
		}

		bool ContainsSameNumberWhenMultiplied(int number, int multiplication) {
			var doubleNumber = number * multiplication;
			var numberList = number.ToStringList();
			foreach (var d in doubleNumber.ToStringList()) {
				if (!numberList.Contains(d)) {
					return false;
				}
			}
			return true;
		}

		public override string Solution {
			get { return "142857"; }
		}
	}
}
