using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTests.Pages.AutomationPackagePage
{
    public partial class AutomationPage
    {

        public IWebElement NewTabButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//button[@id='button1']"));
            }
        }
        

        
    }
}
