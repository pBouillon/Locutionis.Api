using System.Globalization;
using System.Net;
using System.Text;

namespace Locutionis.Api.Extensions;

public static class StringExtensions
{
    public static string WithoutDiacritics(this string content)
    {
        content = WebUtility.HtmlDecode(content);

        var formD = content.Normalize(NormalizationForm.FormD);

        var sb = new StringBuilder();

        foreach (char ch in formD)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);

            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }

        return sb
            .ToString()
            .Normalize(NormalizationForm.FormC);
    }
}