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
using FF6_Editor;


namespace FF6_Editor
{
    public class RomData
    {
        public const int CHAR_DATA = 0x3301F4; // Specifically, character growth structs, which are (stat*1500) per stat, in order of character index.
        public const int NATURAL_MAGIC_DATA = 0x03FE60; // 32 byte structe; (spell : level) * 16
        public const int ESPER_MAGIC_DATA = 0x186E00; // 11 byte struct; ten are spells, one unused.
        public const int ESPER_BONUS_DATA = 0x332CC0; // 20 byte struct
        public const int MONSTER_STATS_NORMAL_DATA = 0x333530; // 384 entries, 32 byte struct, 1000 byte buffer for expansion 
        //public const int MONSTER_STATS_EASY_DATA = 0x337530; // 384 entries, 32 byte struct, 1000 byte buffer for expansion 
        //public const int MONSTER_STATS_HARD_DATA = 0x33B530; // 384 entries, 32 byte struct, 1000 byte buffer for expansion
        public const int MONSTER_STATS_NORMAL_SECONDARY_DATA = 0x0F0000; // 384 entries, 3 byte struct
        //public const int MONSTER_STATS_EASY_SECONDARY_DATA = 0X0F0600; // 384 entries, 3 byte struct
        //public const int MONSTER_STATS_HARD_SECONDARY_DATA = 0x0F0C00; // 384 entries, 3 byte struct
        //public const int MONSTER_HP_HIGH_BYTE_NORMAL = 0x0F1200;
        //public const int MONSTER_HP_HIGH_BYTE_EASY = 0x0F1400;
        //public const int MONSTER_HP_HIGH_BYTE_HARD = 0x0F1600;
        public const int MONSTER_HP_NORMAL = 0x0F1200;
        //public const int MONSTER_HP_EASY = 0x0F1800;
        //public const int MONSTER_HP_HARD = 0x0F1E00;
        public const int MONSTER_AI_NORMAL_POINTERS = 0x0F8400; // 384 entries, 2 bytes each
        public const int MONSTER_AI_NORMAL_BANK = 0x3E0000; // 384 entries, variable length
        public const int MONSTER_AI_HARD_POINTERS = 0x0;
        public const int MONSTER_AI_HARD_BANK = 0x0;
    }
}
