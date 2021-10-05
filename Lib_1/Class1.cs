using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public class Class2
    {
        /// <summary>
        /// //Расчет задания для матрицы
        /// </summary>
        /// <param name="K"> число которое мы вводим </param>
        /// <param name="matr"> матрица </param>
        /// <param name="sum"> сумма </param>
        /// <param name="proizvedenie"> произведение </param>




        public static void Рассчитать(int K, int[,] matr, out int sum, out int proizvedenie)
        {
            sum = 0;
            proizvedenie = 1;
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                sum += matr[K-1, j];
                proizvedenie *= matr[K-1, j];
            }
        }
    }
}
