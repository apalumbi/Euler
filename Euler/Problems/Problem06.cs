using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem06 : Problem {

		public override string Solve() {
			int value = 100;
			long squareOfSum = 0;
			for (int i = 1; i <= value; i++) {
				squareOfSum += i;
			}
			squareOfSum = squareOfSum * squareOfSum;

			long sumOfSquares = 0;
			for (int i = 1; i <= value; i++) {
				sumOfSquares += i * i;
			}
			long result = squareOfSum - sumOfSquares;
			return result.ToString();
		}

		public override string Solution {
			get { return "25164150"; }
		}
	}
}
