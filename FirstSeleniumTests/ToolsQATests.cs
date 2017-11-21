using FirstSeleniumTests.Pages.AutomationPackagePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumDesignPatternsDemo.Pages.ResiblePage;
using SeleniumDesignPatternsDemo.Pages.ToolsQAHomePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTests
{
    [TestFixture]
    public class ToolsQATests
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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

            this.driver.Quit();
        }

      //[Test]
      //[Property ("ToolsQA", 3)]
      //public void HandlePopUp()
      //{
      //    AutomationPage automationPage = new AutomationPage(this.driver);
      //    ToolsQAHomePage toolsQAHomePage = new ToolsQAHomePage(this.driver);
      //    this.driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";
      //
      //    automationPage.NewTabButton.Click();
      //    this.driver.SwitchTo().ActiveElement();
      //    var secondTab = this.driver.WindowHandles.Last();
      //    this.driver.SwitchTo().Window(secondTab);
      //
      //    Assert.AreEqual("http://20tvni1sjxyh352kld2lslvc.wpengine.netdna-cdn.com/wp-content/uploads/2014/08/Toolsqa.jpg", 
      //        toolsQAHomePage.Logo.GetAttribute("src"));
      //    Assert.AreEqual(3, this.driver.WindowHandles.Count);
      //}

        [Test]
        [Property("ToolsQA", 3)]
        public void ResizeFirstTry()
        {
            this.driver = new ChromeDriver();
            var resizblePage = new ResiblePage(this.driver);

            resizblePage.NavigateTo();

            //this.driver.Url = "http://demoqa.com/resizable/";
            int widht = resizblePage.resizeWindow.Size.Width;
            int height = resizblePage.resizeWindow.Size.Height;

            Actions builder = new Actions(this.driver);
            var resize = builder.DragAndDropToOffset(resizblePage.resizeButton, 100, 100);
            resize.Perform();

            //Assert.AreEqual(widht + 100, resizblePage.resizeWindow.Size.Width);
            //Assert.AreEqual(height + 100, resizblePage.resizeWindow.Size.Height);
            Assert.IsTrue(resizblePage.resizeWindow.Size.Width > 230 && resizblePage.resizeWindow.Size.Height < 240);
        }
    }
}
