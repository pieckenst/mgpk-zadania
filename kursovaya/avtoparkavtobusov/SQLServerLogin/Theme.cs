﻿using System;
using System.IO;
using System.Linq;
using libmsstyle;
using Microsoft.Win32;
using Rectify11Installer.Controls;

namespace SQLServerLoginTemplate
{
    public class Theme
	{
		#region Variables
		public static VisualStyle DarkStyle = new();
		public static VisualStyle LightStyle = new();
        
        public static bool IsUsingDarkMode = getdarkmodeinfo();
		
		#endregion
		#region Public Methods
		public static void InitTheme()
		{
			var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
			if (key != null)
			{
				var registryValueObject = key.GetValue("AppsUseLightTheme");
				if (registryValueObject == null)
				{
					return;
				}

				var registryValue = (int)registryValueObject;
				IsUsingDarkMode = registryValue <= 0;
			}

			SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
		}
		public static bool getdarkmodeinfo()
		{
            int res = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1);
            if (res == 0) { return true;}
			else { return false;}

		}
		public static event EventHandler OnThemeChanged;

		public static void LoadTheme()
		{
			DarkStyle.Load(Path.Combine(Environment.CurrentDirectory, "Dark.msstyles"));
			LightStyle.Load(Path.Combine(Environment.CurrentDirectory, "light.msstyles"));
		}

		public static StylePart GetNavArrowPart(VisualStyle v, NavigationButtonType type)
		{
			return (from classes in v.Classes.Values
				where classes.ClassName == "Navigation"
				let partStr = type switch
				{
					NavigationButtonType.Forward => "FORWARDBUTTON",
					NavigationButtonType.Backward => "BACKBUTTON",
					NavigationButtonType.Menu => "MENUBUTTON",
					_ => throw new NotImplementedException()
				}
				from parts in classes.Parts
				where parts.Value.PartName == partStr
				select parts.Value).FirstOrDefault();
		}
		public static StylePart GetCommandLinkPart(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Button" from parts in classes.Parts where parts.Value.PartName == "COMMANDLINK" select parts.Value).FirstOrDefault();
		}
		public static StylePart GetGroupBox(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Button" from parts in classes.Parts where parts.Value.PartName == "GROUPBOX" select parts.Value).FirstOrDefault();
		}
		public static StylePart GetCommandLinkGlyphPart(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Button" from parts in classes.Parts where parts.Value.PartName == "COMMANDLINKGLYPH" select parts.Value).FirstOrDefault();
		}

		public static StylePart? GetProgressbarBg(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Progress" from parts in classes.Parts where parts.Value.PartName == "BAR" select parts.Value).FirstOrDefault();
		}
		public static StylePart? GetProgressbarFill(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Progress" from parts in classes.Parts where parts.Value.PartName == "FILL" select parts.Value).FirstOrDefault();
		}

		public static StylePart GetButtonPart(VisualStyle v)
		{
			return (from classes in v.Classes.Values where classes.ClassName == "Button" from parts in classes.Parts where parts.Value.PartName == "PUSHBUTTON" select parts.Value).FirstOrDefault();
		}
		#endregion
		#region Private Methods
		private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			switch (e.Category)
			{
				case UserPreferenceCategory.General:
					if (OnThemeChanged != null)
					{
						InitTheme();
						OnThemeChanged.Invoke(sender, e);
					}
					break;
			}
		}
		#endregion
	}
}