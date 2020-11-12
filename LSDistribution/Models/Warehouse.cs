using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LSDistribution.Models
{
    public class Warehouse : Object, DBItem
    {
        static Warehouse()
        {
            LSLocalDatabase.InitializeFolder(GetDBFolderPath());
        }

        public void DBRemove()
        {
            if (ID == 0)
                throw new Exception("Item is not valid!");

            File.Delete(_GetDBFilePath());
        }
        public void DBUpdate()
        {
            if (ID == 0)
                ID = GetMaxID() + 1;

            File.WriteAllText(_GetDBFilePath(), JsonConvert.SerializeObject(this));
        }
        public int GetMaxID()
        {
            var l = List();
            return l.Count() == 0 ? 0 : l.Max(x => x.ID);
        }


        public string _GetDBFolderPath()
        {
            return GetDBFolderPath();
        }
        public string _GetDBFilePath()
        {
            return Path.Combine(GetDBFolderPath(), ID.ToString() + ".lsdbi");
        }
        public static string GetDBFolderPath()
        {
            return Path.Combine(LSLocalDatabase.RootFolder, "Warehouses");
        }


        public static Warehouse GetWarehouse(int id)
        {
            foreach (string s in Directory.GetFiles(GetDBFolderPath()))
                if (Path.GetFileName(s).Split('.')[0] == id.ToString())
                    return JsonConvert.DeserializeObject<Warehouse>(File.ReadAllText(s));

            return null;
        }
        public static List<Warehouse> List()
        {
            List<Warehouse> list = new List<Warehouse>();

            foreach (string s in Directory.GetFiles(GetDBFolderPath()))
                list.Add(JsonConvert.DeserializeObject<Warehouse>(File.ReadAllText(s)));

            return list;
        }
    }
}
