using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VK_API
{
    enum FriendListOrder { name, hints, random }
    public class Friend
    {
        private string lastName;
        private string firstName;
        private int uid;
        static FriendListOrder friendListOrder = FriendListOrder.hints;
        public Friend()
        {
            
        }
        public Friend(int uid, string first, string name, string AvatarUrl, int online)
        {
            this.firstName = first;
            this.lastName = name;
            this.uid = uid;
            this.AvatarUrl = AvatarUrl;
            this.Online = online;
            if (online == 1)
                OnlineImage = "Online.png";
            else if (online == 2)
                OnlineImage = "OnlinePhone.png";
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Firstname
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int UserID
        {
            get { return uid; }
            internal set { uid = value; }
        }

        public string GetFullName
        {
            get { return LastName + "  " + Firstname; }
        }

        public string AvatarUrl { get; set; }

        public int Online { get; set; }

        public string OnlineImage { get; private set; }

        public static List<Friend> InitListFriend(int userID)
        {
            string TextWB = VK_API_Req.WebReq(String.Format("https://api.vk.com/method/friends.get?user_id=" + userID + "&order="+friendListOrder.ToString()+"&fields=screen_name,photo_50,online,online_mobile,order&v=5.0&access_token=" + Authorize.AccessToken + "&callback=callbackFunc"));
            List<Friend> friendList = new List<Friend>();
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
            Regex myReg = new Regex("(?<name>[\\w+]+)\":\"?(?<value>[\\w+:\\\\/\\\\/\\s?\\.?]+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?\\w+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string lastNem = "", firstName = "", AvatrUrl = "", online = "", onlineP = "";
            int uid = 0;
            foreach (string i in lstr)
            {
                foreach (Match m in myReg.Matches(i))
                {
                    if (m.Groups["name"].Value == "id")
                        uid = Convert.ToInt32(m.Groups["value"].Value);
                    else if (m.Groups["name"].Value == "first_name")
                        firstName = m.Groups["value"].Value;
                    else if (m.Groups["name"].Value == "last_name")
                        lastNem = m.Groups["value"].Value;
                    else if (m.Groups["name"].Value == "photo_50")
                    {
                        AvatrUrl = "";
                        foreach (char c in m.Groups["value"].Value)
                        {
                            if (c != '\\')
                                AvatrUrl += c;
                        }
                    }
                    else if (m.Groups["name"].Value == "online")
                        online = m.Groups["value"].Value;
                    else if (m.Groups["name"].Value == "online_mobile")
                        onlineP = m.Groups["value"].Value;
                }
                int t = i.IndexOf("online");
                online = i[t + 8].ToString();
                int tmp = 0;
                if (online == "1")
                {
                    if (i.IndexOf("online_mobile") != -1)
                    {
                        tmp = 2;
                        
                    }
                    else
                    {
                        tmp = 1;
                    }
                }
                friendList.Add(new Friend(uid, firstName, lastNem, AvatrUrl, tmp));
            }
            return friendList;
        }
    }
}
