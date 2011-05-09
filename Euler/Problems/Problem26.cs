using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem26 : Problem {

		public override string Solve() {
			int max = 0;
			int maxd = 0;
			for (int d = 2; d < 1000; ++d) {
				var reminders = new HashSet<int>();
				int x = 1;
				int len = 0;
				while (x < d)
					x *= 10;

				while (x != 0) {
					if (reminders.Contains(x))
						break;

					reminders.Add(x);

					while (x < d) {
						x *= 10;
						len++;
					}
					x = x % d;
				}
				if (x != 0) {
					if (len > max) {
						maxd = d;
						max = len;
					}
				}
			}
			return maxd.ToString();
		}

		public override string Solution {
			get { return "983"; }
		}
	}
}
