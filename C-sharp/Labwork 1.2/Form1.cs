using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Labwork_1._2.Handlers;
using Labwork_1._2;

namespace Labwork_1_2
{
    public partial class Form1 : Form
    {
        private string _basePath = @"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\C-sharp\Labwork 1.2\files\";
        readonly BinaryFormatter formatter = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            formatter.Binder = new CustomBinder();
        }

        /// <summary>
        /// Creation of an empty binary file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream streamSource = File.Create(_basePath + @"source.bat");
            streamSource.Close();
            File.Delete(_basePath + @"destination.bat");
            richTextBox5.Text = "";
        }

        /// <summary>
        /// Adding of a product to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream sourceStream = new FileStream(_basePath + "source.bat", FileMode.Append))
            {
                try
                {
                    string errorMessage = GetErrorMessageOrNull();
                    if (errorMessage != null)
                    {
                        throw new ArgumentException(errorMessage);
                    }

                    Product product = new Product(richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, 
                        Convert.ToDecimal(richTextBox4.Text), richTextBox6.Text);

                    product.TimeLeftRelation = ProductHandler.GetRelationOfTimeLeft(product);

                    formatter.Serialize(sourceStream, product);
                    ClearTextBoxes();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Price column musn't be empty");
                }
            }
        }

        private string GetErrorMessageOrNull()
        {
            string result = null;

            if (richTextBox1.Text == "")
            {
                return "Name column musn't be empty";
            }

            if (richTextBox2.Text is null)
            {
                return "Creation date column musn't be empty";
            }

            if (richTextBox3.Text is null)
            {
                return "Expiration date column musn't be empty";
            }

            if (richTextBox6.Text is null)
            {
                return "Please, enter the current date!";
            }
            
            return result;
        }

        private void ClearTextBoxes()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
        }

        /// <summary>
        /// Transfering products to a new file where expiration date goes to the end (<= 10% time left)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            using (FileStream sourceStream = new FileStream(_basePath + "source.bat", FileMode.Open, FileAccess.Read))
            {
                StringBuilder outputBuilder = new StringBuilder();
                
                while (sourceStream.Position != sourceStream.Length)
                {
                    Product newProduct = (Product)formatter.Deserialize(sourceStream);

                    if (newProduct.TimeLeftRelation <= 0.1)
                    {
                        using (FileStream destinationStream = new FileStream(_basePath + "destination.bat", FileMode.Append))
                        {
                            formatter.Serialize(destinationStream, newProduct);
                        }
                        
                        outputBuilder.Append(newProduct.ToString());
                    }
                }

                richTextBox5.Text += outputBuilder.ToString();
            }
        }

        /// <summary>
        /// Printing info about products which were created for last 10 days
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ProductHandler.PrintInfoProductsLastTenDaysCreated(_basePath);
        }
    }
}