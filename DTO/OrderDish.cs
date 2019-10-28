using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDish
    {
        public int fk_idOrder { get; set; }
        public int fk_idDish { get; set; }
        public int quantity { get; set; }

        public override string ToString()
        {
            return $"{fk_idDish}|{fk_idDish}|{quantity}";
        }
    }
}
