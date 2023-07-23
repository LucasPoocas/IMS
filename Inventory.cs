using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class Inventory
    {
        public  BindingList<Product> Products { get; set; }
        public BindingList<Part> AllParts { get; set; }

        public void addProduct(Product product) { Products.Add(product); }
        public bool removeProduct(int index) { Products.RemoveAt(index); return true; }
        public Product lookupProduct(int index) { return Products[index]; }
        public void updateProduct(int index, Product product) { Products[index] = product; }
        public void addPart(Part part) { AllParts.Add(part); }
        public bool deletePart(Part part)
        {
            AllParts.Remove(part);
            return false;
            //May end up having problems by returning false after returning true. Fix for "not all paths return a value".
        }
        public Part lookupPart(int index) { return AllParts[index]; }
        public void updatePart(int index, Part part) { AllParts[index] = part; }

        public Inventory(BindingList<Product> products, BindingList<Part> allParts)
        {
            Products = products;
            AllParts = allParts;
        }

    }
}
