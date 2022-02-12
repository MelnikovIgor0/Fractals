using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс дерева Пифагора, наследованный от фрактала.
    /// </summary>
    public sealed class PifagorTree: Fractal
    {
        /// <summary>
        /// Конструктор дерева Пифагора.
        /// </summary>
        /// <param name="currentCanvas">Холст, на котором рисуется фрактал.</param>
        public PifagorTree(System.Windows.Controls.Canvas currentCanvas)
        {
            canvas = currentCanvas;
        }

        /// <summary>
        /// Метод рисует дерево Пифагора по указанным параметрам.
        /// </summary>
        /// <param name="data">
        /// data[0] - X координата предыдущей итерации.
        /// data[1] - Y координата предыдущей итерации.
        /// data[2] - X координата текущей точки.
        /// data[3] - Y координата текущей точки.
        /// data[4] - количество оставшихся итераций отрисовки фрактала.
        /// data[5] - угол отклонения последней прямой фрактала.
        /// data[6] - угол отклонения левого дочернего элемента.
        /// data[7] - угол отклонения правого дочернего элемента.
        /// data[8] - длина линии на данной итерации.
        /// data[9] - множитель длины дочерних элементов.
        /// data[10] - лимит количества итераций при построении дерева.</param>
        public override void DrawFractal(params double[] data)
        {
            int unusedIterations = (int)data[4];
            if (unusedIterations <= 0) return;
            double lastX = data[0], lastY = data[1], currentX = data[2], currentY = data[3];
            DrawLine(canvas, (int)lastX, (int)lastY, (int)currentX, (int)currentY, CurrentGradient.GetBrush(
                (int)(data[4] - 1), (int)(data[10] - 1), false));
            double currentAngle = data[5], leftAngle = data[6], rightAngle = data[7];
            double segmentLength = data[8], multiplier = data[9];
            double x1 = currentX + segmentLength * multiplier * Math.Cos(currentAngle + leftAngle);
            double y1 = currentY + segmentLength * multiplier * Math.Sin(currentAngle + leftAngle);
            double x2 = currentX + segmentLength * multiplier * Math.Cos(currentAngle - rightAngle);
            double y2 = currentY + segmentLength * multiplier * Math.Sin(currentAngle - rightAngle);
            DrawFractal(currentX, currentY, x1, y1, unusedIterations - 1, currentAngle + leftAngle,
                leftAngle, rightAngle, segmentLength * multiplier, multiplier, data[10]);
            DrawFractal(currentX, currentY, x2, y2, unusedIterations - 1, currentAngle - rightAngle,
                leftAngle, rightAngle, segmentLength * multiplier, multiplier, data[10]);
        }
    }
}
