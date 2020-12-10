

namespace Pong.Model
{
    class Ball
    {
        public int TamanhoBola { get; } = Configurations.TamanhoBola;
        public int PositionXBola { get; set; } = Configurations.PositionXBola;
        public int PositionYBola { get; set; } = Configurations.PositionYBola;
        public int VelocidadeBolaX { get; set; } = Configurations.VelocidadeBolaX;
        public int VelocidadeBolaY { get; set; } = Configurations.VelocidadeBolaY;
    }
}
