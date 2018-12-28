using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Web;

namespace FF1_DOS_editor
{
    public partial class Form1 : Form
    {
        RomFileIO Rom = new RomFileIO();
        EnemySpecs Specs = new EnemySpecs();
        Spells Spells = new Spells();
        //FF6TextTables TextTable = new FF6TextTables();
        //SpellList SpellList = new SpellList();

        public string FName;
        public int statSum = 0;
        public int Fileoffset { get; private set; }
        public int ActorCheckStats;
        public int ActorCheckNaturalMagic;
        public int LevelCheck;
        public int EsperLevelCheck;
        public int EsperCheckMagic;
        public int EsperCharIndex;
        public int EsperBonusMult;
        public int MonsterIndexCheck;
        public int MonsterScriptBase;
        public int MonsterScriptMult;
        public int MonsterDiffCheck;
        public int MonsterHPByteCheck;
        public int MonsterSecondaryIndexCheck;
        public int MonsterSecondaryDiffCheck;
        public int MonsterStealDropIndexCheck;
        public int MonsterRageSketchIndex;
        public int SpellIndex;
        public int SpellDelayIndex;
        public int MonsterQueueIndex;

        string[] jobList = File.ReadAllLines("jobs.txt");
        string[] consumableList = File.ReadAllLines("consumables.txt");
        string[] weaponList = File.ReadAllLines("weapons.txt");
        string[] armorList = File.ReadAllLines("armor.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable File Saving until a file actually exists, to reduce potential problems.
            if (!Rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = false;
                saveROMToolStripMenuItem1.Enabled = false;
            }
        }

