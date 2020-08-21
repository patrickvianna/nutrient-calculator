using System.Globalization;
using System.Linq;
using System.Text;

namespace NutrientCalculator.App._utils
{
    public static class StringUtil
    {
        public static string RemoveAccents(this string str)
        {
            return new string(str
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
