using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Pasword_Manager
{
    public class Entity
    {
        public string entityName;
        public string userName;
        public string email;
        public string password;


        private static readonly string path = Directory.GetCurrentDirectory() + "/entities.txt";


        public static void saveToFile(Entity entity)
        {
            try
            {
                if (!File.Exists(path))
                {
                    FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                    string entityData = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";
                    byte[] convertedEntityData = new UTF8Encoding(true).GetBytes(entityData);
                    fileStream.Write(convertedEntityData, 0, convertedEntityData.Length);
                    fileStream.Close();
                }
                else
                {
                    FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                    string entityData = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";
                    byte[] convertedEntityData = new UTF8Encoding(true).GetBytes(entityData);
                    fileStream.Write(convertedEntityData, 0, convertedEntityData.Length);
                    fileStream.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Dictionary<string, string> readFromFile()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                if (File.Exists(path))
                {
                    string allDataFromFile = File.ReadAllText(path, Encoding.UTF8);
                    string[] entities = allDataFromFile.Split(';');
                    string[] individualEntity = new string[4];
                    string entitiesOfSameKey = "";
                    string entityValuesConcat = "";

                    for (int i = 0; i < entities.Length - 1; i++)
                    {
                        individualEntity = entities[i].Split(',');

                        if (dictionary.TryGetValue(individualEntity[0], out entitiesOfSameKey))
                        {
                            entityValuesConcat = individualEntity[0] + ", " + individualEntity[1] + ", " + individualEntity[2] + ", " + individualEntity[3] + ";";
                            entitiesOfSameKey += entityValuesConcat;
                            dictionary[individualEntity[0]] = entitiesOfSameKey;
                            entityValuesConcat = "";
                        }
                        else
                        {
                            entityValuesConcat = individualEntity[0] + ", " + individualEntity[1] + ", " + individualEntity[2] + ", " + individualEntity[3] + ";";
                            dictionary.Add(individualEntity[0], entityValuesConcat);
                            entityValuesConcat = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The file does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dictionary;
        }


        public static void deleteEntities(Dictionary<string, string> dictionary)
        {
            string saveToFile = "";

            foreach(KeyValuePair<string, string> kvp in dictionary)
            {
                saveToFile += kvp.Value;
            }

            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                newTask.WriteLine(saveToFile);
            }
        }


        public static void updateEntityInFile(Dictionary<string, string> dictionary)
        {
            string saveToFile = "";

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                saveToFile += kvp.Value;
            }

            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                newTask.WriteLine(saveToFile);
            }
        }


        public override string ToString()
        {
            string returnString = entityName;
            return returnString;
        }


    }
}