namespace Task2
{
    class SecondTask
    {
        static public int[] InputSize()
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
                    break;
                }
            }
            return result;
        }


        static public int[,] InputMas()
        {
            int height, width;
            int[] size = InputSize();
            height = size[0]; width = size[1];
            int[,] result = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                string[] temp;
                while(true)
                {
                    var str = Console.ReadLine();
                    if (str == null)
                    {
                        Console.WriteLine("Введите корректную строчку");
                        continue;
                    }
                    temp = str.Split(' ');
                    if (temp.Length != width)
                    {
                        Console.WriteLine("Введите корректную строчку");
                        continue;
                    }
                    bool fl = true;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (!int.TryParse(temp[j], out result[i, j]))
                        {
                            fl = false;
                            break;
                        }
                        else
                        {
                            result[i, j] = int.Parse(temp[j]);
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


        static public void Output(int[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1) - 1; j++)
                {
                    Console.Write($"{mas[i, j]} ");
                }
                Console.WriteLine(mas[i, mas.GetLength(1) - 1]);
            }
        }


        static public void FindMinMax(int[,] mas)
        {
            int[] minEl = { mas[0, 0], 0, 0 }, maxEl = { mas[0, 0], 0, 0 };
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (minEl[0] > mas[i, j])
                    {
                        minEl = new int[3] {mas[i, j], i, j};
                    }
                    if (maxEl[0] < mas[i, j])
                    {
                        maxEl = new int[3] { mas[i, j], i, j };
                    }
                }
            }
            Console.WriteLine($"{minEl[0]} {minEl[1]} {minEl[2]}");
            Console.WriteLine($"{maxEl[0]} {maxEl[1]} {maxEl[2]}");
        }


        static public int[,] AddTwoMas(int[,] mas1, int[,] mas2)
        {
            if (mas1.GetLength(0) != mas2.GetLength(0) || mas1.GetLength(1) != mas2.GetLength(1))
            {
                Console.WriteLine("Операция Add недопустима!");
                return new int[0, 0];
            }
            else
            {
                int[,] result = new int[mas1.GetLength(0), mas1.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = mas1[i, j] + mas2[i, j];
                    }
                }
                return result;
            }
        }


        static public int[,] SubTwoMas(int[,] mas1, int[,] mas2)
        {
            if (mas1.GetLength(0) != mas2.GetLength(0) || mas1.GetLength(1) != mas2.GetLength(1))
            {
                Console.WriteLine("Операция Subtract недопустима!");
                return new int[0, 0];
            }
            else
            {
                int[,] result = new int[mas1.GetLength(0), mas1.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = mas1[i, j] - mas2[i, j];
                    }
                }
                return result;
            }
        }


        static public int[,] MultTwoMas(int[,] mas1, int[,] mas2)
        {
            int[,] result;
            if (mas1.GetLength(1) != mas2.GetLength(0))
            {
                Console.WriteLine("Операция Multiply невозможна!");
               result = new int[0, 0];
            }
            else
            {
                result = new int[mas1.GetLength(0), mas2.GetLength(1)];
                for(int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        int sumEls = 0;
                        for (int k = 0; k < mas1.GetLength(1); k++) 
                        {
                            sumEls += mas1[i, k] * mas2[k, j];
                        }
                        result[i, j] = sumEls;
                    }
                }
            }
            return result;
        }


        static void Main(string[] args)
        {
            int[,] mas1 = InputMas();
            Output(mas1);
            FindMinMax(mas1);
            int[,] mas2 = InputMas();
            int[,] addMas = AddTwoMas(mas1, mas2);
            Output(addMas);
            int[,] subMas = SubTwoMas(mas1, mas2);
            Output(subMas);
            int[,] MultMas = MultTwoMas(mas1, mas2);
            Output(MultMas);
        }
    }
}