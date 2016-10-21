using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public sealed class CalculateChangeResponse : AbstractResponse {

        public CalculateChangeResponse() {

            this.ChangeCoins = new Dictionary<long, long>();
        }

        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public Nullable<long> ChangeAmount { get; set; }

        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public Dictionary<long, long> ChangeCoins { get; set; }
    }
}
