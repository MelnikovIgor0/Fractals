using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Класс, поддерживающий текущий градиент.
    /// </summary>
    public static class CurrentGradient
    {
        /// <summary>
        /// Свойство доступа к начальному цвету градиента.
        /// </summary>
        public static (int red, int green, int blue) GradientBegin;

        /// <summary>
        /// Свойство доступа к конечному цвету градиента.
        /// </summary>
        public static (int red, int green, int blue) GradientEnd;

        /// <summary>
        /// Метод выдает значение из [p1;p2] в отношении p1/p2, с возможностью
        /// реверса значения относительно центра отрезка.
        /// </summary>
        /// <param name="val1">Значение начала отрезка.</param>
        /// <param name="val2">Значение конца отрезка.</param>
        /// <param name="p1">Значение числителя.</param>
        /// <param name="p2">значение знаменателя.</param>
        /// <param name="rev">Флаг, нужно ли развернуть отрезок.</param>
        /// <returns>Целое число, значение из [p1;p2].</returns>
        private static int GetPart(int val1, int val2, int p1, int p2, bool rev)
        {
            if (!rev)
            {
                if (p2 == 0) return val1;
                double part = (double)(p1) / (double)(p2);
                return (int)((double)val1 * part + (double)val2 * (1.0 - part));
            }
            else
            {
                if (p2 == 0) return val1;
                double part = (double)(p1) / (double)(p2);
                return (int)((double)val2 * part + (double)val1 * (1.0 - part));
            }
        }

        /// <summary>
        /// Метод возвращает кисть, цвет которой построен на линейном
        /// градиенте относительно начального и конечного цвета.
        /// </summary>
        /// <param name="p1">Значение числителя.</param>
        /// <param name="p2">Значение знаменателя.</param>
        /// <param name="rev">Флаг, нужно ли развернуть градиент.</param>
        /// <returns>Кисть, цвет которой построен на линейном градиенте.</returns>
        public static System.Windows.Media.SolidColorBrush GetBrush(int p1, int p2, bool rev)
        {
            return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(
                (byte)GetPart(GradientBegin.red, GradientEnd.red, p1, p2, rev),
                (byte)GetPart(GradientBegin.green, GradientEnd.green, p1, p2, rev),
                (byte)GetPart(GradientBegin.blue, GradientEnd.blue, p1, p2, rev)
                ));
        }

        /// <summary>
        /// Статический конструктор, задает начальный градиент черный - черный.
        /// </summary>
        static CurrentGradient()
        {
            GradientBegin = (0, 0, 0);
            GradientEnd = (0, 0, 0);
        }
    }
}
