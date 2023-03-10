// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Numerics;
using SixLabors.Fonts.Unicode;

namespace SixLabors.Fonts
{
    /// <summary>
    /// A glyphs layout and location
    /// </summary>
    internal readonly struct GlyphLayout
    {
        internal GlyphLayout(
            Glyph glyph,
            Vector2 location,
            float ascender,
            float descender,
            float linegap,
            float lineHeight,
            float width,
            float height,
            bool isStartOfLine)
        {
            this.Glyph = glyph;
            this.CodePoint = glyph.GlyphMetrics.CodePoint;
            this.Location = location;
            this.Ascender = ascender;
            this.Descender = descender;
            this.LineGap = linegap;
            this.LineHeight = lineHeight;
            this.Width = width;
            this.Height = height;
            this.IsStartOfLine = isStartOfLine;
        }

        /// <summary>
        /// Gets the glyph.
        /// </summary>
        public Glyph Glyph { get; }

        /// <summary>
        /// Gets the codepoint represented by this glyph.
        /// </summary>
        public CodePoint CodePoint { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        public Vector2 Location { get; }

        /// <summary>
        /// Gets the ascender
        /// </summary>
        public float Ascender { get; }

        /// <summary>
        /// Gets the ascender
        /// </summary>
        public float Descender { get; }

        /// <summary>
        /// Gets the lie gap
        /// </summary>
        public float LineGap { get; }

        /// <summary>
        /// Gets the line height of the glyph.
        /// </summary>
        public float LineHeight { get; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// Gets a value indicating whether this glyph is the first glyph on a new line.
        /// </summary>
        public bool IsStartOfLine { get; }

        /// <summary>
        /// Gets a value indicating whether the glyph represents a whitespace character.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsWhiteSpace() => GlyphMetrics.ShouldRenderWhiteSpaceOnly(this.CodePoint);

        internal FontRectangle BoundingBox(float dpi)
        {
            // TODO: GlyphMetrics can do this.
            FontRectangle box = this.Glyph.BoundingBox(this.Location * dpi, dpi);
            if (this.IsWhiteSpace())
            {
                box = new FontRectangle(box.X, box.Y, this.Width * dpi, box.Height);
            }

            return box;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string s = this.IsStartOfLine ? "@ " : string.Empty;
            string ws = this.IsWhiteSpace() ? "!" : string.Empty;
            Vector2 l = this.Location;
            return $"{s}{ws}{this.CodePoint.ToDebuggerDisplay()} {l.X},{l.Y} {this.Width}x{this.Height}";
        }
    }
}
