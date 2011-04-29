using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem34 : Problem {
		public override string Solve() {
			var results = new List<BigInteger>();
			for (BigInteger i = 50000; i > 2; i--) {
				var numbers = i.ToString().ToList();
				int sum = 0;
				foreach (var n in numbers) {
					var pro = int.Parse(n.ToString());
					var fact = 1;
					for (int j = 1; j <= pro; j++) {
						fact *= j;
					}
					sum += fact;
				}
				if (sum == i) {
					results.Add(i);
					Helper.Write(i);
				}
			}


			BigInteger total = 0;
			foreach (var r in results) {
				total += r;
			}
			return total.ToString();
		}
	}
}
