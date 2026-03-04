namespace SA_lab_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBoxMap = new PictureBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            ImagesPanel = new FlowLayoutPanel();
            visitedButton = new Button();
            splitContainer1 = new SplitContainer();
            btnSubmitReview = new Button();
            txtReviewInput = new TextBox();
            ReviesPanel = new FlowLayoutPanel();
            Rating = new Label();
            QuestionsPanel = new FlowLayoutPanel();
            labelDesc = new Label();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ReviesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxMap
            // 
            pictureBoxMap.Dock = DockStyle.Fill;
            pictureBoxMap.Image = (Image)resources.GetObject("pictureBoxMap.Image");
            pictureBoxMap.InitialImage = (Image)resources.GetObject("pictureBoxMap.InitialImage");
            pictureBoxMap.Location = new Point(0, 0);
            pictureBoxMap.Name = "pictureBoxMap";
            pictureBoxMap.Size = new Size(530, 450);
            pictureBoxMap.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMap.TabIndex = 0;
            pictureBoxMap.TabStop = false;
            pictureBoxMap.Click += pictureBoxMap_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(-29, -68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            textBox1.Text = "Place_Name";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(-29, -164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 75);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // ImagesPanel
            // 
            ImagesPanel.Dock = DockStyle.Top;
            ImagesPanel.Location = new Point(0, 0);
            ImagesPanel.Name = "ImagesPanel";
            ImagesPanel.Size = new Size(266, 127);
            ImagesPanel.TabIndex = 5;
            ImagesPanel.Paint += flowLayoutPanel1_Paint;
            // 
            // visitedButton
            // 
            visitedButton.Dock = DockStyle.Top;
            visitedButton.Location = new Point(0, 127);
            visitedButton.Name = "visitedButton";
            visitedButton.Size = new Size(266, 34);
            visitedButton.TabIndex = 6;
            visitedButton.Text = "Visited ?";
            visitedButton.UseVisualStyleBackColor = true;
            visitedButton.Click += visitedButton_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnSubmitReview);
            splitContainer1.Panel1.Controls.Add(txtReviewInput);
            splitContainer1.Panel1.Controls.Add(ReviesPanel);
            splitContainer1.Panel1.Controls.Add(QuestionsPanel);
            splitContainer1.Panel1.Controls.Add(labelDesc);
            splitContainer1.Panel1.Controls.Add(labelTitle);
            splitContainer1.Panel1.Controls.Add(visitedButton);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(ImagesPanel);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBoxMap);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 7;
            // 
            // btnSubmitReview
            // 
            btnSubmitReview.Dock = DockStyle.Bottom;
            btnSubmitReview.Location = new Point(0, 370);
            btnSubmitReview.Name = "btnSubmitReview";
            btnSubmitReview.Size = new Size(266, 34);
            btnSubmitReview.TabIndex = 12;
            btnSubmitReview.Text = "send";
            btnSubmitReview.UseVisualStyleBackColor = true;
            btnSubmitReview.Click += btnSubmitReview_Click;
            // 
            // txtReviewInput
            // 
            txtReviewInput.Dock = DockStyle.Bottom;
            txtReviewInput.Location = new Point(0, 404);
            txtReviewInput.Multiline = true;
            txtReviewInput.Name = "txtReviewInput";
            txtReviewInput.Size = new Size(266, 46);
            txtReviewInput.TabIndex = 11;
            // 
            // ReviesPanel
            // 
            ReviesPanel.Controls.Add(Rating);
            ReviesPanel.Dock = DockStyle.Top;
            ReviesPanel.Location = new Point(0, 285);
            ReviesPanel.Name = "ReviesPanel";
            ReviesPanel.Size = new Size(266, 74);
            ReviesPanel.TabIndex = 10;
            // 
            // Rating
            // 
            Rating.AutoSize = true;
            Rating.Dock = DockStyle.Top;
            Rating.Location = new Point(3, 0);
            Rating.Name = "Rating";
            Rating.Size = new Size(37, 25);
            Rating.TabIndex = 11;
            Rating.Text = "?/5";
            // 
            // QuestionsPanel
            // 
            QuestionsPanel.Dock = DockStyle.Top;
            QuestionsPanel.Location = new Point(0, 211);
            QuestionsPanel.Name = "QuestionsPanel";
            QuestionsPanel.Size = new Size(266, 74);
            QuestionsPanel.TabIndex = 9;
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Dock = DockStyle.Top;
            labelDesc.Location = new Point(0, 186);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(102, 25);
            labelDesc.TabIndex = 8;
            labelDesc.Text = "Description";
            labelDesc.Click += label2_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Location = new Point(0, 161);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(44, 25);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Title";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ReviesPanel.ResumeLayout(false);
            ReviesPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMap;
        private TextBox textBox1;
        private PictureBox pictureBox2;
        private FlowLayoutPanel ImagesPanel;
        private Button visitedButton;
        private SplitContainer splitContainer1;
        private Label labelDesc;
        private Label labelTitle;
        private FlowLayoutPanel ReviesPanel;
        private Label Rating;
        private FlowLayoutPanel QuestionsPanel;
        private TextBox txtReviewInput;
        private Button btnSubmitReview;
    }
}
