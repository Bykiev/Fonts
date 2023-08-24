// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System;

namespace SixLabors.Fonts
{
    /// <summary>
    /// The font styles
    /// </summary>
    [Flags]
    public enum FontStyle
    {
        /// <summary>
        /// Regular
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Bold
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Italic
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Bold and Italic
        /// </summary>
        BoldItalic = 3,

        // TODO: Not yet supported
        // Underline = 4,
        // Strikeout = 8
    }
}
