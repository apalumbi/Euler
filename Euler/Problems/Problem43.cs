using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem43 : Problem {

		public override string Solve() {
			var count = 0;
			for (BigInteger i = 1023456789; i <= 1032456789; i++) {
				if (Helper.IsPandigital(i.ToString(), false, zerosCount: 1)) {
					count++;
				}
			}

			return count.ToString();
		}
	}
}
