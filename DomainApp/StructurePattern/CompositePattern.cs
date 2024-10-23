using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.StructurePattern
{


    public class ProductComposite : IProduct
    {
        private List<IProduct> products = new List<IProduct>();

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public string ProductDescription()
        {
            string Product = "Available Product :\n";

            foreach(var desc in products)
            {
                Product += desc.ProductDescription();
                
            };
            return Product;
                
        }

    }




    public interface IProduct
    {
        string ProductDescription();

    }

    public class Toy : IProduct
    {
        public string ProductDescription()
        {
            return "This is Toy \n";
        }
    }

    public class Bat : IProduct
    {
        public string ProductDescription()
        {
            return "This is Bat \n";
        }
    }
}
