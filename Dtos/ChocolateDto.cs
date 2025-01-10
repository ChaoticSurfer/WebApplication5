using System.ComponentModel.DataAnnotations;
using WebApplication5.Models;

namespace WebApplication5.Dtos
{
    public class ChocolateDto // Data Transfer Object
    {

        [Required]
        [Length(2, 10, ErrorMessage = "Length must be from 2 to 10")]
        public string Name { get; set; }

        [Length(2, 10, ErrorMessage = "Length must be from 2 to 10")]
        public string Brand { get; set; }


        [Range(1, 200, ErrorMessage = "Weight must be from 1 to 100")]
        public int Weight { get; set; } // grams

        public Chocolate ToChocolate() {
            return new Chocolate { Name = Name, Brand = Brand , Weight= Weight};
        }
    }
}
