using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.StructurePattern
{
    public interface ICoffee
    {
        int GetCost();
    }

    public class SimpleCoffee : ICoffee
    {
        public int GetCost()
        {
            return 5;
        }
    }


    public class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual int GetCost()
        {
            return _coffee.GetCost();
        }
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }
        public override int GetCost()
        {
            return base.GetCost() + 15;
        }
    }


    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override int GetCost()
        {
            var cost =base.GetCost();
            var costWithSugar = cost + 5;
            return costWithSugar;
        }
    }
}
