using Microsoft.VisualBasic.FileIO;
using TradeCategory.Trades;

namespace TradeCategory
{
	// Please, do note that program WILL crash if a wrong input is inserted. I've not dealt with errors at all,
	// which is noticeable by the lack of try/catch blocks
    public class Program
	{
		static void Main(string[] args)
		{
			InputParser inputParser = new InputParser();
			var tradeData = inputParser.trades_;
			iTradeFact tradeFact = new TradeFact(ref inputParser);
			List<ITrade> trades = tradeFact.BuildAllTrades();
			// cleanup. Not really sure how C# gc works, though.
			tradeFact = null;
			inputParser = null;

			// do something with the trades
		}
	}

}