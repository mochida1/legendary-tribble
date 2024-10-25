using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Inputs;

namespace TradeCategory.Trades
{
    internal class TradeExpired : ITrade
    {
        public TradeExpired(ref UserParams userParams)
        {
            Value = userParams.Value;
            ClientSector = userParams.ClientSector;
            NextPaymentDate = userParams.NextPaymentDate;
            Console.WriteLine("EXPIRED");
        }

        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

    }
}
