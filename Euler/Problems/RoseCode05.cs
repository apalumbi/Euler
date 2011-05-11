using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems {
	public class RoseCode05 : Problem {

		public override string Solve() {
			var limit = 1000;
			var primes = Helper.BuildPrimes().Where(p => p < limit).ToList();

			var pairs = new HashSet<string>();
			foreach (var i in primes) {
				foreach (var j in primes) {
					var number1 = int.Parse(i.ToString() + j.ToString());
					var number2 = int.Parse(j.ToString() + i.ToString());
					if (Helper.IsPrime(number1) &&
							Helper.IsPrime(number2)) {
						var order = new List<int> {i, j};
						order.Sort();
						if (!pairs.Contains(order[0].ToString() + order[1].ToString())) {
							pairs.Add(order[0].ToString() + order[1].ToString());
						}
					}
				}
			}
			
			return pairs.Count.ToString();
		}
		
		public override string Solution {
			get { return "764"; }
		}
	}
}