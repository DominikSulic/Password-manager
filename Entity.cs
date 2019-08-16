using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pasword_Manager
{
    public class Entity
    {
        public string entityName;
        public string userName;
        public string email;
        public string password;

        List<Category> listOfCategories;

        private static string path = Directory.GetCurrentDirectory() + "/entities.txt";

        public static void saveToFile(Entity entity)
        {
            try
            {
                if (!File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    string data = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";
                    byte[] info = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(info, 0, info.Length);
                    fs.Close();

                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                    string data = entity.entityName + ", " + entity.userName + ", " + entity.email + ", " + entity.password + ";";
                    byte[] info = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Dictionary<string, List<Entity>> readFromFile()
        {
            Dictionary<string, List<Entity>> dictionary = new Dictionary<string, List<Entity>>();
            List<Entity> tempList = new List<Entity>();

            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    string[] individualEntity = content.Split(';');
                    string temp = "";
                    string[] temp2 = new string[4];

                    for (int i = 0; i < individualEntity.Length - 1; i++)
                    {
                        temp = individualEntity[i];
                        temp2 = temp.Split(',');
                        Entity entity = new Entity();
                        entity.entityName = temp2[0];
                        entity.userName = temp2[1];
                        entity.email = temp2[2];
                        entity.password = temp2[3];


                        if (!dictionary.ContainsKey(entity.entityName))
                        {
                            tempList.Add(entity);
                            dictionary.Add(entity.entityName, tempList);
                            tempList.Clear();
                        }
                        else
                        {

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

        public static void deleteEntitiesFromFile(int[] indexesForDeletion)
        {
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    string[] individualEntity = content.Split(';');
                    List<string> list = new List<string>(individualEntity);
                    string data = "";

                    for (int i = 1; i <= indexesForDeletion.Length; i++)
                    {
                        list.RemoveAt(indexesForDeletion[i - 1]);
                    }

                    individualEntity = list.ToArray();

                    File.WriteAllText(path, String.Empty);

                    for (int i = 0; i < individualEntity.Length - 1; i++)
                    {
                        data += individualEntity[i] + ";";
                    }

                    File.WriteAllText(path, data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void updateEntityInFile()
        {

        }

        public override string ToString()
        {
            string returnString = entityName;
            return returnString;
        }

    }
}