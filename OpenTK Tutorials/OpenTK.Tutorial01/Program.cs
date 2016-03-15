using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK.Tutorial01
{
    class Program
    {
        #region Properties

        static GameWindow Display { get; set; }

        static float Ratio
        {
            get { return (float) Display.ClientSize.Width / (float) Display.ClientSize.Height; }
        }

        #endregion

        #region Methods

        static void Main(string[] args)
        {
            // Create Window
            Display = new GameWindow(800, 600);
            Display.Title = @"OpenTK Tutorial01";

            // Bind Methods
            Display.Load += Load;
            Display.UpdateFrame += Update;
            Display.RenderFrame += Render;

            // Run Update-Render loop
            Display.Run();
        }
        
        static void Load(object sender, EventArgs e)
        {
            // Set Clear Color
            GL.ClearColor(Color.Black);

            // Enable GL checks
            GL.Enable(EnableCap.DepthTest);
        }

        static void Update(object sender, EventArgs e)
        {
            // Update Loop
        }

        static void Render(object sender, EventArgs e)
        {
            // Clear Framebuffer and setup viewport
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.Viewport(Display.ClientRectangle.X, Display.ClientRectangle.Y, Display.ClientSize.Width, Display.ClientSize.Height);

            // Setup Camera
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-Ratio, Ratio, -1.0f, 1.0f, 0.0f, 100.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Triangle
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex3(-1.0f, -1.0f, 0.0f);
            GL.Color3(1.0f, 0.0f, 0.0f);

            GL.Vertex3(1.0f, -1.0f, 0.0f);
            GL.Color3(0.0f, 1.0f, 0.0f);

            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(0.0f, 0.0f, 1.0f);

            GL.End();

            // Swap Framebuffer
            Display.SwapBuffers();
        }

        #endregion
    }
}
