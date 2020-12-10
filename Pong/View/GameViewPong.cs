using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Pong.Model;
using System;

namespace Pong.View
{
    public class GameViewPong : GameWindow
    {
        Ball bola = new Ball();
        Player player = new Player();
        Random positionAleatory = new Random();

        public GameViewPong(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            player.PositionXPlayer1 = -ClientSize.Width / 2 + player.WidthtPlayer / 2;
            player.PositionXPlayer2 = ClientSize.Width / 2 - player.WidthtPlayer / 2;



            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.Clear(ClearBufferMask.ColorBufferBit);


            desenharRetangulo(bola.PositionXBola, bola.PositionYBola, bola.TamanhoBola, bola.TamanhoBola, 1.0f, 1.0f, 0.0f);
            desenharRetangulo(player.PositionXPlayer1, player.PositionYPlayer1, player.WidthtPlayer, player.HeightPlayer, 1.0f, 0.0f, 0.0f);
            desenharRetangulo(player.PositionXPlayer2, player.PositionYPlayer2, player.WidthtPlayer, player.HeightPlayer, 0.0f, 0.0f, 1.0f);



            SwapBuffers();
        }

        void desenharRetangulo(int x, int y, int largura, int altura, float r, float g, float b)
        {
            GL.Color3(r, g, b);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, 0.5f * altura + y);
            GL.Vertex2(-0.5f * largura + x, 0.5f * altura + y);
            GL.End();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            bola.PositionXBola += bola.VelocidadeBolaX;
            bola.PositionYBola += bola.VelocidadeBolaY;

            if (bola.PositionXBola + bola.TamanhoBola / 2 > player.PositionXPlayer2 - player.WidthtPlayer / 2
                && bola.PositionYBola - bola.TamanhoBola / 2 < player.PositionYPlayer2 + player.HeightPlayer / 2
                && bola.PositionYBola + bola.TamanhoBola / 2 > player.PositionYPlayer2 - player.HeightPlayer / 2)
            {
                bola.VelocidadeBolaX = -bola.VelocidadeBolaX;
            }

            if (bola.PositionXBola - bola.TamanhoBola / 2 < player.PositionXPlayer1 + player.WidthtPlayer / 2
                && bola.PositionYBola + bola.TamanhoBola / 2 > player.PositionYPlayer1 - player.HeightPlayer / 2
                && bola.PositionYBola - bola.TamanhoBola / 2 < player.PositionYPlayer1 + player.HeightPlayer / 2)
            {
                bola.VelocidadeBolaX = -bola.VelocidadeBolaX;
            }

            // Altera o módulo da velocidade ao chocar com a borda superior ou inferior
            if (bola.PositionYBola + bola.TamanhoBola / 2 > ClientSize.Height / 2)
            {
                bola.VelocidadeBolaY = -bola.VelocidadeBolaY;
            }

            if (bola.PositionYBola - bola.TamanhoBola / 2 < -ClientSize.Height / 2)
            {
                bola.VelocidadeBolaY = -bola.VelocidadeBolaY;
            }

            BallInit(); // Reinicia a bola no jogo

            GameKeyDown(); // Verifica os comandos do teclado

        }

        private void GameKeyDown()
        {
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                if (!(player.PositionYPlayer1 + player.HeightPlayer / 2 > ClientSize.Height / 2))
                {
                    player.PositionYPlayer1 += 5;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                if (!(player.PositionYPlayer1 - player.HeightPlayer / 2 < -ClientSize.Height / 2))
                {
                    player.PositionYPlayer1 -= 5;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                if (!(player.PositionYPlayer2 + player.HeightPlayer / 2 > ClientSize.Height / 2))
                {
                    player.PositionYPlayer2 += 5;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                if (!(player.PositionYPlayer2 - player.HeightPlayer / 2 < -ClientSize.Height / 2))
                {
                    player.PositionYPlayer2 -= 5;
                }
            }
        }
        private void BallInit()
        {
            if (bola.PositionXBola < -ClientSize.Width / 2)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

                bola.PositionXBola = -ClientSize.Width / 2 + (((ClientSize.Width / 2) / 3));
                bola.PositionYBola = positionAleatory.Next(-ClientSize.Height / 2, ClientSize.Height / 2);
                bola.VelocidadeBolaX *= -1;

            }
            if (bola.PositionXBola > ClientSize.Width / 2)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

                bola.PositionXBola = ClientSize.Width / 2 - (((ClientSize.Width / 2) / 3));
                bola.PositionYBola = positionAleatory.Next(-ClientSize.Height / 2, ClientSize.Height / 2);
                bola.VelocidadeBolaX *= -1;

            }
        }
    }
}
