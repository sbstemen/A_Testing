      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)  // THIS is an infinate lop
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > 3000) // check 
          {
            break; // to the existing code
          }
          else
          {
            sw.Start(); // continue looping and resume time measurement
          }
        }
      }

      /*
      
      The opening For loop looks wrong. 
      For(int i=0;  ;i++)  // Missing the middle element right.  
      BUT 
      The inside IF 
    for (int i = 0; ; i++) 
      {
        if (i % 100000 == 0) // Gets executed before this check happens and this is the i < X value 
        {
            This Code is Executed. 
        }
      }
      
      
       */