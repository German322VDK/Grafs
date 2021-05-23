using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
        private long[] ax;
        private long[] ay;
        private double[] rx, ry, ranx, rany;
        private double pw;
        private long M;

        private double A;
        private double b;

        private const int N = 10;

        private const string ser2 = "C# Rand";

        void PrintGraf(int cht)
        {
            if (cht == 1)
            {
                using (StreamWriter file1 = new StreamWriter("MiddleSqure.txt"))
                {
                    file1.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                    //отрисовка графиков
                    for (int i = 0; i < count; i++)
                    {
                        rx[i] = Math.Round(rx[i], 3);
                        ranx[i] = Math.Round(ranx[i], 3);
                        ry[i] = Math.Round(ry[i], 3);
                        rany[i] = Math.Round(rany[i], 3);

                        chart1.Series["Series1"].Points.AddXY(rx[i], ry[i]);
                        chart1.Series["Series2"].Points.AddXY(rany[i], ranx[i]);

                        file1.WriteLine(i + "   " + rx[i] + "    " + ax[i]);
                    }
                }
                return;
            }
            else if (cht == 2)
            {
                using (StreamWriter file2 = new StreamWriter("MiddleMultyPly.txt"))
                {
                    file2.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                    //отрисовка графиков
                    for (int i = 0; i < count; i++)
                    {
                        rx[i] = Math.Round(rx[i], 3);
                        ranx[i] = Math.Round(ranx[i], 3);
                        ry[i] = Math.Round(ry[i], 3);
                        rany[i] = Math.Round(rany[i], 3);

                        chart2.Series["Series1"].Points.AddXY(rx[i], ry[i]);
                        chart2.Series["Series2"].Points.AddXY(ranx[i], rany[i]);

                        file2.WriteLine(i + "   " + rx[i] + "    " + ax[i]);
                    }
                }
                return;
            }
            else if (cht == 3)
            {
                using (StreamWriter file3 = new StreamWriter("MethMixing.txt"))
                {
                    file3.WriteLine($"i  r[i]    a[i]    N=10    count={count}   bitness={bitness}");
                    //отрисовка графиков
                    for (int i = 0; i < count; i++)
                    {
                        rx[i] = Math.Round(rx[i], 3);
                        ranx[i] = Math.Round(ranx[i], 3);
                        ry[i] = Math.Round(ry[i], 3);
                        rany[i] = Math.Round(rany[i], 3);

                        chart3.Series["Series1"].Points.AddXY(rx[i], ry[i]);
                        chart3.Series["Series2"].Points.AddXY(ranx[i], rany[i]);

                        file3.WriteLine(i + "   " + rx[i] + "    " + ax[i]);
                    }
                }
                return;
            }
            else if(cht == 4)
            {
                using (StreamWriter file4 = new StreamWriter("LineKon.txt"))
                {
                    file4.WriteLine($"i  r[i]    N=10    count={count}   a={A}" +
                        $"  b={b}   M={M}");
                    //отрисовка графика
                    for (int i = 0; i < count; i++)
                    {
                        chart4.Series["Series1"].Points.AddXY(rx[i], ry[i]);

                        file4.WriteLine(i + "   " + rx[i]);
                    }
                }
                return;
            }
        }

        //метод срединных квадратов
        public void MiddleSqure()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "mid squ";
            //объект рандома
            Random rand = new Random();
            //получение первого значение массива r и массива ran по x
            rx[0] = ax[0] / pw;
            ranx[0] = rand.NextDouble();

            //получение первого значение массива r и массива ran по y
            ry[0] = ay[0] / pw;
            rany[0] = rand.NextDouble();

            //цикл вычесления r и ran
            for (int i = 1; i < count; i++)
            {
                //возводим в квадрат и отбрасываем последние числа
                ax[i] = (long)((ax[i-1] * ax[i-1]) / Math.Pow(N, bitness/2));
                //отбрасываем первые числа
                ax[i] = (long)(ax[i] % pw);
                //вычесляем r
                rx[i] = ax[i] / pw;

                if (rx[i] < 0) 
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ranx[i] = rand.NextDouble();

                //возводим в квадрат и отбрасываем последние числа
                ay[i] = (long)((ay[i - 1] * ay[i - 1]) / Math.Pow(N, bitness / 2));
                //отбрасываем первые числа
                ay[i] = (long)(ay[i] % pw);
                //вычесляем r
                ry[i] = ay[i] / pw;

                if (ry[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                rany[i] = rand.NextDouble();
            }
            PrintGraf(1);
        }

        //метод срединных произведений
        public void MiddleMultyPly()
        {
            //подписываем график
            chart2.Series["Series1"].LegendText = "mid mult";
            //объект рандома
            Random rand = new Random();

            //вычесление первого и второго r x
            rx[0] = ax[0] / pw;
            rx[1] = ax[1] / pw;
            //вычесление первого и второго ran x
            ranx[0] = rand.NextDouble();
            ranx[1] = rand.NextDouble();

            //вычесление первого и второго r x
            ry[0] = ay[0] / pw;
            ry[1] = ay[1] / pw;
            //вычесление первого и второго ran x
            rany[0] = rand.NextDouble();
            rany[1] = rand.NextDouble();

            //цикл вычесления r и ran
            for (int i = 2; i < count; i++)
            {
                //перемножаем и отбрасываем последние числа
                ax[i] = (long)((ax[i - 1] * ax[i - 2]) / Math.Pow(N, bitness / 2));
                //отбрасываем первые числа
                ax[i] = (long)(ax[i] % pw);
                //вычесляем r
                rx[i] = ax[i] / pw;

                if (rx[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ranx[i] = rand.NextDouble();

                //перемножаем и отбрасываем последние числа
                ay[i] = (long)((ay[i - 1] * ay[i - 2]) / Math.Pow(N, bitness / 2));
                //отбрасываем первые числа
                ay[i] = (long)(ay[i] % pw);
                //вычесляем r
                ry[i] = ay[i] / pw;

                if (ry[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                rany[i] = rand.NextDouble();
            }
            PrintGraf(2);
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
            rx[0] = ax[0] / pw;
            ranx[0] = rand.NextDouble();

            //получение первого значение массива r и массива ran
            ry[0] = ay[0] / pw;
            rany[0] = rand.NextDouble();

            //цикл вычесления r и ran
            for (int i = 1; i < count; i++)
            {
                a1 = (ax[i - 1] % mx1) * mx2 + (ax[i - 1] / mx1); //сдвиг влево
                a2 = (ax[i - 1] % mx2) * mx1 + (ax[i - 1] / mx2); //сдвиг вправо
                //отбрасываем первые числа
                ax[i] = (long)((a1 + a2) % pw);
                //отбрасываем последние числа, вычесляем r
                rx[i] = ax[i] / pw;

                if (rx[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                ranx[i] = rand.NextDouble();

                a1 = (ay[i - 1] % mx1) * mx2 + (ay[i - 1] / mx1); //сдвиг влево
                a2 = (ay[i - 1] % mx2) * mx1 + (ay[i - 1] / mx2); //сдвиг вправо
                //отбрасываем первые числа
                ay[i] = (long)((a1 + a2) % pw);
                //отбрасываем последние числа, вычесляем r
                ry[i] = ay[i] / pw;

                if (ry[i] < 0)
                    throw new ArgumentException("Получилось слишком большое число");
                //вычесляем ran
                rany[i] = rand.NextDouble();
            }
            PrintGraf(3);
        }

        //Линейный конгруэнтный метод
        public void LineKon()
        {
            //подписываем график
            chart1.Series["Series1"].LegendText = "line con";

            b = 0.21131 * M;

            for (int i = 1; i < count; i++)
            {
                rx[i] = (int)((A * rx[i - 1] + b) % M);
                ry[i] = (int)((A * ry[i - 1] + b) % M);
            }

            PrintGraf(4);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Отчиска окна графиков
                chart1.Series["Series1"].Points.Clear();
                chart1.Series["Series2"].Points.Clear();
                chart1.Series["Series2"].LegendText = ser2;

                count = Convert.ToInt32(textBox1_1.Text);

                // проверки на корректность
                if (count < 2)
                    throw new Exception("Количество чисел");

                //создание массивов по оси х
                ax = new long[count + 1];
                rx = new double[count + 1];
                ranx = new double[count + 1];

                //создание массивов по оси х
                ay = new long[count + 1];
                ry = new double[count + 1];
                rany = new double[count + 1];

                bitness = Convert.ToInt32(textBox1_2.Text);

                if (bitness % 2 != 0)
                    throw new Exception("Разрядность");

                //максимальное значение разрядного числа
                pw = Math.Pow(N, bitness);

                //начальное значение x
                ax[0] = Convert.ToInt32(textBox1_3.Text);

                //проверка соответсвия разрядности
                if (ax[0] >= pw || ax[0] < pw / 10)
                    throw new Exception("число x не соответствует разрядности");

                //начальное значение y
                ay[0] = Convert.ToInt32(textBox1_4.Text);

                if (ay[0] >= pw || ay[0] < pw / 10)
                    throw new Exception("число y не соответствует разрядности");

                MiddleSqure();

                textBox1_5.Text = "Введены коректные данные";
            }
            catch (Exception er)
            {
                //обработка ошибок
                textBox1_5.Text = er.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Отчиска окна графиков
                chart2.Series["Series1"].Points.Clear();
                chart2.Series["Series2"].Points.Clear();
                chart2.Series["Series2"].LegendText = ser2;

                count = Convert.ToInt32(textBox2_1.Text);

                // проверки на корректность
                if (count < 2)
                    throw new Exception("Количество чисел");

                //создание массивов по оси х
                ax = new long[count + 1];
                rx = new double[count + 1];
                ranx = new double[count + 1];

                //создание массивов по оси х
                ay = new long[count + 1];
                ry = new double[count + 1];
                rany = new double[count + 1];

                bitness = Convert.ToInt32(textBox2_2.Text);

                if (bitness % 2 != 0)
                    throw new Exception("Разрядность");

                //максимальное значение разрядного числа
                pw = Math.Pow(N, bitness);

                //начальное значение x 1
                ax[0] = Convert.ToInt32(textBox2_3.Text);

                //проверка соответсвия разраядности
                if (ax[0] >= pw || ax[0] < pw / 10)
                    throw new Exception("число x не соответствует разрядности");

                //начальное значение y 1
                ay[0] = Convert.ToInt32(textBox2_4.Text);

                if (ay[0] >= pw || ay[0] < pw / 10)
                    throw new Exception("число y не соответствует разрядности");

                //начальное значение x 2
                ax[1] = Convert.ToInt32(textBox2_3_2.Text);

                //проверка соответсвия разраядности
                if (ax[1] >= pw || ax[1] < pw / 10)
                    throw new Exception("число x не соответствует разрядности");

                //начальное значение y 2
                ay[1] = Convert.ToInt32(textBox2_4_2.Text);

                if (ay[1] >= pw || ay[1] < pw / 10)
                    throw new Exception("число y не соответствует разрядности");

                MiddleMultyPly();

                textBox2_5.Text = "Введены коректные данные";
            }
            catch (Exception er)
            {
                //обработка ошибок
                textBox2_5.Text = er.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Отчиска окна графиков
                chart3.Series["Series1"].Points.Clear();
                chart3.Series["Series2"].Points.Clear();
                chart3.Series["Series2"].LegendText = ser2;

                count = Convert.ToInt32(textBox3_1.Text);

                // проверки на корректность
                if (count < 2)
                    throw new Exception("Количество чисел");

                //создание массивов по оси х
                ax = new long[count + 1];
                rx = new double[count + 1];
                ranx = new double[count + 1];

                //создание массивов по оси х
                ay = new long[count + 1];
                ry = new double[count + 1];
                rany = new double[count + 1];

                bitness = Convert.ToInt32(textBox3_2.Text);

                if (bitness % 2 != 0)
                    throw new Exception("Разрядность");

                //максимальное значение разрядного числа
                pw = Math.Pow(N, bitness);

                //начальное значение x
                ax[0] = Convert.ToInt32(textBox3_3.Text);

                //проверка соответсвия разрядности
                if (ax[0] >= pw || ax[0] < pw / 10)
                    throw new Exception("число x не соответствует разрядности");

                //начальное значение y
                ay[0] = Convert.ToInt32(textBox3_4.Text);

                if (ay[0] >= pw || ay[0] < pw / 10)
                    throw new Exception("число y не соответствует разрядности");

                MethMixing();

                textBox3_5.Text = "Введены коректные данные";
            }
            catch (Exception er)
            {
                //обработка ошибок
                textBox3_5.Text = er.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Отчиска окна графиков
                chart4.Series["Series1"].Points.Clear();

                count = Convert.ToInt32(textBox4_1.Text);

                // проверки на корректность
                if (count < 2)
                    throw new Exception("Количество чисел");

                M = Convert.ToInt64(textBox4_2.Text);

                if (M < 1000)
                    throw new Exception("Должно быть больше 1000");

                A = Convert.ToDouble(textBox4_3.Text);

                if ((A <= M / 100 || A >= (M - Math.Sqrt(M))) || (A % 8) != 5)
                    throw new Exception("A некоректно");

                rx = new double[count + 1];
                ry = new double[count + 1];

                rx[0] = Convert.ToDouble(textBox4_4.Text);

                if (rx[0] < 0 || rx[0] > M)
                    throw new Exception("начальное число некоректно");

                ry[0] = Convert.ToDouble(textBox4_6.Text);

                if (ry[0] < 0 || ry[0] > M)
                    throw new Exception("начальное число некоректно");

                textBox4_5.Text = "Введены коректные данные";

                LineKon();
            }
            catch (Exception er)
            {
                //обработка ошибок
                textBox4_5.Text = er.Message;
            }
        }

        #region Игра

        int userpoints = 0, comppoints = 0, usernam, compnam;

        private int[] Mix()
        {
            int bt = 10000;
            int bit = 4;
            long[] a1 = new long[3];
            long[] a2 = new long[3];
            long mx1 = (long)Math.Pow(N, (3 * bit) / 4);
            long mx2 = (long)Math.Pow(N, bit / 4);

            double[] trr = new double[3];
            int[] Tr = new int[3];
            long[] s = new long[3];

            int max = DateTime.MaxValue.Millisecond, cur = DateTime.Now.Millisecond;

            if (cur < 100)
                cur *= 10;

            s[0] = (long)( ( (double)max / cur) * ( bt / 10) );
            if (s[0] < 1000)
                s[0] *= 10;
            trr[0] = (double)s[0] / bt;

            for (int i = 1; i < Tr.Length; i++)
            {
                a1[i] = (s[i - 1] % mx1) * mx2 + (s[i - 1] / mx1); //сдвиг влево
                a2[i] = (s[i - 1] % mx2) * mx1 + (s[i - 1] / mx2); //сдвиг вправо
                //отбрасываем первые числа
                s[i] = (long)((a1[i] + a2[i]) % bt);
                if (s[i] < 1000) 
                    s[i] *= 10;
                //отбрасываем последние числа, вычесляем r
                trr[i] = (double)s[i] / bt;

            }

            for(int i = 0; i < Tr.Length; i++)
            {
                Tr[i] = Convert.ToInt32(trr[i] * 6);
                if (Tr[i] == 0)
                    Tr[i]++;
            }

            return Tr;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (userpoints >= 20 || comppoints >= 20)
            {
                MessageBox.Show("Начните игру заново!!!", "Ошибка");
                return;
            }

            Random r = new Random();
            int pu = 0, pc = 0;
            try
            {
                usernam = Convert.ToInt32(textBox5_1.Text);

                if (usernam < 1 || usernam > 6)
                    throw new ArgumentException("Должно быть от 1 до 6");


                textBox5_7.Text = "ошибки не найдены";

                
            }
            catch (Exception er)
            {
                textBox5_7.Text = er.Message;
                return;
            }

            int[] Tru = Mix();

            foreach (var item in Tru)
            {
                if (item == usernam)
                {
                    userpoints++;
                    pu++;
                }
            }

            textBox5_1_1.Text = Tru[0].ToString() + " " + Tru[1].ToString() 
                + " " + Tru[2].ToString();

            textBox5_2.Text = userpoints.ToString();
            textBox5_3.Text = $"Вам выпало ваше \n число {pu} раз";

            await Task.Delay(200);

            compnam = r.Next(1, 7);

            textBox5_4.Text = compnam.ToString();

            int[] Trc = Mix();

            foreach (var item in Trc)
            {
                if (item == compnam)
                {
                    comppoints++;
                    pc++;
                }
            }

            textBox5_2_1.Text = Trc[0].ToString() + " " + Trc[1].ToString()
                + " " + Trc[2].ToString();

            textBox5_5.Text = comppoints.ToString();

            textBox5_6.Text = $"Компьютеру выпало \n его число  {pc} раз";

            if (userpoints >= 20 && comppoints < 20)
            {
                textBox5_8.Text = "Игрок";
                MessageBox.Show("Вы ПОБЕДИЛИ!!!", "Победа");
            }
                
            else if (userpoints < 20 && comppoints >= 20)
            {
                textBox5_8.Text = "Компьютер";
                MessageBox.Show("Вы проиграли(", "Поражение");
            }
                
            else if(userpoints >= 20 && comppoints >= 20)
            {
                textBox5_8.Text = "Ничья";
                MessageBox.Show("Ничья|", "Ничья");
            }
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игрок загадывает число, бросаются 3 кости \n " +
                "Если число выпало 1 раз += 1 очко, 2 раза => 2 и тд. Играем до 20 очков",
                "Подсказка");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userpoints = 0; 
            comppoints = 0;

            textBox5_1.Text = "";
            textBox5_2.Text = "";
            textBox5_3.Text = "";
            textBox5_4.Text = "";
            textBox5_5.Text = "";
            textBox5_6.Text = "";
            textBox5_7.Text = "";
            textBox5_8.Text = "";
            textBox5_2_1.Text = "";
            textBox5_1_1.Text = "";
        }

        #endregion
        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            InitializeComponent();

        }

    }
}
