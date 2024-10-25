using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Inputs;
using TradeCategory.Trades;

namespace TradeCategory.FactCreationStrats
{
	internal class ExpiredCreationStrat : iFactCreationStrat
	{
		public ExpiredCreationStrat(ref UserParams userParams) {
			up_ = userParams;
		}
		public ITrade Build() { return new TradeExpired(ref up_); }
		private UserParams up_;
	}
	
}
