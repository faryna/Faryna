using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace VK_API
{
    class VKMusic
    {
        static public event EventHandler GetMusicComplete;
        static private List<PlayList> playList;
        static private int scope = (int)(VkontakteScopeList.audio | VkontakteScopeList.docs | VkontakteScopeList.friends | VkontakteScopeList.link | VkontakteScopeList.messages | VkontakteScopeList.notes | VkontakteScopeList.notify | VkontakteScopeList.offers | VkontakteScopeList.pages | VkontakteScopeList.photos | VkontakteScopeList.questions | VkontakteScopeList.video | VkontakteScopeList.wall);
        public VKMusic() { }

        public static List<PlayList> AddMusic(int userID)
        {
            playList = new List<PlayList>();
            TextWB = VK_API_Req.WebReq(String.Format("https://api.vk.com/method/audio.get?owner_id=" + userID + "&v=5.0&access_token=" + Authorize.AccessToken + "&callback=callbackFunc"));
            addMusicInPlayList();
            return playList;
        }

        public static PlayList AddMusicById(int OwnerID, int aId)
        {
            playList = new List<PlayList>();
            List<PlayList> pl = new List<PlayList>();
            TextWB = VK_API_Req.WebReq(String.Format("https://api.vk.com/method/audio.getById?audios=" + OwnerID + "_" + aId + "&v=5.0&access_token=" + Authorize.AccessToken + "&callback=callbackFunc"));
            pl = addMusicInPlayList();
            return pl[0];
        }

        static List<PlayList> addMusicInPlayList()
        {
            
            List<String> lstr = new List<String>();
            int a =
            TextWB.IndexOf("[");
            string str = TextWB.Substring(a);
            int begin, end;
            string str2 = "";
            while ((begin = str.IndexOf("{")) != -1)
            {
                end = str.IndexOf("}");
                str2 = str.Substring(begin, end - begin + 1);
                lstr.Add(str2);
                str2 = str.Substring(end + 2);
                str = str2;
            }
            string strUrl;
            Regex myReg = new Regex("(?<name>[\\w+]+)\":\"?(?<value>[\\w+:\\\\/\\\\/\\s?\\.?]+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?\\w+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string title = "", url = "", artist = "";
            int aid = -1, owner = -1;
            foreach (string i in lstr)
            {
                foreach (Match m in myReg.Matches(i))
                {
                    if (m.Groups["name"].Value == "title")
                        title = m.Groups["value"].Value;
                    else if (m.Groups["name"].Value == "artist")
                        artist = m.Groups["value"].Value;
                    else if (m.Groups["name"].Value == "id")
                        aid = Convert.ToInt32(m.Groups["value"].Value);
                    else if (m.Groups["name"].Value == "owner_id")
                        owner = Convert.ToInt32(m.Groups["value"].Value);
                    else if (m.Groups["name"].Value == "url")
                    {
                        url = "";
                        foreach (char c in m.Groups["value"].Value)
                        {
                            if (c != '\\')
                                url += c;
                        }
                    }
                }
                playList.Add(new PlayList(aid, owner, artist, title, url));
                aid = -1;
                owner = -1;
            }
            return playList;
        }

        static void EventOK()
        {
            if (GetMusicComplete != null)
            {
                GetMusicComplete.Invoke(null, EventArgs.Empty);
            }
        }

        static public string TextWB
        {
            get;
            set;
        }
        static public List<PlayList> GetPlaylist
        {
            get { return playList; }
        }
    }
}
