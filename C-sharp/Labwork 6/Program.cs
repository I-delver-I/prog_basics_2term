
namespace Labwork_6
{
    class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            CaptureProducts(binaryTree);
            System.Console.WriteLine($"The depth of tree: {binaryTree.GetTreeDepth()}");
            
            Console.WriteLine("PreOrder traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            PrintHorizontalRule();
            
            Console.WriteLine("InOrder traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            PrintHorizontalRule();
            
            Console.WriteLine("PostOrder traversal:");
            binaryTree.TraversePostOrder(binaryTree.Root);
            PrintHorizontalRule();
            
            System.Console.Write("Total price: ");
            System.Console.WriteLine(binaryTree.GetTotalPrice(binaryTree.Root));
        }

        static void PrintHorizontalRule()
        {
            System.Console.WriteLine(new string('-', 80));
        }

        public static void CaptureProducts(BinaryTree binaryTree)
        {
            bool exceptionIsCaught = true;

            do
            {
                ProductModel product = new();
                exceptionIsCaught = false;

                try
                {
                    System.Console.Write("Please, enter the product name: ");
                    product.Name = Console.ReadLine();

                    System.Console.Write("Please, enter the product price: ");
                    product.Price = int.Parse(Console.ReadLine());

                    System.Console.Write("Please, eter the product count: ");
                    product.Count = int.Parse(Console.ReadLine());

                    binaryTree.Add(product);
                    PrintHorizontalRule();
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsCaught = true;
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsCaught = true;
                }

                if (!exceptionIsCaught)
                {
                    System.Console.WriteLine("Press <Backspace> if you want to end typing or any key to continue");
                }
            } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Backspace);
        }
    }
}
