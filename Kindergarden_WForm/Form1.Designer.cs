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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            dataGridView4 = new DataGridView();
            dataGridView3 = new DataGridView();
            dataGridView2 = new DataGridView();
            button7 = new Button();
            Search2 = new Button();
            Select = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            button11 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
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
            splitContainer1.Panel2.Controls.Add(dataGridView4);
            splitContainer1.Panel2.Controls.Add(dataGridView3);
            splitContainer1.Panel2.Controls.Add(dataGridView2);
            splitContainer1.Panel2.Controls.Add(button7);
            splitContainer1.Panel2.Controls.Add(Search2);
            splitContainer1.Panel2.Controls.Add(Select);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(button11);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 9F);
            splitContainer1.Size = new Size(1496, 614);
            splitContainer1.SplitterDistance = 246;
            splitContainer1.TabIndex = 0;
            // 
            // button10
            // 
            button10.Location = new Point(14, 415);
            button10.Name = "button10";
            button10.Size = new Size(192, 29);
            button10.TabIndex = 3;
            button10.Text = "Exit";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(14, 364);
            button9.Name = "button9";
            button9.Size = new Size(192, 29);
            button9.TabIndex = 3;
            button9.Text = "Delete kid";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button8_Click;
            // 
            // button8
            // 
            button8.Location = new Point(14, 314);
            button8.Name = "button8";
            button8.Size = new Size(192, 29);
            button8.TabIndex = 3;
            button8.Text = "Update information";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button6
            // 
            button6.Location = new Point(14, 264);
            button6.Name = "button6";
            button6.Size = new Size(192, 29);
            button6.TabIndex = 3;
            button6.Text = "Create kid";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(14, 215);
            button5.Name = "button5";
            button5.Size = new Size(192, 29);
            button5.TabIndex = 3;
            button5.Text = "Search kid and parent";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(14, 169);
            button4.Name = "button4";
            button4.Size = new Size(192, 29);
            button4.TabIndex = 3;
            button4.Text = "List all parents";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
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
            // dataGridView4
            // 
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView4.BackgroundColor = SystemColors.Control;
            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView4.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView4.Location = new Point(671, 146);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView4.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView4.RowHeadersVisible = false;
            dataGridView4.RowHeadersWidth = 51;
            dataGridView4.ScrollBars = ScrollBars.None;
            dataGridView4.Size = new Size(195, 188);
            dataGridView4.TabIndex = 12;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.BackgroundColor = SystemColors.Control;
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView3.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView3.Location = new Point(516, 146);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.ScrollBars = ScrollBars.None;
            dataGridView3.Size = new Size(202, 188);
            dataGridView3.TabIndex = 11;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.BackgroundColor = SystemColors.Control;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView2.Location = new Point(375, 146);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.ScrollBars = ScrollBars.None;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView2.Size = new Size(181, 188);
            dataGridView2.TabIndex = 10;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(51, 231);
            button7.Name = "button7";
            button7.Size = new Size(126, 33);
            button7.TabIndex = 9;
            button7.Text = "Save changes";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += button7_Click;
            // 
            // Search2
            // 
            Search2.FlatStyle = FlatStyle.Flat;
            Search2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Search2.ImageAlign = ContentAlignment.TopCenter;
            Search2.Location = new Point(679, 78);
            Search2.Name = "Search2";
            Search2.Size = new Size(114, 46);
            Search2.TabIndex = 8;
            Search2.Text = "Search";
            Search2.TextAlign = ContentAlignment.TopCenter;
            Search2.UseVisualStyleBackColor = true;
            Search2.Visible = false;
            Search2.Click += Search2_Click;
            // 
            // Select
            // 
            Select.FlatStyle = FlatStyle.Flat;
            Select.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Select.ImageAlign = ContentAlignment.TopCenter;
            Select.Location = new Point(71, 188);
            Select.Name = "Select";
            Select.Size = new Size(84, 33);
            Select.TabIndex = 7;
            Select.Text = "Select";
            Select.UseVisualStyleBackColor = true;
            Select.Visible = false;
            Select.Click += Select_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(174, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(41, 27);
            textBox2.TabIndex = 6;
            textBox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(16, 146);
            label3.Name = "label3";
            label3.Size = new Size(152, 28);
            label3.TabIndex = 5;
            label3.Text = "Enter desired Id:";
            label3.Visible = false;
            // 
            // button11
            // 
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ImageAlign = ContentAlignment.TopCenter;
            button11.Location = new Point(679, 78);
            button11.Name = "button11";
            button11.Size = new Size(114, 46);
            button11.TabIndex = 4;
            button11.Text = "Search";
            button11.TextAlign = ContentAlignment.TopCenter;
            button11.UseVisualStyleBackColor = true;
            button11.Visible = false;
            button11.Click += button11_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(473, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 41);
            textBox1.TabIndex = 3;
            textBox1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(225, 80);
            label2.Name = "label2";
            label2.Size = new Size(252, 35);
            label2.TabIndex = 2;
            label2.Text = "Enter kid's first name:";
            label2.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridView1.Location = new Point(225, 146);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(849, 266);
            dataGridView1.TabIndex = 1;
            dataGridView1.Visible = false;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 51;
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
            ClientSize = new Size(1571, 615);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button10;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label2;
        private Button button11;
        private TextBox textBox2;
        private Label label3;
        private Button Select;
        private Button Search2;
        private Button button7;
        private DataGridView dataGridView2;
        private DataGridView dataGridView4;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn Id;
    }
}
