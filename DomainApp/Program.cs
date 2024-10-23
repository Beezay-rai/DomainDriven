using DBDK;
using DBDK.Data;
using DBDK.Helper;
using DomainApp;
using DomainApp.CreationPattern;
using DomainApp.StructurePattern;
using System.Reflection;

public class Program
{
    const string assemblyPath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\DomainApp\\bin\\Debug\\net8.0\\EFcore.dll";
    const string conn = "Server=DESKTOP-KH5S7CP;Initial Catalog=LRMS;User=sa;Password=Dotaplayer;TrustServerCertificate=true;";


    public static void GetDbContextFromAssembly()
    {
        var assembly = Assembly.LoadFrom(assemblyPath);
        if (assembly != null)
        {
            var dbContextType = assembly.GetTypes().FirstOrDefault(x => x.IsSubclassOf(typeof(CustomDbContext)));
            var props = dbContextType.GetProperties();
            if (dbContextType == null)
            {
                throw new Exception("Db Context Not Found !");
            }

            var dbContextHelperType = assembly.GetTypes().FirstOrDefault(x => x.IsSubclassOf(typeof(CustomDbHelper)));
            var dbContextHelper = Activator.CreateInstance(dbContextHelperType) as CustomDbHelper;
            var dbContext = Activator.CreateInstance(dbContextType, dbContextHelper) as CustomDbContext;
            var dbSets = dbContextType.GetProperties()
                .Where(x => x.PropertyType.IsGenericType
                            && x.PropertyType.GetGenericTypeDefinition() == typeof(CustomDbSet<>))
                .ToList();

            var types = assembly.GetTypes();
            foreach (var dbSet in dbSets)
            {
                Console.WriteLine("Table Name :" + dbSet.Name);
                var tabletype = types.Where(x => x.Name == dbSet.Name).FirstOrDefault();
                var tableprops = tabletype.GetProperties();
                foreach (var column in tableprops)
                {
                    Console.WriteLine("Columns :" + column.Name);
                }
                var instance = Activator.CreateInstance(tabletype);
                var a =dbContext.Entry(instance);


                //dbContext.Database.EnsureCreated();
            }


        }


    }



    public static void Main(string[] args)
    {
        //GetDbContextFromAssembly();
        #region AbstractFactoryPattern

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

        #endregion


        #region FactoryPattern
        //GetShoeFactory myFactory = new GetShoeFactory("Nike");
        //var shoeFactory = myFactory.MyFactory();
        //var shoeName =shoeFactory.GetShoeName();
        //Console.WriteLine(shoeName);
        //#endregion

        //#region BridgePattern
        //var circle = new Circle(new RedColor());
        //circle.DrawShape();

        #endregion


        #region Adapter Pattern
        //IBasicPlayer basicPlayer = new Mp3();
        //basicPlayer.Play();

        //IAdvancePlayer mp4Player = new Mp4();

        //IBasicPlayer adapter = new BasicPlayerAdapter(mp4Player);
        //adapter.Play();
        #endregion


        #region Builder Pattern
        //IComputerBuilder compBuilder = new ComputerBuilder();
        //compBuilder.SetGraphics("MyGrapgics");
        //var computer = compBuilder.BuildComputer();
        //Console.WriteLine(computer.Graphics);
        //Console.WriteLine(computer.Ram);
        //Console.WriteLine(string.IsNullOrEmpty( computer.Model)?"Model NOt Defined":computer.Model);
        //compBuilder.SetModel("myModel");
        //Console.WriteLine(string.IsNullOrEmpty( computer.Model)?"Model NOt Defined":computer.Model);
        #endregion


        #region CompositePattern

        //var ProductComposite = new ProductComposite();
        //IProduct toy = new Toy();
        //IProduct Bat = new Bat();
        //ProductComposite.Add(toy);
        //ProductComposite.Add(Bat);
        //Console.WriteLine(ProductComposite.ProductDescription());

        #endregion


        #region DecoratorPattern
        ICoffee coffe = new SimpleCoffee();
        Console.WriteLine("Coffe without Sugar :" + coffe.GetCost());
        coffe = new SugarDecorator(coffe);
        Console.WriteLine("Coffe With Sugar :" + coffe.GetCost());

        #endregion



    }
}