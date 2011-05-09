using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem14 : Problem {

		public override string Solve() {
			long maxIteration = 0;
			long startingNumberForMaxIterations = 0;
			for (long startingNumber = 999999; startingNumber > 500000; startingNumber -= 2) {
				long iterations = Iterate(startingNumber);
				if (iterations > maxIteration) {
					maxIteration = iterations;
					startingNumberForMaxIterations = startingNumber;
				}
			}
			Helper.Write(maxIteration);
			return startingNumberForMaxIterations.ToString();
		}

		public override string Solution {
			get { return "837799"; }
		}

		long Iterate(long startingNumber) {
			long iterationNumber = startingNumber;
			long iterations = 1;
			while (iterationNumber != 1) {
				if (iterationNumber % 2 == 0) {
					iterationNumber = iterationNumber / 2;
				}
				else {
					iterationNumber = (3 * iterationNumber) + 1;
				}
				iterations++;
			}
			return iterations;
		}
	}
}
