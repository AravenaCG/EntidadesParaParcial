using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TESTXML
{
    // Shopping list class which will be serialized
    [XmlRoot("UserList")]
    public class UserList
    {
        private ArrayList myUserList;

        public UserList()
        {
            myUserList = new ArrayList();
        }              

        [XmlElement("myUsers")]
        public User[] myUsers
        {
            get
            {
                User[] myUsers = new User[myUserList.Count];
                myUserList.CopyTo(myUsers);
                return myUsers;
            }
            set
            {
                if (value == null) 
                    return;
                User[] myUsers = (User[])value;
                myUserList.Clear();
                foreach (User myUser in myUsers)
                    myUserList.Add(myUser);
            }
        }

        public string AddItem(User myUser)
        {
            myUserList.Add(myUser);
            return myUser.ToString();
        }

    }



}