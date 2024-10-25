using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.FactCreationStrats;
using TradeCategory.Inputs;
using TradeCategory.Trades;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TradeCategory
{
    internal abstract class iTradeFact
	{
		// should have used an abstract object here :|
		public abstract List<ITrade> BuildAllTrades();
		public abstract void SelectBuilder(ref UserParams userParams);

		protected iFactCreationStrat? creationStrat;
		protected DateTime referenceDate_;
	}
}
