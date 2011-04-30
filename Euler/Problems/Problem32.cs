using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem32 : Problem {
		public override string Solve() {
			var results = new HashSet<BigInteger>();
			for (BigInteger i = 0; i < 10000; i++) {
				if (Helper.CannotBePandigital(i.ToString())) {
					continue;
				}

				for (BigInteger j = 0; j < 10000; j++) {
					if (Helper.CannotBePandigital(j.ToString())) {
						continue;
					}

					var product = i * j;
					if (product.ToString().Length > 9) {
						continue;
					}
					var number = i.ToString() + j.ToString() + product.ToString();
					if (Helper.IsPandigital(number)) {
						if (!results.Contains(product)) {
							results.Add(product);
							Helper.Write(number);
						}
					}
				}
			}

			BigInteger sum = 0;
			foreach (var r in results) {
				sum += r;
			}
			return sum.ToString();
		}
	}
}