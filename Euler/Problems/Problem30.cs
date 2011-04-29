using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem30 : Problem {
		public override string Solve() {
			var results = new List<double>();
			for (int i = 2; i < 10000000; i++) {
				string number = i.ToString();
				var numbers = number.ToList();
				double sum = 0;
				foreach (var n in numbers) {
					sum += Math.Pow(double.Parse(n.ToString()), 5);
					if (sum > i) {
						break;
					}
				}
				if (sum == i) {
					results.Add(sum);
				}
			}

			Helper.Write(string.Join(",", results.ToArray()));
			return results.Sum().ToString();
		}
	}
}
