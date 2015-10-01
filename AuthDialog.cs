using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_API
{
    public partial class AuthDialog : Form
    {
       public event EventHandler AuthComplite;
        void EventOK()
        {
            if (AuthComplite != null)
            {
                AuthComplite.Invoke(this, EventArgs.Empty);
            }
        }
        private int scope = (int)(VkontakteScopeList.audio | VkontakteScopeList.docs | VkontakteScopeList.friends | VkontakteScopeList.link | VkontakteScopeList.messages | VkontakteScopeList.notes | VkontakteScopeList.notify | VkontakteScopeList.offers | VkontakteScopeList.pages | VkontakteScopeList.photos | VkontakteScopeList.questions | VkontakteScopeList.video | VkontakteScopeList.wall);
        private int appId;
        public AuthDialog()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token", (int)AppID.id, scope));
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                string accessToken = "";
                int userId = 0;
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        userId = Convert.ToInt32(m.Groups["value"].Value);
                    }
                }
                //MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", accessToken, userId));
                AccessToken = accessToken;
                UserID = userId;
                EventOK();
                Close();
            }
        }
        public string AccessToken { get; private set; }
        public int UserID { get; private set; }
    }
}
