using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class Board
    {

        public int Id { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Title { get; set; }
       
        public string Description { get; set; }
       
    }
}
