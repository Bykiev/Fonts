// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Diagnostics;

namespace SixLabors.Fonts.Tables.AdvancedTypographic
{
    [DebuggerDisplay("Tag: {Tag}, Enabled: {Enabled}")]
    internal struct TagEntry
    {
        public TagEntry(Tag tag, bool enabled)
        {
            this.Tag = tag;
            this.Enabled = enabled;
        }

        public bool Enabled { get; set; }

        public Tag Tag { get; }
    }
}
