using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine.windowWidth = 800;
            Engine.windowHeight = 800;
            Engine.windowTitle = "Window";
            Engine.windowStyle = Styles.Close;

            Engine.vSyncEnabled = true;
            Engine.maxFPS = -1;

            Engine.gridRows = 200;
            Engine.gridColumns = 200;
            Engine.gridCellSize = 4;

            Engine.gridLandColor = new Color(139, 195, 74);
            Engine.gridSeaColor = new Color(33, 150, 255);
            Engine.gridSandColor = new Color(255, 235, 59);
            Engine.gridSeashoreColor = new Color(0, 188, 255);
            Engine.gridWoodsColor = new Color(85, 139, 47);

            Engine.generationCount1 = 600;
            Engine.generationCount2 = 200;

            Engine.WindowInit();
            Engine.GenerationInit();
            Engine.TerrainRenderInit();
            Engine.Start();
        }
    }
}
