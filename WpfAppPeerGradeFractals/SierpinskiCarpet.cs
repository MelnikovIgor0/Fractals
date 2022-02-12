using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс ковра Серпинского, наследованный от фрактала.
    /// </summary>
    public sealed class SierpinskiCarpet : Fractal
    {
        /// <summary>
        /// Конструктор ковра Серпинского.
        /// </summary>
        /// <param name="currentCanvas">Холст, на котором должен быть нарисован фрактал.</param>
        public SierpinskiCarpet(System.Windows.Controls.Canvas currentCanvas)
        {
            canvas = currentCanvas;
        }

        /// <summary>
        /// Метод отрисовки ковра Серпинского.
        /// </summary>
        /// <param name="data">Массив вещественных чисел, параметров отрисовки ковра.
        /// data[0] - текущая итерация отрисовки ковра.
        /// data[1] - X координата первого угла ковра.
        /// data[2] - Y координата первого угла ковра.
        /// data[3] - X координата второго угла ковра.
        /// data[4] - Y координата второго угла ковра.
        /// data[5] - лимит количества итераций отрисовки фрактала.</param>
        public void DrawFractalRec(params double[] data)
        {
            int currentIteration = (int)data[0], maxIteration = (int)data[5];
            if (currentIteration >= maxIteration) return;
            double x1 = data[1], y1 = data[2], x2 = data[3], y2 = data[4];
            double xm1 = (x1 + x1 + x2) / 3, xm2 = (x1 + x2 + x2) / 3, 
                ym1 = (y1 + y1 + y2) / 3, ym2 = (y1 + y2 + y2) / 3;
            if (xm2 - xm1 < 0.5 || ym2 - ym1 < 0.5) return;
            int holesize = ((int)xm2 - (int)xm1) / 2;
            DrawRectangle(canvas, (int)xm1 - holesize, (int)ym1 - holesize, (int)xm2 + holesize, (int)ym2 + holesize,
                CurrentGradient.GetBrush(currentIteration + 1, maxIteration, true));
            DrawRectangle(canvas, (int)xm1, (int)ym1, (int)xm2, (int)ym2, System.Windows.Media.Brushes.White);
            DrawFractalRec(currentIteration + 1, (int)x1, (int)y1, (int)xm1, (int)ym1, maxIteration);
            DrawFractalRec(currentIteration + 1, (int)xm1, (int)y1, (int)xm2, (int)ym1, maxIteration);
            DrawFractalRec(currentIteration + 1, (int)xm2, (int)y1, (int)x2, (int)ym1, maxIteration);

            DrawFractalRec(currentIteration + 1, (int)x1, (int)ym1, (int)xm1, (int)ym2, maxIteration);
            DrawFractalRec(currentIteration + 1, (int)xm2, (int)ym1, (int)x2, (int)ym2, maxIteration);

            DrawFractalRec(currentIteration + 1, (int)x1, (int)ym2, (int)xm1, (int)y2, maxIteration);
            DrawFractalRec(currentIteration + 1, (int)xm1, (int)ym2, (int)xm2, (int)y2, maxIteration);
            DrawFractalRec(currentIteration + 1, (int)xm2, (int)ym2, (int)x2, (int)y2, maxIteration);
        }

        /// <summary>
        /// Главный метод отрисовки фрактала.
        /// </summary>
        /// <param name="data">Данные для отрисовки фрактала (два угла).</param>
        public override void DrawFractal(params double[] data)
        {
            DrawRectangle(canvas, (int)data[1], (int)data[2], (int)data[3], (int)data[4], 
                CurrentGradient.GetBrush(0, 1, true));
            DrawFractalRec(data);
        }
    }
}
