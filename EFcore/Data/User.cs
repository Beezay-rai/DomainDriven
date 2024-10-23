using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    public class User
    {
        private User(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }

        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public static User Create(string Name, string Address)
        {
            return new User(Name, Address);
        }
    }
}
