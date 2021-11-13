using RenderSharp.CS.RayTracing.Scenes.Cameras;

namespace RenderSharp.CS.RayTracing.Scenes
{
    /// <summary>
    /// A <see cref="Scene"/> for ray tracing.
    /// </summary>
    /// TODO: Change <see cref="Scene"/> to CS.Scenes.Scene.
    public struct Scene
    {
        /// <summary>
        /// The <see cref="Camera"/> in the <see cref="Scene"/>.
        /// </summary>
        public Camera camera;

        /// <summary>
        /// The <see cref="Sky"/> in the <see cref="Scene"/>.
        /// </summary>
        public Sky sky;
    }
}
