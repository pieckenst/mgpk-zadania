

using System;
using System.Linq;
using System.Reflection;

namespace FluentKursovayaAvtoparkA.Helpers;

internal sealed class NameToPageTypeConverter
{
    private static readonly Type[] PageTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.Namespace?.StartsWith("FluentKursovayaAvtoparkA.Views.Pages") ?? false)
        .ToArray();

    public static Type? Convert(string pageName)
    {
        pageName = pageName.Trim().ToLower() + "page";

        return PageTypes.FirstOrDefault(singlePageType => singlePageType.Name.ToLower() == pageName);
    }
}
