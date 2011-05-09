using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem54 : Problem {
		List<Pair<int, string>> player1Cards = new List<Pair<int, string>>();
		List<Pair<int, string>> player2Cards = new List<Pair<int, string>>();

		public override string Solve() {
			var hands = File.ReadAllLines(@"Files\" + this.Name).ToList();
			var player1wins = 0;
			var player2wins = 0;
			var ties = 0;
			foreach (var hand in hands) {
				SetupHands(hand);

				var player1Result = ValueHand(player1Cards);
				var player2Result = ValueHand(player2Cards);

				if (player1Result.HandResult > player2Result.HandResult) {
					player1wins++;
				}
				else if (player2Result.HandResult > player1Result.HandResult) {
					player2wins++;
				}
				else {
					if (player1Result.Differentiator.First > player2Result.Differentiator.First) {
						player1wins++;
					}
					else if (player2Result.Differentiator.First > player1Result.Differentiator.First) {
						player2wins++;
					}
					else {
						if (player1Result.HighCard.First > player2Result.HighCard.First) {
							player1wins++;
						}
						else if (player2Result.HighCard.First > player1Result.HighCard.First) {
							player2wins++;
						}
						else {
							ties++;
						}
					}
				}
			}
			return player1wins.ToString();
		}

		PlayerResult ValueHand(List<Pair<int, string>> cards) {
			var ordered = cards.OrderByDescending(c => c.First).ToList();
			if (IsRoyalFlush(ordered)) {
				return new PlayerResult { HandResult = HandResult.RoyalFlush };
			}
			if (IsStraightFlush(ordered)) {
				return new PlayerResult { HandResult = HandResult.StraightFlush, HighCard = ordered.First(), Differentiator = ordered.First() };
			}
			if (IsFourOfAKind(ordered)) {
				return new PlayerResult { HandResult = HandResult.FourOfAKind };
			}
			if (IsFullHouse(ordered)) {
				return new PlayerResult { HandResult = HandResult.FullHouse };
			}
			if (IsFlush(ordered)) {
				return new PlayerResult { HandResult = HandResult.Flush, HighCard = ordered.First(), Differentiator = ordered.First() };
			}
			if (IsStraight(ordered)) {
				return new PlayerResult { HandResult = HandResult.Straight, HighCard = ordered.First(), Differentiator = ordered.First() };
			}
			if (IsThreeOfAKind(ordered)) {
				return new PlayerResult { HandResult = HandResult.ThreeOfAKind };
			}
			if (IsTwoPair(ordered)) {
				return new PlayerResult { HandResult = HandResult.TwoPair };
			}
			var result = IsPair(ordered);
			if (result != null) {
				return new PlayerResult { HandResult = HandResult.Pair, Differentiator = result, HighCard = ordered.First() };
			}
			return new PlayerResult { HandResult = HandResult.HighCard, HighCard = ordered.First(), Differentiator = ordered.First() };
		}

		bool IsTwoPair(List<Pair<int, string>> cards) {
			var groups = cards.GroupBy(c => c.First);

			return groups.Where(g => g.Count() == 2).Count() == 2;
		}

		Pair<int, string> IsPair(List<Pair<int, string>> cards) {
			var groups = cards.GroupBy(c => c.First);

			if (groups.Any(g => g.Count() == 2)) {
				return new Pair<int, string>(groups.Where(g => g.Count() == 2).First().Key, "");
			}
			return null;
		}

		bool IsThreeOfAKind(List<Pair<int, string>> cards) {
			var groups = cards.GroupBy(c => c.First);

			return groups.Any(g => g.Count() == 3);
		}

		bool IsFullHouse(List<Pair<int, string>> cards) {
			var groups = cards.GroupBy(c => c.First);

			return groups.Where(g => g.Count() == 2).Count() == 1 && groups.Where(g => g.Count() == 3).Count() == 1;
		}

		bool IsFourOfAKind(List<Pair<int, string>> cards) {
			var groups = cards.GroupBy(c => c.First);

			return groups.Any(g => g.Count() == 4);
		}

		bool IsStraight(List<Pair<int, string>> cards) {
			return (cards.Exists(c => c.First == cards.First().First - 1) &&
							cards.Exists(c => c.First == cards.First().First - 2) &&
							cards.Exists(c => c.First == cards.First().First - 3) &&
							cards.Exists(c => c.First == cards.First().First - 4)) ||
						 (cards.Exists(c => c.First == 14) &&
							cards.Exists(c => c.First == 2) &&
							cards.Exists(c => c.First == 3) &&
							cards.Exists(c => c.First == 4) &&
							cards.Exists(c => c.First == 5));
		}

		bool IsStraightFlush(List<Pair<int, string>> cards) {
			return IsFlush(cards) &&
						 IsStraight(cards);
		}

		bool IsRoyalFlush(List<Pair<int, string>> cards) {
			if (!IsFlush(cards)) {
				return false;
			}

			return cards.Exists(c => c.First == 14) &&
						 cards.Exists(c => c.First == 13) &&
						 cards.Exists(c => c.First == 12) &&
						 cards.Exists(c => c.First == 11) &&
						 cards.Exists(c => c.First == 10);
		}

		bool IsFlush(List<Pair<int, string>> cards) {
			var suit = cards.First().Second;
			return cards.TrueForAll(c => c.Second == suit);
		}

		void SetupHands(string hand) {
			player1Cards = new List<Pair<int, string>>();
			player2Cards = new List<Pair<int, string>>();
			var cards = hand.Split(' ').ToList();
			for (int i = 0; i < cards.Count; i++) {
				if (i < 5) {
					player1Cards.Add(new Pair<int, string>(GetCardValue(cards[i].Substring(0, 1)), cards[i].Substring(1, 1)));
				}
				else {
					player2Cards.Add(new Pair<int, string>(GetCardValue(cards[i].Substring(0, 1)), cards[i].Substring(1, 1)));
				}
			}
		}

		static int GetCardValue(string card) {
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

		public override string Solution {
			get { return "376"; }
		}

		class PlayerResult {
			public HandResult HandResult { get; set; }
			public Pair<int, string> HighCard { get; set; }
			public Pair<int, string> Differentiator { get; set; }
			public PlayerResult() {
				Differentiator = new Pair<int, string>(0, "");
				HighCard = new Pair<int, string>(0, "");
			}
		}

		enum HandResult {
			RoyalFlush = 10,
			StraightFlush = 9,
			FourOfAKind = 8,
			FullHouse = 7,
			Flush = 6,
			Straight = 5,
			ThreeOfAKind = 4,
			TwoPair = 3,
			Pair = 2,
			HighCard = 1
		}
	}
}
