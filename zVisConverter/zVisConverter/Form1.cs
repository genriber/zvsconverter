using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zVisConverter
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }
        double enterval;
        double endval1;
        double endval2;
        double komiss =0;
        double USD = 64.19;
        double EUR = 71.10;
        double JPY = 42.07;
        double GBP = 83.69;
        double CHF = 65.09;
        double CAD = 48.32;
        double AUD = 43.76;
        double NZD = 41.65;
        double RUB =1;
        double perper = 1;

        private void Converter_Load(object sender, EventArgs e)
        {
            string[] curr = { "USD", "EUR", "JPY", "GBP", "CHF", "CAD", "AUD", "NZD", "RUB" };
            comboBox1.Items.AddRange(curr);
            comboBox1.SelectedIndex = 8;
            comboBox2.Items.AddRange(curr); 
            comboBox2.SelectedIndex = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: endval1 = USD; break;
                case 1: endval1 = EUR; break;
                case 2: endval1 = JPY; break;
                case 3: endval1 = GBP; break;
                case 4: endval1 = CHF; break;
                case 5: endval1 = CAD; break;
                case 6: endval1 = AUD; break;
                case 7: endval1 = NZD; break;
                case 8: endval1 = RUB; break;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0: endval2 = USD; break;
                case 1: endval2 = EUR; break;
                case 2: endval2 = JPY; break;
                case 3: endval2 = GBP; break;
                case 4: endval2 = CHF; break;
                case 5: endval2 = CAD; break;
                case 6: endval2 = AUD; break;
                case 7: endval2 = NZD; break;
                case 8: endval2 = RUB; break;
            }

            try {

                if (textBox3.Text == "") { komiss = 0; } else { komiss = double.Parse(textBox3.Text); };
                if (textBox1.Text == "") { enterval = 0; } else { enterval = double.Parse(textBox1.Text); };
                //label4.Text = Convert.ToString(((enterval*endval1) - (enterval* endval1 * (komiss / 100)))/endval2);
                perper = (((enterval * endval1) - (enterval * endval1 * (komiss / 100))) / endval2);
                label4.Text = (Convert.ToString(Math.Round(perper, 2)));

            }
            catch (System.FormatException)
            { MessageBox.Show("Введен недопустимый символ"); };
            textBox1.Clear();
            textBox3.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void zagruzka_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    var fileStream = openFileDialog1.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string[] readText = File.ReadAllLines(filePath);
                        for (int i=0; i<readText.Count();i+=9) {
                            try
                            {
                                USD = double.Parse(readText[i]);
                                EUR = double.Parse(readText[i + 1]);
                                JPY = double.Parse(readText[i + 2]);
                                GBP = double.Parse(readText[i + 3]);
                                CHF = double.Parse(readText[i + 4]);
                                CAD = double.Parse(readText[i + 5]);
                                AUD = double.Parse(readText[i + 6]);
                                NZD = double.Parse(readText[i + 7]);
                            }
                            catch (System.IndexOutOfRangeException) { MessageBox.Show("Неверное количество записей в файле. Данные по курсам загружены некорректно."); break; }
                            catch (System.FormatException) { MessageBox.Show("Файл поврежден или записи не соответсвуют форматам. Данные по курсам загружены некорректно."); break; }
                        }
                    }
                }
            }
        }

        private void grafik_Click(object sender, EventArgs e)
        {
            izmkurs form2 = new izmkurs();
            form2.Show();
        }
    }
}
