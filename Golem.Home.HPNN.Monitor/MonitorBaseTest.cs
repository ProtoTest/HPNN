using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.HPNN.Monitor
{
    public class MonitorBaseTest : WebDriverTestBase
    {

        [TearDown]
        public void teardown()
        {
            PrintCondensedActionTimings(testData.actions);
            LogVideo();
        }

        public void LogVideo()
        {
            if (testData.recorder.Video != null)
                TestLog.EmbedVideo("FLV _" + Common.GetShortTestName(90), testData.recorder.Video);
        }


        public void PrintCondensedActionTimings(ActionList actionList)
        {
            actionList.RemoveDuplicateEntries();
            var actions = actionList.actions;
            TestLog.BeginSection("Test Action Timings:");
            DateTime start;
            DateTime end;
            TimeSpan difference;
            string rowText = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            for (int i = 1; i < actions.Count; i++)
            {
                var startIndex = i - 1;
                var endIndex = i;
                start = actions[startIndex]._time;
                end = actions[endIndex]._time;
                difference = end.Subtract(start);
                Common.Log(actions[endIndex].name + " : " + difference);
                rowText += "," + actions[endIndex].name + ":" + difference;
            }
            start = actions[0]._time;
            end = actions[actions.Count - 1]._time;
            difference = end.Subtract(start);

            Common.Log("All Actions : " + difference);
            rowText += ",All:" + difference + Environment.NewLine;
            WriteToCSV(rowText);
            TestLog.End();
        }

        public void WriteToCSV(string rowDetails)
        {
            string newFileName = Config.GetConfigValue("CSVPath", Directory.GetCurrentDirectory().ToString() + "\\" + TestContext.CurrentContext.Test.Name + ".csv");
            File.AppendAllText(newFileName, rowDetails);
            Common.Log("Appended results to file : " + newFileName);
        }

    }
}
