namespace Task5
{
    public class TaskFisrt
    {
        static public List<int> Input(StreamReader? rstream = null)
        {
            List<int> list = new List<int>();
            Console.Write("Введите элементы массива: ");
            string[] temp;
            while (true)
            {
                string? str = null;
                if (rstream == null)
                {
                    str = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        str = rstream.ReadLine();
                    }
                    catch
                    {
                        return list;
                    }
                    if (str == null)
                    {
                        return list;
                    }
                }
                if (str == null)
                {
                    if (rstream == null)
                    {
                        Console.WriteLine("Некорректный ввод. Повторите еще раз.");
                        continue;
                    }
                    else
                    {
                        return new List<int>();
                    }
                }
                else
                {
                    temp = str.Split(' ');
                    int fl = 0;
                    int tempNum;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (!int.TryParse(temp[j], out tempNum))
                        {
                            fl = 1;
                            if (rstream == null)
                            {
                                fl = 1;
                            }
                            else
                            {
                                fl = 2;
                            }
                            break;
                        }
                        else
                        {
                            list.Add(tempNum);

                        }
                    }
                    if (fl == 1)
                    {
                        Console.WriteLine("Введите корректную строчку");
                        list.Clear();
                        continue;
                    }
                    if (fl == 2)
                    {
                        return new List<int>();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return list;
        }


        static public void OutputMassive(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine(list[list.Count - 1]);
        }


        static public void FindMaxMin(List<int> list)
        {
            List<int> minEl = new List<int> { list[0], 0 }, maxEl = new List<int> { list[0], 0 };
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < minEl[0])
                {
                    minEl[0] = list[i];
                    minEl[1] = i;
                }
                if (list[i] > maxEl[0])
                {
                    maxEl[0] = list[i];
                    maxEl[1] = i;
                }
            }
            Console.WriteLine($"{minEl[0]} {minEl[1]}");
            Console.WriteLine($"{maxEl[0]} {maxEl[1]}");
        }


        static public List<int> BubbleSort(List<int> list, bool key = true)
        {
            int temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        if (key)
                        {
                            temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                    else
                    {
                        if (!key)
                        {
                            temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }
            }
            return list;
        }


        static public List<int> EvenElements(List<int> list)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }


