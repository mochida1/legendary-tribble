using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Inputs;
using TradeCategory.Trades;

namespace TradeCategory.FactCreationStrats
{
	internal class LowRiskCreationStrat : iFactCreationStrat
	{
		public LowRiskCreationStrat(ref UserParams userParams)
		{
			up_ = userParams;
		}
		public ITrade Build() { return new TradeLowRisk(ref up_); }
		private UserParams up_;
	}
}
