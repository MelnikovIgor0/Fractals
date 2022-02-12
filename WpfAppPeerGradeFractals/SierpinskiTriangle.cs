using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс треугольника Серпинского, наследованный от фрактала.
    /// </summary>
    public sealed class SierpinskiTriangle : Fractal
    {
        /// <summary>
        /// Конструктор треугольника Серпинского.
        /// </summary>
        /// <param name="currentCanvas">Холст, на котором должен быть отрисован фрактал.</param>
        public SierpinskiTriangle(System.Windows.Controls.Canvas currentCanvas)
        {
            canvas = currentCanvas;
        }

        /// <summary>
        /// Метод отрисовки треугольника Серпинского.
        /// </summary>
        /// <param name="data">Вещественные числа, данные для отрисовки фрактала.
        /// data[0] - текущая итерация отрисовки фрактала.
        /// data[1] - X координата первой точки.
        /// data[2] - Y координата первой точки.
        /// data[3] - X координата второй точки.
        /// data[4] - Y координата второй точки.
        /// data[5] - X координата третьей точки.
        /// data[6] - Y координата третьей точки.
        /// data[7] - лимит количества итераций при отрисовке фрактала.</param>
        public override void DrawFractal(params double[] data)
        {
            int currentIteration = (int)data[0], maxIteration = (int)data[7];
            if (currentIteration >= maxIteration) return;
            double x1 = data[1], y1 = data[2], x2 = data[3], y2 = data[4], x3 = data[5], y3 = data[6];
            double xm1 = (x2 + x3) / 2, ym1 = (y2 + y3) / 2, xm2 = (x1 + x3) / 2, ym2 = (y1 + y3) / 2,
                xm3 = (x1 + x2) / 2, ym3 = (y1 + y2) / 2;
            DrawFractal(currentIteration + 1, x1, y1, xm2, ym2, xm3, ym3, maxIteration);
            DrawFractal(currentIteration + 1, x2, y2, xm1, ym1, xm3, ym3, maxIteration);
            DrawFractal(currentIteration + 1, x3, y3, xm1, ym1, xm2, ym2, maxIteration);
            DrawLine(canvas, (int)x1, (int)y1, (int)x2, (int)y2, CurrentGradient.GetBrush(currentIteration,
                maxIteration - 1, true));
            DrawLine(canvas, (int)x1, (int)y1, (int)x3, (int)y3, CurrentGradient.GetBrush(currentIteration,
                maxIteration - 1, true));
            DrawLine(canvas, (int)x3, (int)y3, (int)x2, (int)y2, CurrentGradient.GetBrush(currentIteration,
                maxIteration - 1, true));
        }
    }
}
