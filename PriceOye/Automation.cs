using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PriceOye
{
    [TestClass]

    public class Automation
    {

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestMethod]
        [TestCategory("ForLogin_Bat")]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Login_DataFilee.XML", "Login", DataAccessMethod.Sequential)]

        public void LoginButton_Valid()
        {

            string mNum = TestContext.DataRow["mNum"].ToString();

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-extensions");
            chromeOptions.AddArguments("disable-popup-blocking");
            chromeOptions.AddArguments("--silent");

            //IWebDriver aDriver = Common_Method.driver("firefox");
            IWebDriver aDriver = Common_Methods.Driver("Chrome");
            aDriver = new ChromeDriver(chromeOptions);


            aDriver.Manage().Window.Maximize();
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            aDriver.Url = "https://priceoye.pk/";

            Login OL = new Login(aDriver);
            OL.clickLoginButton();
            OL.EnterPhoneNumber(mNum);
            OL.ForOTPClick();
            Thread.Sleep(21000);
            OL.VerifyOtp();
            Thread.Sleep(4000);
            aDriver.Navigate().Refresh();
            ((ITakesScreenshot)aDriver).GetScreenshot().SaveAsFile("Login.png");
            aDriver.Close();
        }


        [TestMethod]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Login_DataFile.XML", "LoginWithInvalidUserInvalidPassword", DataAccessMethod.Sequential)]

        public void LoginButton_Invalid()
        {
            string mNum = TestContext.DataRow["Otp"].ToString();

            IWebDriver aDriver = Common_Methods.Driver("firefox");
            aDriver.Manage().Window.Maximize();
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            aDriver.Url = "https://priceoye.pk/";

            Login OL = new Login(aDriver);
            OL.clickLoginButton();
            Thread.Sleep(2000);
            OL.EnterPhoneNumber(mNum);
            Thread.Sleep(2000);
            OL.ForOTPClick();
            Thread.Sleep(5000);
            OL.GetElementShow();
            aDriver.Close();
        }

        ////To show element text
        //[TestMethod]
        //public void ForElementText()
        //{
        //    IWebDriver aDriver = Common_Methods.Driver("firefox");
        //    aDriver.Manage().Window.Maximize();
        //    aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        //    aDriver.Url = "https://priceoye.pk/";

        //    Login ll = new Login(aDriver);

        //    ll.GetElementShow();

    //}

       // For Regitration Button CLick
        [TestMethod]
        public void Registration()
        {
            IWebDriver aDriver = Common_Methods.Driver("Chrome");
            aDriver.Manage().Window.Maximize();
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            aDriver.Url = "https://priceoye.pk/";

            ForRegistration ll = new ForRegistration(aDriver);
            ll.ForCLickRegButton();
            ll.EnterNum("03468592298");
            ll.ClickCtoOTP();
            Thread.Sleep(25000);
            ll.VerifyCode();
            Thread.Sleep(2000);
            ll.ClickFirstName();
            ll.Fname("Sharoon Abdul Khaliq");
            ll.ClickEMail();
            ll.EnterEMail("Sharoonkhaliq84@gmail.com");
            ll.WriteRef("N/A");
            Thread.Sleep(8000);
            ll.Continue();
        }


        [TestMethod]
        public void SearchItemAvailable()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
          //  options.AddArgument("-no-sandbox");

          //  IWebDriver webDriver = Common_Methods.Driver("Chrome");

            //Pass the ChromeOptions object into the ChromeDriver constructor
            IWebDriver  webDriver = new ChromeDriver(options);

            ForSearch fs = new ForSearch(webDriver);
           
            fs.SearchFunctionality("https://priceoye.pk/", "Iphone 13" , "03057633796");
        }

    }
}
