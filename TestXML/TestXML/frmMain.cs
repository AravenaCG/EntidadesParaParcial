using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace TESTXML
{
    public partial class frmMain : Form
    {
        private String BaseDirectory = "";
        XMLHelper<UserList> myXMLHelper = null;
        UserList myListOfUsers = null;

        public frmMain()
        {
            InitializeComponent();
            BaseDirectory = "Data";
            myXMLHelper = new XMLHelper<UserList>(BaseDirectory);
            UserList myListOfUsers = new UserList();
        }            

        private void btnCreate_Click(object sender, EventArgs e)
        {
            myListOfUsers = new UserList();            
            Add(myListOfUsers.AddItem(new User("User1", "Email1", "Password1", 1, true))  + " :- Added to myUserList");
            Add(myListOfUsers.AddItem(new User("User2", "Email2", "Password2", 5, false)) + ":- Added to myUserList");
            Add("Class To be Serialized Created, Exists only in Local Memory");
            Add("");
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            if (myListOfUsers != null)
            {
                Add("Base Directory Set to Data inside the Debug Folder of the Current Environment");
                if (!System.IO.Directory.Exists(BaseDirectory))
                    System.IO.Directory.CreateDirectory(BaseDirectory);

                myXMLHelper.Save(myListOfUsers);
                Add("FilePath of XML File Automatically Set to = " + myXMLHelper.FileName(myListOfUsers));
                Add("Class Serialized Successfully");
                Add("Emptied Current Instance of MyListOfUsers");
                Add(myListOfUsers.myUsers[0].ToString());
                Add(myListOfUsers.myUsers[1].ToString());
                Add("");
                myListOfUsers = new UserList();
            }            
        }

        private void btnDeSerialize_Click(object sender, EventArgs e)
        {
            myListOfUsers = (UserList)myXMLHelper.Load(myListOfUsers);
            Add("FilePath of XML File Automatically Set to = " + myXMLHelper.FileName(myListOfUsers));
            Add("Class De-Serialized Successfully, Class Contents Displayed Below:-");
            Add(myListOfUsers.myUsers[0].ToString());
            Add(myListOfUsers.myUsers[1].ToString());
        }

        public void Add(Object obj)
        {
            if (obj != null)
                listBox1.Items.Add(obj.ToString());
        }
    }
}
