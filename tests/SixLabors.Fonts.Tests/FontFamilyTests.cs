// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.Fonts.Tests;

public class FontFamilyTests
{
    private readonly FontFamily[] families = SystemFonts.Families.ToArray();

    [Fact]
    public void EqualNullTests()
    {
        FontFamily fontFamily = default;
        Assert.True(fontFamily == default);
        Assert.False(fontFamily != default);

        fontFamily = this.families[0];
        Assert.True(fontFamily != default);
        Assert.False(fontFamily == default);
        Assert.False(fontFamily.Equals(default));
    }

    [Fact]
    public void EqualTests()
    {
        FontFamily fontFamily = this.families[0];
        FontFamily fontFamily2 = this.families[0];

        Assert.True(fontFamily == fontFamily2);
        Assert.False(fontFamily != fontFamily2);
        Assert.True(fontFamily.Equals(fontFamily2));
    }

    [Fact]
    public void NotEqualTests()
    {
        FontFamily fontFamily = this.families[0];
        FontFamily fontFamily2 = this.families[1];

        Assert.False(fontFamily == fontFamily2);
        Assert.True(fontFamily != fontFamily2);
        Assert.False(fontFamily.Equals(fontFamily2));
    }

    [Theory]
    [ClassData(typeof(SystemFontFamiliesTheoryData))]
    public void HasPathTests(FontFamily family)
    {
        Assert.True(family.TryGetPaths(out IEnumerable<string> familyPaths));
        Assert.NotNull(familyPaths);
        Assert.True(familyPaths.Any());

        foreach (FontStyle style in family.GetAvailableStyles())
        {
            Font font = family.CreateFont(12, style);
            Assert.True(font.TryGetPath(out string fontPath));
            Assert.Contains(fontPath, familyPaths);
        }
    }

    [Fact]
    public void Throws_FontException_CreateFont_WhenDefault()
        => Assert.Throws<FontException>(() => default(FontFamily).CreateFont(12F));

    [Fact]
    public void Throws_FontException_TryGetPath_WhenDefault()
        => Assert.Throws<FontException>(() => default(FontFamily).TryGetPaths(out IEnumerable<string> _));

    [Fact]
    public void Throws_FontException_TryGetMetrics_WhenDefault()
        => Assert.Throws<FontException>(() => default(FontFamily).TryGetMetrics(FontStyle.Regular, out FontMetrics _));

    private class SystemFontFamiliesTheoryData : TheoryData<FontFamily>
    {
        public SystemFontFamiliesTheoryData()
        {
            foreach (FontFamily family in SystemFonts.Families)
            {
                this.Add(family);
            }
        }
    }
}
