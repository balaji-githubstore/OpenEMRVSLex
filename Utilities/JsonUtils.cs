using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenEmrAutomation.Utilities
{
    public class JsonUtils
    {
        public static string GetValue(string path,string key)
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(data);
            string value = Convert.ToString(json[key]);
            return value;
        }
        public static object[] JsonIntoObjectArray(string path, string key)
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();

            dynamic jdata = JsonConvert.DeserializeObject(data);

            object[] main = new object[jdata[key].Count];

            for (int i = 0; i < main.Length; i++)
            {
                object[] temp = new object[jdata[key][i].Count];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = Convert.ToString(jdata[key][i][j]);
                }
                main[i] = temp;
            }
            return main;
        }
    }
}
