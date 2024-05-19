using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1.Manga
{
    public class Title
    {
        public int id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Chapters { get; private set; }

        const string PATH_TO_ARRAY_DATA = "data\\manga_catalog\\manga";
        const string PATH_TO_DIR = "data\\manga_catalog\\";

        public string PathToImg { get; set; }

        [JsonConstructor]
        public Title(string name, string description, List<string> chapters, string pathImg, int id)
        {
            PathToImg = pathImg;
            Name = name;
            Description = description;
            Chapters = chapters ?? new List<string>();
            this.id = id;
        }

        public Title(Image image, string name, string description, List<string> chapters, int id)
        {
            Name = name;
            Description = description;
            Chapters = chapters ?? new List<string>();
            PathToImg = GetPathImage(image);
            this.id = id;
        }

        private string GetPathImage(Image img)
        {
            if (img == null) return null;
            string res = PATH_TO_DIR+ $"{Name}\\";
            if (makeFolder(res))
            {
                img.Save(res + "preview");
                return res + "preview";
            }
            else return null;
        }

        public static bool makeFolder(string dir) {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return true;
        }

        public void addChapter(string path) => Chapters.Add(path);

        public static void SerializeArrayToFile(List<Title> titles, string path)
        {
            string json = JsonConvert.SerializeObject(titles, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static List<Title> DeserializeArrayFromFile(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Title> res = JsonConvert.DeserializeObject<List<Title>>(json);
                if (res == null) return new List<Title>();
                else return res;
            }
            else
            {
                File.Create(path);
                return new List<Title>();
            }
        }

        public static List<Title> DeserializeAllTitles() => DeserializeArrayFromFile(PATH_TO_ARRAY_DATA);
        public static void SerializeAllTitles(List<Title> titles) => SerializeArrayToFile(titles, PATH_TO_ARRAY_DATA);
    }



}
