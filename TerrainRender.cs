using SFML.Graphics;
using SFML.System;

namespace Game
{
    internal class TerrainRender
    {
        public uint cellSize;

        public Color landColor;
        public Color seaColor;
        public Color sandColor;
        public Color seashoreColor;
        public Color woodsColor;

        public void DrawTerrain(RenderWindow window, Generation.BiomesType[,] grid, uint gridWidth, uint gridHeight)
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    RectangleShape pixel = new RectangleShape();

                    pixel.Size = new Vector2f(cellSize, cellSize);

                    if (grid[i, j] == Generation.BiomesType.Land)
                    {
                        pixel.FillColor = landColor;
                    }
                    else if (grid[i, j] == Generation.BiomesType.Sea)
                    {
                        pixel.FillColor = seaColor;
                    }
                    else if (grid[i, j] == Generation.BiomesType.Sand)
                    {
                        pixel.FillColor = sandColor;
                    }
                    else if (grid[i, j] == Generation.BiomesType.Seashore)
                    {
                        pixel.FillColor = seashoreColor;
                    }
                    else if (grid[i, j] == Generation.BiomesType.Woods)
                    {
                        pixel.FillColor = woodsColor;
                    }

                    pixel.Position = new Vector2f(i * cellSize, j * cellSize);

                    window.Draw(pixel);
                }
            }
        }
    }
}
