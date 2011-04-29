using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem31 : Problem {
		int totalCombinations = 0;
		int amountToFind = 100;

		public override string Solve() {
			var coin1 = new Coin { Value = 1, MaxUses = amountToFind / 1 };
			var coin2 = new Coin { Value = 2, MaxUses = amountToFind / 2 };
			var coin3 = new Coin { Value = 5, MaxUses = amountToFind / 5 };
			var coin4 = new Coin { Value = 10, MaxUses = amountToFind / 10 };
			var coin5 = new Coin { Value = 20, MaxUses = amountToFind / 20 };
			var coin6 = new Coin { Value = 50, MaxUses = amountToFind / 50 };
			var coin7 = new Coin { Value = 100, MaxUses = amountToFind / 100 };
			var coin8 = new Coin { Value = 200, MaxUses = amountToFind / 200 };
			var coins = new List<Coin> { coin1, coin2, coin3, coin4, coin5, coin6, coin7, coin8 };

			//var penny = new Coin { Value = 1, MaxUses = amountToFind / 1 };
			//var nickel = new Coin { Value = 5, MaxUses = amountToFind / 5 };
			//var dime = new Coin { Value = 10, MaxUses = amountToFind / 10 };
			//var quarter = new Coin { Value = 25, MaxUses = amountToFind / 25 };
			//var half = new Coin { Value = 50, MaxUses = amountToFind / 50 };
			//var coins = new List<Coin> { penny, nickel, dime, quarter, half };

			GetCombinations(0, 0, coins.OrderByDescending(c => c.Value).ToList());
			return totalCombinations.ToString();
		}

		void GetCombinations(int index, int amount, IList<Coin> coins) {
			if (index > coins.Count - 1) return;

			var coinToUse = coins[index];
			var timesThisCoinUsed = coinToUse.MaxUses;
			while (timesThisCoinUsed > -1) {
				var runningAmount = amount + (coinToUse.Value * timesThisCoinUsed);
				timesThisCoinUsed--;

				if (runningAmount == amountToFind) {
					totalCombinations++;
				}
				else if (runningAmount < amountToFind) {
					GetCombinations(index + 1, runningAmount, coins);
				}
			}
		}
	}

	public class Coin {
		public int Value;
		public int MaxUses;
	}
}
