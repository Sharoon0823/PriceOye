using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceOye
{
    [TestClass]
    public class ForSearch : Common_Methods
    {

        By CLick_Search = By.XPath("//input[@id='search-term']");


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
        public void SearchFunctionality()
        {
            FOrUrl("https://priceoye.pk/");
            log.Info("Open URL");
            CLick(CLick_Search);
            log.Info("Clicked on Search button");
        }
        #endregion
    }

}
