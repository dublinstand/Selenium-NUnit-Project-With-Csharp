using FirstSeleniumTests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.HomePage;
using System.Collections.Generic;

namespace FirstSeleniumTests
{
    [TestFixture]
    public class RegistrationFromTests        
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }


        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        //Using Page Factory Object Model
        [Test]
        public void NavigateToRegistrationPage()
        {
            HomePage homePage = new HomePage(this.driver);

            //Instantiate the Page Object
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            //homePage.RegistrationButton.Click();
        }

        //Using Page Object Model
        [Test]
        public void RegistrationWithoutMail()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            Type(regPage.FirstName, "Ventsi");
            Type(regPage.LastName, "Ivanov");

        }

        [Test]
        public void RegistrateWithOutFirstName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test]
        public void RegistrateWithOutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ventsislav",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12",
                                                         "12");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            var indicator = this.driver.FindElement(By.Id("piereg_passwordStrength"));
            var bc = indicator.GetCssValue("background-color");
            var color = indicator.GetCssValue("color");

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
