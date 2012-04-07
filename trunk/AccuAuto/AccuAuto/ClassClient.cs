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
        public myClient(string fName, int cID)
        {
            fileName = fName;
            clientID = cID;
        }
    }

    class ClassClient
    {
        private List<myClient> clientList = new List<myClient>();
        
        public void add(string fileName, int clientID)
        {
            clientList.Add(new myClient(fileName, clientID));
        }

        public int getID(string fileName)
        {
            int index = clientList.FindIndex(item => item.fileName == fileName);
            return clientList[index].clientID; 
        }

    }
}
