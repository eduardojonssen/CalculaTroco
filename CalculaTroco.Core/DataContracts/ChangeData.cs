using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Core.DataContracts {
    public class ChangeData {

        public ChangeData(String changeType) {
            this.ChangeType = changeType;
            this.ChangeDictionary = new Dictionary<long, long>();
        }

        /// <summary>
        /// Tipo do troco
        /// </summary>
        public String ChangeType { get; set; }

        /// <summary>
        /// Dicionário que define a quantidade de moedas e o seu respectivo valor
        /// </summary>
        public Dictionary<long, long> ChangeDictionary { get; set; }
    }
}
