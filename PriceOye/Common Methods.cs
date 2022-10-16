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
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;

namespace PriceOye
{
    public class Common_Methods
    {
        public static IWebDriver commonDriver;
        Actions Action;

        #region For Driver
        public static IWebDriver Driver(string driver)
        {
            if (driver == "Chrome")
            {
                commonDriver = new ChromeDriver();
            }
            else if (driver == "firefox")
            {
                commonDriver = new FirefoxDriver();
            }
            else if ( driver == "Edge")
            {
                commonDriver = new EdgeDriver();
            }
            return commonDriver;
        }

        #endregion

        #region Find Element

        public IWebElement findElement(By Locate)
        {
            return (IWebElement)commonDriver.FindElement(Locate);

        }
        #endregion

        #region SendTextInput Field

        public void setText(By locate, string text)
        {
            IWebElement findedElement = findElement(locate);
            findedElement.Clear();
            //removeText(findedElement);
            findedElement.SendKeys(text + Keys.Tab);

        }
        #endregion

        #region Click on the Element
        public void CLick(By locator)
        {
            Action = new Actions(commonDriver);
            Action.Click(findElement(locator)).Build().Perform();  

        }
        #endregion


        #region Reomove Text
        public void removeText(IWebElement element)
        {
            int a = element.Text.Length;

            while (a > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }
        #endregion

        #region DriverClose
        public static void ForClose()
        {
            commonDriver.Close();
        }
        #endregion

        #region Sleep
        public static void ForSleep(int time)
        {
            Thread.Sleep(time);

        }
        #endregion

        #region For URL

        public void FOrUrl(string url)
        {
            commonDriver.Url = url;
        }
        #endregion

        #region GetElementText
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
        #endregion

        #region GetElement STate
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
        #endregion


        //ExecuteJavaScriptCode
        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)commonDriver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }




        #region Wait for Element
        public IWebElement WaitForELement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    //PlaybackWait(timeToReadyElement * 1000);
                    timeToReadyElement = timeToReadyElement * 1000;
                }
                element = commonDriver.FindElement(by);
            }
            catch
            {
                WebDriverWait wait = new WebDriverWait(commonDriver, TimeSpan.FromSeconds(60));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = commonDriver.FindElement(by);
            }
            return element;
        }
        #endregion

        #region Element Visible
        public bool IsElementVisible(By by)
        {
            return(findElement(by).Displayed || findElement(by).Enabled) ? true : false;
            
        }
        #endregion


        #region IS PAge Ready
        public bool IsPageReady(IWebDriver driver)
        {
           return ExecuteJavaScriptCode("return document.readyState").Equals("complete");
        }
        #endregion

       

       #region Element Present
        public bool IsElementPresent(By by)
        {
            try
            {
                commonDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion


        #region Clickable
        public bool IsClickable(By by)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region Scroll Down
        public void scrollToElement(By locator)
        {


            IWebElement state = WaitForELement(locator);
            IJavaScriptExecutor commonExecuter = (IJavaScriptExecutor)commonDriver;
            commonExecuter.ExecuteScript("arguments[0].scrollIntoView(true); ", state);


        }
        #endregion



        #region For DropDown ELement
        public void dropDown(By locator, string a)
        {
            SelectElement drop = new SelectElement(commonDriver.FindElement(locator));
            drop.SelectByValue(a);
        }
        #endregion


        #region FOr Zoom OUt

        public void FOrZoomOUt()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)commonDriver;
            js.ExecuteScript("document.body.style.zoom='50%'");
        }
        #endregion

        #region For Screen SHot
        public void ScreenSHot(string File)
        {
            ((ITakesScreenshot)commonDriver).GetScreenshot().SaveAsFile(File);
        }
        #endregion
    }


    

}

