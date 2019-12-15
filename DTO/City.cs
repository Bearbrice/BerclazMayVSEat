namespace DTO
{
    public class City
    {
        public int idCity { get; set; }
        public int code { get; set; }
        public string name { get; set; }

        //Optional
        public override string ToString()
        {
            return $"{idCity}|{code}|{name}";
        }
    }
}
