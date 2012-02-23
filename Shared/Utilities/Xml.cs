﻿using System.IO;
using System.Xml.Serialization;

namespace MyToolkit.Utilities
{
	// TODO: use this?
	/*public sealed class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding { get { return Encoding.UTF8; } }
	}*/

	public static class Xml
	{
		public static string Serialize(object obj)
		{
			using (var sw = new StringWriter()) 
			{
				var serializer = new XmlSerializer(obj.GetType());
				serializer.Serialize(sw, obj);
				return sw.ToString();
			}
		}

		public static T Deserialize<T>(string xml)
		{
			using (var sw = new StringReader(xml))
			{
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(sw);
			}
		}
	}
}