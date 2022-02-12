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
using System.Windows.Shapes;

namespace WpfAppPeerGradeFractals
{
    /// <summary>
    /// Логика взаимодействия для WindowGradient.xaml
    /// </summary>
    public partial class WindowGradient : Window
    {
        /// <summary>
        /// Конструктор класса окна сохранения градиента цвета.
        /// </summary>
        /// <param name="gradientBegin">Кортеж из трех целых чисел - rgb компонент начального цвета.</param>
        /// <param name="gradientEnd">Кортеж из трех целых чисел - rgb компонент конечного цвета.</param>
        public WindowGradient((int red, int green, int blue) gradientBegin, 
            (int red, int green, int blue) gradientEnd)
        {
            InitializeComponent();
            sliderRBegin.Value = gradientBegin.red;
            sliderGBegin.Value = gradientBegin.green;
            sliderBBegin.Value = gradientBegin.blue;
            sliderREnd.Value = gradientEnd.red;
            sliderGEnd.Value = gradientEnd.green;
            sliderBEnd.Value = gradientEnd.blue;
            this.canvasColorBegin.Background = new SolidColorBrush(Color.FromRgb((byte)sliderRBegin.Value,
                (byte)sliderGBegin.Value, (byte)sliderBBegin.Value));
            this.canvasColorEnd.Background = new SolidColorBrush(Color.FromRgb((byte)sliderREnd.Value,
                (byte)sliderGEnd.Value, (byte)sliderBEnd.Value));
        }

        /// <summary>
        /// Обработчик события изменения значения красной компоненты градиента начального цвета.
        /// Метод изменяет отображение начального цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderRBegin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorBegin.Background = new SolidColorBrush(Color.FromRgb((byte)sliderRBegin.Value,
                    (byte)sliderGBegin.Value, (byte)sliderBBegin.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения значения зеленой компоненты градиента начального цвета.
        /// Метод изменяет отображение начального цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderGBegin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorBegin.Background = new SolidColorBrush(Color.FromRgb((byte)sliderRBegin.Value,
                    (byte)sliderGBegin.Value, (byte)sliderBBegin.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения значения синей компоненты градиента начального цвета.
        /// Метод изменяет отображение начального цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderBBegin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorBegin.Background = new SolidColorBrush(Color.FromRgb((byte)sliderRBegin.Value,
                    (byte)sliderGBegin.Value, (byte)sliderBBegin.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения значения красной компоненты градиента конечного цвета.
        /// Метод изменяет отображение конечного цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderREnd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorEnd.Background = new SolidColorBrush(Color.FromRgb((byte)sliderREnd.Value,
                    (byte)sliderGEnd.Value, (byte)sliderBEnd.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения значения зеленой компоненты градиента конечного цвета.
        /// Метод изменяет отображение конечного цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderGEnd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorEnd.Background = new SolidColorBrush(Color.FromRgb((byte)sliderREnd.Value,
                    (byte)sliderGEnd.Value, (byte)sliderBEnd.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события изменения значения синей компоненты градиента конечного цвета.
        /// Метод изменяет отображение конечного цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void sliderBEnd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                this.canvasColorEnd.Background = new SolidColorBrush(Color.FromRgb((byte)sliderREnd.Value,
                    (byte)sliderGEnd.Value, (byte)sliderBEnd.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события сохранения градиента цвета.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentGradient.GradientBegin = ((int)sliderRBegin.Value, (int)sliderGBegin.Value,
                    (int)sliderBBegin.Value);
                CurrentGradient.GradientEnd = ((int)sliderREnd.Value, (int)sliderGEnd.Value,
                    (int)sliderBEnd.Value);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошло исключение: {ex.Message}. Просьба написать в" +
                    $" отзывах на работу об этом исключении.");
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки отмены сохранения градиента.
        /// </summary>
        /// <param name="sender">Объект издатель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
