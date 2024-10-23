using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2024.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name...")]
        public string Name { get; set; }
    }
}