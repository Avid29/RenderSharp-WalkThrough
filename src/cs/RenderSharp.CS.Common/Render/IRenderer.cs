using ComputeSharp;

namespace RenderSharp.CS.Render
{
    /// <summary>
    /// An interface for renderers to render in RenderSharp.CS
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Renders directly to the output buffer.
        /// </summary>
        /// <param name="buffer">The output buffer.</param>
        public void Render(IReadWriteNormalizedTexture2D<Float4> buffer);
    }
}
