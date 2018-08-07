
  
    
       
    string xPathText = ".//*[@id='main-app']/div[2]/div/div[2]/div[2]/div[2]/div/div/div/div[1]/form/div[7]/div/i";

    webDriver.FindElement(By.XPath(xPathText)).Click();


    CODE FOR DEALING WITH A DDL 

    Actions driverActions = new Actions(webDriver);
    driverActions.MoveToElement(webDriver.FindElement(By.XPath(xPathText))).
        SendKeys(Keys.ArrowDown).
        SendKeys(Keys.ArrowDown).
        SendKeys(Keys.Enter).
        Build().
        Perform();     
     
     
/*******************************/
CODE FOR DEALING WITH A MULTIPLE SELECTION LIST AS IN SIZE S/M/L


	switch (videoSize)
	{
		case 0: //Small
			{
				webDriver.FindElement(By.XPath(xPathText)).Click();

				helperUtilities.RandomPause(.5);

				Actions driverActions = new Actions(webDriver);
				driverActions.MoveToElement(webDriver.FindElement(By.XPath(xPathText))).
					SendKeys(Keys.Enter).
					Build().
					Perform();

				helperUtilities.RandomPause(.5);

				break;
			}
		case 1:// Medium
			{
				webDriver.FindElement(By.XPath(xPathText)).Click();

				helperUtilities.RandomPause(.5);

				Actions driverActions = new Actions(webDriver);
				driverActions.MoveToElement(webDriver.FindElement(By.XPath(xPathText))).
					SendKeys(Keys.ArrowDown).
					SendKeys(Keys.Enter).
					Build().
					Perform();

				helperUtilities.RandomPause(.5);

				break;
			}
		default: //Large
			{
				webDriver.FindElement(By.XPath(xPathText)).Click();

				helperUtilities.RandomPause(.5);

				Actions driverActions = new Actions(webDriver);
				driverActions.MoveToElement(webDriver.FindElement(By.XPath(xPathText))).
					SendKeys(Keys.ArrowDown).
					SendKeys(Keys.ArrowDown).
					SendKeys(Keys.Enter).
					Build().
					Perform();

				helperUtilities.RandomPause(.5);

				break;
			}
	}//EOsw

	