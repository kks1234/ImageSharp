// Copyright (c) Six Labors and contributors.
// Licensed under the GNU Affero General Public License, Version 3.

using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Advanced
{
    /// <summary>
    /// A visitor to implement a double-dispatch pattern in order to apply pixel-specific operations
    /// on non-generic <see cref="Image"/> instances.
    /// </summary>
    public interface IImageVisitor
    {
        /// <summary>
        /// Provides a pixel-specific implementation for a given operation.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <typeparam name="TPixel">The pixel type.</typeparam>
        void Visit<TPixel>(Image<TPixel> image)
            where TPixel : unmanaged, IPixel<TPixel>;
    }
}
