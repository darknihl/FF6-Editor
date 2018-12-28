using System;
using System.IO;

namespace FF1_DOS_editor
{
    [Flags]
    public enum StatusEffect : byte
    {
        Death = 0x1,
        Stone = 0x2,
        Poison = 0x4,
        Blind = 0x8,
        Stun = 0x10,
        Sleep = 0x20,
        Silence = 0x40,
        Confusion = 0x80
    }

    [Flags]
    public enum MonsterFamily : byte
    {
        Magical = 0x1,
        Dragon = 0x2,
        Giant = 0x4,
        Undead = 0x8,
        Werebeast = 0x10,
        Aquan = 0x20,
        Spellcaster = 0x40,
        Regenerative = 0x80
    }

    [Flags]
    public enum Element : ushort
    {
        Paralysis = 0x1,
        Stone = 0x2,
        Time = 0x4,
        Death = 0x8,
        Fire = 0x10,
        Ice = 0x20,
        Lightning = 0x40,
        Quake = 0x80,
        Poison = 0x100,
        Darkness = 0x200,
        Sleep = 0x400,
        Silence = 0x800,
        Confuse = 0x1000,
        Mind = 0x2000
    }

    public class EnemySpecs
    {
        //Defines
        RomFileIO Rom = new RomFileIO();
        public ushort EXP;
        public ushort Gil;
        public ushort MaxHP;
        public byte Morale;
        //Empty byte, originally for AI
        public byte Evasion;
        public byte Defense;
        public byte NumHits;
        public byte Accuracy;
        public byte Attack;
        public byte Agility;
        public byte Intellect;
        public byte CritRate;
        public Element AttackElement;
        public StatusEffect AttackStatus;
        public MonsterFamily MonsterFamily;
        public byte MagDef;
        //Empty byte, likely padding
        public Element Weak;
        public Element Resist;
        public byte DropType;
        public byte ItemDropped;
        public byte DropChance;
        public byte MagicProc;
        public byte AbilityProc;
        public byte Spell1;
        public byte Spell2;
        public byte Spell3;
        public byte Spell4;
        public byte Spell5;
        public byte Spell6;
        public byte Spell7;
        public byte Spell8;
        public byte Ability1;
        public byte Ability2;
        public byte Ability3;
        public byte Ability4;
        public string[] SpellList = File.ReadAllLines("spells.txt");
        public string[] AbilityList = File.ReadAllLines("abilities.txt");
        public string[] MonsterList = File.ReadAllLines("monsters.txt");

        //Methods
        public void ReadMonsterNormal(RomFileIO Rom, int BaseOffset, int MonsterIndex, int BaseScript, int MonsterQueue)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                EXP = Rom.Read16(BaseOffset + MonsterIndex); // 00-01
                Gil = Rom.Read16(); // 02-03
                MaxHP = Rom.Read16(); // 04-05
                Morale = Rom.Read8(); // 06
                Rom.Read8(); // skip a byte 07
                Evasion = Rom.Read8(); // 08
                Defense = Rom.Read8(); // 09
                NumHits = Rom.Read8(); // 0A
                Accuracy = Rom.Read8(); // 0B
                Attack = Rom.Read8(); // 0C
                Agility = Rom.Read8(); // 0D
                Intellect = Rom.Read8(); // 0E
                CritRate = Rom.Read8(); // 0F
                AttackElement = (Element)Rom.Read16(); // 10-11
                AttackStatus = (StatusEffect)Rom.Read8(); // 12
                MonsterFamily = (MonsterFamily)Rom.Read8(); // 13
                MagDef = Rom.Read8(); // 14
                Rom.Read8(); // skip a byte 15
                Weak = (Element)Rom.Read16(); // 16-17
                Resist = (Element)Rom.Read16(); // 18-19
                DropType = Rom.Read8(); // 1A
                ItemDropped = Rom.Read8(); // 1B
                DropChance = Rom.Read8(); // 1C
                // 1D, 1E, 1F

                MagicProc = Rom.Read8(BaseScript + MonsterQueue); // Magic proc value
                AbilityProc = Rom.Read8(); // Ability proc value
                Spell1 = Rom.Read8(); // spells 1-8 in the spell queue
                Spell2 = Rom.Read8();
                Spell3 = Rom.Read8();
                Spell4 = Rom.Read8();
                Spell5 = Rom.Read8();
                Spell6 = Rom.Read8();
                Spell7 = Rom.Read8();
                Spell8 = Rom.Read8();
                Rom.Read8(); // extra terminator if you have the whole queue filled
                Ability1 = Rom.Read8();
                Ability2 = Rom.Read8();
                Ability3 = Rom.Read8();
                Ability4 = Rom.Read8();
                //Another terminator; no point reading

           }
        }


        public void WriteMonsterNormal(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write16(EXP, BaseOffset + MonsterIndex);

            }
        }
    }
}
