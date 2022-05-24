namespace Labwork_6
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public ProductModel Data { get; set; }

        public Node(ProductModel product)
        {
            Data = product;
        }

        public Node()
        {
            
        }
    }
}