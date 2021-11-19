using System;
using System.Collections.Generic;
using System.Text;

namespace _5_CSharpCarTypes
{
    public interface ICar
    {
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
    }

    public class Mercedes : ICar
    {
        public string Brand = "Mercedes";
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
    }

    public class Audi : ICar
    {
        public string Brand = "Mercedes";
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
    }

    public class BMW : ICar
    {
        public string Brand = "Mercedes";
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
    }

    public class MercedesA180 : Mercedes
    {
        public string Model = "A180";
        public string CarType = "Hatchback";
    }

    public class AudiA7 : Audi
    {
        public string Model = "A7";
        public string CarType = "Coupe";
    }

    public class BMW520d : BMW
    {
        public string Model = "520d";
        public string CarType = "Sedan";
    }
}
