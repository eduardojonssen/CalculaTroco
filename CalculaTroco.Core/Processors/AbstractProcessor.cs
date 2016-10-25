using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {

    internal abstract class AbstractProcessor {

        internal AbstractProcessor() { }

        internal abstract Dictionary<long, long> Calculate(long changeAmount );

        internal abstract string GetName();

        internal abstract long[] AvailableValues();
    }
    
}
