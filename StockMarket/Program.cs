using System;
using System.Collections.Generic;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var StockHistory = new List<int> {
                12,13,14,14,15,16,15,14,13,12,12,11,10,11,12,12,13,14,14,13,12,11,10,9,8,8,9,10,11,12,13,14,15,16,17,17,16,15,14
            };

            ProcessStock(StockHistory);
            StockHistory.Reverse();
            ProcessStock(StockHistory);

            for (int i = 0; i < 10; i++)
                ProcessStock(Utils.RandomStock);
        }

        static void ProcessStock(List<int> StockHistory)
        {
            var stockDelta = new StockDelta(StockHistory);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < StockHistory.Count - 1; i++)
            { //TODO : Check profit before changing
                Utils.WriteChart(i, StockHistory[i], StockHistory[i + 1]);

                if (StockHistory[i] < stockDelta.start.value)
                {
                    stockDelta = new StockDelta(i, StockHistory[i]);
                }
                if (StockHistory[i] > stockDelta.end.value)
                {
                    stockDelta.end.position = i;
                    stockDelta.end.value = StockHistory[i];
                }
            }
            Utils.WriteResult(stockDelta);
        }
    }
}
