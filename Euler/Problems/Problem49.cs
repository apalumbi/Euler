﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem49 : Problem {

		public override string Solve() {
			var numbers = new List<int>();
			var primes = Helper.BuildPrimes(1000000);

			var results = new List<string>();
			for (int i = 1; i <= 9999; i++) {
				for (int j = 1; j <= 9999; j++) {
					var first = i;
					var second = first + j;
					var third = second + j;

					if (primes.Contains(first) &&
							primes.Contains(second) &&
							primes.Contains(third) &&
							AllPermutations(first, second, third)) {
								results.Add(first.ToString() + second.ToString() + third.ToString());
					}
				}
			}

			Helper.Write(string.Join(Environment.NewLine, results));

			return results.LastOrDefault();
		}

		bool AllPermutations(int first, int second, int third) {
			var permutations = new PermutationGenerator<string>(first.ToString().Select(c => c.ToString()).ToList()).GetAllPermutations();

			return permutations.Contains(first.ToString()) &&
						 permutations.Contains(second.ToString()) &&
						 permutations.Contains(third.ToString());

		}
	}
}
