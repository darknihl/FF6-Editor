using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF6_Editor
{
    public enum CharEquip : ushort
    {
        Terra = 0x1,
        Locke = 0x2,
        Cyan = 0x4,
        Shadow = 0x8,
        Edgar = 0x10,
        Sabin = 0x20,
        Celes = 0x40,
        Strago = 0x80,
        Relm = 0x100,
        Setzer = 0x200,
        Mog = 0x400,
        Gau = 0x800,
        Gogo = 0x1000,
        Umaro = 0x2000
    }

    public enum EsperStats : byte
    {
        Strength = 0x1,
        Agility = 0x2,
        Vitality = 0x4,
        Magic = 0x8
    }

    class Espers
    {
        RomFileIO Rom = new RomFileIO();
        public CharEquip CharEquip;
        public EsperStats EsperStats;         

        public void ReadCharEquip(RomFileIO Rom, int BaseOffset, int EsperIndex)
        {
            CharEquip = (CharEquip)Rom.Read16(BaseOffset + EsperIndex);
        }

        public void WriteCharEquip(RomFileIO Rom, int BaseOffset, int EsperIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write16((ushort)CharEquip, BaseOffset + EsperIndex);
            }
        }

        public void ReadEsperStatRestrictions(RomFileIO Rom, int BaseOffset, int EsperIndex)
        {
            EsperStats = (EsperStats)Rom.Read8(BaseOffset + EsperIndex);
        }

        public void WriteEsperStatsRestrictions(RomFileIO Rom, int BaseOffset, int EsperIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8((byte)EsperStats, BaseOffset + EsperIndex);
            }
        }
    }
}
