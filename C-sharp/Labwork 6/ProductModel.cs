namespace Labwork_6
{
    public class ProductModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("The name of product mustn't be empty");
                }

                _name = value;
            }
        }
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The count mustn't be less than 0");
                }

                _count = value;
            }
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The price mustn't be less than 0");
                }

                _price = value;
            }
        }

        public ProductModel(string name, decimal price, int count = 0)
        {
            Name = name;
            Count = count;
            Price = price;
        }

        public ProductModel()
        {
            
        }

        public override string ToString()
        {
            return $"Name - {Name}, Price - {Price}, Count - {Count}";
        }

        public decimal GetTotalPrice()
        {
            return Price * Count;
        }
    }
}