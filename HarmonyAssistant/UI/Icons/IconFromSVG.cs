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
                if (element is SvgGroup svgGroup)
                {
                    foreach (SvgElement element1 in svgGroup.Children)
                    {
                        if (element1 is SvgPath svgPath1)
                        {
                            SvgPathSegmentList svgPathSegments = svgPath1.PathData;
                            stringPath += $" {svgPathSegments}";
                        }
                    }
                }
            }

            var path = new System.Windows.Shapes.Path();
            path.Data = Geometry.Parse(stringPath);
            path.Fill = Brushes.AliceBlue;
            path.Stretch = Stretch.Uniform;

            Content = path;
        }
    }
}
