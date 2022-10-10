using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriceOye
{
    [TestClass]
    public class ForSearch : Common_Methods
    {

        By CLick_Search = By.XPath("//input[@id='search-term']");
        By Enter_Value = By.XPath("//input[@id='search-term']");
        By Select_Item = By.XPath("//*[@id=\'autosuggest-list\']/div/a[2]");
        By AddTOCart = By.XPath("//li[@id='order-desktop-button']");
        By EnterPhoneNum = By.XPath("//*[@id=\'phone-number\']");
        By ReqOTP = By.XPath("//button[@onclick='onSignInSubmit()']");
        By ClickVerifyCode = By.XPath("//button[@onclick='onVerifySubmit()']");
        By click_province = By.XPath("//*[@id=\'province\']");
        By Province = By.Name("province");
        By City = By.Name("city");
        By Area = By.Name("area");

        #region Step:01 Constructor
        public ForSearch(IWebDriver driver)
        {
            commonDriver = driver;  
        }
        #endregion

        #region Step:02 LOG4NET
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion


        #region Step:03
        public void SearchFunctionality(string uerl,string ev , string evv)
        {
            FOrUrl(uerl);
            log.Info("Open URL");
            CLick(CLick_Search);
            log.Info("Clicked on Search button");
            setText(Enter_Value , ev);
            log.Info("Enter value");
            scrollToElement(Select_Item);
            CLick(Select_Item);
            scrollToElement(AddTOCart);
            CLick(AddTOCart);
            Thread.Sleep(2000);
            CLick(EnterPhoneNum);
            setText(EnterPhoneNum ,  evv);
            CLick(ReqOTP);
            Thread.Sleep(29000);
            CLick(ClickVerifyCode);

            scrollToElement(Province);
            dropDown(Province, "Punjab");
             //
            dropDown(City, "Barakahu");
            dropDown(Area, "Barakahu");




        }
        #endregion
    }

}
