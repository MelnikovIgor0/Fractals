using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private (int X, int Y) shift;


        /// <summary>
        /// Конструктор окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            sliderRecursionDepth.Value = 5;
            sliderSize.Value = 0.2;
            sliderPart.Value = 0.7;
            sliderLeftAngle.Value = Math.PI / 4;
            sliderRightAngle.Value = Math.PI / 4;
            sliderRecursionDepth.Visibility = Visibility.Hidden;
            sliderSize.Visibility = Visibility.Hidden;
            sliderPart.Visibility = Visibility.Hidden;
            sliderLeftAngle.Visibility = Visibility.Hidden;
            sliderRightAngle.Visibility = Visibility.Hidden;
            textBlockRecursion.Visibility = Visibility.Hidden;
            textBlockSize.Visibility = Visibility.Hidden;
            textBlockElongation.Visibility = Visibility.Hidden;
            textBlockLeft.Visibility = Visibility.Hidden;
            textBlockRight.Visibility = Visibility.Hidden;
            buttonGradient.Visibility = Visibility.Hidden;
            buttonSave.Visibility = Visibility.Hidden;
            CurrentGradient.GradientBegin.red = 255;
            CurrentGradient.GradientBegin.green = 0;
            CurrentGradient.GradientBegin.blue = 0;
            CurrentGradient.GradientEnd.red = 0;
            CurrentGradient.GradientEnd.green = 0;
            CurrentGradient.GradientEnd.blue = 255;
            shift = (0, 0);
        }

        /// <summary>
        /// Метод создает объект дерева Пифагора и рисует его.
        /// </summary>
        public void DrawPifagorTree(Canvas canvas)
        {
            try
            {
                theCanvas.Children.Clear();
                new PifagorTree(canvas).DrawFractal(this.ActualWidth / 2 + shift.X,
                this.ActualHeight - 250 + shift.Y, this.ActualWidth / 2 + shift.X, this.ActualHeight - 250 -
                (int)(350.0 * sliderSize.Value) + shift.Y, (int)(1 + (double)sliderRecursionDepth.Value *
                0.9), -Math.PI / 2, sliderLeftAngle.Value, sliderRightAngle.Value,
                (int)(350.0 * sliderSize.Value), sliderPart.Value,
                (int)(1 + sliderRecursionDepth.Value * 0.9));
                theCanvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Метод создает объект кривой Коха и рисует ее.
        /// </summary>
        public void DrawCurveOfKoch(Canvas canvas)
        {
            try
            {
                theCanvas.Children.Clear();
                new CurveOfKoch(canvas).DrawFractal(0, this.ActualWidth / 2 + shift.X - 1000
                    * sliderSize.Value, this.ActualHeight / 2 + shift.Y, this.ActualWidth / 2 + shift.X + 1000 *
                    sliderSize.Value, this.ActualHeight / 2 + shift.Y, (int)(sliderRecursionDepth.Value / 2), 0);
                theCanvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Метод создает объект ковра Серпинского и рисует его.
        /// </summary>
        public void DrawSierpinskeCarpet(Canvas canvas)
        {
            try
            {
                theCanvas.Children.Clear();
                new SierpinskiCarpet(canvas).DrawFractal(0,
                    this.ActualWidth / 2 - 600 * sliderSize.Value + shift.X, this.ActualHeight / 2 - 80 - 600
                    * sliderSize.Value + shift.Y, this.ActualWidth / 2 + 600 * sliderSize.Value + shift.X,
                    this.ActualHeight / 2 - 80 + 600 * sliderSize.Value + shift.Y,
                    (int)((double)sliderRecursionDepth.Value * 0.45));
                theCanvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Метод создает объект треугольника Серпинского и рисует его.
        /// </summary>
        public void DrawSierpinskiTriangle(Canvas canvas)
        {
            try
            {
                theCanvas.Children.Clear();
                int triangleHeight = (int)(1200.0 * sliderSize.Value * Math.Sqrt(3) / 2.0);
                new SierpinskiTriangle(canvas).DrawFractal(0,
                    this.ActualWidth / 2 + shift.X, this.ActualHeight / 2 - triangleHeight / 2 + shift.Y,
                    this.ActualWidth / 2 - 600 * sliderSize.Value + shift.X, this.ActualHeight / 2 +
                    triangleHeight / 2 + shift.Y, this.ActualWidth / 2 + 600 * sliderSize.Value + shift.X,
                    this.ActualHeight / 2 + triangleHeight / 2 + shift.Y,
                    (int)((double)sliderRecursionDepth.Value * 0.6 + 1));
                theCanvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
}

        /// <summary>
        /// Метод создает объект множества Кантора и рисует его.
        /// </summary>
        public void DrawCantorSet(Canvas canvas)
        {
            try
            {
                theCanvas.Children.Clear();
                new CantorSet(canvas).DrawFractal(0, this.ActualWidth / 2 - 600
                    * sliderSize.Value, this.ActualWidth / 2 + 600 * sliderSize.Value, 100,
                    (int)(sliderPart.Value * 60), 20, (int)(sliderRecursionDepth.Value / 2 + 1), shift.X, shift.Y);
                theCanvas.UpdateLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Метод устанавливает на окне только те регуляторы фракталов, которые необходимы для дерева Пифагора.
        /// </summary>
        public void SetSlidersForPifagor()
        {
            this.buttonGradient.Visibility = Visibility.Visible;
            this.buttonSave.Visibility = Visibility.Visible;
            this.sliderRecursionDepth.Visibility = Visibility.Visible;
            this.textBlockRecursion.Visibility = Visibility.Visible;
            this.sliderLeftAngle.Visibility = Visibility.Visible;
            this.sliderRightAngle.Visibility = Visibility.Visible;
            this.sliderSize.Visibility = Visibility.Visible;
            this.sliderPart.Visibility = Visibility.Visible;
            this.textBlockLeft.Visibility = Visibility.Visible;
            this.textBlockRight.Visibility = Visibility.Visible;
            this.textBlockSize.Visibility = Visibility.Visible;
            this.textBlockElongation.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод устанавливает на окне только те регуляторы фракталов, которые необходимы для кривой Коха.
        /// </summary>
        public void SetSlidersForCurveOfKoch()
        {
            this.buttonGradient.Visibility = Visibility.Visible;
            this.buttonSave.Visibility = Visibility.Visible;
            this.sliderRecursionDepth.Visibility = Visibility.Visible;
            this.textBlockRecursion.Visibility = Visibility.Visible;
            this.sliderLeftAngle.Visibility = Visibility.Hidden;
            this.sliderRightAngle.Visibility = Visibility.Hidden;
            this.sliderPart.Visibility = Visibility.Hidden;
            this.sliderSize.Visibility = Visibility.Visible;
            this.textBlockLeft.Visibility = Visibility.Hidden;
            this.textBlockRight.Visibility = Visibility.Hidden;
            this.textBlockSize.Visibility = Visibility.Visible;
            this.textBlockElongation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод устанавливает на окне только те регуляторы фракталов, которые необходимы для ковра Серпинского.
        /// </summary>
        public void SetSlidersForSierpinskiCarpet()
        {
            this.buttonGradient.Visibility = Visibility.Visible;
            this.buttonSave.Visibility = Visibility.Visible;
            this.sliderRecursionDepth.Visibility = Visibility.Visible;
            this.textBlockRecursion.Visibility = Visibility.Visible;
            this.sliderLeftAngle.Visibility = Visibility.Hidden;
            this.sliderRightAngle.Visibility = Visibility.Hidden;
            this.sliderPart.Visibility = Visibility.Hidden;
            this.sliderSize.Visibility = Visibility.Visible;
            this.textBlockLeft.Visibility = Visibility.Hidden;
            this.textBlockRight.Visibility = Visibility.Hidden;
            this.textBlockSize.Visibility = Visibility.Visible;
            this.textBlockElongation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод устанавливает на окне только те регуляторы фракталов, 
        /// которые необходимы для треугольника Серпинского.
        /// </summary>
        public void SetSlidersForSierpinskiTriangle()
        {
            this.buttonGradient.Visibility = Visibility.Visible;
            this.buttonSave.Visibility = Visibility.Visible;
            this.sliderRecursionDepth.Visibility = Visibility.Visible;
            this.textBlockRecursion.Visibility = Visibility.Visible;
            this.sliderLeftAngle.Visibility = Visibility.Hidden;
            this.sliderRightAngle.Visibility = Visibility.Hidden;
            this.sliderPart.Visibility = Visibility.Hidden;
            this.sliderSize.Visibility = Visibility.Visible;
            this.textBlockLeft.Visibility = Visibility.Hidden;
            this.textBlockRight.Visibility = Visibility.Hidden;
            this.textBlockSize.Visibility = Visibility.Visible;
            this.textBlockElongation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод устанавливает на окне только те регуляторы фракталов, которые необходимы для множества Кантора.
        /// </summary>
        public void SetSlidersForCantorSet()
        {
            this.buttonGradient.Visibility = Visibility.Visible;
            this.buttonSave.Visibility = Visibility.Visible;
            this.sliderRecursionDepth.Visibility = Visibility.Visible;
            this.textBlockRecursion.Visibility = Visibility.Visible;
            this.sliderLeftAngle.Visibility = Visibility.Hidden;
            this.sliderRightAngle.Visibility = Visibility.Hidden;
            this.sliderPart.Visibility = Visibility.Visible;
            this.sliderSize.Visibility = Visibility.Visible;
            this.textBlockLeft.Visibility = Visibility.Hidden;
            this.textBlockRight.Visibility = Visibility.Hidden;
            this.textBlockSize.Visibility = Visibility.Visible;
            this.textBlockElongation.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод определяет тип текущего фрактала и в зависимости от 
        /// этого устанавливает элементы регулирования параметров фракталов.
        /// </summary>
        public void SetSliders()
        {
            try
            {
                switch (theComboBox.SelectedIndex)
                {
                    case 0:
                        SetSlidersForPifagor();
                        break;
                    case 1:
                        SetSlidersForCurveOfKoch();
                        break;
                    case 2:
                        SetSlidersForSierpinskiCarpet();
                        break;
                    case 3:
                        SetSlidersForSierpinskiTriangle();
                        break;
                    case 4:
                        SetSlidersForCantorSet();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Метод определяет тип текущего фрактала и в зависимости от этого рисует фрактал.
        /// </summary>
        public void RedrawFractal()
        {
            try
            {
                switch (theComboBox.SelectedIndex)
                {
                    case 0:
                        DrawPifagorTree(theCanvas);
                        break;
                    case 1:
                        DrawCurveOfKoch(theCanvas);
                        break;
                    case 2:
                        DrawSierpinskeCarpet(theCanvas);
                        break;
                    case 3:
                        DrawSierpinskiTriangle(theCanvas);
                        break;
                    case 4:
                        DrawCantorSet(theCanvas);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения выбранного типа фраткала. Обнуляет сдвиг при отображении, устанавливает
        /// элементы управления параметрами фрактала, перерисовывает фрактал и переписывает текст.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void TheComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                shift = (0, 0);
                SetSliders();
                RedrawFractal();
                switch (theComboBox.SelectedIndex)
                {
                    case 0:
                        textBlockRecursion.Text = $"глубина отрисовки (" +
                            $"{(int)(1 + (double)sliderRecursionDepth.Value * 0.9)})";
                        break;
                    case 1:
                        textBlockRecursion.Text = $"глубина отрисовки ({(int)(1 + sliderRecursionDepth.Value / 2)})";
                        break;
                    case 2:
                        textBlockRecursion.Text =
                            $"глубина отрисовки ({(int)(1 + 0.45 * (double)sliderRecursionDepth.Value)})";
                        break;
                    case 3:
                        textBlockRecursion.Text = $"глубина отрисовки (" +
                            $"{(int)((double)sliderRecursionDepth.Value * 0.6 + 1)})";
                        break;
                    case 4:
                        textBlockRecursion.Text = $"глубина отрисовки ({(int)(1 + sliderRecursionDepth.Value / 2)})";
                        break;
                    default:
                        break;
                }
                if (theComboBox.SelectedIndex == 4) textBlockElongation.Text =
                        $"оступ между уровнями фрактала {(int)(sliderPart.Value * 60)}";
                else textBlockElongation.Text = $"Коэффициент длины дочернего элемента (" +
                        $"{sliderPart.Value.ToString("F3")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения масштаба отображения фрактала. Метод перерисовывает фрактал,
        /// изменяя масштаб отображения на указанный.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedrawFractal();
                textBlockSize.Text = $"Масштаб ({(int)(500.0 * sliderSize.Value)}%)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения длины дочернего элемента фрактала/изменения расстояния между дочерними
        /// элементами фрактала. Метод перерисовывает фрактал в соответствии с указанными параметрами и изменяет
        /// текст перед слайдером.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события</param>
        private void sliderPart_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedrawFractal();
                if (theComboBox.SelectedIndex == 4) textBlockElongation.Text =
                        $"оступ между уровнями фрактала {(int)(sliderPart.Value * 60)}";
                else textBlockElongation.Text = $"Коэффициент длины дочернего элемента (" +
                        $"{sliderPart.Value.ToString("F3")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения размера окна. Метод перерисовывает фрактал.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                RedrawFractal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения левого угла отклонения дочернего элемента. Метод перерисовывает фрактал
        /// в соответствии с указанными параметрами, а также изменяет текст перед слайдером.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderLeftAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedrawFractal();
                textBlockLeft.Text = $"Левый угол отклонения ({sliderLeftAngle.Value.ToString("F3")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения правого угла отклонения дочернего элемента. Метод перерисовывает фрактал
        /// в соответствии с указанными параметрами, а также изменяет текст перед слайдером.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderRightAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedrawFractal();
                textBlockRight.Text = $"Правый угол отклонения ({sliderRightAngle.Value.ToString("F3")})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения глубины отрисовки фрактала. Метод перерисовывает фрактал и изменяет текст,
        /// написанный слева от слайдера.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderRecursionDepth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RedrawFractal();
                switch (theComboBox.SelectedIndex)
                {
                    case 0:
                        textBlockRecursion.Text = $"глубина отрисовки (" +
                            $"{(int)(1 + (double)sliderRecursionDepth.Value * 0.9)})";
                        break;
                    case 1:
                        textBlockRecursion.Text = $"глубина отрисовки ({(int)(1 + sliderRecursionDepth.Value / 2)})";
                        break;
                    case 2:
                        textBlockRecursion.Text =
                            $"глубина отрисовки ({(int)(1 + 0.45 * (double)sliderRecursionDepth.Value)})";
                        break;
                    case 3:
                        textBlockRecursion.Text = $"глубина отрисовки (" +
                            $"{(int)((double)sliderRecursionDepth.Value * 0.6 + 1)})";
                        break;
                    case 4:
                        textBlockRecursion.Text = $"глубина отрисовки ({(int)(1 + sliderRecursionDepth.Value / 2)})";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку для изменения градиента цвета при отображении фрактала. Метод создает
        /// новый объект окна выбора градиента, с его помощью запрашивает градиент и перерисовывает фрактал.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonGradient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowGradient window = new WindowGradient(CurrentGradient.GradientBegin, CurrentGradient.GradientEnd);
                window.ShowDialog();
                RedrawFractal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на клавиатуру. Если нажата одна из клавиш WASD, метод переносит изображение
        /// фрактала в соответствующем направлении.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void TheCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.W:
                        shift.Y += 20;
                        RedrawFractal();
                        break;
                    case Key.S:
                        shift.Y -= 20;
                        RedrawFractal();
                        break;
                    case Key.A:
                        shift.X += 20;
                        RedrawFractal();
                        break;
                    case Key.D:
                        shift.X -= 20;
                        RedrawFractal();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на menuitem помощь. Метод отображает messagebox
        /// с информацией об использовании данной программы.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void menuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
@"Вас приветствует программа, рисующая фракталы, и ее создатель.

Для начала выберите тип фрактала, который хотите увидеть
(в выпадающем списке в правом нижнем углу). После этого в
нижнем меню Вам станут доступны настройки параметров 
указанного фрактала. Как только Вы измените какие-то 
настроки, программа сразу перерисует фрактал. Также Вы 
можете менять цветовой градиент, для этого нажмите на 
кнопку 'задать градиент' и положениями ползунков задайте
начальный и конечный цвет, а после сохраните их. Также Вы
можете увеличивать и уменьшать изображение фрактала, для
этого используйте ползунок 'масштаб'. Чтобы перемещаться
при просмотре фрактала, используйте клавиши WASD. Так как
глубоко прорисованные фракталы долго отрисовываются, 
рекомендуется использовать перемещение при низкой глубине
прорисовки фрактала (это не обязательно, но значительно 
ускоряет работу программы). Также программа имеет 
возможность сохранять изображения фракталов в виде
графического файла. Сохранится то изображение фрактала,
которое Вы видите на холсте на момент сохранения.");
        }

        /// <summary>
        /// Метод сохраняет изображение с указанного холста в файл по указанному адресу.
        /// </summary>
        /// <param name="canvas">Холст, с которого берется изображение.</param>
        /// <param name="filename">Адрес файла, куда нужно сохранить изображение.</param>
        public void ToImageSource(Canvas canvas, string filename)
        {
            try
            {
                canvas.LayoutTransform = null;
                double dpi = 300;
                double scale = dpi / 96;
                Size size = new Size(this.ActualWidth, this.ActualHeight - 120);
                RenderTargetBitmap image = new RenderTargetBitmap((int)(size.Width * scale),
                    (int)(size.Height * scale), dpi, dpi, PixelFormats.Pbgra32);
                canvas.Measure(size);
                canvas.Arrange(new Rect(size));
                image.Render(canvas);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (System.IO.FileStream file = System.IO.File.Create(filename))
                {
                    encoder.Save(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку сохранения фрактала. При нажатии на кнопку метод открывает диалог
        /// сохранения графического файла, после этого при необходимости сохранения вызывает метод сохранения
        /// изображения холста.
        /// </summary>
        /// <param name="sender">Объект издатель события.param>
        /// <param name="e">Аргументы события.</param>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
                saveFile.Filter = "bitmap files (*.bmp)|*.bmp";
                Nullable<bool> result = saveFile.ShowDialog();
                if (result == true) ToImageSource(theCanvas, saveFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }
    }
}
