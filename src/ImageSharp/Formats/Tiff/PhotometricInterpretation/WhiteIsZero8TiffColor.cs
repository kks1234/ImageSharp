// <copyright file="WhiteIsZero8TiffColor.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Formats.Tiff
{
    using System.Runtime.CompilerServices;
    using ImageSharp;

    /// <summary>
    /// Implements the 'WhiteIsZero' photometric interpretation (optimised for 8-bit  grayscale images).
    /// </summary>
    internal static class WhiteIsZero8TiffColor
    {
        /// <summary>
        /// Decodes pixel data using the current photometric interpretation.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <param name="data">The buffer to read image data from.</param>
        /// <param name="pixels">The image buffer to write pixels to.</param>
        /// <param name="left">The x-coordinate of the left-hand side of the image block.</param>
        /// <param name="top">The y-coordinate of the  top of the image block.</param>
        /// <param name="width">The width of the image block.</param>
        /// <param name="height">The height of the image block.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Decode<TColor>(byte[] data, PixelAccessor<TColor> pixels, int left, int top, int width, int height)
            where TColor : struct, IPixel<TColor>
        {
            TColor color = default(TColor);

            uint offset = 0;

            for (int y = top; y < top + height; y++)
            {
                for (int x = left; x < left + width; x++)
                {
                    byte intensity = (byte)(255 - data[offset++]);
                    color.PackFromBytes(intensity, intensity, intensity, 255);
                    pixels[x, y] = color;
                }
            }
        }
    }
}
