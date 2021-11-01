using ComputeSharp;
using RenderSharp.CS.RayTracing.Scenes;
using RenderSharp.CS.RayTracing.Scenes.Cameras;
using RenderSharp.CS.Render;
using System.Numerics;

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
            Scene scene;
            scene.camera = Camera.Create(Vector3.UnitZ * -1, Vector3.Zero, 90);
            scene.sky = Sky.Create(new Vector4(0.3f, 0.7f, 1f, 1f));

            Gpu.Default.For(buffer.Width, buffer.Width, new PathTraceShader(scene, buffer));
        }
    }
}
