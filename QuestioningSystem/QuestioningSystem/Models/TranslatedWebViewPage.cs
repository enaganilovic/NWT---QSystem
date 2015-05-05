using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using i18n;

    // For non-strongly typed view pages
    public abstract class TranslatedWebViewPage : WebViewPage, ILocalizing
    {
        private ILocalizingService service = new LocalizingService();

        public IHtmlString _(string text)
        {
            // If the session doesn't contain the users selected language, 
            // default to the processes current culture (can be defined 
            //in web.config to a specific language,
            // or to be the users browser language see below) 
            // <system.web>
            // <globalization culture="auto" uiCulture="auto" />
            // <globalization culture="en-US" uiCulture="en-US" />
            string[] languages;
            if (Session["CurrentLanguage"] == null)
            {
                languages = new string[] { CultureInfo.CurrentCulture.Name };
            }
            else
            {
                // this can ofcourse be switched to for example cookies for 
                // persistence that lasts longer then the lifetime of the session
                languages = new string[] { Session["CurrentLanguage"].ToString() };
            }

            return new HtmlString(this.service.GetText(text, languages));
        }
    }

    // For strongly typed view pages
    public abstract class TranslatedWebViewPage<T> : WebViewPage<T>, ILocalizing
    {
        private ILocalizingService service = new LocalizingService();

        public IHtmlString _(string text)
        {
            // If the session doesn't contain the users selected language, 
            // default to the processes current culture (can be defined 
            //in web.config to a specific language,
            // or to be the users browser language see below) 
            // <system.web>
            // <globalization culture="auto" uiCulture="auto" />
            // <globalization culture="en-US" uiCulture="en-US" />
            string[] languages;
            if (Session["CurrentLanguage"] == null)
            {
                languages = new string[] { CultureInfo.CurrentCulture.Name };
            }
            else
            {
                // this can ofcourse be switched to for example cookies for
                // persistence that lasts longer then the lifetime of the session
                languages = new string[] { Session["CurrentLanguage"].ToString() };
            }

            return new HtmlString(this.service.GetText(text, languages));
        }
    }
}