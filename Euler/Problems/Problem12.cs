using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem12 : Problem {
		static List<int> divisors = new List<int>();
		static List<int> results = new List<int>();

		public override string Solve() {
			int value = 0;
			int i;
			for (i = 0; value < int.MaxValue; i++) {
				DoIt(value);
				if (results.Count > 500) {
					break;
				}
				value += i;
			}
			results.Sort();
			return results[results.Count - 1].ToString();

		}

		void DoIt(int z) {
			int x;
			results = new List<int>();
			for (x = 1; x * x < z; x++) {
				if ((z % x) == 0) {
					results.Add(x);
					results.Add(z / x);
				}
			}
		}

		public override string Solution {
			get { return "76576500"; }
		} 	}
}
