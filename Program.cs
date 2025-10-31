using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace LearningOpenTK
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Create and run the 3D window
            using (var window = new Window3D())
            {
                window.Run(60.0);
            }
        }
    }
}
