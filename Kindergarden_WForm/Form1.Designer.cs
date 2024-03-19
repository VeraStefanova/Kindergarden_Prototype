namespace Kindergarden_WForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Kid_name = new DataGridViewTextBoxColumn();
            Age = new DataGridViewTextBoxColumn();
            Parent_name = new DataGridViewTextBoxColumn();
            Phone_number = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Group = new DataGridViewTextBoxColumn();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.BackColor = SystemColors.GradientInactiveCaption;
            splitContainer1.Panel1.Controls.Add(button10);
            splitContainer1.Panel1.Controls.Add(button9);
            splitContainer1.Panel1.Controls.Add(button8);
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 9F);
            splitContainer1.Size = new Size(1367, 614);
            splitContainer1.SplitterDistance = 455;
            splitContainer1.TabIndex = 0;
            // 
            // button10
            // 
            button10.Location = new Point(14, 451);
            button10.Name = "button10";
            button10.Size = new Size(192, 29);
            button10.TabIndex = 3;
            button10.Text = "Exit";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(14, 406);
            button9.Name = "button9";
            button9.Size = new Size(192, 29);
            button9.TabIndex = 3;
            button9.Text = "Delete kid";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button8_Click;
            // 
            // button8
            // 
            button8.Location = new Point(14, 359);
            button8.Name = "button8";
            button8.Size = new Size(192, 29);
            button8.TabIndex = 3;
            button8.Text = "Update parent";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(14, 311);
            button7.Name = "button7";
            button7.Size = new Size(192, 29);
            button7.TabIndex = 3;
            button7.Text = "Update kid";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(14, 264);
            button6.Name = "button6";
            button6.Size = new Size(192, 29);
            button6.TabIndex = 3;
            button6.Text = "Create kid";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(14, 215);
            button5.Name = "button5";
            button5.Size = new Size(192, 29);
            button5.TabIndex = 3;
            button5.Text = "Search kid and parent";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(14, 169);
            button4.Name = "button4";
            button4.Size = new Size(192, 29);
            button4.TabIndex = 3;
            button4.Text = "List all parents";
            button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(14, 125);
            button2.Name = "button2";
            button2.Size = new Size(192, 29);
            button2.TabIndex = 2;
            button2.Text = "List all groups";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 23);
            label1.Name = "label1";
            label1.Size = new Size(99, 41);
            label1.TabIndex = 1;
            label1.Text = "Menu";
            // 
            // button1
            // 
            button1.Location = new Point(14, 80);
            button1.Name = "button1";
            button1.Size = new Size(192, 29);
            button1.TabIndex = 0;
            button1.Text = "List all kids";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Kid_name, Age, Parent_name, Phone_number, Address, Group });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(58, 169);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(802, 195);
            dataGridView1.TabIndex = 1;
            dataGridView1.Visible = false;
            // 
            // Kid_name
            // 
            Kid_name.HeaderText = "Kid_name";
            Kid_name.MinimumWidth = 6;
            Kid_name.Name = "Kid_name";
            Kid_name.Width = 125;
            // 
            // Age
            // 
            Age.HeaderText = "Age";
            Age.MinimumWidth = 6;
            Age.Name = "Age";
            Age.Width = 125;
            // 
            // Parent_name
            // 
            Parent_name.HeaderText = "Parent_name";
            Parent_name.MinimumWidth = 6;
            Parent_name.Name = "Parent_name";
            Parent_name.Width = 125;
            // 
            // Phone_number
            // 
            Phone_number.HeaderText = "Phone_number";
            Phone_number.MinimumWidth = 6;
            Phone_number.Name = "Phone_number";
            Phone_number.Width = 125;
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.Width = 125;
            // 
            // Group
            // 
            Group.HeaderText = "Group";
            Group.MinimumWidth = 6;
            Group.Name = "Group";
            Group.Width = 125;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(56, 51);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 614);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button10;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Kid_name;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn Parent_name;
        private DataGridViewTextBoxColumn Phone_number;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Group;
    }
}
