using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SyncHotel
{
    public static class FileHandler<Type>
    {
        //static folder feild to store the foolder location 
        public static string folder;

        //static Method is used to create the folder or to check if it is exist 
        public static void CreateFolder()
        {
            folder = new Program().GetType().Namespace;
            if (!Directory.Exists(folder))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory(folder);
            }
        }
        ////static Method is used to create the file or to check if it is exist 
        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Creating File");
                File.Create(filePath).Close();
            }
        }

        //static method ReadCSVFile is used to read the Data from the CSV file
        public static void ReadCSVFile(CustomList<Type> list)
        {

            CreateFolder();
            string filePath = $"{folder}/{typeof(Type)}.csv";
            CreateFile(filePath);
            string[] values = File.ReadAllLines(filePath);
            PropertyInfo[] info = typeof(Type).GetProperties();

            foreach (var value in values)
            {
                string[] datas = value.Split(",");
                Type obj = Activator.CreateInstance<Type>();
                for (int i = 0; i < info.Length; i++)
                {
                    if (datas[i] != "")
                    {
                        if (info[i].PropertyType == typeof(DateTime))
                        {
                            info[i].SetValue(obj, DateTime.ParseExact(datas[i], "dd/MM/yyyy HH:mm:ss", null));
                        }
                        else if (info[i].PropertyType.IsEnum)
                        {
                            Enum.TryParse(info[i].PropertyType, datas[i], true, out object result);
                            info[i].SetValue(obj, result);
                        }
                        else
                        {
                            object typeChanged = Convert.ChangeType(datas[i], info[i].PropertyType);
                            info[i].SetValue(obj, typeChanged);
                        }
                    }
                }
                list.Add(obj);
            }

        }

        //static method WriteCSVFile is used to Write the Data from the CSV file
        public static void WriteCSVFile(CustomList<Type> list)
        {
            CreateFolder();
            string filePath = $"{folder}/{typeof(Type)}.csv";
            CreateFile(filePath);
            PropertyInfo[] properties = typeof(Type).GetProperties();
            List<string> row = new();
            foreach (Type values in list)
            {
                List<string> column = new();
                foreach (PropertyInfo info in properties)
                {

                    if (info.PropertyType == typeof(DateTime))
                    {
                        column.Add(((DateTime)info.GetValue(values)).ToString("dd/MM/yyyy HH:mm:ss"));
                    }
                    else
                    {
                        column.Add(info.GetValue(values).ToString());
                    }
                }
                row.Add(string.Join(',', column));
            }
            File.WriteAllLines(filePath, row);
        }
    }
}