using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public sealed class CalculateChangeResponse : AbstractResponse {

        public CalculateChangeResponse() { }

        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public long ChangeAmount { get; set; }
    }
}
