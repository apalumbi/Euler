using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem24 : Problem {

		public override string Solve() {
			var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			return new PermutationGenerator<int>(numbers).GetSpecificPermutation(1000000);
		}

		public override string Solution {
			get { return "2783915460"; }
		}
	}
}
