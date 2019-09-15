using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis
{
  class Program
  {
    static void Main(string[] args)
    {
      int n1 = 10;
      int n2 = 25;
      Student s1 = new Student();
      Student s2 = new Student();
      Student s3 = new Student();

      s1.FirstName = "Harry";
      s2.FirstName = "Ron";
      s3.FirstName = "Hermione";
      s1.LastName = "Potter";
      s2.LastName = "Weasley";
      s3.LastName = "Granger";
      s1.CourseFocus = "Flying";
      s2.CourseFocus = "NOT crashing";
      s3.CourseFocus = "Potions";

      Console.WriteLine("First = {0}", s1);
      Console.WriteLine("Next Is = {0}", s2);
      Console.WriteLine("Last but best = {0}", s3);

      Console.WriteLine(Math.Pow(n1, n2));

      Console.WriteLine("\n\nThe the the... end!\n\n");
    }
  }
  public class Student
  {
    string firstName = "";
    string lastName = "";
    string courseFocus = "";
    public string FirstName { get { return firstName; } set { firstName = value; } }
    public string LastName { get { return lastName; } set { lastName = value; } }
    public string CourseFocus { get { return courseFocus; } set { courseFocus = value; } }

    public override string ToString()
    {
      return firstName + " " + lastName + " has the Course Focus of " + courseFocus;
    }

    public Student()
    {
      Console.WriteLine("WE Be Creatin Classes now buddy!!");
      firstName = string.Empty;
      lastName = string.Empty;
      courseFocus = string.Empty;
    }

    public Student(string first, string last, string focus)
    {
      this.courseFocus = focus;
      this.firstName = first;
      this.lastName = last;

      Console.WriteLine(firstName + " " + lastName + " is studying " + courseFocus);
    }

  }
}
