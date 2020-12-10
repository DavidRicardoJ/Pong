using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Pong.View;

namespace Pong.Model
{
    class Player : GameWindow
    {
      
        public int HeightPlayer { get; set; } = Configurations.HeightPlayer;
        public int WidthtPlayer { get; set; } = Configurations.WidthtPlayer;

        public int PositionYPlayer1 { get; set; } = Configurations.PositionYPlayer;
        public int PositionYPlayer2 { get; set; } = Configurations.PositionYPlayer;

        public int PositionXPlayer1 { get; set; } 
        public int PositionXPlayer2 { get; set; } 

    }
}
