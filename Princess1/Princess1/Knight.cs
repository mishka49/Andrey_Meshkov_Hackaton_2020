namespace Princess1
{
    public class Knight : Person
    {
        public int Health { get; set; }

        public Knight()
        {
            X = 0;
            Y = 0;
            Health = 10;
            Avatar = "*";
        }
    }
}
