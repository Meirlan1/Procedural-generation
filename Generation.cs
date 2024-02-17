using System;

namespace Game
{
    internal class Generation
    {
        public uint rows;
        public uint columns;

        public enum BiomesType
        {
            None,
            Land,
            Sea,
            Sand,
            Seashore,
            Woods
        }

        public BiomesType[,]? grid;

        public void CreateStartMatrix()
        {
            grid = new BiomesType[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid[i, j] = BiomesType.None;
                }    
            }

            Random random = new Random();

            int randomNum;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    randomNum = random.Next(1, 3);

                    if (randomNum == 1)
                    {
                        grid[i, j] = BiomesType.Sea;
                    }

                    else
                    {
                        grid[i, j] = BiomesType.Land;
                    }
                }
            }
        }

        public void NextGenerationLands() 
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int counterSea = 0;
                    int counterLand = 0;

                    if (i - 1 >= 0)
                    {
                        if (grid[i - 1, j] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (grid[i, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if (i + 1 <= columns - 1)
                    {
                        if (grid[i + 1, j] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if (j + 1 <= rows - 1)
                    {
                        if (grid[i, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if ((j - 1 >= 0) && (i + 1 <= columns - 1))
                    {
                        if (grid[i + 1, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if ((j + 1 <= rows - 1) && (i + 1 <= columns - 1))
                    {
                        if (grid[i + 1, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if ((j - 1 >= 0) && (i - 1 >= 0))
                    {
                        if (grid[i - 1, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else
                        {
                            counterLand++;
                        }
                    }

                    if ((j + 1 <= rows - 1) && (i - 1 >= 0))
                    {
                        if (grid[i - 1, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                        else 
                        {
                            counterLand++;
                        }
                    }

                    if (grid[i, j] == BiomesType.Land)
                    {
                        if (counterSea == 3 || counterSea == 6 || counterSea == 7 || counterSea == 8)
                        {
                            grid[i, j] = BiomesType.Sea;
                        }
                    }

                    if (grid[i, j] == BiomesType.Sea)
                    {
                        if (counterLand == 3 || counterLand == 6 || counterLand == 7 || counterLand == 8)
                        {
                            grid[i, j] = BiomesType.Land;
                        }
                    }
                }
            }
        }

        public void StartBorderSands()
        {
            for (int i = 0; i < rows; i++) 
            { 
                for (int j = 0; j < columns; j++)
                {
                    int counterSea = 0;

                    if (i - 1 >= 0)
                    {
                        if (grid[i - 1, j] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (grid[i, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if (i + 1 <= 99)
                    {
                        if (grid[i + 1, j] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if (j + 1 <= 99)
                    {
                        if (grid[i, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if ((j - 1 >= 0) && (i + 1 <= 99))
                    {
                        if (grid[i + 1, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if ((j + 1 <= 99) && (i + 1 <= 99))
                    {
                        if (grid[i + 1, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if ((j - 1 >= 0) && (i - 1 >= 0))
                    {
                        if (grid[i - 1, j - 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if ((j + 1 <= 99) && (i - 1 >= 0))
                    {
                        if (grid[i - 1, j + 1] == BiomesType.Sea)
                        {
                            counterSea++;
                        }
                    }

                    if (grid[i, j] == BiomesType.Land)
                    {
                        if (counterSea >= 1)
                        {
                            grid[i, j] = BiomesType.Sand;
                        }
                    }
                }
            }
        }

        public void NextGenerationSands()
        {

        }
    }
}
