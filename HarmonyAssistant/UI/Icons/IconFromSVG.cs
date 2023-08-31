using Svg;
using Svg.Pathing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Xml;

namespace HarmonyAssistant.UI.Icons
{
    public class IconFromSVG : ContentControl
    {
        public IconFromSVG(Stream stream)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(stream);
            SvgDocument svgDoc = SvgDocument.Open(xDoc);

            string stringPath = "";
            foreach (SvgElement element in svgDoc.Children)
            {
                if (element is SvgPath svgPath)
                {
                    SvgPathSegmentList svgPathSegments = svgPath.PathData;
                    stringPath += $" {svgPathSegments}";
                }
            }

            var path = new System.Windows.Shapes.Path();
            path.Data = Geometry.Parse(stringPath);
            path.Fill = Brushes.AliceBlue;

            Content = path;
        }
    }
}
