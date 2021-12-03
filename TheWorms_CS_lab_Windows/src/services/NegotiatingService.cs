using System;
using System.Text.RegularExpressions;

namespace TheWorms_CS_lab_Windows.services
{
    public class NegotiatingService
    {
        private const string Name = "Negotiator";

        public NegotiatingService() {}

        public string Talk(string speakerName, string text, Regex tester, string? defaultValue)
        {
            string defaultValueText = defaultValue != null ? $"({defaultValue})" : "";
            Console.Write($"{speakerName}: {text} {defaultValueText}\nYou: ");
            String? result = null;
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