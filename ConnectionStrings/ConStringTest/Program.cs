using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStringTest
{
  class Program
  {
    static void Main(string[] args)
    {
      string stemenPwd = "fxQ46KAeGAaX3ZfGid7vwWF;";
      string sbs = "sstemen;"; //sstemen
      string QAAutoPwd = "RcYBszMT3gPHXLT;"; //QA_Automation
      string qaa = "QA_Automation;";
      string[] emptyStudent = new string[5];
      int returnedSectionIdNumber = 0;
      //      string sqlConnn = "Server=lms-qa.database.windows.net; Database=lms-qa-primary; user id=QA_Automation@lms-qa; password=πRcYBszMT3gPHXLT";


      // string sqlConnn = "Server=lms-qa.database.windows.net; Initial Catalog=lms-qa-primary; user id=QA_Automation; password=πRcYBszMT3gPHXLT; ApplicationIntent=READONLY";

      string sqlConnn =
        "Server=lms-qa.database.windows.net; Database=lms-qa-primary; ApplicationIntent = READONLY; user id=" +
        qaa +
        "password=" +
        QAAutoPwd;


      string sqlQuery = "SELECT Top 1 S.Id FROM LMS.Section AS S Order By Id DESC;";


      using (SqlConnection connect = new SqlConnection(sqlConnn))
      {
        SqlCommand command = new SqlCommand(sqlQuery, connect);
        connect.Open();
        using (SqlDataReader readMe = command.ExecuteReader())
        {
          while (readMe.Read())
          {
            returnedSectionIdNumber = Convert.ToInt32(readMe.GetValue(0));
          }
        }
      }

      Console.WriteLine("The Section ID number is an INT == {0} ", returnedSectionIdNumber);
      Console.ReadLine();
    }
  }
}
