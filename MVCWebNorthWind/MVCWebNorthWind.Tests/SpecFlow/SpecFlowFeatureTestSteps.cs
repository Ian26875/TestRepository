using System;
using TechTalk.SpecFlow;

namespace MVCWebNorthWind.Tests.SpecFlow
{
    [Binding]
    public class SpecFlowFeatureTestSteps
    {
        [Given(@"商品資料")]
        public void Given商品資料(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"執行計算")]
        public void When執行計算()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"運算結果應該為(.*)")]
        public void Then運算結果應該為(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
