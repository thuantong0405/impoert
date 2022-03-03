using autoclick.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace autoclick.Model
{
    class ListPointer : IListPoint
    {
        List<Pointer> Listp = null;
        public int Length = 0;
        private string FileName = null;
        private string rootPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public ListPointer(string name)
        {
            FileName = name+".txt";
            if (this.OpenFile())
            {
                this.Length = this.Listp.Count;
            }
            else
            {
                Listp = new List<Pointer>();
            }
            
        }
        public bool Add(Pointer p)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Pointer p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">Point want to search</param>
        /// <returns>index</returns>
        public int Find(Pointer p)
        {
            return Listp.FindIndex(x => x.ID == p.ID);
        }

        public List<Pointer> GetAll()
        {
            try
            {
                return Listp;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">id</param>
        /// <returns></returns>
        public Pointer Get(int i)
        {
            try
            {
                return this.FindX(i);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Pointer p)
        {
            int index = this.Find(p);
            if (index < 0) return false;
            Listp.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">ID</param>
        /// <returns></returns>
        public Pointer FindX(int i)
        {
            Pointer pFind = Listp.Find(x => x.ID == i);
            return pFind;
        }

        public bool OpenFile()
        {
            
            string serializationFile = Path.Combine(rootPath, this.FileName);

            if (!File.Exists(serializationFile)) File.Copy(Path.Combine(rootPath, @"Def\FileDat\point.txt"), serializationFile);

            if (new FileInfo(serializationFile).Length == 0) return false;
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();

                Listp = (List<Pointer>)bformatter.Deserialize(stream);
                stream.Close();
            }
            return true;
        }

        public bool SaveToFile()
        {
            string serializationFile = Path.Combine(rootPath, this.FileName);

            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, Listp);
            }

            return true;
        }
    }
}
