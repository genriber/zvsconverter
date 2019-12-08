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
    public partial class izmkurs : Form
    {
        public izmkurs()
        {
            InitializeComponent();
        }
        double USD = 64.19;
        double EUR = 71.10;
        double JPY = 42.07;
        double GBP = 83.69;
        double CHF = 65.09;
        double CAD = 48.32;
        double AUD = 43.76;
        double NZD = 41.65;
        double RUB = 1;
        DateTime DT;

        private void zagruzka_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    var fileStream = openFileDialog1.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string[] readText = File.ReadAllLines(filePath);
                        for (int i = 0; i < readText.Count(); i += 9)
                        {
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
                                DT = DateTime.Parse(readText[i + 8]);
                                graf1.Series["USD"].Points.AddXY(DT, Math.Round(USD,2));
                                graf2.Series["EUR"].Points.AddXY(DT, Math.Round(EUR, 2));
                                graf3.Series["JPY"].Points.AddXY(DT, Math.Round(JPY, 2));
                                graf4.Series["GBP"].Points.AddXY(DT, Math.Round(GBP, 2));
                                graf5.Series["CHF"].Points.AddXY(DT, Math.Round(CHF, 2));
                                graf6.Series["CAD"].Points.AddXY(DT, Math.Round(CAD, 2));
                                graf7.Series["AUD"].Points.AddXY(DT, Math.Round(AUD, 2));
                                graf8.Series["NZD"].Points.AddXY(DT, Math.Round(NZD, 2));

                            }
                            catch (System.IndexOutOfRangeException) { MessageBox.Show("Неверное количество записей в файле. Данные по курсам загружены некорректно."); break; }
                            catch (System.FormatException) { MessageBox.Show("Файл поврежден или записи не соответсвуют форматам. Данные по курсам загружены некорректно."); break; }
                        }
                    }
                }
            }
        }
    }
}
