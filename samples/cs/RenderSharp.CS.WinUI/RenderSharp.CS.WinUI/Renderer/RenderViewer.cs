using ComputeSharp;
using ComputeSharp.WinUI;
using RenderSharp.CS.Render;
using System;

namespace RenderSharp.CS.WinUI.Renderer
{
    /// <summary>
    /// A <see cref="IShaderRunner"/> for displaying <see cref="IRenderer"/>s.
    /// </summary>
    /// <typeparam name="TRenderer">The type of <see cref="IRenderer"/> to show.</typeparam>
    public class RenderViewer<TRenderer> : IShaderRunner
        where TRenderer : IRenderer
    {
        private TRenderer _renderer;

        /// <summary>
        /// Creates a new instance of the <see cref="RenderViewer{TRenderer}"/> class.
        /// </summary>
        /// <param name="renderer">The rendere<see cref="IRenderer"/> being viewed.</param>
        public RenderViewer(TRenderer renderer)
        {
            _renderer = renderer;
        }

        /// <inheritdoc/>
        public void Execute(IReadWriteTexture2D<Float4> texture, TimeSpan timespan)
        {
            _renderer.Render(texture);
        }
    }
}
