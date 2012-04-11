using System;
using System.IO;

namespace Roguelike.Log
{
    class Log
    {
        private static StreamWriter log;
        public Log()
        {
            log = new StreamWriter("log.txt");
        }

        public void Error(String s)
        {
            log.WriteLine("ERROR {0}", s);
        }

        public void Warning(String s)
        {
            log.WriteLine("WARNING {0}", s);
        }

        public void Info(String s)
        {
            log.WriteLine("INFO {0}", s);
        }
    }
}
