using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DBDK
{
    public class CustomDbSet<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public CustomDbSet(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }
    }


}
