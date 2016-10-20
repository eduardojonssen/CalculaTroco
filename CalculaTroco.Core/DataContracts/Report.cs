using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public class Report {

        public Report() { }

        public Report(string field, string message) {

            this.Field = field;
            this.Message = message;
        }

        /// <summary>
        /// Obtém ou define o nome do campo que gerou o report.
        /// </summary>
        public String Field { get; set; }

        /// <summary>
        /// Obtém ou define o repor para o campo especificado.
        /// </summary>
        public String Message { get; set; }

    }
}
