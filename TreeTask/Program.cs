using System;
using ShapesTask;
using ShapesTask.Shapes;
using ShapesTask.Comparers;

namespace TreeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<IShape> shapesTree = new BinarySearchTree<IShape>(new Circle(4.5), new AreaComparer());

            shapesTree.Add(new Square(6));
            shapesTree.Add(new Rectangle(3, 5));
            shapesTree.Add(new Square(9));
            shapesTree.Add(new Circle(4));
            shapesTree.Add(new Rectangle(13, 8));
            shapesTree.Add(new Circle(5.5));
            shapesTree.Add(new Rectangle(20, 1));
            shapesTree.Add(new Square(7));
            shapesTree.Add(new Rectangle(6, 5));
            shapesTree.Add(new Square(8));

            Console.WriteLine($"Binary search tree of {shapesTree.Count} shapes built by area value");
            Console.WriteLine();

            Console.WriteLine("Bypass in breadth:");
            
            shapesTree.BypassInBreadth();
            Console.WriteLine();

            Console.WriteLine("Bypass in depth with cycle:");

            shapesTree.BypassInDepthWithCycle();
            Console.WriteLine();

            Console.WriteLine("Bypass in depth with recursion:");

            shapesTree.BypassInDepthWithRecursion();
            Console.WriteLine();

            IShape shape = new Circle(4.5);

            Console.WriteLine($"Tree contains shape {shape}: {shapesTree.Contains(shape)}");
            Console.WriteLine("Remove shape: " + shape);
            Console.WriteLine("Shape removed: " + shapesTree.Remove(shape));
            Console.WriteLine("Count of shapes remaining: " + shapesTree.Count);
        }
    }
}
