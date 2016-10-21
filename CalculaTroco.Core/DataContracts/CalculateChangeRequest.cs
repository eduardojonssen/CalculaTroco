using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public class CalculateChangeRequest : AbstractRequest {

        public long PaidAmount { get; set; }
        public long ProductAmount { get; set; }

        public CalculateChangeRequest() { }

        protected override void Validate() {

            // Verifica se o valor pago é menor ou igual a zero.
            if (this.PaidAmount <= 0) {
                this.AddError("PaidAmount", "PaidAmount can't be lower than or equal to zero");
            }

            // Verifica se o valor pago é suficiente para cobrir o produto.
            if (this.PaidAmount < this.ProductAmount) {
                this.AddError("PaidAmount", "PaidAmount can't be lower than productAmount");
            }

            // Verifica se o valor do produto foi especificado.
            if (this.ProductAmount <= 0) {
                this.AddError("ProductAmount", "ProductAmount can't be lower than or equal to zero");
            }
        }
    }
}
