using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {

    public abstract class AbstractRequest {

        public AbstractRequest() {
            this.ValidationReport = new List<Report>();
        }

        public bool valid;

        /// <summary>
        /// Obtém a flag que indica se os dados recebidos são válidos.
        /// </summary>
        public bool IsValid {
            get {
                this.ValidationReport.Clear();
                this.Validate();
                return (this.ValidationReport.Count == 0);
            }
        }

        /// <summary>
        /// Obtém a lista com os erros de validação.
        /// </summary>
        public List<Report> ValidationReport { get; set; }

        protected void AddError(string fieldName, string message) {

            Report report = new Report();

            report.Field = this.GetType().Name + "." + fieldName;
            report.Message = message;

            this.ValidationReport.Add(report);
        }

        protected abstract void Validate();
    }
}
