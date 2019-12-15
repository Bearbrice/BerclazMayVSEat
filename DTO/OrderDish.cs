namespace DTO
{
    public class OrderDish
    {
        public int fk_idOrder { get; set; }
        public int fk_idDish { get; set; }

        //Optional
        public override string ToString()
        {
            return $"{fk_idDish}|{fk_idDish}";
        }
    }
}
