using OpenTK;
using Pong.View;
using Pong.Model;

namespace Pong
{
    class Program : GameWindow
    {
        static void Main()
        {
            using (GameViewPong game = new GameViewPong(Configurations.widhtDisplay, Configurations.heightDisplay, Configurations.title))
            {
                //Run takes a double, which is how many frames per second it should strive to reach.
                //You can leave that out and it'll just update as fast as the hardware will allow it.
                game.Run();
            }
        }
    }
}
