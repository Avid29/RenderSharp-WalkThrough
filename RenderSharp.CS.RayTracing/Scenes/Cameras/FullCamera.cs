using RenderSharp.CS.RayTracing.Scenes.Rays;
using System;
using System.Numerics;

namespace RenderSharp.CS.RayTracing.Scenes.Cameras
{
    /// <summary>
    /// A <see cref="Camera"/> that can create <see cref="Ray"/>s.
    /// </summary>
    public struct FullCamera
    {
        /// <summary>
        /// The origin of the <see cref="FullCamera"/>.
        /// </summary>
        public Vector3 origin;

        /// <summary>
        /// The length of the <see cref="FullCamera"/> as rotated vector.
        /// </summary>
        public Vector3 horizontalComp;

        /// <summary>
        /// The height of the <see cref="FullCamera"/> as rotated vector.
        /// </summary>
        public Vector3 verticalComp;

        /// <summary>
        /// The position of the bottom left corner of the <see cref="FullCamera"/>.
        /// </summary>
        public Vector3 bottomLeft;

        /// <summary>
        /// Creates a new instance of the <see cref="FullCamera"/> struct.
        /// </summary>
        /// <remarks>
        /// This is a work around for constructors not working in ComputeSharp shaders.
        /// </remarks>
        /// <param name="specs">The <see cref="Camera"/> to convert to a <see cref="FullCamera"/>.</param>
        /// <param name="aspectRatio">The aspect ratio of the rendering.</param>
        /// <returns>A new <see cref="FullCamera"/> with all the specs stated.</returns>
        public static FullCamera Create(Camera specs, float aspectRatio)
        {
            float theta = (MathF.PI / 180) * specs.fov; // Convert to radians
            float height = 2 * MathF.Tan(theta / 2);
            float width = height * aspectRatio;

            
            Vector3 y = Vector3.UnitY; // Assume Positive Y is the upwards orientation for the camera.

            // Create a local coordinate system pointing the camera so w is towards the target.
            // u is 90 degrees from w around the y axis
            // v is 90 degress from both u and v
            Vector3 w = Vector3.Normalize(specs.origin - specs.target);
            Vector3 u = Vector3.Normalize(Vector3.Cross(y, w));
            Vector3 v = Vector3.Cross(w, u); // This vector is already a unit vector

            /// Create the <see cref="FullCamera"/>.
            FullCamera camera;
            camera.origin = specs.origin;
            camera.horizontalComp = width * u;
            camera.verticalComp = height * v;
            camera.bottomLeft = camera.origin - camera.horizontalComp / 2 - camera.verticalComp / 2 - w;
            return camera;
        }

        /// <summary>
        /// Creates a new <see cref="Ray"/> from the <see cref="FullCamera"/>.
        /// </summary>
        /// <param name="this">The <see cref="FullCamera"/> emitting the <see cref="Ray"/>.</param>
        /// <param name="u">The local x floating position within the image.</param>
        /// <param name="v">The local y floating position with the image.</param>
        /// <returns>The <see cref="Ray"/> from this <see cref="FullCamera"/> at (u,v).</returns>
        public static Ray CreateRay(FullCamera @this, float u, float v)
        {
            Vector3 origin = @this.origin;
            Vector3 direction = @this.bottomLeft + u * @this.horizontalComp + v * @this.verticalComp - @this.origin;
            return Ray.Create(origin, direction);
        }
    }
}
