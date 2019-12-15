namespace DTO
{
    public class Login
    {
        public int idLogin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int fk_customerId { get; set; }
        public int fk_staffId { get; set; }

        //Optional
        public override string ToString()
        {
            return $"{idLogin}|{username}|{password}|{fk_customerId}|{fk_staffId}";
        }
    }
}
