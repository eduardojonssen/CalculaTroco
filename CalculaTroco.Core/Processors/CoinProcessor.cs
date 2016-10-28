using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {
    internal class CoinProcessor : AbstractProcessor {
        private long[] coins = { 100, 50, 25, 10, 5 };
        private string name = "Moedas";

        internal override long[] AvailableValues() {
            return this.coins;
        }

        internal override string GetName() {
            return this.name;
        }
    }
}
