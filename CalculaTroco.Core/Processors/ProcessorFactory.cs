using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.Processors {

    internal static class ProcessorFactory {

        internal static AbstractProcessor Create(long changeAmount) {

            AbstractProcessor[] availableProcessors = new AbstractProcessor[] {
                new BillProcessor(),
                new CoinProcessor()

                // Adicione novos processadores acima desta linha.
            };

            foreach(AbstractProcessor processor in availableProcessors.OrderByDescending(p => p.AvailableValues().Min())) {
                if (changeAmount >= processor.AvailableValues().Min()) {
                    return processor;
                }
            }

            return null;
        }
    }
}
