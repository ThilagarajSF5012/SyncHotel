using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// Class Grid <see cref="Grid<Type>"/> is to print the Custom List of data  
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public class Grid<Type>
    {
        //printtable metod is used to print the list of datas in the list
        public static void PrintTable(CustomList<Type> list)
        {

            PropertyInfo[] info = typeof(Type).GetProperties();
            string border = new string('-', info.Length * 18);
            Console.WriteLine(border);
            foreach (PropertyInfo property in info)
            {
                Console.Write($"| {property.Name,-16}");
            }
            Console.WriteLine("|\n" + border);
            foreach (Type data in list)
            {
                foreach (PropertyInfo property in info)
                {
                    if (property.CanRead)
                    {
                        if (property.PropertyType == typeof(DateTime))
                        {
                            Console.Write($"| {((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy"),-16}");
                        }
                        else
                        {
                            Console.Write($"| {property.GetValue(data),-16}");
                        }

                    }
                }
                Console.Write("|\n");
            }
            Console.WriteLine(border);
        }
    }
}