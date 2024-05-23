using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Manga
{
    public class RatingControl
    {
        const string PATH_TO_GRADES = "data\\users_info\\grades\\";
        public int mangaId { get; set; }
        public Dictionary<int, int> grades { get; private set; } = new Dictionary<int, int>(); //id, grade

        public RatingControl(int MangaID) {
            this.mangaId = MangaID;
        }

        [JsonConstructor]
        public RatingControl(int MangaID, Dictionary<int, int> grades)
        {
            this.mangaId = MangaID;
            this.grades = grades;
        }

        public static void SerializeArrayToFile(List<Title> titles, string path)
        {
            string json = JsonConvert.SerializeObject(titles, Formatting.Indented);
            File.WriteAllText(path + "\\manga", json);
        }

        public void addGrade(int userId, int grade)
        {
            try
            {
                grades.Add(userId, grade);
            }
            catch(ArgumentException ex) {
                Console.WriteLine($"Error: {ex.Message}\n Буде перезаписано значення");
            }
            grades[userId] = grade;

        }
        public int getGrade(int userId)
        {
            int res = 0;
            grades.TryGetValue(userId, out res);
            return res;
        }

        public double getAverage()
        {
                if (grades.Count == 0) return 0; 
                return grades.Values.Average(); 
        }

        public void SerializeGrades()
        {
            string json = JsonConvert.SerializeObject(grades, Formatting.Indented);
            if(!Directory.Exists(PATH_TO_GRADES)) Directory.CreateDirectory(PATH_TO_GRADES);
            File.WriteAllText(PATH_TO_GRADES + mangaId, json);
        }

        public void DeserializeGrades()
        {
            if (File.Exists(PATH_TO_GRADES + mangaId))
            {
                string json = File.ReadAllText(PATH_TO_GRADES + mangaId);
                Dictionary<int, int> res = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
                if (res != null) grades = res;
                else grades = new Dictionary<int, int>();
            }
        }

    }
}
