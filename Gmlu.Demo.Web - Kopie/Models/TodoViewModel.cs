using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gmlu.Demo.Web.Models
{
    public class TodoViewModel
    {
        public IEnumerable<Todo> Todos { get; set; }

        public Todo CreateModel { get; set; }

        public int NextId => Todos.Max(x => x.Id) + 1;
    }
}
