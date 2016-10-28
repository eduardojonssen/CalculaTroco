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

        internal override string GetName() {
            return this.name;
        }
    }
}

