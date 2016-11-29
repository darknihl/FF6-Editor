using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF6_Editor
{
    public enum SpellStatus : uint
    {
        Darkness = 0x1,                    
        Zombie = 0x2,                      
        Poison = 0x4,                      
        Magitek = 0x8,                     
        Clear = 0x10,                      
        Imp = 0x20,                        
        Petrify = 0x40,                    
        Death = 0x80,                      
        Doomed = 0x100,                    
        Critical = 0x200,                  
        Blink = 0x400,                     
        Silence = 0x800,                   
        Berserk = 0x1000,                  
        Confuse = 0x2000,                
        Sap = 0x4000,                      
        Sleep = 0x8000,                    
        Dance = 0x10000,                   
        Regen = 0x20000,                   
        Slow = 0x40000,                    
        Haste = 0x80000,                   
        Stop = 0x100000,                   
        Shell = 0x200000,                  
        Protect = 0x400000,                
        Reflect = 0x800000,
        Rage = 0x1000000,
        Freeze = 0x2000000,
        Reraise = 0x4000000,
        Trance = 0x8000000,
        Chanting = 0x10000000,
        Disappear = 0x20000000,
        DogBlock = 0x40000000,
        Float = 0x80000000
    }

    [Flags]
    public enum SpellElement : byte
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
    public enum SpellTargetting : byte
    {
        MoveCursor = 0x1,
        OneSide = 0x2,
        AutoBothParties = 0x4,
        AutoOneParty = 0x8,
        AutoConfirm = 0x10,
        ToggleMulti = 0x20,
        StartEnemy = 0x40,
        RandomSelect = 0x80
    }

    [Flags]
    public enum SpellSpecial1 : byte
    {
        PhysDamage = 0x1,
        MissDeathProt = 0x2,
        TargetDead = 0x4,
        InvertDamage = 0x8,
        RandomTarget = 0x10,
        IgnoreDefense = 0x20,
        NoSplit = 0x40,
        AbortAllies = 0x80
    }

    [Flags]
    public enum SpellMisc : byte
    {
        FieldUse = 0x1,
        NoReflect = 0x2,
        LearnIfTarget = 0x4,
        EnableRunic = 0x8,
        Unknown = 0x10,
        RetargetIfDead = 0x20,
        CasterDies = 0x40,
        AffectMP = 0x80
    }

    [Flags]
    public enum SpellSpecial2 : byte
    {
        Restore = 0x1,
        Absorb = 0x2,
        RemoveStatus = 0x4,
        ToggleStatus = 0x8,
        StaminaDefense = 0x10,
        NoEvade = 0x20,
        SuccessMult = 0x40,
        Fractional = 0x80
    }

    [Flags]
    public enum SpellSpecial3 : byte
    {
        MissProtStatus = 0x1,
        TextIfHits = 0x2,
        ReplaceWithVitality = 0x4,
        UnknownA = 0x8,
        UnknownB = 0x10,
        UnknownC = 0x20,
        UnknownD = 0x40,
        HalfITD = 0x80
    }

    public class Spells
    {
        RomFileIO Rom = new RomFileIO();
        public SpellTargetting Targetting;
        public SpellElement ElementProps;
        public SpellSpecial1 Special1;
        public SpellMisc Misc;
        public SpellSpecial2 Special2;
        public byte MPCost;
        public byte Power;
        public SpellSpecial3 Special3;
        public byte Success;
        public byte Effect;
        public SpellStatus Status;
        public byte SpellDelay;

        public void ReadSpellData(RomFileIO Rom, int BaseOffset, int SpellIndex, int SpellDelayIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Targetting = (SpellTargetting)Rom.Read8(BaseOffset + SpellIndex);
                ElementProps = (SpellElement)Rom.Read8();
                Special1 = (SpellSpecial1)Rom.Read8();
                Misc = (SpellMisc)Rom.Read8();
                Special2 = (SpellSpecial2)Rom.Read8();
                MPCost = Rom.Read8();
                Power = Rom.Read8();
                Special3 = (SpellSpecial3)Rom.Read8();
                Success = Rom.Read8();
                Effect = Rom.Read8();
                Status = (SpellStatus)Rom.Read32();
                SpellDelay = Rom.Read8(RomData.SPELL_DELAY + SpellDelayIndex);
            }
        }

        public void WriteSpellData(RomFileIO Rom, int BaseOffset, int SpellIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                Rom.Write8((byte)Targetting, BaseOffset + SpellIndex);
                Rom.Write8((byte)ElementProps);
                Rom.Write8((byte)Special1);
                Rom.Write8((byte)Misc);
                Rom.Write8((byte)Special2);
                Rom.Write8(MPCost);
                Rom.Write8(Power);
                Rom.Write8((byte)Special3);
                Rom.Write8(Success);
                Rom.Write8(Effect);
                Rom.Write32((uint)Status);
            }
        }


    }
}
