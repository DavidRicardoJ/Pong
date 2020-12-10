using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Pong.Model
{
    static class Configurations 
    {
        // Configuações da bola
        public static int TamanhoBola = 20;
        public static int PositionXBola = 0;
        public static int PositionYBola = 0;
        public static int VelocidadeBolaX = 3;
        public static int VelocidadeBolaY = 3;


        // Configurações do player
        public static int HeightPlayer = 3 * TamanhoBola;
        public static int WidthtPlayer = TamanhoBola;
        public static int PositionYPlayer = 0;

        // Configurações do diplay
        public static int widhtDisplay = 800;
        public static int heightDisplay = 500;
        public static string title = "Pong";

    }
}
