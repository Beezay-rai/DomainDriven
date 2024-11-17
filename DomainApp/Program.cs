using DomainApp.CreationPattern;
using DomainApp.StructurePattern;

public class Program
{


    public static void Main(string[] args)
    {
        #region Pattern Learning
        //#region AbstractFactoryPattern

        //IFurnitureFactory factory;
        //string chairType = "Old";
        //switch (chairType)
        //{
        //    case "Modern":
        //        factory = new ModernFurnitureFactory();
        //        break;
        //    case "Old":
        //        factory = new OldFurnitureFactory();
        //        break;
        //    default:
        //        factory = new ModernFurnitureFactory();
        //        break;

        //}
        //Console.WriteLine(factory.GetChairDescription());

        //#endregion


        //#region FactoryPattern
        //GetShoeFactory myFactory = new GetShoeFactory("Nike");
        //var shoeFactory = myFactory.MyFactory();
        //var shoeName = shoeFactory.GetShoeName();
        //Console.WriteLine(shoeName);
        //#endregion

        //#region BridgePattern
        //var circle = new Circle(new RedColor());
        //circle.DrawShape();

        //#endregion


        //#region Adapter Pattern
        //IBasicPlayer basicPlayer = new Mp3();
        //basicPlayer.Play();

        //IAdvancePlayer mp4Player = new Mp4();

        //IBasicPlayer adapter = new BasicPlayerAdapter(mp4Player);
        //adapter.Play();
        //#endregion


        //#region Builder Pattern
        //IComputerBuilder compBuilder = new ComputerBuilder();
        //compBuilder.SetGraphics("MyGrapgics");
        //var computer = compBuilder.BuildComputer();
        //Console.WriteLine(computer.Graphics);
        //Console.WriteLine(computer.Ram);
        //Console.WriteLine(string.IsNullOrEmpty(computer.Model) ? "Model NOt Defined" : computer.Model);
        //compBuilder.SetModel("myModel");
        //Console.WriteLine(string.IsNullOrEmpty(computer.Model) ? "Model NOt Defined" : computer.Model);
        //#endregion


        //#region CompositePattern

        //var ProductComposite = new ProductComposite();
        //IProduct toy = new Toy();
        //IProduct Bat = new Bat();
        //ProductComposite.Add(toy);
        //ProductComposite.Add(Bat);
        //Console.WriteLine(ProductComposite.ProductDescription());

        //#endregion


        //#region DecoratorPattern
        //ICoffee coffe = new SimpleCoffee();
        //Console.WriteLine("Coffe without Sugar :" + coffe.GetCost());
        //coffe = new SugarDecorator(coffe);
        //Console.WriteLine("Coffe With Sugar :" + coffe.GetCost());

        //#endregion
        #endregion



    }
}