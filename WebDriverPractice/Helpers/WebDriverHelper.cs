using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverPractice.Helpers
{
    public class WebDriverHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;

        public WebDriverHelper(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            _driver = driver;
            _wait = wait;
            _actions = actions;
        }

        public void Click(By locator)
        {
            //var webElement = _wait.Until(driver =>
            //{
            //	var element = _driver.FindElement(locator);
            //	return element.Displayed && element.Enabled ? element : null;
            //});

            var webElement = _wait.Until(driver => _driver.FindElement(locator));

            _actions
                //.MoveToElement(webElement)
                .Pause(TimeSpan.FromSeconds(1))
                .Click(webElement)
                .Perform();
        }

        public void SendKeys(By locator, string keys)
        {
            //var webElement = _wait.Until(driver =>
            //{
            //	var element = _driver.FindElement(locator);
            //	return element.Displayed && element.Enabled ? element : null;
            //});
            var webElement = _wait.Until(driver => _driver.FindElement(locator));

            _actions
                .MoveToElement(webElement)
                .Pause(TimeSpan.FromSeconds(1))
                .Click()
                .SendKeys(keys)
                .Perform();
        }

        public IWebElement FindTheElement(By locator)
        {
            //var webElement = _wait.Until(driver =>
            //{
            //	var element = _driver.FindElement(locator);
            //	return element.Displayed && element.Enabled ? element : null;
            //});
            var webElement = _wait.Until(driver => _driver.FindElement(locator));

            return webElement;
        }

        public void ScrollToElement(By locator) => _actions
            .ScrollToElement(FindTheElement(locator))
            .Perform();

	}
}
