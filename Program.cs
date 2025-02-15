using System;
namespace SyncHotel;

public class Program
{
  public static void Main(string[] args)
  {
    Operation operation = new Operation();
    //  operation.DefaultValues();
    operation.ReadCSVFile();
    operation.MainMenu();
    operation.WriteCSVFile();
  }
}
