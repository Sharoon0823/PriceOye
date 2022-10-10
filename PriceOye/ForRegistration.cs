using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceOye
{
     class ForRegistration : Common_Methods
    {

        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        By Register_ButtonC = By.XPath("//*[@id=\'p-register \']/a/span");
        By Pnum = By.XPath("//input[@id='phone-number']");
        By CToOTP = By.XPath("//button[@class = 'btn btn-primary btn-otp' and @id = 'content_to_otp'] ");
        By VOTP = By.XPath("//button[@onClick = 'onVerifySubmit()']");
        By EnterFname = By.XPath("//input[@id = 'full_name'] ");
        By Email = By.XPath("//input[@id = 'email']");
        By Con = By.XPath("onSignUpSubmit()");
        By RefWrite = By.XPath("//input[@id = 'referal_code']");
       


        //Constructor
         public ForRegistration(IWebDriver driver)
        {
            commonDriver = driver;
        }


        //Method FOr Registration
        public void ForCLickRegButton()
        {

            CLick(Register_ButtonC);
            log.Info("Click is Working");
        }

        //Method For PhoneNumber ENter

        public void EnterNum(string number)
        {
            log.Info("Number Written ");
            setText(Pnum, number);
        }

        //For Click On Continue to OTP
        public void ClickCtoOTP()
        {
            log.Info("CLick To OTP ");
            CLick(CToOTP);

        }

        //ENterOTP Manually and Also Captcha

        //Click On VerifyCode

        public void VerifyCode()
        {
            log.Info("Code  Verified");
            CLick(VOTP);
        }

        //Click On FirstName

        public void ClickFirstName()
        {
            log.Info("Click on First_Name ENtered");
            CLick(EnterFname);
        }

        //ENter FirstName
        public void Fname(string Fnamee)
        {
            log.Info("Entered Fname");
            setText(EnterFname, Fnamee);
        }

        //Click On EMail
         public void ClickEMail()
        {
            CLick(Email);
        }

        //Write Email
        public void EnterEMail( string email)
        {
          
            setText(Email, email);
        }

        //Write in Refferel 
       public void WriteRef(string text )
        {
            setText(RefWrite, text);
        }

        //Click To COntinue
        public void Continue()
        {
            CLick(Con);
        }
    }

}
