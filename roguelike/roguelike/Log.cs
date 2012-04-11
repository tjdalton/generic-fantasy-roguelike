using System;
using System.IO;

namespace roguelike
{
    class Log
    {
        private StreamWriter log;
        public Log()
        {
            log = new StreamWriter("log.txt");
        }

        public void Error(String s)
        {
            log.Write("ERROR {0}", s);
        }

        public void Warning(String s)
        {
            log.Write("WARNING {0}", s);
        }

        public void Info(String s)
        {
            log.Write("INFO {0}", s);
        }
    }
}
