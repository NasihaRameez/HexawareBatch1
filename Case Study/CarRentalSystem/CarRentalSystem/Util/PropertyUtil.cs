using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarRentalSystem.Util
{
    public class PropertyUtil
    {
        public static Dictionary<string, string> LoadProperties(string filePath)
        {
            var properties = new Dictionary<string, string>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The property file '{filePath}' was not found.");
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    var parts = line.Split('=');
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    properties[key] = value;
                }
            }

            return properties;
        }
    }
}