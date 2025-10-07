using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.Primitives;
using System.Resources;

namespace Resume.Maui.Shared.Resources.Localization
{

    public static class LocalizationResourcemanager
    {
        //static ResourceManager fa = new ResourceManager("Resume.Maui.Shared.Resources.Localization.Loc_fa", typeof(Loc_fa).Assembly);
        //static ResourceManager en = new ResourceManager("Resume.Maui.Shared.Resources.Localization.Loc_en", typeof(Loc_en).Assembly);
        //public static void ChangeToPersian()
        //{
        //    CultureInfo.CurrentCulture = new CultureInfo("fa-IR");
        //    CultureInfo.CurrentUICulture = new CultureInfo("fa-IR");
        //}

        //public static void ChangeToEnglish()
        //{
        //    CultureInfo.CurrentCulture = new CultureInfo("en-US");
        //    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
        //}

        //public static string GetTextByName(string name)
        //{

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fa")
        //        {
        //            return fa.GetString(name) ?? name;
        //        }
        //        else
        //        {
        //            return en.GetString(name) ?? name;
        //        }
        //    }
        //    return "";
        //}
    }
}
