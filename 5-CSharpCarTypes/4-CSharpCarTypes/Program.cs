using System;

namespace _5_CSharpCarTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            MercedesA180 mercedesA180 = new MercedesA180() { Color = "White", ModelYear = 2020, Price = 750000 };
            AudiA7 audiA7 = new AudiA7() { Color = "Black", ModelYear = 2020, Price = 1000000 };
            BMW520d bmw520d = new BMW520d() { Color = "Blue", ModelYear = 2021, Price = 1200000 };

            Console.WriteLine(mercedesA180.Model + " " + mercedesA180.Brand + " " + mercedesA180.ModelYear);
            Console.WriteLine(mercedesA180.CarType);
            Console.WriteLine(mercedesA180.Color);
            Console.WriteLine(mercedesA180.Price);

            Console.WriteLine("-----");

            Console.WriteLine(audiA7.Model + " " + audiA7.Brand + " " + audiA7.ModelYear);
            Console.WriteLine(audiA7.CarType);
            Console.WriteLine(audiA7.Color);
            Console.WriteLine(audiA7.Price);

            Console.WriteLine("-----");

            Console.WriteLine(bmw520d.Model + " " + bmw520d.Brand + " " + bmw520d.ModelYear);
            Console.WriteLine(bmw520d.CarType);
            Console.WriteLine(bmw520d.Color);
            Console.WriteLine(bmw520d.Price);

            Console.ReadLine();
        }
    }
}
