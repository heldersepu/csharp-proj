using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Data.EntityClient;

namespace AccuAuto
{
    class ClassConvert
    {
        private ClassClient client = new ClassClient();
        private QFWinData_Entities db;
        private string connString = @"metadata=res://*/ModelEData.csdl|res://*/ModelEData.ssdl|res://*/ModelEData.msl; provider=System.Data.SqlClient; provider connection string="" Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3}; MultipleActiveResultSets=True""";
        
        public ClassConvert(string tServer, string tDB, string tUser, string tPassw)
        {
            connString = String.Format(connString, tServer, tDB, tUser, tPassw);
            db = new QFWinData_Entities(connString); 
        }


        public void doClients(Form1 form, System.IO.DirectoryInfo migrationDir)
        {
            var files = migrationDir.GetFiles();
            DateTime myDM = DateTime.Now;
            foreach (var file in files)
            {
                form.updFileLabel(file.Name);
                try
                {
                    using (var t = new StreamReader(file.FullName))
                    {
                        string strOldID = "";
                        var bits = t.ReadToEnd();
                        dynamic json = JsonHelper.Decode(bits);
                        CLNMA item = new CLNMA()
                        {
                            UNIQUE = "AccuAuto",
                            DBA = file.Name,
                            DateMigrated = myDM,
                            CompanyName = json.DisplayName,
                            LNAME = json.Name.LastName,
                            FNAME = json.Name.FirstName,
                            MiddleName = json.Name.MiddleName,
                            SOURCE = json.Source,
                            CSTATUS = (json.ClientStatus == "Prospect") ? "P" : "A",
                        };
                        try
                        {
                            item.ADDRESS1 = json.Addresses[0].Line1;
                            item.CITY = json.Addresses[0].City;
                            item.STATE = json.Addresses[0].State;
                            item.ZIP = json.Addresses[0].Zip;
                            item.ADDRESS2 = json.Addresses[0].Line2;
                        }
                        catch { }
                        try
                        {
                            if (json.Contacts.Count > 0)
                            {
                                foreach (dynamic Contact in json.Contacts)
                                {
                                    if (Contact.ContactType == "HomePhone")
                                    {
                                        item.HPHONE = Contact.Value;
                                    }
                                    else if (Contact.ContactType == "WorkPhone")
                                    {
                                        item.WPHONE = Contact.Value;
                                    }
                                    else if (Contact.ContactType == "MobilePhone")
                                    {
                                        item.Cell = Contact.Value;
                                    }
                                    else if (Contact.ContactType == "Email")
                                    {
                                        item.Email = Contact.Value;
                                    }
                                }
                            }
                        }
                        catch { }
                        try
                        {
                            item.DOB = Convert.ToDateTime(json.BirthDate.Substring(0, 10));
                        }
                        catch { }
                        try
                        {
                            strOldID = json.OldId;
                        }
                        catch { }

                        db.CLNMAS.AddObject(item);
                        db.SaveChanges();
                        client.add(file.Name, item.Client_ID, strOldID);
                        if (client.count() > 1000) break;
                    }
                }
                catch { }
            }
        }

        public void doPolicies(Form1 form, System.IO.DirectoryInfo migrationDir, string lob)
        {
            var files = migrationDir.GetFiles();
            foreach (var file in files)
            {
                form.updFileLabel(file.Name);
                try
                {
                    using (var t = new StreamReader(file.FullName))
                    {
                        var bits = t.ReadToEnd();
                        dynamic json = JsonHelper.Decode(bits);
                        int clientID = client.getID(json.NamedInsured.Id + ".json");
                        if (clientID > 0)
                        {
                            POLMA item = new POLMA()
                            {
                                CLIENT_ID = clientID,
                                POLICY_NUM = json.PolicyNumber,
                                LOB = lob
                            };
                            try
                            {
                                item.EFFECTIVE = Convert.ToDateTime(json.EffectiveDate.Substring(0, 10));
                                item.EXPIRATION = Convert.ToDateTime(json.RenewDate.Substring(0, 10));
                            }
                            catch { }
                            try
                            {
                                item.CSR = json.Producer;
                                item.BINDER_NUM = json.BinderNumber;
                                item.COMPANY = json.CompanyName;
                                item.PISSUED = Convert.ToDecimal(json.CurrentTermAmount);
                                item.PQUOTED = item.PISSUED;
                                item.PERIOD = Convert.ToString(json.ContractTerm);
                                item.PSTATUS = (json.Status == "Expired") ? "X" : "A";
                                item.CEARNED = Convert.ToDecimal(json.CommissionAmount);
                            }
                            catch { }
                            db.POLMAS.AddObject(item);
                            db.SaveChanges();
                        }
                    }
                }
                catch { }
            }
        }

        public void doImages(Form1 form, System.IO.DirectoryInfo migrationDir, string strFolder)
        {
            var files = migrationDir.GetFiles();
            foreach (var file in files)
            {
                form.updFileLabel(file.Name);
                try
                {
                    using (var t = new StreamReader(file.FullName))
                    {
                        var bits = t.ReadToEnd();
                        dynamic json = JsonHelper.Decode(bits);
                        int clientID = client.getID2(json.ClientId);
                        if (clientID > 0)
                        {
                            Image item = new Image()
                            {
                                Client_ID = clientID,
                                Policy_ID = 0,
                                Directory = strFolder,
                                Description = json.FileName
                            };
                            try
                            {
                                item.CSR_Images = json.CreatedBy;
                                item.DateEntered = Convert.ToDateTime(json.CreatedDate.Substring(0, 10));
                                item.FileDate = item.DateEntered;
                                item.TimeEntered = item.DateEntered;
                            }
                            catch { }
                            db.Images.AddObject(item);
                            db.SaveChanges();
                        }
                    }
                }
                catch { }
            }
        }
    }
}
