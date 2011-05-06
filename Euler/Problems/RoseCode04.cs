using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems {
	public class RoseCode04 : Problem {

		public override string Solve() {
			var primes = Helper.BuildPrimes(1000000).Where(p => p < 1000000).ToList();

			var pairs = new List<Pair<int, int>>();
			for (int i = 0; i < primes.Count - 1; i++) {
				if (primes[i + 1] - primes[i] == 2) {
					pairs.Add(new Pair<int, int>(primes[i], primes[i + 1]));
				}
			}

			var distance = 0;
			for (int i = 0; i < pairs.Count - 1; i++) {
				var currentDistance = pairs[i + 1].First - pairs[i].First;
				if (currentDistance > distance) {
					distance = currentDistance;
				}
			}

			return distance.ToString();
		}
	}
}