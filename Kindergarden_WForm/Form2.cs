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
    /// <summary>
    /// Represents a form for creating new kids and their associated parents in the kindergarten database.
    /// </summary>    
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
