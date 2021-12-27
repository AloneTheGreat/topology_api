using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace topology_api.modules
{
    public class Values
    {
        [Required]
        public double @default { get; set; }
        [Required]
        public double min { get; set; }
        [Required]
        public double max { get; set; }
    }
}