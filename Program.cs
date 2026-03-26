using System;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Markup;
using ConsoleApp2;
using System.Data.SqlClient;

namespace ConsoleApp2
{


    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        void Introduce();

        void Print();

        string To_String();
    }


    public interface ICommunicate
    {

        void CallPhone();

        void SendEmail(string Title, string Body);

        void SendSMS(string Title, string Body);

        void SendFax(string Title, string Body);

    }


    public abstract class Person 

    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual void Introduce()
        {

        }
        public void Print()
        {

        }

        public string To_String()
        {
            return "hello";
        }
       


      
    }


    public  class Employee : Person
    {
        public int EmployeeId { get; set; }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, my name is {FirstName} {LastName}, and my employee ID is {EmployeeId}.");
        }
       


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Create object from class
            string ConnactionString = "Server=.;Database=HR_Database;User Id=sa;Password=sa123456";
            DataSet DataSet= new DataSet();
            string quary = "SELECT * FROM HR_Database";
           SqlDataAdapter DataAdapter=new SqlDataAdapter(quary,ConnactionString);

           SqlConnection connaction=new SqlConnection(ConnactionString);

            connaction.Open();

            DataAdapter.SelectCommand.Connection = connaction;


            DataAdapter.Fill(DataSet, "Employees");
            connaction.Close();


            DataTable Coustomers = DataSet.Tables["Employees"];

            foreach(DataRow row in Coustomers.Rows)
            {
                Console.WriteLine("FirstName{0}", row["FirstName"]);
            }









            Console.ReadKey();


        }
    }
}

