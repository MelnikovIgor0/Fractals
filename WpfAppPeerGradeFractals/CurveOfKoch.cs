using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс кривой Коха, наследованный от фрактала.
    /// </summary>
    public sealed class CurveOfKoch : Fractal
    {
        /// <summary>
        /// Конструктор кривой Коха.
        /// </summary>
        /// <param name="currentCanvas">Холст, на котором будет рисоваться фрактал.</param>
        public CurveOfKoch(System.Windows.Controls.Canvas currentCanvas)
        {
            canvas = currentCanvas;
        }

        /// <summary>
        /// Метод находит конец нормированной ортогонали к середине вектора pq, такой, что [pq, ортогональ] > 0,
        /// а нормированная длина ортогонали составляет 1/3 длины pq.
        /// </summary>
        /// <param name="p">Кортеж, задающий точку p.</param>
        /// <param name="q">Кортеж, задающий точку q.</param>
        /// <returns>Кортеж, задающий искомую точку.</returns>
        private (double, double) FindMediumPoint((double x, double y) p, (double x, double y) q)
        {
            double a = p.y - q.y;
            double b = q.x - p.x;
            double c = -a * p.x - b * p.y;
            double xm = (p.x + q.x) / 2, ym = (p.y + q.y) / 2;
            double dst = Math.Sqrt((p.x - q.x) * (p.x - q.x) + (p.y - q.y) * (p.y - q.y)) / 3;
            double multiplier = dst / Math.Sqrt(a * a + b * b);
            return (xm - a * multiplier, ym - b * multiplier);
        }

        /// <summary>
        /// Метод рисует кривую Коха.
        /// </summary>
        /// <param name="data">Массив вещественных чисел, параметры для отрисовки фрактала.
        /// data[0] - текущая итерация отрисовки фрактала.
        /// data[1] - X координата первой точки.
        /// data[2] - Y координата первой точки.
        /// data[3] - X координата второй точки.
        /// data[4] - Y координата второй точки.
        /// data[5] - лимит количества итераций при отрисовке фрактала.
        /// data[6] - последняя итерация, на которой было выгибание прямой.</param>
        public override void DrawFractal(params double[] data)
        {
            int currentIteration = (int)data[0], maxIteration = (int)data[5], lastChange = (int)data[6];
            double x1 = data[1], y1 = data[2], x2 = data[3], y2 = data[4];
            if (currentIteration >= maxIteration)
            {
                DrawLine(canvas, (int)x1, (int)y1, (int)x2, (int)y2, 
                    CurrentGradient.GetBrush(maxIteration - lastChange, maxIteration, false));
                return;
            }
            double xm1 = (x1 + x1 + x2) / 3, ym1 = (y1 + y1 + y2) / 3,
                xm2 = (x1 + x2 + x2) / 3, ym2 = (y1 + y2 + y2) / 3;
            (double x, double y) nextPoint = FindMediumPoint((x1, y1), (x2, y2));
            DrawFractal(currentIteration + 1, x1, y1, xm1, ym1, maxIteration, lastChange);
            DrawFractal(currentIteration + 1, xm2, ym2, x2, y2, maxIteration, lastChange);
            DrawFractal(currentIteration + 1, xm1, ym1, nextPoint.x, nextPoint.y, maxIteration, currentIteration + 1);
            DrawFractal(currentIteration + 1, nextPoint.x, nextPoint.y, xm2, ym2, maxIteration, currentIteration + 1);
        }
    }
}
