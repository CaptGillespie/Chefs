using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chefs.Models;
public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [MinLength(2)]
        public String DishName {get; set;}

        [Required]
        public int Calories {get; set;}

        [Required]
        public String Description {get; set;}

        [Required]
        public int Tastiness {get; set;}

        public int UserId {get;set;}
        public Chef Creator {get;set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

       
    }