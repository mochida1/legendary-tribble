using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Inputs;
using TradeCategory.Trades;

namespace TradeCategory.FactCreationStrats
{
	internal class InvalidCreationStrat : iFactCreationStrat
	{
		public InvalidCreationStrat(ref UserParams userParams)
		{
			return;
		}
		public ITrade Build() { return new TradeInvalid(); }
	}
}
