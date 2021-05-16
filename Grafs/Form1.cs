using System;
using System.IO;
using System.Windows.Forms;

namespace Grafs
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// count - Количество чисел
        /// a - массив значений (разрядное число)
        /// r - массив значений (дробное число)
        /// ran - массив с# rand значений 
        /// bitness - разрядность
        /// N - основание
        /// </summary>
        private long count, bitness;
        private long[] a;
        private double[] r, ran;
        private double pw;
        private long M;

        private double A;
        private double b;

        private const int N = 10;
        private const string ser2 = "C# Rand";


        //функция выбора метода
        public int RadButton()
        {
            if (radioButton1.Checked) return 1;
            if (radioButton2.Checked) return 2;
            if (radioButton3.Checked) return 3;
            if (radioButton4.Checked) return 4;

            return 0;
        }

        //метод срединных квадратов
        public void MiddleSqure()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "mid squ";
            //объект рандома
            Random rand = new Random();
            //получение первого значение массива r и массива ran
            r[0] = a[0] / pw;
            ran[0] = rand.NextDouble();
            //цикл вычесления r и ran
            for (int i = 1; i < count; i++)
            {
                //возводим в квадрат и отбрасываем последние числа
                a[i] = (long)((a[i-1] * a[i-1]) / Math.Pow(N, bitness/2));
                //отбрасываем первые числа
                a[i] = (long)(a[i] % pw);
                //вычесляем r
                r[i] = a[i] / pw;

                if (r[i] < 0) 
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ran[i] = rand.NextDouble();
            }
            using (StreamWriter file1 = new StreamWriter("MiddleSqure.txt"))
            {
                file1.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                //отрисовка графиков
                for (int i = 0; i < count; i++)
                {
                    r[i] = Math.Round(r[i], 3);
                    ran[i] = Math.Round(ran[i], 3);

                    chart1.Series["Series1"].Points.AddXY(i, r[i]);
                    chart1.Series["Series2"].Points.AddXY(i, ran[i]);

                    file1.WriteLine(i + "   " + r[i] + "    " + a[i]);
                }
            }
        }

        //метод срединных произведений
        public void MiddleMultyPly()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "mid mult";
            //объект рандома
            Random rand = new Random();
            //вычесление первого и второго r
            r[0] = a[0] / pw;
            r[1] = a[1] / pw;
            //вычесление первого и второго ran
            ran[0] = rand.NextDouble();
            ran[1] = rand.NextDouble();
            //цикл вычесления r и ran
            for (int i = 2; i < count; i++)
            {
                //перемножаем и отбрасываем последние числа
                a[i] = (long)((a[i - 1] * a[i - 2]) / Math.Pow(N, bitness / 2));
                //отбрасываем первые числа
                a[i] = (long)(a[i] % pw);
                //вычесляем r
                r[i] = a[i] / pw;

                if (r[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ran[i] = rand.NextDouble();
            }
            using (StreamWriter file2 = new StreamWriter("MiddleMultyPly.txt"))
            {
                file2.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                //отрисовка графиков
                for (int i = 0; i < count; i++)
                {
                    r[i] = Math.Round(r[i], 3);
                    ran[i] = Math.Round(ran[i], 3);

                    chart1.Series["Series1"].Points.AddXY(i, r[i]);
                    chart1.Series["Series2"].Points.AddXY(i, ran[i]);

                    file2.WriteLine(i + "   " + r[i] + "    " + a[i]);
                }
            }
        }

        //метод перемешивания
        public void MethMixing()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "meth mix";
            //объект рандома
            Random rand = new Random();
            //переменные сдвига влево и вправо
            long a1, a2;
            //переменные для сдвига влево и вправо
            long mx1 = (int)Math.Pow(N, (3 * bitness) / 4);
            long mx2 = (int)Math.Pow(N, bitness / 4);
            //получение первого значение массива r и массива ran
            r[0] = a[0] / pw;
            ran[0] = rand.NextDouble();
            //цикл вычесления r и ran
            for (int i = 1; i < count; i++)
            {
                a1 = (a[i-1] % mx1) * mx2 + (a[i - 1] / mx1); //сдвиг влево
                a2 = (a[i - 1] % mx2) * mx1 + (a[i - 1] / mx2); //сдвиг вправо
                //отбрасываем первые числа
                a[i] = (long)((a1 + a2) % pw);
                //отбрасываем последние числа, вычесляем r
                r[i] = a[i] / pw;

                if (r[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ran[i] = rand.NextDouble();
            }
            using (StreamWriter file3 = new StreamWriter("MethMixing.txt"))
            {
                file3.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                //отрисовка графиков
                for (int i = 0; i < count; i++)
                {
                    r[i] = Math.Round(r[i], 3);
                    ran[i] = Math.Round(ran[i], 3);

                    chart1.Series["Series1"].Points.AddXY(i, r[i]);
                    chart1.Series["Series2"].Points.AddXY(i, ran[i]);

                    file3.WriteLine(i + "   " + r[i] + "    " + a[i]);
                }
            }
        }

        //Линейный конгруэнтный метод
        public void LineKon()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "line con";
            chart1.Series["Series2"].LegendText = "";

            b = 0.21131 * M;

            for (int i = 1; i < count; i++)
            {
                r[i] = (int)( ( A * r[i-1] + b) % M);
            }

            using (StreamWriter file4 = new StreamWriter("LineKon.txt"))
            {
                file4.WriteLine($"i  r[i]    N=10    count={count}   a={A}" +
                    $"  b={b}   M={M}");
                //отрисовка графика
                for (int i = 0; i < count; i++)
                {
                    chart1.Series["Series1"].Points.AddXY(i, r[i]);

                    file4.WriteLine(i + "   " + r[i]);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Отчиска окна графиков
                chart1.Series["Series1"].Points.Clear();
                chart1.Series["Series2"].Points.Clear();
                chart1.Series["Series2"].LegendText = ser2;

                int sw = RadButton(); //Выбранный метод

                count = Convert.ToInt32(textBox1.Text);

                // проверки на корректность
                if (count < 2)
                    throw new Exception("Количество чисел");

                //создание массивов
                a = new long[count + 1];
                r = new double[count + 1];
                ran = new double[count + 1];

                if (sw != 4)
                {
                    bitness = Convert.ToInt32(textBox2.Text);

                    if (bitness % 2 != 0)
                        throw new Exception("Разрядность");

                    //начальное значение
                    a[0] = Convert.ToInt32(textBox3.Text);

                    //максимальное значение разрядного числа
                    pw = Math.Pow(N, bitness);

                    //проверка соответсвия разраядности
                    if (a[0] >= pw || a[0] < pw / 10)
                        throw new Exception("число 1 не соответствует разрядности");

                    if (sw == 2)
                    {
                        //второе значение
                        a[1] = Convert.ToInt32(textBox5.Text);

                        if (a[1] >= pw || a[1] < pw / 10)
                            throw new Exception("число 2 не соответствует разрядности");
                    }
                }

                else
                {
                    M = Convert.ToInt64(textBox6.Text);

                    if (M < 1000)
                        throw new Exception("Должно быть больше 1000");

                    A = Convert.ToDouble(textBox7.Text);

                    if ((A <= M / 100 || A >= (M - Math.Sqrt(M))) || (A % 8) != 5 )
                        throw new Exception("A некоректно");

                    r[0] = Convert.ToDouble(textBox3.Text);

                    if(r[0] < 0 || r[0] > M)
                        throw new Exception("начальное число некоректно");
                }

                //Выбор запускаемого метода
                switch (sw)
                {
                    case 1: MiddleSqure(); break;
                    case 2: MiddleMultyPly();  break;
                    case 3: MethMixing();  break;
                    case 4: LineKon();  break;
                    default: throw new Exception("Не выбран метод");
                }

                textBox4.Text = "Введены коректные данные";
            }
            catch (Exception er)
            {
                //обработка ошибок
                textBox4.Text = er.Message;
            }
        }

        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            InitializeComponent();
        }

    }
}
