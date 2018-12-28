using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF1_DOS_editor
{
 /*   public enum SpellStatus : uint
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
*/
    public class Spells
    {
        RomFileIO Rom = new RomFileIO();
        //public SpellTargetting Targetting;


        public void ReadSpellData(RomFileIO Rom, int BaseOffset, int SpellIndex, int SpellDelayIndex)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                //Targetting = (SpellTargetting)Rom.Read8(BaseOffset + SpellIndex);

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
                //Rom.Write8((byte)Targetting, BaseOffset + SpellIndex);

            }
        }

    }
}
