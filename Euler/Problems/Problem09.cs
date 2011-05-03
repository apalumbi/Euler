using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem09 : Problem {

		public override string Solve() {
			for (int i = 1; i <= 1000; i++) {
				for (int j = 1; j <= 1000; j++) {
					for (int k = 1; k <= 1000; k++) {
						if (((i * i) + (j * j)) == (k * k)) {
							if ((i + j + k) == 1000) {
								long product = i * j * k;
								return i.ToString() + " " + j.ToString() + " " + k.ToString() + " = " + product;
							}
						}
					}
				}
			}
			return "garf";
		}
	}
}
