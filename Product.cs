using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class Product
    {
        public BindingList<Part> AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        //public string[] Row { get; set; }

        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        public bool removeAssociatedPart(int index)
        {
            if (AssociatedParts.Count > 0) { AssociatedParts.RemoveAt(index); }
            return false;
        }
        public Part lookupAssociatedPart(int index) { return AssociatedParts[index]; }

        public Product(BindingList<Part> associatedParts, int ID, string name, decimal price, int inStock, int min, int max)
        {
            AssociatedParts = associatedParts;
            ProductID = ID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            /*
            Row = new string[6] { $"{ProductID}", $"{Name}", $"{Price}",
            $"{InStock}", $"{Min}", $"{Max}"};
            */
        }

        /*Used for being passed into ToString() in order to programatically print
         * the list of AssociatedParts for testing*/
        public string PartPrint()
        {
            if (AssociatedParts.Count > 0)
            {
                string concatString = "";
                for (int i = 0; i < AssociatedParts.Count; i++)
                {
                    concatString += AssociatedParts[i].ToString();
                }
                return concatString;
            }
            else if (AssociatedParts.Count <= 0) { return "Parts at 0 or less!"; }
            return "Error";
        }

        public override string ToString()
        {
            return $"\nPRODUCT\n-------\n" +
                $"\nProduct Name: {Name}" +
                $"\nPrice: {Price:C}\nIn Stock: {InStock}\nMin: {Min}\nMax: {Max}\n" +
                "\nPARTS\n" + PartPrint();

        }

    }
}
