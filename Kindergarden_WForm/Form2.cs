using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kindergarden_WForm
{
    public partial class Form2 : Form
    {
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;
        public Form2()
        {
            InitializeComponent();
            this.db = new KindergardenDbContext();
            db.Database.EnsureCreated();
            this.kidService = new KidService(db);
            this.parentService = new ParentService(db);
            this.groupService = new GroupService(db);

        }
        private void Copy()
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateKidage_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSaveExit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBoxCreateKidName.Text) && !String.IsNullOrEmpty(TextBoxCreateKidAge.Text)
                && !String.IsNullOrEmpty(TextBoxCreateParentName.Text) && !String.IsNullOrEmpty(TextBoxCreateParentPhonenumber.Text)
                && !String.IsNullOrEmpty(TextBoxCreateAddress.Text))
            {
                var kidName = TextBoxCreateKidName.Text.Trim().Split().ToArray();
                var parentName = TextBoxCreateParentName.Text.Trim().Split().ToArray();
                
                
                kidService.CreateKid(kidName[0], kidName[1], int.Parse(TextBoxCreateKidAge.Text), parentName[0], parentName[1], TextBoxCreateParentPhonenumber.Text, TextBoxCreateAddress.Text);
                //Kid kid = new Kid();
                //Parent parent = new Parent();
                //Group group;

                //var kidName = TextBoxCreateKidName.Text.Trim().Split().ToArray();
                //kid.FirstName = kidName[0].ToString();
                //kid.LastName = kidName[1].ToString();
                //kid.Age = int.Parse(TextBoxCreateKidAge.Text);


                //if (kid.Age == 3)
                //{
                //    group = db.Groups.FirstOrDefault(x => x.GroupId == 1);
                //    kid.GroupId = group.GroupId;
                //    kid.Group = group;
                //}
                //else if (kid.Age == 4)
                //{
                //    group = db.Groups.FirstOrDefault(x => x.GroupId == 2);
                //    kid.GroupId = group.GroupId;
                //    kid.Group = group;
                //}
                //else if (kid.Age == 5)
                //{
                //    group = db.Groups.FirstOrDefault(x => x.GroupId == 3);
                //    kid.GroupId = group.GroupId;
                //    kid.Group = group;
                //}
                //else if (kid.Age == 6)
                //{
                //    group = db.Groups.FirstOrDefault(x => x.GroupId == 4);
                //    kid.GroupId = group.GroupId;
                //    kid.Group = group;
                //}

                //if (db.Parents.FirstOrDefault(x => x.PhoneNumber == parent.PhoneNumber) == null)
                //{
                //    string[] parentName = TextBoxCreateParentName.Text.Trim().Split().ToArray();
                //    parent.FirstName = parentName[0].ToString();
                //    parent.LastName = parentName[1].ToString();
                //    parent.PhoneNumber = TextBoxCreateParentPhonenumber.Text;
                //    parent.Address = TextBoxCreateAddress.Text;
                //    db.Parents.Add(parent);
                //}
                //else
                //{
                //    parent = db.Parents.FirstOrDefault(x => x.PhoneNumber == parent.PhoneNumber);

                //}

                //kid.ParentId = parent.ParentId;
                //db.Kids.Add(kid); 
                TextBoxCreateKidName.Text = null;
                TextBoxCreateKidAge.Text = null;
                TextBoxCreateParentName.Text = null;
                TextBoxCreateParentPhonenumber.Text = null;
                TextBoxCreateAddress.Text = null;
                LabelWarning.BackColor = Color.Green;
                LabelWarning.Text = "Kid has been successfully created!";
                LabelWarning.Visible = true;

            }
            else
            {
                LabelWarning.BackColor = Color.Red;
                LabelWarning.Text = "No boxes can be left empty!!!";
                LabelWarning.Visible = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
