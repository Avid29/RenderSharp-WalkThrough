using ComputeSharp;
using RenderSharp.CS.RayTracing.Scenes;
using RenderSharp.CS.Render;

namespace RenderSharp.CS.RayTracing.HLSL
{
    /// <summary>
    /// An <see cref="IRenderer"/> for ray tracing with ComputeSharp.
    /// </summary>
    public class HlslRayTraceRenderer : IRenderer
    {
        /// <inheritdoc/>
        public void Render(IReadWriteTexture2D<Float4> buffer)
        {
            // TODO: Hardcode scene.
            Scene scene = new Scene();
            Gpu.Default.For(buffer.Width, buffer.Width, new PathTraceShader(scene, buffer));
        }
    }
}
