using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategory
{
	internal class InputParser
	{
		public InputParser() {
			this.referenceDate_ = userReferenceDate_();
			this.numberOfTrades_ = userNumberOfTrades_();
			this.trades_ = new List<(double, string, DateTime)>();
			userTrades_(); 
		}
		private DateTime userReferenceDate_()
		{
			string? userInput = null;
			while (userInput == null)
			{
				Console.Write("Reference date: ");
				userInput = Console.ReadLine();
			}
			// ugly, I know...No time to check how to do it the nice way
			string[] dataFmt = userInput.Split('/');
			DateTime referenceDate = DateTime.Parse(dataFmt[1] + "/" + dataFmt[0] + "/" + dataFmt[2]);
			// Console.WriteLine(referenceDate.ToString());
			return referenceDate;
		}

		private int userNumberOfTrades_()
		{

			string? userInput = null;
			int numberOfTrades = 0;
			// Because C# does not lets you build almost wrong code
			while (true)
			{
				Console.Write("Number of trades: ");
				userInput = Console.ReadLine();
				if (Int32.TryParse(userInput, out numberOfTrades))
				{
					break;
				}
			}
			// Console.WriteLine(numberOfTrades);
			return numberOfTrades;
		}

		private void userTrades_()
		{
			string? userInput = null;
			Console.WriteLine(this.trades_.Count);
			int index = 1;
			while (userInput == null || this.trades_.Count < this.numberOfTrades_)
			{
				Console.Write($"Trade {index}: ");
				userInput = Console.ReadLine();
				if (userInput != null)
				{
					string[] tradeStrings = userInput.Split(" ");
					double value = double.Parse(tradeStrings[0]);
					string sector = tradeStrings[1];
					string[] dataFmt = tradeStrings[2].Split('/');
					DateTime date = DateTime.Parse(dataFmt[1] + "/" + dataFmt[0] + "/" + dataFmt[2]);
					var trade = (value, sector, date);
					this.trades_.Add(trade);
					index++;
				}
			}
			return;
		}

		public DateTime referenceDate_ { get; }
		public int numberOfTrades_ { get; }
		public List<(double, string, DateTime)> trades_ { get; }

	}
}
