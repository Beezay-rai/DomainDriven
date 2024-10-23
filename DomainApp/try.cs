//using DomainApp.Migrations;

//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.Extensions.Options;
//using System.Reflection;

//public class Program
//{

//    const string assemblyPath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\DomainApp\\bin\\Debug\\net8.0\\EFcore.dll";
//    const string conn = "Server=DESKTOP-KH5S7CP;Initial Catalog=LRMS;User=sa;Password=Dotaplayer;TrustServerCertificate=true;";


//    public static DbContext GetDbContextFromAssembly()
//    {
//       var assembly = Assembly.LoadFrom(assemblyPath);
//        if (assembly != null)
//        {
//            var dbContextType = assembly.GetTypes().FirstOrDefault(x=>x.IsSubclassOf(typeof(DbContext)));
//            if (dbContextType == null)
//            {
//                throw new Exception("Db Context Not Found !");
//            }

//            //var optionbuilderType =typeof(DbContextOptionsBuilder<>).MakeGenericType(dbContextType);
//            //var optionbuilder =Activator.CreateInstance(optionbuilderType) as DbContextOptionsBuilder;
//            //optionbuilder.UseSqlServer("");
//            //var sqlServerMethod = typeof(SqlServerDbContextOptionsExtensions)
//            //                //.GetMethod("UseSqlServer", BindingFlags.Static,null, new[] { typeof(DbContextOptionsBuilder), typeof(string) }, null);
//            //                .GetMethod("UseSqlServer", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(DbContextOptionsBuilder), typeof(string) }, null);



//            var dbContext =Activator.CreateInstance(dbContextType) as DbContext;
//            var migrationbuilder = new MigrationBuilder(dbContext.Database.ProviderName);
//            var myMigration = new testMigration();
//            myMigration.ApplyMigration(migrationbuilder);
//            foreach (var operation in migrationbuilder.Operations)
//            {
//                var sqlCommand = operation.ToString();
//                dbContext.Database.ExecuteSqlRaw(sqlCommand);
//            }
//            return dbContext;   

//        }
//        else
//        {
//            throw new Exception("Assembly Not Found !");
//        }

//    }



//    public class User
//    {
//        public int Id { get; private set; }
//        public string Name { get; private set; }
//        public string Address { get; private set; }
//    }

//    public static void Main(string[] args)
//    {
//        var dbContext = GetDbContextFromAssembly();

//        if (dbContext != null)
//        {
//            Console.WriteLine("Context Found !");


//            dbContext.Database.EnsureCreated();
//            //dbContext.Database.Migrate();

//            var sql = "Select * from [dbo].[User]";



//            var Users = dbContext.Database.SqlQueryRaw<User>(sql).ToList();

//            Users.ForEach(x => Console.WriteLine("UserName : " + x.Name));

//            var insertSql = "Insert into [dbo].[User](Name,Address)Values('Test','Kapan') ";


//            var insertexe = dbContext.Database.ExecuteSqlRawAsync(insertSql).GetAwaiter().GetResult();

//            var userAfterInsert = dbContext.Database.SqlQueryRaw<User>(sql).ToList();
//            userAfterInsert.ForEach(x => Console.WriteLine(" After Insert UserName : " + x.Name));






//        }


//    }
//}
