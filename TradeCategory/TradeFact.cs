using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.FactCreationStrats;
using TradeCategory.Inputs;
using TradeCategory.Trades;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TradeCategory
{
	internal class TradeFact : iTradeFact
	{
		public TradeFact(ref InputParser inputParser)
		{
			this.inputs = inputParser;
			this.referenceDate_ = inputParser.referenceDate_;
			this.tradeIndex = 0;
		}
		public override List<ITrade> BuildAllTrades() {
			List<ITrade> tradeList = new List<ITrade>();
			foreach (var trade in inputs.trades_)
			{
				UserParams userParams = new UserParams(ref this.tradeIndex, ref this.inputs);
				SelectBuilder(ref userParams);
				++this.tradeIndex;
				tradeList.Add(this.creationStrat.Build());
			}
			return tradeList;
		}
		private void SetStrat(iFactCreationStrat strat) { this.creationStrat = strat; }
		public override void SelectBuilder(ref UserParams userParams)
		{
			// would've created a class that only deals with selecting how to build, but no time.
			if (this.isTradeExpired())
			{
				this.SetStrat(new ExpiredCreationStrat(ref userParams));
			}
			else if (this.isTradeMediumRisk())
			{
				this.SetStrat(new MediumRiskCreationStrat(ref userParams));
			}
			else if (this.isTradeLowRisk())
			{
				this.SetStrat(new LowRiskCreationStrat(ref userParams));
			}
			else
			{
				this.SetStrat(new InvalidCreationStrat(ref userParams));
			}
		}

		private bool isTradeExpired()
		{
			TimeSpan totalTime =  this.referenceDate_ - this.inputs.trades_[this.tradeIndex].Item3;
			return (totalTime.TotalDays > 30);
		}

		private bool isTradeMediumRisk()
		{
			return (this.isOverValueThreshold() && this.isPrivate());
		}

		private bool isTradeLowRisk()
		{
			return (this.isOverValueThreshold() && this.isPublic());
		}

		public bool isOverValueThreshold()
		{
			const double TRADEVALUETHRESHOLD = 1000000;
			return (this.inputs.trades_[tradeIndex].Item1 > TRADEVALUETHRESHOLD);
		}
		private bool isPrivate()
		{
			// we could have used a container here for abstraction, but kinda of sad for just 2 values
			return (this.inputs.trades_[this.tradeIndex].Item2 == "Private");
		}
		private bool isPublic()
		{
			return (this.inputs.trades_[this.tradeIndex].Item2 == "Public");
		}
		private InputParser inputs;
		private int tradeIndex;
		
	}
}

