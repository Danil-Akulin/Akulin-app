using System;
using System.Collections.Generic;
using System.Text;

namespace tthk_graz_app
{
    class StringTemplates
    {
        public static string NewYear(string firstName) => $"Kallis {firstName}, head uut aastat Sulle!";
        public static string Birthday(string firstName) => $"Kallis {firstName}, palju õnne Sulle!";
        public static string IndependenceDay(string firstName) => $"Kallis {firstName}, head iseseisvumispäeva sulle!";
        public static string WomansDay(string firstName) => $"Kallis {firstName}, head naistepäeva sulle!";
        public static string Christmas(string firstName) => $"Kallis {firstName}, head jõulu sulle!";
    }
}
