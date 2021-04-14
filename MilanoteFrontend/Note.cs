using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilanoteFrontend
{
    public class Note
    {

        public int Id { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
