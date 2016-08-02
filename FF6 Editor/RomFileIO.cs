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
using RomData;

namespace RomFileIO
{
    public class RomFileIO
    {
        MemoryStream ROM;

        public void LoadRom(string Name)
        {
            FileStream Data = new FileStream(Name, FileMode.Open);

            ROM = new MemoryStream();
            Data.CopyTo(ROM);
        }
    }
}
