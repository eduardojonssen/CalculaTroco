using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {

    internal abstract class AbstractProcessor {

        internal AbstractProcessor() { }

        internal virtual Dictionary<long, long> Calculate(long changeAmount) {

            Dictionary<long, long> changeDictionary = new Dictionary<long, long>();

            foreach (long unit in this.AvailableValues()) {

                long unitQuantity = changeAmount / unit;

                if (unitQuantity > 0) {
                    changeDictionary.Add(unit, unitQuantity);
                    changeAmount = changeAmount % unit;
                }
            }

            return changeDictionary;
        }

        internal abstract string GetName();

        internal abstract long[] AvailableValues();
    }
    
}
