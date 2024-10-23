using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.CreationPattern
{
    public interface IFurnitureFactory
    {
        IChair GetChairDescription();
    }

    public interface IChair
    {
        string GetChairName();
    }


    public class ModernChair : IChair
    {

        public string GetChairName()
        {
            return "modern Chair";
        }
    }


    public class OldChair : IChair
    {
        public string GetChairName()
        {
            return "Old Chair";
        }
    }


    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair GetChairDescription()
        {
            return new ModernChair();
        }
    }


    public class OldFurnitureFactory : IFurnitureFactory
    {
        public IChair GetChairDescription()
        {
            return new OldChair();
        }
    }




}
