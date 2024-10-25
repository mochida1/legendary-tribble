using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Inputs;

namespace TradeCategory.Trades
{
    internal class TradeMediumRisk : ITrade
    {
        public TradeMediumRisk(ref UserParams userParams)
		{
			Value = userParams.Value;
			ClientSector = userParams.ClientSector;
			NextPaymentDate = userParams.NextPaymentDate;
			Console.WriteLine("MEDIUMRISK");
		}

		public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

    }
}
