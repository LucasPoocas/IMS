using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{

    public abstract class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        //public string[] Row { get; set; }

        public Part(int partID, string name, decimal price, int inStock, int min, int max)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            /*
            Row = new string[6] {
                $"{PartID}",
                $"{Name}",
                $"{Price}",
                $"{InStock}",
                $"{Min}",
                $"{Max}"
            };
            */
        }
        public override string ToString() =>
            $"ID - {PartID}\nName - {Name}\nPrice - {Price}\nInventory - {InStock}\n" +
            $"Min - {Min}\nMax - {Max}\n";

    }
}
