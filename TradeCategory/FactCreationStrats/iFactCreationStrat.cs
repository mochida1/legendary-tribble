using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Trades;
using TradeCategory.Inputs;

namespace TradeCategory.FactCreationStrats
{
    internal interface iFactCreationStrat
    {
        public ITrade Build();
    }
}
