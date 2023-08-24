// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Reflection;

namespace SixLabors.Fonts.Tests;

internal static class TestEnvironment
{
    private const string SixLaborsSolutionFileName = "SixLabors.Fonts.sln";

    private const string UnicodeTestDataRelativePath = @"tests\UnicodeTestData\";

    private static readonly Lazy<string> SolutionDirectoryFullPathLazy = new(GetSolutionDirectoryFullPathImpl);

    internal static string SolutionDirectoryFullPath => SolutionDirectoryFullPathLazy.Value;

    /// <summary>
    /// Gets the correct full path to the Unicode TestData directory.
    /// </summary>
    internal static string UnicodeTestDataFullPath => GetFullPath(UnicodeTestDataRelativePath);

    private static string GetSolutionDirectoryFullPathImpl()
    {
        string assemblyLocation = Path.GetDirectoryName(new Uri(typeof(TestEnvironment).GetTypeInfo().Assembly.CodeBase).LocalPath);

        var assemblyFile = new FileInfo(assemblyLocation);

        DirectoryInfo directory = assemblyFile.Directory;

        while (!directory.EnumerateFiles(SixLaborsSolutionFileName).Any())
        {
            try
            {
                directory = directory.Parent;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Unable to find SixLabors solution directory from {assemblyLocation} because of {ex.GetType().Name}!",
                    ex);
            }

            if (directory == null)
            {
                throw new Exception($"Unable to find SixLabors solution directory from {assemblyLocation}!");
            }
        }

        return directory.FullName;
    }

    private static string GetFullPath(string relativePath) =>
        Path.Combine(SolutionDirectoryFullPath, relativePath)
        .Replace('\\', Path.DirectorySeparatorChar);
}
