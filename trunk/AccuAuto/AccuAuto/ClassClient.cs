using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccuAuto
{
    class ClassClient
    {
        private List<string> clientList = new List<string>();
        
        public void add(string fileName, int clientID)
        {
            clientList.Insert(clientID, fileName);
        }

        public int getID(string fileName)
        {
            return clientList.FindIndex(item => item == fileName);
        }

    }
}
