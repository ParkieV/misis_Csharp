

namespace Task4
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
            public int idStudent;
            public string fullName;
            public DateTime birthdayDate;
            public string institute;
            public string group;
            public int course;
            public double avgMark;
            public string educationForm;
            public string educationLevel;
            public int numDolg;

            public void Print(bool id = false)
            {
                if (id)
                {
                    Console.WriteLine($"|\t{this.idStudent}.\t{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{this.avgMark}\t{this.educationForm}\t{this.educationLevel}\t{this.numDolg}\t|");
                }
                else
                {
                    Console.WriteLine($"|\t{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{Math.Round(this.avgMark, 2).ToString()}\t{this.educationForm}\t{this.educationLevel}\t{this.numDolg}\t|");
                }
            }
            public string GetString(bool id = false)
            {
                if (id)
                {
                    return $"{this.idStudent}.\t{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{this.avgMark}";
                }
                else
                {
                    return $"{this.fullName}\t{this.birthdayDate.GetDate()}\t{this.institute}\t{this.group}\t{this.course}\t{Math.Round(this.avgMark, 2).ToString()}";
                }
            }
        }

        static private StreamReader? InputFile(string? bdname)
        {
            StreamReader? rstream = null;
            string fname;
            var s = bdname;
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

        static private StreamWriter? WriteFile(string? bdname)
        {
            StreamWriter? wstream = null;
            string fname;
            var s = bdname;
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
        static private int GetNumStudents(string bdname)
        {
            int num;
            StreamReader? rstream = InputFile(bdname);
            if (rstream == null)
            {
                return -1;
            }
            try
            {
                num = int.Parse(rstream.ReadLine());
            }
            catch
            {
                return -1;
            }
            return num;
        }

        static public List<Student>? InputBD(string? bdname)
        {
            List<Student>? students = new List<Student>();
            StreamReader? rstream = InputFile(bdname);
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
                if (fileSize / 2 == acc - 1)
                {
                    Console.WriteLine("Обработано 50% данных.");
                }
                if (fileSize * 3 / 4 == acc - 1)
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
                if (studentMas.Length != 10)
                {
                    Console.WriteLine($"Строка {acc}. Невозможно извлечь данные.");
                    return null;
                }

                Student student;
                try
                {
                    student.idStudent = int.Parse(studentMas[0]);
                    student.fullName = studentMas[1];
                    student.birthdayDate = DataBase.GetDateTime(studentMas[2]);
                    student.institute = studentMas[3];
                    student.group = studentMas[4];
                    student.course = int.Parse(studentMas[5]);
                    student.avgMark = Math.Round(double.Parse(studentMas[6]), 2);
                    student.educationForm = studentMas[7];
                    student.educationLevel = studentMas[8];
                    student.numDolg = int.Parse(studentMas[9]);
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

        static public int saveBD(List<Student> students, string? bdname)
        {
            StreamWriter? wstream = WriteFile(bdname);
            if (wstream == null)
            {
                return -1;
            }
            wstream.WriteLine(students.Count);
            try
            {
                for (int i = 0; i < students.Count; i++)
                {
                    wstream.WriteLine($"{i + 1}\t{students[i].fullName}\t{students[i].birthdayDate.GetDate()}\t{students[i].institute}\t{students[i].group}\t{students[i].course}\t{students[i].avgMark}\t{students[i].educationForm}\t{students[i].educationLevel}\t{students[i].numDolg}");
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
                if (withId)
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        students[i].Print(true);
                    }
                }
                else
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.Write($"{i + 1}\t");
                        students[i].Print();
                    }
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
            Console.WriteLine("Данные отсортированы!");
            OutputBase(students);
            return 0;
        }

        static public int DeleteLine(List<Student> studentsList, int id = 0)
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

        private static void RewriteLine(string path, int lineIndex, string newValue)
        {
            int i = 0;
            string tempPath = path + ".tmp";
            using (StreamReader sr = new StreamReader(path))
            using (StreamWriter sw = new StreamWriter(tempPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (lineIndex == i)
                        sw.WriteLine(newValue);
                    else
                        sw.WriteLine(line);
                    i++;
                }
            }
            File.Delete(path);
            File.Move(tempPath, path);
        }

        static public int AddStudent(string bdname, List<Student> students, string info)
        {
            Student student;
            try
            {
                string[] studentInfo = info.Split(", ");
                student.idStudent = students.Count + 1;
                student.fullName = studentInfo[0];
                try
                {
                    student.birthdayDate = GetDateTime(studentInfo[1]);
                }
                catch
                {
                    Console.WriteLine("Неверно указана дата.");
                    return -1;
                }
                student.institute = studentInfo[2];
                student.group = studentInfo[3];
                try
                {
                    student.course = int.Parse(studentInfo[4]);
                }
                catch
                {
                    Console.WriteLine("Неверно указан курс.");
                    return -1;
                }
                try
                {
                    student.avgMark = double.Parse(studentInfo[5]);
                }
                catch
                {
                    Console.WriteLine("Неверно указан средний балл.");
                    return -1;
                }
                student.educationForm = studentInfo[6];
                student.educationLevel = studentInfo[7];
                try
                {
                    student.numDolg = int.Parse(studentInfo[8]);
                }
                catch
                {
                    Console.WriteLine("Неверно указано количество задолжностей.");
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
            if (IsInBD(students, student))
            {
                Console.WriteLine("Данный человек уже есть в базе данных.");
                return -1;
            }
            string fullname = "";
            try
            {
                FileInfo f = new FileInfo(bdname);
                fullname = f.FullName;
                File.AppendAllText(fullname, "\n" + student.GetString());
                students.Add(student);
            }
            catch
            {
                return -1;
            }
            try
            {
                RewriteLine(fullname, 0, students.Count.ToString() + "\n");
            }
            catch
            {
                students.Remove(student);
                return -1;
            }
            return 0;
        }

        static public List<Student> FindByDate(List<Student> students, DateTime date)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].birthdayDate.day == date.day && students[i].birthdayDate.month == date.month && students[i].birthdayDate.year == date.year)
                {
                    result.Add(students[i]);
                }
            }
            return result;
        }

        static public bool OnString(string main, string substr)
        {
            if (main.Length < substr.Length)
            {
                return false;
            }
            else if (main == substr)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < main.Length - substr.Length; i++)
                {
                    string temp = main.Substring(i, substr.Length);
                    if (temp == substr)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        static public List<Student> FindByName(List<Student> students, string name)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (OnString(students[i].fullName, name))
                {
                    result.Add(students[i]);
                }
            }
            return result;
        }

        static public double[] FindMinMax(List<Student> students)
        {
            double[] result = new double[] { students[0].avgMark, students[0].avgMark };
            for (int i = 1; i < students.Count; i++)
            {
                if (result[0] < students[i].avgMark)
                {
                    result[0] = students[i].avgMark;
                }
                if (result[1] > students[i].avgMark)
                {
                    result[1] = students[i].avgMark;
                }
            }
            return result;
        }

        static public List<List<Student>> ListMinMaxStudents(List<Student> students, double[] MaxMin)
        {
            List<List<Student>> result = new List<List<Student>>() { new List<Student>(), new List<Student>() };
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].avgMark == MaxMin[0])
                {
                    result[0].Add(students[i]);
                }
                if (students[i].avgMark == MaxMin[1])
                {
                    result[1].Add(students[i]);
                }
            }
            return result;
        }

        static public bool IsInBD(List<Student> students, Student student, bool inbd = false, int idStudent = 0)
        {
            if (inbd)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if ((students[i].fullName == student.fullName && student.birthdayDate.day == students[i].birthdayDate.day && student.birthdayDate.month == students[i].birthdayDate.month && students[i].birthdayDate.year == student.birthdayDate.year) && !object.Equals(students[i], student))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].fullName == student.fullName && student.birthdayDate.day == students[i].birthdayDate.day && student.birthdayDate.month == students[i].birthdayDate.month && students[i].birthdayDate.year == student.birthdayDate.year)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        static public int DeleteRep(List<Student> students)
        {
            int acc = 0;
            while (acc < students.Count)
            {
                if (IsInBD(students, students[acc], true))
                {
                    students.RemoveAt(acc);
                }
                else 
                { 
                    acc++; 
                }
            }
            return 0;
        }
        static public List<Student> FindByAvgMark(List<Student> students, double mark)
        {
            List<Student> result = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].avgMark == mark)
                {
                    result.Add(students[i]);
                }
            }
            return result;
        }
    }

    public class Task4
    {

        static int Menu()
        {
            List<DataBase.Student> studentList = new List<DataBase.Student>();
            try
            {
                studentList = DataBase.InputBD("db.txt");
                if (studentList == null)
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
            while (true)
            {
                Console.Write("Выберите режим работы программы: ");
                string? input = Console.ReadLine();
                bool flExit = false;
                switch (input)
                {
                    case "1":
                        Console.Write("Введите дату рождения учащегося в формате DD.MM.YYYY: ");
                        string? birthdayDate = Console.ReadLine();
                        if (birthdayDate == null || birthdayDate == "")
                        {
                            Console.WriteLine("Дата не написана");
                        }
                        DataBase.DateTime bDate;
                        try
                        {
                            string[] dataMas = birthdayDate.Split(".");
                            if (int.Parse(dataMas[0]) < 32 && int.Parse(dataMas[0]) > 0)
                            {
                                bDate.day = int.Parse(dataMas[0]);
                            }
                            else
                            {
                                throw new Exception("Uncorrect input day of date");
                            }
                            if (int.Parse(dataMas[1]) < 13 && int.Parse(dataMas[1]) > 0)
                            {
                                bDate.month = int.Parse(dataMas[1]);
                            }
                            else
                            {
                                throw new Exception("Uncorrect input month of date");
                            }
                            if (int.Parse(dataMas[0]) > 0)
                            {
                                bDate.year = int.Parse(dataMas[2]);
                            }
                            else
                            {
                                throw new Exception("Uncorrect input year of date");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Неккоректно введена дата.");
                            continue;
                        }
                        List<DataBase.Student> studentsDates = new List<DataBase.Student>();
                        try
                        {
                            studentsDates = DataBase.FindByDate(studentList, bDate);
                        }
                        catch
                        {
                            Console.WriteLine("Невозможно найти по заданным параметрам.");
                        }
                        if (studentsDates.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                        }
                        else
                        {
                            Console.WriteLine("\nРезультат:");
                            DataBase.OutputBase(studentsDates);
                        }
                        continue;

                    case "2":
                        Console.WriteLine("Введите данных о студенте через запятую (ФИО, дата рождения в формате DD.MM.YYYY, университет, группа, курс, средний балл, форма обучения, уровень подготовки, количество задолжностей).");
                        Console.Write("Для отмены введите 'end': ");
                        string? studentStr;
                        try
                        {
                            studentStr = Console.ReadLine();
                        }
                        catch
                        {
                            Console.WriteLine("Данные не введены.");
                            continue;
                        }
                        if (studentStr == "")
                        {
                            Console.WriteLine("Данные не введены.");
                            continue;
                        }
                        else if (studentStr == "end")
                        {
                            return 0;
                        }
                        if (DataBase.AddStudent("db.txt", studentList, studentStr) != 0)
                        {
                            Console.WriteLine("Невозможно записать данные.");
                            continue;
                        }
                        break;

                    case "3":
                        Console.WriteLine("");
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("Невозможно провести сортировку, так как нет записей в базе данных.");
                            continue;
                        }
                        if (DataBase.SortByAvgMark(studentList, true) != 0)
                        {
                            Console.WriteLine("Невозможно отсортировать данные.");
                            return -1;
                        }
                        break;

                    case "4":
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("Невозможно удалить запись, так как нет записей в базе данных.");
                            continue;
                        }
                        Console.WriteLine("Введите id cтудента, которого вы хотите удалить.");
                        Console.Write("Для отмены введите команды 'back'. Для просмотра студентов с их id введите 'output -id': ");
                        bool flWhile = false;
                        do
                        {
                            if (flWhile)
                            {
                                Console.Write("Введите id cтудента: ");
                            }
                            string? id = Console.ReadLine();
                            if (id == "back")
                            {
                                break;
                            }
                            else if (id == "output -id")
                            {
                                DataBase.OutputBase(studentList, true);
                            }
                            else
                            {
                                try
                                {
                                    int idStudent = int.Parse(id);
                                    if (DataBase.DeleteLine(studentList, idStudent) != 0)
                                    {
                                        Console.WriteLine("Невозможно удалить данные.");
                                    }
                                    for (int i = idStudent - 1; i < studentList.Count; i++)
                                    {
                                        DataBase.Student tempStudent;
                                        tempStudent.idStudent = studentList[i].idStudent - 1;
                                        tempStudent.fullName = studentList[i].fullName;
                                        tempStudent.birthdayDate = studentList[i].birthdayDate;
                                        tempStudent.institute = studentList[i].institute;
                                        tempStudent.group = studentList[i].group;
                                        tempStudent.course = studentList[i].course;
                                        tempStudent.avgMark = studentList[i].avgMark;
                                        tempStudent.educationForm = studentList[i].educationForm;
                                        tempStudent.educationLevel = studentList[i].educationLevel;
                                        tempStudent.numDolg = studentList[i].numDolg;
                                        studentList[i] = tempStudent;
                                    }
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Id введен неверно.");
                                }
                            }
                            flWhile = true;
                        } while (flWhile);
                        continue;

                    case "5":
                        DataBase.OutputBase(studentList, true);
                        continue;

                    case "6":
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("Невозможно провесети поиск, так как нет записей в базе данных.");
                            continue;
                        }
                        Console.Write("Введите имя: ");
                        string? name = Console.ReadLine();
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Неккоректно введено имя.");
                            continue;
                        }
                        List<DataBase.Student> studentsNames = new List<DataBase.Student>();
                        try
                        {
                            studentsNames = DataBase.FindByName(studentList, name);
                        }
                        catch
                        {
                            Console.WriteLine("Невозможно найти по заданным параметрам.");
                        }
                        if (studentsNames.Count == 0)
                        {
                            Console.WriteLine("Нет записей");
                        }
                        else
                        {
                            Console.WriteLine("\nРезультат:");
                            DataBase.OutputBase(studentsNames);
                        }
                        continue;

                    case "7":
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("Невозможно произвести поиск, так как нет записей в базе данных.");
                            continue;
                        }
                        double[] MaxMin = DataBase.FindMinMax(studentList);
                        List<List<DataBase.Student>> result = DataBase.ListMinMaxStudents(studentList, MaxMin);
                        Console.WriteLine("\nУченики с максимальным баллом:");
                        DataBase.OutputBase(result[0]);
                        Console.WriteLine("\nУченики с минимальным баллом:");
                        DataBase.OutputBase(result[1]);
                        continue;

                    case "8":
                        if (studentList.Count == 0)
                        {
                            Console.WriteLine("Невозможно произвести действие, так как нет записей в базе данных.");
                            continue;
                        }
                        int result8 = 0;
                        try
                        {
                            result8 = DataBase.DeleteRep(studentList);
                        }
                        catch
                        {
                            Console.WriteLine("Невозможно выполнить действие.");
                        }
                        if (result8 == 0)
                        {
                            Console.WriteLine("Повторяющиеся записи успешно удалены!");
                        }
                        continue;

                    case "9":
                        Console.Write("Введите среднюю оценку (для отмены введите 'back'): ");
                        var s = Console.ReadLine();
                        if (s == "back")
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                double mark = double.Parse(s);
                                List<DataBase.Student> StudentList = DataBase.FindByAvgMark(studentList, mark);
                                if (StudentList.Count == 0)
                                {
                                    Console.WriteLine("Записи не найдены.");
                                }
                                else
                                {
                                    Console.WriteLine("Полученные данные:");
                                    DataBase.OutputBase(StudentList);
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Неверно указан средний балл.");
                            }
                            continue;
                        }

                    case "exit":
                        Console.WriteLine("Завершение работы...");
                        flExit = true;
                        break;

                    case "help":
                        Console.WriteLine("1 - Поиск по дате.");
                        Console.WriteLine("2 - Добавление студента.");
                        Console.WriteLine("3 - Сортировка студентов по среднему баллу.");
                        Console.WriteLine("4 - Удаление студента.");
                        Console.WriteLine("5 - Вывод базы данных на экран.");
                        Console.WriteLine("6 - Поиск по имени.");
                        Console.WriteLine("7 - Вывести учеников с максимальным и минимальным баллами.");
                        Console.WriteLine("8 - Удалить повторяющиеся элементы в базе данных.");
                        Console.WriteLine("9 - Поиск по среднему баллу.");
                        Console.WriteLine("");
                        Console.WriteLine("exit - Завершение работы программы.");
                        Console.WriteLine("help - Описание всех режимов.");
                        continue;

                    default:
                        Console.WriteLine("Режим не найден. Повторите ввод. Для просмотра описания режимов введите 'help'.");
                        continue;
                }
                if (DataBase.saveBD(studentList, "db.txt") == 0)
                {
                    Console.WriteLine("База данных сохранена!");
                    if (flExit)
                    {
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Невозможно сохранить базу данных!");
                    if (flExit)
                    {
                        return -1;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("API к базе данных.\n");
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