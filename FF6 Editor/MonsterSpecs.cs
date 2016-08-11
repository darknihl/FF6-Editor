using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF6_Editor
{
    [Flags]
    enum MonsterFlagsA : ushort
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
    enum StatusBlock : uint
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
        Dance = 0x10000,                   // Block Dance
	    Regen = 0x20000,                   // Block Regen
	    Slow = 0x40000,                    // Block Slow
	    Haste = 0x80000,                   // Block Haste
	    Stop = 0x100000,                   // Block Stop
	    Shell = 0x200000,                  // Block Shell
	    Protect = 0x400000,                // Block Protect
	    Reflect = 0x800000                 // Block Reflect
    }

    [Flags]
    enum StatusBegin : uint
    {
        Darkness = 0x1,                    // Start with Darkness
        Zombie = 0x2,                      // Start with Zombie
        Poison = 0x4,                      // Start with Poison
        Magitek = 0x8,                     // Start with Magitek
        Clear = 0x10,                      // Start with Clear
        Imp = 0x20,                        // Start with Imp
        Petrify = 0x40,                    // Start with Petrify
        Death = 0x80,                      // Start with Death
        Doomed = 0x100,                    // Start with Doomed
        Critical = 0x200,                  // Start with Near Fatal
        Blink = 0x400,                     // Start with Image
        Silence = 0x800,                   // Start with Silence
        Berserk = 0x1000,                  // Start with Berserk
        Confusion = 0x2000,                // Start with Confusion
        Sap = 0x4000,                      // Start with Sap
        Sleep = 0x8000,                    // Start with Sleep
        Float = 0x10000,                   // Start with Dance
        Regen = 0x20000,                   // Start with Regen
        Slow = 0x40000,                    // Start with Slow
        Haste = 0x80000,                   // Start with Haste
        Stop = 0x100000,                   // Start with Stop
        Shell = 0x200000,                  // Start with Shell
        Protect = 0x400000,                // Start with Protect
        Reflect = 0x800000                 // Start with Reflect
    }

    [Flags]
    enum Element : byte
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
    enum MonsterFlagsB : byte
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

    enum SpecialAttackAttributes : byte
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
        Unknown14 = 0x3F
    };

    [Flags]
    enum SpecialAttackAttributesFlags : byte
    {
        NoDamage = 0x40,
        NoDodge = 0x80
    }

    class MonsterSpecs
    {
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
        public StatusBlock BlockStatus;
        public Element Absorb;
        public Element Nullify;
        public Element Weakness;
        public byte AttackAnimation;
        public StatusBegin StartStatus;
        public MonsterFlagsB FlagsB;
        public SpecialAttackAttributes SpecialAttackAttributes;
        public byte Strength;
        public Element Half;
        public byte Vitality;

        byte[] BinaryHP()
        {
            byte[] ret = new byte[3];

            ret[0] = Convert.ToByte(HP & 0xFF);
            ret[1] = Convert.ToByte((HP & 0xFF00) >> 8);
            ret[2] = Convert.ToByte((HP & 0xFF0000) >> 16);

            return ret;
        }

        byte[] BinaryMP()
        {
            byte[] ret = new byte[2];

            ret[0] = Convert.ToByte(MP & 0xFF);
            ret[1] = Convert.ToByte((MP & 0xFF00) >> 8);

            return ret;
        }

        byte[] BinaryXP()
        {
            byte[] ret = new byte[2];

            ret[0] = Convert.ToByte(XP & 0xFF);
            ret[1] = Convert.ToByte((XP & 0xFF00) >> 8);

            return ret;
        }

        byte[] BinaryGil()
        {
            byte[] ret = new byte[2];

            ret[0] = Convert.ToByte(Gil & 0xFF);
            ret[1] = Convert.ToByte((Gil & 0xFF00) >> 8);

            return ret;
        }
        /*
        byte[] BinaryFlagsA()
        {
            // ... 
            

        }
        byte[] BinaryFlagsB()
        {
            // ...
        }

        byte[] ElementsAbsorb()
        {
            
        }

        byte[] ElementsNull()
        {

        }

        byte[] ElementsWeak()
        {

        }

        byte[] ElementsHalf()
        {

        }
        */
        public void ReadMonsterStats()
        {
            Agility = 
        }

        byte[] ToBinary()
        {
            byte[] ret = new byte[21];
            byte[] hp = BinaryHP();
            byte[] mp = BinaryMP();
            byte[] xp = BinaryXP();
            byte[] gil = BinaryGil();

            ret[0] = Agility;
            ret[1] = Attack;
            ret[2] = Accuracy;
            ret[3] = Evasion;
            ret[4] = MagEva;
            ret[5] = Defense;
            ret[6] = MagDef;
            ret[7] = MagDef;
            ret[8] = 0;
            ret[9] = 0;
            for (byte i = 0; i < 2; i++)
            {
                ret[10 + i] = mp[i];
            }
            for (byte i = 0; i < 2; i++)
            {
                ret[12 + i] = xp[i];
            }
            for (byte i = 0; i < 2; i++)
            {
                ret[14 + i] = gil[i];
            }
            ret[16] = Level;
            ret[17] = Metamorph;
            ret[18] = MetaMiss;
            ret[19] = AttackAnimation;
            ret[20] = Strength;
            ret[21] = Vitality;

        }
    }
}
