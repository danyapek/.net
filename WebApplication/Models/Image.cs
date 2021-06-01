using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Interfaces;

namespace WebApplication.Models
{
    public class Image : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }
    }
}
