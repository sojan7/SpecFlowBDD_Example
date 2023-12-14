using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDD.Hooks
{
    [Binding]
    public class Hooks
    {
        [AfterFeature]
        public static void AfterFeature()
        {
        }
    }
}