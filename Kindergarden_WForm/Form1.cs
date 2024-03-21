using Kindergarden_Models;
using static Kindergarden_Data.KindergardenDbContext;
using Kindergarden_Data;
using Kindergarden_Services;
using System.Linq;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Diagnostics.Contracts;

namespace Kindergarden_WForm
{

    public partial class Form1 : Form
    {
        const int SplitterDist = 220;
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;
        public Form1()
        {
            InitializeComponent();
            this.db = new KindergardenDbContext();
            db.Database.EnsureCreated();
            this.kidService = new KidService(db);
            this.parentService = new ParentService(db);
            this.groupService = new GroupService(db);

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
            dataGridView1.Rows.Clear();
            Kid kid;
            Parent parent;
            Group group;
            List<Kid> kidsList = db.Kids.ToList();
            foreach (var kidTemp in kidsList)
            {
                kid = kidTemp;
                parent = db.Parents.FirstOrDefault(x => x.ParentId == kid.ParentId);
                kid.Parent = parent;
                group = db.Groups.FirstOrDefault(y => y.GroupId == kid.GroupId);
                kid.Group = group;
                dataGridView1.Rows.Add($"{kid.FirstName + " " + kid.LastName}", kid.Age.ToString(),
                    $"{parent.FirstName + " " + parent.LastName}", parent.PhoneNumber, parent.Address, group.GroupName);
            }

            dataGridView1.Visible = true;
            dataGridView1.Columns["Kid_name"].Visible = true;
            dataGridView1.Columns["Age"].Visible = true;
            dataGridView1.Columns["Parent_name"].Visible = true;
            dataGridView1.Columns["Phone_number"].Visible = true;
            dataGridView1.Columns["Address"].Visible = true;
            dataGridView1.Columns["Group"].Visible = true;
            dataGridView1.Columns["Group1"].Visible = false;
            dataGridView1.Columns["Group2"].Visible = false;
            dataGridView1.Columns["Group3"].Visible = false;
            dataGridView1.Columns["Group4"].Visible = false;
            //clear table


        }
        private void button2_Click(object sender, EventArgs e) // List all groups
        {
            MenuCollapse();
            dataGridView1.Rows.Clear();
            List<Kid> group1 = db.Kids.Where(x => x.GroupId == 1).ToList();
            List<Kid> group2 = db.Kids.Where(x => x.GroupId == 2).ToList();
            List<Kid> group3 = db.Kids.Where(x => x.GroupId == 3).ToList();
            List<Kid> group4 = db.Kids.Where(x => x.GroupId == 4).ToList();
            int longestGroup = Math.Max(Math.Max(group1.Count, group2.Count), Math.Max(group3.Count, group4.Count)); ;

            List<Kid> kidsOrdered = new List<Kid>();


            for (int i = 0; i < longestGroup; i++)
            {
                if (i < group1.Count)
                {
                    kidsOrdered.Add(group1[i]);
                }
                else
                {
                    kidsOrdered.Add(null);
                }
                if (i < group2.Count)
                {
                    kidsOrdered.Add(group2[i]);
                }
                else
                {
                    kidsOrdered.Add(null);
                }
                if (i < group3.Count)
                {
                    kidsOrdered.Add(group3[i]);
                }
                else
                {
                    kidsOrdered.Add(null);
                }
                if (i < group4.Count)
                {
                    kidsOrdered.Add(group4[i]);
                }
                else
                {
                    kidsOrdered.Add(null);
                }
                string[] kidsFNames = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    if (kidsOrdered[j] == null)
                    {
                        kidsFNames[j] = "";
                    }
                    else
                    {
                        kidsFNames[j] = kidsOrdered[j].FirstName + " " + kidsOrdered[j].LastName;
                    }
                }


                dataGridView1.Rows.Add("", "", "", "", "", "", kidsFNames[0], kidsFNames[1], kidsFNames[2], kidsFNames[3]);
                kidsOrdered.Clear();

            }




            dataGridView1.Visible = true;
            dataGridView1.Columns["Group1"].Visible = true;
            dataGridView1.Columns["Group2"].Visible = true;
            dataGridView1.Columns["Group3"].Visible = true;
            dataGridView1.Columns["Group4"].Visible = true;

            dataGridView1.Columns["kid_name"].Visible = false;
            dataGridView1.Columns["group"].Visible = false;
            dataGridView1.Columns["age"].Visible = false;
            dataGridView1.Columns["Parent_name"].Visible = false;
            dataGridView1.Columns["Phone_number"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;



        }

        private void button4_Click(object sender, EventArgs e) // List All Parents
        {
            MenuCollapse();
            dataGridView1.Rows.Clear();

            List<Parent> parentList = db.Parents.ToList();
            Parent parent;
            foreach (var parentTemp in parentList)
            {
                parent = parentTemp;
                dataGridView1.Rows.Add("", "", $"{parent.FirstName + " " + parent.LastName}", parent.PhoneNumber, parent.Address);
            }

            dataGridView1.Visible = true;

            dataGridView1.Columns["Kid_name"].Visible = false;
            dataGridView1.Columns["Age"].Visible = false;
            dataGridView1.Columns["Parent_name"].Visible = true;
            dataGridView1.Columns["Phone_number"].Visible = true;
            dataGridView1.Columns["Address"].Visible = true;
            dataGridView1.Columns["Group"].Visible = false;
            dataGridView1.Columns["Group1"].Visible = false;
            dataGridView1.Columns["Group2"].Visible = false;
            dataGridView1.Columns["Group3"].Visible = false;
            dataGridView1.Columns["Group4"].Visible = false;
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
            dataGridView1.Visible = false;

        } // Hamburger

        
    }
}
