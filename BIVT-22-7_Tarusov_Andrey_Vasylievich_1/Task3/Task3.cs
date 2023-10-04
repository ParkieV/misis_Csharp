namespace Task3
{
    class TaskThird
    {
        static public int InputSize()
        {
            int result;
            while (true)
            {
                var temp = Console.ReadLine();
                if (temp == null)
                {
                    Console.WriteLine("Неверный ввод размера. Попробуйте еще раз.");
                    continue;
                }
                else
                {
                    if (int.TryParse(temp, out result))
                    {
                        result = int.Parse(temp);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод размера. Попробуйте еще раз.");
                        continue;
                    }
                }
            }
            return result;
        }


        static public int[][] InputMas()
        {
            int size = InputSize();
            int[][] result = new int[size][];
            for (int i = 0; i < size; i++)
            {
                string[] temp;
                while (true)
                {
                    var str = Console.ReadLine();
                    if (str == null)
                    {
                        Console.WriteLine("Введите корректную строчку");
                        continue;
                    }
                    temp = str.Split(' ');
                    result[i] = new int[temp.Length];
                    bool fl = true;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (!int.TryParse(temp[j], out result[i][j]))
                        {
                            fl = false;
                            break;
                        }
                        else
                        {
                            result[i][j] = int.Parse(temp[j]);
                        }
                    }
                    if (!fl)
                    {
                        Console.WriteLine("Введите корректную строчку");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }


        static public void FindMinMax(int[][] mas)
        {
            int[] minEl = { mas[0][0], 0, 0 }, maxEl = { mas[0][0], 0, 0 };
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (minEl[0] > mas[i][j])
                    {
                        minEl = new int[] { mas[i][j], i, j };
                    }
                    if (maxEl[0] < mas[i][j])
                    {
                        maxEl = new int[] { mas[i][j], i, j };
                    }
                }
            }
            Console.WriteLine($"{minEl[0]} {minEl[1]} {minEl[2]}");
            Console.WriteLine($"{maxEl[0]} {maxEl[1]} {maxEl[2]}");
        }


        static public void ChangeElement(int[][] mas)
        {
            int[] result = new int[2];
            string[] temp;
            while (true)
            {
                var str = Console.ReadLine();
                if (str == null)
                {
                    Console.WriteLine("Некорректно заданы размеры. Попробуйте еще раз.");
                    continue;
                }
                temp = str.Split(' ');
                if (temp.Length != 2)
                {
                    Console.WriteLine("Некорректно заданы размеры. Попробуйте еще раз.");
                    continue;
                }
                bool fl = true;
                for (int i = 0; i < result.Length; i++)
                {
                    if (!int.TryParse(temp[i], out result[i]))
                    {
                        fl = false;
                        break;
                    }
                    else
                    {
                        result[i] = int.Parse(temp[i]);
                    }
                }
                if (!fl)
                {
                    Console.WriteLine("Некорректно заданы размеры. Попробуйте еще раз.");
                    continue;
                }
                else
                {
                    if (0 <= result[0] && result[0] < mas.Length)
                    {
                        if (0 <= result[1] && result[1] < mas[result[0]].Length)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверно указан номер элемента. Попробуйте еще раз.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверно указан номер элемента. Попробуйте еще раз");
                    }
                }
            }
            mas[result[0]][result[1]] = new Random().Next() % 1000;
        }


        static public void Output(int[][] mas)
        {
            for(int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length - 1; j++)
                {
                    Console.Write($"{mas[i][j]} ");
                }
                Console.WriteLine(mas[i][mas[i].Length - 1]);
            }
        }


        static void Main(string[] args)
        {
            int[][] mas = InputMas();
            Output(mas);
            FindMinMax(mas);
            ChangeElement(mas);
            Output(mas);
        }
    }
}