using System.Numerics;

namespace RenderSharp.CS.RayTracing.Scenes
{
    /// <summary>
    /// A <see cref="CS.Scenes.Sky"/> for ray tracing.
    /// </summary>
    public struct Sky
    {
        /// <summary>
        /// The base color of the sky.
        /// </summary>
        public Vector4 albedo;

        /// <summary>
        /// Creates a new instance of the <see cref="Sky"/>.
        /// </summary>
        /// <remarks>
        /// This is a work around for constructors not working in ComputeSharp shaders.
        /// </remarks>
        /// <param name="albedo">The base color of the <see cref="Sky"/>.</param>
        /// <returns>A new <see cref="Sky"/> with all the specs stated.</returns>
        public static Sky Create(Vector4 albedo)
        {
            Sky sky;
            sky.albedo = albedo;
            return sky;
        }
    }
}
