using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IOrderDetail
    {


        List<DTO.Dish> GetDishes();

        void Add(DTO.Dish dish);




    }

}
