using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public partial class Book : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public Languages Language { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public BookGenre Genre { get; set; }

        public string Description { get; set; } 

        public Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}
