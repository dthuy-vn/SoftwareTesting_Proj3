using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Sample1
    {
        //function to switch tab
        public void SwitchToWindow(Expression<Func<IWebDriver, bool>> predicateExp)
        {
            var predicate = predicateExp.Compile();
            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (predicate(driver))
                {
                    return;
                }
            }

            throw new ArgumentException(string.Format("Unable to find window with condition: '{0}'", predicateExp.Body));
        }

        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            //navigate to URL  
            driver.Navigate().GoToUrl("https://mybk.hcmut.edu.vn/");
            Console.Write("Open the website\n");
            //Maximize the browser window  
            Thread.Sleep(2000);
        }
        [Test]
        public void ExecuteTest()
        {
            //Press the Login button
            IWebElement ele = driver.FindElement(By.CssSelector("div.login-navi>a:first-child"));
            ele.Click();
            Thread.Sleep(1000);
            
            //Send username, password and press Login
            IWebElement ele1 = driver.FindElement(By.Name("username"));
            ele1.SendKeys("1652229");
            IWebElement ele2 = driver.FindElement(By.Name("password"));
            ele2.SendKeys("Toilahuy");
            IWebElement ele3 = driver.FindElement(By.Name("submit"));
            ele3.Click();
            Console.Write("User is login\n");
            Thread.Sleep(2000);
            

            //Select Course Registration function
            IWebElement ele4 = driver.FindElement(By.CssSelector("a[href='http://mybk.hcmut.edu.vn/dkmh']"));
            ele4.Click();
            Thread.Sleep(2000);
            driver.Close();
            Thread.Sleep(500);

            //Switch to new pop-up window
            SwitchToWindow(driver => driver.Title == "Đăng ký môn học");
            Thread.Sleep(500);
            IWebElement ele5 = driver.FindElement(By.CssSelector("img[src='images/dkmh2.png']"));
            ele5.Click();
            Thread.Sleep(500);

            //Select semester
            IWebElement ele6 = driver.FindElement(By.CssSelector("tbody>tr:nth-child(2)"));
            ele6.Click();
            Thread.Sleep(500);
            IWebElement ele7 = driver.FindElement(By.CssSelector("div>button:nth-child(2)"));
            ele7.Click();
            Thread.Sleep(500);
            IWebElement ele8 = driver.FindElement(By.CssSelector("tr#dotDKId467>td:nth-child(2)"));
            ele8.Click();
            Thread.Sleep(500);

            //Select course
            IWebElement ele9 = driver.FindElement(By.Name("msmh"));
            ele9.SendKeys("CO");
            Thread.Sleep(500);
            IWebElement ele10 = driver.FindElement(By.CssSelector("span.input-group-btn"));
            ele10.Click();
            Thread.Sleep(2000);
            IWebElement ele11 = driver.FindElement(By.CssSelector("tr#monHoc5583>td:nth-child(4)"));
            ele11.Click();
            Thread.Sleep(1000);

            //Select class
            IWebElement ele12 = driver.FindElement(By.CssSelector("td>button[group='input5583']"));
            ele12.Click();
            Console.Write("Select class\n");
            Thread.Sleep(1000);

            //Confirm form submission
            IWebElement ele13 = driver.FindElement(By.CssSelector("button#btnXacNhanKetQua"));
            ele13.Click();
            Thread.Sleep(2000);
            IWebElement ele14 = driver.FindElement(By.CssSelector("button#btnXacNhanKetQua"));
            ele14.Click();
            Console.Write("Confirm form submission\n");
            Thread.Sleep(2000);
        }
        [TearDown]
        public void EndTest()
        {
            //close the browser  
            driver.Close();
        }
    }
}
