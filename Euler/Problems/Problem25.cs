using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem25 : Problem {

		public override string Solve() {
			var lengthToLookFor = 1000;

			BigInteger previousTerm = 0;
			BigInteger currentTerm = 1;
			int termCount = 1;
			while (currentTerm.ToString().Length != lengthToLookFor) {
				var result = currentTerm + previousTerm;
				previousTerm = currentTerm;
				currentTerm = result;
				termCount++;
			}

			return termCount.ToString();
		}

		public override string Solution {
			get { return "4782"; }
		}
	}
}
