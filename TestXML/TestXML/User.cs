using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TESTXML
{
public class User
{
    [XmlAttribute("UserName")]
    public String UserName = "";

    [XmlAttribute("Email")]
    public String Email = "";

    [XmlAttribute("Password")]
    public String Password = "";

    [XmlAttribute("TotalScore")]
    public int TotalScore = 0;

    [XmlAttribute("IsApproved")]
    public Boolean IsApproved = false;

    public User(string myUserName, String myEmail, String myPassword, int myTotalScore, Boolean myIsApproved)
    {
        UserName = myUserName;
        Email = myEmail;
        Password = myPassword;
        TotalScore = myTotalScore;
        IsApproved = myIsApproved;
    }

    public override string ToString()
    {
        return "UserName: " + UserName + ", Email: " + Email + ", TotalScore = " + TotalScore + ", IsApproved = " + IsApproved;
    }
}
}
