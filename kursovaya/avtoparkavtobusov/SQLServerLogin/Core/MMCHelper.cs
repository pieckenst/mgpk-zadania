﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Rectify11Installer.Core
{
	internal class MMCHelper
	{
		#region Variables
		private static readonly string backupDir = Path.Combine(Environment.CurrentDirectory, "Backup");
		private static readonly string tempDir = Path.Combine(Environment.CurrentDirectory, "Tmp");
		#endregion
		#region Public Methods
		public static bool PatchAll()
		{
			var langFolder = Path.Combine(Variables.sys32Folder, CultureInfo.CurrentUICulture.Name);
			var usaFolder = Path.Combine(Variables.sys32Folder, "en-US");
			List<string> langMsc = new(Directory.GetFiles(langFolder, "*.msc", SearchOption.TopDirectoryOnly));
			List<string> usaMsc = new(Directory.GetFiles(usaFolder, "*.msc", SearchOption.TopDirectoryOnly));
			List<string> r11Msc = new(Directory.GetFiles(Path.Combine(Variables.r11Files, "mmc"), "*.msc", SearchOption.TopDirectoryOnly));
			CopyFiles(langMsc, usaMsc, r11Msc);

			if (CultureInfo.CurrentUICulture.Name == "en-US") return true;
			List<string> r11LangMsc = new(Directory.GetFiles(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name), "*.msc", SearchOption.TopDirectoryOnly));
			List<string> sysMsc = new(Directory.GetFiles(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp"), "*.msc", SearchOption.TopDirectoryOnly));
			for (var i = 0; i < r11LangMsc.Count; i++)
			{
				for (var j = 0; j < sysMsc.Count; j++)
				{
					if (Path.GetFileName(r11LangMsc[i]) == Path.GetFileName(sysMsc[j]))
					{
						ReplaceString(r11LangMsc[i], sysMsc[j]);
					}
				}
			}
			Directory.Delete(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp"), true);
			var msc = Path.Combine(tempDir, "msc");
			if (CultureInfo.CurrentUICulture.Name != "en-US")
			{
				File.Copy(Path.Combine(msc, "lusrmgr.msc"), Path.Combine(msc, CultureInfo.CurrentUICulture.Name, "lusrmgr.msc"), true);
				File.Copy(Path.Combine(msc, "taskschd.msc"), Path.Combine(msc, CultureInfo.CurrentUICulture.Name, "taskschd.msc"), true);
				File.Copy(Path.Combine(msc, "WmiMgmt.msc"), Path.Combine(msc, CultureInfo.CurrentUICulture.Name, "WmiMgmt.msc"), true);
			}
			return true;
		}
		#endregion
		#region Private Methods
		private static void ReplaceString(string file, string r11file)
		{
			var msc = XDocument.Load(file);
			var r11msc = XDocument.Load(r11file);
			var xmlr11doc = r11msc.ToXmlDocument();
			foreach (var element in msc.Descendants())
			{
				if (element.Name != "StringTables") continue;
				var xmldoc = msc.ToXmlDocument();
				var del = xmldoc.GetElementsByTagName("StringTables")[0];
				if (xmldoc.DocumentElement != null)
				{
					xmldoc.DocumentElement.RemoveChild(del);
					if (xmlr11doc.DocumentElement != null)
					{
						var copiedNode =
							xmldoc.ImportNode(xmlr11doc.DocumentElement.GetElementsByTagName("StringTables")[0], true);
						xmldoc.DocumentElement.AppendChild(copiedNode);
					}
					var xmldecl = xmldoc.CreateXmlDeclaration("1.0", null, null);
					xmldoc.InsertBefore(xmldecl, xmldoc.DocumentElement);
				}
				xmldoc.Save(file);
			}
		}
		private static void CopyFiles(IReadOnlyList<string> langMsc, IList<string> usaMsc, IReadOnlyList<string> r11Msc)
		{
			if (Directory.Exists(Path.Combine(tempDir, "msc")))
			{
				Directory.Delete(Path.Combine(tempDir, "msc"));
			}
			Directory.CreateDirectory(Path.Combine(tempDir, "msc"));
			if (CultureInfo.CurrentUICulture.Name != "en-US")
			{
				if (Directory.Exists(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name)))
				{
					Directory.Delete(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name));
				}
				Directory.CreateDirectory(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name));

				if (Directory.Exists(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp")))
				{
					Directory.Delete(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp"));
				}
				Directory.CreateDirectory(Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp"));
			}
			else
			{
				if (Directory.Exists(Path.Combine(tempDir, "msc", "en-US")))
				{
					Directory.Delete(Path.Combine(tempDir, "msc", "en-US"));
				}
				Directory.CreateDirectory(Path.Combine(tempDir, "msc", "en-US"));
			}
			if (CultureInfo.CurrentUICulture.Name != "en-US")
			{
				for (var i = 0; i < langMsc.Count; i++)
				{
					for (var j = 0; j < usaMsc.Count; j++)
					{
						if (Path.GetFileName(langMsc[i]) == Path.GetFileName(usaMsc[j]))
						{
							usaMsc.RemoveAt(j);
						}
					}
				}
			}
			for (var j = 0; j < r11Msc.Count; j++)
			{
				if (CultureInfo.CurrentUICulture.Name == "en-US") continue;
				for (var i = 0; i < langMsc.Count; i++)
				{
					if (Path.GetFileName(langMsc[i]) != Path.GetFileName(r11Msc[j])) continue;
					Debug.WriteLine(langMsc[i]);
					if (File.Exists(Path.Combine(backupDir, "msc", CultureInfo.CurrentUICulture.Name,
						    Path.GetFileName(r11Msc[j])))) continue;
					if (Path.GetFileName(langMsc[i]) == "lusrmgr.msc"
					    && Path.GetFileName(langMsc[i]) == "taskschd.msc"
					    && Path.GetFileName(langMsc[i]) == "WmiMgmt.msc") continue;
					File.Copy(r11Msc[j], Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, Path.GetFileName(r11Msc[j])), true);
					File.Copy(langMsc[i], Path.Combine(tempDir, "msc", CultureInfo.CurrentUICulture.Name, "temp", Path.GetFileName(langMsc[i])), true);
				}
			}
			for (var i = 0; i < r11Msc.Count; i++)
			{
				File.Copy(r11Msc[i], Path.Combine(tempDir, "msc", Path.GetFileName(r11Msc[i])), true);
			}
		}
		#endregion
	}
	#region Helper
	public static class DocumentExtensions
	{
		public static XmlDocument ToXmlDocument(this XDocument xDocument)
		{
			var xmlDocument = new XmlDocument();
			using (var xmlReader = xDocument.CreateReader())
			{
				xmlDocument.Load(xmlReader);
			}
			return xmlDocument;
		}

		public static XDocument ToXDocument(this XmlDocument xmlDocument)
		{
			using (var nodeReader = new XmlNodeReader(xmlDocument))
			{
				nodeReader.MoveToContent();
				return XDocument.Load(nodeReader);
			}
		}
	}
	#endregion
}
