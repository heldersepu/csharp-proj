using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccuAuto
{
    class myClient
    {
        public string fileName;
        public int clientID;
        public string OldId;
        public myClient(string fName, int cID, string strOldId)
        {
            fileName = fName;
            clientID = cID;
            OldId = strOldId;
        }
    }

    class ClassClient
    {
        private List<myClient> clientList = new List<myClient>();

        public void add(string fileName, int clientID, string strOldId)
        {
            clientList.Add(new myClient(fileName, clientID, strOldId));
        }

        public int getID(string fileName)
        {
            int index = clientList.FindIndex(item => item.fileName == fileName);
            if (index > 0)
                return clientList[index].clientID;
            else
                return index;
        }

        public int getID2(string strOldId)
        {
            int index = clientList.FindIndex(item => item.OldId == strOldId);
            if (index > 0)
                return clientList[index].clientID;
            else
                return index;
        }
        
        public int count()
        {
            return clientList.Count;
        }
    }
}
