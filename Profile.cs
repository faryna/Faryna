using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_API
{
    
    class AccountGetProfileInfo
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public AccountGetProfileInfo()
        {
            Parse(VK_API_Req.WebReq("https://api.vk.com/method/account.getProfileInfo?access_token="+Authorize.AccessToken));
        }

        void Parse(string str)
        {
            Regex myReg = new Regex("(?<name>[\\w+]+)\":\"?(?<value>[\\w+:\\\\/\\\\/\\s?\\.?]+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?\\w+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string lastName = "", firstName = "";
            int uid = 0;
            foreach (Match m in myReg.Matches(str))
            {
                if (m.Groups["name"].Value == "first_name")
                    firstName = m.Groups["value"].Value;
                else if (m.Groups["name"].Value == "last_name")
                    lastName = m.Groups["value"].Value;
            }
            Name = firstName;
            Surname = lastName;
        }
    }

    public class UserInfo
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int ID { get; private set; }
        public int CountFriend { get; private set; }
        public int CountShared { get; private set; }
        public int CountPhotos { get; private set; }
        public int CountAudios { get; private set; }
        public string Status { get; private set; }
        public string Avatar { get; private set; }
        public int Online { get; private set; }

        public UserInfo(int userID)
        {
            Parse(VK_API_Req.WebReq(String.Format("https://api.vk.com/method/users.get?user_ids={0}&fields=counters,status,photo_100,online&access_token={1}", userID, Authorize.AccessToken)));
            //MessageBox.Show(Name + " " + Surname + "; " + ID + "; " + CountFriend+"; "+CountShared);
        }

        void Parse(string str)
        {
            Regex myReg = new Regex("(?<name>[\\w+]+)\":\"?(?<value>[\\w+:\\\\/\\\\/\\s?\\.?]*([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?\\w+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //string lastName = "", firstName = "";
            int uid = 0;
            foreach (Match m in myReg.Matches(str))
            {
                if (m.Groups["name"].Value == "first_name")
                    Name = m.Groups["value"].Value;
                else if (m.Groups["name"].Value == "last_name")
                    Surname = m.Groups["value"].Value;
                else if (m.Groups["name"].Value == "uid")
                    ID = Convert.ToInt32(m.Groups["value"].Value);
                else if (m.Groups["name"].Value == "friends")
                    CountFriend = Convert.ToInt32(m.Groups["value"].Value);
                else if (m.Groups["name"].Value == "mutual_friends")
                    CountShared = Convert.ToInt32(m.Groups["value"].Value);
                else if (m.Groups["name"].Value == "audios")
                    CountAudios = Convert.ToInt32(m.Groups["value"].Value);
                else if (m.Groups["name"].Value == "photos")
                    CountPhotos = Convert.ToInt32(m.Groups["value"].Value);
                else if (m.Groups["name"].Value == "status")
                    Status = m.Groups["value"].Value;
                else if (m.Groups["name"].Value == "photo_100")
                {
                    foreach (char c in m.Groups["value"].Value)
                    {
                        if (c != '\\')
                            Avatar += c;
                    }
                }
                int t = str.IndexOf("online");
                string s = str[t + 8].ToString();
                Online = 0;
                if (s == "1")
                {
                    if (str.IndexOf("online_mobile") != -1)
                        Online = 2;
                    else
                        Online = 1;
                }
            }
            //Name = firstName;
            //Surname = lastName;
        }
    }
}
