using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using WebDriverPractice.Business.Data;
using WebDriverPractice.Business.Pages;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public class EpamTests : TestBase
	{
		//[TestMethod]
		//[DataRow("JavaScript")]
		//public void CareerSearch_ProvideKeyword_GetProperResult(string testData)
		//{
		//	Log.Information($"{TestContext.TestName} test method starts.");

		//	bool isSearchResultDisplayed = false;

		//	var carrerSearchPage = EpamMainPage.ClickCareersButton();

		//	var carrerSearchResultsPage = carrerSearchPage.PerfromCarrerSearchOperations(testData);

		//	var jobDetailsPage = carrerSearchResultsPage.NavigateToLatestResult();

		//	isSearchResultDisplayed = jobDetailsPage.IsSearchResultDisplayed(testData);

		//	Assert.IsTrue(isSearchResultDisplayed, "Search result was not displayed.");
		//}

		//[TestMethod]
		//[DataRow("BLOCKCHAIN")]
		//[DataRow("Cloud")]
		//[DataRow("Automation")]
		//public void GlobalSearch_ProvideInput_GetProperResult(string keyword)
		//{
		//	Log.Information($"{TestContext.TestName} test method starts with '{keyword}' keyword.");
			
		//	bool doAllLinksContainKeyword = false;
			
		//	var searchResultPage = EpamMainPage.SearchForKeyword(keyword);

		//	doAllLinksContainKeyword = searchResultPage.DoAllLinksContainKeyword(keyword);

		//	Assert.IsTrue(doAllLinksContainKeyword, $"All links do not contain the searched keyword, which is {keyword}");
		//}

		//[TestMethod]
		//[DataRow(AboutPage.DownloadFilePath)]
		//public void AboutPage_ClickDownload_Downloads(string fileName)
		//{
		//	Log.Information($"{TestContext.TestName} test method starts and checking for '{fileName}' download.");
			
		//	var aboutPage = EpamMainPage.ClickAboutButton();

		//	var doesFileExist = aboutPage.ClickDownloadButtonAndWaitUntilDone();

		//	var canFileBeDeleted = doesFileExist;

		//	if (canFileBeDeleted)
		//	{
		//		File.Delete(fileName);
		//	}
			
		//	Assert.IsTrue(doesFileExist, "File does not exist.");
		//}

		//[TestMethod]
		//[DataRow(DataConstants.ClickTimes)]
		//public void InsightsPage_ClickReadMoreButtonOnThirdSlide_ValidateArticleName(int clickTimes)
		//{
		//	Log.Information($"{TestContext.TestName} test method starts. Number of swipes: {clickTimes}.");

		//	var insightsPage = EpamMainPage.ClickInsightsButton();
			
		//	insightsPage.ClickSliderButton(clickTimes);

		//	var slideText = insightsPage.GetSlideText();

		//	var insightsReadMorePage = insightsPage.ClickReadMoreButton();

		//	var insightsReadMorePageTitle = insightsReadMorePage.GetReadMorePageTitle();

		//	Assert.AreEqual(slideText, insightsReadMorePageTitle, "Texts are not equal.");
		//}
	}
}