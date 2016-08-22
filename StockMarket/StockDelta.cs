using System.Collections.Generic;

namespace StockMarket
{
    public class StockDelta
    {
        public StockNode start;
        public StockNode end;

        public StockDelta(List<int> list)
        {
            int count = list.Count;
            start = new StockNode { position = 0, value = list[0] };
            end = new StockNode { position = count, value = list[count-1] };
        }

        public StockDelta(int pos, int val)
        {
            start = new StockNode { position = pos, value = val };
            end = new StockNode { position = pos, value = val };
        }

        public int profit()
        {
            return end.value - start.value;
        }

        public new string ToString()
        {
            return string.Format("Start Index: {0} \nEnd Index: {1} \nBuy: {2} Sell: {3} \nProfit: {4}",  
                                    start.position, end.position, start.value, end.value, profit()) ;
        }
    }

    public class StockNode
    {
        public int position;
        public int value;
    }
}
