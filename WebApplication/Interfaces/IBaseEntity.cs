using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Interfaces
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
