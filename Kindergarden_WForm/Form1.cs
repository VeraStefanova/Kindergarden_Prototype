using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using System.Linq;

namespace Kindergarden_WForm
{

    public partial class Form1 : Form
    {
        const int SplitterDist = 220;
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;
        DataGridView table = new DataGridView();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
            splitContainer1.SplitterDistance = SplitterDist;
        }

        private void button1_Click(object sender, EventArgs e) //List all kids
        {
            MenuCollapse();

            foreach (var kid in db.Kids)
            {
                Parent parent = db.Parents.FirstOrDefault(x => x.ParentId == kid.ParentId);
                table.Rows.Add($"{kid.FirstName.ToString() + " " + kid.LastName.ToString()}", kid.Age.ToString(), $"{parent.FirstName.ToString() + " " + parent.LastName.ToString()}", parent.PhoneNumber.ToString(), parent.Address.ToString());
            }

            dataGridView1.Visible = true;
            


        }
        private void button2_Click(object sender, EventArgs e) // List all groups
        {
            MenuCollapse();




        }




        private void button8_Click(object sender, EventArgs e) // Update parent
        {

        }
        private void MenuCollapse()
        {
            for (int i = splitContainer1.SplitterDistance; i > 0; i--)
            {
                splitContainer1.SplitterDistance = i;
            }
            splitContainer1.Panel1Collapsed = true;
            button3.Visible = true;
            //TODO: Make labels and buttons visible after collapse
        } // Collapse
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            splitContainer1.Panel1Collapsed = false;
            for (int i = 0; i < SplitterDist; i++)
            {
                splitContainer1.SplitterDistance = i;
            }

        } // Hamburger

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
