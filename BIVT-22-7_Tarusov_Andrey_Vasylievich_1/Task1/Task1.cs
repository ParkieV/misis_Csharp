namespace Task1
{
    class TaskFisrt
    {
        static public List<int> Input()
        {
            List<int> list = new List<int>();
            Console.WriteLine("Ввод чисел в массив, для выхода введите 'end'.");
            int temp;
            while (true)
            {
                var value = Console.ReadLine();
                if (value == "end" || value == null)
                {
                    break;
                }
                else
                {
                    if (int.TryParse(value, out temp))
                    {
                        list.Add(temp);
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


        static void Main(string[] args)
        {
            List<int> num_mas = Input();
            OutputMassive(num_mas);
            FindMaxMin(num_mas);
            var choose = Console.ReadLine();
            if ((choose != "a" & choose != "b") || choose == null)
            {
                Console.Write("Режим не выбран, заканчиваю работу...");
                return;
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
        }
    }
}