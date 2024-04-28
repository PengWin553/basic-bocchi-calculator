using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_toPass
{
    public partial class Calculator : Form
    {
        public decimal EndResult = 0;
        public decimal MemoryStore = 0;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            btnMC.Click += new EventHandler(btnEquals);
            btnMR.Click += new EventHandler(btnEquals);
            btnMS.Click += new EventHandler(btnEquals);
            btnMPlus.Click += new EventHandler(btnEquals);

        }

        private void btnBackspace(object sender, EventArgs e)
        {
            try
            {
                if ((String.Compare(textBox1.Text, " ") < 0))
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1 + 1);
                }
                else
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }

                if (textBox1.Text == "-")
                {
                    textBox1.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
           
        }

        private void btnCE(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void btnC(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void btnMisc(object sender, EventArgs e)
        {
            try
            {
                Button ButtonThatWasPushed = (Button)sender;
                string ButtonText = ButtonThatWasPushed.Text;

                if (ButtonText == "MC")
                {
                    //MEMORY CLEAR
                    this.MemoryStore = 0;
                    return;
                }

                if (ButtonText == "MR")
                {
                    //MEMORY RECALL
                    textBox1.Text = this.MemoryStore.ToString();
                    return;
                }

                /* if (ButtonText == "MS")
                 {
                     //MEMORY SUBTRACT

                     this.MemoryStore -= Convert.ToDecimal(this.EndResult);
                     return;
                 }

                 */

                if (ButtonText == "M+")
                {
                    //MEMORY ADD

                    this.MemoryStore += Convert.ToDecimal(this.EndResult);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
           

        }

        private void btn(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "0")
                    textBox1.Clear();

                Button button = (Button)sender;
                textBox1.Text = textBox1.Text + button.Text;
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }

        }

        private void btnPlusMinus(object sender, EventArgs e)
        {
            try
            {
                //To find the Inverse
                if (textBox1.Text != string.Empty)
                {
                    double chk = Convert.ToDouble(this.textBox1.Text);
                    chk = -chk;
                    textBox1.Text = chk.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
           
        }

        private void btnSqrt(object sender, EventArgs e)
        {
            try
            {
                //To find the Square root
                if (textBox1.Text != string.Empty)
                {
                    double SqrRoot = Math.Sqrt(Convert.ToDouble(this.textBox1.Text));
                    textBox1.Text = SqrRoot.ToString();

                }
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
           
        }

        private void btnPercent(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(100));
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }

        }

        private void btnReciprocal(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {

                    double chk = Convert.ToDouble("1") / Convert.ToDouble(textBox1.Text);
                    textBox1.Text = chk.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
          
        }

        private void btnEquals(object sender, EventArgs e)
        {
            try
            {
                Button buttonThatWasPushed = (Button)sender;
                string buttonText = buttonThatWasPushed.Text;

                string equation = textBox1.Text;

                if (buttonText == "MS")
                {
                    MemoryStore = Decimal.Parse(textBox1.Text);

                    return;
                }

                if (buttonText == "MR")
                {
                    textBox1.Text = MemoryStore.ToString();
                }

                if (buttonText == "MC")
                {
                    MemoryStore = 0;
                }

                // PERHAPS HANDLE AN EXEPTION HERE

                //string equation = textBox1.Text;
                var result = new DataTable().Compute(equation, null);

                if (buttonText == "M+")
                {
                    //MEMORY ADD
                    textBox1.Text = result.ToString();
                    MemoryStore += Convert.ToDecimal(textBox1.Text);
                    return;
                }

                textBox1.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Syntax Error");
            }
           
        }
    }
}
