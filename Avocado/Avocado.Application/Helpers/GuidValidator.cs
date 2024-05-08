
namespace Avocado.Application.Helpers
{
    using System;
    using System.Text.RegularExpressions;

    public static class GuidValidator
    {
        internal static bool IsGUID(Guid expression)
        {
            if (expression != null)
            {
                Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
                return guidRegEx.IsMatch(expression.ToString());
            }
            return false;
        }
    }
}
