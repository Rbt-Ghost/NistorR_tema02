using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace LearningOpenTK
{
    public class Mywindow : GameWindow
    {
        private Triangle triangle;
        public Mywindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.0f, 1.0f, 1.0f, 1.0f);

            triangle = new Triangle();
            triangle.Load();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            triangle.Draw();
            triangle.move(0.01f, 0.01f);

            SwapBuffers();
        }
    }
}
