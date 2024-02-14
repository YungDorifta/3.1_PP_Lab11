using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Лаб_11
{
    public class MyException : ArgumentException
    {
        public const string ArgumentError = "Массив не определен";
        public const string SizeError = "Выход за границы массива!";

        public int Value { get; }

        public MyException(string message) :base(message)
        { 
        }

        public MyException(string message, int value) : base(message)
        {
            Value = value;
        }
    }


    public class Arr
    {
        private int[] a;
        private int size;
        private Random rnd = new Random();

        /// <summary>
        /// конструктор класса по умолчанию
        /// </summary>
        public Arr()
        {
            size = 0;
            a = null;
        }
        
        /// <summary>
        /// конструктор класса с одним параметром размер массива
        /// </summary>
        /// <param name="n">размер массива</param>
        public Arr(int n)
        {
            a = new int[n];
            size = n;
        }
        
        /// <summary>
        /// ещё один конструктор с инициализацией обычным массивом
        /// </summary>
        /// <param name="x">массив целого типа</param>
        public Arr(int[] x)
        {
            if (x == null)
                throw new MyException(MyException.ArgumentError);
            else
            {
                size = x.Length;
                a = new int[size];
                for (int i = 0; i < size; i++)
                {
                    a[i] = x[i];
                }
            }
        }
        
        /// <summary>
        /// ещё один конструктор с инициализацией объектом класса Arr
        /// </summary>
        /// <param name="A">объект класса Arr</param>
        public Arr(Arr A)
        {
            if (A.a == null)
            {
                throw new MyException(MyException.ArgumentError);
            }
            else
            {
                size = A.size;
                a = new int[size];
                for (int i = 0; i < size; i++)
                { this.a[i] = A.a[i]; }
            }
        }
        
        /// <summary>
        /// метод заполнения массива случайными числами от -100 до 100
        /// </summary>
        public void RndInput()
        {
            for (int i = 0; i < size; i++)
                a[i] = rnd.Next(-100, 101);
        }
        
        /// <summary>
        /// метод заполнения массива случайными числами от 0 до n1
        /// </summary>
        /// <param name="n1"></param>
        public void RndInput(int n1)
        {
            for (int i = 0; i < size; i++)
                a[i] = rnd.Next(0, n1);
        }
        
        /// <summary>
        /// метод заполнения массива случайными числами от n1 до n2
        /// </summary>
        /// <param name="n1">нижняя граница интервала</param>
        /// <param name="n2">верхняя граница интервала</param>
        public void RndInput(int n1, int n2)
        {
            for (int i = 0; i < size; i++)
                a[i] = rnd.Next(n1, n2);
        }
        
        /// <summary>
        /// перегрузка метода преобразования объекта Arr в троку
        /// </summary>
        /// <returns>элементы массива через пробел в одну строку</returns>
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                s += String.Format("{0,5}", a[i]);
            }
            return s;
        }
        
        /// <summary>
        /// метод вывода массива класса Arr на консоль
        /// </summary>
        public void Print()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine();
        }
        
        /// <summary>
        /// метод распечатки массива в поле надписи
        /// </summary>
        /// <param name="handel">handel-строка заголовки</param>
        /// <param name="lbl">lbl-поле надписи</param>
        public void Print(string handel, Label lbl)
        {
            Console.WriteLine(handel);
            Console.WriteLine(lbl);
        }

        /// <summary>
        /// метод распечатки массива в таблицу
        /// </summary>
        /// <param name="handel">handel-строка заголовки</param>
        /// <param name="lbl">lbl-поле надписи</param>
        /// <param name="dgv">dgv-таблицаб куда выводится массив</param>
        public void Print(string handel, Label lbl, DataGridView dgv)
        {
            lbl.Text = handel;
            dgv.RowCount = 1;
            dgv.ColumnCount = this.size;
            for (int i = 0; i < this.size; i++)
            {
                dgv.Rows[0].Cells[i].Value = a[i];
            }
        }

        /// <summary>
        /// метод индексации элемента массива
        /// </summary>
        /// <param name="i">номер элемента</param>
        /// <returns></returns>
        public int this[int i]
        {
            get
            {
                if (i>= 0 && i < size)
                {
                    return a[i];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < size)
                    a[i] = value;
                else
                    throw new MyException(MyException.SizeError);
            }
        }

        /// <summary>
        /// метод вычисления суммы всех элементов массива
        /// </summary>
        /// <returns>возвращает сумму элементов массива</returns>
        public int Summ()
        {
            int s = 0;
            for (int i = 0; i < size; i++)
            {
                s += a[i];
            }
            return s;
        }
        
        /// <summary>
        /// Метод нахождения суммы эл-тов, кратных заданным
        /// </summary>
        /// <param name="n"></param>
        /// <returns>сумма эл-тов, кратных заданному числу</returns>
        public int Summ(int n)
        {
            int s = 0;
            for (int i = 0; i < size; i++)
            {
                if (a[i] % n == 0)
                    s += a[i];
            }
            return s;
        }

        /// <summary>
        /// перегрузка метода инкременции
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Arr operator ++(Arr A)
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = ++A[i];
            }
            return temp;
        }

        /// <summary>
        /// перегрузка метода декременции
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Arr operator --(Arr A)
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = --A[i];
            }
            return temp;
        }

        /// <summary>
        /// перегрузка оператора +: сложение массивов
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Arr operator +(Arr A, Arr B)
        {
            int tempsize;
            if (A.size > B.size)
            {
                tempsize = A.size;
            }
            else
            {
                tempsize = B.size;
            }
            Arr temp = new Arr(tempsize);

            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] + B[i];
            }

            return temp;
        }

        /// <summary>
        /// перегрузка оператора +: сложение массива и целого числа
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Arr operator +(Arr A, int x)
        {
            
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] + x;
            }
            return temp;
        }

        /// <summary>
        /// перегрузка оператора +: сложение массива и целого числа
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Arr operator +(int x, Arr A)
        {

            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] + x;
            }
            return temp;
        }

        /// <summary>
        /// перегрузка оператора -: вычитание массивов
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Arr operator -(Arr A, Arr B)
        {
            int tempsize;
            if (A.size > B.size)
            {
                tempsize = A.size;
            }
            else
            {
                tempsize = B.size;
            }
            Arr temp = new Arr(tempsize);

            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] - B[i];
            }

            return temp;
        }

        /// <summary>
        /// перегрузка оператора -: вычитание целого числа из массива
        /// </summary>
        /// <param name="A"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Arr operator -(int x, Arr A)
        {

            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] - x;

            }
            return temp;
        }

        /// <summary>
        /// перегрузка оператора -: вычитание целого числа из массива
        /// </summary>
        /// <param name="A"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Arr operator -(Arr A, int x)
        {

            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = A[i] - x;
            }
            return temp;
        }

        /// <summary>
        /// Метод сравнения (перегруж.)
        /// </summary>
        /// <param name="obj">объект, с которым сравнивают</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj as Arr == null)
                return false;

            for (int i = 0; i < size; i++)
                if (this[i] != ((Arr)obj)[i])
                    return false;

            return true;
        }



        
        /// <summary>
        /// Метод вычисления кол-ва элементов, кратных заданному числу
        /// </summary>
        /// <param name="num">Заданное число</param>
        /// <returns>Кол-во эл-тов</returns>
        public int count_krat(int num)
        {
            int s = 0;
            for (int i = 0; i < size; i++)
            {
                if (a[i] % num == 0 && a[i] != 0)
                    s++;
            }
            return s;
        }

        /// <summary>
        /// Метод чтения эл-тов массива из файла
        /// </summary>
        /// <param name="fn">Адрес файла</param>
        public void file_read(string fn)
        {
            StreamReader stream = null;
            try
            {
                stream = new StreamReader(fn);
                char[] ch = { ' ', '\n' };
                string[] elements = (stream.ReadToEnd()).Split(ch, StringSplitOptions.RemoveEmptyEntries);
                size = elements.Length;
                a = new int[size];
                for (int i = 0; i < size; i++)
                {
                    a[i] = Convert.ToInt32(elements[i]);
                }
            }
            catch
            {
                throw new Exception("Не удалось открыть файл");
            }
            finally
            {
                stream.Close();
            }
        }

       /// <summary>
       /// Метод, меняющий знаки эл-тов массива на противоположные, 
       /// если большинство эл-тов отрицательные
       /// </summary>
       /// <returns></returns>
        public Arr the_variant_method()
        {
            if (size > 0)
            {
                //подсчет 
                int sum = 0;
                for (int i = 0; i < size; i++)
                {
                    if (a[i] < 0) sum++;
                }

                //замена знаков, если отр. > полож.
                if (size - sum < sum)
                {
                    for (int i = 0; i < size; i++)
                    {
                        a[i] = a[i] * (-1);
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// Метод, возвращающий размер массива
        /// </summary>
        /// <returns></returns>
        public int return_size()
        {
            return this.size;
        }
    }
}
