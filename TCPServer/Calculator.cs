using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace TCPServer
{

    static class Calculator
    {   
        public static void Validate(string message)
        {
            if (Regex.IsMatch(message, "[a-z]"))
            {
                throw new ArgumentException(message);
            }

            string[] splitedMessage = Split(message);

            List<Token> tokens = new List<Token>();

            foreach (string expression in splitedMessage)
            {
                tokens.Add(GetToken(expression));
            }
            Console.WriteLine();
        }

        static void Parse()
        {

        }

        static void Calculate()
        {

        }

        static void ToMessage()
        {

        }

        public static string[] Split(string input) => Regex.Split(input, @"([+\-*/])");

        private static Token GetToken(string input) => input switch
        {
            "+" => Token.Addition,
            "-" => Token.Subtraction,
            "*" => Token.Multiplication,
            "/" => Token.Division,
            var s when Regex.IsMatch(s, @"^\d+$") => Token.IntNumber,
            var s when Regex.IsMatch(s, @"^-?\d+(\.\d+)?$") => Token.Decimal,
            _ => throw new ArgumentException()
        };

    }

    internal enum Token
    {
        IntNumber,
        Decimal,
        Addition,
        Subtraction, 
        Multiplication, 
        Division
    }
}
