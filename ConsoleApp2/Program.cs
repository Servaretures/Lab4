using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class MeteData
    {
        public string Data {get; set;}
        public float Tempreture { get; set; }
        public int AtmospherePressure  { get; set; }
        public MeteData(string Data,float Temp,int Atmosphere)
        {
            this.Data = Data;
            Tempreture = Temp;
            AtmospherePressure = Atmosphere;
        }
        public MeteData()
        {
            this.Data = "";
            Tempreture = 0;
            AtmospherePressure = 0;
        }
    }
    public class Student
    {
        //private String LastName, Group, Year, Adrees, Passport, Age, Telephon;
        //private int Ratig;
        public string lastname { get; set; }
        public string group { get; set; }
        public string adrees { get; set; }
        public string passport { get; set; }
        public string age { get; set; }
        public string telephon { get; set; }
        public int rating { get; set; }
        public string StudentRating(int R)
        {
            if (R > 90)
            {
                Console.WriteLine("Вітаємо відмінника");
                return "Вітаємо відмінника";
            }
            string s = (R > 75) ? ("Можна вчитися краще") : ("Варто більше уваги приділяти навчанню");
            Console.WriteLine(s);
            return s;
        }
    }
    public class Goods
    {
        public int InventeralNum { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public int Count { get; set; }

    }
    public class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Enter number of the task \n1)Stud Rating\n2)Meteo Date\n3)Goods storage");
            char d = '1';
            if ((d = (Char)Console.ReadKey().KeyChar) == '1')
            {
                Console.WriteLine();
                task1();
            }
            if (d == '2')
            {
                Console.WriteLine();
                task2();
            }
            if (d == '3')
            {
                Console.WriteLine();
                task3();
            }

            Console.WriteLine((Char)Console.ReadKey().KeyChar);
        }
        static void task1()
        {
            Student s = new Student();
            Console.WriteLine("Enter rating");
            s.rating = Convert.ToInt16(Console.ReadLine());
            s.StudentRating(s.rating);
        }
        static void task2()
        {
            MeteData Day5 = new MeteData("23.05.2020", 16, 737);
            MeteData Day4 = new MeteData("19.05.2020", 19, 730);
            MeteData Day3 = new MeteData("16.05.2020", 16, 748);
            MeteData Day1 = new MeteData("21.05.2020",17,747);
            MeteData Day2 = new MeteData("14.05.2020", 14, 740);
            MeteData Day6 = new MeteData("30.05.2020", 10, 737);
            MeteData Day7 = new MeteData("11.05.2020", 11, 730);
            MeteData Day8 = new MeteData("05.05.2020", 34, 707);
            MeteData Day9 = new MeteData("10.05.2020", 15, 732);
            MeteData Day10 = new MeteData("01.05.2020", 20, 750);
            List<MeteData> Days = new List<MeteData>();
            Days.Add(Day1); Days.Add(Day2); Days.Add(Day3); Days.Add(Day4); Days.Add(Day5);
            Days.Add(Day6); Days.Add(Day7); Days.Add(Day8); Days.Add(Day9); Days.Add(Day10);
            //Sorting
            MeteData Most = Day1;
            MeteData Less = Day1;
            for(int i =0; i < Days.Count; i++)
            {
                

                for (int k = 0; k < Days.Count; k++)
                {
                    if (Most.AtmospherePressure < Days[k].AtmospherePressure)
                    {
                        Most = Days[i];
                    }
                    if (Less.AtmospherePressure > Days[k].AtmospherePressure)
                    {
                        Less = Days[i];
                    }
                    if (Days[i].AtmospherePressure > Days[k].AtmospherePressure)
                    {
                        MeteData temp = Days[k];
                        Days[k] = Days[i];
                        Days[i] = temp;
                    }
                }
            }
            Console.WriteLine("Date      |Temperature | Atmosphere Pressure");
            for (int i = 0;i < Days.Count; i++)
            {
               Console.WriteLine(Days[i].Data + "|" + Days[i].Tempreture + "          |" + Days[i].AtmospherePressure);
            }
            Console.WriteLine("\nThe greatest Atmosphere Pressure");
            Console.WriteLine(Most.Data + "|" + Most.AtmospherePressure);
            Console.WriteLine("The least Atmosphere Pressure");
            Console.WriteLine(Less.Data + "|" + Less.AtmospherePressure);
        }
        static void task3()
        {
            string path = "";
            List<Goods> goods = new List<Goods>();
            Console.WriteLine("Enter path to file like '' or enter any to create new file");
            path = Console.ReadLine();
            try
            {
                goods = ReadData(path);
            }
            catch
            {
                path = "Data.txt";
            }
            
            while (true)
            {
                Console.Clear();
                ShowTable(goods);
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    Main();
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    ChangeData(goods);
                    SaveData(goods,path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    Seach(goods);
                    SaveData(goods, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    AddNew(goods);
                    SaveData(goods, path);
                }
                if (press.ToString() == "S")
                {
                    Console.WriteLine();
                    Sort(goods);
                    SaveData(goods, path);
                }
                //C:/Users/Макс/Desktop/Data.txt
            }

        }
        static string PS(int count)
        {
            string s = "";
            for(int i = 0;i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        static void ShowTable(List<Goods> Goods)
        {
            int MaxI = 8;
            int MaxN = 12;
            int MaxW = 8;
            int MaxC = 7;
            Console.WriteLine("| Number |    Name    | Weight | Count |");
            foreach(Goods g in Goods)
            {
                int ni = MaxI - Convert.ToString(g.InventeralNum).Length;
                int nn = MaxN - g.Name.Count();
                int nw = MaxW - Convert.ToString(g.Weight).Length;
                int nc = MaxC - Convert.ToString(g.Count).Length;
                Console.WriteLine("|" + Convert.ToString(g.InventeralNum) + PS(ni) + "|" + g.Name + PS(nn) + "|" +
                    Convert.ToString(g.Weight) + PS(nw) + "|" + Convert.ToString(g.Count) + PS(nc) + "|");
            }
            Console.WriteLine(" p - Edit/Delete,\n d - Create\n s- Sort by weight \n n - search,\n Enter - exit");
        }
        static List<Goods> ReadData(string path)
        {
            List<Goods> g = new List<Goods>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Dates = text.Split('/');
            foreach(string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if(MetaDete.Length > 3)
                {
                    Goods d = new Goods
                    {
                        InventeralNum = Convert.ToInt32(MetaDete[0]),
                        Name = MetaDete[1],
                        Weight = Convert.ToInt32(MetaDete[2]),
                        Count = Convert.ToInt32(MetaDete[3]),
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        static void SaveData(List<Goods> Data,string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Goods g in Data)
                {

                    sw.WriteLine(g.InventeralNum + "|" + g.Name + "|" + g.Weight + "|" + g.Count + "/");

                }
            }
        }
        static void ChangeData(List<Goods> Data)
        {
            Console.WriteLine("Enter Name of good that`s need to change");
            string Nam = Console.ReadLine();
            Goods Choosen = new Goods();
            foreach(Goods g in Data)
            {
                if(g.Name == Nam)
                {
                    Choosen = g;
                }
            }
            if(Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Change Number\n2)Change Name\n3)Change Weight\n4)Change Count\n5)Delete");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                try
                {
                    if (key == '1')
                    {

                        Choosen.InventeralNum = Convert.ToInt32(Console.ReadLine());
                    }
                    if (key == '2')
                    {

                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '3')
                    {

                        Choosen.Weight = Convert.ToInt32(Console.ReadLine());
                    }
                    if (key == '4')
                    {
                        Choosen.Count = Convert.ToInt32(Console.ReadLine());
                    }
                    if (key == '5')
                    {
                        Data.Remove(Choosen);
                    }
                }
                catch
                {
                    Console.WriteLine("New value is incorrect");
                }
               
            }
            else
            {
                Console.WriteLine("Goods Not found");
            }
            
        }
        static void AddNew(List<Goods> Data)
        {
            Console.WriteLine("Enter Inventary Number");
            Goods neww = new Goods();
            neww.InventeralNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Enter Weight");
            neww.Weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Count");
            neww.Count = Convert.ToInt32(Console.ReadLine());
            Data.Add(neww);
        }
        static void Seach(List<Goods> Data)
        {
            int MaxI = 8;
            int MaxN = 12;
            int MaxW = 8;
            int MaxC = 7;
            Console.Clear();
            Console.WriteLine("Enter name of object tat`s you want to find");
            string s = Console.ReadLine();
            foreach (Goods g in Data)
            {
                
                if (g.Name == s)
                {
                    int ni = MaxI - Convert.ToString(g.InventeralNum).Length;
                    int nn = MaxN - g.Name.Count();
                    int nw = MaxW - Convert.ToString(g.Weight).Length;
                    int nc = MaxC - Convert.ToString(g.Count).Length;
                    Console.WriteLine("| Number |    Name    | Weight | Count |");
                    Console.WriteLine("|" + Convert.ToString(g.InventeralNum) + PS(ni) + "|" + g.Name + PS(nn) + "|" +
                    Convert.ToString(g.Weight) + PS(nw) + "|" + Convert.ToString(g.Count) + PS(nc) + "|");
                }
            }
            Console.WriteLine("Press any key to back into table");
            Console.ReadLine();
        }
        static void Sort(List<Goods> Data)
        {
            for(int i = 0;i < Data.Count; i++)
            {
                for (int k = 0; k < Data.Count; k++)
                {
                    if(Data[i].Weight > Data[k].Weight)
                    {
                        Goods temp = Data[k];
                        Data[k] = Data[i];
                        Data[i] = temp;
                    }
                }
            }
        }
    }
}
