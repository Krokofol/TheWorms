using System;
using System.Text.RegularExpressions;

namespace TheWorms_CS_lab.assistant
{
    public static class Negotiator
    {
        private const string Name = "Negotiator";

        public static string Talk(string speakerName, string text, Regex tester, string defaultValue)
        {
            string defaultValueText = defaultValue != null ? $"({defaultValue})" : "";
            Console.Write($"{speakerName ?? "Unknown"}: {text ?? "(something stupid)"} {defaultValueText}\nYou: ");
            string result = null;
            do
            {
                if (result != null)
                {
                    Console.Write($"{Name}: bad answer, try again please\nYou: ");
                }
                result = Console.ReadLine() ?? "";
                if (result == "" && defaultValue != null)
                {
                    result = defaultValue;
                    Console.WriteLine(defaultValue);
                }
            } while (!tester.IsMatch(result));
            
            return tester.Match(result).Value;
        }
    }
}