using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem35 : Problem {
		public override string Solve() {
			var primes = Helper.BuildPrimes(1000000);

			var results = new List<int>();
			foreach (var prime in primes) {
				if (IsCircular(prime, primes)) {
					results.Add(prime);
				}
			}

			foreach (var item in results) {
				Helper.Write(item);
			}

			return results.Count.ToString();
		}

		static bool IsCircular(int prime, HashSet<int> primes) {
			var text = prime.ToString();

			if (GetRotations(text).ToList().TrueForAll(r => primes.Contains(int.Parse(r)))) {
				return true;
			}

			return false;
		}

		static IEnumerable<string> GetRotations(string text) {
			var list = text.ToList();
			var max = list.Count;
			var results = new List<string>();
			for (int i = 0; i < max; i++) {
				results.Add(Rotate(list, i));
			}
			return results;
		}

		static string Rotate(List<char> list, int i) {
			var max = list.Count - 1;

			var result = "";

			while (result.Length != list.Count) {
				i++;
				if (i > max) {
					i = 0;
				}
				result += list[i];
			}

			return result;
		}
	}
}
