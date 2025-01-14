using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverPractice.Helpers;

namespace WebDriverPractice.Pages
{
	public class InsightsPage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;
		private readonly Actions _actions;
		private readonly WebDriverHelper _driverHelper;

		private readonly By _sliderButton = By.XPath("//div[@class='slider-ui-23   media-content ']//button[@class='slider__right-arrow slider-navigation-arrow']");
		private readonly By _readMoreButton = By.XPath("(//div[@class='owl-item active']//a)[1]");
		private readonly By _slideTitle = By.XPath("(//div[@class='owl-item active']//p)[1]");
		private readonly By _readMorePageTitle = By.XPath("//span[@class='font-size-80-33']/span[@class='museo-sans-light']");

		public InsightsPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public void ClickSliderButton() => _driverHelper.Click(_sliderButton);
		public string GetSlideText() => _driverHelper.FindElementWithWait(_slideTitle).Text.Trim();
		public void ClickReadMoreButton() => _driverHelper.ClickWithJS(_driverHelper.FindElementWithWait(_readMoreButton));
		public string GetReadMorePageTitle() => _driverHelper.FindElementWithWait(_readMorePageTitle).Text.Trim();
	}
}
