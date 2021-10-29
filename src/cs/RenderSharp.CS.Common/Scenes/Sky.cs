using System.Numerics;

namespace RenderSharp.CS.Scenes
{
    /// <summary>
    /// A Sky for a RenderSharp scene.
    /// </summary>
    public class Sky
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Sky"/> class.
        /// </summary>
        /// <param name="albedo">The base color of the <see cref="Sky"/>.</param>
        public Sky(Vector4 albedo)
        {
            Albedo = albedo;
        }

        /// <summary>
        /// Gets or sets the base color of the <see cref="Sky"/>.
        /// </summary>
        public Vector4 Albedo { get; set; }
    }
}
