using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets
{
    public class CommonTextBoxStyled : TextBox
    {
        public CommonTextBoxStyled()
        {
            Style = TextBlockStyles.CommonTextBlockStyle;
            ThemeManager.AddResourceReference(this);
            SetResourceReference(ForegroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
        }
    }
}
