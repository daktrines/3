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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_1;
using LibMas;
using Масивы;

namespace _3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Вывод информации о программе
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Калион Екатерина. Пр3" +
                " Дана матрица размера M × N и целое число K (1 ≤ K ≤ M). Найти сумму и произведение элементов K - й строки данной матрицы.");
        }

        //Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int[,] matr;
        
        //Редактирование ячеек
        private void МатрицаDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Очищаем textbox с результатом 
            rez1.Clear();
            rez2.Clear();

            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Определяем номер строки
            int rowIndex = e.Row.GetIndex();

            //Заносим  отредоктированое значение в соответствующую ячейку матрицы

            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out matr[rowIndex, columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
        }

        //Заполнение матрицы
        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int row = Convert.ToInt32(kolStrok.Text);
                int column = Convert.ToInt32(kolStolbcov.Text);
                Class1.Заполнить(row, column, out matr);

                //Выводим матрицу на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

                //очищаем результат
                rez1.Clear();
                rez2.Clear();
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
                ZnK.Focus();
            }

        }
        //Расчет задания для матрицы
        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            rez1.Clear();
            rez2.Clear();

            if (matr == null || matr.Length == 0)
            {
                MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку Заполнить", "Ошибка");
            }
            else
            {
                try
                {
                    int K = Convert.ToInt32(ZnK.Text); //Вводим K
                    int M = Convert.ToInt32(kolStrok.Text); //Вводим M
                    if (K > 0 && K <= M)
                    {
                        Class2.Рассчитать(K, matr, out int sum, out int proizvedenie); //функция расчета
                        rez1.Text = Convert.ToString(sum); //выводим сумму нужной строки
                        rez2.Text = Convert.ToString(proizvedenie); //выводим прозведение нужной строки
                    }
                    else MessageBox.Show("Неверно ввели к (к должно быть меньше или равно количеству строк. И к не должно быть отрицательным числом)", "Ошибка");
                }
                catch
                {
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                      MessageBoxImage.Error);
                }

            }
        }
        //Очищение матрицы
        private void ОчиститьМатрицу_Click(object sender, RoutedEventArgs e)
        {
            //Очищаем результат матрицы
            ZnK.Clear();
            rez1.Clear();
            rez2.Clear();
            kolStrok.Clear();
            kolStolbcov.Clear();

            if (matr != null && matr.Length != 0)
            {
                matrData.ItemsSource = null;
            }
            else MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку \"Заполнить", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);

        }
        //Сохранение матрицы
        private void Savematr_Click(object sender, RoutedEventArgs e)
        {
            Class1.Savematr(matr);
        }

        //Открытие матрицы
        private void Openmatr_Click(object sender, RoutedEventArgs e)
        {
            
            Class1.Openmatr( out matr);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    //Выводим матрицу на форму
                    matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                }
            }
        }

    }
}
