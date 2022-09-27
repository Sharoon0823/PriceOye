using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceOye
{
    [TestClass]
    public class Automation
    {
        [TestMethod]

        public void LoginButton()
        {
            IWebDriver aDriver = new ChromeDriver();
            aDriver.Manage().Window.Maximize();
            aDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            aDriver.Url = "https://priceoye.pk/";

          Login OL = new Login(aDriver);
            OL.clickLoginButton();
            OL.EnterPhoneNumber("03057633796");
            OL.ForOTPClick();
        }
    }
}
