
using System;
using System.IO;
using System.Linq;
using J = Newtonsoft.Json;
using JSSettings = Newtonsoft.Json.JsonSerializerSettings;

using System.Web.Helpers;
using System.Xml;
using System.Text;

namespace github
{
    /// <summary>
    /// Summary description for github
    /// </summary>
    public class User
    {
        internal static readonly string Name = "Virtual-World-Systems";
        internal static readonly string Token = "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";

        internal static string fmt(string s)
		{
            s = s.Replace("<", "&lt;").Replace(">", "&gt;");
            return "<code style='white-space:pre-wrap'>" + s + "</code>";

        }
        internal static string xob(string s)
		{
            XmlDocument doc = J.JsonConvert.DeserializeXmlNode("{_:" + s + "}");
            XmlElement e = (XmlElement)doc.DocumentElement.SelectSingleNode("content");
            if (e != null) e.InnerText += Encoding.UTF8.GetString(Convert.FromBase64String(e.InnerText));
            var stringBuilder = new StringBuilder();
            var settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings)) doc.Save(xmlWriter);
            return fmt(stringBuilder.ToString()); // adaradius@gmail.com
        }
        internal static string job(string s)
		{
            var obj = J.JsonConvert.DeserializeObject(s);
            //JSSettings settings = new JSSettings() { Formatting = J.Formatting.Indented };
            s = J.JsonConvert.SerializeObject(obj, J.Formatting.Indented);
            return fmt(s.Replace("\t", "\t\t"));
        }

        internal static string test()
        {
            Stream stm = RP.GET("repos/Virtual-World-Systems/Index/git/blobs/1506d5baebf7a48e0b6cfbee360be0a5bbb82ece");
            string s = new StreamReader(stm).ReadToEnd();
            return xob(s);
            //return job(s);
        }
    }
}