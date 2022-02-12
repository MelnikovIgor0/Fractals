using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс фрактала множества Кантора, наследованный от абстрактного класса.
    /// </summary>
    public sealed class CantorSet : Fractal
    {
        /// <summary>
        /// Конструктор множества Кантора.
        /// </summary>
        /// <param name="currentCanvas">Холст, на котором рисуется фрактал.</param>
        public CantorSet(System.Windows.Controls.Canvas currentCanvas)
        {
            canvas = currentCanvas;
        }

        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="data">Множество вещественных чисел, параметры отрисовки фрактала.
        /// data[0] - номер итерации отрисовки фрактала.
        /// data[1] - X координата начала сегмента.
        /// data[2] - X координата конца сегмента.
        /// data[3] - Y координата ыерха сегмента.
        /// data[4] - отступ между итерациями фрактала.
        /// data[5] - высота сегмента фрактала.
        /// data[6] - лимит итераций отрисовки фрактала.
        /// data[7] - сдвиг по X координате.
        /// data[8] - сдвиг по Y координате.</param>
        public override void DrawFractal(params double[] data)
        {
            int currentIteration = (int)data[0], maxIteration = (int)data[6];
            if (currentIteration >= maxIteration) return;
            double segmentBegin = data[1], segmentEnd = data[2], coordY = data[3], indent = data[4], height = data[5];
            DrawRectangle(canvas, (int)segmentBegin + (int)data[7], (int)coordY + (int)data[8], 
                (int)segmentEnd + (int)data[7], (int)(coordY + height) + (int)data[8],
                CurrentGradient.GetBrush(currentIteration, maxIteration, true));
            double m1 = (segmentBegin + segmentBegin + segmentEnd) / 3;
            double m2 = (segmentBegin + segmentEnd + segmentEnd) / 3;
            DrawFractal(currentIteration + 1, segmentBegin, m1, coordY + height + indent, indent, height,
                maxIteration, data[7], data[8]);
            DrawFractal(currentIteration + 1, m2, segmentEnd, coordY + height + indent, indent, height,
                maxIteration, data[7], data[8]);
        }
    }
}
