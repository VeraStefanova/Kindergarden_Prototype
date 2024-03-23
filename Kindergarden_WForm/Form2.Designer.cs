namespace Kindergarden_WForm
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBoxCreateKidName = new TextBox();
            LabelCreateKidFullName = new Label();
            LabelCreateParentFullName = new Label();
            LabelCreateKidAge = new Label();
            LabelCreatePhoneNumber = new Label();
            LabelCreateAddress = new Label();
            TextBoxCreateKidAge = new TextBox();
            TextBoxCreateParentName = new TextBox();
            TextBoxCreateParentPhonenumber = new TextBox();
            TextBoxCreateAddress = new TextBox();
            ButtonSaveExit = new Button();
            LabelWarning = new Label();
            SuspendLayout();
            // 
            // TextBoxCreateKidName
            // 
            TextBoxCreateKidName.Location = new Point(217, 87);
            TextBoxCreateKidName.Name = "TextBoxCreateKidName";
            TextBoxCreateKidName.Size = new Size(125, 27);
            TextBoxCreateKidName.TabIndex = 0;
            TextBoxCreateKidName.TextChanged += textBox1_TextChanged;
            // 
            // LabelCreateKidFullName
            // 
            LabelCreateKidFullName.AutoSize = true;
            LabelCreateKidFullName.Location = new Point(102, 90);
            LabelCreateKidFullName.Name = "LabelCreateKidFullName";
            LabelCreateKidFullName.Size = new Size(109, 20);
            LabelCreateKidFullName.TabIndex = 1;
            LabelCreateKidFullName.Text = "Kid's full name:";
            // 
            // LabelCreateParentFullName
            // 
            LabelCreateParentFullName.AutoSize = true;
            LabelCreateParentFullName.Location = new Point(102, 170);
            LabelCreateParentFullName.Name = "LabelCreateParentFullName";
            LabelCreateParentFullName.Size = new Size(119, 20);
            LabelCreateParentFullName.TabIndex = 2;
            LabelCreateParentFullName.Text = "Parent full name:";
            LabelCreateParentFullName.Click += label2_Click;
            // 
            // LabelCreateKidAge
            // 
            LabelCreateKidAge.AutoSize = true;
            LabelCreateKidAge.Location = new Point(102, 131);
            LabelCreateKidAge.Name = "LabelCreateKidAge";
            LabelCreateKidAge.Size = new Size(72, 20);
            LabelCreateKidAge.TabIndex = 3;
            LabelCreateKidAge.Text = "Kid's age:";
            LabelCreateKidAge.Click += CreateKidage_Click;
            // 
            // LabelCreatePhoneNumber
            // 
            LabelCreatePhoneNumber.AutoSize = true;
            LabelCreatePhoneNumber.Location = new Point(102, 213);
            LabelCreatePhoneNumber.Name = "LabelCreatePhoneNumber";
            LabelCreatePhoneNumber.Size = new Size(159, 20);
            LabelCreatePhoneNumber.TabIndex = 4;
            LabelCreatePhoneNumber.Text = "Parent's phonenumber:";
            // 
            // LabelCreateAddress
            // 
            LabelCreateAddress.AutoSize = true;
            LabelCreateAddress.Location = new Point(102, 257);
            LabelCreateAddress.Name = "LabelCreateAddress";
            LabelCreateAddress.Size = new Size(65, 20);
            LabelCreateAddress.TabIndex = 5;
            LabelCreateAddress.Text = "Address:";
            LabelCreateAddress.Click += label1_Click;
            // 
            // TextBoxCreateKidAge
            // 
            TextBoxCreateKidAge.Location = new Point(180, 128);
            TextBoxCreateKidAge.Name = "TextBoxCreateKidAge";
            TextBoxCreateKidAge.Size = new Size(125, 27);
            TextBoxCreateKidAge.TabIndex = 6;
            // 
            // TextBoxCreateParentName
            // 
            TextBoxCreateParentName.Location = new Point(227, 167);
            TextBoxCreateParentName.Name = "TextBoxCreateParentName";
            TextBoxCreateParentName.Size = new Size(125, 27);
            TextBoxCreateParentName.TabIndex = 7;
            // 
            // TextBoxCreateParentPhonenumber
            // 
            TextBoxCreateParentPhonenumber.Location = new Point(267, 210);
            TextBoxCreateParentPhonenumber.Name = "TextBoxCreateParentPhonenumber";
            TextBoxCreateParentPhonenumber.Size = new Size(125, 27);
            TextBoxCreateParentPhonenumber.TabIndex = 8;
            // 
            // TextBoxCreateAddress
            // 
            TextBoxCreateAddress.Location = new Point(173, 254);
            TextBoxCreateAddress.Name = "TextBoxCreateAddress";
            TextBoxCreateAddress.Size = new Size(125, 27);
            TextBoxCreateAddress.TabIndex = 9;
            // 
            // ButtonSaveExit
            // 
            ButtonSaveExit.Location = new Point(234, 325);
            ButtonSaveExit.Name = "ButtonSaveExit";
            ButtonSaveExit.Size = new Size(118, 29);
            ButtonSaveExit.TabIndex = 10;
            ButtonSaveExit.Text = "Save and exit";
            ButtonSaveExit.UseVisualStyleBackColor = true;
            ButtonSaveExit.Click += ButtonSaveExit_Click;
            // 
            // LabelWarning
            // 
            LabelWarning.AutoSize = true;
            LabelWarning.Location = new Point(196, 46);
            LabelWarning.Name = "LabelWarning";
            LabelWarning.Size = new Size(196, 20);
            LabelWarning.TabIndex = 11;
            LabelWarning.Text = "No boxes can be left empty!";
            LabelWarning.Click += label1_Click_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 412);
            Controls.Add(LabelWarning);
            Controls.Add(ButtonSaveExit);
            Controls.Add(TextBoxCreateAddress);
            Controls.Add(TextBoxCreateParentPhonenumber);
            Controls.Add(TextBoxCreateParentName);
            Controls.Add(TextBoxCreateKidAge);
            Controls.Add(LabelCreateAddress);
            Controls.Add(LabelCreatePhoneNumber);
            Controls.Add(LabelCreateKidAge);
            Controls.Add(LabelCreateParentFullName);
            Controls.Add(LabelCreateKidFullName);
            Controls.Add(TextBoxCreateKidName);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxCreateKidName;
        private Label LabelCreateKidFullName;
        private Label LabelCreateParentFullName;
        private Label LabelCreateKidAge;
        private Label LabelCreatePhoneNumber;
        private Label LabelCreateAddress;
        private TextBox TextBoxCreateKidAge;
        private TextBox TextBoxCreateParentName;
        private TextBox TextBoxCreateParentPhonenumber;
        private TextBox TextBoxCreateAddress;
        private Button ButtonSaveExit;
        private Label LabelWarning;
    }
}