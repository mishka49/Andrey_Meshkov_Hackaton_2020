namespace Princess1
{
    public class Knight
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Health { get; set; }

        public string Avatar { get; }

        public Knight()
        {
            X = 0;
            Y = 0;
            Health = 10;
            Avatar = "*";
        }
    }
}
