using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApplication.Models
{
    public interface IOrderDetail
    {
        

        List<DTO.Dish> GetDishes();

        void Add(DTO.Dish dish);
        



    }
    
}
