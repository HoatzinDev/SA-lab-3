using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SA_lab_3.BLL;
using SA_lab_3.DAL;
namespace SA_lab_3
{
    public partial class enter : Form
    {
        private AppService _service;
        public enter(AppService service)
        {
            InitializeComponent();
            _service = service;
            Start();//buttons
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {}
        void Start()
        {

            flowLayoutPanel1.Controls.Clear();

            foreach (User us in _service.GetUsers()) // BLL
            {
                Button btn = new Button();
                btn.Text = us.name;
                btn.Size = new Size(300, 100);

                btn.Click += (s, e) =>
                {
                    _service.Login(us);  
                    Form1 mainApp = new Form1(_service); 
                    mainApp.Show();         
                    this.Hide();             
                };

                flowLayoutPanel1.Controls.Add(btn);
            }
        }
    }
}
