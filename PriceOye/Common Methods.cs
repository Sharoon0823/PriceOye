using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace PriceOye
{
    public class Common_Method
    {
        public static IWebDriver commonDriver;
        Actions Action;

        public static IWebDriver driver(string driver)
        {
            if (driver == "Chrome")
            {
                commonDriver = new ChromeDriver();
            }
            else if (driver == "firefox")
            {
                commonDriver = new FirefoxDriver();
            }
            return commonDriver;
        }


        #region frequent_methods


        //Find Element

        public IWebElement findElement(By Locate)
        {
            return commonDriver.FindElement(Locate);

        }




        //RemoveText


        //SendTextInput Field

        public void setText(By locate, string text)
        {
            IWebElement findedElement = findElement(locate);
            findedElement.Clear();
            //removeText(findedElement);
            findedElement.SendKeys(text + Keys.Tab);

        }

        //Click on the Element

        public void CLick(By locator)
        {
            Action = new Actions(commonDriver);
            Action.Click(findElement(locator)).Build().Perform();  

        }


        //Reomove Text
        public void removeText(IWebElement element)
        {
            int a = element.Text.Length;

            while (a > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }


        public static void ForClose()
        {
            commonDriver.Close();
        }

        public static void ForSleep()
        {
            Thread.Sleep(5000);

        }

        //For URL

        public void FOrUrl(string url)
        {
            commonDriver.Url = url;
        }


        
        public string getElementText(By Locator)
        {
            string text;
            try
            {
                text = findElement(Locator).Text;
            }
            catch
            {
                try
                {
                    text = findElement(Locator).GetAttribute("Value");
                }
                catch
                {
                    text = findElement(Locator).GetAttribute("innerHTML");
                }
            }
            return text;
        }


        //GetElement STate
        public string getElementState(By by)
        {
            string elementState = commonDriver.FindElement(by).GetAttribute("Disabled");
            if(elementState == null)
            {
                elementState = "enabled";
            }
            else if(elementState == "true")
            {
                elementState = "disabled";
            }
            return elementState;
        }
}

        #endregion
        
    }

