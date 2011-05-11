using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem57 : Problem {
		public override string Solve() {
			var count = 0;
			
			BigInteger numerator = 3;
			BigInteger denominator = 2;

			BigInteger numeratorAddition = 1;
			BigInteger denominatorAddition = 1;


			var expansions = 0;
			while (expansions < 1000) {
				var newNumeratorAddition = numerator;
				var newDenominatorAddition = denominator;

				numerator = numerator * 2 + numeratorAddition;
				denominator = denominator * 2 + denominatorAddition;

				numeratorAddition = newNumeratorAddition;
				denominatorAddition = newDenominatorAddition;

				if (numerator.ToString().Length > denominator.ToString().Length) {
					count++;
				}

				expansions++;

			}

			return count.ToString();
		}
	}
}
