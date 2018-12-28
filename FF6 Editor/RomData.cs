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
using FF1_DOS_editor;


namespace FF1_DOS_editor
{
    public class RomData
    {
        public const int MONSTER_DATA_OFFSET = 0x1DE044; // 32 bytes per monster, 195 entries
        public const int MONSTER_ATTACK_ANIM_OFFSET = 0x223540; // 1 byte per, 195 entries
        //public const int MONSTER_ATTACKS_TABLE_INDEX_OFFSET = 0x22F0B8; // 1 byte per monster, 195 entries
        public const int MONSTER_ATTACKS_DEFINITIONS_OFFSET = 0xEE0760; // 16 bytes per entries, 195 entries
        public const int SPELL_DATA_OFFSET = 0x1A1980; // 16 bytes, 116 entries
        public const int SPELL_USABILITY_DATA_OFFSET = 0x1A20C0;
        public const int CONSUMABLE_ITEM_DATA_OFFSET = 0x19F07C;
        public const int WEAPONS_DATA_OFFSET = 0X19F33C;
        public const int ARMOR_DATA_OFFSET = 0x19FA58;
        public const int JOB_INIT_DATA_OFFSET = 0x1e1354; // 16 bytes, 6 entries
        public const int EXPERIENCE_TABLE_OFFSET = 0x1be3b8; // 4 bytes, 98 entries

    }
}