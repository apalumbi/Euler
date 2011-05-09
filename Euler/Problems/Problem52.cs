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
			var perms = new PermutationGenerator<string>(number.ToStringList()).GetAllPermutations();
			var doubleNumber = number * multiplication;
			if (perms.Contains(doubleNumber.ToString())) {
				return true;
			}
			return false;
		}

		public override string Solution {
			get { return "142857"; }
		}
	}
}
