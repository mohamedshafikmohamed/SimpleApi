using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class Note
    {

        public int Id { get; set; }
        public int BoardId { get; set; }
      
        public int Index { get; set; }

        public string Title { get; set; }
    }
}
