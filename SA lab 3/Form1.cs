using System.Windows.Forms;
using System;
using System.Drawing;
using SA_lab_3.BLL;
using SA_lab_3.DAL;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace SA_lab_3
{
    public partial class Form1 : Form
    {
        private AppService _service = new AppService();
        private Location _selectedLocation; 

        public Form1(AppService service)
        {
            InitializeComponent();
            _service = service;

            this.Text = "RDR2 map - Login as: " + _service.CurrentUser.name;

            pictureBoxMap.Resize += PictureBox1_Resize;
            DrawMarkers();
        }

        private void PictureBox1_Resize(object sender, EventArgs e)
        {
            DrawMarkers();
        }

        private void DrawMarkers()
        {
            pictureBoxMap.Controls.Clear();
            if (pictureBoxMap.Image == null) return;

            float picWidth = pictureBoxMap.ClientSize.Width;
            float picHeight = pictureBoxMap.ClientSize.Height;
            float imgWidth = pictureBoxMap.Image.Width;
            float imgHeight = pictureBoxMap.Image.Height;
            float scale = Math.Min(picWidth / imgWidth, picHeight / imgHeight);
            float actualImgWidth = imgWidth * scale;
            float actualImgHeight = imgHeight * scale;
            float offsetX = (picWidth - actualImgWidth) / 2f;
            float offsetY = (picHeight - actualImgHeight) / 2f;

            foreach (var loc in _service.GetLocations())
            {
                Button btn = new Button();
                btn.Text = "↓";
                btn.Size = new Size(30, 30);

                // ЛОГІКА КОЛЬОРУ МАРКЕРА
                bool isVisited = _service.CurrentUser.Visited.Any(v => v.Id == loc.Id);
                btn.BackColor = isVisited ? Color.Green : Color.Red;
                btn.ForeColor = Color.White;

                int markerX = (int)(offsetX + (loc.X * actualImgWidth));
                int markerY = (int)(offsetY + (loc.Y * actualImgHeight));
                btn.Location = new Point(markerX - 15, markerY - 15);

                btn.Click += (s, e) => OpenLocation(loc);
                pictureBoxMap.Controls.Add(btn);
            }
        }

        private void OpenLocation(Location loc)
        {
            _selectedLocation = loc;
            labelTitle.Text = loc.name;
            labelDesc.Text = loc.description;

            //bool isVisited = _service.CurrentUser.Visited.Any(v => v.Id == loc.Id);

            bool isVisited = _service.CurrentUser.Visited.Contains(loc);
            visitedButton.Text = isVisited ? "Cancel " : "Mark as visited";
            visitedButton.BackColor = isVisited ? Color.Green : Color.LightGray;

            LoadImages(loc);
            LoadReviews(loc);
            LoadQuestions(loc);
        }
        private void LoadImages(Location loc)
        {
            ImagesPanel.Controls.Clear();
            Button btnAddImage = new Button { Text = "Upload Image", Width = 120, Height = 100 };
            btnAddImage.Click += (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        _service.AddImage(loc.Id, ofd.FileName);
                        OpenLocation(loc);
                    }
                }
            };
            ImagesPanel.Controls.Add(btnAddImage);
            foreach (var path in loc.ImagePaths)
            {
                // transform to relative path
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

                if (File.Exists(fullPath)) 
                {
                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromFile(fullPath);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(150, 150);
                    ImagesPanel.Controls.Add(pb);
                }
            }
        }

        private void LoadReviews(Location loc)
        {
            ReviesPanel.Controls.Clear();

            if (loc.reviews != null && loc.reviews.Count > 0)
            {
                foreach (var review in loc.reviews)
                {
                    Label lbl = new Label();

                    string authorName = review.Writer != null ? review.Writer.name : "Guest";
                    lbl.Text = $"{authorName}: {review.Text}";
                    lbl.AutoSize = true;

                    lbl.MaximumSize = new Size(ReviesPanel.Width - 25, 0);

                    ReviesPanel.Controls.Add(lbl);
                }
            }
        }

        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            if (_selectedLocation != null && !string.IsNullOrWhiteSpace(txtReviewInput.Text))
            {
                MessageBox.Show($"submit review:{txtReviewInput.Text}");
                _service.AddReview(_selectedLocation.Id, 5, txtReviewInput.Text);//rating
                txtReviewInput.Clear();
                LoadReviews(_selectedLocation);
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBoxMap_Click(object sender, EventArgs e) { }

        private void visitedButton_Click(object sender, EventArgs e)
        {
            _service.ToggleVisited(_selectedLocation.Id);
            bool isVisited = _service.CurrentUser.Visited.Contains(_selectedLocation);
            visitedButton.Text = isVisited ? "Cancel " : "Mark as visited";
            DrawMarkers();
        }
        private void LoadQuestions(Location loc)
        {
            QuestionsPanel.Controls.Clear();

            if (loc.questions != null)
            {
                foreach (var q in loc.questions)
                {

                    Label lblQ = new Label();
                    lblQ.Text = "Question: " + q.Text;
                    lblQ.AutoSize = true;
                    lblQ.MaximumSize = new Size(QuestionsPanel.Width - 25, 0);
                    lblQ.Font = new Font(lblQ.Font, FontStyle.Bold);
                    QuestionsPanel.Controls.Add(lblQ);

                    if (!string.IsNullOrEmpty(q.Answer))
                    {
                        Label lblA = new Label();
                        lblA.Text = "Answer:\n" + q.Answer;
                        lblA.AutoSize = true;
                        lblA.MaximumSize = new Size(QuestionsPanel.Width - 25, 0);
                        lblA.ForeColor = Color.Green;
                        QuestionsPanel.Controls.Add(lblA);
                    }

                    TextBox txtAnswer = new TextBox { Width = 150 };
                    Button btnAnswer = new Button { Text = "Leave answer", AutoSize = true };

                    btnAnswer.Click += (s, e) =>
                    {
                        if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                        {
                            _service.AnswerQuestion(loc.Id, q, txtAnswer.Text);
                            LoadQuestions(loc);
                        }
                    };
                    QuestionsPanel.Controls.Add(txtAnswer);
                    QuestionsPanel.Controls.Add(btnAnswer);

                    QuestionsPanel.Controls.Add(new Label { Text = " ", AutoSize = true, Width = QuestionsPanel.Width });
                }
            }

            if (_service.CurrentUser.Id == loc.Id)
            {
                Label spacer = new Label { Text = "---", AutoSize = true };
                QuestionsPanel.Controls.Add(spacer);

                TextBox newQuestionTxt = new TextBox { Width = 150 };
                Button addQuestionBtn = new Button { Text = "Ask", AutoSize = true };

                addQuestionBtn.Click += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(newQuestionTxt.Text))
                    {
                        _service.AddQuestion(loc.Id, newQuestionTxt.Text);
                        LoadQuestions(loc);
                    }
                };

                QuestionsPanel.Controls.Add(newQuestionTxt);
                QuestionsPanel.Controls.Add(addQuestionBtn);
            }
        }



        //OpenFileDialog
        private void btnAddImage_Click(object sender, EventArgs e) 
        {
            if (_selectedLocation == null) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _service.AddImage(_selectedLocation.Id, ofd.FileName);
                    OpenLocation(_selectedLocation);
                }
            }
        }
    }
}
