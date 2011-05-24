using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem26 : Problem {

		public override string Solve() {
			int maxLength = 0;
			int result = 0;

			for (int numberToDivide = 2; numberToDivide < 1000; ++numberToDivide) {
				var alreadyChecked = new HashSet<int>();
				int remainder = 1;
				int length = 0;

				while (remainder < numberToDivide) {
					remainder *= 10;
				}
				
				while (remainder != 0) {
					if (alreadyChecked.Contains(remainder)) {
						break;
					}

					alreadyChecked.Add(remainder);
					while (remainder < numberToDivide) {
						remainder *= 10;
						length++;
					}
					remainder = remainder % numberToDivide;
				}
				if (remainder != 0) {
					if (length > maxLength) {
						result = numberToDivide;
						maxLength = length;
					}
				}
			}
			return result.ToString();
		}

		public override string Solution {
			get { return "983"; }
		}
	}
}
