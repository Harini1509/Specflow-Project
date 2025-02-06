using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;


public static class ReportHelper
{

    public static ExtentTest test;
    public static AventStack.ExtentReports.ExtentReports extent;

    public static void InitializeReport()
    {
       var htmlReporter = new ExtentHtmlReporter(@"C:\Users\HariniGandhi\");
        extent = new AventStack.ExtentReports.ExtentReports();
        extent.AttachReporter(htmlReporter);
        test = extent.CreateTest("Automation Test");
        Console.WriteLine("Invoked");
    }
    public static void FlushReport()
    {
        extent.Flush();
    }
    public static string CaptureScreenshot(IWebDriver driver)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();


        var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
        if (!Directory.Exists(screenshotDirectory))
        {
            Directory.CreateDirectory(screenshotDirectory);
            Console.WriteLine("Report directory created: " + screenshotDirectory);
        }


        var screenshotFilePath = Path.Combine(screenshotDirectory, $"{Guid.NewGuid()}.png");

        screenshot.SaveAsFile(screenshotFilePath);

        return screenshotFilePath;
    }
}
