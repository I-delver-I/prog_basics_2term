using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleControl;
using ConsoleControlAPI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.SqlServer.Server;

namespace Labwork_1_2
{
    public partial class Form1 : Form
    {
        private string _path = @"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\C-sharp\Labwork 1.2\files\";

        private BinaryFormatter _formatter = new BinaryFormatter();

        private List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream streamSource = File.Create(_path + @"source.bat");
            streamSource.Close();
            File.Delete(_path + @"destination.bat");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream stream = new FileStream(_path + "source.bat", FileMode.Append))
            {
                try
                {
                    Product product = new Product(richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, Convert.ToDecimal(richTextBox4.Text));

                    if (richTextBox6.Text is null)
                    {
                        throw new ArgumentException("Please, enter the current date!");
                    }
                    Date.CurrentDate = richTextBox6.Text;
                    product.CountRelationOfTimeLeft();

                    _formatter.Serialize(stream, product);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //private byte[] ObjectToByteArray(object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bf.Serialize(ms, obj);
        //        return ms.ToArray();
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            using (FileStream mainStream = new FileStream(_path + "source.bat", FileMode.Open, FileAccess.Read))
            {
                while (mainStream.Position != mainStream.Length)
                {
                    Product newProduct = (Product)_formatter.Deserialize(mainStream);

                    if (newProduct.TimeLeftRelation <= 0.1)
                    {
                        using (FileStream write = new FileStream(_path + "destination.bat", FileMode.Append))
                        {
                            _formatter.Serialize(write, newProduct);
                            richTextBox5.Text += newProduct.ToString();
                        }
                    }
                }
            }
        }

        private void PrintInfoProductsLastTenDaysCreated()
        {
            StringBuilder productsList = new StringBuilder(); 

            using (FileStream sourceStream = new FileStream(_path + "source.bat", FileMode.Open, FileAccess.Read))
            {
                while (sourceStream.Position != sourceStream.Length)
                {
                    Product product = (Product)_formatter.Deserialize(sourceStream);

                    if (product.ExistingTerm.CountDaysBySubstractingDates(Date.CurrentDate, product.ExistingTerm.CreationDate) <= 10) 
                    {
                        productsList.Append(product.ToString());
                    }
                }
            }

            MessageBox.Show("This is the list of products:\n\n" + productsList.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintInfoProductsLastTenDaysCreated();
        }
    }
}