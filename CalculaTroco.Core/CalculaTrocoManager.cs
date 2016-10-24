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
            Bill bill = new Bill();
            Coin coin = new Coin();

            try {
                //TODO: Salvar log de request
                // Verifica se os dados recebidos são válidos.
                if (request.IsValid == false) {
                    response.OperationReport = request.ValidationReport;
                    return response;
                }

                long changeAmount = request.PaidAmount - request.ProductAmount;

                response.ChangeAmount = changeAmount;
                
                Dictionary<long, long> resultBill = bill.CalculateOptimalChangeInBills(changeAmount);
                Dictionary<long, long> result = new Dictionary<long, long>();
               
                foreach (KeyValuePair<long,long> r in resultBill  ) {
                    result.Add(r.Key, r.Value);
                }
                long resultAmount = resultBill.Sum(p => p.Key * p.Value);
                changeAmount -= resultAmount;
                Dictionary<long,long> resultCoin = coin.CalculateOptimalChangeInCoins(changeAmount);
                foreach (KeyValuePair<long, long> r in resultCoin) {
                    result.Add(r.Key, r.Value);
                }

                response.ChangeResult = result;
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
    }
}
