using Amazon.DynamoDBv2.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace PriceOye
{
    internal class Contact : Common_Methods
    {
        By pop_up = By.XPath("//button[@on='tap:my-notification.dismiss']");
        By Click_menu = By.XPath("//img[@class='i-amphtml-fill-content i-amphtml-replaced-content' and @alt = 'bar']");
        By Contact_Button = By.XPath("//a[@class='ga-dataset p2' and @data-vars-value='Contact']");
        By CLick_TrackOrder = By.XPath("//div[@class='h4' and text() = ' How can I track my order?']");
        By click_TrackLink = By.XPath("//a[@href='https://leopardcouriertracking.com/']");
        By ENter_CN = By.XPath(" //input[@type='search']");
        By Click_ParcelOpen = By.XPath("//div[@class='h4' and text() = 'What is Open Parcel Delivery ?']");
        By click_ParcelOpenLink = By.XPath("//a[@href='https://priceoye.pk/parcel-policy']");

        #region Constructor
        public Contact(IWebDriver driver)
        {
            commonDriver = driver;
        }
        #endregion

        public void ForContact(string url , string cn)
        {
            FOrUrl(url);
            CLick(pop_up);
            CLick(Click_menu);
            scrollToElement(Contact_Button);
            ForSleep(3000);
            CLick(Contact_Button);
            ForSleep(3000);
            CLick(CLick_TrackOrder);
            CLick(click_TrackLink);
            ForSleep(2000);
            IsClickable(ENter_CN);
            scrollToElement(ENter_CN);
            CLick(ENter_CN);
            setText(ENter_CN , cn);

        }

        public void ParcelOpenDelivery(string url)
        {
            FOrUrl(url);
            CLick(pop_up);
            CLick(Click_menu);
            scrollToElement(Contact_Button);
            ForSleep(3000);
            CLick(Contact_Button);
            scrollToElement(Click_ParcelOpen);
            CLick(Click_ParcelOpen);
            CLick(click_ParcelOpenLink);
        }

    }

}
