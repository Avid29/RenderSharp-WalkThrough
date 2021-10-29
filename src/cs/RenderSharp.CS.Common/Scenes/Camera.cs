using System.Numerics;

namespace RenderSharp.CS.Scenes
{
    /// <summary>
    /// A Camera for a RenderSharp scene.
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="origin">The origin of the <see cref="Camera"/>.</param>
        /// <param name="target">The target position of the <see cref="Camera"/>.</param>
        /// <param name="fov">The field of view of the <see cref="Camera"/>.</param>
        public Camera(Vector3 origin, Vector3 target, float fov)
        {
            Origin = origin;
            Target = target;
            FOV = fov;
        }

        /// <summary>
        /// Gets or sets the origin of the <see cref="Camera"/>.
        /// </summary>
        public Vector3 Origin { get; set; }

        /// <summary>
        /// Gets or sets the target position of the <see cref="Camera"/>.
        /// </summary>
        /// <remarks>
        /// Might be replaced with a direction rotation vector.
        /// </remarks>
        public Vector3 Target { get; set; }

        /// <summary>
        /// Gets or sets the field of view for the <see cref="Camera"/>.
        /// </summary>
        public float FOV { get; set; }
    }
}
