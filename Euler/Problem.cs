using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public abstract class Problem {
		public abstract string Solve();

		public string Name {
			get { return this.GetType().Name; }
		}
	}
}
