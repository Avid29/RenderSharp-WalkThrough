using System.Numerics;

namespace RenderSharp.CS.RayTracing.Scenes
{
    /// <summary>
    /// A <see cref="CS.Scenes.Camera"/> for ray tracing.
    /// </summary>
    public struct Camera
    {
        /// <summary>
        /// The origin of the <see cref="Camera"/>.
        /// </summary>
        public Vector3 origin;

        /// <summary>
        /// The target of the <see cref="Camera"/>.
        /// </summary>
        public Vector3 target;

        /// <summary>
        /// The field of view of the <see cref="Camera"/>.
        /// </summary>
        public float fov;

        /// <summary>
        /// Creates a new instance of the <see cref="Camera"/>.
        /// </summary>
        /// <remarks>
        /// This is a work around for constructors not working in ComputeSharp shaders.
        /// </remarks>
        /// <param name="origin">The origin of the <see cref="Camera"/>.</param>
        /// <param name="target">The target of the <see cref="Camera"/>.</param>
        /// <param name="fov">The field of view of the <see cref="Camera"/>.</param>
        /// <returns>A new <see cref="Camera"/> with all the specs stated.</returns>
        public static Camera CreateCamera(Vector3 origin, Vector3 target, float fov)
        {
            Camera camera;
            camera.origin = origin;
            camera.target = target;
            camera.fov = fov;
            return camera;
        }
    }
}
