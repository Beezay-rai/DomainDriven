using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.CreationPattern
{
    public interface IShoeFactory
    {
        string GetShoeName();
    }


    public class GetShoeFactory
    {
        private string _shoeName;

        public GetShoeFactory(string shoeName)
        {
            _shoeName = shoeName;
        }

        public IShoeFactory MyFactory()
        {
            IShoeFactory shoeFactory;
            switch (_shoeName)
            {
                case "Nike":
                    shoeFactory = new Nike();
                    break;
                case "Addidas":
                    shoeFactory = new Addidas();
                    break;
                default:
                    shoeFactory = new Addidas();
                    break;

            }
            return shoeFactory;
        }
    }


    public class Nike : IShoeFactory
    {
        public string GetShoeName()
        {
            return "Nike type shoes";
        }
    }
    public class Addidas : IShoeFactory
    {
        public string GetShoeName()
        {
            return "Addidas type Shoes";
        }
    }
}
