using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
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

		public InsightsPage(IWebDriver driver, WebDriverWait wait, Actions actions, WebDriverHelper driverHelper)
		{
			Log.Information($"Open {this.GetType().Name} page.");
			_driver = driver;
			_wait = wait;
			_actions = actions;
			_driverHelper = driverHelper;
		}

		public void ClickSliderButton(int clickTimes)
		{
			for (int i = 0; i < clickTimes; i++)
			{
				Log.Information($"Click {nameof(_sliderButton)}.");
				_driverHelper.Click(_sliderButton);
			}
		}

		public string GetSlideText() => _driverHelper.FindElementWithWait(_slideTitle).Text.Trim();
		public InsightsReadMorePage ClickReadMoreButton()
		{
			Log.Information($"Click {nameof(_readMoreButton)}.");
			_driverHelper.ClickWithJS(_driverHelper.FindElementWithWait(_readMoreButton));

			return new InsightsReadMorePage(_driver, _wait, _actions, _driverHelper);
		}
	}
}
