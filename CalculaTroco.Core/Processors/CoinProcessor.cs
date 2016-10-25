using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {
    internal class CoinProcessor : AbstractProcessor {
        private long[] coins = { 100, 50, 25, 10, 5, 1 };
        private string name = "Moedas";

        internal override long[] AvailableValues() {
            return this.coins;
        }

        internal override Dictionary<long, long> Calculate(long changeAmount) {

            Dictionary<long, long> change = new Dictionary<long, long>();

            foreach (long coin in coins) {
                long coinQuantity = changeAmount / coin;
                if (coinQuantity > 0) {
                    change.Add(coin, coinQuantity);
                    changeAmount = changeAmount % coin;
                }
            }
            return change;
        }

        internal override string GetName() {
            return this.name;
        }
    }
}
