using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF1_DOS_editor
{
    /*
    public class SpellList
    {
        RomFileIO Rom = new RomFileIO();
        FF6TextTables TextTables = new FF6TextTables();

        public int Spell = 0;        
        public int ReadLetter;
        public byte SpellByte;

        List<string> SpellLettersList = new List<string>();
        string SpellName;
        List<string> SpellNamesList = new List<string>();

        public List<string> ReadSpellNames(RomFileIO Rom)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                ReadLetter = RomData.SPELL_ESPER_NAMES;
                int l = 0;
                StringBuilder sb = new StringBuilder();
                Dictionary<ulong, string> FF6TableIn = TextTables.ReadTableIn();
                Rom.Read8(ReadLetter - 1);
                while (Spell < 54)
                {                    
                    while (l < 9)
                    {
                        SpellByte = Rom.Read8();
                        //sb.Append(FF6TableIn[SpellByte]);
                        SpellLettersList.Add(FF6TableIn[SpellByte]);
                        ReadLetter++;
                        l++;
                    }
                    SpellName = SpellLettersList[0];
                    for (int i = 0; i < 8; i++)
                    {
                        SpellName += SpellLettersList[i + 1];
                    }
                    //SpellNames.Value = Spell;
                    SpellNamesList.Add(Convert.ToString(SpellName));
                    SpellName = null;
                    Spell++;
                    l = 0;
                    SpellLettersList.Clear();
                }
                while ((Spell >= 54) && (Spell < 81))
                {
                    while (l < 12)
                    {
                        SpellByte = Rom.Read8();
                        SpellLettersList.Add(FF6TableIn[SpellByte]);
                        ReadLetter++;
                        l++;
                    }
                    SpellName = SpellLettersList[0];
                    for (int i = 0; i < 11; i++)
                    {
                        SpellName += SpellLettersList[i + 1];
                    }
                    SpellNamesList.Add(Convert.ToString(SpellName));
                    SpellName = null;
                    Spell++;
                    l = 0;
                    SpellLettersList.Clear();                    
                }
                ReadLetter = RomData.OTHER_SPELL_NAMES;
                SpellByte = 0;
                Rom.Read8(ReadLetter - 1);
                while ((Spell >= 81) && (Spell < 256))
                {
                    while (l < 16)
                    {
                        SpellByte = Rom.Read8();
                        SpellLettersList.Add(FF6TableIn[SpellByte]);
                        ReadLetter++;
                        l++;
                    }
                    SpellName = SpellLettersList[0];
                    for (int i = 0; i < 15; i++)
                    {
                        SpellName += SpellLettersList[i + 1];
                    }
                    SpellNamesList.Add(Convert.ToString(SpellName));
                    SpellName = null;
                    Spell++;
                    l = 0;
                    SpellLettersList.Clear();
                }
                return SpellNamesList;
            }
        }

        /*public List<string> WriteSpellNames()
        {
            Dictionary<string, ulong> FF6TableOut = TextTables.ReadTableOut();
        }
    } */
}
