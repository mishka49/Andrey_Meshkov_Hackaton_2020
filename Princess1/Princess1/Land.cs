using System;

namespace Princess1
{
    public class Land
    {
        public static int[,] Field { get; set; }

        public Knight knight;

        public Princess princess;

        public Land(int sizeByX, int sizeByY)
        {
            knight = new Knight();
            princess = new Princess(sizeByY - 1, sizeByX - 1);
            Field = CreateField(sizeByX, sizeByY);
        }

        private static int[,] CreateField(int sizeByX, int sizeByY)
        {
            int[,] field = new int[sizeByY, sizeByX];

            for (int i = 0; i < sizeByY; i++)
            {
                for (int j = 0; j < sizeByX; j++)
                {
                    field[i, j] = 0;
                }
            }

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                field[random.Next(0, sizeByY), random.Next(0, sizeByX)] = random.Next(1, 11);
            }

            return field;
        }
    }
}
