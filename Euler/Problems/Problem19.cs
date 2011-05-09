using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem19 : Problem {

		public override string Solve() {
			var startYear = 1901;
			var endYear = 2001;
			var counter = 0;
			for (int i = startYear; i < endYear; i++) {
				for (int j = 1; j <= 12; j++) {
					var date = new DateTime(i, j, 1);
					if (date.DayOfWeek == DayOfWeek.Sunday) {
						counter++;
					}
				}
			}

			return counter.ToString();
		}

		public override string Solution {
			get { return "171"; }
		}
	}
}
