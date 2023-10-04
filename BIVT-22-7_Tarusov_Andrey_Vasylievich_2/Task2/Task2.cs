namespace Task2
{
    public class DataBase
    {
        public struct DateTime
        {
            public int day;
            public int month;
            public int year;

            public string GetDate()
            {
                if (month > 9)
                {
                    return String.Join(".", new List<int> { this.day, this.month, this.year });
                }
                else
                {
                    return this.day.ToString() + ".0" + this.month.ToString() + "." + this.year.ToString();
                }
            }
        }

        public struct Student
        {
            public int id;
            public string fullName;
            public DateTime birthdayDate;
            public string institute;
            public string group;
            public int course;
            public double avgMark;

            public void Print(bool id = false)
            {
                if (id)
                {
                    Console.WriteLine($"|\t{this.id}.\t{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{this.avgMark}\t|");
                }
                else
                {
                    Console.WriteLine($"|\t{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{Math.Round(this.avgMark, 2).ToString()}\t|");
                }
            }
        }

        static private StreamReader? InputFile(string? name)
        {
            StreamReader? rstream = null;
            string fname;
            var s = name;
            if (s == null)
            {
                return null;
            }
            else
            {
                fname = s;
            }
            try
            {
                FileInfo f = new FileInfo(fname);
                string fullname = f.FullName;
                rstream = new StreamReader(fullname);
            }
            catch
            {
                return null;
            }
            return rstream;
        }

        static private StreamWriter? WriteFile(string? name)
        {
            StreamWriter? wstream = null;
            string fname;
            var s = name;
            if (s == null)
            {
                return null;
            }
            else
            {
                fname = s;
            }
            try
            {
                FileInfo f = new FileInfo(fname);
                string fullname = f.FullName;
                wstream = new StreamWriter(fullname);
            }
            catch
            {
                return null;
            }
            return wstream;
        }

        static private DateTime GetDateTime(string date)
        {
            DateTime dt;
            string[] sdate = date.Split(".");
            dt.day = int.Parse(sdate[0]);
            dt.month = int.Parse(sdate[1]);
            dt.year = int.Parse(sdate[2]);
            return dt;
        }

        static public List<Student>? InputBD(string? name)
        {
            List<Student>? students = new List<Student>();
            StreamReader? rstream = InputFile(name);
            if (rstream == null)
            {
                Console.WriteLine("Неудалось открыть файл.");
                return null;
            }
            int acc = 1, fileSize = 0;
            string s = "";

            try
            {
                s = rstream.ReadLine();
            }
            catch
            {
                Console.WriteLine("Невозможно прочитать файл");
                return null;
            }
            if (int.TryParse(s, out fileSize))
            {
                fileSize = int.Parse(s);
            }
            else
            {
                Console.WriteLine("Невозможно прочитать файл");
                return null;
            }
            Console.WriteLine("Обработка данных...");

            while (true)
            {
                if (fileSize / 4 == acc - 1)
                {
                    Console.WriteLine("Обработано 25% данных.");
                }
                else if (fileSize / 2 == acc - 1)
                {
                    Console.WriteLine("Обработано 50% данных.");
                }
                else if (fileSize * 3 / 4 == acc - 1)
                {
                    Console.WriteLine("Обработано 75% данных.");
                }

                string line = "";
                string[] studentMas;
                try
                {
                    line = rstream.ReadLine().ToString();
                }
                catch
                {
                    Console.WriteLine("Данные обработаны.\n");
                    break;
                }
                if (line != "" && line != null)
                {
                    studentMas = line.Split("\t");
                }
                else
                {
                    Console.WriteLine($"Строка {acc}. Невозможно извлечь данные.");
                    return null;
                }
                if (studentMas.Length != 7)
                {
                    Console.WriteLine($"Строка {acc}. Невозможно извлечь данные.");
                    return null;
                }

                Student student;
                try
                {
                    student.id = int.Parse(studentMas[0]);
                    student.fullName = studentMas[1];
                    student.birthdayDate = DataBase.GetDateTime(studentMas[2]);
                    student.institute = studentMas[3];
                    student.group = studentMas[4];
                    student.course = int.Parse(studentMas[5]);
                    student.avgMark = Math.Round(double.Parse(studentMas[6]), 2);
                    students.Add(student);
                }
                catch
                {
                    Console.WriteLine($"Строка {acc}. Невозможно извлечь данные.");
                    return null;
                }
                acc++;
            }
            rstream.Close();
            return students;
        }

        static public List<Student> FindByDate(List<Student>? students, string? str)
        {
            List<Student> result = new List<Student>();
            if (students == null)
            {
                Console.WriteLine("Такой базы данных не существует.");
                return result;
            }
            if (str == null)
            {
                Console.WriteLine("Невено указана дата.");
                return result;
            }
            else if (str.Split(".").Length != 3)
            {
                Console.WriteLine("Невено указана дата.");
                return result;
            }
            DateTime date = GetDateTime(str);
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].birthdayDate.day == date.day && students[i].birthdayDate.month == date.month && students[i].birthdayDate.year == date.year)
                {
                    result.Add(students[i]);
                }
            }
            return result;
        }


        static public int saveBD(List<Student> students, string? name)
        {
            StreamWriter? wstream = WriteFile(name);
            if (wstream == null)
            {
                return -1;
            }
            wstream.WriteLine(students.Count);
            try
            {
                for (int i = 0; i < students.Count; i++)
                {
                    wstream.WriteLine($"{i + 1}\t{students[i].fullName}\t{students[i].birthdayDate.GetDate()}\t{students[i].institute}\t{students[i].group}\t{students[i].course}\t{students[i].avgMark}");
                }
            }
            catch
            {
                wstream.Close();
                return -1;
            }
            wstream.Close();
            return 0;
        }

        static public void OutputBase(List<Student> students, bool withId = false)
        {
            if (students.Count != 0)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    students[i].Print(true);
                }
            }
        }

        static public int SortByAvgMark(List<Student> studentsList, bool reverse = false)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsList.Count; i++)
            {
                students.Add(studentsList[i]);
            }
            Console.WriteLine("Данные отсортированы!");
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].avgMark < students[j].avgMark)
                    {
                        if (reverse)
                        {
                            Student temp = students[i];
                            students[i] = students[j];
                            students[j] = temp;
                        }
                    }
                    else
                    {
                        if (!reverse)
                        {
                            Student temp = students[i];
                            students[i] = students[j];
                            students[j] = temp;
                        }
                    }
                }
            }

            OutputBase(students);
            return 0;
        }

        static public int DeleteLine(List<Student> studentsList, int id = 1)
        {
            try
            {
                studentsList.Remove(studentsList[id - 1]);
                Console.WriteLine("Строка удалена!\n");
                return 0;
            }
            catch
            {
                Console.WriteLine("Невозможно удалить.\n");
                return -1;
            }
        }
    }

    public class Task1
    {

        static int Menu()
        {
            List<DataBase.Student>? studentList = DataBase.InputBD("db.txt");
            if (studentList == null)
            {
                return -1;
            }
            Console.Write("Выберите режим работы программы (1 - поиск по дате, 2 - выход, 3 - сортировка по ср. баллу): ");
            string? s = Console.ReadLine();
            if (s != "1" && s != "2" && s != "3" && s != "4")
            {
                Console.WriteLine("Неверное выбран режим, завершаю свою работу.");
                return -1;
            }
            else
            {
                if (s == "2")
                {
                    Console.WriteLine("Завершение работы...");
                }
                else if (s == "3")
                {
                    Console.WriteLine("");
                    if (DataBase.SortByAvgMark(studentList) == 0)
                    {
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (s == "4")
                {
                    if (DataBase.DeleteLine(studentList, 2) != 0)
                    {
                        return -1;
                    }
                }
                else
                {
                    List<DataBase.Student>? result = DataBase.FindByDate(studentList, "23.09.2004");
                    if (result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("\nПолученный результат:");
                        DataBase.OutputBase(result);
                    }
                }
                if (DataBase.saveBD(studentList, "db.txt") == 0)
                {
                    Console.WriteLine("База данных сохранена!");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Невозможно сохранить базу данных!");
                    return -1;
                }
            }
        }

        static void Main(string[] args)
        {
            int result = Menu();
            if (result == 0)
            {
                Console.WriteLine("Корректное завершение работы программы.");
            }
            else
            {
                Console.WriteLine("Некорректное завершение работы программы.");
            }
        }
    }
}