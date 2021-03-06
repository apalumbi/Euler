﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem58 : Problem {

		public override string Solve() {
			var number = 1;
			var increment = 0;
			var numberCount = 1;

			var primeCount = 0;
			var ratio = 0m;
			do {
				increment = increment + 2;
				for (int i = 0; i < 4; i++) {
					number += increment;
					if (Helper.IsPrime(number)) {
						primeCount++;
						}
					numberCount++;
				}

				ratio = decimal.Parse(primeCount.ToString())/decimal.Parse(numberCount.ToString());
			} while (ratio > .1m);
			
			return (increment + 1).ToString();
		}

		public override string Solution {
			get { return "26241"; }
		}
	}
}
