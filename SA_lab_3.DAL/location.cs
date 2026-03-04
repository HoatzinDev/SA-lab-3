using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SA_lab_3.DAL
{
    public class Location
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> ImagePaths { get; set; } = new List<string>(); 
        public float X { get; set; }
        public float Y { get; set; }
        public User Manager { get; set; }
        public float rating;//averege
        public List<Question> questions = new List<Question>();
        public List<Review> reviews = new List<Review>();
        //public Location(User manager)
        //{
        //    Manager = manager;
        //}
    }
    public class Question { public string Text { get; set; }
        public string Answer { get; set; }
    }
    public class Review 
        {
        public float Rating { get; set; }// { get; private set; }
        public string Text { get; set; }//{ get; private set; }
        public User Writer { get; set; }//{ get; private set; }

        //public Review(float rating, string text, User writer)
        //{
        //    Rating = rating;
        //    Text = text;
        //    Writer = writer;
        //}
    }
    //public class User
    //{
    //    public string Name { get; set; }

    //    public List<Location> Visited { get; set; } = new List<Location>();
    //}
}
