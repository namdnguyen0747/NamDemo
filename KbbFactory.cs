using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace Exercise2.PageObjects
{
    public class KbbFactory
    {
        /// <summary>
        /// ///////////////////////////////////////////////////////Object Page Model
        /// </summary>
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "zip-code-header")]
        public IWebElement btn_Zipcode { get; set; }

        [FindsBy(How = How.Id, Using = "zipcode-input-header")]
        public IWebElement txt_Zipcode_input { get; set; }

        [FindsBy(How = How.Id, Using = "zipcode-update-btn")]
        public IWebElement btn_Save_Zipcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='pageBottom']//*[contains(text(),'Price New/Used Cars')]")]
        public IWebElement btn_NewCarPath { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='pageBottom']//*[contains(text(),'Check My')]")]
        public IWebElement btn_OWNPathPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='pageBottom']//*[contains(text(),'See Cars for Sale')]")]
        public IWebElement btn_Car4Sales { get; set; }

        [FindsBy(How = How.Id, Using = "survey_close")]
        public IWebElement btn_closeSurvey { get; set; }
        //
        [FindsBy(How = How.Id, Using = "kbbmanufacturer")]
        public IWebElement ddl_NCMake { get; set; }
        //
        [FindsBy(How = How.Id, Using = "kbbmodel")]
        public IWebElement ddl_NCModel { get; set; }
        //
        [FindsBy(How = How.Id, Using = "ymm-submit")]
        public IWebElement btn_Next { get; set; }
        //
        [FindsBy(How = How.XPath, Using = "//*[@id='Model-year-select']//*[contains(text(),'Select 2016')]")]
        public IWebElement btn_selectYear { get; set; }
        //
        [FindsBy(How = How.XPath, Using = "//*[@id='Styles-list-container']//*[contains(text(),'Choose this style')]")]
        public IWebElement btn_selectStyle { get; set; }
        //
        [FindsBy(How = How.XPath, Using = "//*[@id='Options-container']//*[contains(text(),'Price with standard options')]")]
        public IWebElement btn_selectOptions { get; set; }
        //
        [FindsBy(How = How.XPath, Using = "//*[@id='Options-container']//*[contains(text(),'Price with standard options')]")]
        public IWebElement btn_Nothank_survey { get; set; }

        /// <summary>
        ////////////////////////////////////////////// Validate Model
        /// </summary>
        public KbbFactory(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        #region SetZipcodeOnHomePage
        public void _SetToZipCode()
        {
            btn_Zipcode.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            txt_Zipcode_input.SendKeys("92618");
            btn_Save_Zipcode.Click();
        }
        #endregion

        #region NavigateNCSLP
        public void _NavigateToNCSLP()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.Id("zipcode-update-btn")));
            btn_NewCarPath.Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("zipcode-update-btn")));// Dieu kien available tren New Car YMMT
            //Verify Title SLP
            string _title = driver.Title;
            Assert.IsTrue(_title.Equals("New Cars & New Car Prices - Kelley Blue Book"));

        }
        #endregion

        #region VerifyThisTitle
        public void _VerifyTitle( string _comparevalue)
        {
            string _title = driver.Title;
            //Console.WriteLine(_title);
            Assert.IsTrue(_title.Equals(_comparevalue));
        }
        #endregion

        #region SelectOnDropDown
        public void SelectOnDropDown(IWebElement _eElement, string value, string elementtype)
        {
            SelectElement select1 = new SelectElement(_eElement);
            if (elementtype == "Id")
                select1.SelectByText(value);
            if (elementtype == "Name")
            select1.SelectByText(value);
            if (elementtype == "Xpath")
                select1.SelectByText(value);
        }
        #endregion

    }
}


