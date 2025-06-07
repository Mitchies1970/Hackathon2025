using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon2025.DbRepo.Data.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string ProductName { get; set; }

        [Required]
        [StringLength(4000)]
        public required string ProductDescription { get; set; }
    }
}
