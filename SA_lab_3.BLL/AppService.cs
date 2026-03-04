using SA_lab_3.DAL;
using System.Collections.Generic;
using System.Linq;
namespace SA_lab_3.BLL
{
    public class AppService
    {
        private Data data = new Data();
        public User CurrentUser { get; private set; }

        public List<User> GetUsers() => data.GetUsers();

        public void Login(User user)
        {
            CurrentUser = user;
        }

        public List<Location> GetLocations() => data.GetAll();

        public void AddReview(int locationId, float rate, string text)
        {
            var loc = data.GetAll().FirstOrDefault(l => l.Id == locationId);
            if (loc != null)
            {
                loc.reviews.Add(new Review { Rating = rate, Text = text, Writer = CurrentUser });
                data.SaveData();
            }
        }

        public void AddQuestion(int locationId, string questionText)
        {
            var loc = data.GetAll().FirstOrDefault(l => l.Id == locationId);
            if (loc != null && CurrentUser != null && loc.Id == CurrentUser.Id)//if (loc != null && CurrentUser != null && loc.Manager.Id == CurrentUser.Id)
            {
                loc.questions.Add(new Question { Text = questionText });
                data.SaveData();
            }
        }

        public void AnswerQuestion(int locationId, Question question, string answerText)
        {
            var loc = data.GetAll().FirstOrDefault(l => l.Id == locationId);
            if (loc != null && CurrentUser != null)
            {

                string formattedAnswer = $"{CurrentUser.name}: {answerText}";

                if (string.IsNullOrEmpty(question.Answer))
                    question.Answer = formattedAnswer;
                else
                    question.Answer += "\n" + formattedAnswer;

                data.SaveData();
            }
        }

        public void ToggleVisited(int locationId)
        {
            var loc = data.GetAll().FirstOrDefault(l => l.Id == locationId);
            if (loc != null && CurrentUser != null)
            {
                if (CurrentUser.Visited.Contains(loc))CurrentUser.Visited.Remove(loc);
                else CurrentUser.Visited.Add(loc);    
            }
        }

        public void AddImage(int locationId, string sourceFilePath)
        {
            var loc = data.GetAll().FirstOrDefault(l => l.Id == locationId);
            if (loc != null)
            {

                string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(sourceFilePath);
                string destPath = Path.Combine(imagesFolder, fileName);

                File.Copy(sourceFilePath, destPath);

                string relativePath = Path.Combine("Images", fileName);
                loc.ImagePaths.Add(relativePath);

                data.SaveData(); // JSON
            }
        }

    }
}

