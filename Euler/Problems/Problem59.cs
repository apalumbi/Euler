using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem59 : Problem {
		string currentWord = "";
		int index = 0;

		public override string Solve() {
			var codes = File.ReadAllText(@"Files\Problem59").Split(',').Select(s => Convert.ToChar(int.Parse(s))).ToList();
			var words = GetWords();

			foreach (var cipher in GetValidCiphers()) {
				var sumOfCodes = 0;
				currentWord = "";
				index = 0;
				while (index < codes.Count) {
					sumOfCodes += ValueConversion(cipher[0], codes);
					index++;
					if (index > codes.Count - 1) break;

					sumOfCodes += ValueConversion(cipher[1], codes);
					index++;
					if (index > codes.Count - 1) break;

					sumOfCodes += ValueConversion(cipher[2], codes);
					index++;
				}
				var wordList = currentWord.Split(' ');
				if (wordList.Count(w => words.Contains(w.ToUpper())) > 100) {
					return sumOfCodes.ToString();
				}
			}
			return Helper.GARF;
		}

		HashSet<string> GetWords() {
			var wordList = File.ReadAllText(@"Files\Problem42").Replace("\"", "").Split(',');
			var words = new HashSet<string>();
			foreach (var word in wordList) {
				words.Add(word);
			}
			return words;
		}

		List<string> GetValidCiphers() {
			var validCiphers = new List<string>();

			for (char one = 'a'; one < 'z'; one++) {
				for (char two = 'a'; two < 'z'; two++) {
					for (char three = 'a'; three < 'z'; three++) {
						validCiphers.Add(one.ToString() + two.ToString() + three.ToString());
					}
				}
			}
			return validCiphers;
		}

		int ValueConversion(char cipherCharacter, List<char> codes) {
			var c = Convert.ToChar(cipherCharacter ^ codes[index]);

			if (Helper.AlphabetPosition(c) != 0) {
				currentWord += c;
			}
			else {
				currentWord += " ";
			}
			return cipherCharacter ^ codes[index];
		}
		
		public override string Solution {
			get { return "107359"; }
		}
	}
}