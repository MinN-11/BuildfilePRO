using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildfilePRO
{
    public partial class SkillLearnListEditor : Form
    {
        public Editor editor;

        public string selectedList;

        public bool isClassList;

        public SkillLearnListEditor(Editor editor, bool isClassList)
        {
            this.editor = editor;
            this.isClassList = isClassList;
            InitializeComponent();
            PopulateSkillComboBox();
            SetUpLearnListView();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.ActiveControl == selectedSkill) && (keyData == Keys.Return))
            {
                selectedSkill.SelectedItem = selectedSkill.Text;
                UpdateSkillImage();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void SetUpLearnListView()
        {
            skillListBox.Items.Clear();
            currentSkillList.Items.Clear();
            PopulateCurrentSkillList();

            if (isClassList != true)
            {
                classLabel.Text = "Character";
            }

            string getCSV;
            string[] skillLearnListData;
            StreamReader skillLearnListCSV;

            if (this.isClassList)
            {
                currentSelection.Text = editor.GetSelectedClass();
                getCSV = editor.GetClassLevelUpSkillCSV();
                skillLearnListCSV = new StreamReader(getCSV);
                skillLearnListData = editor.ReadSpecificLine(editor.GetSelectedClassIndex() + 2, skillLearnListCSV).Split(',');
            }
            else
            {
                currentSelection.Text = editor.GetSelectedCharacter();
                getCSV = editor.GetCharacterLevelUpSkillCSV();
                skillLearnListCSV = new StreamReader(getCSV);
                skillLearnListData = editor.ReadSpecificLine(editor.GetSelectedCharacterIndex() + 2, skillLearnListCSV).Split(',');
            }

            if (skillLearnListData[1] != "0x0" && skillLearnListData[1] != "0")
            {
                currentSkillList.SelectedItem = skillLearnListData[1].Substring(0, skillLearnListData[1].Length - 10);
                selectedList = currentSkillList.Text;
                PopulateSkillListBox();              
            }
            else
            {
                currentSkillList.SelectedItem = "None";
                selectedList = currentSkillList.Text;
            }

            skillLearnListCSV.Close();

        }

        public void PopulateSkillListBox()
        {
            LinkedList<(int, string)> skills = editor.GetSkillList(selectedList);

            foreach ((int, string) skillEntry in skills)
            {
                skillListBox.Items.Add(skillEntry.Item1.ToString() + " " + skillEntry.Item2);
            }
        }

        public void PopulateSkillComboBox()
        {
            LinkedList<string> skillList = editor.GetAllSkills();
            foreach (string skill in skillList)
            {
                selectedSkill.Items.Add(skill);
            }
        }

        public void UpdateSkillImage()
        {
            string skillIcon = "";

            if (selectedSkill.SelectedItem != null)
            {
                skillIcon = editor.filePath + "\\Engine Hacks\\SkillSystem\\SkillIcons\\" + selectedSkill.SelectedItem + ".png";
            }

            if (selectedSkill.SelectedItem != null && File.Exists(skillIcon))
            {
                selectedSkillImage.Visible = true;
                Image img;
                using (var bmpTemp = new Bitmap(skillIcon))
                {
                    img = new Bitmap(bmpTemp);
                }
                selectedSkillImage.Image = img;
            }
            else
            {
                selectedSkillImage.Visible = false;
            }
        }

        private void selectedSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSkillImage();
        }

        private void skillListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] currentSkill = skillListBox.SelectedItem.ToString().Split(' ');

            selectedSkill.SelectedItem = currentSkill[1];
            selectedSkillLevel.Value = Int16.Parse(currentSkill[0]);
            UpdateSkillImage();
        }

        private void skillWrite_Click(object sender, EventArgs e)
        {
            if (skillListBox.SelectedItem != null && selectedList != "None")
            {
                int skillIndex = skillListBox.SelectedIndex;
                editor.EditSkillListEntry(selectedList, skillIndex, selectedSkillLevel.Value, selectedSkill.Text);
                SetUpLearnListView();
                skillListBox.SelectedIndex = skillIndex;
            }
        }

        private void skillAdd_Click(object sender, EventArgs e)
        {
            if (selectedSkill.Text != "" && selectedSkillLevel.Value != 0 && selectedList != "None")
            {
                editor.AddSkillListEntry(selectedList, selectedSkillLevel.Value, selectedSkill.Text);
                SetUpLearnListView();
                skillListBox.SelectedIndex = skillListBox.Items.Count-1;
                UpdateSkillImage();
            }
        }

        private void skillRemove_Click(object sender, EventArgs e)
        {
            if (skillListBox.SelectedItem != null && selectedList != "None")
            {
                int skillIndex = skillListBox.SelectedIndex;
                editor.RemoveSkillListEntry(selectedList, skillIndex, selectedSkillLevel.Value, selectedSkill.Text);
                SetUpLearnListView();

                skillListBox.SelectedItem = null;
                selectedSkillLevel.Value = 0;
                selectedSkill.SelectedItem = null;
                UpdateSkillImage();
            }
        }

        private void PopulateCurrentSkillList()
        {
            currentSkillList.Items.Add("None");
            LinkedList<string> skillListList = editor.GetAllSkillLists();

            foreach (string skillList in skillListList)
            {
                currentSkillList.Items.Add(skillList);
            }
        }

        private void changeClassSkillList_Click(object sender, EventArgs e)
        {
            if (this.isClassList)
            {
                if (currentSkillList.Text != "None")
                {
                    editor.ChangeClassSkillList(editor.GetSelectedClassIndex() + 1, currentSelection.Text, currentSkillList.Text + "|IsPointer");
                }
                else
                {
                    editor.ChangeClassSkillList(editor.GetSelectedClassIndex() + 1, currentSelection.Text, "0x0");

                }
            }
            else
            {
                if (currentSkillList.Text != "None")
                {
                    editor.ChangeCharacterSkillList(editor.GetSelectedCharacterIndex() + 1, currentSelection.Text, currentSkillList.Text + "|IsPointer");
                }
                else
                {
                    editor.ChangeCharacterSkillList(editor.GetSelectedCharacterIndex() + 1, currentSelection.Text, "0x0");
                }
            }
            selectedList = currentSkillList.Text;
            SetUpLearnListView();
        }

        private void addNewClassSkillList_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("", "Enter New Skill List Name");

            if (input == null || input == "")
            {
                MessageBox.Show("Invalid Input",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            foreach (string skillList in editor.GetAllSkillLists())
            {
                if (skillList == input || skillList == input + "SkillList")
                {
                    MessageBox.Show("Skill List already exists",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (input.Contains("SkillList") != true){
                input = input + "SkillList";
            }

            editor.AddSkillList(input);

            if (isClassList)
            {
                editor.ChangeClassSkillList(editor.GetSelectedClassIndex() + 1, currentSelection.Text, input);
            }
            else
            {
                editor.ChangeCharacterSkillList(editor.GetSelectedCharacterIndex() + 1, currentSelection.Text, input);
            }


            selectedList = input;
            SetUpLearnListView();
        }

    }
}
