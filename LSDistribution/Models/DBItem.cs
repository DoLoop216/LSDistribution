using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSDistribution.Models
{
    public interface DBItem
    {
        /// <summary>
        /// Updates or Insert new object into database
        /// </summary>
        void DBUpdate();
        /// <summary>
        /// Removes object from database
        /// </summary>
        void DBRemove();
        /// <summary>
        /// Returns full file path based on ID of the object
        /// </summary>
        /// <returns></returns>
        string _GetDBFolderPath();
        /// <summary>
        /// Returns full file path based on ID of the object
        /// </summary>
        /// <returns></returns>
        string _GetDBFilePath();
        /// <summary>
        /// Returns max items ID located in database
        /// </summary>
        /// <returns></returns>
        int GetMaxID();
    }
}
