using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces;

namespace WebApplication.Models
{
    public class Author : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public string Country { get; set; }

        [NotMapped]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
