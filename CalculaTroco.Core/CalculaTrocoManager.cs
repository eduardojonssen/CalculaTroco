using CalculaTroco.Core.DataContracts;
using CalculaTroco.Core.Processors;
using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
            // File e Directory
            Directory.CreateDirectory("C:\\Log");

            try {
                //TODO: Salvar log de request
                using (StreamWriter logFile = File.AppendText("C:\\Log\\CalculaTroco.log")) {
                    string date = DateTime.UtcNow.ToString();
                    string type = "Request";
                    string method = "CalculateChange";
                    string data = Serializer.NewtonsoftSerialize(request);
                    logFile.Write(date + " | " + type + " | " + method + " | " + data + Environment.NewLine);
                    logFile.Flush();
                }

                // Verifica se os dados recebidos são válidos.
                if (request.IsValid == false) {
                    response.OperationReport = request.ValidationReport;
                    return response;
                }

                throw new OutOfMemoryException("Deu ruim.");

                long changeAmount = request.PaidAmount - request.ProductAmount;
                long totalChangeAmount = changeAmount;

                List<ChangeData> changeDataCollection = new List<ChangeData>();

                while (changeAmount > 0) {

                    // Obtém o processador adequado para calcular o troco especificado.
                    AbstractProcessor processor = ProcessorFactory.Create(changeAmount);

                    // Caso não exista processador adequado, aborta a operação.
                    if (processor == null) {
                        Report report = new Report("", "Não foi possível realizar a transação por falta de troco. Lamentamos o inconveniente.");
                        response.OperationReport.Add(report);
                        return response;
                    }

                    Dictionary<long, long> changeDictionary = processor.Calculate(changeAmount);

                    ChangeData changeData = new ChangeData(processor.GetName());
                    changeData.ChangeDictionary = changeDictionary;

                    changeDataCollection.Add(changeData);

                    changeAmount -= changeDictionary.Sum(p => p.Key * p.Value);
                }

                response.ChangeAmount = totalChangeAmount;
                response.ChangeDataCollection = changeDataCollection;
                response.Success = true;

            }
            catch (Exception ex) {
                //TODO: Salvar log de exceção
                Report report = new Report();
                report.Field = "Error";
                report.Message = "Ocorreu um erro durante o processamento da transação. Nenhuma operação foi realizada.";
                response.OperationReport.Add(report);

                using (StreamWriter logFile = File.AppendText("C:\\Log\\CalculaTroco.log")) {
                    string date = DateTime.UtcNow.ToString();
                    string type = "Exception";
                    string method = "CalculateChange";
                    string data = Serializer.NewtonsoftSerialize(ex);
                    logFile.Write(date + " | " + type + " | " + method + " | " + data + Environment.NewLine);
                    logFile.Flush();
                }
            }
            finally {
                //TODO: Salvar log de response

                using (StreamWriter logFile = File.AppendText("C:\\Log\\CalculaTroco.log")) {
                    string date = DateTime.UtcNow.ToString();
                    string type = "Response";
                    string method = "CalculateChange";
                    string data = Serializer.NewtonsoftSerialize(response);
                    logFile.Write(date + " | " + type + " | " + method + " | " + data + Environment.NewLine);
                    logFile.Flush();
                }
            }

            return response;
        }
    }
}
