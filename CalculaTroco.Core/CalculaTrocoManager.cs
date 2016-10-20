using CalculaTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core {
    public class CalculaTrocoManager {

        public CalculaTrocoManager() { }

        public CalculateChangeResponse CalculateChange(long paidAmount, long productAmount) {

            CalculateChangeResponse response = new CalculateChangeResponse();

            if (paidAmount <= 0) {
                Report report = new Report("paidAmount", "paidAmount can't be lower than or equal to zero");
                response.OperationReport.Add(report);
            }

            if (paidAmount < productAmount) {
                Report report = new Report("paidAmount", "paidAmount can't be lower than productAmount");
                response.OperationReport.Add(report);
            }

            if (productAmount <= 0) { 
                Report report = new Report("productAmount", "productAmount can't be lower than or equal to zero");
                response.OperationReport.Add(report);
            }

            // Sai do método caso algum erro tenha ocorrido
            if (response.OperationReport.Count > 0) {
                return response;
            }

            long changeAmount = paidAmount - productAmount;

            response.ChangeAmount = changeAmount;

            response.Success = true;
            return response;
        }

        
    }
}
