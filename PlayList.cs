using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VK_API
{
    public class PlayList
    {
        private string title;
        private string url;
        private string artist;
        private int id;
        private int ownerId;
        public PlayList()
        {

        }
        public PlayList(int id, int ownerId, string artist, string title, string url)
        {
            this.title = title;
            this.url = url;
            this.artist = artist;
            this.id = id;
            this.ownerId = ownerId;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }

    public class SavePlaylist
    {
        private string name;
        private List<PlayList> pl;
        public SavePlaylist() { }
        static string folderName = "playlist";
        public SavePlaylist(string name, List<PlayList> pl)
        {
            this.name = name;
            this.pl = pl;
        }
        public SavePlaylist NewList(string name)
        {
            this.name = name;
            Save();
            return this;
        }
        public string Name { get { return name; } }
        public List<PlayList> GetPlayList { get { return pl; } }
        public void Add(PlayList playList)
        {
            pl.Add(playList);
            Save();
        }
        public void Save()
        {
            XDocument xd = new XDocument(new XElement("root"));
            if (pl != null)
                pl.ForEach(x => xd.Root.Add(new XElement("Music", new XAttribute("ownerId", x.OwnerId), new XAttribute("id", x.Id), new XAttribute("title", x.Title), new XAttribute("artist", x.Artist), new XAttribute("url", x.Url))));
            int a = name.Length - 1;
            int b = a - 3;
            string str = "";
            for (int i = b; i <= a; i++)
                str += name[i];
            if (str != ".xml")
                name += ".xml";
            xd.Save(folderName + "\\" + name);
        }
        public void Delete()
        {
            File.Delete(folderName + "\\" + name);
        }
        public static List<SavePlaylist> Load()
        {
            DirectoryInfo info = new DirectoryInfo(folderName);
            var files = info.GetFiles().ToList();
            List<SavePlaylist> savePlayList = new List<SavePlaylist>();
            XDocument doc;
            foreach (var i in files)
            {

                doc = XDocument.Load(folderName + "\\" + i.Name);
                List<PlayList> lps = new List<PlayList>();

                List<XElement> xe = doc.Root.Elements("Music").ToList();
                //PlayList p = VKMusic.AddMusicById(Convert.ToInt32(x.Attribute("id").Value), Convert.ToInt32(x.Attribute("ownerId").Value));
                //xe.ForEach(x => 
                foreach (var x in xe)
                    lps.Add(VKMusic.AddMusicById(Convert.ToInt32(x.Attribute("ownerId").Value), Convert.ToInt32(x.Attribute("id").Value)));
                //);
                savePlayList.Add(new SavePlaylist(i.Name, lps));

            }
            return savePlayList;
        }
    }
}
