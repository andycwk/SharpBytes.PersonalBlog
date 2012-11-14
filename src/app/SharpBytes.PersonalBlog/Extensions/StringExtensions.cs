namespace SharpBytes.PersonalBlog.Extensions
{
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        private static readonly Regex PunctuationPattern = new Regex(@"\W+", RegexOptions.Compiled);
        private static readonly Regex WhitespacePattern = new Regex(@"\s+", RegexOptions.Compiled);
         public static string Slug(this string original)
         {
             return RemoveDiacritics(Trim(RemoveWhitespace(RemovePunctuation(original)))).ToLowerInvariant();
         }

         // Taken from http://blogs.msdn.com/michkap/archive/2007/05/14/2629747.aspx
         private static string RemoveDiacritics(string text)
         {
             string normalized = text.Normalize(NormalizationForm.FormD);
             var builder = new StringBuilder();

             foreach (var t in normalized)
             {
                 var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(t);
                 if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                 {
                     builder.Append(t);
                 }
             }
             return (builder.ToString().Normalize(NormalizationForm.FormC));
         }

         private static string Trim(string text)
         {
             return text.Trim('-');
         }

         private static string RemoveWhitespace(string text)
         {
             return WhitespacePattern.Replace(text, "-");
         }

         private static string RemovePunctuation(string text)
         {
             return PunctuationPattern.Replace(text, " ");
         }

    }
}