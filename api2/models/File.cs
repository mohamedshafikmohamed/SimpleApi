using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class File
    {

        public int Id { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public byte[] file { get; set; }

    }
}
