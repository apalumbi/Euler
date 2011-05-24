using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem05 : Problem {

		public override string Solve() {
			long topNumber = 20;
			
			long result;
			for (result = topNumber; result < Helper.BuildFactorialUsingLongs(topNumber); result = result + 20) {
				bool isGood = true;
				for (long i = topNumber; i > 0; i--) {
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
