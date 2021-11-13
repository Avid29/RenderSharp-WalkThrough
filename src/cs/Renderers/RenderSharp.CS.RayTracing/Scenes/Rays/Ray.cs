using System.Numerics;

namespace RenderSharp.CS.RayTracing.Scenes.Rays
{
    /// <summary>
    /// A ray to bounce in a ray tracing scene.
    /// </summary>
    public struct Ray
    {
        /// <summary>
        /// The origin of the <see cref="Ray"/>.
        /// </summary>
        public Vector3 origin;

        /// <summary>
        /// The direction of the <see cref="Ray"/>.
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// Creates a new instance of the <see cref="Ray"/> struct.
        /// </summary>
        /// <remarks>
        /// This is a work around for constructors not working in ComputeSharp shaders.
        /// </remarks>
        /// <returns>A new <see cref="Ray"/> with an origin and direction of 0.</returns>
        public static Ray Create() => Create(Vector3.Zero, Vector3.Zero);

        /// <summary>
        /// Creates a new instance of the <see cref="Ray"/> struct.
        /// </summary>
        /// <remarks>
        /// This is a work around for constructors not working in ComputeSharp shaders.
        /// </remarks>
        /// <param name="origin">The origin of the <see cref="Ray"/>.</param>
        /// <param name="direction">The direction of the <see cref="Ray"/>.</param>
        /// <returns>A new <see cref="Ray"/> with all the specs stated.</returns>
        public static Ray Create(Vector3 origin, Vector3 direction)
        {
            Ray ray;
            ray.origin = origin;
            ray.direction = direction;
            return ray;
        }
    }
}
