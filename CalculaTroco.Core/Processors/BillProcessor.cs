using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {

    internal class BillProcessor : AbstractProcessor {

        private string name = "Cedulas";
        private long[] bills = { 10000, 5000, 2000, 1000, 500, 200 };

        internal override long[] AvailableValues() {
            return this.bills;
        }

        internal override Dictionary<long, long> Calculate(long changeAmount) {
            Dictionary<long, long> change = new Dictionary<long, long>();

            foreach (long bill in bills) {
                long billQuantity = changeAmount / bill;
                if (billQuantity > 0) {
                    change.Add(bill, billQuantity);
                    changeAmount = changeAmount % bill;
                }
            }
            return change;
        }


        internal override string GetName() {
            return this.name;
        }
    }
}

