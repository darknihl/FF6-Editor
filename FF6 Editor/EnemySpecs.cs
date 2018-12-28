using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF6_Editor
{
    [Flags]
    public enum MonsterFlagsA : ushort
    {
        MPDeath = 0x1, // Dies on 0 MP
        IgnoreITD= 0x2, // Ignores Ignore Target Defense
        NameHide = 0x4, // Hides enemy's name
        PierceReflect = 0x8, // Ignores reflect status
        Humanoid = 0x10, // Human enemy
        UnknownA = 0x20, // Unknown value
        ImpSucks = 0x40, // Critical hit when Imped
        Undead = 0x80, // What it says on the tin
        FlightRisky = 0x100, // Harder to run from
        Preemptive = 0x200, // Attacks first
        NoSuplex = 0x400, // Cannot be Suplexed
        FlightBanned = 0x800, // Can't run
        NoScan = 0x1000, // Cannot be Scanned
        NoSketch = 0x2000, // Cannot be Sketched
        Event = 0x4000, // Special Event
        NoControl = 0x8000 // Cannot be Controlled
    }

    [Flags]
    public enum Status : uint
    {
        Darkness = 0x1,                    // Block Darkness
	    Zombie = 0x2,                      // Block Zombie
	    Poison = 0x4,                      // Block Poison
	    Magitek = 0x8,                     // Block Magitek
	    Clear = 0x10,                      // Block Clear
	    Imp = 0x20,                        // Block Imp
	    Petrify = 0x40,                    // Block Petrify
	    Death = 0x80,                      // Block Death
        Doomed = 0x100,                    // Block Doomed
	    Critical = 0x200,                  // Block Near Fatal
	    Blink = 0x400,                     // Block Image
	    Silence = 0x800,                   // Block Silence
	    Berserk = 0x1000,                  // Block Berserk
	    Confuse = 0x2000,                // Block Confusion
	    Sap = 0x4000,                      // Block Sap
	    Sleep = 0x8000,                    // Block Sleep
        Dance = 0x10000,                   // Block Dance / Start with Float
	    Regen = 0x20000,                   // Block Regen
	    Slow = 0x40000,                    // Block Slow
	    Haste = 0x80000,                   // Block Haste
	    Stop = 0x100000,                   // Block Stop
	    Shell = 0x200000,                  // Block Shell
	    Protect = 0x400000,                // Block Protect
	    Reflect = 0x800000                 // Block Reflect
    }

    [Flags]
    public enum Element : byte
    {
        Fire = 0x1,
        Ice = 0x2,
        Thunder = 0x4,
        Poison = 0x8,
        Wind = 0x10,
        Holy = 0x20,
        Earth = 0x40,
        Water = 0x80
    }

    [Flags]
    public enum MonsterFlagsB : byte
    {
        Cover = 0x1,                // True Knight effect
        Runic = 0x2,                // Runic
        Reraise = 0x4,              // Reraise
        UnknownA = 0x8,             // Unknown value
        UnknownB = 0x10,            // Unknown value
        UnknownC = 0x20,            // Unknown value
        UnknownD = 0x40,            // Unknown value
        Float = 0x80                // Removable Float
    }

    [Flags]
    public enum SpecialAttackAttributesFlags : byte
    {
        NoDamage = 0x40,
        NoDodge = 0x80
    }

    public class EnemySpecs
    {
        RomFileIO Rom = new RomFileIO();
        public byte Agility;
        public byte Attack;
        public byte Accuracy;
        public byte Evasion;
        public byte MagEva;
        public byte Defense;
        public byte MagDef;
        public byte Magic;
        public ushort HP;
        public byte LP;
        public ushort MP;
        public ushort XP;
        public ushort Gil;
        public byte Level;
        public byte SkillExp;
        public byte MetaMiss;
        public MonsterFlagsA FlagsA;
        public Status BlockStatus;
        public Element Absorb;
        public Element Nullify;
        public Element Weakness;
        public Element ElemAtk;
        public byte AttackAnimation;
        public Status StartStatus;
        public MonsterFlagsB FlagsB;
        public int SpecialAttack;
        public int SpecialAttackEffects;
        public SpecialAttackAttributesFlags SpecialAttackFlags;
        public byte Strength;
        public Element Half;
        public byte Vitality;
        public byte RareSteal;
        public byte CommonSteal;
        public byte RareDrop;
        public byte CommonDrop;
        public byte Rage1;
        public byte Rage2;
        public byte Sketch1;
        public byte Sketch2;
        public byte Control1;
        public byte Control2;
        public byte Control3;
        public byte Control4;

        /*byte[] BinaryHP()
        {
            byte[] ret = new byte[3];

            ret[0] = Convert.ToByte(HP & 0xFF);
            ret[1] = Convert.ToByte((HP & 0xFF00) >> 8);
            ret[2] = Convert.ToByte((HP & 0xFF0000) >> 16);

            return ret;
        }*/

        public void ReadMonsterNormal(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Agility = Rom.Read8(BaseOffset + MonsterIndex + MonsterDifficulty);
                Attack = Rom.Read8();
                Accuracy = Rom.Read8();
                Evasion = Rom.Read8();
                MagEva = Rom.Read8();
                Defense = Rom.Read8();
                MagDef = Rom.Read8();
                Magic = Rom.Read8();
                //Rom.Read16(); // old HP int
                ElemAtk = (Element)Rom.Read8();
                Rom.Read8(); // old HP int upper byte
                MP = Rom.Read16();
                XP = Rom.Read16();
                Gil = Rom.Read16();
                Level = Rom.Read8();
                SkillExp = Rom.Read8(); // Metamorph byte
                FlagsA = (MonsterFlagsA)Rom.Read16();
                BlockStatus = (Status)Rom.Read24();
                Absorb = (Element)Rom.Read8();
                Nullify = (Element)Rom.Read8();
                Weakness = (Element)Rom.Read8();
                AttackAnimation = Rom.Read8();
                StartStatus = (Status)Rom.Read24();
                FlagsB = (MonsterFlagsB)Rom.Read8();
                SpecialAttack = Rom.Read8();
                SpecialAttackFlags = (SpecialAttackAttributesFlags)SpecialAttack;
           }
        }

        public void ReadMonsterSecondary(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Strength = Rom.Read8(BaseOffset + MonsterIndex + MonsterDifficulty);
                Half = (Element)Rom.Read8();
                Vitality = Rom.Read8();
            }
        }

        public void ReadMonsterHP(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                HP = Rom.Read16(BaseOffset + MonsterIndex + MonsterDifficulty);
                LP = Rom.Read8();
            }
        }

        public void ReadMonsterDropsSteals(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                RareSteal = Rom.Read8(BaseOffset + MonsterIndex);
                CommonSteal = Rom.Read8();
                RareDrop = Rom.Read8();
                CommonDrop = Rom.Read8();
            }
        }

        public void ReadRage(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rage1 = Rom.Read8(BaseOffset + MonsterIndex);
                Rage2 = Rom.Read8();
            }
        }

        public void ReadSketch(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Sketch1 = Rom.Read8(BaseOffset + MonsterIndex);
                Sketch2 = Rom.Read8();
            }
        }

        public void ReadControl(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Control1 = Rom.Read8(BaseOffset + MonsterIndex);
                Control2 = Rom.Read8();
                Control3 = Rom.Read8();
                Control4 = Rom.Read8();
            }
        }

        public void WriteMonsterNormal(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(Agility, BaseOffset + MonsterIndex + MonsterDifficulty);
                Rom.Write8(Attack);
                Rom.Write8(Accuracy);
                Rom.Write8(Evasion);
                Rom.Write8(MagEva);
                Rom.Write8(Defense);
                Rom.Write8(MagDef);
                Rom.Write8(Magic);
                Rom.Write8((byte)ElemAtk);
                Rom.Read8();
                Rom.Write16(MP);
                Rom.Write16(XP);
                Rom.Write16(Gil);
                Rom.Write8(Level);
                Rom.Write8(SkillExp);
                Rom.Write16((ushort)FlagsA);
                Rom.Write24((uint)BlockStatus);
                Rom.Write8((byte)Absorb);
                Rom.Write8((byte)Nullify);
                Rom.Write8((byte)Weakness);
                Rom.Write8(AttackAnimation);
                Rom.Write24((uint)StartStatus);
                Rom.Write8((byte)FlagsB);
                Rom.Write8((byte)SpecialAttack);
            }
        }

        public void WriteMonsterSecondary(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(Strength, BaseOffset + MonsterIndex + MonsterDifficulty);
                Rom.Write8((byte)Half);
                Rom.Write8(Vitality);
            }
        }

        public void WriteMonsterHP(RomFileIO Rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write16(HP, BaseOffset + MonsterIndex + MonsterDifficulty);
                Rom.Write8(LP);
            }
        }

        public void WriteMonsterStealsDrops(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(RareSteal, BaseOffset + MonsterIndex);
                Rom.Write8(CommonSteal);
                Rom.Write8(RareDrop);
                Rom.Write8(CommonDrop);
            }
        }


        public void WriteRage(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(Rage1, BaseOffset + MonsterIndex);
                Rom.Write8(Rage2);
            }
        }


        public void WriteSketch(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(Sketch1, BaseOffset + MonsterIndex);
                Rom.Write8(Sketch2);
            }
        }


        public void WriteControl(RomFileIO Rom, int BaseOffset, int MonsterIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8(Control1, BaseOffset + MonsterIndex);
                Rom.Write8(Control2);
                Rom.Write8(Control3);
                Rom.Write8(Control4);
            }
        }
    }
}
