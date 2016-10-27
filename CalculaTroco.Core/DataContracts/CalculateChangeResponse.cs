using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public sealed class CalculateChangeResponse : AbstractResponse {

        public CalculateChangeResponse() {

            this.ChangeDataCollection = new List<ChangeData>();
        }

        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public Nullable<long> ChangeAmount { get; set; }

        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public List<ChangeData> ChangeDataCollection { get; set; }
    }
}
