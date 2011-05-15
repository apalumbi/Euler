using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem61 : Problem {

		public override string Solve() {
			var triangles = RunFormula(FormulaType.Triangle, Formulas.Triangle);
			var squares = RunFormula(FormulaType.Square, Formulas.Square);
			var pentagonals = RunFormula(FormulaType.Pentagonal, Formulas.Pentagonal);
			var hexagonals = RunFormula(FormulaType.Hexagonal, Formulas.Hexogonal);
			var heptagonals = RunFormula(FormulaType.Heptagonal, Formulas.Heptagonal);
			var octogonals = RunFormula(FormulaType.Octogonal, Formulas.Octogonal);

			foreach (var first in triangles.Second) {
				var firstPair = GetLastTwo(first);
				foreach (var second in GetMatches(firstPair, squares, pentagonals, hexagonals, heptagonals, octogonals)) {
					var secondPair = GetLastTwo(second.Second);
					foreach (var third in GetMatches(secondPair, GetLists(new List<FormulaType> { second.First }, squares, pentagonals, hexagonals, heptagonals, octogonals))) {
						var thirdPair = GetLastTwo(third.Second);
						foreach (var forth in GetMatches(thirdPair, GetLists(new List<FormulaType> { second.First, third.First }, squares, pentagonals, hexagonals, heptagonals, octogonals))) {
							var forthPair = GetLastTwo(forth.Second);
							foreach (var fifth in GetMatches(forthPair, GetLists(new List<FormulaType> { second.First, third.First, forth.First }, squares, pentagonals, hexagonals, heptagonals, octogonals))) {
								var fifthPair = GetLastTwo(fifth.Second);
								foreach (var sixth in GetMatches(fifthPair, GetLists(new List<FormulaType> { second.First, third.First, forth.First, fifth.First }, squares, pentagonals, hexagonals, heptagonals, octogonals))) {
									if (first.ToString().StartsWith(GetLastTwo(sixth.Second))) {
										return (first + second.Second + third.Second + forth.Second + fifth.Second + sixth.Second).ToString();
									}
								}
							}
						}
					}
				}
			}

			return Helper.GARF;
		}

		Pair<FormulaType, HashSet<BigInteger>> RunFormula(FormulaType type, Func<BigInteger, BigInteger> formula) {
			var results = new HashSet<BigInteger>();
			for (BigInteger i = 0; i < 1000; i++) {
				var result = formula(i);
				if (result > 999 && result < 10000) {
					results.Add(result);
				}
			}
			return new Pair<FormulaType, HashSet<BigInteger>>(type, results);
		}

		string GetLastTwo(BigInteger triangle) {
			return triangle.ToString().Substring(2, 2);
		}

		IEnumerable<Pair<FormulaType, BigInteger>> GetMatches(string match, params Pair<FormulaType, HashSet<BigInteger>>[] numberLists) {
			var results = new List<Pair<FormulaType, BigInteger>>();
			foreach (var list in numberLists) {
				results.AddRange(list.Second.Where(s => s.ToString().StartsWith(match)).Select(p => new Pair<FormulaType, BigInteger>(list.First, p)));
			}
			return results.Distinct();
		}

		Pair<FormulaType, HashSet<BigInteger>>[] GetLists(IEnumerable<FormulaType> filterType, params Pair<FormulaType, HashSet<BigInteger>>[] numberLists) {
			var results = new List<Pair<FormulaType, HashSet<BigInteger>>>();
			foreach (var list in numberLists) {
				if (!filterType.Contains(list.First)) {
					results.Add(list);
				}
			}
			return results.ToArray(); ;
		}	

		public override string Solution {
			get { return "28684"; } //8256 - 5625 - 2512 - 1281 - 8128 - 2882
		}

		enum FormulaType {
			Triangle,
			Square,
			Pentagonal,
			Hexagonal,
			Heptagonal,
			Octogonal
		}
	}
}
