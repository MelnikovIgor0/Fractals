using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Абстрактный класс фрактала, от которого создаются все виды фракталов.
    /// </summary>
    public abstract class Fractal
    {
        /// <summary>
        /// Свойство максимальной глубины прорисовки фрактала.
        /// </summary>
        public static int MaxRecursionDepth { get; } = 14;
        protected System.Windows.Controls.Canvas canvas;

        /// <summary>
        /// Метод отрисовки линии с указанными координатами, указанным цветом, на указанном холсте.
        /// </summary>
        /// <param name="canvas">Холст, на котором рисуется линия.</param>
        /// <param name="x1">X координата первой точки.</param>
        /// <param name="y1">Y координата первой точки.</param>
        /// <param name="x2">X координата второй точки.</param>
        /// <param name="y2">Y координата второй точкию</param>
        /// <param name="brush">Кисть, которой рисуется линия.</param>
        public void DrawLine(System.Windows.Controls.Canvas canvas, int x1, int y1, int x2, int y2, 
            System.Windows.Media.Brush brush)
        {
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();
            line.Stroke = brush;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            line.StrokeThickness = 1;
            canvas.Children.Add(line);
        }

        /// <summary>
        /// Метод отрисовки прямоугольника с указанными координатами, указанным цветом на указанном холсте.
        /// </summary>
        /// <param name="canvas">Холст, на котором рисуется прямоугольник.</param>
        /// <param name="x1">X координата первого угла.</param>
        /// <param name="y1">Y координата первого угла.</param>
        /// <param name="x2">X координата второго угла.</param>
        /// <param name="y2">Y координата второго угла.</param>
        /// <param name="brush">КистьЮ которой рисуется прямоугольник.</param>
        public void DrawRectangle(System.Windows.Controls.Canvas canvas, int x1, int y1, int x2, int y2,
            System.Windows.Media.Brush brush)
        {
            System.Windows.Shapes.Polygon rect = new System.Windows.Shapes.Polygon();
            rect.Points.Add(new System.Windows.Point(x1, y1));
            rect.Points.Add(new System.Windows.Point(x1, y2));
            rect.Points.Add(new System.Windows.Point(x2, y2));
            rect.Points.Add(new System.Windows.Point(x2, y1));
            rect.Fill = brush;
            canvas.Children.Add(rect);
        }

        /// <summary>
        /// Абстрактный метод отрисовки фрактала.
        /// </summary>
        /// <param name="data">Список вещественных параметров для отрисовки фрактала.</param>
        public abstract void DrawFractal(params double[] data);
    }
}
