

using System;
using Wpf.Ui.Controls;

namespace FluentKursovayaAvtoparkA.ControlsLookup;

[AttributeUsage(AttributeTargets.Class)]
class GalleryPageAttribute : Attribute
{
    public string Description { get; }
    public SymbolRegular Icon { get; }

    public GalleryPageAttribute(string description, SymbolRegular icon)
    {
        Description = description;
        Icon = icon;
    }
}
