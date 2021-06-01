using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces;

namespace WebApplication.Models
{
    public partial class User : IBaseEntity<int>
    {
        public int Id { get; set;  }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
