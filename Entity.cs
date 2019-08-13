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
                    string data = entity.entityName + ", " + entity.userName +  ", " + entity.email + ", " + entity.password + ";";
                    byte[] info = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(info, 0, info.Length);
                    fs.Close();

                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                    string data = entity.userName + ", " + entity.entityName + ", " + entity.email + ", " + entity.password + ";";
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

        public static List<Entity> readFromFile()
        {
            List<Entity> listOfEntities = new List<Entity>();

            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    string[] individualEntity = content.Split(';');
                    string temp = "";
                    string[] temp2 = new string[4];

                    for(int i = 0; i < individualEntity.Length - 1; i++)
                    {
                        temp = individualEntity[i];
                        temp2 = temp.Split(',');
                        Entity entity = new Entity();
                        entity.entityName = temp2[0];
                        entity.userName = temp2[1];
                        entity.email = temp2[2];
                        entity.password = temp2[3];
                        listOfEntities.Add(entity);
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

            return listOfEntities;
        }

        public static void deleteEntitiesFromFile(string[] entitiesForDeletion)
        {
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    string[] individualEntity = content.Split(';');
                    string temp = "";
                    string[] temp2 = new string[4];

                    for (int i = 0; i < entitiesForDeletion.Length - 1; i++)
                    {
                        for(int i2 = 0; i < individualEntity.Length - 1; i++)
                        {
                            if (individualEntity[i2].StartsWith(entitiesForDeletion[i]))
                            {
                                individualEntity[i2].Remove(0, individualEntity[i2].Length);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            string returnString = userName + ", " + entityName + ", " + email + ", " + password + ";";
            return returnString;
        }

    }
}
