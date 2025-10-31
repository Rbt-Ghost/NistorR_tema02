using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace LearningOpenTK
{
    class Grid
    {
        private readonly Color colorisation;
        private bool visibility;

        // CONST
        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POINT_OFFSET = GRIDSTEP * UNITS;
        private const int MICRO_OFFSET = 1; // usefeul because otherwise the axes will be "drown" in overlapping grid lines...

        /// <summary>
        // / Default constructor.
        /// </summary>
        public Grid()
        {
            colorisation = GRIDCOLOR;
            visibility = true;
        }

        /// <summary>
        /// Sets visibility of the object ON.
        /// </summary>
        public void Show()
        {
            visibility = true;
        }

        public void Hide()
        {
            visibility = false;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        /// <summary>
        /// This methods handles the drawing of the object. Must be called - always - from OnRenderFrame() method! The drawing can be unconditional.
        /// </summary> 

        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorisation);
                for (int i = -1 * GRIDSTEP * UNITS; i <= GRIDSTEP * UNITS; i += GRIDSTEP)
                {
                    // XZ plan drawing: parallel with Oz
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);

                    // XZ plan drawing: parallel with Ox
                    GL.Vertex3(POINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POINT_OFFSET, 0, i + MICRO_OFFSET);
                }
                GL.End();
            }
        }
    }
}
