using CalculaTroco.Core;
using CalculaTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculaTroco.UI {
    public partial class CalculaTroco : Form {
        public CalculaTroco() {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            CalculaTrocoAbout about = new CalculaTrocoAbout();
            about.ShowDialog();
        }

        private void UxBtnCalculateChange_Click(object sender, EventArgs e) {
            long paidAmount = long.Parse(this.UxTxtPaidAmount.Text);
            long productAmount = long.Parse(this.UxTxtProductAmount.Text);
            CalculaTrocoManager calculaTrocoManager = new CalculaTrocoManager();
            CalculateChangeRequest calculateChangeRequest = new CalculateChangeRequest();
            calculateChangeRequest.PaidAmount = paidAmount;
            calculateChangeRequest.ProductAmount = productAmount;

            CalculateChangeResponse calculateChangeResponse = calculaTrocoManager.CalculateChange(calculateChangeRequest);

            if (calculateChangeResponse.Success) {
                this.UxTxtChangeAmount.Text = calculateChangeResponse.ChangeAmount.ToString();

                string coins = "";
                foreach(KeyValuePair<long, long> coin in calculateChangeResponse.ChangeResult) {
                    coins += coin.Value + " moedas de " + coin.Key + " centavos \r\n";
                }
                this.UxTxtCoins.Text = coins;
            } else {
                String errorMessages = "";
                foreach (Report report in calculateChangeResponse.OperationReport) {
                    errorMessages += report.Field + ": " + report.Message + "\r\n";
                }
                MessageBox.Show(errorMessages, "CalculaTroco - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
