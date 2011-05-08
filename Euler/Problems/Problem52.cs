using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem52 : Problem {
		public override string Solve() {
			for (int i = 2; i < 1000000; i++) {
				if (ContainsSameNumberWhenMultiplied(i, 2) &&
						ContainsSameNumberWhenMultiplied(i, 3) &&
						ContainsSameNumberWhenMultiplied(i, 4) &&
						ContainsSameNumberWhenMultiplied(i, 5) &&
						ContainsSameNumberWhenMultiplied(i, 6)) {
							return i.ToString();
				}
			}
			return "garf";
		}

		private static bool ContainsSameNumberWhenMultiplied(int number, int multiplication) {
			var numberList = number.ToString().Select(c => c.ToString()).ToList();
			var perms = new PermutationGenerator<string>(numberList).GetAllPermutations();
			var doubleNumber = number * multiplication;
			if (perms.Contains(doubleNumber.ToString())) {
				return true;
			}
			return false;
		}
	}
}
