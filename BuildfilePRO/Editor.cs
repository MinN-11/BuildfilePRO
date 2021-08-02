using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuildfilePRO
{
    public partial class Editor : Form
    {
        public string filePath;

        public string classAbilityValue;

        public string characterAbilityValue;

        public string itemAbilityValue;

        public decimal itemSkillValue = 0;

        public bool toggleFlag = false;

        public Editor(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
            ToggleConfigOptions();
            ToggleVisibilites();
            PopulateComboBoxes();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.ActiveControl == classSkillComboBox) && (keyData == Keys.Return))
            {
                classSkillComboBox.SelectedItem = classSkillComboBox.Text;
                UpdateClassSkillImage();
                return true;
            }
            if ((this.ActiveControl == characterSkillComboBox) && (keyData == Keys.Return))
            {
                characterSkillComboBox.SelectedItem = characterSkillComboBox.Text;
                UpdateCharacterSkillImage();
                return true;
            }
            if ((this.ActiveControl == itemSkillComboBox) && (keyData == Keys.Return))
            {
                itemSkillComboBox.SelectedItem = itemSkillComboBox.Text;
                UpdateItemSkillImage();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void ToggleVisibilites()
        {
            ToggleClassVisibilities();
            ToggleCharacterVisibilities();
        }

        public void PopulateComboBoxes()
        {
            PopulateClassSelector();
            PopulateCharacterSelector();
            PopulateItemSelector();
            PopulateChapterSelector();
            PopulateSkillComboBoxes();
            PopulateRankBoxes();
            PopulateMoveTypeBoxes();
            PopulateAbilityCheckBoxLists();
            PopulateItemAbilityCheckBoxLists();
            PopulateAffinityBoxes();
            PopulateItemTypeBoxes();
            PopulateChapterDataBoxes();
            PopulateWalkSoundComboBox();
        }

        public void PopulateWalkSoundComboBox()
        {
            string[] walkSounds = new string[] { "", "Cavalry", "Wyvern", "Pegasus", "Armor", "Fleet", "Dragon", "Zombie", "Skeleton", "Spider", "Dog", "Float", "Gorgon" };

            classWalkSoundBox.Items.AddRange(walkSounds);
        }

        public void PopulateAffinityBoxes()
        {
            string[] affinities = new string[] { "", "Fire", "Thunder", "Wind", "Ice", "Dark", "Light", "Anima" };

            characterAffinityBox.Items.AddRange(affinities);
        }

        public void PopulateChapterDataBoxes()
        {
            string[] weathers = new string[] { "", "Snow", "Blizzard", "Rain", "Fire", "Sandstorm", "Cloudy" };

            chapterWeatherBox.Items.AddRange(weathers);

            string[] backgrounds = new string[] { "", "Snow", "Volcano", "Town 1", "Plains 2", "Fort 1", "Town 2", "Town 3", "Ship", "Desert", "Fort 2", "Valni", "Jehanna", "Darkling", "Renais", "Castle 1", "Castle 2", "Castle 3", "Mountain", "Port", "Swamp" };

            chapterBackgroundBox.Items.AddRange(backgrounds);

            string[] objectives = new string[] { "", "Seize", "Rout", "Defend", "Boss", "Other" };

            chapterObjectiveBox.Items.AddRange(objectives);
        }

        public void ChangeBackgroundBoxItem(decimal value, ComboBox backgroundBox)
        {
            if (value < backgroundBox.Items.Count)
            {
                backgroundBox.SelectedIndex = (int)value;
            }
            else
            {
                backgroundBox.SelectedItem = "";
            }
        }

        public void PopulateItemTypeBoxes()
        {
            string[] itemTypes = new string[] { "", "Sword", "Lance", "Axe", "Bow", "Staff", "Anima", "Light", "Dark", "Item", "Monster", "Ring" };

            itemTypeBox.Items.AddRange(itemTypes);
        }

        public void PopulateRankBoxes()
        {
            string[] weaponRanks = new string[] { "", "E", "D", "C", "B", "A", "S" };

            classSwordRankBox.Items.AddRange(weaponRanks);
            classLanceRankBox.Items.AddRange(weaponRanks);
            classAxeRankBox.Items.AddRange(weaponRanks);
            classBowRankBox.Items.AddRange(weaponRanks);
            classStaffRankBox.Items.AddRange(weaponRanks);
            classAnimaRankBox.Items.AddRange(weaponRanks);
            classLightRankBox.Items.AddRange(weaponRanks);
            classDarkRankBox.Items.AddRange(weaponRanks);
            characterSwordRankBox.Items.AddRange(weaponRanks);
            characterLanceRankBox.Items.AddRange(weaponRanks);
            characterAxeRankBox.Items.AddRange(weaponRanks);
            characterBowRankBox.Items.AddRange(weaponRanks);
            characterStaffRankBox.Items.AddRange(weaponRanks);
            characterAnimaRankBox.Items.AddRange(weaponRanks);
            characterLightRankBox.Items.AddRange(weaponRanks);
            characterDarkRankBox.Items.AddRange(weaponRanks);
            itemRankBox.Items.AddRange(weaponRanks);
        }

        public void PopulateMoveTypeBoxes()
        {
            string[] moveTypes = new string[] { "", "Infantry", "Infantry T2", "Cavalry", "Cavalry T2", "Armor", "Thief", "Flier", "Mage", "Fighter", "Brigand", "Pirate", "Berserker", "Ranger T1", "Ranger", "Civilian", "Demon King" };

            classMoveTypeBox.Items.AddRange(moveTypes);
        }

        public void PopulateAbilityCheckBoxLists()
        {
            string[] classAbilities = new string[] { "Mounted Aid", "Canto", "Steal", "Thief Skill", "Dance", "Play", "Crit +15", "Ballista", "Promoted", "Supply", "Horse Icon", "Dragon Icon", "Pegasus Icon", "Lord", "Female", "Boss", "Weapon Unlock 1", "Weapon Unlock 2", "Monster Unlock", "Trainee", "Cannot Control", "Triangle Attack", "Armor Triangle", "Decrement ID", "Give No EXP", "Lethality", "Magic Seal", "Summoning", "Weapon Unlock 3", "Weapon Unlock 4", "Weapon Unlock 5", "Weapon Unlock 6" };

            classAbilityCheckBoxList.Items.AddRange(classAbilities);
            characterAbilityCheckBoxList.Items.AddRange(classAbilities);
        }

        public void PopulateItemAbilityCheckBoxLists()
        {
            string[] itemAbilities = new string[] { "Weapon", "Magic", "Staff", "Unbreakable", "Unsellable", "Brave", "Magic Sword", "Uncounterable", "Reaver", "Unrepairable", "Monster Lock", "Weapon Lock 1", "Weapon Lock 2", "Hide Info", "Fili Shield", "Hoplon Guard", "Unusable", "Ignore Def", "Weapon Unlock 3", "Weapon Unlock 4", "Weapon Unlock 5", "Weapon Unlock 6", "UnkAbility3", "Passive Boosts" };

            itemAbilityCheckBoxList.Items.AddRange(itemAbilities);
        }

        public void ChangeRankBoxItem(string value, ComboBox rankBox)
        {
            if (value == "SRank")
            {
                rankBox.SelectedItem = "S";
            }
            else if (value == "ARank")
            {
                rankBox.SelectedItem = "A";
            }
            else if (value == "BRank")
            {
                rankBox.SelectedItem = "B";
            }
            else if (value == "CRank")
            {
                rankBox.SelectedItem = "C";
            }
            else if (value == "DRank")
            {
                rankBox.SelectedItem = "D";
            }
            else if (value == "ERank")
            {
                rankBox.SelectedItem = "E";
            }
            else
            {
                rankBox.SelectedItem = "";
            }

        }

        public void ChangeAffinityBoxItem(decimal value, ComboBox affinityBox)
        {
            if (value <= affinityBox.Items.Count)
            {
                affinityBox.SelectedIndex = (int)value;
            }
            else
            {
                affinityBox.SelectedItem = "";
            }
        }

        public void ChangeWalkingSoundBoxItem(decimal value, ComboBox walkingsoundBox)
        {
            if (value <= walkingsoundBox.Items.Count)
            {
                walkingsoundBox.SelectedIndex = (int)value;
            }
            else
            {
                walkingsoundBox.SelectedItem = "";
            }
        }

        public void ChangeWeatherBoxItem(decimal value, ComboBox weatherBox)
        {
            if (value <= weatherBox.Items.Count)
            {
                if (value > 2)
                {
                    weatherBox.SelectedIndex = (int)value - 1;
                }
                else
                {
                    weatherBox.SelectedIndex = (int)value;
                }
            }
            else
            {
                weatherBox.SelectedItem = "";
            }
        }

        public void ChangeObjectiveTypeBoxItem(decimal value, ComboBox objectiveBox)
        {
            if (value <= objectiveBox.Items.Count + 1)
            {
                objectiveBox.SelectedIndex = (int)value + 1;
            }
            else
            {
                objectiveBox.SelectedItem = "";
            }
        }

        public void ChangeItemTypeBoxItem(decimal value, ComboBox typebox)
        {
            if (value <= 7)
            {
                typebox.SelectedIndex = (int)value + 1;
            }
            else if (value == FE8Constants.Item)
            {
                typebox.SelectedItem = "Item";
            }
            else if (value == FE8Constants.Monster)
            {
                typebox.SelectedItem = "Monster";
            }
            else if (value == FE8Constants.Ring)
            {
                typebox.SelectedItem = "Ring";
            }
            else
            {
                typebox.SelectedItem = "";
            }
        }

        public void ChangeItemTypeValue(string value, NumericUpDown itemType)
        {
            if (value == "Sword")
            {
                itemType.Value = FE8Constants.Sword;
            }
            else if (value == "Lance")
            {
                itemType.Value = FE8Constants.Lance;
            }
            else if (value == "Axe")
            {
                itemType.Value = FE8Constants.Axe;
            }
            else if (value == "Bow")
            {
                itemType.Value = FE8Constants.Bow;
            }
            else if (value == "Staff")
            {
                itemType.Value = FE8Constants.Staff;
            }
            else if (value == "Anima")
            {
                itemType.Value = FE8Constants.Anima;
            }
            else if (value == "Light")
            {
                itemType.Value = FE8Constants.Light;
            }
            else if (value == "Dark")
            {
                itemType.Value = FE8Constants.Dark;
            }
            else if (value == "Item")
            {
                itemType.Value = FE8Constants.Item;
            }
            else if (value == "Monster")
            {
                itemType.Value = FE8Constants.Monster;
            }
            else if (value == "Ring")
            {
                itemType.Value = FE8Constants.Ring;
            }
            else
            {
                itemType.Value = 0x0;
            }
        }

        public void ChangeAffinityValue(string value, NumericUpDown affinity)
        {
            if (value == "Fire")
            {
                affinity.Value = FE8Constants.FireAffinity;
            }
            else if (value == "Thunder")
            {
                affinity.Value = FE8Constants.ThunderAffinity;
            }
            else if (value == "Wind")
            {
                affinity.Value = FE8Constants.WindAffinity;
            }
            else if (value == "Ice")
            {
                affinity.Value = FE8Constants.IceAffinity;
            }
            else if (value == "Dark")
            {
                affinity.Value = FE8Constants.DarkAffinity;
            }
            else if (value == "Light")
            {
                affinity.Value = FE8Constants.LightAffinity;
            }
            else if (value == "Anima")
            {
                affinity.Value = FE8Constants.AnimaAffinity;
            }
            else
            {
                affinity.Value = 0x0;
            }
        }

        public void ChangeWeatherValue(string value, NumericUpDown weather)
        {
            if (value == "Snow")
            {
                weather.Value = FE8Constants.Snow;
            }
            else if (value == "Blizzard")
            {
                weather.Value = FE8Constants.Blizzard;
            }
            else if (value == "Rain")
            {
                weather.Value = FE8Constants.Rain;
            }
            else if (value == "Fire")
            {
                weather.Value = FE8Constants.Fire;
            }
            else if (value == "Sandstorm")
            {
                weather.Value = FE8Constants.Sandstorm;
            }
            else if (value == "Cloudy")
            {
                weather.Value = FE8Constants.Cloudy;
            }
            else
            {
                weather.Value = 0x0;
            }
        }

        public void ChangeMoveTypeBoxItem()
        {
            classMoveTypeBox.SelectedItem = "";

            if (
                HexStringToIntString(classAvoBonus.Text) == FE8Constants.TerrainAvo.ToString() &&
                HexStringToIntString(classDefBonus.Text) == FE8Constants.TerrainDef.ToString() &&
                HexStringToIntString(classResBonus.Text) == FE8Constants.TerrainRes.ToString()
                )
            {
                if (
                    HexStringToIntString(classMoveCost.Text) == FE8Constants.InfantryMove.ToString() &&
                    HexStringToIntString(classRainMoveCost.Text) == FE8Constants.InfantryRainMove.ToString() &&
                    HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.InfantrySnowMove.ToString()
                    )
                {
                    classMoveTypeBox.SelectedItem = "Infantry";
                }
                else if (
                    HexStringToIntString(classMoveCost.Text) == FE8Constants.InfantryT2Move.ToString() &&
                    HexStringToIntString(classRainMoveCost.Text) == FE8Constants.InfantryT2RainMove.ToString() &&
                    HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.InfantryT2SnowMove.ToString()
                    )
                {
                    classMoveTypeBox.SelectedItem = "Infantry T2";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.CavalryMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.CavalryRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.CavalrySnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Cavalry";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.CavalryT2Move.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.CavalryT2RainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.CavalryT2SnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Cavalry T2";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.ArmorMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.ArmorRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.ArmorSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Armor";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.ThiefMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.ThiefRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.ThiefSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Thief";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.MageMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.MageRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.MageSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Mage";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.FighterMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.FighterRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.FighterSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Fighter";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.BrigandMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.BrigandRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.BrigandSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Brigand";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.PirateMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.PirateRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.PirateSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Pirate";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.BerserkerMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.BerserkerRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.BerserkerSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Berserker";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.RangerT1Move.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.RangerT1RainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.RangerT1SnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Ranger T1";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.RangerMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.RangerRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.RangerSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Ranger";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.CivilianMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.CivilianRainMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.CivilianSnowMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Civilian";
                }
                else if (
                   HexStringToIntString(classMoveCost.Text) == FE8Constants.DemonKingMove.ToString() &&
                   HexStringToIntString(classRainMoveCost.Text) == FE8Constants.DemonKingMove.ToString() &&
                   HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.DemonKingMove.ToString()
                   )
                {
                    classMoveTypeBox.SelectedItem = "Demon King";
                }
            }
            else if (
                    HexStringToIntString(classAvoBonus.Text) == FE8Constants.NoTerrainAvo.ToString() &&
                    HexStringToIntString(classDefBonus.Text) == FE8Constants.NoTerrainDef.ToString() &&
                    HexStringToIntString(classResBonus.Text) == FE8Constants.NoTerrainRes.ToString()
                    )
            {
                if (
                        HexStringToIntString(classMoveCost.Text) == FE8Constants.FlierMove.ToString() &&
                        HexStringToIntString(classRainMoveCost.Text) == FE8Constants.FlierRainMove.ToString() &&
                        HexStringToIntString(classSnowMoveCost.Text) == FE8Constants.FlierSnowMove.ToString()
                        )
                {
                    classMoveTypeBox.SelectedItem = "Flier";
                }
            }
        }

        public void UpdateCharClassAbilityCheckBoxList(bool isClass)
        {

            CheckedListBox abilityCheckBoxList;
            string abilityValue;

            if (isClass)
            {
                abilityCheckBoxList = classAbilityCheckBoxList;
                abilityValue = classAbilityValue;
            }
            else
            {
                abilityCheckBoxList = characterAbilityCheckBoxList;
                abilityValue = characterAbilityValue;
            }

            abilityCheckBoxList.SelectedItem = null;

            UncheckAll(abilityCheckBoxList);

            if (abilityValue.Contains("MountedAid"))
            {
                abilityCheckBoxList.SetItemChecked(0, true);
            }
            if (abilityValue.Contains("HasCanto"))
            {
                abilityCheckBoxList.SetItemChecked(1, true);
            }
            if (abilityValue.Contains("Steal"))
            {
                abilityCheckBoxList.SetItemChecked(2, true);
            }
            if (abilityValue.Contains("CanUseLockpick"))
            {
                abilityCheckBoxList.SetItemChecked(3, true);
            }
            if (abilityValue.Contains("CanDance"))
            {
                abilityCheckBoxList.SetItemChecked(4, true);
            }
            if (abilityValue.Contains("CanPlay"))
            {
                abilityCheckBoxList.SetItemChecked(5, true);
            }
            if (abilityValue.Contains("CritBoost"))
            {
                abilityCheckBoxList.SetItemChecked(6, true);
            }
            if (abilityValue.Contains("UseBallista"))
            {
                abilityCheckBoxList.SetItemChecked(7, true);
            }
            if (abilityValue.Contains("IsPromoted"))
            {
                abilityCheckBoxList.SetItemChecked(8, true);
            }
            if (abilityValue.Contains("IsSupply"))
            {
                abilityCheckBoxList.SetItemChecked(9, true);
            }
            if (abilityValue.Contains("HorseIcon"))
            {
                abilityCheckBoxList.SetItemChecked(10, true);
            }
            if (abilityValue.Contains("DragonIcon"))
            {
                abilityCheckBoxList.SetItemChecked(11, true);
            }
            if (abilityValue.Contains("PegIcon"))
            {
                abilityCheckBoxList.SetItemChecked(12, true);
            }
            if (abilityValue.Contains("IsLord"))
            {
                abilityCheckBoxList.SetItemChecked(13, true);
            }
            if (abilityValue.Contains("IsFemale"))
            {
                abilityCheckBoxList.SetItemChecked(14, true);
            }
            if (abilityValue.Contains("IsBoss"))
            {
                abilityCheckBoxList.SetItemChecked(15, true);
            }
            if (abilityValue.Contains("UnlockLock1"))
            {
                abilityCheckBoxList.SetItemChecked(16, true);
            }
            if (abilityValue.Contains("SwordmasterUnlock"))
            {
                abilityCheckBoxList.SetItemChecked(17, true);
            }
            if (abilityValue.Contains("UseMonsterWeapons"))
            {
                abilityCheckBoxList.SetItemChecked(18, true);
            }
            if (abilityValue.Contains("TraineeLevelCap"))
            {
                abilityCheckBoxList.SetItemChecked(19, true);
            }
            if (abilityValue.Contains("CannotCritical"))
            {
                abilityCheckBoxList.SetItemChecked(20, true);
            }
            if (abilityValue.Contains("TriangleAttack"))
            {
                abilityCheckBoxList.SetItemChecked(21, true);
            }
            if (abilityValue.Contains("TriangleAttack2"))
            {
                abilityCheckBoxList.SetItemChecked(22, true);
            }
            if (abilityValue.Contains("DecrementIDAfterLoad"))
            {
                abilityCheckBoxList.SetItemChecked(23, true);
            }
            if (abilityValue.Contains("GiveNoExp"))
            {
                abilityCheckBoxList.SetItemChecked(24, true);
            }
            if (abilityValue.Contains("Lethality"))
            {
                abilityCheckBoxList.SetItemChecked(25, true);
            }
            if (abilityValue.Contains("IsMagicSeal"))
            {
                abilityCheckBoxList.SetItemChecked(26, true);
            }
            if (abilityValue.Contains("Summoning"))
            {
                abilityCheckBoxList.SetItemChecked(27, true);
            }
            if (abilityValue.Contains("UnlockEirika"))
            {
                abilityCheckBoxList.SetItemChecked(28, true);
            }
            if (abilityValue.Contains("UnlockEphraim"))
            {
                abilityCheckBoxList.SetItemChecked(29, true);
            }
            if (abilityValue.Contains("UnlockLock3"))
            {
                abilityCheckBoxList.SetItemChecked(30, true);
            }
            if (abilityValue.Contains("UnlockLock4"))
            {
                abilityCheckBoxList.SetItemChecked(31, true);
            }
        }

        public void UpdateItemAbilityCheckBoxList()
        {
            itemAbilityCheckBoxList.SelectedItem = null;

            UncheckAll(itemAbilityCheckBoxList);

            if (itemAbilityValue.Contains("IsWeapon"))
            {
                itemAbilityCheckBoxList.SetItemChecked(0, true);
            }
            if (itemAbilityValue.Contains("IsMagic")) 
            { 
                itemAbilityCheckBoxList.SetItemChecked(1, true);
            }
            if (itemAbilityValue.Contains("IsStaff"))
            {
                itemAbilityCheckBoxList.SetItemChecked(2, true);
            }
            if (itemAbilityValue.Contains("Indestructible"))
            {
                itemAbilityCheckBoxList.SetItemChecked(3, true);
            }
            if (itemAbilityValue.Contains("Unsellable"))
            {
                itemAbilityCheckBoxList.SetItemChecked(4, true);
            }
            if (itemAbilityValue.Contains("IsBrave"))
            {
                itemAbilityCheckBoxList.SetItemChecked(5, true);
            }
            if (itemAbilityValue.Contains("MagicDamage"))
            {
                itemAbilityCheckBoxList.SetItemChecked(6, true);
            }
            if (itemAbilityValue.Contains("Uncounterable"))
            {
                itemAbilityCheckBoxList.SetItemChecked(7, true);
            }
            if (itemAbilityValue.Contains("ReverseTriangle"))
            {
                itemAbilityCheckBoxList.SetItemChecked(8, true);
            }
            if (itemAbilityValue.Contains("CannotRepair"))
            {
                itemAbilityCheckBoxList.SetItemChecked(9, true);
            }
            if (itemAbilityValue.Contains("MonsterWeapon"))
            {
                itemAbilityCheckBoxList.SetItemChecked(10, true);
            }
            if (itemAbilityValue.Contains("WeaponLock1"))
            {
                itemAbilityCheckBoxList.SetItemChecked(11, true);
            }
            if (itemAbilityValue.Contains("SwordmasterLock"))
            {
                itemAbilityCheckBoxList.SetItemChecked(12, true);
            }
            if (itemAbilityValue.Contains("WeaponLock2"))
            {
                itemAbilityCheckBoxList.SetItemChecked(13, true);
            }
            if (itemAbilityValue.Contains("NegateFlyingEffectiveness"))
            {
                itemAbilityCheckBoxList.SetItemChecked(14, true);
            }
            if (itemAbilityValue.Contains("NegateCriticals"))
            {
                itemAbilityCheckBoxList.SetItemChecked(15, true);
            }
            if (itemAbilityValue.Contains("CannotUse"))
            {
                itemAbilityCheckBoxList.SetItemChecked(16, true);
            }
            if (itemAbilityValue.Contains("NegateDef"))
            {
                itemAbilityCheckBoxList.SetItemChecked(17, true);
            }
            if (itemAbilityValue.Contains("EirikaLock"))
            {
                itemAbilityCheckBoxList.SetItemChecked(18, true);
            }
            if (itemAbilityValue.Contains("EphraimLock"))
            {
                itemAbilityCheckBoxList.SetItemChecked(19, true);
            }
            if (itemAbilityValue.Contains("WeaponLock3"))
            {
                itemAbilityCheckBoxList.SetItemChecked(20, true);
            }
            if (itemAbilityValue.Contains("WeaponLock4"))
            {
                itemAbilityCheckBoxList.SetItemChecked(21, true);
            }
            if (itemAbilityValue.Contains("0x400000"))
            {
                itemAbilityCheckBoxList.SetItemChecked(22, true);
            }
            if (itemAbilityValue.Contains("PassiveBoosts"))
            {
                itemAbilityCheckBoxList.SetItemChecked(23, true);
            }
        }

        public void UncheckAll(CheckedListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, false);
            }
        }

        public string HexStringToIntString(string hex)
        {

            string output = "";

            if (hex.Length > 2)
            {
                hex = hex.Substring(2);
            }

            if (Int64.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long dummy))
            {
                output = dummy.ToString();
            }

            return output;
        }

        public int HexStringToInt(string hex)
        {

            int output = 0;

            if (hex.Length > 2)
            {
                hex = hex.Substring(2);
            }

            if (Int32.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int dummy))
            {
                output = dummy;
            }

            return output;
        }

        public void UpdateItemTypeBox()
        {
            ChangeItemTypeBoxItem(itemType.Value, itemTypeBox);
        }

        public void UpdateWalkingSoundBox()
        {
            ChangeWalkingSoundBoxItem(classWalkSound.Value, classWalkSoundBox);
        }

        public void UpdateChapterDataBoxes()
        {
            ChangeWeatherBoxItem(chapterWeather.Value, chapterWeatherBox);
            ChangeObjectiveTypeBoxItem(chapterObjectiveType.Value, chapterObjectiveBox);
            ChangeBackgroundBoxItem(chapterBackground.Value, chapterBackgroundBox);
        }

        public void ToggleClassVisibilities()
        {
            if (configStrMag.Checked)
            {
                classMagLabel.Visible = true;
                classBaseMag.Visible = true;
                classMagCap.Visible = true;
                classMagGrowth.Visible = true;
                classMagPromo.Visible = true;
            }
            else
            {
                classMagLabel.Visible = false;
                classBaseMag.Visible = false;
                classMagCap.Visible = false;
                classMagGrowth.Visible = false;
                classMagPromo.Visible = false;
            }
        }

        public void ToggleCharacterVisibilities()
        {
            if (configStrMag.Checked)
            {
                characterMagLabel.Visible = true;
                characterBaseMag.Visible = true;
                characterMagGrowth.Visible = true;
            }
            else
            {
                characterMagLabel.Visible = false;
                characterBaseMag.Visible = false;
                characterMagGrowth.Visible = false;
            }
        }

        public void classSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClassSelection();
        }

        public void PopulateSkillComboBoxes()
        {
            classSkillComboBox.Items.Add("None");
            characterSkillComboBox.Items.Add("None");
            itemSkillComboBox.Items.Add("None");
            var skillList = GetAllSkills();
            foreach (string skill in skillList)
            {
                classSkillComboBox.Items.Add(skill);
                characterSkillComboBox.Items.Add(skill);
                itemSkillComboBox.Items.Add(skill);
            }
        }

        public void PopulateClassSelector()
        {
            string nextLine;
            StreamReader classCSV = new StreamReader(GetClassCSV());
            classCSV.ReadLine(); // skip first line
            while ((nextLine = classCSV.ReadLine()) != null)
            {
                string[] classEntry = nextLine.Split(',');
                classSelector.Items.Add(classEntry[3] + " " + classEntry[0]);
            }
            classCSV.Close();
        }

        public void PopulateItemSelector()
        {
            string nextLine;
            StreamReader itemCSV = new StreamReader(GetItemCSV());
            itemCSV.ReadLine(); // skip first line
            while ((nextLine = itemCSV.ReadLine()) != null)
            {
                string[] itemEntry = nextLine.Split(',');
                itemSelector.Items.Add(itemEntry[4] + " " + itemEntry[0]);
            }
            itemCSV.Close();
        }

        public void PopulateCharacterSelector()
        {
            string nextLine;
            StreamReader characterCSV = new StreamReader(GetCharacterCSV());
            characterCSV.ReadLine(); // skip first line
            while ((nextLine = characterCSV.ReadLine()) != null)
            {
                string[] characterEntry = nextLine.Split(',');
                characterSelector.Items.Add(characterEntry[3] + " " + characterEntry[0]);
            }
            characterCSV.Close();
        }

        public void PopulateChapterSelector()
        {
            string nextLine;
            StreamReader chapterCSV = new StreamReader(GetChapterCSV());
            chapterCSV.ReadLine(); // skip first line
            while ((nextLine = chapterCSV.ReadLine()) != null)
            {
                string[] chapterEntry = nextLine.Split(',');
                chapterSelector.Items.Add(chapterEntry[0]);
            }
            chapterCSV.Close();
        }

        public void ToggleConfigOptions()
        {
            toggleFlag = true;
            if (IsConfigOptionEnabled("USE_STRMAG_SPLIT"))
            {
                configStrMag.Checked = true;
            }
            toggleFlag = false;
        }

        public string GetClassCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "ClassTable.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetPromotionCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "PromotionBranchEditor.csv", SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                return files[0];
            }
            else
            {
                string newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\PromotionBranchEditor.nmm";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\PromotionBranchEditor.nmm", newFilePath);
                newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\PromotionBranchEditor.csv";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\PromotionBranchEditor.csv", newFilePath);
                return newFilePath;
            }
        }

        public string GetMovingMapSpriteCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "MiscMapSpriteEditor.csv", SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                return files[0];
            }
            else
            {
                string newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\MiscMapSpriteEditor.nmm";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\MiscMapSpriteEditor.nmm", newFilePath);
                newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\MiscMapSpriteEditor.csv";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\MiscMapSpriteEditor.csv", newFilePath);
                return newFilePath;
            }
        }

        public string GetCharacterCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "CharacterTable.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetItemCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "ItemTable.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetSpellAssocCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "SpellAssociationList.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetChapterCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "ChapterData.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetClassMagCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "MagClassEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetCharacterMagCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "MagCharEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetClassSkillCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "ClassSkillEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetCharacterSkillCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "PersonalSkillEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetClassLevelUpSkillCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "ClassLevelUpSkillEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetCharacterLevelUpSkillCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "CharacterLevelUpSkillEditor.csv", SearchOption.AllDirectories);
            return files[0];
        }

        public string GetWalkingSoundCSV()
        {
            string[] files = Directory.GetFiles(filePath + "\\Tables", "WalkingSoundEditor.csv", SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                return files[0];
            }
            else
            {
                string newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\WalkingSoundEditor.nmm";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\WalkingSoundEditor.nmm", newFilePath);
                newFilePath = filePath + "\\Tables\\NightmareModules\\CharactersClasses\\WalkingSoundEditor.csv";
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Tables\\csv\\WalkingSoundEditor.csv", newFilePath);
                return newFilePath;
            }
        }

        public string GetSkillLists()
        {
            return filePath + "\\EngineHacks\\SkillSystem\\skill_lists.event";
        }

        public string GetSkillSysConfig()
        {
            return filePath + "\\EngineHacks\\Config.event";
        }

        public string GetSkillDefinitions()
        {
            string[] files = Directory.GetFiles(filePath + "\\EngineHacks\\SkillSystem", "skill_definitions.event", SearchOption.AllDirectories);
            return files[0];
        }

        public void UpdateCharacterSelection()
        {
            StreamReader characterCSV = new StreamReader(GetCharacterCSV());
            int index = characterSelector.SelectedIndex + 1;
            string[] characterData = ReadSpecificLine(index + 1, characterCSV).Split(',');

            characterIdentifier.Text = characterData[0];
            characterNameText.Text = characterData[1];
            characterDescriptionText.Text = characterData[2];
            characterID.Value = Convert.ToInt32(characterData[3], 16);
            characterClass.Text = characterData[4];
            characterMug.Text = characterData[5];

            characterMinimug.Value = HexStringToInt(characterData[6]);

            if (characterData[7] != "NoAffinity")
            {
                characterAffinityBox.SelectedItem = characterData[7].Replace("Affinity", "");
            }
            else
            {
                characterAffinityBox.SelectedItem = "";
            }

            characterSortOrder.Value = HexStringToInt(characterData[8]);

            characterBaseLevel.Value = ReadCSVNumeric(characterData[9]);
            characterBaseHP.Value = ReadCSVNumeric(characterData[10]);
            characterBaseStr.Value = ReadCSVNumeric(characterData[11]);
            characterBaseSkl.Value = ReadCSVNumeric(characterData[12]);
            characterBaseSpd.Value = ReadCSVNumeric(characterData[13]);
            characterBaseDef.Value = ReadCSVNumeric(characterData[14]);
            characterBaseRes.Value = ReadCSVNumeric(characterData[15]);
            characterBaseLuck.Value = ReadCSVNumeric(characterData[16]);
            characterBaseCon.Value = ReadCSVNumeric(characterData[17]);

            ChangeRankBoxItem(characterData[18], characterSwordRankBox);
            ChangeRankBoxItem(characterData[19], characterLanceRankBox);
            ChangeRankBoxItem(characterData[20], characterAxeRankBox);
            ChangeRankBoxItem(characterData[21], characterBowRankBox);
            ChangeRankBoxItem(characterData[22], characterStaffRankBox);
            ChangeRankBoxItem(characterData[23], characterAnimaRankBox);
            ChangeRankBoxItem(characterData[24], characterLightRankBox);
            ChangeRankBoxItem(characterData[25], characterDarkRankBox);

            characterHPGrowth.Value = ReadCSVNumeric(characterData[26]);
            characterStrGrowth.Value = ReadCSVNumeric(characterData[27]);
            characterSklGrowth.Value = ReadCSVNumeric(characterData[28]);
            characterSpdGrowth.Value = ReadCSVNumeric(characterData[29]);
            characterDefGrowth.Value = ReadCSVNumeric(characterData[30]);
            characterResGrowth.Value = ReadCSVNumeric(characterData[31]);
            characterLuckGrowth.Value = ReadCSVNumeric(characterData[32]);

            // 5 unused bytes

            characterAbilityValue = characterData[38];

            characterSupports.Text = characterData[39];

            // 4 unused bytes

            // character magic csv
            StreamReader characterMagCSV = new StreamReader(GetCharacterMagCSV());
            string[] characterMagData = ReadSpecificLine(index + 1, characterMagCSV).Split(',');

            characterBaseMag.Value = ReadCSVNumeric(characterMagData[1]);
            characterMagGrowth.Value = ReadCSVNumeric(characterMagData[2]);

            characterMagCSV.Close();

            // character skill csv
            StreamReader characterSkillCSV = new StreamReader(GetCharacterSkillCSV());
            string[] characterSkillData = ReadSpecificLine(index+2, characterSkillCSV).Split(',');

            string characterSkill = characterSkillData[1].Replace("\"", String.Empty);
            characterSkill = characterSkill.Substring(0, characterSkill.Length - 2);

            if (characterSkill != "0")
            {
                characterSkillComboBox.SelectedItem = characterSkill;
            }
            else
            {
                characterSkillComboBox.SelectedItem = "None";
            }

            characterSkillCSV.Close();

            UpdateCharacterSkillImage();
            UpdateCharClassAbilityCheckBoxList(false);

            characterCSV.Close();
        }

        public void UpdateChapterSelection()
        {
            StreamReader chapterCSV = new StreamReader(GetChapterCSV());
            int index = chapterSelector.SelectedIndex + 1;
            string[] chapterData = ReadSpecificLine(index + 1, chapterCSV).Split(',');

            chapterIdentifier.Text = chapterData[0];

            chapterFog.Value = HexStringToInt(chapterData[9]);
            chapterID.Value = HexStringToInt(chapterData[11]);

            chapterCameraX.Value = ReadCSVNumeric(chapterData[13]);
            chapterCameraY.Value = ReadCSVNumeric(chapterData[14]);

            chapterWeather.Value = HexStringToInt(chapterData[15]);
            chapterBackground.Value = HexStringToInt(chapterData[16]);
            chapterDifficulty.Value = HexStringToInt(chapterData[17]);

            chapterPlayerBGM.Text = chapterData[18];
            chapterEnemyBGM.Text = chapterData[19];
            chapterNPCBGM.Text = chapterData[20];
            chapterPlayerBattleBGM.Text = chapterData[21];
            chapterEnemyBattleBGM.Text = chapterData[22];
            chapterNPCBattleBGM.Text = chapterData[23];
            chapterPlayerBGM2.Text = chapterData[24];
            chapterEnemyBGM2.Text = chapterData[25];
            chapterPrepBGM.Text = chapterData[26];

            chapterWallHP.Value = ReadCSVNumeric(chapterData[29]);

            chapterName.Text = chapterData[68];

            chapterEvent.Value = HexStringToInt(chapterData[70]);
            chapterWMEvent.Value = HexStringToInt(chapterData[71]);

            chapterVictory.Value = HexStringToInt(chapterData[88]);
            chapterFade.Value = HexStringToInt(chapterData[89]);

            chapterObjective.Text = chapterData[90];
            chapterMapObjective.Text = chapterData[91];
            chapterObjectiveType.Value = HexStringToInt(chapterData[92]);

            chapterTurns.Value = ReadCSVNumeric(chapterData[93]);
            chapterDefendUnit.Text = chapterData[94];

            chapterMarkerX.Value = ReadCSVNumeric(chapterData[95]);
            chapterMarkerY.Value = ReadCSVNumeric(chapterData[96]);

            UpdateChapterDataBoxes();

            chapterCSV.Close();
        }

        public void UpdateClassSelection()
        {
            StreamReader classCSV = new StreamReader(GetClassCSV());
            int index = classSelector.SelectedIndex + 1;
            string[] classData = ReadSpecificLine(index + 1, classCSV).Split(',');

            classIdentifier.Text = classData[0];
            classNameText.Text = classData[1];
            classDescriptionText.Text = classData[2];
            classID.Value = Convert.ToInt32(classData[3], 16);

            classPromotion.Text = classData[4];
            classMapSprite.Text = classData[5];
            classWalkSpeed.Value = HexStringToInt(classData[6]);
            classClassCard.Text = classData[7];

            classSortOrder.Value = Convert.ToInt32(classData[8], 16);

            classBaseHP.Value = ReadCSVNumeric(classData[9]);
            classBaseStr.Value = ReadCSVNumeric(classData[10]);
            classBaseSkl.Value = ReadCSVNumeric(classData[11]);
            classBaseSpd.Value = ReadCSVNumeric(classData[12]);
            classBaseDef.Value = ReadCSVNumeric(classData[13]);
            classBaseRes.Value = ReadCSVNumeric(classData[14]);
            classBaseCon.Value = ReadCSVNumeric(classData[15]);
            classBaseMov.Value = ReadCSVNumeric(classData[16]);

            classHPCap.Value = ReadCSVNumeric(classData[17]);
            classStrCap.Value = ReadCSVNumeric(classData[18]);
            classSklCap.Value = ReadCSVNumeric(classData[19]);
            classSpdCap.Value = ReadCSVNumeric(classData[20]);
            classDefCap.Value = ReadCSVNumeric(classData[21]);
            classResCap.Value = ReadCSVNumeric(classData[22]);
            classConCap.Value = ReadCSVNumeric(classData[23]);

            classRelativePower.Value = ReadCSVNumeric(classData[24]);

            classHPGrowth.Value = ReadCSVNumeric(classData[25]);
            classStrGrowth.Value = ReadCSVNumeric(classData[26]);
            classSklGrowth.Value = ReadCSVNumeric(classData[27]);
            classSpdGrowth.Value = ReadCSVNumeric(classData[28]);
            classDefGrowth.Value = ReadCSVNumeric(classData[29]);
            classResGrowth.Value = ReadCSVNumeric(classData[30]);
            classLuckGrowth.Value = ReadCSVNumeric(classData[31]);

            classHPPromo.Value = ReadCSVNumeric(classData[32]);
            classStrPromo.Value = ReadCSVNumeric(classData[33]);
            classSklPromo.Value = ReadCSVNumeric(classData[34]);
            classSpdPromo.Value = ReadCSVNumeric(classData[35]);
            classDefPromo.Value = ReadCSVNumeric(classData[36]);
            classResPromo.Value = ReadCSVNumeric(classData[37]);

            classAbilityValue = classData[38];

            ChangeRankBoxItem(classData[39], classSwordRankBox);
            ChangeRankBoxItem(classData[40], classLanceRankBox);
            ChangeRankBoxItem(classData[41], classAxeRankBox);
            ChangeRankBoxItem(classData[42], classBowRankBox);
            ChangeRankBoxItem(classData[43], classStaffRankBox);
            ChangeRankBoxItem(classData[44], classAnimaRankBox);
            ChangeRankBoxItem(classData[45], classLightRankBox);
            ChangeRankBoxItem(classData[46], classDarkRankBox);

            classAnimation.Text = classData[47];

            classMoveCost.Text = classData[48];
            classRainMoveCost.Text = classData[49];
            classSnowMoveCost.Text = classData[50];

            classAvoBonus.Text = classData[51];
            classDefBonus.Text = classData[52];
            classResBonus.Text = classData[53];

            classClassType.Text = classData[54];

            // class magic csv
            StreamReader classMagCSV = new StreamReader(GetClassMagCSV());
            string[] classMagData = ReadSpecificLine(index + 1, classMagCSV).Split(',');

            classBaseMag.Value = ReadCSVNumeric(classMagData[1]);
            classMagGrowth.Value = ReadCSVNumeric(classMagData[2]);
            classMagCap.Value = ReadCSVNumeric(classMagData[3]);
            classMagPromo.Value = ReadCSVNumeric(classMagData[4]);

            classMagCSV.Close();

            // class skill csv
            StreamReader classSkillCSV = new StreamReader(GetClassSkillCSV());
            string[] classSkillData = ReadSpecificLine(index + 1, classSkillCSV).Split(',');

            string classSkill = classSkillData[1].Replace("\"", String.Empty);
            classSkill = classSkill.Substring(0, classSkill.Length - 2);

            if (classSkill != "0")
            {
                classSkillComboBox.SelectedItem = classSkill;
            }
            else
            {
                classSkillComboBox.SelectedItem = "None";
            }

            classSkillCSV.Close();

            // moving map sprite csv
            StreamReader classMovingCSV = new StreamReader(GetMovingMapSpriteCSV());
            string[] classMovingData = ReadSpecificLine(index, classMovingCSV).Split(',');

            classMovingSpriteData.Text = classMovingData[1];
            classMovingAP.Text = classMovingData[2];

            classMovingCSV.Close();

            // walking sound csv
            StreamReader classWalkingCSV = new StreamReader(GetWalkingSoundCSV());
            string[] classWalkingData = ReadSpecificLine(index + 1, classWalkingCSV).Split(',');

            classWalkSound.Value = ReadCSVNumeric(classWalkingData[1]);

            classWalkingCSV.Close();

            // promo branch csv
            StreamReader classPromoCSV = new StreamReader(GetPromotionCSV());
            string[] classPromoData = ReadSpecificLine(index, classPromoCSV).Split(',');

            classPromo1.Text = classPromoData[1];
            classPromo2.Text = classPromoData[2];

            classPromoCSV.Close();

            UpdateClassSkillImage();
            UpdateWalkingSoundBox();
            ChangeMoveTypeBoxItem();
            UpdateCharClassAbilityCheckBoxList(true);

            classCSV.Close();
        }

        public void UpdateItemSelection()
        {

            StreamReader itemCSV = new StreamReader(GetItemCSV());
            int index = itemSelector.SelectedIndex + 1;
            string[] itemData = ReadSpecificLine(index + 1, itemCSV).Split(',');

            itemIdentifier.Text = itemData[0];
            itemNameText.Text = itemData[1];
            itemDescriptionText.Text = itemData[2];
            itemUseText.Text = itemData[3];
            itemID.Value = Convert.ToInt32(itemData[4], 16);
            itemType.Value = HexStringToInt(itemData[5]);
            itemAbilityValue = itemData[6];

            itemStatBonus.Text = itemData[7];
            itemEffectiveness.Text = itemData[8];

            itemDurability.Value = ReadCSVNumeric(itemData[9]);
            itemMight.Value = ReadCSVNumeric(itemData[10]);
            itemHit.Value = ReadCSVNumeric(itemData[11]);
            itemWeight.Value = ReadCSVNumeric(itemData[12]);
            itemCrit.Value = ReadCSVNumeric(itemData[13]);
            itemRange.Value = HexStringToInt(itemData[14]);
            itemPrice.Value = ReadCSVNumeric(itemData[15]);
            ChangeRankBoxItem(itemData[16], itemRankBox);

            itemIcon.Text = itemData[17];
            itemUseEffect.Value = HexStringToInt(itemData[18]);
            itemWeaponEffect.Value = HexStringToInt(itemData[19]);
            itemWEXP.Value = ReadCSVNumeric(itemData[20]);
            itemDebuff.Value = HexStringToInt(itemData[21]);
            itemIERExtra.Value = HexStringToInt(itemData[22]);
            itemSkillValue = HexStringToInt(itemData[23]);

            string itemSkill = GetSkillByID(itemSkillValue);
            if (itemSkill != "0")
            {
                itemSkillComboBox.SelectedItem = itemSkill;
            }
            else
            {
                itemSkillComboBox.SelectedItem = "None";
            }

            // spell association csv
            StreamReader itemAssocCSV = new StreamReader(GetSpellAssocCSV());
            string[] itemAssocData = ReadSpecificLine(index, itemAssocCSV).Split(',');

            itemIsMapAnim.Value = HexStringToInt(itemAssocData[2]);
            itemMagicAnim.Value = HexStringToInt(itemAssocData[3]);
            itemMagicAnimEnabled.Value = HexStringToInt(itemAssocData[4]);
            itemMapAnim.Text = itemAssocData[6];
            itemHPChange.Value = HexStringToInt(itemAssocData[7]);
            itemDirection.Value = HexStringToInt(itemAssocData[8]);
            itemColor.Value = HexStringToInt(itemAssocData[9]);

            itemAssocCSV.Close();

            UpdateItemTypeBox();
            UpdateItemAbilityCheckBoxList();
            UpdateItemSkillImage();

            itemCSV.Close();

        }

        public string GetSkillByID(decimal skillID)
        {

            StreamReader skillDefs = new StreamReader(GetSkillDefinitions());

            string nextLine;

            while ((nextLine = skillDefs.ReadLine()) != null)
            {
                string[] checkLine = nextLine.Split(' ');
                if (checkLine[0].Equals("#define") && (checkLine[2].Equals(skillID.ToString())))
                {
                    return checkLine[1].Substring(0, checkLine[1].Length - 2);
                }
            }

            skillDefs.Close();
            return "0";
        }

        public int GetSkillIDByName(string name)
        {
            if (name == "None")
            {
                return 0;
            }

            StreamReader skillDefs = new StreamReader(GetSkillDefinitions());

            string nextLine;

            while ((nextLine = skillDefs.ReadLine()) != null)
            {
                string[] checkLine = nextLine.Split(' ');
                if (checkLine[0].Equals("#define") && (checkLine[1].Equals(name)))
                {
                    return Int16.Parse(checkLine[2]);
                }
            }

            skillDefs.Close();
            return 0;
        }

        public void UpdateClassSkillImage()
        {
            string skillIcon = "";

            if (classSkillComboBox.SelectedItem != null)
            {
                skillIcon = filePath + "\\EngineHacks\\SkillSystem\\SkillIcons\\" + classSkillComboBox.SelectedItem + ".png";
            }

            if ((classSkillComboBox.SelectedItem != null || classSkillComboBox.SelectedItem.ToString() != "None") && File.Exists(skillIcon))
            {
                classSkillImage.Visible = true;
                Image img;
                using (var bmpTemp = new Bitmap(skillIcon))
                {
                    img = new Bitmap(bmpTemp);
                }
                classSkillImage.Image = img;
            }
            else
            {
                classSkillImage.Visible = false;
            }
        }

        public void UpdateItemSkillImage()
        {
            string skillIcon = "";

            if (itemSkillComboBox.SelectedItem != null)
            {
                skillIcon = filePath + "\\EngineHacks\\SkillSystem\\SkillIcons\\" + itemSkillComboBox.SelectedItem + ".png";
            }

            if ((itemSkillComboBox.SelectedItem != null || itemSkillComboBox.SelectedItem.ToString() != "None") && File.Exists(skillIcon))
            {
                itemSkillImage.Visible = true;
                Image img;
                using (var bmpTemp = new Bitmap(skillIcon))
                {
                    img = new Bitmap(bmpTemp);
                }
                itemSkillImage.Image = img;
            }
            else
            {
                itemSkillImage.Visible = false;
            }
        }

        public void UpdateCharacterSkillImage()
        {
            string skillIcon = "";

            if (characterSkillComboBox.SelectedItem != null)
            {
                skillIcon = filePath + "\\EngineHacks\\SkillSystem\\SkillIcons\\" + characterSkillComboBox.SelectedItem + ".png";
            }

            if ((characterSkillComboBox.SelectedItem != null || characterSkillComboBox.SelectedItem.ToString() != "None") && File.Exists(skillIcon))
            {
                characterSkillImage.Visible = true;
                Image img;
                using (var bmpTemp = new Bitmap(skillIcon))
                {
                    img = new Bitmap(bmpTemp);
                }
                characterSkillImage.Image = img;
            }
            else
            {
                characterSkillImage.Visible = false;
            }
        }

        public string ReadSpecificLine(int line, StreamReader stream)
        {
            string output = "";
            for (int i = 0; i < line; i++)
            {
                output = stream.ReadLine();
            }
            return output;
        }

        public bool IsConfigOptionEnabled(string configOption)
        {
            {
                string nextLine;
                StreamReader file = new StreamReader(GetSkillSysConfig());
                while ((nextLine = file.ReadLine()) != null)
                {
                    string[] checkLine = nextLine.Split(' ');
                    if (checkLine[0].Equals("#define") && checkLine[1].Equals(configOption))
                    {
                        file.Close();
                        return true;
                    }
                    else if (checkLine[0].Equals("//#define") && checkLine[1].Equals(configOption) || checkLine[0].Equals("//") && checkLine[1].Equals("#define") && checkLine[2].Equals(configOption))
                    {
                        file.Close();
                        return false;
                    }
                }
                file.Close();
                return false;
            }
        }

        public void ToggleConfigOption(string configOption)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(GetSkillSysConfig());
            string nextLine;

            while ((nextLine = file.ReadLine()) != null)
            {
                string[] checkLine = nextLine.Split(' ');
                if (checkLine[0].Equals("#define") && checkLine[1].Equals(configOption))
                {
                    builder.Append("//#define " + configOption);
                    builder.Append("\r\n");
                }
                else if (checkLine[0].Equals("//#define") && checkLine[1].Equals(configOption) || checkLine[0].Equals("//") && checkLine[1].Equals("#define") && checkLine[2].Equals(configOption))
                {
                    builder.Append("#define " + configOption);
                    builder.Append("\r\n");
                }
                else
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
            }

            file.Close();
            StreamWriter writer = new StreamWriter(GetSkillSysConfig());
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        public void WriteToCSV(string[] data, int line, string fileName)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(fileName);
            string nextLine;

            string compileData = "";
            foreach (string value in data)
            {
                if (Int16.TryParse(value, out short numeric) && numeric < 0)
                {
                    compileData += "(" + value + ")";
                }
                else
                {
                    compileData += value;
                }
                compileData += ",";
            }
            compileData = compileData.TrimEnd(new char[] { ',' });

            int counter = 0;
            while ((nextLine = file.ReadLine()) != null)
            {
                if (counter == line)
                {
                    builder.Append(compileData);
                    builder.Append("\r\n");
                }
                else
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
                counter++;
            }

            file.Close();
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        public void AddNewCSVEntry(string fileName, int indexOfID)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(fileName);
            string nextLine;
            int counter = -1;
            string[] tableLine = new string[0];

            while ((nextLine = file.ReadLine()) != null)
            {
                tableLine = nextLine.Split(',');
                counter += 1;
                builder.Append(nextLine);
                builder.Append("\r\n");
            }

            string[] newData = Enumerable.Repeat("0", tableLine.Length).ToArray();

            newData[indexOfID] = DecToHexString(counter);

            string compileData = "";
            foreach (string value in newData)
            {
                compileData += value;
                compileData += ",";
            }
            compileData = compileData.TrimEnd(new char[] { ',' });

            builder.Append(compileData);

            file.Close();
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();

        }

        public void AddNewCloneCSVEntry(string fileName, int indexToClone, int indexOfID)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(fileName);
            string nextLine;
            int counter = -1;
            string[] tableLine = new string[0];

            while ((nextLine = file.ReadLine()) != null)
            {
                counter += 1;
                builder.Append(nextLine);
                builder.Append("\r\n");
                if (counter == indexToClone)
                {
                    tableLine = nextLine.Split(',');
                }
            }

            tableLine[indexOfID] = DecToHexString(counter);

            string compileData = "";
            foreach (string value in tableLine)
            {
                compileData += value;
                compileData += ",";
            }
            compileData = compileData.TrimEnd(new char[] { ',' });

            builder.Append(compileData);

            file.Close();
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();

        }

        public string DecToHexString(decimal input)
        {
            return "0x" + String.Format("{0:X}", Decimal.ToInt32(input)).ToLower();
        }

        public decimal ReadCSVNumeric(string input)
        {
            if (input != null)
            {
                input = input.Replace("(", String.Empty);
                input = input.Replace(")", String.Empty);
                return Int16.Parse(input);
            }
            else
            {
                return 0;
            }

        }

        public void classSave_Click(object sender, EventArgs e)
        {
            classTableSave();
        }

        public void classTableSave()
        {
            if (classSelector.SelectedItem != null)
            {

                int index = classSelector.SelectedIndex + 1;

                string[] classData = new string[58];

                classData[0] = classIdentifier.Text;
                classData[1] = classNameText.Text;
                classData[2] = classDescriptionText.Text;
                classData[3] = DecToHexString(classID.Value);
                classData[4] = classPromotion.Text;
                classData[5] = classMapSprite.Text;
                classData[6] = DecToHexString(classWalkSpeed.Value);
                classData[7] = classClassCard.Text;
                classData[8] = DecToHexString(classSortOrder.Value);
                classData[9] = classBaseHP.Value.ToString();
                classData[10] = classBaseStr.Value.ToString();
                classData[11] = classBaseSkl.Value.ToString();
                classData[12] = classBaseSpd.Value.ToString();
                classData[13] = classBaseDef.Value.ToString();
                classData[14] = classBaseRes.Value.ToString();
                classData[15] = classBaseCon.Value.ToString();
                classData[16] = classBaseMov.Value.ToString();
                classData[17] = classHPCap.Value.ToString();
                classData[18] = classStrCap.Value.ToString();
                classData[19] = classSklCap.Value.ToString();
                classData[20] = classSpdCap.Value.ToString();
                classData[21] = classDefCap.Value.ToString();
                classData[22] = classResCap.Value.ToString();
                classData[23] = classConCap.Value.ToString();
                classData[24] = classRelativePower.Value.ToString();
                classData[25] = classHPGrowth.Value.ToString();
                classData[26] = classStrGrowth.Value.ToString();
                classData[27] = classSklGrowth.Value.ToString();
                classData[28] = classSpdGrowth.Value.ToString();
                classData[29] = classDefGrowth.Value.ToString();
                classData[30] = classResGrowth.Value.ToString();
                classData[31] = classLuckGrowth.Value.ToString();
                classData[32] = classHPPromo.Value.ToString();
                classData[33] = classStrPromo.Value.ToString();
                classData[34] = classSklPromo.Value.ToString();
                classData[35] = classSpdPromo.Value.ToString();
                classData[36] = classDefPromo.Value.ToString();
                classData[37] = classResPromo.Value.ToString();
                classData[38] = CharClassAbilityWriter(true);
                classData[39] = IntToWeaponRank(classSwordRankBox.SelectedIndex);
                classData[40] = IntToWeaponRank(classLanceRankBox.SelectedIndex);
                classData[41] = IntToWeaponRank(classAxeRankBox.SelectedIndex);
                classData[42] = IntToWeaponRank(classBowRankBox.SelectedIndex);
                classData[43] = IntToWeaponRank(classStaffRankBox.SelectedIndex);
                classData[44] = IntToWeaponRank(classAnimaRankBox.SelectedIndex);
                classData[45] = IntToWeaponRank(classLightRankBox.SelectedIndex);
                classData[46] = IntToWeaponRank(classDarkRankBox.SelectedIndex);
                classData[47] = classAnimation.Text;
                classData[48] = classMoveCost.Text;
                classData[49] = classRainMoveCost.Text;
                classData[50] = classSnowMoveCost.Text;
                classData[51] = classAvoBonus.Text;
                classData[52] = classDefBonus.Text;
                classData[53] = classResBonus.Text;
                classData[54] = classClassType.Text;

                WriteToCSV(classData, index, GetClassCSV());

                // class magic csv
                if (configStrMag.Checked)
                {
                    string[] classMagData = new string[5];

                    classMagData[0] = classIdentifier.Text;
                    classMagData[1] = classBaseMag.Value.ToString();
                    classMagData[2] = classMagGrowth.Value.ToString();
                    classMagData[3] = classMagCap.Value.ToString();
                    classMagData[4] = classMagPromo.Value.ToString();

                    WriteToCSV(classMagData, index, GetClassMagCSV());
                }

                // class skill csv
                string[] classSkillData = new string[2];

                classSkillData[0] = "\"" + DecToHexString(classID.Value) + " " + classIdentifier.Text + "\"";
                if (classSkillComboBox.SelectedItem != null && classSkillComboBox.SelectedItem.ToString() != "None")
                {
                    classSkillData[1] = "\"" + classSkillComboBox.SelectedItem + "ID\"";
                }
                else
                {
                    classSkillData[1] = "\"0x0\"";
                }

                WriteToCSV(classSkillData, index, GetClassSkillCSV());

                // moving map sprite csv
                string[] classMovingData = new string[3];

                classMovingData[0] = classIdentifier.Text;
                classMovingData[1] = classMovingSpriteData.Text;
                classMovingData[2] = classMovingAP.Text;

                WriteToCSV(classMovingData, index - 1, GetMovingMapSpriteCSV());

                // walking sound csv
                string[] classWalkingData = new string[2];

                classWalkingData[0] = classIdentifier.Text;
                classWalkingData[1] = classWalkSound.Value.ToString();

                WriteToCSV(classWalkingData, index, GetWalkingSoundCSV());

                // promo branch csv

                string[] classPromoData = new string[3];

                classPromoData[0] = classIdentifier.Text;
                classPromoData[1] = classPromo1.Text;
                classPromoData[2] = classPromo2.Text;

                WriteToCSV(classPromoData, index - 1, GetPromotionCSV());

                classSelector.Items.Clear();
                PopulateClassSelector();
                classSelector.SelectedIndex = index - 1;

            }
        }

        public void characterTableSave()
        {
            if (characterSelector.SelectedItem != null)
            {
                int index = characterSelector.SelectedIndex + 1;

                string[] characterData = new string[47];

                characterData[0] = characterIdentifier.Text;
                characterData[1] = characterNameText.Text;
                characterData[2] = characterDescriptionText.Text;
                characterData[3] = DecToHexString(characterID.Value);
                characterData[4] = characterClass.Text;
                characterData[5] = characterMug.Text;
                characterData[6] = DecToHexString(characterMinimug.Value);

                if (characterAffinityBox.SelectedItem.ToString() != "")
                {
                    characterData[7] = characterAffinityBox.SelectedItem.ToString() + "Affinity";
                }
                else
                {
                    characterData[7] = "NoAffinity";
                }

                characterData[8] = DecToHexString(characterSortOrder.Value);
                characterData[9] = characterBaseLevel.Value.ToString();
                characterData[10] = characterBaseHP.Value.ToString();
                characterData[11] = characterBaseStr.Value.ToString();
                characterData[12] = characterBaseSkl.Value.ToString();
                characterData[13] = characterBaseSpd.Value.ToString();
                characterData[14] = characterBaseDef.Value.ToString();
                characterData[15] = characterBaseRes.Value.ToString();
                characterData[16] = characterBaseLuck.Value.ToString();
                characterData[17] = characterBaseCon.Value.ToString();
                characterData[18] = IntToWeaponRank(characterSwordRankBox.SelectedIndex);
                characterData[19] = IntToWeaponRank(characterLanceRankBox.SelectedIndex);
                characterData[20] = IntToWeaponRank(characterAxeRankBox.SelectedIndex);
                characterData[21] = IntToWeaponRank(characterBowRankBox.SelectedIndex);
                characterData[22] = IntToWeaponRank(characterStaffRankBox.SelectedIndex);
                characterData[23] = IntToWeaponRank(characterAnimaRankBox.SelectedIndex);
                characterData[24] = IntToWeaponRank(characterLightRankBox.SelectedIndex);
                characterData[25] = IntToWeaponRank(characterDarkRankBox.SelectedIndex);
                characterData[26] = characterHPGrowth.Value.ToString();
                characterData[27] = characterStrGrowth.Value.ToString();
                characterData[28] = characterSklGrowth.Value.ToString();
                characterData[29] = characterSpdGrowth.Value.ToString();
                characterData[30] = characterDefGrowth.Value.ToString();
                characterData[31] = characterResGrowth.Value.ToString();
                characterData[32] = characterLuckGrowth.Value.ToString();

                // 5 unused bytes
                characterData[33] = "0x0";
                characterData[34] = "0x0";
                characterData[35] = "0x0";
                characterData[36] = "0x0";
                characterData[37] = "0x0";

                characterData[38] = CharClassAbilityWriter(false);

                characterData[39] = characterSupports.Text;

                // 4 unused bytes
                characterData[40] = "0x0";
                characterData[41] = "0x0";
                characterData[42] = "0x0";
                characterData[43] = "0x0";

                WriteToCSV(characterData, index, GetCharacterCSV());

                // character magic csv
                if (configStrMag.Checked)
                {
                    string[] characterMagData = new string[3];

                    characterMagData[0] = characterIdentifier.Text;
                    characterMagData[1] = characterBaseMag.Value.ToString();
                    characterMagData[2] = characterMagGrowth.Value.ToString();

                    WriteToCSV(characterMagData, index, GetCharacterMagCSV());
                }

                // character skill csv
                string[] characterSkillData = new string[2];

                characterSkillData[0] = "\"" + DecToHexString(characterID.Value) + " " + characterIdentifier.Text + "\"";
                if (characterSkillComboBox.SelectedItem != null && characterSkillComboBox.SelectedItem.ToString() != "None")
                {
                    characterSkillData[1] = "\"" + characterSkillComboBox.SelectedItem + "ID\"";
                }
                else
                {
                    characterSkillData[1] = "\"0x0\"";
                }

                WriteToCSV(characterSkillData, index+1, GetCharacterSkillCSV());

                characterSelector.Items.Clear();
                PopulateCharacterSelector();
                characterSelector.SelectedIndex = index - 1;
            }
        }

        public void chapterTableSave()
        {
            if (chapterSelector.SelectedItem != null)
            {
                int index = chapterSelector.SelectedIndex + 1;

                string[] chapterData = Enumerable.Repeat("0x0", 100).ToArray();

                chapterData[0] = chapterIdentifier.Text;
                chapterData[9] = DecToHexString(chapterFog.Value);
                chapterData[11] = DecToHexString(chapterID.Value);

                chapterData[13] = chapterCameraX.Value.ToString();
                chapterData[14] = chapterCameraY.Value.ToString();

                chapterData[15] = DecToHexString(chapterWeather.Value);
                chapterData[16] = DecToHexString(chapterBackground.Value);
                chapterData[17] = DecToHexString(chapterDifficulty.Value);
   
                chapterData[18] = chapterPlayerBGM.Text;
                chapterData[19] = chapterEnemyBGM.Text;
                chapterData[20] = chapterNPCBGM.Text;
                chapterData[21] = chapterPlayerBattleBGM.Text;
                chapterData[22] = chapterEnemyBattleBGM.Text;
                chapterData[23] = chapterNPCBattleBGM.Text;
                chapterData[24] = chapterPlayerBGM2.Text;
                chapterData[25] = chapterEnemyBGM2.Text;
                chapterData[26] = chapterPrepBGM.Text;

                chapterData[29] = chapterWallHP.Value.ToString();

                chapterData[68] = chapterName.Text;

                chapterData[70] = DecToHexString(chapterEvent.Value);
                chapterData[71] = DecToHexString(chapterWMEvent.Value);

                chapterData[88] = DecToHexString(chapterVictory.Value);
                chapterData[89] = DecToHexString(chapterFade.Value);

                chapterData[90] = chapterObjective.Text;
                chapterData[91] = chapterMapObjective.Text;
                chapterData[92] = DecToHexString(chapterObjectiveType.Value);

                chapterData[93] = chapterTurns.Value.ToString();
                chapterData[94] = chapterDefendUnit.Text;

                chapterData[95] = chapterMarkerX.Value.ToString();
                chapterData[96] = chapterMarkerY.Value.ToString();

                WriteToCSV(chapterData, index, GetChapterCSV());

                chapterSelector.Items.Clear();
                PopulateChapterSelector();
                chapterSelector.SelectedIndex = index - 1;
            }
        }

        public void itemTableSave()
        {
            if (itemSelector.SelectedItem != null)
            {
                int index = itemSelector.SelectedIndex + 1;

                string[] itemData = new string[27];

                itemData[0] = itemIdentifier.Text;
                itemData[1] = itemNameText.Text;
                itemData[2] = itemDescriptionText.Text;
                itemData[3] = itemUseText.Text;
                itemData[4] = DecToHexString(itemID.Value);
                itemData[5] = DecToHexString(itemType.Value);
                itemData[6] = ItemAbilityWriter();
                itemData[7] = itemStatBonus.Text;
                itemData[8] = itemEffectiveness.Text;
                itemData[9] = itemDurability.Value.ToString();
                itemData[10] = itemMight.Value.ToString();
                itemData[11] = itemHit.Value.ToString();
                itemData[12] = itemWeight.Value.ToString();
                itemData[13] = itemCrit.Value.ToString();
                itemData[14] = DecToHexString(itemRange.Value);
                itemData[15] = itemPrice.Value.ToString();
                itemData[16] = IntToWeaponRank(itemRankBox.SelectedIndex);
                itemData[17] = itemIcon.Text;
                itemData[18] = DecToHexString(itemUseEffect.Value);
                itemData[19] = DecToHexString(itemWeaponEffect.Value);
                itemData[20] = itemWEXP.Value.ToString();
                itemData[21] = DecToHexString(itemDebuff.Value);
                itemData[22] = DecToHexString(itemIERExtra.Value);
                itemData[23] = DecToHexString(GetSkillIDByName(itemSkillComboBox.SelectedItem.ToString() + "ID"));

                WriteToCSV(itemData, index, GetItemCSV());

                // spell association csv
                string[] spellAssocData = new string[11];

                spellAssocData[0] = itemIdentifier.Text;
                spellAssocData[1] = DecToHexString(itemID.Value);
                spellAssocData[2] = DecToHexString(itemIsMapAnim.Value);
                spellAssocData[3] = DecToHexString(itemMagicAnim.Value);
                spellAssocData[4] = DecToHexString(itemMagicAnimEnabled.Value);
                spellAssocData[5] = "0x0";
                spellAssocData[6] = itemMapAnim.Text;
                spellAssocData[7] = DecToHexString(itemHPChange.Value);
                spellAssocData[8] = DecToHexString(itemDirection.Value);
                spellAssocData[9] = DecToHexString(itemColor.Value);
                spellAssocData[10] = "0x0";

                WriteToCSV(spellAssocData, index-1, GetSpellAssocCSV());


                itemSelector.Items.Clear();
                PopulateItemSelector();
                itemSelector.SelectedIndex = index - 1;
            }
        }

        public void configStrMag_CheckedChanged(object sender, EventArgs e)
        {
            if (!toggleFlag)
            {
                ToggleConfigOption("USE_STRMAG_SPLIT");
                ToggleVisibilites();
            }
        }

        public SortedSet<string> GetAllSkills() // QoL: Skills are now sorted by name
        {
            StreamReader skillDefs = new StreamReader(GetSkillDefinitions());
            SortedSet<string> skillList = new SortedSet<string>();

            string nextLine;

            while ((nextLine = skillDefs.ReadLine()) != null)
            {
                string[] checkLine = nextLine.Split(' ');
                if (checkLine[0].Equals("#define") && (!checkLine[2].Equals("255") || !int.TryParse(checkLine[2], out int i)))
                {
                    skillList.Add(checkLine[1].Substring(0, checkLine[1].Length - 2));
                }
            }

            skillDefs.Close();
            return skillList;
        }

        public void EditSkillListEntry(string skillList, int index, decimal level, string skillID)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(GetSkillLists());

            string nextLine;

            LinkedList<string> stringBuffer = new LinkedList<string>();
            LinkedList<string> stringBuffer2 = new LinkedList<string>();

            while ((nextLine = file.ReadLine()) != null)
            {
                if (nextLine.Equals(skillList + ":"))
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                    while ((nextLine = file.ReadLine()) != "BYTE 00 00")
                    {
                        stringBuffer.AddLast(nextLine);
                    }
                    foreach (string Entry in stringBuffer)
                    {
                        string[] checkEntry = Entry.Split(' ');
                        if ((checkEntry[0] == "//" || checkEntry[0] == "//BYTE") != true)
                        {
                            stringBuffer2.AddLast(Entry);
                        }
                    }
                    foreach (string Entry in stringBuffer2)
                    {
                        if (index == 0)
                        {
                            builder.Append("BYTE " + level + " " + skillID + "ID");
                            builder.Append("\r\n");
                        }
                        else
                        {
                            builder.Append(Entry);
                            builder.Append("\r\n");
                        }
                        index--;
                    }
                    builder.Append("BYTE 00 00");
                    builder.Append("\r\n");
                }
                else
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
            }

            file.Close();
            StreamWriter writer = new StreamWriter(GetSkillLists());
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        public void RunC2EA()
        {
            var C2EA = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filePath + "\\Tools\\C2EA\\c2ea.exe",
                    Arguments = filePath + "\\FE8_clean.gba",
                    WorkingDirectory = filePath + "\\Tables\\"
                }
            };
            C2EA.Start();
            C2EA.WaitForExit();
        }

        public void classSaveC2EA_Click(object sender, EventArgs e)
        {
            classTableSave();
            RunC2EA();
        }

        public void classSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClassSkillImage();
        }

        public void classSkillLearnListButton_Click(object sender, EventArgs e)
        {
            if (classSelector.SelectedItem != null)
            {
                SkillLearnListEditor classSkillLearnListEditor = new SkillLearnListEditor(this, true);
                classSkillLearnListEditor.ShowDialog();
            }
        }

        public string GetSelectedClass()
        {
            return classSelector.Text;
        }

        public int GetSelectedClassIndex()
        {
            return classSelector.SelectedIndex;
        }

        public string GetSelectedCharacter()
        {
            return characterSelector.Text;
        }

        public int GetSelectedCharacterIndex()
        {
            return characterSelector.SelectedIndex;
        }

        public LinkedList<(int, string)> GetSkillList(string skillList)
        {
            LinkedList<(int, string)> output = new LinkedList<(int, string)>();

            StreamReader skillDefs = new StreamReader(GetSkillLists());
            string nextLine;

            while ((nextLine = skillDefs.ReadLine()) != null)
            {
                if (nextLine.Equals(skillList + ":"))
                {
                    while ((nextLine = skillDefs.ReadLine()) != "BYTE 00 00")
                    {
                        String[] checkLine = nextLine.Split(' ');
                        if (checkLine[0] != "//" && checkLine[0] != "//BYTE")
                        {
                            output.AddLast((Int16.Parse(checkLine[1]), checkLine[2].Substring(0, checkLine[2].Length - 2)));
                        }
                    }
                    break;
                }
            }

            skillDefs.Close();

            return output;
        }

        public void AddSkillListEntry(string skillList, decimal level, string skillID)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(GetSkillLists());

            string nextLine;

            while ((nextLine = file.ReadLine()) != null)
            {
                if (nextLine.Equals(skillList + ":"))
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                    while ((nextLine = file.ReadLine()) != "BYTE 00 00")
                    {
                        builder.Append(nextLine);
                        builder.Append("\r\n");
                    }
                    builder.Append("BYTE " + level + " " + skillID + "ID");
                    builder.Append("\r\n");
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
                else
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
            }

            file.Close();
            StreamWriter writer = new StreamWriter(GetSkillLists());
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        public void RemoveSkillListEntry(string skillList, int index, decimal level, string skillID)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(GetSkillLists());

            string nextLine;

            LinkedList<string> stringBuffer = new LinkedList<string>();
            LinkedList<string> stringBuffer2 = new LinkedList<string>();

            while ((nextLine = file.ReadLine()) != null)
            {
                if (nextLine.Equals(skillList + ":"))
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                    while ((nextLine = file.ReadLine()) != "BYTE 00 00")
                    {
                        stringBuffer.AddLast(nextLine);
                    }
                    foreach (string Entry in stringBuffer)
                    {
                        string[] checkEntry = Entry.Split(' ');
                        if ((checkEntry[0] == "//" || checkEntry[0] == "//BYTE") != true)
                        {
                            stringBuffer2.AddLast(Entry);
                        }
                    }
                    foreach (string Entry in stringBuffer2)
                    {
                        if (index != 0)
                        {
                            builder.Append(Entry);
                            builder.Append("\r\n");
                        }
                        index--;
                    }
                    builder.Append("BYTE 00 00");
                    builder.Append("\r\n");
                }
                else
                {
                    builder.Append(nextLine);
                    builder.Append("\r\n");
                }
            }

            file.Close();
            StreamWriter writer = new StreamWriter(GetSkillLists());
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        public LinkedList<string> GetAllSkillLists()
        {
            LinkedList<string> skillListList = new LinkedList<string>();

            StreamReader file = new StreamReader(GetSkillLists());
            string nextLine;

            while ((nextLine = file.ReadLine()) != null)
            {
                if (nextLine.Contains(":"))
                {
                    skillListList.AddLast(nextLine.Substring(0, nextLine.Length - 1));
                }
            }

            file.Close();

            return skillListList;
        }

        public void ChangeClassSkillList(int index, string className, string newSkillList)
        {
            string[] skillData = new string[2];

            skillData[0] = className;
            skillData[1] = newSkillList;

            WriteToCSV(skillData, index, GetClassLevelUpSkillCSV());
        }

        public void ChangeCharacterSkillList(int index, string characterName, string newSkillList)
        {
            string[] skillData = new string[2];

            skillData[0] = characterName;
            skillData[1] = newSkillList;

            WriteToCSV(skillData, index, GetCharacterLevelUpSkillCSV());
        }

        public void AddSkillList(string newSkillList)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader file = new StreamReader(GetSkillLists());

            string nextLine;

            while ((nextLine = file.ReadLine()) != null)
            {
                builder.Append(nextLine);
                builder.Append("\r\n");
            }

            builder.Append("\r\n");
            builder.Append(newSkillList + ":");
            builder.Append("\r\n");
            builder.Append("BYTE 00 00");
            builder.Append("\r\n");
            builder.Append("ALIGN 4");
            builder.Append("\r\n");

            file.Close();
            StreamWriter writer = new StreamWriter(GetSkillLists());
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
        }

        private void classMoveTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classMoveTypeBox.SelectedItem.ToString() != "")
            {
                classAvoBonus.Text = "0x" + FE8Constants.TerrainAvo.ToString("X").ToLower();
                classDefBonus.Text = "0x" + FE8Constants.TerrainDef.ToString("X").ToLower();
                classResBonus.Text = "0x" + FE8Constants.TerrainRes.ToString("X").ToLower();
            }
            if (classMoveTypeBox.SelectedItem.ToString() == "Flier")
            {
                classAvoBonus.Text = "0x" + FE8Constants.NoTerrainAvo.ToString("X").ToLower();
                classDefBonus.Text = "0x" + FE8Constants.NoTerrainDef.ToString("X").ToLower();
                classResBonus.Text = "0x" + FE8Constants.NoTerrainRes.ToString("X").ToLower();
            }

            if (classMoveTypeBox.SelectedItem.ToString() == "Infantry")
            {
                classMoveCost.Text = "0x" + FE8Constants.InfantryMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.InfantryRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.InfantrySnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Infantry T2")
            {
                classMoveCost.Text = "0x" + FE8Constants.InfantryT2Move.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.InfantryT2RainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.InfantryT2SnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Cavalry")
            {
                classMoveCost.Text = "0x" + FE8Constants.CavalryMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.CavalryRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.CavalrySnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "CavalryT2")
            {
                classMoveCost.Text = "0x" + FE8Constants.CavalryT2Move.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.CavalryT2RainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.CavalryT2SnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Armor")
            {
                classMoveCost.Text = "0x" + FE8Constants.ArmorMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.ArmorRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.ArmorSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Thief")
            {
                classMoveCost.Text = "0x" + FE8Constants.ThiefMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.ThiefRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.ThiefSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Flier")
            {
                classMoveCost.Text = "0x" + FE8Constants.FlierMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.FlierRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.FlierSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Mage")
            {
                classMoveCost.Text = "0x" + FE8Constants.MageMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.MageRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.MageSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Fighter")
            {
                classMoveCost.Text = "0x" + FE8Constants.FighterMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.FighterRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.FighterSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Brigand")
            {
                classMoveCost.Text = "0x" + FE8Constants.BrigandMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.BrigandRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.BrigandSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Pirate")
            {
                classMoveCost.Text = "0x" + FE8Constants.PirateMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.PirateRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.PirateSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Berserker")
            {
                classMoveCost.Text = "0x" + FE8Constants.BerserkerMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.BerserkerRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.BerserkerSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Ranger T1")
            {
                classMoveCost.Text = "0x" + FE8Constants.RangerT1Move.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.RangerT1RainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.RangerT1SnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Ranger")
            {
                classMoveCost.Text = "0x" + FE8Constants.RangerMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.RangerRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.RangerSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Civilian")
            {
                classMoveCost.Text = "0x" + FE8Constants.CivilianMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.CivilianRainMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.CivilianSnowMove.ToString("X").ToLower();
            }
            else if (classMoveTypeBox.SelectedItem.ToString() == "Demon King")
            {
                classMoveCost.Text = "0x" + FE8Constants.DemonKingMove.ToString("X").ToLower();
                classRainMoveCost.Text = "0x" + FE8Constants.DemonKingMove.ToString("X").ToLower();
                classSnowMoveCost.Text = "0x" + FE8Constants.DemonKingMove.ToString("X").ToLower();
            }
        }

        private void characterSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCharacterSelection();
        }

        private void characterSave_Click(object sender, EventArgs e)
        {
            characterTableSave();
        }

        private void characterSaveC2EA_Click(object sender, EventArgs e)
        {
            characterTableSave();
            RunC2EA();
        }

        private void characterSkillLearnListButton_Click(object sender, EventArgs e)
        {
            if (characterSelector.SelectedItem != null)
            {
                SkillLearnListEditor characterSkillLearnListEditor = new SkillLearnListEditor(this, false);
                characterSkillLearnListEditor.ShowDialog();
            }
        }

        private void characterSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCharacterSkillImage();
        }

        private void itemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItemSelection();
        }

        private void itemSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItemSkillImage();
            itemSkillValue = GetSkillIDByName(itemSkillComboBox.SelectedItem + "ID");
        }

        private void itemTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeItemTypeValue(itemTypeBox.SelectedItem.ToString(), itemType);
        }

        private void itemSave_Click(object sender, EventArgs e)
        {
            itemTableSave();
        }

        private void itemSaveC2EA_Click(object sender, EventArgs e)
        {
            itemTableSave();
            RunC2EA();
        }

        private void chapterSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChapterSelection();
        }

        private void chapterWeatherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeWeatherValue(chapterWeatherBox.SelectedItem.ToString(), chapterWeather);
        }

        private void chapterBackgroundBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            chapterBackground.Value = chapterBackgroundBox.SelectedIndex;
        }

        private void chapterObjectiveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chapterObjectiveBox.SelectedIndex == 0)
            {
                chapterObjectiveType.Value = 0;
            }
            else
            {
                chapterObjectiveType.Value = chapterObjectiveBox.SelectedIndex - 1;
            }
        }

        private void chapterSave_Click(object sender, EventArgs e)
        {
            chapterTableSave();
        }

        private void chapterSaveC2EA_Click(object sender, EventArgs e)
        {
            chapterTableSave();
            RunC2EA();
        }

        private void classNewEntry_Click(object sender, EventArgs e)
        {
            AddNewCSVEntry(GetClassCSV(), 3);
            AddNewCSVEntry(GetMovingMapSpriteCSV(), 0);

            classSelector.Items.Clear();
            PopulateClassSelector();
            classSelector.SelectedIndex = classSelector.Items.Count - 1;
        }

        private void itemNewEntry_Click(object sender, EventArgs e)
        {
            AddNewCSVEntry(GetItemCSV(), 4);

            itemSelector.Items.Clear();
            PopulateItemSelector();
            itemSelector.SelectedIndex = itemSelector.Items.Count - 1;
        }

        private void classCloneEntry_Click(object sender, EventArgs e)
        {
            if (classSelector.SelectedItem != null)
            {
                AddNewCloneCSVEntry(GetClassCSV(), classSelector.SelectedIndex + 1, 3);
                AddNewCloneCSVEntry(GetMovingMapSpriteCSV(), classSelector.SelectedIndex, 0);

                classSelector.Items.Clear();
                PopulateClassSelector();
                classSelector.SelectedIndex = classSelector.Items.Count - 1;
            }
        }

        public string GetValueFromDefinition(string definition, string fileName)
        {
            string nextLine;
            StreamReader file = new StreamReader(fileName);
            while ((nextLine = file.ReadLine()) != null)
            {
                string[] checkLine = nextLine.Split(' ');
                if (checkLine[0].Equals("#define") && checkLine[1].Equals(definition))
                {
                    file.Close();
                    string value = nextLine;
                    return value.Replace(("#define " + definition + " "), String.Empty);
                }
            }
            file.Close();
            return null;
        }

        private void classWalkSoundBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            classWalkSound.Value = classWalkSoundBox.SelectedIndex;
        }

        private string CharClassAbilityWriter(bool isClass)
        {
            CheckedListBox abilityCheckBoxList;

            if (isClass)
            {
                abilityCheckBoxList = classAbilityCheckBoxList;
            }
            else
            {
                abilityCheckBoxList = characterAbilityCheckBoxList;
            }

            string abilityValue = "";

            if (abilityCheckBoxList.GetItemChecked(0))
            {
                abilityValue += "|MountedAid";
            }
            if (abilityCheckBoxList.GetItemChecked(1))
            {
                abilityValue += "|HasCanto";
            }
            if (abilityCheckBoxList.GetItemChecked(2))
            {
                abilityValue += "|Steal";
            }
            if (abilityCheckBoxList.GetItemChecked(3))
            {
                abilityValue += "|CanUseLockpick";
            }
            if (abilityCheckBoxList.GetItemChecked(4))
            {
                abilityValue += "|CanDance";
            }
            if (abilityCheckBoxList.GetItemChecked(5))
            {
                abilityValue += "|CanPlay";
            }
            if (abilityCheckBoxList.GetItemChecked(6))
            {
                abilityValue += "|CritBoost";
            }
            if (abilityCheckBoxList.GetItemChecked(7))
            {
                abilityValue += "|UseBallista";
            }
            if (abilityCheckBoxList.GetItemChecked(8))
            {
                abilityValue += "|IsPromoted";
            }
            if (abilityCheckBoxList.GetItemChecked(9))
            {
                abilityValue += "|IsSupply";
            }
            if (abilityCheckBoxList.GetItemChecked(10))
            {
                abilityValue += "|HorseIcon";
            }
            if (abilityCheckBoxList.GetItemChecked(11))
            {
                abilityValue += "|DragonIcon";
            }
            if (abilityCheckBoxList.GetItemChecked(12))
            {
                abilityValue += "|PegIcon";
            }
            if (abilityCheckBoxList.GetItemChecked(13))
            {
                abilityValue += "|IsLord";
            }
            if (abilityCheckBoxList.GetItemChecked(14))
            {
                abilityValue += "|IsFemale";
            }
            if (abilityCheckBoxList.GetItemChecked(15))
            {
                abilityValue += "|IsBoss";
            }
            if (abilityCheckBoxList.GetItemChecked(16))
            {
                abilityValue += "|UnlockLock1";
            }
            if (abilityCheckBoxList.GetItemChecked(17))
            {
                abilityValue += "|SwordmasterUnlock";
            }
            if (abilityCheckBoxList.GetItemChecked(18))
            {
                abilityValue += "|UseMonsterWeapons";
            }
            if (abilityCheckBoxList.GetItemChecked(19))
            {
                abilityValue += "|TraineeLevelCap";
            }
            if (abilityCheckBoxList.GetItemChecked(20))
            {
                abilityValue += "|CannotControl";
            }
            if (abilityCheckBoxList.GetItemChecked(21))
            {
                abilityValue += "|TriangleAttack";
            }
            if (abilityCheckBoxList.GetItemChecked(22))
            {
                abilityValue += "|TriangleAttack2";
            }
            if (abilityCheckBoxList.GetItemChecked(23))
            {
                abilityValue += "|DecrementIDAfterLoad";
            }
            if (abilityCheckBoxList.GetItemChecked(24))
            {
                abilityValue += "|GiveNoExp";
            }
            if (abilityCheckBoxList.GetItemChecked(25))
            {
                abilityValue += "|Lethality";
            }
            if (abilityCheckBoxList.GetItemChecked(26))
            {
                abilityValue += "|IsMagicSeal";
            }
            if (abilityCheckBoxList.GetItemChecked(27))
            {
                abilityValue += "|Summoning";
            }
            if (abilityCheckBoxList.GetItemChecked(28))
            {
                abilityValue += "|UnlockEirika";
            }
            if (abilityCheckBoxList.GetItemChecked(29))
            {
                abilityValue += "|UnlockEphraim";
            }
            if (abilityCheckBoxList.GetItemChecked(30))
            {
                abilityValue += "|UnlockLock3";

            }
            if (abilityCheckBoxList.GetItemChecked(31))
            {
                abilityValue += "|UnlockLock4";
            }

            if (abilityValue.Length != 0)
            {
                return abilityValue.Substring(1);
            }
            else
            {
                return "0x0";
            }
        }

        private string ItemAbilityWriter()
        {
            CheckedListBox abilityCheckBoxList = itemAbilityCheckBoxList;

            string abilityValue = "";

            if (abilityCheckBoxList.GetItemChecked(0))
            {
                abilityValue += "|IsWeapon";
            }
            if (abilityCheckBoxList.GetItemChecked(1))
            {
                abilityValue += "|IsMagic";
            }
            if (abilityCheckBoxList.GetItemChecked(2))
            {
                abilityValue += "|IsStaff";
            }
            if (abilityCheckBoxList.GetItemChecked(3))
            {
                abilityValue += "|Indestructible";
            }
            if (abilityCheckBoxList.GetItemChecked(4))
            {
                abilityValue += "|Unsellable";
            }
            if (abilityCheckBoxList.GetItemChecked(5))
            {
                abilityValue += "|IsBrave";
            }
            if (abilityCheckBoxList.GetItemChecked(6))
            {
                abilityValue += "|MagicDamage";
            }
            if (abilityCheckBoxList.GetItemChecked(7))
            {
                abilityValue += "|Uncounterable";
            }
            if (abilityCheckBoxList.GetItemChecked(8))
            {
                abilityValue += "|ReverseTriangle";
            }
            if (abilityCheckBoxList.GetItemChecked(9))
            {
                abilityValue += "|CannotRepair";
            }
            if (abilityCheckBoxList.GetItemChecked(10))
            {
                abilityValue += "|MonsterLock";
            }
            if (abilityCheckBoxList.GetItemChecked(11))
            {
                abilityValue += "|WeaponLock1";
            }
            if (abilityCheckBoxList.GetItemChecked(12))
            {
                abilityValue += "|SwordmasterLock";
            }
            if (abilityCheckBoxList.GetItemChecked(13))
            {
                abilityValue += "|WeaponLock2";
            }
            if (abilityCheckBoxList.GetItemChecked(14))
            {
                abilityValue += "|NegateFlyingEffectiveness";
            }
            if (abilityCheckBoxList.GetItemChecked(15))
            {
                abilityValue += "|NegateCriticals";
            }
            if (abilityCheckBoxList.GetItemChecked(16))
            {
                abilityValue += "|CannotUse";
            }
            if (abilityCheckBoxList.GetItemChecked(17))
            {
                abilityValue += "|NegateDef";
            }
            if (abilityCheckBoxList.GetItemChecked(18))
            {
                abilityValue += "|EirikaLock";
            }
            if (abilityCheckBoxList.GetItemChecked(19))
            {
                abilityValue += "|EphraimLock";
            }
            if (abilityCheckBoxList.GetItemChecked(20))
            {
                abilityValue += "|WeaponLock3";
            }
            if (abilityCheckBoxList.GetItemChecked(21))
            {
                abilityValue += "|WeaponLock4";
            }
            if (abilityCheckBoxList.GetItemChecked(22))
            {
                abilityValue += "|0x400000";
            }
            if (abilityCheckBoxList.GetItemChecked(23))
            {
                abilityValue += "|PassiveBoosts";
            }

            if (abilityValue.Length != 0)
            {
                return abilityValue.Substring(1);
            }
            else
            {
                return "0x0";
            }
        }


        private string IntToWeaponRank(int value)
        {
            String[] ranks = { "NoRank", "ERank", "DRank", "CRank", "BRank", "ARank", "SRank" };
            if (value <= 7)
            {
                return ranks[value];
            }
            else
            {
                return ranks[0];
            }

        }
    }

    public class FE8Constants
    {
        public static int ERank = 0x1;
        public static int DRank = 0x1F;
        public static int CRank = 0x47;
        public static int BRank = 0x79;
        public static int ARank = 0xB5;
        public static int SRank = 0xFB;

        public static int FireAffinity = 1;
        public static int ThunderAffinity = 2;
        public static int WindAffinity = 3;
        public static int IceAffinity = 4;   
        public static int DarkAffinity = 5;
        public static int LightAffinity = 6;
        public static int AnimaAffinity = 7;

        public static int Sword = 0x0;
        public static int Lance = 0x1;
        public static int Axe = 0x2;
        public static int Bow = 0x3;
        public static int Staff = 0x4;
        public static int Anima = 0x5;
        public static int Light = 0x6;
        public static int Dark = 0x7;
        public static int Item = 0x9;
        public static int Monster = 0xB;
        public static int Ring = 0xC;

        public static long InfantryMove = 0x880B849;
        public static long InfantryRainMove = 0x880BC9A;
        public static long InfantrySnowMove = 0x880C0AA;

        public static long InfantryT2Move = 0x880B808;
        public static long InfantryT2RainMove = 0x880BC59;
        public static long InfantryT2SnowMove = 0x880C069;

        public static long CavalryMove = 0x880BA92;
        public static long CavalryRainMove = 0x880BEE3;
        public static long CavalrySnowMove = 0x880C2F3;

        public static long CavalryT2Move = 0x880BAD3;
        public static long CavalryT2RainMove = 0x880BF24;
        public static long CavalryT2SnowMove = 0x880C334;

        public static long ArmorMove = 0x880B88A;
        public static long ArmorRainMove = 0x880BCDB;
        public static long ArmorSnowMove = 0x880C0EB;

        public static long ThiefMove = 0x880B9CF;
        public static long ThiefRainMove = 0x880BE20;
        public static long ThiefSnowMove = 0x880C230;

        public static long FlierMove = 0x880BB96;
        public static long FlierRainMove = 0x880BFE7;
        public static long FlierSnowMove = 0x880C3F7;

        public static long MageMove = 0x880BA10;
        public static long MageRainMove = 0x880BE61;
        public static long MageSnowMove = 0x880C271;

        public static long FighterMove = 0x880B8CB;
        public static long FighterRainMove = 0x880BD1C;
        public static long FighterSnowMove = 0x880C12C;

        public static long BrigandMove = 0x880B94D;
        public static long BrigandRainMove = 0x880BD9E;
        public static long BrigandSnowMove = 0x880C1AE;

        public static long PirateMove = 0x880B98E;
        public static long PirateRainMove = 0x880BDDF;
        public static long PirateSnowMove = 0x880C1EF;

        public static long BerserkerMove = 0x880B90C;
        public static long BerserkerRainMove = 0x880BD5D;
        public static long BerserkerSnowMove = 0x880C16D;

        public static long RangerT1Move = 0x880BB14;
        public static long RangerT1RainMove = 0x880BF65;
        public static long RangerT1SnowMove = 0x880C375;

        public static long RangerMove = 0x880BB55;
        public static long RangerRainMove = 0x880BFA6;
        public static long RangerSnowMove = 0x880C3B6;

        public static long CivilianMove = 0x880BA51;
        public static long CivilianRainMove = 0x880BEA2;
        public static long CivilianSnowMove = 0x880C2B2;

        public static long DemonKingMove = 0x880BBD7;

        public static long TerrainAvo = 0x880C479;
        public static long TerrainDef = 0x880C4BA;
        public static long TerrainRes = 0x880C4FB;

        public static long NoTerrainAvo = 0x880C53C;
        public static long NoTerrainDef = 0x880C57D;
        public static long NoTerrainRes = 0x880C5BE;

        public static long Snow = 0x1;
        public static long Blizzard = 0x2;
        public static long Rain = 0x4;
        public static long Fire = 0x5;
        public static long Sandstorm = 0x6;
        public static long Cloudy = 0x7;

        public static long SnowBG = 0x1;
        public static long VolcanoBG = 0x2;
        public static long Town1BG = 0x3;
        public static long Plains2BG = 0x4;
        public static long Fort1BG = 0x5;
        public static long Town2BG = 0x6;
        public static long Town3BG = 0x7;
        public static long ShipBG = 0x8;
        public static long DesertBG = 0x9;
        public static long Fort2BG = 0xA;
        public static long ValniBG = 0xB;
        public static long JehannaBG = 0xC;
        public static long DarklingBG = 0xD;
        public static long RenaisBG = 0xE;
        public static long Castle1BG = 0xF;
        public static long Castle2BG = 0x10;
        public static long Castle3BG = 0x11;
        public static long MountainBG = 0x12;
        public static long PortBG = 0x13;
        public static long SwampBG = 0x14;

        public static long Seize = 0x0;
        public static long Rout = 0x1;
        public static long Defend = 0x2;
        public static long Boss = 0x3;
        public static long OtherObjective = 0x4;

        public class ClassAbilities
        {
            // ability 1
            public static int MountedAid = 0x1;
            public static int Canto = 0x2;
            public static int Steal = 0x4;
            public static int ThiefSkill = 0x8;
            public static int Dance = 0x10;
            public static int Play = 0x20;
            public static int CritPlus15 = 0x40;
            public static int Ballista = 0x80;

            // ability 2 (+0x00)
            public static int Promoted = 0x1;
            public static int Supply = 0x2;
            public static int HorseIcon = 0x4;
            public static int DragonIcon = 0x8;
            public static int PegasusIcon = 0x10;
            public static int Lord = 0x20;
            public static int Female = 0x40;
            public static int Boss = 0x80;

            // ability 3 (+0x0000)
            public static int WeaponUnlock1 = 0x1;
            public static int WeaponUnlock2 = 0x2;
            public static int MonsterUnlock = 0x4;
            public static int Trainee = 0x8;
            public static int CannotControl = 0x10;
            public static int TriangleAttack = 0x20;
            public static int ArmorTriangle = 0x40;
            public static int DecrementID = 0x80;

            // ability 4 (+0x000000)
            public static int GiveNoEXP = 0x1;
            public static int Lethality = 0x2;
            public static int MagicSeal = 0x4;
            public static int Summoning = 0x8;
            public static int WeaponUnlock3 = 0x10;
            public static int WeaponUnlock4 = 0x20;
            public static int WeaponUnlock5 = 0x40;
            public static int WeaponUnlock6 = 0x80;
        }

        public class ItemAbilities
        {
            // ability 1
            public static int Weapon = 0x1;
            public static int Magic = 0x2;
            public static int Staff = 0x4;
            public static int Unbreakable = 0x8;
            public static int Unsellable = 0x10;
            public static int Brave = 0x20;
            public static int MagicSword = 0x40;
            public static int Uncounterable = 0x80;

            // ability 2 (+0x00)
            public static int Reaver = 0x1;
            public static int Unrepairable = 0x2;
            public static int MonsterLock = 0x4;
            public static int WeaponLock1 = 0x8;
            public static int WeaponLock2 = 0x10;
            public static int HideInfo = 0x20;
            public static int FiliShield = 0x40;
            public static int HoplonGuard = 0x80;

            // ability 3 (+0x0000)
            public static int Unusable = 0x1;
            public static int IgnoreDef = 0x2;
            public static int WeaponLock3 = 0x4;
            public static int WeaponLock4 = 0x8;
            public static int WeaponLock5 = 0x10;
            public static int WeaponLock6 = 0x20;
            public static int UnkAbility3 = 0x40;
            public static int PassiveBoosts = 0x80;
        }
    }
}