        static public int Loop(StreamReader? rstream)
        {
            List<int> num_mas = Input(rstream);
            if (num_mas.Count == 0)
            {
                Console.WriteLine("Неверно введен массив. Завершение работы...");
                return -1;
            }
            OutputMassive(num_mas);
            FindMaxMin(num_mas);
            string? choose = null;
            Console.Write("Выберите режим работы приложения ('a' - собственноручно написанные сортировки, 'b' - с помощью методов System.Array): ");
            if (rstream == null)
            {
                choose = Console.ReadLine();
            }
            else
            {
                try
                {
                    choose = rstream.ReadLine();
                }
                catch
                {
                    return -1;
                }
            }
            if ((choose != "a" && choose != "b") || choose == null)
            {
                Console.WriteLine("Режим не выбран, заканчиваю работу...");
                return -1;
            }
            else
            {
                if (choose == "a")
                {
                    num_mas = BubbleSort(num_mas, true);
                    OutputMassive(num_mas);
                    num_mas = BubbleSort(num_mas, false);
                    OutputMassive(num_mas);
                }
                else
                {
                    int[] tempMassive = new int[num_mas.Count];
                    for (int i = 0; i < num_mas.Count; i++)
                    {
                        tempMassive[i] = num_mas[i];
                    }
                    Array.Sort(tempMassive);
                    for (int i = 0; i < num_mas.Count - 1; i++)
                    {
                        Console.Write($"{tempMassive[i]} ");
                    }
                    Console.WriteLine(tempMassive[num_mas.Count - 1]);
                    Array.Reverse(tempMassive);
                    for (int i = 0; i < num_mas.Count - 1; i++)
                    {
                        Console.Write($"{tempMassive[i]} ");
                    }
                    Console.WriteLine(tempMassive[num_mas.Count - 1]);
                }
            }
            List<int> evenList = EvenElements(num_mas);
            OutputMassive(evenList);
            return 0;
        }
    }


    public class TaskSecond
    {
        static public int[] InputSize(StreamReader? rstream)
        {
            int[] result = new int[2];
            string[] temp;
            Console.Write("Введите размеры массива: ");
            if (rstream == null)
            {
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
            }
            else
            {
                string? str;
                try
                {
                    str = rstream.ReadLine();
                }
                catch
                {
                    return Array.Empty<int>();
                }
                if (str == null)
                {
                    return Array.Empty<int>();
                }
                temp = str.Split(' ');
                if (temp.Length != 2)
                {
                    return new int[0];
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
                    return Array.Empty<int>();
                }
            }
            return result;
        }


        static public int[,] InputMas(StreamReader? rstream)
        {
            int height, width;
            int[] size = InputSize(rstream);
            if (size.Length == 0)
            {
                Console.WriteLine("Некорректно записаны размеры массива.");
                return new int[0, 0];
            }
            height = size[0]; width = size[1];
            int[,] result = new int[height, width];
            Console.WriteLine("Введите массив");
            if (rstream == null)
            {
                for (int i = 0; i < height; i++)
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
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    string[] temp;
                    string? str;
                    try
                    {
                        str = rstream.ReadLine();
                    }
                    catch
                    {
                        return new int[0, 0];
                    }
                    if (str == null)
                    {
                        return new int[0, 0];
                    }
                    temp = str.Split(' ');
                    if (temp.Length != width)
                    {
                        return new int[0, 0];
                    }
                    bool fl = true;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (!int.TryParse(temp[j], out result[i, j]))
                        {
                            fl = false;
                            return new int[0, 0];
                        }
                        else
                        {
                            result[i, j] = int.Parse(temp[j]);
                        }
                    }
                    if (!fl)
                    {
                        return new int[0, 0];
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
                        minEl = new int[3] { mas[i, j], i, j };
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
                for (int i = 0; i < result.GetLength(0); i++)
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


        static public int Loop(StreamReader? rstream)
        {
            int[,] mas1 = InputMas(rstream);
            if (mas1.GetLength(0) == 0 || mas1.GetLength(1) == 0)
            {
                Console.WriteLine("Неверно задан массив");
                return -1;
            }
            Output(mas1);
            FindMinMax(mas1);
            int[,] mas2 = InputMas(rstream);
            int[,] addMas = AddTwoMas(mas1, mas2);
            Output(addMas);
            int[,] subMas = SubTwoMas(mas1, mas2);
            Output(subMas);
            int[,] MultMas = MultTwoMas(mas1, mas2);
            Output(MultMas);
            return 0;
        }
    }


    public class TaskThird
    {
        static public int InputSize(StreamReader? rstream)
        {
            int result;
            if (rstream == null)
            {
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
            }
            else
            {
                string? temp;
                try
                {
                    temp = rstream.ReadLine();
                }
                catch
                {
                    return 0;
                }
                if (temp == null)
                {
                    return 0;
                }
                else
                {
                    if (int.TryParse(temp, out result))
                    {
                        result = int.Parse(temp);
                        return 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return result;
        }


        static public int[][] InputMas(StreamReader? rstream)
        {
            int size = InputSize(rstream);
            int[][] result = new int[size][];
            for (int i = 0; i < size; i++)
            {
                if (rstream == null)
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
                else
                {
                    string[] temp;
                    string? str;
                    try
                    {
                        str = rstream.ReadLine();
                    }
                    catch
                    {
                        return Array.Empty<int[]>();
                    }
                    if (str == null)
                    {
                        return Array.Empty<int[]>();
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
                        return Array.Empty<int[]>();
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


        static public int ChangeElement(int[][] mas, StreamReader? rstream)
        {
            int[] result = new int[2];
            string[] temp;
            if (rstream == null)
            {
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
            }
            else
            {

                var str = Console.ReadLine();
                if (str == null)
                {
                    return -1;
                }
                temp = str.Split(' ');
                if (temp.Length != 2)
                {
                    return -1;
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
                    return -1;
                }
                else
                {
                    if (0 <= result[0] && result[0] < mas.Length)
                    {
                        if (0 <= result[1] && result[1] < mas[result[0]].Length)
                        {
                            Console.WriteLine("Элемент изменен удачно!");
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            mas[result[0]][result[1]] = new Random().Next() % 1000;
            return 0;
        }


        static public void Output(int[][] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length - 1; j++)
                {
                    Console.Write($"{mas[i][j]} ");
                }
                Console.WriteLine(mas[i][mas[i].Length - 1]);
            }
        }


        static public int Loop(StreamReader? rstream)
        {
            int[][] mas = InputMas(rstream);
            if (mas.Length == 0)
            {
                Console.WriteLine("Некорректно задан массив. Завершение работы...");
                return -1;
            }
            else
            {
                if (mas[0].Length == 0)
                {
                    Console.WriteLine("Некорректно задан массив. Завершение работы...");
                    return -1;
                }
            }
            Output(mas);
            FindMinMax(mas);
            if (ChangeElement(mas, rstream) != 0)
            {
                Console.WriteLine("Некорректный введены индексы элемента. Завершаю работу");
                return -1;
            }
            Output(mas);
            return 0;
        }
    }


    class TaskFourth
    {
        static public string InputMode()
        {
            string format;
            Console.Write("Введите режим работы приложения с вводом ('kb' - с клавиатуры, 'fl' - файл): ");
            while (true)
            {
                var s = Console.ReadLine();
                if (s == null || (s != "kb" && s != "fl"))
                {
                    Console.WriteLine("Некоректный ввод. Попробуйте еще раз.");
                }
                else
                {
                    format = s;
                    break;
                }
            }
            return format;
        }

        static public int Menu()
        {

            string format = InputMode();
            StreamReader? rstream = null;
            if (format == "fl")
            {
                while (true)
                {
                    Console.Write("Введите название файла, указывая его формат: ");
                    string fname;
                    while (true)
                    {
                        var s = Console.ReadLine();
                        if (s == null)
                        {
                            Console.WriteLine("Неверный формат ввода. Попробуйте еще раз.");
                        }
                        else
                        {
                            fname = s;
                            break;
                        }
                    }
                    try
                    {
                        FileInfo f = new FileInfo(fname);
                        string fullname = f.FullName;
                        rstream = new StreamReader(fullname);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неудалось открыть файл. Введите название файла еще раз.\n");
                    }
                }
            }

            if (rstream == null)
            {
                Console.WriteLine("Выберите режим приложения: t1 - работа с одномерными массивами, t2 - работа с двумерными массивами,\nt3 - работа с ступенчатыми массивами.");
                while (true)
                {
                    var s = Console.ReadLine();
                    if (s == null || (s != "t1" && s != "t2" && s != "t3"))
                    {
                        Console.WriteLine("Некоректный ввод. Попробуйте еще раз.");
                    }
                    else
                    {
                        int result = 0;
                        switch (s)
                        {
                            case "t1":
                                result = TaskFisrt.Loop(rstream);
                                break;
                            case "t2":
                                result = TaskSecond.Loop(rstream);
                                break;
                            case "t3":
                                result = TaskThird.Loop(rstream);
                                break;
                            default:
                                result = -1;
                                break;
                        }
                        if (result != 0)
                        {
                            Console.WriteLine("Некорректное завершение работы программы...");
                            return -1;
                        }
                        else
                        {
                            Console.WriteLine("Работа программы завершилась успешно!");
                            return 0;
                        }
                    }
                }
            }
            else
            {
                string? NumProgram;
                try
                {
                    NumProgram = rstream.ReadLine();
                }
                catch
                {
                    return -1;
                }
                int result = 0;
                switch (NumProgram)
                {
                    case "t1":
                        Console.WriteLine($"Вы выбрали режим {NumProgram[1]}");
                        result = TaskFisrt.Loop(rstream);
                        break;
                    case "t2":
                        Console.WriteLine($"Вы выбрали режим {NumProgram[1]}");
                        result = TaskSecond.Loop(rstream);
                        break;
                    case "t3":
                        Console.WriteLine($"Вы выбрали режим {NumProgram[1]}");
                        result = TaskThird.Loop(rstream);
                        break;
                    default:
                        result = -1;
                        break;
                }
                if (result != 0)
                {
                    Console.WriteLine("Некорректное завершение работы программы...");
                    return -1;
                }
                else
                {
                    Console.WriteLine("Работа программы завершилась успешно!");
                    return 0;
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Начать работу?(Y/n)");
                var s = Console.ReadLine();
                if (s == "Y" || s == "y")
                {
                    Menu();
                }
                if (s == "N" || s == "n")
                {
                    return;
                }
            }
        }
    }
}