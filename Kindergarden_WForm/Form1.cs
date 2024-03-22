using Kindergarden_Models;
using static Kindergarden_Data.KindergardenDbContext;
using Kindergarden_Data;
using Kindergarden_Services;
using System.Linq;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Diagnostics.Contracts;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Forms;


namespace Kindergarden_WForm
{

    public partial class Form1 : Form
    {
        const int SplitterDist = 220;
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;
        SqlDataAdapter adapter;
        DataTable dataTable;
        SqlConnection connection = new SqlConnection("Server=KAMENPC\\SQLEXPRESS;Database=Kindergarden;Integrated Security=true;TrustServerCertificate=True");
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
            adapter = new SqlDataAdapter("SELECT Concat(k.FirstName,' ',k.LastName) as 'Kid name', Age, \r\nConcat(p.FirstName,' ',p.LastName) as 'Parent name',\r\nPhoneNumber as'Phone number',Address, GroupName as 'Group name'  from Kids as k\r\nJOIN Parents as p on (p.ParentId=k.ParentId)\r\nJoin Groups as g on (k.GroupId=g.GroupId)", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView2.BringToFront();
            dataGridView3.BringToFront();
            dataGridView4.BringToFront();
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            button11.Visible = false;
            dataGridView1.Visible = true;
            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
            textBox1.Visible = false;

            Search2.Visible = false;


        }
        private void button2_Click(object sender, EventArgs e) // List all groups
        {
            MenuCollapse();
            adapter = new SqlDataAdapter(" Select Concat(k.FirstName,' ',k.LastName) as 'Kometa' from Kids as k join Groups as g on (k.GroupId=g.GroupId) Where(k.GroupId=1)", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;


            adapter = new SqlDataAdapter("Select Concat(k.FirstName,' ',k.LastName) as 'Luna' from Kids as k join Groups as g on (k.GroupId=g.GroupId) Where(k.GroupId=2)", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;

            adapter = new SqlDataAdapter("Select Concat(k.FirstName,' ',k.LastName) as 'Zvezdichka' from Kids as k join Groups as g on (k.GroupId=g.GroupId) Where(k.GroupId=3)", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;

            adapter = new SqlDataAdapter("Select Concat(k.FirstName,' ',k.LastName) as 'Slunchice' from Kids as k join Groups as g on (k.GroupId=g.GroupId) Where(k.GroupId=4)", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView4.DataSource = dataTable;

            dataGridView1.BringToFront();
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            dataGridView4.Visible = true;

            Search2.Visible = false;
            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
            button11.Visible = false;
            textBox1.Visible = false;



        }

        private void button4_Click(object sender, EventArgs e) // List All Parents
        {
            MenuCollapse();

            adapter = new SqlDataAdapter("Select CONCAT(FirstName,' ', LastName)as 'Parent name', PhoneNumber as 'Phone number', Address from Parents", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.BringToFront();
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView1.Visible = true;
            Search2.Visible = false;
            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
            button11.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e) //Search Kid and Parent
        {

            MenuCollapse();
            dataGridView1.Rows.Clear();


            dataGridView1.BringToFront();
            label2.Visible = true;
            label2.Text = "Enter kid's first name:";
            textBox1.Visible = true;
            button11.Visible = true;

            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;
            Search2.Visible = false;
            dataGridView1.Columns["Id"].Visible = false;

        }

        private void button8_Click(object sender, EventArgs e) // Update 
        {
            MenuCollapse();



            Search2.Visible = true;

            button11.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;

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
            label1.Visible = true;
            splitContainer1.Panel1Collapsed = false;
            for (int i = 0; i < SplitterDist; i++)
            {
                splitContainer1.SplitterDistance = i;
            }
            dataGridView1.Visible = false;
            button11.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;

        } // Hamburger

        private void button11_Click(object sender, EventArgs e) // Search Button for kid and parent
        {
            string query = $"SELECT Concat(k.FirstName,' ',k.LastName) as 'Kid name', Age, Concat(p.FirstName,' ',p.LastName) as 'Parent name',PhoneNumber as'Phone number',Address, GroupName as 'Group name'  from Kids as k JOIN Parents as p on (p.ParentId=k.ParentId)Join Groups as g on (k.GroupId=g.GroupId) where(k.FirstName='{textBox1.Text}')";
            adapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Visible = true;
            textBox1.Text = null;

            label3.Visible = false;
            Select.Visible = false;
            textBox2.Visible = false;

        }

        private void Search2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Kid kid1;
            Parent parent;
            Group group;
            List<Kid> kids = db.Kids.Where(x => x.FirstName == textBox1.Text).ToList();
            for (int i = 0; i < kids.Count; i++)
            {
                kid1 = kids[i];
                group = db.Groups.FirstOrDefault(y => y.GroupId == kid1.GroupId);
                parent = db.Parents.FirstOrDefault(x => x.ParentId == kid1.ParentId);
                dataGridView1.Rows.Add(i + 1, $"{kid1.FirstName + " " + kid1.LastName}", kid1.Age.ToString(),
                    $"{parent.FirstName + " " + parent.LastName}", parent.PhoneNumber, parent.Address, group.GroupName);
            }

            dataGridView1.Columns["Id"].Visible = true;
            dataGridView1.Visible = true;
            textBox2.Text = null;

            label3.Visible = true;
            Select.Visible = true;
            textBox2.Visible = true;
        } // search za update 

        private void Select_Click(object sender, EventArgs e) // Select
        {
            dataGridView1.Rows.Clear();
            Kid kid = new Kid();
            Parent parent = new Parent();
            Group group = new Group();
            List<Kid> kids = db.Kids.Where(x => x.FirstName == textBox1.Text).ToList();

            for (int i = 0; i < kids.Count; i++)
            {
                if (i + 1 == int.Parse(textBox2.Text))
                {
                    kid = kids[i];
                    parent = db.Parents.FirstOrDefault(x => x.ParentId == kid.ParentId);
                    group = db.Groups.FirstOrDefault(x => x.GroupId == kid.GroupId);
                }
            }
            dataGridView1.Rows.Add("", $"{kid.FirstName + " " + kid.LastName}", kid.Age.ToString(),
            $"{parent.FirstName + " " + parent.LastName}", parent.PhoneNumber, parent.Address);
            dataGridView1.Visible = true;
            dataGridView1.Columns["Id"].Visible = false;
            button7.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e) //Save changes
        {
            //TODO: Find which kid 
            Kid kid = new Kid();
            Parent parent = new Parent();
            Group group = new Group();

            var kidName = dataGridView1.Rows[0].Cells[1].Value.ToString().Split().ToArray();
            var parentName = dataGridView1.Rows[0].Cells[3].Value.ToString().Split().ToArray();
            kid.FirstName = kidName[0];
            kid.LastName = kidName[1];

            kid.Age = int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());
            parent.FirstName = parentName[0];
            parent.LastName = parentName[1];
            parent.PhoneNumber = dataGridView1.Rows[0].Cells[4].Value.ToString();
            parent.Address = dataGridView1.Rows[0].Cells[5].Value.ToString();
            if (kid.Age == 3)
            {
                group = db.Groups.FirstOrDefault(x => x.GroupId == 1);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if (kid.Age == 4)
            {
                group = db.Groups.FirstOrDefault(x => x.GroupId == 2);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if (kid.Age == 5)
            {
                group = db.Groups.FirstOrDefault(x => x.GroupId == 3);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            else if (kid.Age == 6)
            {
                group = db.Groups.FirstOrDefault(x => x.GroupId == 4);
                kid.GroupId = group.GroupId;
                kid.Group = group;
            }
            db.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e) // Create kid
        {
            Form2 form2 = new Form2();
           
            form2.Show();
            this.Hide();

        }
    }
}
