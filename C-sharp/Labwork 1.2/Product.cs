using System;

namespace Labwork_1_2
{
    [Serializable]
    struct Product
    {
        public string Name { get; set; }
        public Date ExistingTerm { get; set; }

        public decimal Price { get; set; }

        public double TimeLeftRelation { get; set; }

        public Product(string Name, string CreationDate, string ExpirationDate, decimal Price, string CurrentDate)
        {
            ExistingTerm = new Date
            {
                CreationDate = CreationDate,
                ExpirationDate = ExpirationDate,
                CurrentDate = CurrentDate
            };

            this.Name = Name;
            this.Price = Price;
            TimeLeftRelation = default;
        }

        public override string ToString() => $"[Name - {Name}, Creation date - {ExistingTerm.CreationDate}," +
                $" Expiration date - {ExistingTerm.ExpirationDate}, Current Date - { ExistingTerm.CurrentDate }, Price - {Price}$]\n\n";
    }
}
