﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem39 : Problem {

		public override string Solve() {
			var pairs = new List<Pair<string, int>>();
			for (int i = 1; i < 1000; i++) {
				var pair = FindIntegrals(i);
				pairs.Add(pair);
			}
			var maxPair = pairs.OrderByDescending(p => p.Second).First();
			Helper.Write(maxPair.First.ToString());
			return maxPair.Second.ToString();
		}

		private static Pair<string, int> FindIntegrals(int limit) {
			var integrals = "";
			var count = 0;
			var alreadyAdded = new HashSet<string>();

			for (int a = 1; a < limit; a++) {
				for (int b = 1; b < limit; b++) {
					if (a + b > limit) {
						break;
					}
					var c = QuadraticFormula(a, b);
					if (c + a + b == limit) {
						var list = new List<string> { a.ToString(), b.ToString(), c.ToString() };
						list.Sort();
						if (!alreadyAdded.Contains(list[0] + list[1] + list[2])) {
							count++;
							integrals += "{" + list[0] + "," + list[1] + "," + list[2] + "} ";
							alreadyAdded.Add(list[0] + list[1] + list[2]);
						}
					}
				}
			}
			
			return new Pair<string, int>(integrals, count);
		}


		private static double QuadraticFormula(int a, int b) {
			var aSquaredPlusbSquared = (a * a) + (b * b);
			var c = Math.Sqrt(aSquaredPlusbSquared);
			return c;
		}
	}
}
