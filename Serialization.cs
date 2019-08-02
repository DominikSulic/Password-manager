using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pasword_Manager
{
    [Serializable]
    public class Serialization
    {
        private static Serialization serialize;
        private Dictionary<string, Entity> entityDictionary;
        private BinaryFormatter formatter;

        private const string file = "savedEntities.dat";

        string path = Directory.GetCurrentDirectory();



        public static Serialization Instance()
        {
            if (serialize == null)
            {
                serialize = new Serialization();
            }
            return serialize;
        }

        public Serialization()
        {
            this.entityDictionary = new Dictionary<string, Entity>();
            this.formatter = new BinaryFormatter();

        }

        public void addEntity(string entityName, Entity entity)
        {
            this.entityDictionary.Add(entityName, entity);
            Save();
        }


        public void Save()
        {
            if (File.Exists(file))
            {
                try
                {
                    FileStream writerFileStream = new FileStream(file, FileMode.Append, FileAccess.Write);
                    this.formatter.Serialize(writerFileStream, this.entityDictionary);
                    writerFileStream.Close();
                }
                catch (Exception)
                {
                    //Exception error goes here
                }
            }
            else
            {
                try
                {
                    FileStream writerFileStream = new FileStream(file, FileMode.Create, FileAccess.Write);
                    this.formatter.Serialize(writerFileStream, this.entityDictionary);
                    writerFileStream.Close();
                }
                catch (Exception)
                {
                    //Exception error goes here
                }

            }

        }

        public Dictionary<string, Entity> Load()
        {
            // Check if we had previously Save information of our friends
            // previously
            if (File.Exists(file))
            {
                try
                {
                    // Create a FileStream will gain read access to the 
                    // data file.
                    FileStream readerFileStream = new FileStream(file,
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    this.entityDictionary = (Dictionary<String, Entity>)
                        this.formatter.Deserialize(readerFileStream);

                    readerFileStream.Close();

                }
                catch (Exception)
                {
                    //Exception error goes here
                }

            }
            return entityDictionary;
        }
    }
}




