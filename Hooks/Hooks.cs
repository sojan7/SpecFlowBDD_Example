using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SpecFlowBDD.Hooks
{
    [Binding]
    public class Hooks
    {
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario, step;

        private static string reportsFilePath = Directory.GetParent(@"../../../")!.FullName
                                    + Path.DirectorySeparatorChar + "Result"
                                    + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("yyMMdd_HHmm");

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlReport = new ExtentHtmlReporter(reportsFilePath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
            {
                step.Log(Status.Pass, scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                step.Log(Status.Fail, scenarioContext.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}