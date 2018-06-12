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
      EpochTime.Text = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
    }

    private void Click_convert(object sender, EventArgs e)
    {
      string sendForConversion = inputEpochTxt.Text;
      outPutDateTxt.Text = Convert(sendForConversion);
    }

    private void Click_clear(object sender, EventArgs e)
    {
      inputEpochTxt.Text = "Enter the Epoch String here";
      outPutDateTxt.Text = string.Empty;
    }

    private string Convert(string incommingText)
    {
      bool goodToGo = false;
      Int64 outCome;
      goodToGo = Int64.TryParse(incommingText, out outCome);
      if (goodToGo)
      {
        if (outCome >= 1451606400) // Epoch greater than 2016 or fails
        {
          if (outCome < 1000000000000) // Adds milliseconds if not already added.
          {
            outCome = outCome * 1000;
          }
          var dtAsString = DateTimeOffset.FromUnixTimeMilliseconds(outCome).DateTime.ToLocalTime();
          incommingText = dtAsString.ToString("yyyy-MM-dd ~ HH:mm:ss");
        }
      }
      else
      {
        incommingText = "Not Epoch Time";
      }
      return incommingText;
    }

  }
}