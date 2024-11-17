namespace DomainApp.StructurePattern
{
    public interface IColor
    {
        void ApplyColor(string shapeName);
    }


    public class RedColor : IColor
    {
        public void ApplyColor(string shapeName)
        {
            Console.WriteLine("Applied Red Color to :" + shapeName);
        }
    }

    public abstract class Shape
    {
        public IColor _color;
        protected Shape(IColor color)
        {
            _color = color;
        }
        public abstract void DrawShape();
    }


    public class Circle : Shape
    {
        private IColor _color;
        public Circle(IColor color) : base(color)
        {
            _color = color;
        }

        public override void DrawShape()
        {
            Console.WriteLine("Drawed Circle !");
            _color.ApplyColor("Circle");
        }
    }
}
