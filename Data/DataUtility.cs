using Dalamud.Utility;
using Lumina.Text;

namespace Penumbra.GameData.Data;

/// <summary> Some utility functions for data containers. </summary>
public static class DataUtility
{
    /// <summary> Convert a given SeString to title case and intern it. </summary>
    /// <param name="s"> The string to convert. </param>
    /// <param name="article"> The article byte indicates whether the name is used with an article, in which case the capitalization is already done right. </param>
    /// <returns> The interned string in title case. </returns>
    public static string ToTitleCaseExtended(SeString s, sbyte article)
    {
        if (article == 1)
            return string.Intern(s.ToDalamudString().ToString());

        var sb = new StringBuilder(s.ToDalamudString().ToString());
        var lastSpace = true;
        for (var i = 0; i < sb.Length; ++i)
        {
            if (sb[i] == ' ')
            {
                lastSpace = true;
            }
            else if (lastSpace)
            {
                lastSpace = false;
                sb[i] = char.ToUpperInvariant(sb[i]);
            }
        }

        return string.Intern(sb.ToString());
    }

    /// <summary> Approximate the memory a dictionary needs </summary>
    /// <param name="tupleSize"> The approximate size of the KeyValuePair. </param>
    /// <param name="count"> The number of entries. </param>
    public static int DictionaryMemory(int tupleSize, int count)
        => 64 + (tupleSize + 16) * count;
}
