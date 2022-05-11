using Labwork_1_2;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Labwork_1._2.Handlers
{
    struct ProductHandler
    {
        public static void PrintInfoProductsLastTenDaysCreated(string filePath)
        {
            StringBuilder productsList = new StringBuilder();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();

            using (FileStream sourceStream = new FileStream(filePath + "source.bat", FileMode.Open, FileAccess.Read))
            {
                while (sourceStream.Position != sourceStream.Length)
                {
                    Product product = (Product)formatter.Deserialize(sourceStream);
                    
                    if (DateHandler.CountDaysBySubtractingDates(product.ExistingTerm.CurrentDate, product.
                        ExistingTerm.CreationDate) <= 10)
                    {
                        productsList.Append(product.ToString());
                    }
                }
            }

            MessageBox.Show("The list of products last 10 days created:\n\n" + productsList.ToString());
        }

        public static double GetRelationOfTimeLeft(Product product)
        {
            int totalDaysOfExisting = DateHandler.CountDaysBySubtractingDates(product.ExistingTerm.ExpirationDate,
                product.ExistingTerm.CreationDate);
            int spentDays = DateHandler.CountDaysBySubtractingDates(product.ExistingTerm.ExpirationDate,
                product.ExistingTerm.CurrentDate);

            return (double)(spentDays) / totalDaysOfExisting;
        }
    }
}
