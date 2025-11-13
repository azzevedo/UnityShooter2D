using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Cerebrynth
{
    public enum StringTypes
    {
        ClassName,
        Namespace,
        Path,
        Filename
    }
	public static class Utilities
	{

        #region Validation

        #region Validation Fields

        private const string _validClassFileName = @"[A-Za-z]{1}\w*";
        private const string _validPath = @"^[A-Za-z]+(\/[A-Za-z\d_]+)*\/?$";
        private const string _validNameSpace = @"[A-Za-z]{1}\w*((\.?)[A-Za-z]{1}\w*)*";
        
        #endregion
        
        public static string ValidateString(this string input, StringTypes sType)
        {
            input = input.RemoveSpaces();
            string temp = sType == StringTypes.Namespace ? "MyNamespace" : "MyClass";
            var matchCase = sType switch
            {
                StringTypes.Namespace => _validNameSpace,
                StringTypes.Path => _validPath,
                StringTypes.Filename => _validPath,
                _ => _validClassFileName
            };

            if (string.IsNullOrEmpty(input)) return temp;

            var matches = Regex.Matches(input, matchCase);

            if (matches.Count > 0)
            {
                string result = "";
                foreach (Match m in matches)
                {
                    result += m;
                }
                temp = result;
            }

            return temp;
        }

        public static string RemoveSpaces(this string input)
        {
            return new string(input.Where(x => !Char.IsWhiteSpace(x)).ToArray());
        }

        public static string CheckExistingFileName(this string input, InputData data, out string name)
        {
            var extension = data.ClassType.ToString() == "HLSL" ? ".hlsl" : ".cs";
            Debug.Log($"Classtype is {data.ClassType.ToString()}");
            int post = 0;
            if (!File.Exists(input))
            {
                name = data.Name;
                return input;
            }

            post++;
            string attempt = $"{data.SavePath}{data.Name}{post.ToString("00")}{extension}";

            while (File.Exists(attempt))
            {
                post++;
                attempt = $"{data.SavePath}{data.Name}{post.ToString("00")}{extension}";
            }

            name = data.Name + post.ToString("00");
            input = $"{data.SavePath}{name}{extension}";
            return input;
        }

        #endregion

    }
}
