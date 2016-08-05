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
        public const int MONSTER_STATS_DATA = 0x0F0000; // 32 byte struct
        public const int MONSTER_AI_NORMALPOINTERS = 0x0F8400; // 386 entries, 2 bytes each
        public const int MONSTER_AI_NORMALBANK = 0x3E0000; // 386 entries, variable length
    }
}
