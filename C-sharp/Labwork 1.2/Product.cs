using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labwork_1_2
{
    [Serializable]
    struct Product
    {
        public string Name { get; set; }

        public Date ExistingTerm;

        public decimal Price { get; set; }

        public double TimeLeftRelation { get; set; }

        public Product(string Name, string CreationDate, string ExpirationDate, decimal Price)
        {
            if (Name is null)
            {
                throw new ArgumentException("The name wasn't entered");
            }

            ExistingTerm = new Date
            {
                CreationDate = CreationDate,
                ExpirationDate = ExpirationDate
            };
            this.Name = Name;
            this.Price = Price;
            TimeLeftRelation = default;
        }

        public void CountRelationOfTimeLeft()
        {
            int totalDaysOfExisting = ExistingTerm.CountDaysBySubstractingDates(ExistingTerm.ExpirationDate, ExistingTerm.CreationDate);
            int spentDays = ExistingTerm.CountDaysBySubstractingDates(ExistingTerm.ExpirationDate, Date.CurrentDate);

            TimeLeftRelation = (double)(spentDays) / totalDaysOfExisting;
        }

        public override string ToString()
        {
            return $"The product has the properties:\n" +
                $"name - {Name}, creation date - {ExistingTerm.CreationDate}, expiration date - {ExistingTerm.ExpirationDate}, price - {Price}$\n";
        }
    }
}
