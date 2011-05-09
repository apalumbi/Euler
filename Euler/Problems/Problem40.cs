using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem40 : Problem {
		int counter = 9;
		string allNumbers = "123456789";
		HashSet<int> dPoints = new HashSet<int> { 1, 10, 100, 1000, 10000, 100000, 100000 };
		public override string Solve() {
			
			for (int first = 1; counter < 100001; first++) {
				for (int second = 0; second < 10; second++) {
					counter += NumberToString(first);
					counter += NumberToString(second);
				}
			}

			var products = new List<int>();
			foreach (var d in dPoints) {
				products.Add(int.Parse(allNumbers.ElementAt(d - 1).ToString()));
			}

			var product = 1;
			foreach (var multi in products) {
				product *= multi;
			}

			return product.ToString();
		}

		int NumberToString(int first) {
			var numberString = first.ToString();
			allNumbers += numberString;
			return numberString.Length;
		}

		public override string Solution {
			get { return "210"; }
		}
	}
}
