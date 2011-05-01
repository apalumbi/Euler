using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem38 : Problem {

		public override string Solve() {
			BigInteger largestPandigital = 987654321;
			var results = new List<Pair<int, int>>();

			for (BigInteger i = largestPandigital; i > 918273645; i--) {
				if (Helper.CannotBePandigital(i.ToString())) {
					continue;
				}
				else {
					results = Do(i);
					if (results.Count() > 0) {
						break;
					}
				}
			}
			Helper.Write(string.Join(Environment.NewLine, results));

			return results.Last().Second.ToString();
		}
		
		private static List<Pair<int, int>> Do(BigInteger numberToCheck) {
			for (int i = 9000; i < 10000; i++) {
				var shouldContinue = true;
				var pairs = new List<Pair<int, int>>();
				var n = 1;
				var numberString = numberToCheck.ToString();
				var productString = "";
				while (shouldContinue) {
					var product  = i * n;
					productString += product.ToString();
					if (numberString.StartsWith(productString)) {
						pairs.Add(new Pair<int, int>(n, i));
					}
					else {
						shouldContinue = false;
					}

					if (productString == numberString) {
						pairs.Add(new Pair<int,int>(0, int.Parse(numberString)));
						return pairs;
					}
					n++;
				}
			}
			return new List<Pair<int, int>>();
		}
	}


	public class Pair<T, U> {
		public T First;
		public U Second;
		public Pair(T first, U second) {
			First = first;
			Second = second;
		}

		public override string ToString() {
			return First.ToString() + " X " + Second.ToString();
		}
	}
}
