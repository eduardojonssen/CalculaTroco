using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {
    internal class SilverBarProcessor : AbstractProcessor {

        private string name = "Barras de Prata";
        private long[] silverBars = { 100000, 50000 };

        internal override long[] AvailableValues() {
            return this.silverBars;
        }

        internal override Dictionary<long, long> Calculate(long changeAmount) {
            Dictionary<long, long> change = new Dictionary<long, long>();

            foreach (long bar in this.silverBars) {
                long silverBarsQuantity = changeAmount / bar;
                if (silverBarsQuantity > 0) {
                    change.Add(bar, silverBarsQuantity);
                    changeAmount = changeAmount % bar;
                }
            }
            return change;
        }

        internal override string GetName() {
            return this.name;
        }
    }
}
