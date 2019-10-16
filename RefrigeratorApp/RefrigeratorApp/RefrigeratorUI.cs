using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefrigeratorApp
{
    public partial class RefrigeratorUI : Form
    {
        public RefrigeratorUI()
        {
            InitializeComponent();
        }
        Refrigerator aRefrigerator = new Refrigerator();
        private void saveButton_Click(object sender, EventArgs e)
        {
            aRefrigerator.MaximumWeight = Convert.ToDouble(maximumWeightTextBox.Text);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            try
            {
                int item = Convert.ToInt32(totalItemTextBox.Text);
                double weight = Convert.ToDouble(unitWeightTextBox.Text);
                double totalWeight = item * weight;
                if (totalWeight + aRefrigerator.TotalWeights.Sum() > aRefrigerator.MaximumWeight)
                {
                    MessageBox.Show("Your given amount can't be entered because it will be over flown");
                    return;
                }
                aRefrigerator.Items.Add(item);
                aRefrigerator.Weights.Add(weight);
                currentWeightTextBox.Text = (aRefrigerator.GetCurrentWeight(totalWeight)).ToString(CultureInfo.InvariantCulture);
                remainingWeightTextBox.Text = aRefrigerator.GetRemainingWeight().ToString(CultureInfo.CurrentCulture);
                string message = "\t\tItems \t\t\t Weights\t\t\t\tTotalWeight\n";
                int index=0;
                foreach (double data in aRefrigerator.Weights)
                {
                    message += "Number of item : \t" + aRefrigerator.Items[index]+ "\t Weights(per unit) :\t " + data + "\t\tTotalWeight :\t"+aRefrigerator.TotalWeights[index]+"\n";
                    index++;
                }

                message += "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \n";
                message += "Total :\t\t" + aRefrigerator.Items.Sum() + "\t\t\t" + aRefrigerator.Weights.Sum() + "\t\t\t\t" +
                           aRefrigerator.TotalWeights.Sum();
                weightShowRichTextBox.Text = message;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void maximumWeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '.' && maximumWeightTextBox.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!(Char.IsDigit(ch) || (ch == (char)Keys.Back)|| ch == '.'))
                e.Handled = true;
            
        }
        private void totalItemTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!(Char.IsDigit(ch) || (ch == (char)Keys.Back)))
                e.Handled = true;
        }

        private void unitWeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '.' && maximumWeightTextBox.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!(Char.IsDigit(ch) || (ch == (char)Keys.Back) || ch == '.'))
                e.Handled = true;
        }
    }
}
