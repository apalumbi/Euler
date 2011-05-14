using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem60 : Problem {

		bool IsPartPrime(int first, int second) {
			var permutationList = new List<int> { first, second };
			return Helper.IsPrime(long.Parse(first.ToString() + second.ToString())) &&
						 Helper.IsPrime(long.Parse(second.ToString() + first.ToString()));
		}

		public override string Solve() {
			var alreadyChecked = new HashSet<string>();
			var primes = Helper.BuildPrimes().ToList();

			var pairs = new List<List<int>>();

			for (int i = 800; i < 1100; i++) {
				for (int j = 800; j < 1100; j++) {
					var one = primes[i];
					var two = primes[j];
					var sortedList = new List<int> { one, two };
					sortedList.Sort();
					var sortedString = string.Join("", sortedList);
					if (one != two && !alreadyChecked.Contains(sortedString)) {
						if (IsPartPrime(one, two)) {
							pairs.Add(sortedList);
						}
						alreadyChecked.Add(sortedString);
					}
				}
			}

			alreadyChecked.Clear();
			var triples = new List<List<int>>();
			for (int i = 1; i < 100; i++) {
				foreach (var list in pairs) {
					var three = primes[i];
					if (!list.Contains(three)) {
						var sortedList = new List<int> { list[0], list[1], three };
						sortedList.Sort();
						if (IsPartPrime(list[0], three) &&
								IsPartPrime(list[1], three)) {
							triples.Add(sortedList);
						}
					}
				}
			}

			alreadyChecked.Clear();
			var quads = new List<List<int>>();
			for (int i = 500; i < 1000; i++) {
				foreach (var list in triples) {
					var four = primes[i];
					if (!list.Contains(four)) {
						var sortedList = new List<int> { list[0], list[1], list[2], four };
						if (IsPartPrime(list[0], four) &&
								IsPartPrime(list[1], four) &&
								IsPartPrime(list[2], four)) {
							quads.Add(sortedList);
						}
					}
				}
			}

			alreadyChecked.Clear();
			var pents = new List<List<int>>();
			for (int i = 500; i < 1000; i++) {
				foreach (var list in quads) {
					var five = primes[i];
					if (!list.Contains(five)) {
						var sortedList = new List<int> { list[0], list[1], list[2], list[3], five };
						if (IsPartPrime(list[0], five) &&
								IsPartPrime(list[1], five) &&
								IsPartPrime(list[2], five) &&
								IsPartPrime(list[3], five)) {
							pents.Add(sortedList);
						}
					}
				}
			}

			return pents.Min(p => p.Sum()).ToString();
		}

		public override string Solution {
			get { return "26033"; } //5197, 5701, 8389, 13, 6733
		}
	}
}
