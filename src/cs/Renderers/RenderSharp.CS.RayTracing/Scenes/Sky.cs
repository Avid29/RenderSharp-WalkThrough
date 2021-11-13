using RenderSharp.CS.RayTracing.Scenes.Rays;
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

        /// <summary>
        /// Gets the color of the sky as hit by a ray.
        /// </summary>
        /// <param name="sky">The <see cref="Sky"/>being hit.</param>
        /// <param name="ray">The <see cref="Ray"/> hitting the <see cref="Sky"/.></param>
        /// <returns>The color of the sky in the hit.</returns>
        public static Vector4 Color(Sky sky, Ray ray)
        {
            Vector3 unitDirection = Vector3.Normalize(ray.direction);
            float pos = 0.5f * (unitDirection.Y + 1);
            return pos * sky.albedo + (1 - pos) * Vector4.One; 
        }
    }
}
