namespace PackageCreator;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Package Creator for Advanced Web Tools!");
            PackageBuilder.BuildPackage();


            Console.WriteLine("Do you want to create a new package? y/N");

            var input = Console.ReadLine();

            if (input.ToLower() == "n")
                break;
        }
    }
}