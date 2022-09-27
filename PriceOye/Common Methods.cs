using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PriceOye
{
    public class Common_Method
    {
        public static IWebDriver commonDriver;
        Actions Action;

        public static void driver(string driver)
        {
            if (driver == "Chrome")
            {
                 commonDriver = new  ChromeDriver();
            }
            else if (driver == "firefox")
            {
                commonDriver = new FirefoxDriver();
            }
        }


        #region frequent_methods


        //Find Element

        public IWebElement findElement(By Locate)
        {
            return commonDriver.FindElement(Locate);

        }

        //RemoveText


        //SendTextInput Field
        
        public void setText(By locate , string text)
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

            while(a> 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        #endregion
    }
}
