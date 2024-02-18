using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Game
{
    internal class Engine
    {
        public static uint windowWidth;
        public static uint windowHeight;
        public static string? windowTitle;
        public static int maxFPS; // -1 is vSync
        public static bool vSyncEnabled;
        public static Styles windowStyle;

        private static RenderWindow? window;
        public static Generation? generation;
        public static TerrainRender? terrainRender;


        public static uint gridRows;
        public static uint gridColumns;
        public static uint gridCellSize;
        public static Color gridLandColor;
        public static Color gridSeaColor;
        public static Color gridSandColor;
        public static Color gridSeashoreColor;
        public static Color gridWoodsColor;

        public static uint generationCount1;
        public static uint generationCount2;

        public static void WindowInit()
        {
            window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle, windowStyle);

            if (!vSyncEnabled && maxFPS != -1)
            {
                window.SetVerticalSyncEnabled(false);
                window.SetFramerateLimit((uint)maxFPS);
            }

            else if (vSyncEnabled && maxFPS == -1)
            {
                window.SetVerticalSyncEnabled(true);
            }

            window.Closed += Window_Closed;
        }

        public static void GenerationInit()
        {
            generation = new Generation();

            generation.rows = gridRows;
            generation.columns = gridColumns;

            generation.CreateStartMatrix();

            for (int i = 0; i < generationCount1; i++)
            {
                generation.NextGenerationLands();
            }

            generation.StartBorderSands();
            
            for (int i = 0; i < generationCount2; i++)
            {
                generation.NextGenerationSands();
            }
            
        }

        public static void TerrainRenderInit()
        {
            terrainRender = new TerrainRender();

            terrainRender.cellSize = gridCellSize;
            
            terrainRender.landColor = gridLandColor;
            terrainRender.seaColor = gridSeaColor;
            terrainRender.sandColor = gridSandColor;
            terrainRender.seashoreColor = gridSeashoreColor;
            terrainRender.woodsColor = gridWoodsColor;
        }

        
        public static void Start() 
        {
            terrainRender.DrawTerrain(window, generation.grid, generation.rows, generation.columns);
            window.Display();

            while (window.IsOpen)
            {
                window.DispatchEvents();                
            }
        }

        private static void Window_Closed(object? sender, EventArgs e)
        {
            window.Close();
        }
    }
}
