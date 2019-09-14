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
                    string saveToFile = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";

                    // path is the only specified variable, the boolean value wont have any effect, the file doesnt exist
                    using (StreamWriter newTask = new StreamWriter(path))
                    {
                        newTask.WriteLine(Encryption.Encrypt(saveToFile, "HungryForApples?"));
                    }
                }
                else
                {
                    string saveToFile = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";
                    string allDataFromFile = Encryption.Decrypt(File.ReadAllText(path), "HungryForApples?");

                    allDataFromFile += saveToFile;

                    // add the boolean now, it's regarding the append - false - overwrites the file
                    using (StreamWriter newTask = new StreamWriter(path, false))
                    {
                        newTask.WriteLine(Encryption.Encrypt(allDataFromFile, "HungryForApples?"));
                    }

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
                    allDataFromFile = Encryption.Decrypt(allDataFromFile, "HungryForApples?");
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

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                saveToFile += kvp.Value;
            }

            // add the boolean now, it's regarding the append - false - overwrites the file
            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                newTask.WriteLine(Encryption.Encrypt(saveToFile, "HungryForApples?"));
            }
        }


        public static void updateEntityInFile(Dictionary<string, string> dictionary)
        {
            string saveToFile = "";

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                saveToFile += kvp.Value;
            }

            // add the boolean now, it's regarding the append - false - overwrites the file
            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                newTask.WriteLine(Encryption.Encrypt(saveToFile, "HungryForApples?"));
            }
        }


        public override string ToString()
        {
            string returnString = entityName;
            return returnString;
        }


    }
}