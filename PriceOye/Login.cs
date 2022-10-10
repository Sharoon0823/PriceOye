using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Security.Policy;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace PriceOye
{

    public class Login : Common_Methods
    {


        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // #region objects

        By Login_Button = By.XPath("/html/body/div[1]/header/div/div[4]/a/span");
        By Phone_Number = By.XPath("//input[@id = 'phone-number']");
        By CLickOTP = By.XPath("//button [@id = 'content_to_otp']");
        By VerifyCode = By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div/div[2]/button");

        //constructor
        public Login(IWebDriver driver)
        {
            log.Info("Constructor Called");
            commonDriver = driver;

        }


        #region login
        public void clickLoginButton()
        {
            log.Info("CLick On Login Button");
            CLick(Login_Button);
            

        }

        //Forverify  OTP Code
        public void VerifyOtp()
        {
            log.Info("Click on Verify Code");
            CLick(VerifyCode);


        }

        public void EnterPhoneNumber(string num)
        {
            log.Info("Enter Phone Number");
            setText(Phone_Number, num);
        }

        public void ForOTPClick()
        {

            CLick(CLickOTP);
        }

        //GetElement

        public void GetElementShow()
        {

            string text = getElementText(Login_Button);
            MessageBox.Show(text);
        }

        //URl

        public void URL(string Url)
        {
            commonDriver.Url = Url;
        }


  
    }
}
#endregion
