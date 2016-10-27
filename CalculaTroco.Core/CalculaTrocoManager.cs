using CalculaTroco.Core.DataContracts;
using CalculaTroco.Core.Processors;
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
            BillProcessor bill = new BillProcessor();
            CoinProcessor coin = new CoinProcessor();

            try {
                //TODO: Salvar log de request
                // Verifica se os dados recebidos são válidos.
                if (request.IsValid == false) {
                    response.OperationReport = request.ValidationReport;
                    return response;
                }

                long changeAmount = request.PaidAmount - request.ProductAmount;

                response.ChangeAmount = changeAmount;
                
                List<ChangeData> changeDataCollection = new List<ChangeData>();

                while (changeAmount > 0) {

                    // Obtém o processador adequado para calcular o troco especificado.
                    AbstractProcessor processor = ProcessorFactory.Create(changeAmount);

                    Dictionary<long,long> changeDictionary = processor.Calculate(changeAmount);

                    ChangeData changeData = new ChangeData(processor.GetName());
                    changeData.ChangeDictionary = changeDictionary;

                    changeDataCollection.Add(changeData);                 

                    changeAmount -= changeDictionary.Sum(p => p.Key * p.Value);
                }
                                              
                response.ChangeDataCollection = changeDataCollection;
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
