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
            using (var window = new Mywindow(800, 600, "MyWindow"))
            {
                window.Run(60.0);
            }
        }
    }
}
