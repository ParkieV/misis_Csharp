namespace Lab6
{

    public class Program1_2
    {
        public class Woman
        {
            public string surname;
            public string group;
            public string surnameTeacher;
            public string result;
            public bool pass;

            static public int resultInt(string result)
            {
                string[] timeStr = result.Split(":");
                int[] timeInt = new int[3];
                for (int i = 0; i < timeStr.Length;
                    i++)
                {
                    timeInt[i] = int.Parse(timeStr[i]);
                }
                if (timeInt.Length == 3)
                {
                    return timeInt[0] * 3600 + timeInt[1] * 60 + timeInt[2];
                }
                else if (timeInt.Length == 2)
                {
                    return timeInt[0] * 60 + timeInt[1];
                }
                else if (timeInt.Length == 1)
                {
                    return timeInt[0];
                }
                return 0;
            }
            public Woman(string surname, string group, string surnameTeacher, string result, bool pass)
            {
                this.surname = surname;
                this.group = group;
                this.surnameTeacher = surnameTeacher;
                this.result = result;
                this.pass = pass;
            }
            public Woman()
            {
                this.surname = "";
                this.group = "";
                this.surnameTeacher = "";
                this.result = "";
                this.pass = false;
            }
        }

        static public void sortMas(Woman[] women)
        {
            for (int i = 0; i < women.Length; i++)
            {
                for (int j = i + 1; j < women.Length; j++)
                {
                    if (Woman.resultInt(women[i].result) < Woman.resultInt(women[j].result))
                    {
                        Woman temp = women[i];
                        women[i] = women[j];
                        women[j] = temp;
                    }
                }
            }
        }

        static public void OutputMas(Woman[] women)
        {
            for (int i = 0; i < women.Length; i++)
            {
                if (women[i].pass)
                {
                    Console.WriteLine($"{women[i].surname}\t{women[i].group}\t{women[i].surnameTeacher}\t{women[i].result}\tСдала");
                }
                else
                {
                    Console.WriteLine($"{women[i].surname}\t{women[i].group}\t{women[i].surnameTeacher}\t{women[i].result}\tНе сдала");
                }
            }
        }
        static public void Loop()
        {
            int n;
            Console.WriteLine("Введите количество девушек: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите необходимое время для сдачи норматива: ");
            string resultTime = Console.ReadLine();
            Woman[] women = new Woman[n];
            for (int i = 0; i < n; i++)
            {
                Woman woman = new Woman();
                Console.WriteLine("Введите фамилию ученицы: ");
                woman.surname = Console.ReadLine();
                Console.WriteLine("Введите группу ученицы: ");
                woman.group = Console.ReadLine();
                Console.WriteLine("Введите фамилию преподавателя: ");
                woman.surnameTeacher = Console.ReadLine();
                Console.WriteLine("Введите результат ученицы: ");
                woman.result = Console.ReadLine();
                if (Woman.resultInt(resultTime) >= Woman.resultInt(woman.result))
                {
                    woman.pass = true;
                }
                else
                {
                    woman.pass = false;
                }
                women[i] = woman;
            }
            sortMas(women);
            Console.WriteLine("\n Упорядоченная таблица результатов");
            OutputMas(women);
        }
    }

    public class Program1_3
    {
        public class Answer
        {
            public string name;
            public int votes;

            public Answer(string nameStr, int votesInt)
            {
                this.name = nameStr;
                this.votes = votesInt;
            }
        }

        static public void Loop()
        {
            int n;
            Console.Write("Введите количество ответов: ");
            n = int.Parse(Console.ReadLine());
            Answer[] answersMas = new Answer[n];
            string[,] answers = new string[n, 2];
            int acc = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ответ {i + 1}-го человека: ");
                string temp = Console.ReadLine();
                bool onMas = false;
                for (int j = 0; j < acc; j++)
                {
                    if (temp == answers[j, 0])
                    {
                        int tempNum = int.Parse(answers[j, 1]) + 1;
                        answers[j, 1] = tempNum.ToString();
                        onMas = true;
                        break;
                    }
                }
                if (!onMas)
                {
                    answers[acc, 0] = temp;
                    answers[acc, 1] = "1";
                    acc++;
                }
            }
            int sum = 0;
            for (int i = 0; i < acc; i++)
            {
                answersMas[i] = new Answer(answers[i, 0], int.Parse(answers[i, 1]));
                sum += int.Parse(answers[i, 1]);
            }
            for (int i = 0; i < acc; i++)
            {
                for (int j = i + 1; j < acc; j++)
                {
                    if (answersMas[i].votes < answersMas[j].votes)
                    {
                        Answer temp = answersMas[i];
                        answersMas[i] = answersMas[j];
                        answersMas[j] = temp;
                    }
                }
            }
            Console.WriteLine("Топ 5 по количеству набранных голосов:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{answersMas[i].name}\t{answersMas[i].votes * 100 / sum}%"); ;
            }
        }
    }

    public class Program1_4
    {
        public class Jumper
        {
            public string name;
            public double firstTry;
            public double secondTry;

            public Jumper(string nameJumper, double first, double second)
            {
                this.name = nameJumper;
                this.firstTry = first;
                this.secondTry = second;
            }
        }

        static public double Max(Jumper jumper)
        {
            if (jumper.firstTry > jumper.secondTry)
            {
                return jumper.firstTry;
            }
            else
            {
                return jumper.secondTry;
            }
        }

        static public void SortMas(Jumper[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (Max(mas[i]) < Max(mas[j]))
                    {
                        Jumper temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
        }

        static public void Loop()
        {
            int n;
            Console.Write("Введите количество участников: ");
            n = int.Parse(Console.ReadLine());
            Jumper[] mas = new Jumper[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите результаты {i + 1}-го участника: ");
                mas[i] = new Jumper(Console.ReadLine(), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            }
            SortMas(mas);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{mas[i].name}\t{mas[i].firstTry}\t{mas[i].secondTry}");
            }
        }
    }

    public class Program3_1
    {
        public class Student
        {
            public int firstExam;
            public int secondExam;
            public int thirdExam;
            public int fourExam;
            public int fiveExam;

            public Student(int first, int second, int third, int four, int five)
            {
                this.firstExam = first;
                this.secondExam = second;
                this.thirdExam = third;
                this.fourExam = four;
                this.fiveExam = five;
            }
        }

        public class Group
        {
            public string name;
            public Student[] students;
            public double avgMark;
        }

        static public void Loop()
        {
            int[] n = new int[3];
            Console.WriteLine("Введите количество студентов в группе: ");
            n[0] = int.Parse(Console.ReadLine());
            Group[] groups = new Group[3];
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"\n{i + 1} группа");
                double avg = 0;
                Group group = new Group();
                group.students = new Student[n[0]];
                for (int j = 0; j < group.students.Length; j++)
                {
                    Console.WriteLine($"Введите оценки {j + 1} ученика");
                    group.students[j] = new Student(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    avg += group.students[j].firstExam;
                    avg += group.students[j].secondExam;
                    avg += group.students[j].thirdExam;
                    avg += group.students[j].fourExam;
                    avg += group.students[j].fiveExam;
                }
                group.avgMark = (avg / 5) / group.students.Length;
                group.name = $"{i + 1} группа";
                groups[i] = group;
                Console.WriteLine("");
            }
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = i + 1; j < groups.Length; j++)
                {
                    if (groups[i].avgMark < groups[j].avgMark)
                    {
                        Group temp = groups[i];
                        groups[i] = groups[j];
                        groups[j] = temp;
                    }
                }
            }
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"{groups[i].name}\t{groups[i].avgMark}");
            }
        }
    }

    public class Program3_2
    {
        public class Match
        {
            public int firstGoals;
            public int secondGoals;

            public Match()
            {
                Random r = new Random();
                this.firstGoals = r.Next() % 3;
                this.secondGoals = r.Next() % 3;
            }
        }
        public class Team
        {
            public string name;
            public int sumGoal;

            public Team(string teamName, int teamGoals)
            {
                this.name = teamName;
                this.sumGoal = teamGoals;
            }
        }

        static public void Loop()
        {
            int n = 12;
            Team[] teams = new Team[n];
            int[] sumGoals = new int[n];
            for (int i = 0; i < n; i++)
            {
                sumGoals[i] = 0;
            }
            Match temp = new Match();
            sumGoals[0] += temp.firstGoals;
            sumGoals[1] += temp.secondGoals;
            temp = new Match();
            sumGoals[0] += temp.firstGoals;
            sumGoals[2] += temp.secondGoals;
            temp = new Match();
            sumGoals[0] += temp.firstGoals;
            sumGoals[3] += temp.secondGoals;
            temp = new Match();
            sumGoals[1] += temp.firstGoals;
            sumGoals[2] += temp.secondGoals;
            temp = new Match();
            sumGoals[1] += temp.firstGoals;
            sumGoals[3] += temp.secondGoals;
            temp = new Match();
            sumGoals[2] += temp.firstGoals;
            sumGoals[3] += temp.secondGoals;
            temp = new Match();
            sumGoals[4] += temp.firstGoals;
            sumGoals[5] += temp.secondGoals;
            temp = new Match();
            sumGoals[6] += temp.firstGoals;
            sumGoals[7] += temp.secondGoals;
            temp = new Match();
            sumGoals[8] += temp.firstGoals;
            sumGoals[9] += temp.secondGoals;
            temp = new Match();
            sumGoals[10] += temp.firstGoals;
            sumGoals[11] += temp.secondGoals;

            teams[0] = new Team("1 команда", sumGoals[0]); teams[1] = new Team("2 команда", sumGoals[1]); teams[2] = new Team("3 команда", sumGoals[2]); teams[3] = new Team("4 команда", sumGoals[3]); teams[4] = new Team("5 команда", sumGoals[4]); teams[5] = new Team("6 команда", sumGoals[5]); teams[6] = new Team("7 команда", sumGoals[6]); teams[7] = new Team("8 команда", sumGoals[7]); teams[8] = new Team("9 команда", sumGoals[8]); teams[9] = new Team("10 команда", sumGoals[9]); teams[10] = new Team("11 команда", sumGoals[10]); teams[11] = new Team("12 команда", sumGoals[11]);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (teams[i].sumGoal < teams[j].sumGoal)
                    {
                        Team tempTeam = teams[i];
                        teams[i] = teams[j];
                        teams[j] = tempTeam;
                    }
                }
            }
            Console.WriteLine("Номер команды\tочки");
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{teams[i].name}\t{teams[i].sumGoal}");
            }
        }
    }

    public class Program3_3
    {
        public class Student
        {
            public string name;
            public int point;

            public Student(string name = "Вася", int pointStudent = 0)
            {
                this.name = name;
                this.point = pointStudent;
            }
            public Student(int pointStudent = 0)
            {
                this.name = "Вася";
                this.point = pointStudent;
            }
        }

        public class Group
        {
            public string name;
            public Student[] students = new Student[6];
            public int sumPoints;

            public Group(string nameGroup, Student[] mas, int num)
            {
                this.name = nameGroup;
                this.students = mas;
                this.sumPoints = num;
            }
        }


        static public void Loop()
        {
            int n = 18;
            Random random = new Random();
            Student[] students3 = new Student[6] { new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15) };
            Student[] students1 = new Student[6] { new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15) };
            Student[] students2 = new Student[6] { new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15), new Student(random.Next() % 15) };
            Group[] groups = new Group[3];
            int sum3 = students3[0].point + students3[1].point + students3[2].point + students3[3].point + students3[4].point + students3[5].point;
            int sum1 = students1[0].point + students1[1].point + students1[2].point + students1[3].point + students1[4].point + students1[5].point;
            int sum2 = students2[0].point + students2[1].point + students2[2].point + students2[3].point + students2[4].point + students2[5].point;
            groups[0] = new Group("1", students1, sum1);
            groups[1] = new Group("2", students2, sum2);
            groups[2] = new Group("3", students3, sum3);
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = i + 1; j < groups.Length; j++)
                {
                    if (groups[i].sumPoints < groups[j].sumPoints)
                    {
                        Group tempGroup = groups[i];
                        groups[i] = groups[j];
                        groups[j] = tempGroup;
                    }
                    else if (groups[i].sumPoints == groups[j].sumPoints)
                    {
                        if (groups[j].students[0].point == 5 || groups[j].students[1].point == 5 || groups[j].students[2].point == 5 || groups[j].students[3].point == 5 || groups[j].students[4].point == 5 || groups[j].students[5].point == 5)
                        {
                            Group tempGroup = groups[i];
                            groups[i] = groups[j];
                            groups[j] = tempGroup;
                        }
                    }
                }
            }
            Console.WriteLine("Команда\tИмя\tБалл");
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups[i].students.Length; j++)
                    Console.WriteLine($"{groups[i].name}\t{groups[i].students[j].name}\t{groups[i].students[j].point}");
            }
            Console.WriteLine("");
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"{groups[i].name}-я команда набрала {groups[i].sumPoints} очков");
            }
            Console.WriteLine("");
            if (groups[0].sumPoints > groups[1].sumPoints)
            {
                if (groups[0].sumPoints > groups[2].sumPoints)
                {
                    Console.WriteLine($"Победила {groups[0].name}-я команда");
                }
                else
                {
                    Console.WriteLine($"Победила {groups[2].name}-я команда");
                }
            }
            else
            {
                if (groups[1].sumPoints > groups[2].sumPoints)
                {
                    Console.WriteLine($"Победила {groups[1].name}-я команда");
                }
                else
                {
                    Console.WriteLine($"Победила {groups[2].name}-я команда");
                }
            }
        }

    }


    public class Task6
    {
        static void Main(string[] args)
        {
            Program3_3.Loop();
        }
    }
}