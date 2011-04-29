using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem28 : Problem {
		public override string Solve() {
			var start = 1;
			var increment = 0;

			var grid = new List<List<int>>();

			var lastNumber = start;
			while (increment != 1001 - 1) {
				var row = new List<int>();
				increment = increment + 2;
				for (int j = 1; j <= 4; j++) {
					lastNumber = lastNumber + increment;
					row.Add(lastNumber);
				}
				grid.Add(row);
			}

			var sum = 0;
			foreach (var row in grid) {
				sum += row.Sum();
			}

			return (sum + 1).ToString();
		}
	}
}
