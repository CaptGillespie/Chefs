using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs.Models{    
public class Chef
{
    [Key]
    public int UserId {get;set;}

    [Required]
    public string FirstName {get;set;}

    [Required]
    public string LastName {get;set;}
    
    [Required]
    public DateTime DateofBirth {get;set;}
  
   
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Dish> CreatedDishes {get; set;}
    
    public Chef ()
    {

    }
} 
}  