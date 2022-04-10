using ComputeSharp;
using RenderSharp.CS.RayTracing.Scenes;
using RenderSharp.CS.RayTracing.Scenes.Cameras;
using RenderSharp.CS.RayTracing.Scenes.Rays;

namespace RenderSharp.CS.RayTracing.HLSL
{
    /// <summary>
    /// A Shader for path tracing a <see cref="Scene"/>.
    /// </summary>
    [AutoConstructor]
    [EmbeddedBytecode(DispatchAxis.XY)]
    public readonly partial struct PathTraceShader : IComputeShader
    {
        private readonly Scene scene;
        private readonly IReadWriteNormalizedTexture2D<Float4> buffer;

        /// <inheritdoc/>
        public void Execute()
        {
            Int2 pos = ThreadIds.XY;
            Int2 size = new Int2(buffer.Width, buffer.Height);

            float aspectRatio = (float)size.X / size.Y;
            FullCamera camera = FullCamera.Create(scene.camera, aspectRatio);

            // Find the fraction positions u and v
            float u = (float)pos.X / size.X;
            float v = (float)pos.Y / size.Y;

            // Create a ray for the pixel positions
            Ray ray = FullCamera.CreateRay(camera, u, v);

            // Get the color of the sky in the pixel positions
            buffer[pos] = Sky.Color(scene.sky, ray);
        }
    }
}
