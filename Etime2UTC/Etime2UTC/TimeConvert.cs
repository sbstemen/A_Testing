/******************************
 * Author Date 20180608 
 *  By Scott B. Stemen 
 *   Clock and EPOCH conversions
 *******************************/
using System;
using System.Windows.Forms;

namespace Etime2UTC
{
  public partial class TimeConvert : Form
  {
    public TimeConvert()
    {
      InitializeComponent();
    }

    private void Form1_Load_1(object sender, EventArgs e)
    {

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timelcl.Text = DateTime.Now.ToString("HH:mm:ss");
      timezulu.Text = DateTime.UtcNow.ToString("HH:mm:ss");
      datebox.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
      timeeast.Text = DateTime.UtcNow.AddHours(-4).ToString("HH:mm:ss");
      timehawaii.Text = DateTime.UtcNow.AddHours(-10).ToString("HH:mm:ss");
    }

    private void go_Click(object sender, EventArgs e)
    {
      string testforEpochValue = inputEpochTxt.Text;
      bool goodToGo = false;
      goodToGo = IsNumber(testforEpochValue);

      if(goodToGo)
      {
        Int64 outCome;
        bool ok = false;
        ok = Int64.TryParse(testforEpochValue, out outCome);
        string PutUp = HumanDate(outCome);
        outPutDateTxt.Text = PutUp;
      }
      else
      {
        inputEpochTxt.Text = string.Empty;
        inputEpochTxt.Text = "Enter Valid Epoch Number";
      }
      

    }

    private void clear_Click(object sender, EventArgs e)
    {
      inputEpochTxt.Text = string.Empty;
    }

    private string HumanDate(Int64 input)
    {

      var dtAsString = DateTimeOffset.FromUnixTimeMilliseconds(input).DateTime.ToLocalTime();
      return dtAsString.ToString("yyyy-MM-dd ~ HH:mm:ss");
    }
    private bool IsNumber(string testThis)
    {
      bool okNumber = false;

      try
      {
        double numberTest = Convert.ToDouble(testThis);
        okNumber = true;
      }
      catch(Exception exText)
      {
        outPutDateTxt.Text = "That is not a valid Epoch Number";
      }

      return okNumber;
    }
  }
}