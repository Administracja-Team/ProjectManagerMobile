
using FluentIcons.Maui;

namespace ProjectManagerMobile.Utilities
{
    public class FlyoutItemIconFont : FlyoutItem
    {
        public static readonly BindableProperty IconGlyphProperty =
            BindableProperty.Create(nameof(IconGlyphProperty), typeof(FluentIcons.Common.Icon), typeof(FlyoutItemIconFont), FluentIcons.Common.Icon.Accessibility);
        public FluentIcons.Common.Icon IconGlyph
        {
            get { return (FluentIcons.Common.Icon)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }
    }
}
