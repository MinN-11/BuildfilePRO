namespace BuildfilePRO
{
    partial class SkillLearnListEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.currentSelection = new System.Windows.Forms.TextBox();
            this.skillListBox = new System.Windows.Forms.ListBox();
            this.selectedSkill = new System.Windows.Forms.ComboBox();
            this.selectedSkillImage = new System.Windows.Forms.PictureBox();
            this.selectedSkillLevel = new System.Windows.Forms.NumericUpDown();
            this.skillWrite = new System.Windows.Forms.Button();
            this.skillAdd = new System.Windows.Forms.Button();
            this.skillRemove = new System.Windows.Forms.Button();
            this.changeClassSkillList = new System.Windows.Forms.Button();
            this.currentSkillList = new System.Windows.Forms.ComboBox();
            this.addNewClassSkillList = new System.Windows.Forms.Button();
            this.classLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSkillImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSkillLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Skill List";
            // 
            // currentSelection
            // 
            this.currentSelection.Location = new System.Drawing.Point(63, 12);
            this.currentSelection.Name = "currentSelection";
            this.currentSelection.ReadOnly = true;
            this.currentSelection.Size = new System.Drawing.Size(211, 20);
            this.currentSelection.TabIndex = 2;
            // 
            // skillListBox
            // 
            this.skillListBox.FormattingEnabled = true;
            this.skillListBox.Location = new System.Drawing.Point(280, 70);
            this.skillListBox.Name = "skillListBox";
            this.skillListBox.Size = new System.Drawing.Size(120, 95);
            this.skillListBox.TabIndex = 3;
            this.skillListBox.SelectedIndexChanged += new System.EventHandler(this.skillListBox_SelectedIndexChanged);
            // 
            // selectedSkill
            // 
            this.selectedSkill.FormattingEnabled = true;
            this.selectedSkill.Location = new System.Drawing.Point(117, 116);
            this.selectedSkill.Name = "selectedSkill";
            this.selectedSkill.Size = new System.Drawing.Size(119, 21);
            this.selectedSkill.TabIndex = 119;
            this.selectedSkill.SelectedIndexChanged += new System.EventHandler(this.selectedSkill_SelectedIndexChanged);
            // 
            // selectedSkillImage
            // 
            this.selectedSkillImage.Location = new System.Drawing.Point(242, 104);
            this.selectedSkillImage.Name = "selectedSkillImage";
            this.selectedSkillImage.Size = new System.Drawing.Size(32, 32);
            this.selectedSkillImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedSkillImage.TabIndex = 118;
            this.selectedSkillImage.TabStop = false;
            // 
            // selectedSkillLevel
            // 
            this.selectedSkillLevel.Location = new System.Drawing.Point(62, 116);
            this.selectedSkillLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.selectedSkillLevel.Name = "selectedSkillLevel";
            this.selectedSkillLevel.Size = new System.Drawing.Size(49, 20);
            this.selectedSkillLevel.TabIndex = 120;
            // 
            // skillWrite
            // 
            this.skillWrite.Location = new System.Drawing.Point(19, 142);
            this.skillWrite.Name = "skillWrite";
            this.skillWrite.Size = new System.Drawing.Size(81, 23);
            this.skillWrite.TabIndex = 122;
            this.skillWrite.Text = "Write";
            this.skillWrite.UseVisualStyleBackColor = true;
            this.skillWrite.Click += new System.EventHandler(this.skillWrite_Click);
            // 
            // skillAdd
            // 
            this.skillAdd.Location = new System.Drawing.Point(106, 142);
            this.skillAdd.Name = "skillAdd";
            this.skillAdd.Size = new System.Drawing.Size(81, 23);
            this.skillAdd.TabIndex = 123;
            this.skillAdd.Text = "Add";
            this.skillAdd.UseVisualStyleBackColor = true;
            this.skillAdd.Click += new System.EventHandler(this.skillAdd_Click);
            // 
            // skillRemove
            // 
            this.skillRemove.Location = new System.Drawing.Point(193, 142);
            this.skillRemove.Name = "skillRemove";
            this.skillRemove.Size = new System.Drawing.Size(81, 23);
            this.skillRemove.TabIndex = 124;
            this.skillRemove.Text = "Remove";
            this.skillRemove.UseVisualStyleBackColor = true;
            this.skillRemove.Click += new System.EventHandler(this.skillRemove_Click);
            // 
            // changeClassSkillList
            // 
            this.changeClassSkillList.Location = new System.Drawing.Point(280, 10);
            this.changeClassSkillList.Name = "changeClassSkillList";
            this.changeClassSkillList.Size = new System.Drawing.Size(81, 23);
            this.changeClassSkillList.TabIndex = 125;
            this.changeClassSkillList.Text = "Change";
            this.changeClassSkillList.UseVisualStyleBackColor = true;
            this.changeClassSkillList.Click += new System.EventHandler(this.changeClassSkillList_Click);
            // 
            // currentSkillList
            // 
            this.currentSkillList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentSkillList.FormattingEnabled = true;
            this.currentSkillList.Location = new System.Drawing.Point(63, 39);
            this.currentSkillList.Name = "currentSkillList";
            this.currentSkillList.Size = new System.Drawing.Size(211, 21);
            this.currentSkillList.TabIndex = 126;
            // 
            // addNewClassSkillList
            // 
            this.addNewClassSkillList.Location = new System.Drawing.Point(280, 37);
            this.addNewClassSkillList.Name = "addNewClassSkillList";
            this.addNewClassSkillList.Size = new System.Drawing.Size(81, 23);
            this.addNewClassSkillList.TabIndex = 127;
            this.addNewClassSkillList.Text = "Add New";
            this.addNewClassSkillList.UseVisualStyleBackColor = true;
            this.addNewClassSkillList.Click += new System.EventHandler(this.addNewClassSkillList_Click);
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(4, 15);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(32, 13);
            this.classLabel.TabIndex = 128;
            this.classLabel.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 130;
            this.label4.Text = "Skill";
            // 
            // SkillLearnListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 180);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.addNewClassSkillList);
            this.Controls.Add(this.currentSkillList);
            this.Controls.Add(this.changeClassSkillList);
            this.Controls.Add(this.skillRemove);
            this.Controls.Add(this.skillAdd);
            this.Controls.Add(this.skillWrite);
            this.Controls.Add(this.selectedSkillLevel);
            this.Controls.Add(this.selectedSkill);
            this.Controls.Add(this.selectedSkillImage);
            this.Controls.Add(this.skillListBox);
            this.Controls.Add(this.currentSelection);
            this.Controls.Add(this.label1);
            this.Name = "SkillLearnListEditor";
            this.Text = "SkillLearnListEditor";
            ((System.ComponentModel.ISupportInitialize)(this.selectedSkillImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSkillLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentSelection;
        private System.Windows.Forms.ListBox skillListBox;
        private System.Windows.Forms.ComboBox selectedSkill;
        private System.Windows.Forms.PictureBox selectedSkillImage;
        private System.Windows.Forms.NumericUpDown selectedSkillLevel;
        private System.Windows.Forms.Button skillWrite;
        private System.Windows.Forms.Button skillAdd;
        private System.Windows.Forms.Button skillRemove;
        private System.Windows.Forms.Button changeClassSkillList;
        private System.Windows.Forms.ComboBox currentSkillList;
        private System.Windows.Forms.Button addNewClassSkillList;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}