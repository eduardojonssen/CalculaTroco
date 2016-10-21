using CalculaTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core {
    public class CalculaTrocoManager {

        public CalculaTrocoManager() { }

        public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {

            CalculateChangeResponse response = new CalculateChangeResponse();

            try {
                //TODO: Salvar log de request
                // Verifica se os dados recebidos são válidos.
                if (request.IsValid == false) {
                    response.OperationReport = request.ValidationReport;
                    return response;
                }

                long changeAmount = request.PaidAmount - request.ProductAmount;

                response.ChangeAmount = changeAmount;
                response.ChangeCoins = CalculateOptimalChangeInCoins(changeAmount);

                response.Success = true;

            }
            catch (Exception ex) {
                //TODO: Salvar log de exceção
                Report report = new Report();
                report.Field = "Error";
                report.Message = "Ocorreu um erro durante o processamento da transação. Nenhuma operação foi realizada.";
                response.OperationReport.Add(report);
            } 
            //TODO: Salvar log de response

            return response;
        }

        public Dictionary<long, long> CalculateOptimalChangeInCoins(long changeAmount) {
            long[] coins = { 100, 50, 25, 10, 5, 1 };

            Dictionary<long, long> change = new Dictionary<long, long>();

            foreach(long coin in coins) {
                long coinQuantity = changeAmount / coin;                
                if(coinQuantity > 0) {
                    change.Add(coin,coinQuantity);
                    changeAmount = changeAmount % coin;
                }                
            }

            return change;
        }
    }
}
