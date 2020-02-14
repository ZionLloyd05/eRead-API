using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Dtos
{
    public class TagDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
