using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace PriceOye
{

    public class Login  : Common_Method
    {
        


        // #region objects

        By Login_Button = By.XPath("/html/body/div[1]/header/div/div[4]/a/span");
        By Phone_Number = By.XPath("//input[@id = 'phone-number']");
        By CLickOTP = By.XPath("//button [@id = 'content_to_otp']");
        // #region constructor
        public Login(IWebDriver driver)
        {
            commonDriver = driver;

        }


        #region login
        public void clickLoginButton()
        {
            CLick(Login_Button);

        }

        public void EnterPhoneNumber(string num)
        {
         setText(Phone_Number, num);  
        }

        public void ForOTPClick()
        {
            CLick(CLickOTP);
        }

        
    }
}
#endregion
