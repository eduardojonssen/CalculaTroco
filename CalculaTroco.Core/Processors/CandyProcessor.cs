using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {
    internal class CandyProcessor : AbstractProcessor {
        private string name = "Balas";
        private long[] candies = {3, 1};

        internal override long[] AvailableValues() {
            return this.candies;
        }

        internal override string GetName() {
            return this.name;
        }
    }
}