        private void LoadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Gameboy Advance ROM|*.gba",                                         //File type filter
                Title = "Load ROM",                                                         //Title for dialog
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };                                      //Setting the dialog up
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Could not open " + ofd.FileName);
                return;
            }
            FName = Path.GetFullPath(ofd.FileName);
            Rom.Open(ofd.FileName);
            if (Rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveROMToolStripMenuItem1.Enabled = true;
            }
            cmbMonsters.Items.AddRange(Specs.MonsterList);

            cmbMonsterSpell1.Items.Clear();
            cmbMonsterSpell1.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell2.Items.Clear();
            cmbMonsterSpell2.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell3.Items.Clear();
            cmbMonsterSpell3.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell4.Items.Clear();
            cmbMonsterSpell4.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell5.Items.Clear();
            cmbMonsterSpell5.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell6.Items.Clear();
            cmbMonsterSpell6.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell7.Items.Clear();
            cmbMonsterSpell7.Items.AddRange(Specs.SpellList);
            cmbMonsterSpell8.Items.Clear();
            cmbMonsterSpell8.Items.AddRange(Specs.SpellList);

            cmbMonsterAbility1.Items.Clear();
            cmbMonsterAbility1.Items.AddRange(Specs.AbilityList);
            cmbMonsterAbility2.Items.Clear();
            cmbMonsterAbility2.Items.AddRange(Specs.AbilityList);
            cmbMonsterAbility3.Items.Clear();
            cmbMonsterAbility3.Items.AddRange(Specs.AbilityList);
            cmbMonsterAbility4.Items.Clear();
            cmbMonsterAbility4.Items.AddRange(Specs.AbilityList);
            //DisplaySpellNames();
            //DisplayEnemyNames();
            cmbMonsters.SelectedIndex = 0;
            //cmbSpells.SelectedIndex = 0;
            UpdateMonsterStats();
            //UpdateSpells();

        }


        private void SaveROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                //Open SaveFileDialog for file saving.
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Gameboy Advance ROM|*.gba",
                    Title = "Save ROM"
                };
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Could not save " + sfd.FileName);
                }
                //Save the file to disk
                //Checks to make sure a file actually has been loaded.
                if (Rom.IsOpen())
                {
                    Rom.SaveAs(sfd.FileName);
                }
                else
                {
                    MessageBox.Show("No ROM is loaded.", "No ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveROMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rom.SaveAs(FName);
        }

        private void UpdateMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterQueueIndex = cmbMonsters.SelectedIndex * 16;
            
            //Begin populating stat values
            Specs.ReadMonsterNormal(Rom, RomData.MONSTER_DATA_OFFSET, MonsterIndexCheck, RomData.MONSTER_ATTACKS_DEFINITIONS_OFFSET, MonsterQueueIndex);

            //Monster stats
            numMonsterHP.Value = Specs.MaxHP;
            numMonsterEXP.Value = Specs.EXP;
            numMonsterGil.Value = Specs.Gil;
            numMonsterMorale.Value = Specs.Morale;
            numMonsterEvasion.Value = Specs.Evasion;
            numMonsterNumHits.Value = Specs.NumHits;
            numMonsterAccuracy.Value = Specs.Accuracy;
            numMonsterDefense.Value = Specs.Defense;
            numMonsterMagDef.Value = Specs.MagDef;
            numMonsterAttack.Value = Specs.Attack;
            numMonsterAgility.Value = Specs.Agility;
            numMonsterIntellect.Value = Specs.Intellect;
            numMonsterCritRate.Value = Specs.CritRate;
            cmbMonsterItemType.SelectedIndex = Specs.DropType;
            cmbMonsterItemDrop.SelectedIndex = Specs.ItemDropped;
            numDropChance.Value = Specs.DropChance;

            //Spell and ability queues
            numMonsterMagicQueue.Value = Specs.MagicProc;
            cmbMonsterSpell1.SelectedIndex = Specs.Spell1;
            cmbMonsterSpell2.SelectedIndex = Specs.Spell2;
            cmbMonsterSpell3.SelectedIndex = Specs.Spell3;
            cmbMonsterSpell4.SelectedIndex = Specs.Spell4;
            cmbMonsterSpell5.SelectedIndex = Specs.Spell5;
            cmbMonsterSpell6.SelectedIndex = Specs.Spell6;
            cmbMonsterSpell7.SelectedIndex = Specs.Spell7;
            cmbMonsterSpell8.SelectedIndex = Specs.Spell8;

            numMonsterAbilityQueue.Value = Specs.AbilityProc;
            cmbMonsterAbility1.SelectedIndex = Specs.Ability1;
            cmbMonsterAbility2.SelectedIndex = Specs.Ability2;
            cmbMonsterAbility3.SelectedIndex = Specs.Ability3;
            cmbMonsterAbility4.SelectedIndex = Specs.Ability4;



            //Monster properties
            //Attack elmeents
            chkMonsterAtkParalysis.Checked = Specs.AttackElement.HasFlag(Element.Paralysis);
            chkMonsterAtkStone.Checked = Specs.AttackElement.HasFlag(Element.Stone);
            chkMonsterAtkTime.Checked = Specs.AttackElement.HasFlag(Element.Time);
            chkMonsterAtkDeath.Checked = Specs.AttackElement.HasFlag(Element.Death);
            chkMonsterAtkFire.Checked = Specs.AttackElement.HasFlag(Element.Fire);
            chkMonsterAtkIce.Checked = Specs.AttackElement.HasFlag(Element.Ice);
            chkMonsterAtkLightning.Checked = Specs.AttackElement.HasFlag(Element.Lightning);
            chkMonsterAtkQuake.Checked = Specs.AttackElement.HasFlag(Element.Quake);
            chkMonsterAtkPoison.Checked = Specs.AttackElement.HasFlag(Element.Poison);
            chkMonsterAtkDarkness.Checked = Specs.AttackElement.HasFlag(Element.Darkness);
            chkMonsterAtkSleep.Checked = Specs.AttackElement.HasFlag(Element.Sleep);
            chkMonsterAtkSilence.Checked = Specs.AttackElement.HasFlag(Element.Silence);
            chkMonsterAtkConfusion.Checked = Specs.AttackElement.HasFlag(Element.Confuse);
            chkMonsterAtkMind.Checked = Specs.AttackElement.HasFlag(Element.Mind);

            //Resist
            chkMonsterResistParalysis.Checked = Specs.Resist.HasFlag(Element.Paralysis);
            chkMonsterResistStone.Checked = Specs.Resist.HasFlag(Element.Stone);
            chkMonsterResistTime.Checked = Specs.Resist.HasFlag(Element.Time);
            chkMonsterResistDeath.Checked = Specs.Resist.HasFlag(Element.Death);
            chkMonsterResistFire.Checked = Specs.Resist.HasFlag(Element.Fire);
            chkMonsterResistIce.Checked = Specs.Resist.HasFlag(Element.Ice);
            chkMonsterResistLightning.Checked = Specs.Resist.HasFlag(Element.Lightning);
            chkMonsterResistQuake.Checked = Specs.Resist.HasFlag(Element.Quake);
            chkMonsterResistPoison.Checked = Specs.Resist.HasFlag(Element.Poison);
            chkMonsterResistDarkness.Checked = Specs.Resist.HasFlag(Element.Darkness);
            chkMonsterResistSleep.Checked = Specs.Resist.HasFlag(Element.Sleep);
            chkMonsterResistSilence.Checked = Specs.Resist.HasFlag(Element.Silence);
            chkMonsterResistConfusion.Checked = Specs.Resist.HasFlag(Element.Confuse);
            chkMonsterResistMind.Checked = Specs.Resist.HasFlag(Element.Mind);

            //Weak
            chkMonsterWeakParalysis.Checked = Specs.Weak.HasFlag(Element.Paralysis);
            chkMonsterWeakStone.Checked = Specs.Weak.HasFlag(Element.Stone);
            chkMonsterWeakTime.Checked = Specs.Weak.HasFlag(Element.Time);
            chkMonsterWeakDeath.Checked = Specs.Weak.HasFlag(Element.Death);
            chkMonsterWeakFire.Checked = Specs.Weak.HasFlag(Element.Fire);
            chkMonsterWeakIce.Checked = Specs.Weak.HasFlag(Element.Ice);
            chkMonsterWeakLightning.Checked = Specs.Weak.HasFlag(Element.Lightning);
            chkMonsterWeakQuake.Checked = Specs.Weak.HasFlag(Element.Quake);
            chkMonsterWeakPoison.Checked = Specs.Weak.HasFlag(Element.Poison);
            chkMonsterWeakDarkness.Checked = Specs.Weak.HasFlag(Element.Darkness);
            chkMonsterWeakSleep.Checked = Specs.Weak.HasFlag(Element.Sleep);
            chkMonsterWeakSilence.Checked = Specs.Weak.HasFlag(Element.Silence);
            chkMonsterWeakConfusion.Checked = Specs.Weak.HasFlag(Element.Confuse);
            chkMonsterWeakMind.Checked = Specs.Weak.HasFlag(Element.Mind);

            //Attack Status
            chkMonsterAtkStDeath.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Death);
            chkMonsterAtkStStone.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Stone);
            chkMonsterAtkStPoison.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Poison);
            chkMonsterAtkStBlind.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Blind);
            chkMonsterAtkStStun.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Stun);
            chkMonsterAtkStSleep.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Sleep);
            chkMonsterAtkStSilence.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Silence);
            chkMonsterAtkStConfusion.Checked = Specs.AttackStatus.HasFlag(StatusEffect.Confusion);

            //Monster Family
            chkMonsterFamMagical.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Magical);
            chkMonsterFamDragon.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Dragon);
            chkMonsterFamGiant.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Giant);
            chkMonsterFamUndead.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Undead);
            chkMonsterFamWerebeast.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Werebeast);
            chkMonsterFamAquan.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Aquan);
            chkMonsterFamSpellcaster.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Spellcaster);
            chkMonsterFamRegenerative.Checked = Specs.MonsterFamily.HasFlag(MonsterFamily.Regenerative);

            //Begin populating the first two special bytes
            //chkMPDeath.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.MPDeath);

        }

        private void SaveMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;

            //Specs.Agility = (byte)numMonsterAgility.Value;

            //Write first two special bytes
            //if (chkMPDeath.Checked == true) Specs.FlagsA |= MonsterFlagsA.MPDeath; else Specs.FlagsA &= ~MonsterFlagsA.MPDeath;

            //Nullify
            //if (chkFireNull.Checked == true) Specs.Nullify |= Element.Fire; else Specs.Nullify &= ~Element.Fire;

            //Actual write code
            Specs.WriteMonsterNormal(Rom, RomData.MONSTER_DATA_OFFSET, MonsterIndexCheck);
        }

        /* private void UpdateSpells()
        {
            SpellIndex = cmbSpells.SelectedIndex * 14;
            Spells.ReadSpellData(Rom, RomData.SPELL_DATA, SpellIndex, SpellDelayIndex);
            SpellDelayIndex = cmbSpells.SelectedIndex * 1;

            //Targetting byte
            if (Spells.Targetting.HasFlag(SpellTargetting.MoveCursor) == true) chkLstSpellTargetting.SetItemChecked(0, true); else chkLstSpellTargetting.SetItemChecked(0, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.OneSide) == true) chkLstSpellTargetting.SetItemChecked(1, true); else chkLstSpellTargetting.SetItemChecked(1, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoBothParties) == true) chkLstSpellTargetting.SetItemChecked(2, true); else chkLstSpellTargetting.SetItemChecked(2, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoOneParty) == true) chkLstSpellTargetting.SetItemChecked(3, true); else chkLstSpellTargetting.SetItemChecked(3, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoConfirm) == true) chkLstSpellTargetting.SetItemChecked(4, true); else chkLstSpellTargetting.SetItemChecked(4, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.ToggleMulti) == true) chkLstSpellTargetting.SetItemChecked(5, true); else chkLstSpellTargetting.SetItemChecked(5, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.StartEnemy) == true) chkLstSpellTargetting.SetItemChecked(6, true); else chkLstSpellTargetting.SetItemChecked(6, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.RandomSelect) == true) chkLstSpellTargetting.SetItemChecked(7, true); else chkLstSpellTargetting.SetItemChecked(7, false);
            //Elemental properties
            if (Spells.ElementProps.HasFlag(SpellElement.Fire) == true) chkLstSpellElement.SetItemChecked(0, true); else chkLstSpellElement.SetItemChecked(0, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Ice) == true) chkLstSpellElement.SetItemChecked(1, true); else chkLstSpellElement.SetItemChecked(1, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Thunder) == true) chkLstSpellElement.SetItemChecked(2, true); else chkLstSpellElement.SetItemChecked(2, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Poison) == true) chkLstSpellElement.SetItemChecked(3, true); else chkLstSpellElement.SetItemChecked(3, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Wind) == true) chkLstSpellElement.SetItemChecked(4, true); else chkLstSpellElement.SetItemChecked(4, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Holy) == true) chkLstSpellElement.SetItemChecked(5, true); else chkLstSpellElement.SetItemChecked(5, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Earth) == true) chkLstSpellElement.SetItemChecked(6, true); else chkLstSpellElement.SetItemChecked(6, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Water) == true) chkLstSpellElement.SetItemChecked(7, true); else chkLstSpellElement.SetItemChecked(7, false);
            //Special 1
            if (Spells.Special1.HasFlag(SpellSpecial1.PhysDamage) == true) chkLstSpellSpecial1.SetItemChecked(0, true); else chkLstSpellSpecial1.SetItemChecked(0, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.MissDeathProt) == true) chkLstSpellSpecial1.SetItemChecked(1, true); else chkLstSpellSpecial1.SetItemChecked(1, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.TargetDead) == true) chkLstSpellSpecial1.SetItemChecked(2, true); else chkLstSpellSpecial1.SetItemChecked(2, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.InvertDamage) == true) chkLstSpellSpecial1.SetItemChecked(3, true); else chkLstSpellSpecial1.SetItemChecked(3, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.RandomTarget) == true) chkLstSpellSpecial1.SetItemChecked(4, true); else chkLstSpellSpecial1.SetItemChecked(4, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.IgnoreDefense) == true) chkLstSpellSpecial1.SetItemChecked(5, true); else chkLstSpellSpecial1.SetItemChecked(5, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.NoSplit) == true) chkLstSpellSpecial1.SetItemChecked(6, true); else chkLstSpellSpecial1.SetItemChecked(6, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.AbortAllies) == true) chkLstSpellSpecial1.SetItemChecked(7, true); else chkLstSpellSpecial1.SetItemChecked(7, false);
            //Misc
            if (Spells.Misc.HasFlag(SpellMisc.FieldUse) == true) chkLstSpellMisc.SetItemChecked(0, true); else chkLstSpellMisc.SetItemChecked(0, false);
            if (Spells.Misc.HasFlag(SpellMisc.NoReflect) == true) chkLstSpellMisc.SetItemChecked(1, true); else chkLstSpellMisc.SetItemChecked(1, false);
            if (Spells.Misc.HasFlag(SpellMisc.LearnIfTarget) == true) chkLstSpellMisc.SetItemChecked(2, true); else chkLstSpellMisc.SetItemChecked(2, false);
            if (Spells.Misc.HasFlag(SpellMisc.EnableRunic) == true) chkLstSpellMisc.SetItemChecked(3, true); else chkLstSpellMisc.SetItemChecked(3, false);
            if (Spells.Misc.HasFlag(SpellMisc.Unknown) == true) chkLstSpellMisc.SetItemChecked(4, true); else chkLstSpellMisc.SetItemChecked(4, false);
            if (Spells.Misc.HasFlag(SpellMisc.RetargetIfDead) == true) chkLstSpellMisc.SetItemChecked(5, true); else chkLstSpellMisc.SetItemChecked(5, false);
            if (Spells.Misc.HasFlag(SpellMisc.CasterDies) == true) chkLstSpellMisc.SetItemChecked(6, true); else chkLstSpellMisc.SetItemChecked(6, false);
            if (Spells.Misc.HasFlag(SpellMisc.AffectMP) == true) chkLstSpellMisc.SetItemChecked(7, true); else chkLstSpellMisc.SetItemChecked(7, false);
            //Special 2
            if (Spells.Special2.HasFlag(SpellSpecial2.Restore) == true) chkLstSpellSpecial2.SetItemChecked(0, true); else chkLstSpellSpecial2.SetItemChecked(0, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.Absorb) == true) chkLstSpellSpecial2.SetItemChecked(1, true); else chkLstSpellSpecial2.SetItemChecked(1, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.RemoveStatus) == true) chkLstSpellSpecial2.SetItemChecked(2, true); else chkLstSpellSpecial2.SetItemChecked(2, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.ToggleStatus) == true) chkLstSpellSpecial2.SetItemChecked(3, true); else chkLstSpellSpecial2.SetItemChecked(3, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.StaminaDefense) == true) chkLstSpellSpecial2.SetItemChecked(4, true); else chkLstSpellSpecial2.SetItemChecked(4, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.NoEvade) == true) chkLstSpellSpecial2.SetItemChecked(5, true); else chkLstSpellSpecial2.SetItemChecked(5, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.SuccessMult) == true) chkLstSpellSpecial2.SetItemChecked(6, true); else chkLstSpellSpecial2.SetItemChecked(6, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.Fractional) == true) chkLstSpellSpecial2.SetItemChecked(7, true); else chkLstSpellSpecial2.SetItemChecked(7, false);
            //MP Cost
            numMPCost.Value = Spells.MPCost;
            //Spell Power
            numSpellPower.Value = Spells.Power;
         
        } */

        /* private void SaveSpells()
        {
            SpellIndex = cmbSpells.SelectedIndex * 14;
            //Targetting
            if (chkLstSpellTargetting.GetItemChecked(0)) Spells.Targetting |= SpellTargetting.MoveCursor; else Spells.Targetting &= ~SpellTargetting.MoveCursor;
            if (chkLstSpellTargetting.GetItemChecked(1)) Spells.Targetting |= SpellTargetting.OneSide; else Spells.Targetting &= ~SpellTargetting.OneSide;
            if (chkLstSpellTargetting.GetItemChecked(2)) Spells.Targetting |= SpellTargetting.AutoBothParties; else Spells.Targetting &= ~SpellTargetting.AutoBothParties;
            if (chkLstSpellTargetting.GetItemChecked(3)) Spells.Targetting |= SpellTargetting.AutoOneParty; else Spells.Targetting &= ~SpellTargetting.AutoOneParty;
            if (chkLstSpellTargetting.GetItemChecked(4)) Spells.Targetting |= SpellTargetting.AutoConfirm; else Spells.Targetting &= ~SpellTargetting.AutoConfirm;
            if (chkLstSpellTargetting.GetItemChecked(5)) Spells.Targetting |= SpellTargetting.ToggleMulti; else Spells.Targetting &= ~SpellTargetting.ToggleMulti;
            if (chkLstSpellTargetting.GetItemChecked(6)) Spells.Targetting |= SpellTargetting.StartEnemy; else Spells.Targetting &= ~SpellTargetting.StartEnemy;
            if (chkLstSpellTargetting.GetItemChecked(7)) Spells.Targetting |= SpellTargetting.RandomSelect; else Spells.Targetting &= ~SpellTargetting.RandomSelect;
            //Elemental properties
            if (chkLstSpellElement.GetItemChecked(0)) Spells.ElementProps |= SpellElement.Fire; else Spells.ElementProps &= ~SpellElement.Fire;
            if (chkLstSpellElement.GetItemChecked(1)) Spells.ElementProps |= SpellElement.Ice; else Spells.ElementProps &= ~SpellElement.Ice;
            if (chkLstSpellElement.GetItemChecked(2)) Spells.ElementProps |= SpellElement.Thunder; else Spells.ElementProps &= ~SpellElement.Thunder;
            if (chkLstSpellElement.GetItemChecked(3)) Spells.ElementProps |= SpellElement.Poison; else Spells.ElementProps &= ~SpellElement.Poison;
            if (chkLstSpellElement.GetItemChecked(4)) Spells.ElementProps |= SpellElement.Wind; else Spells.ElementProps &= ~SpellElement.Wind;
            if (chkLstSpellElement.GetItemChecked(5)) Spells.ElementProps |= SpellElement.Holy; else Spells.ElementProps &= ~SpellElement.Holy;
            if (chkLstSpellElement.GetItemChecked(6)) Spells.ElementProps |= SpellElement.Earth; else Spells.ElementProps &= ~SpellElement.Earth;
            if (chkLstSpellElement.GetItemChecked(7)) Spells.ElementProps |= SpellElement.Water; else Spells.ElementProps &= ~SpellElement.Water;
            //Special 1
            if (chkLstSpellSpecial1.GetItemChecked(0)) Spells.Special1 |= SpellSpecial1.PhysDamage; else Spells.Special1 &= ~SpellSpecial1.PhysDamage;
            if (chkLstSpellSpecial1.GetItemChecked(1)) Spells.Special1 |= SpellSpecial1.MissDeathProt; else Spells.Special1 &= ~SpellSpecial1.MissDeathProt;
            if (chkLstSpellSpecial1.GetItemChecked(2)) Spells.Special1 |= SpellSpecial1.TargetDead; else Spells.Special1 &= ~SpellSpecial1.TargetDead;
            if (chkLstSpellSpecial1.GetItemChecked(3)) Spells.Special1 |= SpellSpecial1.InvertDamage; else Spells.Special1 &= ~SpellSpecial1.InvertDamage;
            if (chkLstSpellSpecial1.GetItemChecked(4)) Spells.Special1 |= SpellSpecial1.RandomTarget; else Spells.Special1 &= ~SpellSpecial1.RandomTarget;
            if (chkLstSpellSpecial1.GetItemChecked(5)) Spells.Special1 |= SpellSpecial1.IgnoreDefense; else Spells.Special1 &= ~SpellSpecial1.IgnoreDefense;
            if (chkLstSpellSpecial1.GetItemChecked(6)) Spells.Special1 |= SpellSpecial1.NoSplit; else Spells.Special1 &= ~SpellSpecial1.NoSplit;
            if (chkLstSpellSpecial1.GetItemChecked(7)) Spells.Special1 |= SpellSpecial1.AbortAllies; else Spells.Special1 &= ~SpellSpecial1.AbortAllies;
            //MP Cost
            Spells.MPCost = (byte)numMPCost.Value;
            //Spell Power
            Spells.Power = (byte)numSpellPower.Value;
            //Special 3
            if (chkLstSpellSpecial3.GetItemChecked(0)) Spells.Special3 |= SpellSpecial3.MissProtStatus; else Spells.Special3 &= ~SpellSpecial3.MissProtStatus;
            if (chkLstSpellSpecial3.GetItemChecked(1)) Spells.Special3 |= SpellSpecial3.TextIfHits; else Spells.Special3 &= ~SpellSpecial3.TextIfHits;
            if (chkLstSpellSpecial3.GetItemChecked(2)) Spells.Special3 |= SpellSpecial3.ReplaceWithVitality; else Spells.Special3 &= ~SpellSpecial3.ReplaceWithVitality;
            if (chkLstSpellSpecial3.GetItemChecked(3)) Spells.Special3 |= SpellSpecial3.UnknownA; else Spells.Special3 &= ~SpellSpecial3.UnknownA;
            if (chkLstSpellSpecial3.GetItemChecked(4)) Spells.Special3 |= SpellSpecial3.UnknownB; else Spells.Special3 &= ~SpellSpecial3.UnknownB;
            if (chkLstSpellSpecial3.GetItemChecked(5)) Spells.Special3 |= SpellSpecial3.UnknownC; else Spells.Special3 &= ~SpellSpecial3.UnknownC;
            if (chkLstSpellSpecial3.GetItemChecked(6)) Spells.Special3 |= SpellSpecial3.UnknownD; else Spells.Special3 &= ~SpellSpecial3.UnknownD;
            if (chkLstSpellSpecial3.GetItemChecked(7)) Spells.Special3 |= SpellSpecial3.HalfITD; else Spells.Special3 &= ~SpellSpecial3.HalfITD;
            //Success Rate
            Spells.Success = (byte)numSuccessRate.Value;
            //TODO: Special Effects
            //Status toggles
            //1
            if (chkLstSpellStatus1.GetItemChecked(0)) Spells.Status |= SpellStatus.Darkness; else Spells.Status &= ~SpellStatus.Darkness;
            if (chkLstSpellStatus1.GetItemChecked(1)) Spells.Status |= SpellStatus.Zombie; else Spells.Status &= ~SpellStatus.Zombie;
            if (chkLstSpellStatus1.GetItemChecked(2)) Spells.Status |= SpellStatus.Poison; else Spells.Status &= ~SpellStatus.Poison;
            if (chkLstSpellStatus1.GetItemChecked(3)) Spells.Status |= SpellStatus.Magitek; else Spells.Status &= ~SpellStatus.Magitek;
            if (chkLstSpellStatus1.GetItemChecked(4)) Spells.Status |= SpellStatus.Clear; else Spells.Status &= ~SpellStatus.Clear;
            if (chkLstSpellStatus1.GetItemChecked(5)) Spells.Status |= SpellStatus.Imp; else Spells.Status &= ~SpellStatus.Imp;
            if (chkLstSpellStatus1.GetItemChecked(6)) Spells.Status |= SpellStatus.Petrify; else Spells.Status &= ~SpellStatus.Petrify;
            if (chkLstSpellStatus1.GetItemChecked(7)) Spells.Status |= SpellStatus.Death; else Spells.Status &= ~SpellStatus.Death;
            //2
            if (chkLstSpellStatus2.GetItemChecked(0)) Spells.Status |= SpellStatus.Doomed; else Spells.Status &= ~SpellStatus.Doomed;
            if (chkLstSpellStatus2.GetItemChecked(1)) Spells.Status |= SpellStatus.Critical; else Spells.Status &= ~SpellStatus.Critical;
            if (chkLstSpellStatus2.GetItemChecked(2)) Spells.Status |= SpellStatus.Blink; else Spells.Status &= ~SpellStatus.Blink;
            if (chkLstSpellStatus2.GetItemChecked(3)) Spells.Status |= SpellStatus.Silence; else Spells.Status &= ~SpellStatus.Silence;
            if (chkLstSpellStatus2.GetItemChecked(4)) Spells.Status |= SpellStatus.Berserk; else Spells.Status &= ~SpellStatus.Berserk;
            if (chkLstSpellStatus2.GetItemChecked(5)) Spells.Status |= SpellStatus.Confuse; else Spells.Status &= ~SpellStatus.Confuse;
            if (chkLstSpellStatus2.GetItemChecked(6)) Spells.Status |= SpellStatus.Sap; else Spells.Status &= ~SpellStatus.Sap;
            if (chkLstSpellStatus2.GetItemChecked(7)) Spells.Status |= SpellStatus.Sleep; else Spells.Status &= ~SpellStatus.Sleep;
            //3
            if (chkLstSpellStatus3.GetItemChecked(0)) Spells.Status |= SpellStatus.Dance; else Spells.Status &= ~SpellStatus.Dance;
            if (chkLstSpellStatus3.GetItemChecked(1)) Spells.Status |= SpellStatus.Regen; else Spells.Status &= ~SpellStatus.Regen;
            if (chkLstSpellStatus3.GetItemChecked(2)) Spells.Status |= SpellStatus.Slow; else Spells.Status &= ~SpellStatus.Slow;
            if (chkLstSpellStatus3.GetItemChecked(3)) Spells.Status |= SpellStatus.Haste; else Spells.Status &= ~SpellStatus.Haste;
            if (chkLstSpellStatus3.GetItemChecked(4)) Spells.Status |= SpellStatus.Stop; else Spells.Status &= ~SpellStatus.Stop;
            if (chkLstSpellStatus3.GetItemChecked(5)) Spells.Status |= SpellStatus.Shell; else Spells.Status &= ~SpellStatus.Shell;
            if (chkLstSpellStatus3.GetItemChecked(6)) Spells.Status |= SpellStatus.Protect; else Spells.Status &= ~SpellStatus.Protect;
            if (chkLstSpellStatus3.GetItemChecked(7)) Spells.Status |= SpellStatus.Reflect; else Spells.Status &= ~SpellStatus.Reflect;
            //4
            if (chkLstSpellStatus4.GetItemChecked(0)) Spells.Status |= SpellStatus.Rage; else Spells.Status &= ~SpellStatus.Rage;
            if (chkLstSpellStatus4.GetItemChecked(1)) Spells.Status |= SpellStatus.Freeze; else Spells.Status &= ~SpellStatus.Freeze;
            if (chkLstSpellStatus4.GetItemChecked(2)) Spells.Status |= SpellStatus.Reraise; else Spells.Status &= ~SpellStatus.Reraise;
            if (chkLstSpellStatus4.GetItemChecked(3)) Spells.Status |= SpellStatus.Trance; else Spells.Status &= ~SpellStatus.Trance;
            if (chkLstSpellStatus4.GetItemChecked(4)) Spells.Status |= SpellStatus.Chanting; else Spells.Status &= ~SpellStatus.Chanting;
            if (chkLstSpellStatus4.GetItemChecked(5)) Spells.Status |= SpellStatus.Disappear; else Spells.Status &= ~SpellStatus.Disappear;
            if (chkLstSpellStatus4.GetItemChecked(6)) Spells.Status |= SpellStatus.DogBlock; else Spells.Status &= ~SpellStatus.DogBlock;
            if (chkLstSpellStatus4.GetItemChecked(7)) Spells.Status |= SpellStatus.Float; else Spells.Status &= ~SpellStatus.Float;
            Spells.WriteSpellData(Rom, RomData.SPELL_DATA, SpellIndex);
        } */

        private int SumOfStatValues(int FileOffset, int CalcValue)
        {
            statSum = 0;
            for (int i = 0; i < CalcValue; i++)
            {
                statSum += Rom.Read8(FileOffset + i);
            }
            return statSum;
        }

        private bool CheckRomIntegrity()
        {
            byte integrity_check_value = 0x0e;
            int integrity_check;
            integrity_check = Rom.Read8(integrity_check_value);
            if (integrity_check != 234)
            {
                return false;
            }
            else return true;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Removes gameArray data and closes editor.
            Rom.Close();
            Application.Exit();
        }

        private void CmbMonsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            numMonsterIndex.Value = cmbMonsters.SelectedIndex;
            UpdateMonsterStats();
        }

        private void CmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMonsterStats();
        }

        private void NumMonsterIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numMonsterIndex.Value <= 195)
            {
                int i;
                i = (int)numMonsterIndex.Value;
                cmbMonsters.SelectedIndex = i;
            }
            else numMonsterIndex.Value = 195;
            UpdateMonsterStats();
        }

        private void BtnMonstersOkay_Click(object sender, EventArgs e)
        {
            SaveMonsterStats();
        }

        private void BtnMonstersCancel_Click(object sender, EventArgs e)
        {
            UpdateMonsterStats();
        }

        private void CmbSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            //numSpellIndex.Value = cmbSpells.SelectedIndex;
            //UpdateSpells();
        }

        private void NumSpellIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numSpellIndex.Value <= 255)
            {
                int i;
                i = (int)numSpellIndex.Value;
                cmbSpells.SelectedIndex = i;
            }
            else numSpellIndex.Value = 255;
            //UpdateSpells();

        }

        private void BtnSpellsOkay_Click(object sender, EventArgs e)
        {
            //SaveSpells();
        }

        private void BtnSpellsCancel_Click(object sender, EventArgs e)
        {
            //UpdateSpells();
        }


        private void cmbMonsterItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMonsterItemType.SelectedIndex)
            {
                case 1:
                    cmbMonsterItemDrop.Visible = true;
                    cmbMonsterItemDrop.Items.Clear();
                    cmbMonsterItemDrop.Items.AddRange(new object[]
                    {
                        "Nothing","Potion","Hi-Potion","X-Potion","Ether","Turbo Ether","Dry Ether","Elixir","Megalixir","Phoenix Down","Remedy","Antidote","Gold Needle","Eye Drops",
                        "Echo Grass","Emergency Exit","Sleeping Bag","Tent","Cottage","Spider's Silk","White Fang","Red Fang","Blue Fang","Light Curtain","Red Curtain","White Curtain",
                        "Blue Curtain","Lunar Curtain","Hermes's Shoes","Vampire Fang","Cockatrice Claw","Giant's Tonic","Faerie Tonic","Strength Tonic","Protect Drink","Speed Drink",
                        "Golden Apple","Silver Apple","Soma Drop","Power Plus","Stamina Plus","Mind Plus","Speed Plus","Luck Plus" });
                    cmbMonsterItemDrop.SelectedIndex = Specs.ItemDropped;
                    break;
                case 2:
                    cmbMonsterItemDrop.Visible = true;
                    cmbMonsterItemDrop.Items.Clear();
                    cmbMonsterItemDrop.Items.AddRange(new object[]
                    {
                        "Nothing","Nunchaku","Knife","Staff","Rapier","Hammer","Broadsword","Battle Axe","Scimitar","Iron Nunchaku","Dagger","Crosier","Saber","Longsword","Great Axe",
                        "Falchion","Mythril Knife","Mythril Sword","Mythril Hammer","Mythril Axe","Flame Sword","Ice Brand","Wyrmkiller","Great Sword","Sun Sword","Coral Sword","Werebuster",
                        "Rune Blade","Power Staff","Light Axe","Healing Staff","Mage's Staff","Defender","Wizard's Staff","Vorpal Sword","Cat Claws","Thor's Hammer","Razer","Sasuke's Katana",
                        "Excalibur","Masamune","Ultima Weapon","Ragnarok","Murasame","Lightbringer","Rune Staff","Judgement Staff","Dark Claymore","Duel Rapier","Braveheart","Deathbringer",
                        "Enhancer","Gigant Axe","Viking Axe","Rune Axe","Ogrekiller","Kikuichimonji","Ashura","Kotetsu","War Hammer","Assassin Dagger","Orichalcum","Mage Masher","Gladius",
                        "Sage's Staff"});
                    cmbMonsterItemDrop.SelectedIndex = Specs.ItemDropped;
                    break;
                case 3:
                    cmbMonsterItemDrop.Visible = true;
                    cmbMonsterItemDrop.Items.Clear();
                    cmbMonsterItemDrop.Items.AddRange(new object[]
                    {
                        "Nothing","Robe","Leather Armor","Chain Mail","Iron Armor","Knight's Armor","Mythril Mail","Flame Mail","Ice Armor","Diamond Armor","Dragon Mail","Copper Armlet",
                        "Silver Armlet","Ruby Armlet","Diamond Armlet","White Robe","Black Robe","Crystal Mail","Thief Armlet","Black Garb","Kenpogi","Power Vest","Red Jacket",
                        "Sage's Surplice","Light Robe","Gaia Gear","Bard's Tunic","Genji Armor","Leather Shield","Iron Shield","Mythril Shield","Flame Shield","Ice Shield","Diamond Shield",
                        "Aegis Shield","Buckler","Protect Cloak","Genji Shield","Crystal Shield","Hero's Shield","Zephyr Cape","Elven Cloak","Leather Cap","Helm","Great Helm","Mythril Helm",
                        "Diamond Helm","Healing Helm","Ribbon","Genji Helm","Crystal Helm","Black Cowl","Twist Headband","Tiger Mask","Feathered Cap","Red Cap","Wizard's Hat","Sage's Mitre",
                        "Leather Gloves","Bronze Gloves","Steel Gloves","Mythril Gloves","Gauntlets","Giant's Gloves","Diamond Gloves","Protect Ring","Crystal Gloves","Thief's Gloves",
                        "Crystal Ring","Angel Ring","Genji Gloves"});
                    cmbMonsterItemDrop.SelectedIndex = Specs.ItemDropped;
                    break;
                default:
                    cmbMonsterItemDrop.Visible = false;
                    cmbMonsterItemDrop.Items.Clear();
                    cmbMonsterItemDrop.Items.AddRange(new object[]
                    {
                        "Nothing"
                    });
                    cmbMonsterItemDrop.SelectedIndex = 0;
                    break;
            }
        }

        private void numJobIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numJobsIndex.Value <= 11)
            {
                int i;
                i = (int)numJobsIndex.Value;
                cmbJobs.SelectedIndex = i;
            }
            else numJobsIndex.Value = 11;
            //UpdateJobs();
        }

        private void cmbJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            numJobsIndex.Value = cmbJobs.SelectedIndex;
            //UpdateJobs();
        }

        //private void displayspellnames()
        //{
        //    string[] spellcoll = spelllist.readspellnames(rom).toarray();
        //    cmbspells.items.addrange(spellcoll);
        //    cmbspells.selectedindex = 0;
        //    spelllist.readspellnames(rom).foreach (el => cmbspells.items.addrange(spelllist.readspellnames(rom).toarray())) ;
        //}
    }
}
