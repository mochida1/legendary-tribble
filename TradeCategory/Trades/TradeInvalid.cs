using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategory.Trades
{
	internal class TradeInvalid : ITrade
	{
		public TradeInvalid() {
			this.Value = 0;
			this.ClientSector = "";
			this.NextPaymentDate = DateTime.MinValue;
		}
		public double Value { get; } //indicates the transaction amount in dollars
		public string ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
		public DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
	}
}
