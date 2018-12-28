namespace FF1_DOS_editor
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveROMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabConsumables = new System.Windows.Forms.TabPage();
            this.tabSpells = new System.Windows.Forms.TabPage();
            this.btnSpellsCancel = new System.Windows.Forms.Button();
            this.btnSpellsOkay = new System.Windows.Forms.Button();
            this.numSpellIndex = new System.Windows.Forms.NumericUpDown();
            this.cmbSpells = new System.Windows.Forms.ComboBox();
            this.tabJobs = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numJobsIndex = new System.Windows.Forms.NumericUpDown();
            this.cmbJobs = new System.Windows.Forms.ComboBox();
            this.btnActorsCancel = new System.Windows.Forms.Button();
            this.btnActorsOkay = new System.Windows.Forms.Button();
            this.TabBar = new System.Windows.Forms.TabControl();
            this.tabEnemies = new System.Windows.Forms.TabPage();
            this.grpMonsterAttacks = new System.Windows.Forms.GroupBox();
            this.lblMonsterSpell = new System.Windows.Forms.Label();
            this.lblMonsterAbility = new System.Windows.Forms.Label();
            this.cmbMonsterAbility4 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterAbility3 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterAbility2 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterAbility1 = new System.Windows.Forms.ComboBox();
            this.numMonsterAbilityQueue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMonsterMagicQueue = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterMagicQueue = new System.Windows.Forms.Label();
            this.cmbMonsterSpell8 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell7 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell6 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell5 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell4 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell3 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell2 = new System.Windows.Forms.ComboBox();
            this.cmbMonsterSpell1 = new System.Windows.Forms.ComboBox();
            this.grpItemDrops = new System.Windows.Forms.GroupBox();
            this.cmbMonsterItemDrop = new System.Windows.Forms.ComboBox();
            this.lblDropChance = new System.Windows.Forms.Label();
            this.numDropChance = new System.Windows.Forms.NumericUpDown();
            this.lblDropType = new System.Windows.Forms.Label();
            this.cmbMonsterItemType = new System.Windows.Forms.ComboBox();
            this.grpMonsterFamily = new System.Windows.Forms.GroupBox();
            this.chkMonsterFamMagical = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamRegenerative = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamDragon = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamGiant = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamSpellcaster = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamUndead = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamWerebeast = new System.Windows.Forms.CheckBox();
            this.chkMonsterFamAquan = new System.Windows.Forms.CheckBox();
            this.grpMonsterWeakElements = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkMonsterWeakMind = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakConfusion = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakSilence = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakSleep = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakDarkness = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakPoison = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakQuake = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakLightning = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakIce = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakFire = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakDeath = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakTime = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakStone = new System.Windows.Forms.CheckBox();
            this.chkMonsterWeakParalysis = new System.Windows.Forms.CheckBox();
            this.grpMonsterResistElements = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMonsterResistMind = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistConfusion = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistSilence = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistSleep = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistDarkness = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistPoison = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistQuake = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistLightning = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistIce = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistFire = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistDeath = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistTime = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistStone = new System.Windows.Forms.CheckBox();
            this.chkMonsterResistParalysis = new System.Windows.Forms.CheckBox();
            this.grpAttackStatus = new System.Windows.Forms.GroupBox();
            this.chkMonsterAtkStDeath = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStConfusion = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStStone = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStPoison = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStSilence = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStBlind = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStStun = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStSleep = new System.Windows.Forms.CheckBox();
            this.grpMonsterAttackElements = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMonsterAtkMind = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkConfusion = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkSilence = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkSleep = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkDarkness = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkPoison = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkQuake = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkLightning = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkIce = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkFire = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkDeath = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkTime = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkStone = new System.Windows.Forms.CheckBox();
            this.chkMonsterAtkParalysis = new System.Windows.Forms.CheckBox();
            this.numMonsterMagDef = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterMagDef = new System.Windows.Forms.Label();
            this.numMonsterCritRate = new System.Windows.Forms.NumericUpDown();
            this.numMonsterAgility = new System.Windows.Forms.NumericUpDown();
            this.numMonsterIntellect = new System.Windows.Forms.NumericUpDown();
            this.numMonsterAttack = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterCritRate = new System.Windows.Forms.Label();
            this.lblMonsterIntellect = new System.Windows.Forms.Label();
            this.lblMonsterAgility = new System.Windows.Forms.Label();
            this.lblMonsterAttack = new System.Windows.Forms.Label();
            this.numMonsterAccuracy = new System.Windows.Forms.NumericUpDown();
            this.numMonsterDefense = new System.Windows.Forms.NumericUpDown();
            this.numMonsterNumHits = new System.Windows.Forms.NumericUpDown();
            this.numMonsterEvasion = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterAccuracy = new System.Windows.Forms.Label();
            this.lblMonsterNumHits = new System.Windows.Forms.Label();
            this.lblMonsterDefense = new System.Windows.Forms.Label();
            this.lblMonsterEvasion = new System.Windows.Forms.Label();
            this.numMonsterMorale = new System.Windows.Forms.NumericUpDown();
            this.lblMonsterMorale = new System.Windows.Forms.Label();
            this.numMonsterIndex = new System.Windows.Forms.NumericUpDown();
            this.numMonsterEXP = new System.Windows.Forms.NumericUpDown();
            this.numMonsterGil = new System.Windows.Forms.NumericUpDown();
            this.numMonsterHP = new System.Windows.Forms.NumericUpDown();
            this.btnMonstersCancel = new System.Windows.Forms.Button();
            this.btnMonstersOkay = new System.Windows.Forms.Button();
            this.lblMonsterGil = new System.Windows.Forms.Label();
            this.lblMonsterEXP = new System.Windows.Forms.Label();
            this.lblMonsterHP = new System.Windows.Forms.Label();
            this.cmbMonsters = new System.Windows.Forms.ComboBox();
            this.tabArmor = new System.Windows.Forms.TabPage();
            this.tabWeapons = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabSpells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpellIndex)).BeginInit();
            this.tabJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJobsIndex)).BeginInit();
            this.TabBar.SuspendLayout();
            this.tabEnemies.SuspendLayout();
            this.grpMonsterAttacks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAbilityQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMagicQueue)).BeginInit();
            this.grpItemDrops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDropChance)).BeginInit();
            this.grpMonsterFamily.SuspendLayout();
            this.grpMonsterWeakElements.SuspendLayout();
            this.grpMonsterResistElements.SuspendLayout();
            this.grpAttackStatus.SuspendLayout();
            this.grpMonsterAttackElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMagDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterCritRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterIntellect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAccuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterDefense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterNumHits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterEvasion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMorale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterEXP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterGil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterHP)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadROMToolStripMenuItem,
            this.saveROMToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadROMToolStripMenuItem
            // 
            this.loadROMToolStripMenuItem.Name = "loadROMToolStripMenuItem";
            this.loadROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadROMToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadROMToolStripMenuItem.Text = "Load";
            this.loadROMToolStripMenuItem.Click += new System.EventHandler(this.LoadROMToolStripMenuItem_Click);
            // 
            // saveROMToolStripMenuItem1
            // 
            this.saveROMToolStripMenuItem1.Name = "saveROMToolStripMenuItem1";
            this.saveROMToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.saveROMToolStripMenuItem1.Text = "Save";
            this.saveROMToolStripMenuItem1.Click += new System.EventHandler(this.SaveROMToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveROMToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // tabConsumables
            // 
            this.tabConsumables.Location = new System.Drawing.Point(4, 23);
            this.tabConsumables.Name = "tabConsumables";
            this.tabConsumables.Size = new System.Drawing.Size(836, 527);
            this.tabConsumables.TabIndex = 4;
            this.tabConsumables.Text = "Consumables";
            this.tabConsumables.UseVisualStyleBackColor = true;
            // 
            // tabSpells
            // 
            this.tabSpells.Controls.Add(this.btnSpellsCancel);
            this.tabSpells.Controls.Add(this.btnSpellsOkay);
            this.tabSpells.Controls.Add(this.numSpellIndex);
            this.tabSpells.Controls.Add(this.cmbSpells);
            this.tabSpells.Location = new System.Drawing.Point(4, 23);
            this.tabSpells.Name = "tabSpells";
            this.tabSpells.Size = new System.Drawing.Size(836, 527);
            this.tabSpells.TabIndex = 3;
            this.tabSpells.Text = "Spells";
            this.tabSpells.UseVisualStyleBackColor = true;
            // 
            // btnSpellsCancel
            // 
            this.btnSpellsCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSpellsCancel.Location = new System.Drawing.Point(1032, 544);
            this.btnSpellsCancel.Name = "btnSpellsCancel";
            this.btnSpellsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSpellsCancel.TabIndex = 142;
            this.btnSpellsCancel.Text = "Cancel";
            this.btnSpellsCancel.UseVisualStyleBackColor = false;
            this.btnSpellsCancel.Click += new System.EventHandler(this.BtnSpellsCancel_Click);
            // 
            // btnSpellsOkay
            // 
            this.btnSpellsOkay.Location = new System.Drawing.Point(951, 544);
            this.btnSpellsOkay.Name = "btnSpellsOkay";
            this.btnSpellsOkay.Size = new System.Drawing.Size(75, 23);
            this.btnSpellsOkay.TabIndex = 141;
            this.btnSpellsOkay.Text = "Okay";
            this.btnSpellsOkay.UseVisualStyleBackColor = true;
            this.btnSpellsOkay.Click += new System.EventHandler(this.BtnSpellsOkay_Click);
            // 
            // numSpellIndex
            // 
            this.numSpellIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpellIndex.Location = new System.Drawing.Point(150, 6);
            this.numSpellIndex.Maximum = new decimal(new int[] {
            383,
            0,
            0,
            0});
            this.numSpellIndex.Name = "numSpellIndex";
            this.numSpellIndex.Size = new System.Drawing.Size(51, 27);
            this.numSpellIndex.TabIndex = 140;
            this.numSpellIndex.ValueChanged += new System.EventHandler(this.NumSpellIndex_ValueChanged);
            // 
            // cmbSpells
            // 
            this.cmbSpells.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSpells.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSpells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpells.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpells.FormattingEnabled = true;
            this.cmbSpells.Location = new System.Drawing.Point(6, 6);
            this.cmbSpells.MaxLength = 20;
            this.cmbSpells.Name = "cmbSpells";
            this.cmbSpells.Size = new System.Drawing.Size(138, 27);
            this.cmbSpells.TabIndex = 139;
            this.cmbSpells.SelectedIndexChanged += new System.EventHandler(this.CmbSpells_SelectedIndexChanged);
            // 
            // tabJobs
            // 
            this.tabJobs.Controls.Add(this.button1);
            this.tabJobs.Controls.Add(this.button2);
            this.tabJobs.Controls.Add(this.numJobsIndex);
            this.tabJobs.Controls.Add(this.cmbJobs);
            this.tabJobs.Controls.Add(this.btnActorsCancel);
            this.tabJobs.Controls.Add(this.btnActorsOkay);
            this.tabJobs.Location = new System.Drawing.Point(4, 23);
            this.tabJobs.Name = "tabJobs";
            this.tabJobs.Padding = new System.Windows.Forms.Padding(3);
            this.tabJobs.Size = new System.Drawing.Size(836, 527);
            this.tabJobs.TabIndex = 0;
            this.tabJobs.Text = "Jobs";
            this.tabJobs.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(755, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 144;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(674, 498);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 143;
            this.button2.Text = "Okay";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numJobsIndex
            // 
            this.numJobsIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numJobsIndex.Location = new System.Drawing.Point(150, 6);
            this.numJobsIndex.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numJobsIndex.Name = "numJobsIndex";
            this.numJobsIndex.Size = new System.Drawing.Size(51, 27);
            this.numJobsIndex.TabIndex = 142;
            this.numJobsIndex.ValueChanged += new System.EventHandler(this.numJobIndex_ValueChanged);
            // 
            // cmbJobs
            // 
            this.cmbJobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbJobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.Location = new System.Drawing.Point(6, 6);
            this.cmbJobs.MaxLength = 20;
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.Size = new System.Drawing.Size(138, 27);
            this.cmbJobs.TabIndex = 141;
            this.cmbJobs.SelectedIndexChanged += new System.EventHandler(this.cmbJobs_SelectedIndexChanged);
            // 
            // btnActorsCancel
            // 
            this.btnActorsCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnActorsCancel.Location = new System.Drawing.Point(1032, 544);
            this.btnActorsCancel.Name = "btnActorsCancel";
            this.btnActorsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnActorsCancel.TabIndex = 95;
            this.btnActorsCancel.Text = "Cancel";
            this.btnActorsCancel.UseVisualStyleBackColor = false;
            // 
            // btnActorsOkay
            // 
            this.btnActorsOkay.Location = new System.Drawing.Point(951, 544);
            this.btnActorsOkay.Name = "btnActorsOkay";
            this.btnActorsOkay.Size = new System.Drawing.Size(75, 23);
            this.btnActorsOkay.TabIndex = 94;
            this.btnActorsOkay.Text = "Okay";
            this.btnActorsOkay.UseVisualStyleBackColor = true;
            // 
            // TabBar
            // 
            this.TabBar.AccessibleName = "";
            this.TabBar.Controls.Add(this.tabJobs);
            this.TabBar.Controls.Add(this.tabEnemies);
            this.TabBar.Controls.Add(this.tabSpells);
            this.TabBar.Controls.Add(this.tabConsumables);
            this.TabBar.Controls.Add(this.tabArmor);
            this.TabBar.Controls.Add(this.tabWeapons);
            this.TabBar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabBar.Location = new System.Drawing.Point(12, 27);
            this.TabBar.Name = "TabBar";
            this.TabBar.SelectedIndex = 0;
            this.TabBar.Size = new System.Drawing.Size(844, 554);
            this.TabBar.TabIndex = 2;
            // 
            // tabEnemies
            // 
            this.tabEnemies.Controls.Add(this.grpMonsterAttacks);
            this.tabEnemies.Controls.Add(this.grpItemDrops);
            this.tabEnemies.Controls.Add(this.grpMonsterFamily);
            this.tabEnemies.Controls.Add(this.grpMonsterWeakElements);
            this.tabEnemies.Controls.Add(this.grpMonsterResistElements);
            this.tabEnemies.Controls.Add(this.grpAttackStatus);
            this.tabEnemies.Controls.Add(this.grpMonsterAttackElements);
            this.tabEnemies.Controls.Add(this.numMonsterMagDef);
            this.tabEnemies.Controls.Add(this.lblMonsterMagDef);
            this.tabEnemies.Controls.Add(this.numMonsterCritRate);
            this.tabEnemies.Controls.Add(this.numMonsterAgility);
            this.tabEnemies.Controls.Add(this.numMonsterIntellect);
            this.tabEnemies.Controls.Add(this.numMonsterAttack);
            this.tabEnemies.Controls.Add(this.lblMonsterCritRate);
            this.tabEnemies.Controls.Add(this.lblMonsterIntellect);
            this.tabEnemies.Controls.Add(this.lblMonsterAgility);
            this.tabEnemies.Controls.Add(this.lblMonsterAttack);
            this.tabEnemies.Controls.Add(this.numMonsterAccuracy);
            this.tabEnemies.Controls.Add(this.numMonsterDefense);
            this.tabEnemies.Controls.Add(this.numMonsterNumHits);
            this.tabEnemies.Controls.Add(this.numMonsterEvasion);
            this.tabEnemies.Controls.Add(this.lblMonsterAccuracy);
            this.tabEnemies.Controls.Add(this.lblMonsterNumHits);
            this.tabEnemies.Controls.Add(this.lblMonsterDefense);
            this.tabEnemies.Controls.Add(this.lblMonsterEvasion);
            this.tabEnemies.Controls.Add(this.numMonsterMorale);
            this.tabEnemies.Controls.Add(this.lblMonsterMorale);
            this.tabEnemies.Controls.Add(this.numMonsterIndex);
            this.tabEnemies.Controls.Add(this.numMonsterEXP);
            this.tabEnemies.Controls.Add(this.numMonsterGil);
            this.tabEnemies.Controls.Add(this.numMonsterHP);
            this.tabEnemies.Controls.Add(this.btnMonstersCancel);
            this.tabEnemies.Controls.Add(this.btnMonstersOkay);
            this.tabEnemies.Controls.Add(this.lblMonsterGil);
            this.tabEnemies.Controls.Add(this.lblMonsterEXP);
            this.tabEnemies.Controls.Add(this.lblMonsterHP);
            this.tabEnemies.Controls.Add(this.cmbMonsters);
            this.tabEnemies.Location = new System.Drawing.Point(4, 23);
            this.tabEnemies.Name = "tabEnemies";
            this.tabEnemies.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnemies.Size = new System.Drawing.Size(836, 527);
            this.tabEnemies.TabIndex = 2;
            this.tabEnemies.Text = "Enemies";
            this.tabEnemies.UseVisualStyleBackColor = true;
            // 
            // grpMonsterAttacks
            // 
            this.grpMonsterAttacks.Controls.Add(this.lblMonsterSpell);
            this.grpMonsterAttacks.Controls.Add(this.lblMonsterAbility);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterAbility4);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterAbility3);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterAbility2);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterAbility1);
            this.grpMonsterAttacks.Controls.Add(this.numMonsterAbilityQueue);
            this.grpMonsterAttacks.Controls.Add(this.label1);
            this.grpMonsterAttacks.Controls.Add(this.numMonsterMagicQueue);
            this.grpMonsterAttacks.Controls.Add(this.lblMonsterMagicQueue);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell8);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell7);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell6);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell5);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell4);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell3);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell2);
            this.grpMonsterAttacks.Controls.Add(this.cmbMonsterSpell1);
            this.grpMonsterAttacks.Location = new System.Drawing.Point(207, 281);
            this.grpMonsterAttacks.Name = "grpMonsterAttacks";
            this.grpMonsterAttacks.Size = new System.Drawing.Size(619, 204);
            this.grpMonsterAttacks.TabIndex = 63;
            this.grpMonsterAttacks.TabStop = false;
            this.grpMonsterAttacks.Text = "Attack Order";
            // 
            // lblMonsterSpell
            // 
            this.lblMonsterSpell.AutoSize = true;
            this.lblMonsterSpell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterSpell.Location = new System.Drawing.Point(70, 68);
            this.lblMonsterSpell.Name = "lblMonsterSpell";
            this.lblMonsterSpell.Size = new System.Drawing.Size(42, 19);
            this.lblMonsterSpell.TabIndex = 64;
            this.lblMonsterSpell.Text = "/200";
            // 
            // lblMonsterAbility
            // 
            this.lblMonsterAbility.AutoSize = true;
            this.lblMonsterAbility.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterAbility.Location = new System.Drawing.Point(440, 68);
            this.lblMonsterAbility.Name = "lblMonsterAbility";
            this.lblMonsterAbility.Size = new System.Drawing.Size(42, 19);
            this.lblMonsterAbility.TabIndex = 65;
            this.lblMonsterAbility.Text = "/128";
            // 
            // cmbMonsterAbility4
            // 
            this.cmbMonsterAbility4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterAbility4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterAbility4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterAbility4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterAbility4.FormattingEnabled = true;
            this.cmbMonsterAbility4.Location = new System.Drawing.Point(491, 130);
            this.cmbMonsterAbility4.Name = "cmbMonsterAbility4";
            this.cmbMonsterAbility4.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterAbility4.TabIndex = 78;
            // 
            // cmbMonsterAbility3
            // 
            this.cmbMonsterAbility3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterAbility3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterAbility3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterAbility3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterAbility3.FormattingEnabled = true;
            this.cmbMonsterAbility3.Location = new System.Drawing.Point(491, 97);
            this.cmbMonsterAbility3.Name = "cmbMonsterAbility3";
            this.cmbMonsterAbility3.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterAbility3.TabIndex = 77;
            // 
            // cmbMonsterAbility2
            // 
            this.cmbMonsterAbility2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterAbility2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterAbility2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterAbility2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterAbility2.FormattingEnabled = true;
            this.cmbMonsterAbility2.Location = new System.Drawing.Point(491, 64);
            this.cmbMonsterAbility2.Name = "cmbMonsterAbility2";
            this.cmbMonsterAbility2.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterAbility2.TabIndex = 76;
            // 
            // cmbMonsterAbility1
            // 
            this.cmbMonsterAbility1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterAbility1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterAbility1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterAbility1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterAbility1.FormattingEnabled = true;
            this.cmbMonsterAbility1.Location = new System.Drawing.Point(491, 31);
            this.cmbMonsterAbility1.Name = "cmbMonsterAbility1";
            this.cmbMonsterAbility1.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterAbility1.TabIndex = 75;
            // 
            // numMonsterAbilityQueue
            // 
            this.numMonsterAbilityQueue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterAbilityQueue.Location = new System.Drawing.Point(381, 66);
            this.numMonsterAbilityQueue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterAbilityQueue.Name = "numMonsterAbilityQueue";
            this.numMonsterAbilityQueue.Size = new System.Drawing.Size(55, 27);
            this.numMonsterAbilityQueue.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 73;
            this.label1.Text = "Ability Queue";
            // 
            // numMonsterMagicQueue
            // 
            this.numMonsterMagicQueue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterMagicQueue.Location = new System.Drawing.Point(10, 64);
            this.numMonsterMagicQueue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterMagicQueue.Name = "numMonsterMagicQueue";
            this.numMonsterMagicQueue.Size = new System.Drawing.Size(55, 27);
            this.numMonsterMagicQueue.TabIndex = 64;
            // 
            // lblMonsterMagicQueue
            // 
            this.lblMonsterMagicQueue.AutoSize = true;
            this.lblMonsterMagicQueue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterMagicQueue.Location = new System.Drawing.Point(6, 31);
            this.lblMonsterMagicQueue.Name = "lblMonsterMagicQueue";
            this.lblMonsterMagicQueue.Size = new System.Drawing.Size(100, 19);
            this.lblMonsterMagicQueue.TabIndex = 64;
            this.lblMonsterMagicQueue.Text = "Magic Queue";
            // 
            // cmbMonsterSpell8
            // 
            this.cmbMonsterSpell8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell8.FormattingEnabled = true;
            this.cmbMonsterSpell8.Location = new System.Drawing.Point(256, 130);
            this.cmbMonsterSpell8.Name = "cmbMonsterSpell8";
            this.cmbMonsterSpell8.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell8.TabIndex = 72;
            // 
            // cmbMonsterSpell7
            // 
            this.cmbMonsterSpell7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell7.FormattingEnabled = true;
            this.cmbMonsterSpell7.Location = new System.Drawing.Point(256, 97);
            this.cmbMonsterSpell7.Name = "cmbMonsterSpell7";
            this.cmbMonsterSpell7.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell7.TabIndex = 71;
            // 
            // cmbMonsterSpell6
            // 
            this.cmbMonsterSpell6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell6.FormattingEnabled = true;
            this.cmbMonsterSpell6.Location = new System.Drawing.Point(256, 64);
            this.cmbMonsterSpell6.Name = "cmbMonsterSpell6";
            this.cmbMonsterSpell6.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell6.TabIndex = 70;
            // 
            // cmbMonsterSpell5
            // 
            this.cmbMonsterSpell5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell5.FormattingEnabled = true;
            this.cmbMonsterSpell5.Location = new System.Drawing.Point(256, 31);
            this.cmbMonsterSpell5.Name = "cmbMonsterSpell5";
            this.cmbMonsterSpell5.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell5.TabIndex = 69;
            // 
            // cmbMonsterSpell4
            // 
            this.cmbMonsterSpell4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell4.FormattingEnabled = true;
            this.cmbMonsterSpell4.Location = new System.Drawing.Point(131, 130);
            this.cmbMonsterSpell4.Name = "cmbMonsterSpell4";
            this.cmbMonsterSpell4.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell4.TabIndex = 68;
            // 
            // cmbMonsterSpell3
            // 
            this.cmbMonsterSpell3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell3.FormattingEnabled = true;
            this.cmbMonsterSpell3.Location = new System.Drawing.Point(131, 97);
            this.cmbMonsterSpell3.Name = "cmbMonsterSpell3";
            this.cmbMonsterSpell3.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell3.TabIndex = 67;
            // 
            // cmbMonsterSpell2
            // 
            this.cmbMonsterSpell2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell2.FormattingEnabled = true;
            this.cmbMonsterSpell2.Location = new System.Drawing.Point(131, 64);
            this.cmbMonsterSpell2.Name = "cmbMonsterSpell2";
            this.cmbMonsterSpell2.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell2.TabIndex = 66;
            // 
            // cmbMonsterSpell1
            // 
            this.cmbMonsterSpell1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterSpell1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterSpell1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterSpell1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterSpell1.FormattingEnabled = true;
            this.cmbMonsterSpell1.Location = new System.Drawing.Point(131, 31);
            this.cmbMonsterSpell1.Name = "cmbMonsterSpell1";
            this.cmbMonsterSpell1.Size = new System.Drawing.Size(113, 27);
            this.cmbMonsterSpell1.TabIndex = 65;
            // 
            // grpItemDrops
            // 
            this.grpItemDrops.Controls.Add(this.cmbMonsterItemDrop);
            this.grpItemDrops.Controls.Add(this.lblDropChance);
            this.grpItemDrops.Controls.Add(this.numDropChance);
            this.grpItemDrops.Controls.Add(this.lblDropType);
            this.grpItemDrops.Controls.Add(this.cmbMonsterItemType);
            this.grpItemDrops.Location = new System.Drawing.Point(582, 177);
            this.grpItemDrops.Name = "grpItemDrops";
            this.grpItemDrops.Size = new System.Drawing.Size(244, 98);
            this.grpItemDrops.TabIndex = 62;
            this.grpItemDrops.TabStop = false;
            this.grpItemDrops.Text = "Items";
            // 
            // cmbMonsterItemDrop
            // 
            this.cmbMonsterItemDrop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterItemDrop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterItemDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterItemDrop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterItemDrop.FormattingEnabled = true;
            this.cmbMonsterItemDrop.Location = new System.Drawing.Point(6, 53);
            this.cmbMonsterItemDrop.Name = "cmbMonsterItemDrop";
            this.cmbMonsterItemDrop.Size = new System.Drawing.Size(144, 27);
            this.cmbMonsterItemDrop.TabIndex = 64;
            // 
            // lblDropChance
            // 
            this.lblDropChance.AutoSize = true;
            this.lblDropChance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropChance.Location = new System.Drawing.Point(217, 56);
            this.lblDropChance.Name = "lblDropChance";
            this.lblDropChance.Size = new System.Drawing.Size(25, 19);
            this.lblDropChance.TabIndex = 63;
            this.lblDropChance.Text = "%";
            // 
            // numDropChance
            // 
            this.numDropChance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDropChance.Location = new System.Drawing.Point(160, 53);
            this.numDropChance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numDropChance.Name = "numDropChance";
            this.numDropChance.Size = new System.Drawing.Size(51, 27);
            this.numDropChance.TabIndex = 63;
            // 
            // lblDropType
            // 
            this.lblDropType.AutoSize = true;
            this.lblDropType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropType.Location = new System.Drawing.Point(6, 17);
            this.lblDropType.Name = "lblDropType";
            this.lblDropType.Size = new System.Drawing.Size(82, 19);
            this.lblDropType.TabIndex = 63;
            this.lblDropType.Text = "Item Type";
            // 
            // cmbMonsterItemType
            // 
            this.cmbMonsterItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsterItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsterItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsterItemType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsterItemType.FormattingEnabled = true;
            this.cmbMonsterItemType.Items.AddRange(new object[] {
            "Nothing",
            "Consumable",
            "Weapon",
            "Armor"});
            this.cmbMonsterItemType.Location = new System.Drawing.Point(94, 14);
            this.cmbMonsterItemType.Name = "cmbMonsterItemType";
            this.cmbMonsterItemType.Size = new System.Drawing.Size(144, 27);
            this.cmbMonsterItemType.TabIndex = 61;
            this.cmbMonsterItemType.SelectedIndexChanged += new System.EventHandler(this.cmbMonsterItemType_SelectedIndexChanged);
            // 
            // grpMonsterFamily
            // 
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamMagical);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamRegenerative);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamDragon);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamGiant);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamSpellcaster);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamUndead);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamWerebeast);
            this.grpMonsterFamily.Controls.Add(this.chkMonsterFamAquan);
            this.grpMonsterFamily.Location = new System.Drawing.Point(707, 6);
            this.grpMonsterFamily.Name = "grpMonsterFamily";
            this.grpMonsterFamily.Size = new System.Drawing.Size(119, 165);
            this.grpMonsterFamily.TabIndex = 59;
            this.grpMonsterFamily.TabStop = false;
            this.grpMonsterFamily.Text = "Family";
            // 
            // chkMonsterFamMagical
            // 
            this.chkMonsterFamMagical.AutoSize = true;
            this.chkMonsterFamMagical.Location = new System.Drawing.Point(6, 21);
            this.chkMonsterFamMagical.Name = "chkMonsterFamMagical";
            this.chkMonsterFamMagical.Size = new System.Drawing.Size(64, 18);
            this.chkMonsterFamMagical.TabIndex = 14;
            this.chkMonsterFamMagical.Text = "Magical";
            this.chkMonsterFamMagical.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamRegenerative
            // 
            this.chkMonsterFamRegenerative.AutoSize = true;
            this.chkMonsterFamRegenerative.Location = new System.Drawing.Point(6, 140);
            this.chkMonsterFamRegenerative.Name = "chkMonsterFamRegenerative";
            this.chkMonsterFamRegenerative.Size = new System.Drawing.Size(98, 18);
            this.chkMonsterFamRegenerative.TabIndex = 21;
            this.chkMonsterFamRegenerative.Text = "Regenerative";
            this.chkMonsterFamRegenerative.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamDragon
            // 
            this.chkMonsterFamDragon.AutoSize = true;
            this.chkMonsterFamDragon.Location = new System.Drawing.Point(6, 38);
            this.chkMonsterFamDragon.Name = "chkMonsterFamDragon";
            this.chkMonsterFamDragon.Size = new System.Drawing.Size(65, 18);
            this.chkMonsterFamDragon.TabIndex = 15;
            this.chkMonsterFamDragon.Text = "Dragon";
            this.chkMonsterFamDragon.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamGiant
            // 
            this.chkMonsterFamGiant.AutoSize = true;
            this.chkMonsterFamGiant.Location = new System.Drawing.Point(6, 55);
            this.chkMonsterFamGiant.Name = "chkMonsterFamGiant";
            this.chkMonsterFamGiant.Size = new System.Drawing.Size(54, 18);
            this.chkMonsterFamGiant.TabIndex = 16;
            this.chkMonsterFamGiant.Text = "Giant";
            this.chkMonsterFamGiant.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamSpellcaster
            // 
            this.chkMonsterFamSpellcaster.AutoSize = true;
            this.chkMonsterFamSpellcaster.Location = new System.Drawing.Point(6, 123);
            this.chkMonsterFamSpellcaster.Name = "chkMonsterFamSpellcaster";
            this.chkMonsterFamSpellcaster.Size = new System.Drawing.Size(84, 18);
            this.chkMonsterFamSpellcaster.TabIndex = 20;
            this.chkMonsterFamSpellcaster.Text = "Spellcaster";
            this.chkMonsterFamSpellcaster.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamUndead
            // 
            this.chkMonsterFamUndead.AutoSize = true;
            this.chkMonsterFamUndead.Location = new System.Drawing.Point(6, 72);
            this.chkMonsterFamUndead.Name = "chkMonsterFamUndead";
            this.chkMonsterFamUndead.Size = new System.Drawing.Size(68, 18);
            this.chkMonsterFamUndead.TabIndex = 17;
            this.chkMonsterFamUndead.Text = "Undead";
            this.chkMonsterFamUndead.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamWerebeast
            // 
            this.chkMonsterFamWerebeast.AutoSize = true;
            this.chkMonsterFamWerebeast.Location = new System.Drawing.Point(6, 89);
            this.chkMonsterFamWerebeast.Name = "chkMonsterFamWerebeast";
            this.chkMonsterFamWerebeast.Size = new System.Drawing.Size(86, 18);
            this.chkMonsterFamWerebeast.TabIndex = 18;
            this.chkMonsterFamWerebeast.Text = "Werebeast";
            this.chkMonsterFamWerebeast.UseVisualStyleBackColor = true;
            // 
            // chkMonsterFamAquan
            // 
            this.chkMonsterFamAquan.AutoSize = true;
            this.chkMonsterFamAquan.Location = new System.Drawing.Point(6, 106);
            this.chkMonsterFamAquan.Name = "chkMonsterFamAquan";
            this.chkMonsterFamAquan.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterFamAquan.TabIndex = 19;
            this.chkMonsterFamAquan.Text = "Aquan";
            this.chkMonsterFamAquan.UseVisualStyleBackColor = true;
            // 
            // grpMonsterWeakElements
            // 
            this.grpMonsterWeakElements.Controls.Add(this.groupBox2);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakMind);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakConfusion);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakSilence);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakSleep);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakDarkness);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakPoison);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakQuake);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakLightning);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakIce);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakFire);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakDeath);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakTime);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakStone);
            this.grpMonsterWeakElements.Controls.Add(this.chkMonsterWeakParalysis);
            this.grpMonsterWeakElements.Location = new System.Drawing.Point(457, 6);
            this.grpMonsterWeakElements.Name = "grpMonsterWeakElements";
            this.grpMonsterWeakElements.Size = new System.Drawing.Size(119, 269);
            this.grpMonsterWeakElements.TabIndex = 60;
            this.grpMonsterWeakElements.TabStop = false;
            this.grpMonsterWeakElements.Text = "Weak Elements";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(125, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 269);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attack Properties";
            // 
            // chkMonsterWeakMind
            // 
            this.chkMonsterWeakMind.AutoSize = true;
            this.chkMonsterWeakMind.Location = new System.Drawing.Point(6, 242);
            this.chkMonsterWeakMind.Name = "chkMonsterWeakMind";
            this.chkMonsterWeakMind.Size = new System.Drawing.Size(51, 18);
            this.chkMonsterWeakMind.TabIndex = 13;
            this.chkMonsterWeakMind.Text = "Mind";
            this.chkMonsterWeakMind.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakConfusion
            // 
            this.chkMonsterWeakConfusion.AutoSize = true;
            this.chkMonsterWeakConfusion.Location = new System.Drawing.Point(6, 225);
            this.chkMonsterWeakConfusion.Name = "chkMonsterWeakConfusion";
            this.chkMonsterWeakConfusion.Size = new System.Drawing.Size(79, 18);
            this.chkMonsterWeakConfusion.TabIndex = 12;
            this.chkMonsterWeakConfusion.Text = "Confusion";
            this.chkMonsterWeakConfusion.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakSilence
            // 
            this.chkMonsterWeakSilence.AutoSize = true;
            this.chkMonsterWeakSilence.Location = new System.Drawing.Point(6, 208);
            this.chkMonsterWeakSilence.Name = "chkMonsterWeakSilence";
            this.chkMonsterWeakSilence.Size = new System.Drawing.Size(64, 18);
            this.chkMonsterWeakSilence.TabIndex = 11;
            this.chkMonsterWeakSilence.Text = "Silence";
            this.chkMonsterWeakSilence.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakSleep
            // 
            this.chkMonsterWeakSleep.AutoSize = true;
            this.chkMonsterWeakSleep.Location = new System.Drawing.Point(6, 191);
            this.chkMonsterWeakSleep.Name = "chkMonsterWeakSleep";
            this.chkMonsterWeakSleep.Size = new System.Drawing.Size(56, 18);
            this.chkMonsterWeakSleep.TabIndex = 10;
            this.chkMonsterWeakSleep.Text = "Sleep";
            this.chkMonsterWeakSleep.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakDarkness
            // 
            this.chkMonsterWeakDarkness.AutoSize = true;
            this.chkMonsterWeakDarkness.Location = new System.Drawing.Point(6, 174);
            this.chkMonsterWeakDarkness.Name = "chkMonsterWeakDarkness";
            this.chkMonsterWeakDarkness.Size = new System.Drawing.Size(74, 18);
            this.chkMonsterWeakDarkness.TabIndex = 9;
            this.chkMonsterWeakDarkness.Text = "Darkness";
            this.chkMonsterWeakDarkness.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakPoison
            // 
            this.chkMonsterWeakPoison.AutoSize = true;
            this.chkMonsterWeakPoison.Location = new System.Drawing.Point(6, 157);
            this.chkMonsterWeakPoison.Name = "chkMonsterWeakPoison";
            this.chkMonsterWeakPoison.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterWeakPoison.TabIndex = 8;
            this.chkMonsterWeakPoison.Text = "Poison";
            this.chkMonsterWeakPoison.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakQuake
            // 
            this.chkMonsterWeakQuake.AutoSize = true;
            this.chkMonsterWeakQuake.Location = new System.Drawing.Point(6, 140);
            this.chkMonsterWeakQuake.Name = "chkMonsterWeakQuake";
            this.chkMonsterWeakQuake.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterWeakQuake.TabIndex = 7;
            this.chkMonsterWeakQuake.Text = "Quake";
            this.chkMonsterWeakQuake.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakLightning
            // 
            this.chkMonsterWeakLightning.AutoSize = true;
            this.chkMonsterWeakLightning.Location = new System.Drawing.Point(6, 123);
            this.chkMonsterWeakLightning.Name = "chkMonsterWeakLightning";
            this.chkMonsterWeakLightning.Size = new System.Drawing.Size(76, 18);
            this.chkMonsterWeakLightning.TabIndex = 6;
            this.chkMonsterWeakLightning.Text = "Lightning";
            this.chkMonsterWeakLightning.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakIce
            // 
            this.chkMonsterWeakIce.AutoSize = true;
            this.chkMonsterWeakIce.Location = new System.Drawing.Point(6, 106);
            this.chkMonsterWeakIce.Name = "chkMonsterWeakIce";
            this.chkMonsterWeakIce.Size = new System.Drawing.Size(43, 18);
            this.chkMonsterWeakIce.TabIndex = 5;
            this.chkMonsterWeakIce.Text = "Ice";
            this.chkMonsterWeakIce.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakFire
            // 
            this.chkMonsterWeakFire.AutoSize = true;
            this.chkMonsterWeakFire.Location = new System.Drawing.Point(6, 89);
            this.chkMonsterWeakFire.Name = "chkMonsterWeakFire";
            this.chkMonsterWeakFire.Size = new System.Drawing.Size(45, 18);
            this.chkMonsterWeakFire.TabIndex = 4;
            this.chkMonsterWeakFire.Text = "Fire";
            this.chkMonsterWeakFire.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakDeath
            // 
            this.chkMonsterWeakDeath.AutoSize = true;
            this.chkMonsterWeakDeath.Location = new System.Drawing.Point(6, 72);
            this.chkMonsterWeakDeath.Name = "chkMonsterWeakDeath";
            this.chkMonsterWeakDeath.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterWeakDeath.TabIndex = 3;
            this.chkMonsterWeakDeath.Text = "Death";
            this.chkMonsterWeakDeath.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakTime
            // 
            this.chkMonsterWeakTime.AutoSize = true;
            this.chkMonsterWeakTime.Location = new System.Drawing.Point(6, 55);
            this.chkMonsterWeakTime.Name = "chkMonsterWeakTime";
            this.chkMonsterWeakTime.Size = new System.Drawing.Size(53, 18);
            this.chkMonsterWeakTime.TabIndex = 2;
            this.chkMonsterWeakTime.Text = "Time";
            this.chkMonsterWeakTime.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakStone
            // 
            this.chkMonsterWeakStone.AutoSize = true;
            this.chkMonsterWeakStone.Location = new System.Drawing.Point(6, 38);
            this.chkMonsterWeakStone.Name = "chkMonsterWeakStone";
            this.chkMonsterWeakStone.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterWeakStone.TabIndex = 1;
            this.chkMonsterWeakStone.Text = "Stone";
            this.chkMonsterWeakStone.UseVisualStyleBackColor = true;
            // 
            // chkMonsterWeakParalysis
            // 
            this.chkMonsterWeakParalysis.AutoSize = true;
            this.chkMonsterWeakParalysis.Location = new System.Drawing.Point(6, 21);
            this.chkMonsterWeakParalysis.Name = "chkMonsterWeakParalysis";
            this.chkMonsterWeakParalysis.Size = new System.Drawing.Size(69, 18);
            this.chkMonsterWeakParalysis.TabIndex = 0;
            this.chkMonsterWeakParalysis.Text = "Paralysis";
            this.chkMonsterWeakParalysis.UseVisualStyleBackColor = true;
            // 
            // grpMonsterResistElements
            // 
            this.grpMonsterResistElements.Controls.Add(this.groupBox3);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistMind);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistConfusion);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistSilence);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistSleep);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistDarkness);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistPoison);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistQuake);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistLightning);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistIce);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistFire);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistDeath);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistTime);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistStone);
            this.grpMonsterResistElements.Controls.Add(this.chkMonsterResistParalysis);
            this.grpMonsterResistElements.Location = new System.Drawing.Point(332, 6);
            this.grpMonsterResistElements.Name = "grpMonsterResistElements";
            this.grpMonsterResistElements.Size = new System.Drawing.Size(119, 269);
            this.grpMonsterResistElements.TabIndex = 59;
            this.grpMonsterResistElements.TabStop = false;
            this.grpMonsterResistElements.Text = "Resist Elements";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(125, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 269);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attack Properties";
            // 
            // chkMonsterResistMind
            // 
            this.chkMonsterResistMind.AutoSize = true;
            this.chkMonsterResistMind.Location = new System.Drawing.Point(6, 242);
            this.chkMonsterResistMind.Name = "chkMonsterResistMind";
            this.chkMonsterResistMind.Size = new System.Drawing.Size(51, 18);
            this.chkMonsterResistMind.TabIndex = 13;
            this.chkMonsterResistMind.Text = "Mind";
            this.chkMonsterResistMind.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistConfusion
            // 
            this.chkMonsterResistConfusion.AutoSize = true;
            this.chkMonsterResistConfusion.Location = new System.Drawing.Point(6, 225);
            this.chkMonsterResistConfusion.Name = "chkMonsterResistConfusion";
            this.chkMonsterResistConfusion.Size = new System.Drawing.Size(79, 18);
            this.chkMonsterResistConfusion.TabIndex = 12;
            this.chkMonsterResistConfusion.Text = "Confusion";
            this.chkMonsterResistConfusion.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistSilence
            // 
            this.chkMonsterResistSilence.AutoSize = true;
            this.chkMonsterResistSilence.Location = new System.Drawing.Point(6, 208);
            this.chkMonsterResistSilence.Name = "chkMonsterResistSilence";
            this.chkMonsterResistSilence.Size = new System.Drawing.Size(64, 18);
            this.chkMonsterResistSilence.TabIndex = 11;
            this.chkMonsterResistSilence.Text = "Silence";
            this.chkMonsterResistSilence.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistSleep
            // 
            this.chkMonsterResistSleep.AutoSize = true;
            this.chkMonsterResistSleep.Location = new System.Drawing.Point(6, 191);
            this.chkMonsterResistSleep.Name = "chkMonsterResistSleep";
            this.chkMonsterResistSleep.Size = new System.Drawing.Size(56, 18);
            this.chkMonsterResistSleep.TabIndex = 10;
            this.chkMonsterResistSleep.Text = "Sleep";
            this.chkMonsterResistSleep.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistDarkness
            // 
            this.chkMonsterResistDarkness.AutoSize = true;
            this.chkMonsterResistDarkness.Location = new System.Drawing.Point(6, 174);
            this.chkMonsterResistDarkness.Name = "chkMonsterResistDarkness";
            this.chkMonsterResistDarkness.Size = new System.Drawing.Size(74, 18);
            this.chkMonsterResistDarkness.TabIndex = 9;
            this.chkMonsterResistDarkness.Text = "Darkness";
            this.chkMonsterResistDarkness.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistPoison
            // 
            this.chkMonsterResistPoison.AutoSize = true;
            this.chkMonsterResistPoison.Location = new System.Drawing.Point(6, 157);
            this.chkMonsterResistPoison.Name = "chkMonsterResistPoison";
            this.chkMonsterResistPoison.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterResistPoison.TabIndex = 8;
            this.chkMonsterResistPoison.Text = "Poison";
            this.chkMonsterResistPoison.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistQuake
            // 
            this.chkMonsterResistQuake.AutoSize = true;
            this.chkMonsterResistQuake.Location = new System.Drawing.Point(6, 140);
            this.chkMonsterResistQuake.Name = "chkMonsterResistQuake";
            this.chkMonsterResistQuake.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterResistQuake.TabIndex = 7;
            this.chkMonsterResistQuake.Text = "Quake";
            this.chkMonsterResistQuake.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistLightning
            // 
            this.chkMonsterResistLightning.AutoSize = true;
            this.chkMonsterResistLightning.Location = new System.Drawing.Point(6, 123);
            this.chkMonsterResistLightning.Name = "chkMonsterResistLightning";
            this.chkMonsterResistLightning.Size = new System.Drawing.Size(76, 18);
            this.chkMonsterResistLightning.TabIndex = 6;
            this.chkMonsterResistLightning.Text = "Lightning";
            this.chkMonsterResistLightning.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistIce
            // 
            this.chkMonsterResistIce.AutoSize = true;
            this.chkMonsterResistIce.Location = new System.Drawing.Point(6, 106);
            this.chkMonsterResistIce.Name = "chkMonsterResistIce";
            this.chkMonsterResistIce.Size = new System.Drawing.Size(43, 18);
            this.chkMonsterResistIce.TabIndex = 5;
            this.chkMonsterResistIce.Text = "Ice";
            this.chkMonsterResistIce.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistFire
            // 
            this.chkMonsterResistFire.AutoSize = true;
            this.chkMonsterResistFire.Location = new System.Drawing.Point(6, 89);
            this.chkMonsterResistFire.Name = "chkMonsterResistFire";
            this.chkMonsterResistFire.Size = new System.Drawing.Size(45, 18);
            this.chkMonsterResistFire.TabIndex = 4;
            this.chkMonsterResistFire.Text = "Fire";
            this.chkMonsterResistFire.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistDeath
            // 
            this.chkMonsterResistDeath.AutoSize = true;
            this.chkMonsterResistDeath.Location = new System.Drawing.Point(6, 72);
            this.chkMonsterResistDeath.Name = "chkMonsterResistDeath";
            this.chkMonsterResistDeath.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterResistDeath.TabIndex = 3;
            this.chkMonsterResistDeath.Text = "Death";
            this.chkMonsterResistDeath.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistTime
            // 
            this.chkMonsterResistTime.AutoSize = true;
            this.chkMonsterResistTime.Location = new System.Drawing.Point(6, 55);
            this.chkMonsterResistTime.Name = "chkMonsterResistTime";
            this.chkMonsterResistTime.Size = new System.Drawing.Size(53, 18);
            this.chkMonsterResistTime.TabIndex = 2;
            this.chkMonsterResistTime.Text = "Time";
            this.chkMonsterResistTime.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistStone
            // 
            this.chkMonsterResistStone.AutoSize = true;
            this.chkMonsterResistStone.Location = new System.Drawing.Point(6, 38);
            this.chkMonsterResistStone.Name = "chkMonsterResistStone";
            this.chkMonsterResistStone.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterResistStone.TabIndex = 1;
            this.chkMonsterResistStone.Text = "Stone";
            this.chkMonsterResistStone.UseVisualStyleBackColor = true;
            // 
            // chkMonsterResistParalysis
            // 
            this.chkMonsterResistParalysis.AutoSize = true;
            this.chkMonsterResistParalysis.Location = new System.Drawing.Point(6, 21);
            this.chkMonsterResistParalysis.Name = "chkMonsterResistParalysis";
            this.chkMonsterResistParalysis.Size = new System.Drawing.Size(69, 18);
            this.chkMonsterResistParalysis.TabIndex = 0;
            this.chkMonsterResistParalysis.Text = "Paralysis";
            this.chkMonsterResistParalysis.UseVisualStyleBackColor = true;
            // 
            // grpAttackStatus
            // 
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStDeath);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStConfusion);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStStone);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStPoison);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStSilence);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStBlind);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStStun);
            this.grpAttackStatus.Controls.Add(this.chkMonsterAtkStSleep);
            this.grpAttackStatus.Location = new System.Drawing.Point(582, 6);
            this.grpAttackStatus.Name = "grpAttackStatus";
            this.grpAttackStatus.Size = new System.Drawing.Size(119, 165);
            this.grpAttackStatus.TabIndex = 58;
            this.grpAttackStatus.TabStop = false;
            this.grpAttackStatus.Text = "Attack Status";
            // 
            // chkMonsterAtkStDeath
            // 
            this.chkMonsterAtkStDeath.AutoSize = true;
            this.chkMonsterAtkStDeath.Location = new System.Drawing.Point(6, 21);
            this.chkMonsterAtkStDeath.Name = "chkMonsterAtkStDeath";
            this.chkMonsterAtkStDeath.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterAtkStDeath.TabIndex = 14;
            this.chkMonsterAtkStDeath.Text = "Death";
            this.chkMonsterAtkStDeath.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStConfusion
            // 
            this.chkMonsterAtkStConfusion.AutoSize = true;
            this.chkMonsterAtkStConfusion.Location = new System.Drawing.Point(6, 140);
            this.chkMonsterAtkStConfusion.Name = "chkMonsterAtkStConfusion";
            this.chkMonsterAtkStConfusion.Size = new System.Drawing.Size(79, 18);
            this.chkMonsterAtkStConfusion.TabIndex = 21;
            this.chkMonsterAtkStConfusion.Text = "Confusion";
            this.chkMonsterAtkStConfusion.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStStone
            // 
            this.chkMonsterAtkStStone.AutoSize = true;
            this.chkMonsterAtkStStone.Location = new System.Drawing.Point(6, 38);
            this.chkMonsterAtkStStone.Name = "chkMonsterAtkStStone";
            this.chkMonsterAtkStStone.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterAtkStStone.TabIndex = 15;
            this.chkMonsterAtkStStone.Text = "Stone";
            this.chkMonsterAtkStStone.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStPoison
            // 
            this.chkMonsterAtkStPoison.AutoSize = true;
            this.chkMonsterAtkStPoison.Location = new System.Drawing.Point(6, 55);
            this.chkMonsterAtkStPoison.Name = "chkMonsterAtkStPoison";
            this.chkMonsterAtkStPoison.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterAtkStPoison.TabIndex = 16;
            this.chkMonsterAtkStPoison.Text = "Poison";
            this.chkMonsterAtkStPoison.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStSilence
            // 
            this.chkMonsterAtkStSilence.AutoSize = true;
            this.chkMonsterAtkStSilence.Location = new System.Drawing.Point(6, 123);
            this.chkMonsterAtkStSilence.Name = "chkMonsterAtkStSilence";
            this.chkMonsterAtkStSilence.Size = new System.Drawing.Size(64, 18);
            this.chkMonsterAtkStSilence.TabIndex = 20;
            this.chkMonsterAtkStSilence.Text = "Silence";
            this.chkMonsterAtkStSilence.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStBlind
            // 
            this.chkMonsterAtkStBlind.AutoSize = true;
            this.chkMonsterAtkStBlind.Location = new System.Drawing.Point(6, 72);
            this.chkMonsterAtkStBlind.Name = "chkMonsterAtkStBlind";
            this.chkMonsterAtkStBlind.Size = new System.Drawing.Size(51, 18);
            this.chkMonsterAtkStBlind.TabIndex = 17;
            this.chkMonsterAtkStBlind.Text = "Blind";
            this.chkMonsterAtkStBlind.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStStun
            // 
            this.chkMonsterAtkStStun.AutoSize = true;
            this.chkMonsterAtkStStun.Location = new System.Drawing.Point(6, 89);
            this.chkMonsterAtkStStun.Name = "chkMonsterAtkStStun";
            this.chkMonsterAtkStStun.Size = new System.Drawing.Size(52, 18);
            this.chkMonsterAtkStStun.TabIndex = 18;
            this.chkMonsterAtkStStun.Text = "Stun";
            this.chkMonsterAtkStStun.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStSleep
            // 
            this.chkMonsterAtkStSleep.AutoSize = true;
            this.chkMonsterAtkStSleep.Location = new System.Drawing.Point(6, 106);
            this.chkMonsterAtkStSleep.Name = "chkMonsterAtkStSleep";
            this.chkMonsterAtkStSleep.Size = new System.Drawing.Size(56, 18);
            this.chkMonsterAtkStSleep.TabIndex = 19;
            this.chkMonsterAtkStSleep.Text = "Sleep";
            this.chkMonsterAtkStSleep.UseVisualStyleBackColor = true;
            // 
            // grpMonsterAttackElements
            // 
            this.grpMonsterAttackElements.Controls.Add(this.groupBox1);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkMind);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkConfusion);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkSilence);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkSleep);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkDarkness);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkPoison);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkQuake);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkLightning);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkIce);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkFire);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkDeath);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkTime);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkStone);
            this.grpMonsterAttackElements.Controls.Add(this.chkMonsterAtkParalysis);
            this.grpMonsterAttackElements.Location = new System.Drawing.Point(207, 6);
            this.grpMonsterAttackElements.Name = "grpMonsterAttackElements";
            this.grpMonsterAttackElements.Size = new System.Drawing.Size(119, 269);
            this.grpMonsterAttackElements.TabIndex = 57;
            this.grpMonsterAttackElements.TabStop = false;
            this.grpMonsterAttackElements.Text = "Attack Elements";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(125, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 269);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attack Properties";
            // 
            // chkMonsterAtkMind
            // 
            this.chkMonsterAtkMind.AutoSize = true;
            this.chkMonsterAtkMind.Location = new System.Drawing.Point(6, 242);
            this.chkMonsterAtkMind.Name = "chkMonsterAtkMind";
            this.chkMonsterAtkMind.Size = new System.Drawing.Size(51, 18);
            this.chkMonsterAtkMind.TabIndex = 13;
            this.chkMonsterAtkMind.Text = "Mind";
            this.chkMonsterAtkMind.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkConfusion
            // 
            this.chkMonsterAtkConfusion.AutoSize = true;
            this.chkMonsterAtkConfusion.Location = new System.Drawing.Point(6, 225);
            this.chkMonsterAtkConfusion.Name = "chkMonsterAtkConfusion";
            this.chkMonsterAtkConfusion.Size = new System.Drawing.Size(79, 18);
            this.chkMonsterAtkConfusion.TabIndex = 12;
            this.chkMonsterAtkConfusion.Text = "Confusion";
            this.chkMonsterAtkConfusion.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkSilence
            // 
            this.chkMonsterAtkSilence.AutoSize = true;
            this.chkMonsterAtkSilence.Location = new System.Drawing.Point(6, 208);
            this.chkMonsterAtkSilence.Name = "chkMonsterAtkSilence";
            this.chkMonsterAtkSilence.Size = new System.Drawing.Size(64, 18);
            this.chkMonsterAtkSilence.TabIndex = 11;
            this.chkMonsterAtkSilence.Text = "Silence";
            this.chkMonsterAtkSilence.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkSleep
            // 
            this.chkMonsterAtkSleep.AutoSize = true;
            this.chkMonsterAtkSleep.Location = new System.Drawing.Point(6, 191);
            this.chkMonsterAtkSleep.Name = "chkMonsterAtkSleep";
            this.chkMonsterAtkSleep.Size = new System.Drawing.Size(56, 18);
            this.chkMonsterAtkSleep.TabIndex = 10;
            this.chkMonsterAtkSleep.Text = "Sleep";
            this.chkMonsterAtkSleep.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkDarkness
            // 
            this.chkMonsterAtkDarkness.AutoSize = true;
            this.chkMonsterAtkDarkness.Location = new System.Drawing.Point(6, 174);
            this.chkMonsterAtkDarkness.Name = "chkMonsterAtkDarkness";
            this.chkMonsterAtkDarkness.Size = new System.Drawing.Size(74, 18);
            this.chkMonsterAtkDarkness.TabIndex = 9;
            this.chkMonsterAtkDarkness.Text = "Darkness";
            this.chkMonsterAtkDarkness.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkPoison
            // 
            this.chkMonsterAtkPoison.AutoSize = true;
            this.chkMonsterAtkPoison.Location = new System.Drawing.Point(6, 157);
            this.chkMonsterAtkPoison.Name = "chkMonsterAtkPoison";
            this.chkMonsterAtkPoison.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterAtkPoison.TabIndex = 8;
            this.chkMonsterAtkPoison.Text = "Poison";
            this.chkMonsterAtkPoison.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkQuake
            // 
            this.chkMonsterAtkQuake.AutoSize = true;
            this.chkMonsterAtkQuake.Location = new System.Drawing.Point(6, 140);
            this.chkMonsterAtkQuake.Name = "chkMonsterAtkQuake";
            this.chkMonsterAtkQuake.Size = new System.Drawing.Size(61, 18);
            this.chkMonsterAtkQuake.TabIndex = 7;
            this.chkMonsterAtkQuake.Text = "Quake";
            this.chkMonsterAtkQuake.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkLightning
            // 
            this.chkMonsterAtkLightning.AutoSize = true;
            this.chkMonsterAtkLightning.Location = new System.Drawing.Point(6, 123);
            this.chkMonsterAtkLightning.Name = "chkMonsterAtkLightning";
            this.chkMonsterAtkLightning.Size = new System.Drawing.Size(76, 18);
            this.chkMonsterAtkLightning.TabIndex = 6;
            this.chkMonsterAtkLightning.Text = "Lightning";
            this.chkMonsterAtkLightning.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkIce
            // 
            this.chkMonsterAtkIce.AutoSize = true;
            this.chkMonsterAtkIce.Location = new System.Drawing.Point(6, 106);
            this.chkMonsterAtkIce.Name = "chkMonsterAtkIce";
            this.chkMonsterAtkIce.Size = new System.Drawing.Size(43, 18);
            this.chkMonsterAtkIce.TabIndex = 5;
            this.chkMonsterAtkIce.Text = "Ice";
            this.chkMonsterAtkIce.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkFire
            // 
            this.chkMonsterAtkFire.AutoSize = true;
            this.chkMonsterAtkFire.Location = new System.Drawing.Point(6, 89);
            this.chkMonsterAtkFire.Name = "chkMonsterAtkFire";
            this.chkMonsterAtkFire.Size = new System.Drawing.Size(45, 18);
            this.chkMonsterAtkFire.TabIndex = 4;
            this.chkMonsterAtkFire.Text = "Fire";
            this.chkMonsterAtkFire.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkDeath
            // 
            this.chkMonsterAtkDeath.AutoSize = true;
            this.chkMonsterAtkDeath.Location = new System.Drawing.Point(6, 72);
            this.chkMonsterAtkDeath.Name = "chkMonsterAtkDeath";
            this.chkMonsterAtkDeath.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterAtkDeath.TabIndex = 3;
            this.chkMonsterAtkDeath.Text = "Death";
            this.chkMonsterAtkDeath.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkTime
            // 
            this.chkMonsterAtkTime.AutoSize = true;
            this.chkMonsterAtkTime.Location = new System.Drawing.Point(6, 55);
            this.chkMonsterAtkTime.Name = "chkMonsterAtkTime";
            this.chkMonsterAtkTime.Size = new System.Drawing.Size(53, 18);
            this.chkMonsterAtkTime.TabIndex = 2;
            this.chkMonsterAtkTime.Text = "Time";
            this.chkMonsterAtkTime.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkStone
            // 
            this.chkMonsterAtkStone.AutoSize = true;
            this.chkMonsterAtkStone.Location = new System.Drawing.Point(6, 38);
            this.chkMonsterAtkStone.Name = "chkMonsterAtkStone";
            this.chkMonsterAtkStone.Size = new System.Drawing.Size(59, 18);
            this.chkMonsterAtkStone.TabIndex = 1;
            this.chkMonsterAtkStone.Text = "Stone";
            this.chkMonsterAtkStone.UseVisualStyleBackColor = true;
            // 
            // chkMonsterAtkParalysis
            // 
            this.chkMonsterAtkParalysis.AutoSize = true;
            this.chkMonsterAtkParalysis.Location = new System.Drawing.Point(6, 21);
            this.chkMonsterAtkParalysis.Name = "chkMonsterAtkParalysis";
            this.chkMonsterAtkParalysis.Size = new System.Drawing.Size(69, 18);
            this.chkMonsterAtkParalysis.TabIndex = 0;
            this.chkMonsterAtkParalysis.Text = "Paralysis";
            this.chkMonsterAtkParalysis.UseVisualStyleBackColor = true;
            // 
            // numMonsterMagDef
            // 
            this.numMonsterMagDef.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterMagDef.Location = new System.Drawing.Point(121, 318);
            this.numMonsterMagDef.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterMagDef.Name = "numMonsterMagDef";
            this.numMonsterMagDef.Size = new System.Drawing.Size(80, 27);
            this.numMonsterMagDef.TabIndex = 56;
            // 
            // lblMonsterMagDef
            // 
            this.lblMonsterMagDef.AutoSize = true;
            this.lblMonsterMagDef.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterMagDef.Location = new System.Drawing.Point(6, 320);
            this.lblMonsterMagDef.Name = "lblMonsterMagDef";
            this.lblMonsterMagDef.Size = new System.Drawing.Size(78, 19);
            this.lblMonsterMagDef.TabIndex = 55;
            this.lblMonsterMagDef.Text = "Magic Def";
            // 
            // numMonsterCritRate
            // 
            this.numMonsterCritRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterCritRate.Location = new System.Drawing.Point(121, 458);
            this.numMonsterCritRate.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterCritRate.Name = "numMonsterCritRate";
            this.numMonsterCritRate.Size = new System.Drawing.Size(80, 27);
            this.numMonsterCritRate.TabIndex = 54;
            // 
            // numMonsterAgility
            // 
            this.numMonsterAgility.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterAgility.Location = new System.Drawing.Point(121, 388);
            this.numMonsterAgility.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterAgility.Name = "numMonsterAgility";
            this.numMonsterAgility.Size = new System.Drawing.Size(80, 27);
            this.numMonsterAgility.TabIndex = 52;
            // 
            // numMonsterIntellect
            // 
            this.numMonsterIntellect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterIntellect.Location = new System.Drawing.Point(121, 423);
            this.numMonsterIntellect.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterIntellect.Name = "numMonsterIntellect";
            this.numMonsterIntellect.Size = new System.Drawing.Size(80, 27);
            this.numMonsterIntellect.TabIndex = 53;
            // 
            // numMonsterAttack
            // 
            this.numMonsterAttack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterAttack.Location = new System.Drawing.Point(121, 353);
            this.numMonsterAttack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterAttack.Name = "numMonsterAttack";
            this.numMonsterAttack.Size = new System.Drawing.Size(80, 27);
            this.numMonsterAttack.TabIndex = 51;
            // 
            // lblMonsterCritRate
            // 
            this.lblMonsterCritRate.AutoSize = true;
            this.lblMonsterCritRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterCritRate.Location = new System.Drawing.Point(6, 460);
            this.lblMonsterCritRate.Name = "lblMonsterCritRate";
            this.lblMonsterCritRate.Size = new System.Drawing.Size(70, 19);
            this.lblMonsterCritRate.TabIndex = 50;
            this.lblMonsterCritRate.Text = "Crit Rate";
            // 
            // lblMonsterIntellect
            // 
            this.lblMonsterIntellect.AutoSize = true;
            this.lblMonsterIntellect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterIntellect.Location = new System.Drawing.Point(6, 425);
            this.lblMonsterIntellect.Name = "lblMonsterIntellect";
            this.lblMonsterIntellect.Size = new System.Drawing.Size(65, 19);
            this.lblMonsterIntellect.TabIndex = 49;
            this.lblMonsterIntellect.Text = "Intellect";
            // 
            // lblMonsterAgility
            // 
            this.lblMonsterAgility.AutoSize = true;
            this.lblMonsterAgility.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterAgility.Location = new System.Drawing.Point(6, 390);
            this.lblMonsterAgility.Name = "lblMonsterAgility";
            this.lblMonsterAgility.Size = new System.Drawing.Size(54, 19);
            this.lblMonsterAgility.TabIndex = 48;
            this.lblMonsterAgility.Text = "Agility";
            // 
            // lblMonsterAttack
            // 
            this.lblMonsterAttack.AutoSize = true;
            this.lblMonsterAttack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterAttack.Location = new System.Drawing.Point(6, 355);
            this.lblMonsterAttack.Name = "lblMonsterAttack";
            this.lblMonsterAttack.Size = new System.Drawing.Size(53, 19);
            this.lblMonsterAttack.TabIndex = 47;
            this.lblMonsterAttack.Text = "Attack";
            // 
            // numMonsterAccuracy
            // 
            this.numMonsterAccuracy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterAccuracy.Location = new System.Drawing.Point(121, 248);
            this.numMonsterAccuracy.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterAccuracy.Name = "numMonsterAccuracy";
            this.numMonsterAccuracy.Size = new System.Drawing.Size(80, 27);
            this.numMonsterAccuracy.TabIndex = 46;
            // 
            // numMonsterDefense
            // 
            this.numMonsterDefense.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterDefense.Location = new System.Drawing.Point(121, 283);
            this.numMonsterDefense.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterDefense.Name = "numMonsterDefense";
            this.numMonsterDefense.Size = new System.Drawing.Size(80, 27);
            this.numMonsterDefense.TabIndex = 44;
            // 
            // numMonsterNumHits
            // 
            this.numMonsterNumHits.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterNumHits.Location = new System.Drawing.Point(121, 213);
            this.numMonsterNumHits.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numMonsterNumHits.Name = "numMonsterNumHits";
            this.numMonsterNumHits.Size = new System.Drawing.Size(80, 27);
            this.numMonsterNumHits.TabIndex = 45;
            // 
            // numMonsterEvasion
            // 
            this.numMonsterEvasion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterEvasion.Location = new System.Drawing.Point(121, 178);
            this.numMonsterEvasion.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterEvasion.Name = "numMonsterEvasion";
            this.numMonsterEvasion.Size = new System.Drawing.Size(80, 27);
            this.numMonsterEvasion.TabIndex = 43;
            // 
            // lblMonsterAccuracy
            // 
            this.lblMonsterAccuracy.AutoSize = true;
            this.lblMonsterAccuracy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterAccuracy.Location = new System.Drawing.Point(6, 250);
            this.lblMonsterAccuracy.Name = "lblMonsterAccuracy";
            this.lblMonsterAccuracy.Size = new System.Drawing.Size(72, 19);
            this.lblMonsterAccuracy.TabIndex = 42;
            this.lblMonsterAccuracy.Text = "Accuracy";
            // 
            // lblMonsterNumHits
            // 
            this.lblMonsterNumHits.AutoSize = true;
            this.lblMonsterNumHits.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterNumHits.Location = new System.Drawing.Point(6, 215);
            this.lblMonsterNumHits.Name = "lblMonsterNumHits";
            this.lblMonsterNumHits.Size = new System.Drawing.Size(85, 19);
            this.lblMonsterNumHits.TabIndex = 41;
            this.lblMonsterNumHits.Text = "No. of Hits";
            // 
            // lblMonsterDefense
            // 
            this.lblMonsterDefense.AutoSize = true;
            this.lblMonsterDefense.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterDefense.Location = new System.Drawing.Point(6, 285);
            this.lblMonsterDefense.Name = "lblMonsterDefense";
            this.lblMonsterDefense.Size = new System.Drawing.Size(65, 19);
            this.lblMonsterDefense.TabIndex = 40;
            this.lblMonsterDefense.Text = "Defense";
            // 
            // lblMonsterEvasion
            // 
            this.lblMonsterEvasion.AutoSize = true;
            this.lblMonsterEvasion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterEvasion.Location = new System.Drawing.Point(6, 180);
            this.lblMonsterEvasion.Name = "lblMonsterEvasion";
            this.lblMonsterEvasion.Size = new System.Drawing.Size(63, 19);
            this.lblMonsterEvasion.TabIndex = 39;
            this.lblMonsterEvasion.Text = "Evasion";
            // 
            // numMonsterMorale
            // 
            this.numMonsterMorale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterMorale.Location = new System.Drawing.Point(121, 144);
            this.numMonsterMorale.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMonsterMorale.Name = "numMonsterMorale";
            this.numMonsterMorale.Size = new System.Drawing.Size(80, 27);
            this.numMonsterMorale.TabIndex = 38;
            // 
            // lblMonsterMorale
            // 
            this.lblMonsterMorale.AutoSize = true;
            this.lblMonsterMorale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterMorale.Location = new System.Drawing.Point(6, 145);
            this.lblMonsterMorale.Name = "lblMonsterMorale";
            this.lblMonsterMorale.Size = new System.Drawing.Size(56, 19);
            this.lblMonsterMorale.TabIndex = 37;
            this.lblMonsterMorale.Text = "Morale";
            // 
            // numMonsterIndex
            // 
            this.numMonsterIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterIndex.Location = new System.Drawing.Point(150, 6);
            this.numMonsterIndex.Maximum = new decimal(new int[] {
            194,
            0,
            0,
            0});
            this.numMonsterIndex.Name = "numMonsterIndex";
            this.numMonsterIndex.Size = new System.Drawing.Size(51, 27);
            this.numMonsterIndex.TabIndex = 1;
            this.numMonsterIndex.ValueChanged += new System.EventHandler(this.NumMonsterIndex_ValueChanged);
            // 
            // numMonsterEXP
            // 
            this.numMonsterEXP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterEXP.Location = new System.Drawing.Point(121, 74);
            this.numMonsterEXP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMonsterEXP.Name = "numMonsterEXP";
            this.numMonsterEXP.Size = new System.Drawing.Size(80, 27);
            this.numMonsterEXP.TabIndex = 6;
            // 
            // numMonsterGil
            // 
            this.numMonsterGil.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterGil.Location = new System.Drawing.Point(121, 109);
            this.numMonsterGil.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMonsterGil.Name = "numMonsterGil";
            this.numMonsterGil.Size = new System.Drawing.Size(80, 27);
            this.numMonsterGil.TabIndex = 7;
            // 
            // numMonsterHP
            // 
            this.numMonsterHP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonsterHP.Location = new System.Drawing.Point(121, 39);
            this.numMonsterHP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMonsterHP.Name = "numMonsterHP";
            this.numMonsterHP.Size = new System.Drawing.Size(80, 27);
            this.numMonsterHP.TabIndex = 4;
            // 
            // btnMonstersCancel
            // 
            this.btnMonstersCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnMonstersCancel.Location = new System.Drawing.Point(755, 498);
            this.btnMonstersCancel.Name = "btnMonstersCancel";
            this.btnMonstersCancel.Size = new System.Drawing.Size(75, 23);
            this.btnMonstersCancel.TabIndex = 36;
            this.btnMonstersCancel.Text = "Cancel";
            this.btnMonstersCancel.UseVisualStyleBackColor = false;
            this.btnMonstersCancel.Click += new System.EventHandler(this.BtnMonstersCancel_Click);
            // 
            // btnMonstersOkay
            // 
            this.btnMonstersOkay.Location = new System.Drawing.Point(674, 498);
            this.btnMonstersOkay.Name = "btnMonstersOkay";
            this.btnMonstersOkay.Size = new System.Drawing.Size(75, 23);
            this.btnMonstersOkay.TabIndex = 35;
            this.btnMonstersOkay.Text = "Okay";
            this.btnMonstersOkay.UseVisualStyleBackColor = true;
            this.btnMonstersOkay.Click += new System.EventHandler(this.BtnMonstersOkay_Click);
            // 
            // lblMonsterGil
            // 
            this.lblMonsterGil.AutoSize = true;
            this.lblMonsterGil.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterGil.Location = new System.Drawing.Point(6, 110);
            this.lblMonsterGil.Name = "lblMonsterGil";
            this.lblMonsterGil.Size = new System.Drawing.Size(28, 19);
            this.lblMonsterGil.TabIndex = 33;
            this.lblMonsterGil.Text = "Gil";
            // 
            // lblMonsterEXP
            // 
            this.lblMonsterEXP.AutoSize = true;
            this.lblMonsterEXP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterEXP.Location = new System.Drawing.Point(6, 75);
            this.lblMonsterEXP.Name = "lblMonsterEXP";
            this.lblMonsterEXP.Size = new System.Drawing.Size(40, 19);
            this.lblMonsterEXP.TabIndex = 32;
            this.lblMonsterEXP.Text = "Exp.";
            // 
            // lblMonsterHP
            // 
            this.lblMonsterHP.AutoSize = true;
            this.lblMonsterHP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterHP.Location = new System.Drawing.Point(6, 40);
            this.lblMonsterHP.Name = "lblMonsterHP";
            this.lblMonsterHP.Size = new System.Drawing.Size(29, 19);
            this.lblMonsterHP.TabIndex = 4;
            this.lblMonsterHP.Text = "HP";
            // 
            // cmbMonsters
            // 
            this.cmbMonsters.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonsters.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonsters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonsters.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonsters.FormattingEnabled = true;
            this.cmbMonsters.Location = new System.Drawing.Point(6, 6);
            this.cmbMonsters.Name = "cmbMonsters";
            this.cmbMonsters.Size = new System.Drawing.Size(138, 27);
            this.cmbMonsters.TabIndex = 0;
            this.cmbMonsters.SelectedIndexChanged += new System.EventHandler(this.CmbMonsters_SelectedIndexChanged);
            // 
            // tabArmor
            // 
            this.tabArmor.Location = new System.Drawing.Point(4, 23);
            this.tabArmor.Name = "tabArmor";
            this.tabArmor.Padding = new System.Windows.Forms.Padding(3);
            this.tabArmor.Size = new System.Drawing.Size(836, 527);
            this.tabArmor.TabIndex = 5;
            this.tabArmor.Text = "Armor";
            this.tabArmor.UseVisualStyleBackColor = true;
            // 
            // tabWeapons
            // 
            this.tabWeapons.Location = new System.Drawing.Point(4, 23);
            this.tabWeapons.Name = "tabWeapons";
            this.tabWeapons.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeapons.Size = new System.Drawing.Size(836, 527);
            this.tabWeapons.TabIndex = 6;
            this.tabWeapons.Text = "Weapons";
            this.tabWeapons.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 594);
            this.Controls.Add(this.TabBar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FF1 Dawn of Souls Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabSpells.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSpellIndex)).EndInit();
            this.tabJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numJobsIndex)).EndInit();
            this.TabBar.ResumeLayout(false);
            this.tabEnemies.ResumeLayout(false);
            this.tabEnemies.PerformLayout();
            this.grpMonsterAttacks.ResumeLayout(false);
            this.grpMonsterAttacks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAbilityQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMagicQueue)).EndInit();
            this.grpItemDrops.ResumeLayout(false);
            this.grpItemDrops.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDropChance)).EndInit();
            this.grpMonsterFamily.ResumeLayout(false);
            this.grpMonsterFamily.PerformLayout();
            this.grpMonsterWeakElements.ResumeLayout(false);
            this.grpMonsterWeakElements.PerformLayout();
            this.grpMonsterResistElements.ResumeLayout(false);
            this.grpMonsterResistElements.PerformLayout();
            this.grpAttackStatus.ResumeLayout(false);
            this.grpAttackStatus.PerformLayout();
            this.grpMonsterAttackElements.ResumeLayout(false);
            this.grpMonsterAttackElements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMagDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterCritRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterIntellect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterAccuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterDefense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterNumHits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterEvasion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterMorale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterEXP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterGil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterHP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveROMToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabConsumables;
        private System.Windows.Forms.TabPage tabSpells;
        private System.Windows.Forms.Button btnSpellsCancel;
        private System.Windows.Forms.Button btnSpellsOkay;
        private System.Windows.Forms.NumericUpDown numSpellIndex;
        private System.Windows.Forms.ComboBox cmbSpells;
        private System.Windows.Forms.TabPage tabJobs;
        private System.Windows.Forms.Button btnActorsCancel;
        private System.Windows.Forms.Button btnActorsOkay;
        private System.Windows.Forms.TabControl TabBar;
        private System.Windows.Forms.TabPage tabEnemies;
        private System.Windows.Forms.NumericUpDown numMonsterIndex;
        private System.Windows.Forms.NumericUpDown numMonsterEXP;
        private System.Windows.Forms.NumericUpDown numMonsterGil;
        private System.Windows.Forms.NumericUpDown numMonsterHP;
        private System.Windows.Forms.Button btnMonstersCancel;
        private System.Windows.Forms.Button btnMonstersOkay;
        private System.Windows.Forms.Label lblMonsterGil;
        private System.Windows.Forms.Label lblMonsterEXP;
        private System.Windows.Forms.Label lblMonsterHP;
        private System.Windows.Forms.ComboBox cmbMonsters;
        private System.Windows.Forms.Label lblMonsterMorale;
        private System.Windows.Forms.NumericUpDown numMonsterMorale;
        private System.Windows.Forms.Label lblMonsterDefense;
        private System.Windows.Forms.Label lblMonsterEvasion;
        private System.Windows.Forms.Label lblMonsterAccuracy;
        private System.Windows.Forms.Label lblMonsterNumHits;
        private System.Windows.Forms.NumericUpDown numMonsterAccuracy;
        private System.Windows.Forms.NumericUpDown numMonsterDefense;
        private System.Windows.Forms.NumericUpDown numMonsterNumHits;
        private System.Windows.Forms.NumericUpDown numMonsterEvasion;
        private System.Windows.Forms.NumericUpDown numMonsterCritRate;
        private System.Windows.Forms.NumericUpDown numMonsterAgility;
        private System.Windows.Forms.NumericUpDown numMonsterIntellect;
        private System.Windows.Forms.NumericUpDown numMonsterAttack;
        private System.Windows.Forms.Label lblMonsterCritRate;
        private System.Windows.Forms.Label lblMonsterIntellect;
        private System.Windows.Forms.Label lblMonsterAgility;
        private System.Windows.Forms.Label lblMonsterAttack;
        private System.Windows.Forms.Label lblMonsterMagDef;
        private System.Windows.Forms.NumericUpDown numMonsterMagDef;
        private System.Windows.Forms.GroupBox grpMonsterAttackElements;
        private System.Windows.Forms.CheckBox chkMonsterAtkParalysis;
        private System.Windows.Forms.CheckBox chkMonsterAtkStone;
        private System.Windows.Forms.CheckBox chkMonsterAtkDeath;
        private System.Windows.Forms.CheckBox chkMonsterAtkTime;
        private System.Windows.Forms.CheckBox chkMonsterAtkQuake;
        private System.Windows.Forms.CheckBox chkMonsterAtkLightning;
        private System.Windows.Forms.CheckBox chkMonsterAtkIce;
        private System.Windows.Forms.CheckBox chkMonsterAtkFire;
        private System.Windows.Forms.CheckBox chkMonsterAtkMind;
        private System.Windows.Forms.CheckBox chkMonsterAtkConfusion;
        private System.Windows.Forms.CheckBox chkMonsterAtkSilence;
        private System.Windows.Forms.CheckBox chkMonsterAtkSleep;
        private System.Windows.Forms.CheckBox chkMonsterAtkDarkness;
        private System.Windows.Forms.CheckBox chkMonsterAtkPoison;
        private System.Windows.Forms.CheckBox chkMonsterAtkStConfusion;
        private System.Windows.Forms.CheckBox chkMonsterAtkStSilence;
        private System.Windows.Forms.CheckBox chkMonsterAtkStSleep;
        private System.Windows.Forms.CheckBox chkMonsterAtkStStun;
        private System.Windows.Forms.CheckBox chkMonsterAtkStBlind;
        private System.Windows.Forms.CheckBox chkMonsterAtkStPoison;
        private System.Windows.Forms.CheckBox chkMonsterAtkStStone;
        private System.Windows.Forms.CheckBox chkMonsterAtkStDeath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpAttackStatus;
        private System.Windows.Forms.GroupBox grpMonsterResistElements;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkMonsterResistMind;
        private System.Windows.Forms.CheckBox chkMonsterResistConfusion;
        private System.Windows.Forms.CheckBox chkMonsterResistSilence;
        private System.Windows.Forms.CheckBox chkMonsterResistSleep;
        private System.Windows.Forms.CheckBox chkMonsterResistDarkness;
        private System.Windows.Forms.CheckBox chkMonsterResistPoison;
        private System.Windows.Forms.CheckBox chkMonsterResistQuake;
        private System.Windows.Forms.CheckBox chkMonsterResistLightning;
        private System.Windows.Forms.CheckBox chkMonsterResistIce;
        private System.Windows.Forms.CheckBox chkMonsterResistFire;
        private System.Windows.Forms.CheckBox chkMonsterResistDeath;
        private System.Windows.Forms.CheckBox chkMonsterResistTime;
        private System.Windows.Forms.CheckBox chkMonsterResistStone;
        private System.Windows.Forms.CheckBox chkMonsterResistParalysis;
        private System.Windows.Forms.GroupBox grpMonsterWeakElements;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkMonsterWeakMind;
        private System.Windows.Forms.CheckBox chkMonsterWeakConfusion;
        private System.Windows.Forms.CheckBox chkMonsterWeakSilence;
        private System.Windows.Forms.CheckBox chkMonsterWeakSleep;
        private System.Windows.Forms.CheckBox chkMonsterWeakDarkness;
        private System.Windows.Forms.CheckBox chkMonsterWeakPoison;
        private System.Windows.Forms.CheckBox chkMonsterWeakQuake;
        private System.Windows.Forms.CheckBox chkMonsterWeakLightning;
        private System.Windows.Forms.CheckBox chkMonsterWeakIce;
        private System.Windows.Forms.CheckBox chkMonsterWeakFire;
        private System.Windows.Forms.CheckBox chkMonsterWeakDeath;
        private System.Windows.Forms.CheckBox chkMonsterWeakTime;
        private System.Windows.Forms.CheckBox chkMonsterWeakStone;
        private System.Windows.Forms.CheckBox chkMonsterWeakParalysis;
        private System.Windows.Forms.GroupBox grpMonsterFamily;
        private System.Windows.Forms.CheckBox chkMonsterFamMagical;
        private System.Windows.Forms.CheckBox chkMonsterFamRegenerative;
        private System.Windows.Forms.CheckBox chkMonsterFamDragon;
        private System.Windows.Forms.CheckBox chkMonsterFamGiant;
        private System.Windows.Forms.CheckBox chkMonsterFamSpellcaster;
        private System.Windows.Forms.CheckBox chkMonsterFamUndead;
        private System.Windows.Forms.CheckBox chkMonsterFamWerebeast;
        private System.Windows.Forms.CheckBox chkMonsterFamAquan;
        private System.Windows.Forms.GroupBox grpItemDrops;
        private System.Windows.Forms.Label lblDropType;
        private System.Windows.Forms.ComboBox cmbMonsterItemType;
        private System.Windows.Forms.NumericUpDown numDropChance;
        private System.Windows.Forms.Label lblDropChance;
        private System.Windows.Forms.GroupBox grpMonsterAttacks;
        private System.Windows.Forms.ComboBox cmbMonsterItemDrop;
        private System.Windows.Forms.Label lblMonsterSpell;
        private System.Windows.Forms.Label lblMonsterAbility;
        private System.Windows.Forms.ComboBox cmbMonsterAbility4;
        private System.Windows.Forms.ComboBox cmbMonsterAbility3;
        private System.Windows.Forms.ComboBox cmbMonsterAbility2;
        private System.Windows.Forms.ComboBox cmbMonsterAbility1;
        private System.Windows.Forms.NumericUpDown numMonsterAbilityQueue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMonsterMagicQueue;
        private System.Windows.Forms.Label lblMonsterMagicQueue;
        private System.Windows.Forms.ComboBox cmbMonsterSpell8;
        private System.Windows.Forms.ComboBox cmbMonsterSpell7;
        private System.Windows.Forms.ComboBox cmbMonsterSpell6;
        private System.Windows.Forms.ComboBox cmbMonsterSpell5;
        private System.Windows.Forms.ComboBox cmbMonsterSpell4;
        private System.Windows.Forms.ComboBox cmbMonsterSpell3;
        private System.Windows.Forms.ComboBox cmbMonsterSpell2;
        private System.Windows.Forms.ComboBox cmbMonsterSpell1;
        private System.Windows.Forms.NumericUpDown numJobsIndex;
        private System.Windows.Forms.ComboBox cmbJobs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabArmor;
        private System.Windows.Forms.TabPage tabWeapons;
    }
}

