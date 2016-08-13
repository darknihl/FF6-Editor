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
        ReflectPierce = 0x2, // Ignores Reflect status
        NameHide = 0x4, // Hides enemy's name
        UnknownA = 0x8, // Unknown value
        Humanoid = 0x10, // Human enemy
        UnknownB = 0x20, // Unknown value
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
	    Confusion = 0x2000,                // Block Confusion
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

    /*public enum SpecialAttackAttributes : byte
    {
        Blind = 0x00,
        Zombie = 0x01,
        Poison = 0x02,
        Magitek = 0x03,
        Clear = 0x04,
        Imp = 0x05,
        Petrify = 0x06,
        Dead = 0x07,
        Condemned = 0x08,
        NearFatal = 0x09,
        Image = 0x0A,
        Mute = 0x0B,
        Berserk = 0x0C,
        Muddle = 0x0D,
        Seizure = 0x0E,
        Psyche = 0x0F,
        Dance = 0x10,
        Regen = 0x11,
        Slow = 0x12,
        Haste = 0x13,
        Stop = 0x14,
        Shell = 0x15,
        Safe = 0x16,
        Wall = 0x17,
        Rage = 0x18,
        Frozen = 0x19,
        Life3 = 0x1A,
        EsperMorph = 0x1B,
        MagicCast = 0x1C,
        Disappear = 0x1D,
        Interceptor = 0x1E,
        Float = 0x1F,
        AttackPower1 = 0x20,
        AttackPower2 = 0x21,
        AttackPower3 = 0x22,
        AttackPower4 = 0x23,
        AttackPower5 = 0x24,
        AttackPower6 = 0x25,
        AttackPower7 = 0x26,
        AttackPower8 = 0x27,
        AttackPower9 = 0x28,
        AttackPower10 = 0x29,
        AttackPower11 = 0x2A,
        AttackPower12 = 0x2B,
        AttackPower13 = 0x2C,
        AttackPower14 = 0x2D,
        AttackPower15 = 0x2E,
        AttackPower16 = 0x2F,
        AbsorbHP = 0x30,
        AbsorbMP = 0x31,
        Unknown1 = 0x32,
        Unknown2 = 0x33,
        Unknown3 = 0x34,
        Unknown4 = 0x35,
        Unknown5 = 0x36,
        Unknown6 = 0x37,
        Unknown7 = 0x38,
        Unknown8 = 0x39,
        Unknown9 = 0x3A,
        Unknown10 = 0x3B,
        Unknown11 = 0x3C,
        Unknown12 = 0x3D,
        Unknown13 = 0x3E,
        Unknown14 = 0x3F,
        NoDamage = 0x40,
        NoDodge = 0x80
    };
    */

    [Flags]
    public enum SpecialAttackAttributesFlags : byte
    {
        NoDamage = 0x40,
        NoDodge = 0x80
    }

    public class MonsterSpecs
    {
        RomFileIO rom = new RomFileIO();
        public byte Agility;
        public byte Attack;
        public byte Accuracy;
        public byte Evasion;
        public byte MagEva;
        public byte Defense;
        public byte MagDef;
        public byte Magic;
        public uint HP;
        public ushort MP;
        public ushort XP;
        public ushort Gil;
        public byte Level;
        public byte Metamorph;
        public byte MetaMiss;
        public MonsterFlagsA FlagsA;
        public Status BlockStatus;
        public Element Absorb;
        public Element Nullify;
        public Element Weakness;
        public byte AttackAnimation;
        public Status StartStatus;
        public MonsterFlagsB FlagsB;
        public int SpecialAttack;
        public int SpecialAttackEffects;
        public SpecialAttackAttributesFlags SpecialAttackFlags;
        public byte Strength;
        public Element Half;
        public byte Vitality;

        /*byte[] BinaryHP()
        {
            byte[] ret = new byte[3];

            ret[0] = Convert.ToByte(HP & 0xFF);
            ret[1] = Convert.ToByte((HP & 0xFF00) >> 8);
            ret[2] = Convert.ToByte((HP & 0xFF0000) >> 16);

            return ret;
        }*/

        public void ReadMonsterNormal(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Agility = rom.Read8(BaseOffset + MonsterIndex + MonsterDifficulty);
                Attack = rom.Read8();
                Accuracy = rom.Read8();
                Evasion = rom.Read8();
                MagEva = rom.Read8();
                Defense = rom.Read8();
                MagDef = rom.Read8();
                Magic = rom.Read8();
                rom.Read16(); // old HP int
                MP = rom.Read16();
                XP = rom.Read16();
                Gil = rom.Read16();
                Level = rom.Read8();
                rom.Read8(); // Metamorph byte
                FlagsA = (MonsterFlagsA)rom.Read16();
                BlockStatus = (Status)rom.Read24();
                Absorb = (Element)rom.Read8();
                Nullify = (Element)rom.Read8();
                Weakness = (Element)rom.Read8();
                AttackAnimation = rom.Read8();
                StartStatus = (Status)rom.Read24();
                FlagsB = (MonsterFlagsB)rom.Read8();
                SpecialAttack = rom.Read8();
                SpecialAttackFlags = (SpecialAttackAttributesFlags)SpecialAttack;
           }
        }

        public void ReadMonsterSecondary(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Strength = rom.Read8(BaseOffset + MonsterIndex + MonsterDifficulty);
                Half = (Element)rom.Read8();
                Vitality = rom.Read8();
            }
        }

        public void ReadMonsterHP(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                HP = rom.Read24(BaseOffset + MonsterIndex + MonsterDifficulty);
            }
        }

        public void WriteMonsterNormal(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                rom.Write8(Agility, BaseOffset + MonsterIndex + MonsterDifficulty);
                rom.Write8(Attack);
                rom.Write8(Accuracy);
                rom.Write8(Evasion);
                rom.Write8(MagEva);
                rom.Write8(Defense);
                rom.Write8(MagDef);
                rom.Write8(Magic);
                rom.Read16();
                rom.Write16(MP);
                rom.Write16(XP);
                rom.Write16(Gil);
                rom.Write8(Level);
                rom.Read8(); // Ragnarok metamorph byte
                rom.Write16((ushort)FlagsA);
                rom.Write24((uint)BlockStatus);
                rom.Write8((byte)Absorb);
                rom.Write8((byte)Nullify);
                rom.Write8((byte)Weakness);
                rom.Write8(AttackAnimation);
                rom.Write24((uint)StartStatus);
                rom.Write8((byte)FlagsB);
                rom.Write8((byte)SpecialAttack);
            }
        }

        public void WriteMonsterSecondary(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                rom.Write8(Strength, BaseOffset + MonsterIndex + MonsterDifficulty);
                rom.Write8(Convert.ToByte(Half));
                rom.Write8(Vitality);
            }
        }

        public void WriteMonsterHP(RomFileIO rom, int BaseOffset, int MonsterIndex, int MonsterDifficulty)
        {
            if (!rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                rom.Write24(HP, BaseOffset + MonsterIndex + MonsterDifficulty);
            }
        }
    }
}
