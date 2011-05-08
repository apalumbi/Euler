using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem54 : Problem {

		public override string Solve() {
			var hands = File.ReadAllLines(@"Files\" + this.Name).ToList();

			foreach (var hand in hands) {
				var player1Cards = new List<Pair<int, string>>();
				var player2Cards = new List<Pair<int, string>>();

				var cards = hand.Split(' ').ToList();
				for (int i = 0; i < cards.Count; i++) {
					if (i < 5) {
						player1Cards.Add(new Pair<int, string>(GetCardValue(cards[i].Substring(0, 1)), cards[i].Substring(1, 1)));
					}
					else {
						player2Cards.Add(new Pair<int, string>(GetCardValue(cards[i].Substring(0, 1)), cards[i].Substring(1, 1)));
					}
				}

				Helper.Write(string.Join("", player1Cards));
			}

			return hands.Count.ToString();
		}

		private static int GetCardValue(string card) {
			if (card == "A") {
				return 14;
			}
			if (card == "K") {
				return 13;
			}
			if (card == "Q") {
				return 12;
			}
			if (card == "J") {
				return 11;
			}
			if (card == "T") {
				return 10;
			}
			return int.Parse(card);
		}
	}
}
