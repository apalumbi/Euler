using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace Euler.Problems {
	public class Problem22 : Problem {

		public override string Solve() {
			var nameString = File.ReadAllText(@"Files\" + this.Name);
			var names = nameString.Replace('"', ' ').Split(',').ToList();
			names = names.OrderBy(a => a).ToList();

			BigInteger total = 0;
			int counter = 1;
			foreach (var name in names) {
				var points = 0;
				var chars = name.ToCharArray();
				foreach (var c in chars) {
					points += AlphabetPosition(c);
				}
				total += (points * counter);
				counter++;
			}

			return total.ToString();
		}

		static int AlphabetPosition(char letter) {
			switch (letter.ToString()) {
				case "A":
					return 1;
				case "B":
					return 2;
				case "C":
					return 3;
				case "D":
					return 4;
				case "E":
					return 5;
				case "F":
					return 6;
				case "G":
					return 7;
				case "H":
					return 8;
				case "I":
					return 9;
				case "J":
					return 10;
				case "K":
					return 11;
				case "L":
					return 12;
				case "M":
					return 13;
				case "N":
					return 14;
				case "O":
					return 15;
				case "P":
					return 16;
				case "Q":
					return 17;
				case "R":
					return 18;
				case "S":
					return 19;
				case "T":
					return 20;
				case "U":
					return 21;
				case "V":
					return 22;
				case "W":
					return 23;
				case "X":
					return 24;
				case "Y":
					return 25;
				case "Z":
					return 26;
				default:
					return 0;
			}
		}
	}
}
