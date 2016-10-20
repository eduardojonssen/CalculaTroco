using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public abstract class AbstractResponse {

        public AbstractResponse() {

            this.OperationReport = new List<Report>();
        }

        /// <summary>
        /// Obtém ou define o relatório sobre o processamento da requisição.
        /// </summary>
        public List<Report> OperationReport { get; set; }

        /// <summary>
        /// Obtém ou define a flag que indica se o processamento foi concluído com sucesso.
        /// </summary>
        public bool Success { get; set; }
    }
}
