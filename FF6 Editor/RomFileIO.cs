using System;
using System.IO;

namespace FF6_Editor
{
    public class RomFileIO
    {
        FileStream DataFile = null;
        MemoryStream ROM = null;
        BinaryReader br = null;
        BinaryWriter bw = null;
        bool FileChanged { set; get; }

        public RomFileIO()
        {
            FileChanged = false;
        }

        public void Open(string Name)
        {
            Close();

            DataFile = new FileStream(Name, FileMode.Open, FileAccess.ReadWrite);
            ROM = new MemoryStream();
            DataFile.CopyTo(ROM);

            br = new BinaryReader(ROM);
            bw = new BinaryWriter(ROM);
            FileChanged = false;
        }

        public void SaveAs(string Name)
        {
            DataFile.Close();
            DataFile = new FileStream(Name, FileMode.Create, FileAccess.ReadWrite);
            ROM.WriteTo(DataFile);
        }

        public void Close()
        {
            if (DataFile != null)
                DataFile.Close();
            if (ROM != null)
                ROM.Close();
        }

        public void Seek(int FileOffset)
        {
            if (ROM != null)
                ROM.Seek(FileOffset, SeekOrigin.Begin);
        }

        public bool IsOpen()
        {
            return ROM != null;
        }

        public byte Read8()
        {
            if (ROM != null)
                return br.ReadByte();
            else
                throw new NullReferenceException();
        }

        public ushort Read16()
        {
            if (ROM != null)
                return br.ReadUInt16();
            else
                throw new NullReferenceException();
        }

        public uint Read32()
        {
            if (ROM != null)
                return br.ReadUInt32();
            else
                throw new NullReferenceException();
        }

        public byte Read8(int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                return br.ReadByte();
            }
            else
                throw new NullReferenceException();
        }

        public ushort Read16(int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                return br.ReadUInt16();
            }
            else
                throw new NullReferenceException();
        }

        public uint Read32(int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                return br.ReadUInt32();
            }
            else
                throw new NullReferenceException();
        }

        public void Write8(byte val)
        {
            if (ROM != null)
                bw.Write(val);
            else
                throw new NullReferenceException();
        }

        public void Write16(ushort val)
        {
            if (ROM != null)
                bw.Write(val);
            else
                throw new NullReferenceException();
        }

        public void Write32(uint val)
        {
            if (ROM != null)
                bw.Write(val);
            else
                throw new NullReferenceException();
        }

        public void Write8(byte val, int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                Write8(val);
            }
            else
                throw new NullReferenceException();
        }

        public void Write16(ushort val, int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                Write16(val);
            }
            else
                throw new NullReferenceException();
        }

        public void Write32(uint val, int FileOffset)
        {
            if (ROM != null)
            {
                Seek(FileOffset);
                Write32(val);
            }
            else
                throw new NullReferenceException();
        }

        private bool CheckRomSize(string Name)
        {
            if (Name.Length != 0x400000 | Name.Length != 0x400200)
            {
                Close();
                return false;
            }
            return true;
        }
    }
}
