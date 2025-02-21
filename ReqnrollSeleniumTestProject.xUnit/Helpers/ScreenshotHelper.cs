using OpenQA.Selenium;

namespace ReqnrollSeleniumTestProject.xUnit.Helpers
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string scenarioName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

                if (!Directory.Exists(screenshotsDir))
                {
                    Directory.CreateDirectory(screenshotsDir);
                }
                
                string filePath = Path.Combine(screenshotsDir, $"{scenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(filePath);
                //File.WriteAllBytes(filePath, screenshot.AsByteArray);

                Console.WriteLine($"📸 Screenshot saved: {filePath}");

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to capture screenshot: {ex.Message}");
                return null;
            }
        }
    }
}
