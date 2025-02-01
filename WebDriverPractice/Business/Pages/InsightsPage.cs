using OpenQA.Selenium;
using Serilog;
using WebDriverPractice.Core.Helpers;

namespace WebDriverPractice.Business.Pages
{
	public class InsightsPage : BasePage
	{
		private readonly By _sliderButton = By.XPath("//div[@class='slider-ui-23   media-content ']//button[@class='slider__right-arrow slider-navigation-arrow']");
		private readonly By _readMoreButton = By.XPath("(//div[@class='owl-item active']//a)[1]");
		private readonly By _slideTitle = By.XPath("(//div[@class='owl-item active']//p)[1]");

		public InsightsPage(IWebDriver driver) : base(driver)
		{
			Log.Information($"Open {GetType().Name} page.");
		}

		public void ClickSliderButton(int clickTimes)
		{
			for (int i = 0; i < clickTimes; i++)
			{
				Log.Information($"Click {nameof(_sliderButton)}.");
				Driver.Click(_sliderButton);
			}
		}

		public string GetSlideText() => Driver.FindElementWithWait(_slideTitle).Text.Trim();
		public InsightsReadMorePage ClickReadMoreButton()
		{
			Log.Information($"Click {nameof(_readMoreButton)}.");
			Driver.ClickWithJS(Driver.FindElementWithWait(_readMoreButton));

			return new InsightsReadMorePage(Driver);
		}
	}
}