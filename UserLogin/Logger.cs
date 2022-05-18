using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
            + LoginValidation.username + ";"
            + LoginValidation.currentUserRole + ";"
            + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("test.txt"))
            {
                foreach(string s in currentSessionActivities)
                File.AppendAllText("test.txt", s+"\n" );
            }

        }

        static public IEnumerable<string> getLog()
        {
            List<string> log=new List<string>();
                StreamReader sr = new StreamReader("test.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                log.Add(line);
            }
            sr.Close();
            return log;
        }
        static public void printLog()
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader("test.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(line+"\n");
            }
            Console.WriteLine(sb.ToString());
            sr.Close();
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filtered = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();   
            return filtered;
        }
    }
}
