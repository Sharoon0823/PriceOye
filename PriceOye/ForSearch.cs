using Amazon.DynamoDBv2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Telerik.JustMock;

namespace PriceOye
{
    [TestClass]
    public class ForSearch : Common_Methods
    {
       
        By pop_up = By.XPath("//button[@on='tap:my-notification.dismiss']");
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
        By Compare = By.XPath("//li[@id='compare-desktop-btn']");
        By Gold_colour = By.XPath("//*[@id=\'product-summary\']/div[5]/div[1]/ul/li[2]/a/div");
        By compare01 = By.XPath("//input[@id='compare-search-term0']");
        By compare001 = By.XPath("//*[@id=\'compare_autosuggest0-list\']/div/a[1]/span");
        By page_Ss = By.XPath("//div[@id='wrapper']");

        #region Step:01 Constructor
        public ForSearch(IWebDriver driver)
        {
            commonDriver = driver;  
        }
        #endregion

        #region Step:02 LOG4NET
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object ExpectedConditions { get; private set; }
        #endregion


        #region Step:03 Search Item and Add to Cart
        public void SearchFunctionality01(string uerl,string ev , string evv)
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
            ((IJavaScriptExecutor)commonDriver).ExecuteScript("return document.getElementById('City').selectedIndex =  + '1' ");
          // dropDown(City, "Barakahu");
            //dropDown(Area, "Barakahu");
        }
        #endregion


        #region Search Item and COmpare with other Item
        public void SearchAndCOmpare(string uerl, string ev, string com)
        {
            FOrUrl(uerl);
            CLick(pop_up);
            log.Info("Open URL");
            CLick(CLick_Search);
            log.Info("Clicked on Search button");
            setText(Enter_Value, ev);
            log.Info("Enter Value");
            scrollToElement(Select_Item);
            log.Info("Scroll to element");
            CLick(Select_Item);
            log.Info("Click to Scroll element");
            CLick(Gold_colour);
            log.Info("Select Golden Color");
            scrollToElement(Compare);
            log.Info("Scroll to Compare element");
            CLick(Compare);
            log.Info("Click to element");
            CLick(compare01);
            log.Info("Click to Selected Item");
            setText(compare01, com);
            log.Info("Enter Value");
            Thread.Sleep(1000);
            log.Info("Wait");
            scrollToElement(compare01);
            log.Info("Scroll to element compare01");
            CLick(compare001);
            log.Info("CLick compare001");
            FOrZoomOUt();
            log.Info("Zoom out Scree");
            ScreenSHot("SearchAndCompare.png");
            log.Info("Take ScreenSHoot and save this file name");
            commonDriver.Close();
            log.Info("Close Driver");
        }
        #endregion

        #region Search Item Out of COntext
        public void InvalidSearchOfItem(string uerl , string cs)
        {
            FOrUrl(uerl);
            CLick(pop_up);
            CLick(CLick_Search);
            setText(CLick_Search, cs);
            commonDriver.FindElement(CLick_Search).SendKeys(Keys.Enter);
            ScreenSHot("InvalidSearchOfItem.png");
            
        }
        #endregion
    }

}
