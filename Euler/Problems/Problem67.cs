using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem67 : Problem {

		public override string Solve() {
			var triangle = File.ReadAllLines(@"Files\" + this.Name);

			var lookup = new Dictionary<int, List<int>>();
			int row = 0;
			foreach (var line in triangle) {
				lookup.Add(row, line.Split(' ').Select(l => int.Parse(l)).ToList());
				row++;
			}


			var crunch = new List<int>();
			for (int i = 0; i < triangle.Count(); i++) {
				var maxValues = new List<int>();
				var rowToCalc = lookup[i];

				if (i == 0) {
					maxValues.Add(rowToCalc[i]);
				}
				else {
					int rowMax = 0;
					int selection = 0;
					for (int column = 0; column < rowToCalc.Count(); column++) {
						if (column == 0) {
							maxValues.Add(rowToCalc[column] + crunch[column]);
						}
						else if (column == rowToCalc.Count - 1) {
							maxValues.Add(rowToCalc[column] + crunch[crunch.Count - 1]);
						}
						else {
							var first = rowToCalc[column] + crunch[column - 1];
							var second = rowToCalc[column] + crunch[column];
							if (first > second) {
								maxValues.Add(first);
							}
							else {
								maxValues.Add(second);
							}
						}
					}
				}
				crunch = maxValues;
			}

			return crunch.Max().ToString();

		}
	}
}
