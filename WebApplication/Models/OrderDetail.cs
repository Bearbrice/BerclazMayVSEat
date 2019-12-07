using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApplication.Models
{
    public class OrderDetail
    {
        public List<DTO.Dish> dishes {get; set;}


        
        public List<DTO.Dish> getDishes()
        {
            return dishes;
        }


    }
    
}
