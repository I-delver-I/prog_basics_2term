namespace Labwork_6
{
    public class BinaryTree
    {
        public Node Root { get; set; }
 
        public void Add(ProductModel product)
        {
            Node previous = new();
            Node next = Root;
    
            while (next != null)
            {
                previous = next;

                if (product.Price < next.Data.Price)
                {
                    next = next.LeftNode; 
                }
                else if (product.Price >= next.Data.Price)
                {
                    next = next.RightNode;
                }
            }
    
            Node newNode = new(product);
    
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                if (product.Price < previous.Data.Price)
                {
                    previous.LeftNode = newNode;
                }
                else
                {
                    previous.RightNode = newNode;
                }
            }
        }
 
        public Node Find(decimal price)
        {
            return Find(price, Root);            
        }
    
        public void Remove(int price)
        {
            Root = Remove(Root, price);
        }
    
        private Node Remove(Node root, decimal price)
        {
            if (root == null)
            {
                return root;
            }
    
            if (price < root.Data.Price)
            {
                root.LeftNode = Remove(root.LeftNode, price);
            }
            else if (price > root.Data.Price)
            {
                root.RightNode = Remove(root.RightNode, price);
            }
    
            else
            {
                if (root.LeftNode == null)
                {
                    return root.RightNode;
                }
                else if (root.RightNode == null)
                {
                    return root.LeftNode;
                }
    
                root.Data.Price = GetMinValue(root.RightNode);
                root.RightNode = Remove(root.RightNode, root.Data.Price);
            }
    
            return root;
        }
    
        private decimal GetMinValue(Node node)
        {
            decimal minPrice = node.Data.Price;
    
            while (node.LeftNode != null)
            {
                minPrice = node.LeftNode.Data.Price;
                node = node.LeftNode;
            }
    
            return minPrice;
        }
    
        private Node Find(decimal price, Node root)
        {
            if (root != null)
            {
                if (price == root.Data.Price)
                {
                    return root;
                }
                else if (price < root.Data.Price)
                {
                    return Find(price, root.LeftNode);
                }
                else
                {
                    return Find(price, root.RightNode);
                }
            }
    
            return null;
        }
    
        public int GetTreeDepth()
        {
            return GetTreeDepth(Root);
        }
    
        private int GetTreeDepth(Node root)
        {
            return (root == null) ? 0 : Math.Max(GetTreeDepth(root.LeftNode), GetTreeDepth(root.RightNode)) + 1;
        }

        public decimal GetTotalPrice(Node root)
        {
            decimal totalPrice = root.Data.GetTotalPrice();

            if (root.LeftNode != null)
            {
                totalPrice += GetTotalPrice(root.LeftNode);
            }

            if (root.RightNode != null)
            {
                totalPrice += GetTotalPrice(root.RightNode);
            }

            return totalPrice;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.WriteLine(parent.Data);
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }
    
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.WriteLine(parent.Data);
                TraverseInOrder(parent.RightNode);
            }
        }
    
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.WriteLine(parent.Data);
            }
        }
    }
}