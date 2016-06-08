using Exercise2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using System;


namespace Exercise2.TestCases
{
    class Exercise2
    {
        private IWebDriver driver = new FirefoxDriver();
        private Uri url = new Uri("http://www.kbb.com");
        [Test]
        public void GotoNCYMMT()
        {
            driver.Navigate().GoToUrl(url);
            var iAction = new KbbFactory(driver);
            iAction._SetToZipCode();
            iAction._NavigateToNCSLP();
            //SLP
            string _SLPequal = "New Cars & New Car Prices - Kelley Blue Book";
            iAction._VerifyTitle(_SLPequal);
            iAction.SelectOnDropDown(iAction.ddl_NCMake, "Acura", "Id");
            iAction.SelectOnDropDown(iAction.ddl_NCModel, "ILX", "Id");
            iAction.btn_Next.Click();
            //YMM
            string _ymmEqual = "Acura ILX - Kelley Blue Book";
            iAction._VerifyTitle(_ymmEqual);
            iAction.btn_selectYear.Click();
            //Style
            string _styleEqual = "2016 Acura ILX Styles and Equipment, New Cars - Kelley Blue Book";
            iAction._VerifyTitle(_styleEqual);
            iAction.btn_selectStyle.Click();
            //Option
            string _optionEqual = "2016 Acura ILX Options - Kelley Blue Book";
            iAction._VerifyTitle(_optionEqual);
            iAction.btn_selectOptions.Click();
            //YMMT
            string _ymmtEqual = "2016 Acura ILX New Car Prices - Kelley Blue Book";
            iAction._VerifyTitle(_ymmtEqual);
        }
        [TearDown]
        public void End()
        {
            driver.Close();
        }
    }
}
