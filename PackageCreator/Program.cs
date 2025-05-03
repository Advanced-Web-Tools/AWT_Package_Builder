using System;

namespace PackageCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Package Creator!");
            PackageBuilder.BuildPackage();
        }
    }
}