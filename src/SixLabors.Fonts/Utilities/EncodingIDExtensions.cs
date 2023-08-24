// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Text;
using SixLabors.Fonts.WellKnownIds;

namespace SixLabors.Fonts.Utilities
{
    /// <summary>
    /// Converts encoding ID to TextEncoding
    /// </summary>
    internal static class EncodingIDExtensions
    {
        /// <summary>
        /// Converts encoding ID to TextEncoding
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the encoding for this encoding ID</returns>
        public static Encoding AsEncoding(this EncodingIDs id)
        {
            switch (id)
            {
                case EncodingIDs.Unicode11:
                case EncodingIDs.Unicode2:
                    return Encoding.BigEndianUnicode;
                default:
                    return Encoding.UTF8;
            }
        }
    }
}
