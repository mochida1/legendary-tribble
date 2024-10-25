using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategory.Inputs
{
	internal class UserParams
	{
		public UserParams(ref int index, ref InputParser input) {
			Value = input.trades_[index].Item1;
			ClientSector = input.trades_[index].Item2;
			NextPaymentDate = input.trades_[index].Item3;
		}
			public double Value { get; }
			public string ClientSector { get; }
			public DateTime NextPaymentDate { get; }
	}
}
