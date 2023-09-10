using HarmonyAssistant.UI.Styles;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets
{
    public class CommonTextBlockStyled : TextBlock
    {
        public CommonTextBlockStyled()
        {
            Style = TextBlockStyles.CommonTextBlockStyle;
            //ThemeManager.AddResourceReference(this);
            //SetResourceReference(ForegroundProperty,
            //    nameof(IAppBrushes.CommonForegroundBrush));
        }
    }
}
