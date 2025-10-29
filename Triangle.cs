using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace LearningOpenTK
{
    public class Triangle
    {
        private readonly float[] vertics = {
            0.0f, 0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f
        };

        private int vertexArray;
        private int vertexBuffer;
        private int shaderProgram;

        public void Load()
        {
            string vertexShaderSource = @"
                #version 330 core
                layout(location = 0) in vec3 aPosition;
                void main()
                {
                    gl_Position = vec4(aPosition, 1.0);
                }
            ";

            string fragmentShaderSource = @"
                #version 330 core
                out vec4 FragColor;
                void main()
                {
                    FragColor = vec4(1.0, 0.0, 0.0, 1.0);
                }
            ";

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentShader);
            GL.LinkProgram(shaderProgram);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            vertexArray = GL.GenVertexArray();
            vertexBuffer = GL.GenBuffer();

            GL.BindVertexArray(vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertics.Length * sizeof(float), vertics, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Draw()
        {
            GL.UseProgram(shaderProgram);
            GL.BindVertexArray(vertexArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void move(float x, float y)
        {
            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                vertics[1] += y;
                vertics[4] += y;
                vertics[7] += y;
            }
            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                vertics[1] -= y;
                vertics[4] -= y;
                vertics[7] -= y;
            }
            if (Keyboard.GetState().IsKeyDown(Key.A))
            {
                vertics[0] -= x;
                vertics[3] -= x;
                vertics[6] -= x;
            }
            if (Keyboard.GetState().IsKeyDown(Key.D))
            {
                vertics[0] += x;
                vertics[3] += x;
                vertics[6] += x;
            }
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertics.Length * sizeof(float), vertics, BufferUsageHint.StaticDraw);

        }
    }
}
