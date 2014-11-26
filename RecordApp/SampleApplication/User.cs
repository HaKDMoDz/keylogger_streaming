using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Xml;



namespace SampleApplication
{
    class User
    {
        static string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        static string usersDB = System.IO.Path.Combine(dir, "config.xml");

        private string username { get; set; }
        private string password { get; set; }
        private string occupation { get; set; }
        private int age { get; set; }
        private string gender { get; set; }

        public User(string u, string pw, string o, int age, string g)
        {
            username = u;
            password = pw;
            occupation = o;
            this.age = age;
            gender = g;

        }


        public static bool login(string username, string pw)
        {
            StreamReader stRd = new System.IO.StreamReader(usersDB);
            XmlTextReader xmlRd = new XmlTextReader(stRd);
            XmlDocument myXml = new System.Xml.XmlDocument();

            myXml.Load(xmlRd);

            XmlNode connNode = myXml.SelectSingleNode("Config/UserDB/UserRecords/User[@username='"+username+"']");
            XmlNode pwNode = connNode.SelectSingleNode("Pw");

            string value = pwNode.InnerText;

            Console.WriteLine(value);
            stRd.Close();
            return value.Equals(MD5password(pw));

               
        }
        public static void recordLogin(string username)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(usersDB);

            XmlNode lastLogged = doc.SelectSingleNode("Config/UserDB/Logged");
            lastLogged.InnerText = username;


            doc.Save(usersDB);

        }



        public static string checkLogin()
        {
            StreamReader stRd = new System.IO.StreamReader(usersDB);
            XmlTextReader xmlRd = new XmlTextReader(stRd);
            XmlDocument myXml = new System.Xml.XmlDocument();

            myXml.Load(xmlRd);

            XmlNode connNode = myXml.SelectSingleNode("Config/UserDB/Logged");
            string value = connNode.InnerText;
            xmlRd.Close();
            stRd.Close();
            
            return value;
        }

        public static void record(string u,string pw, string o, int age, string g)
        {



            XmlDocument doc = new XmlDocument();
            doc.Load(usersDB);

            XmlNode userinfo = doc["Config"]["UserDB"]["UserRecords"].AppendChild(doc.CreateElement("User"));


            
            XmlAttribute username = doc.CreateAttribute("username");
            username.Value = u;
            userinfo.Attributes.Append(username);

            userinfo.AppendChild(doc.CreateElement("Pw")).AppendChild(doc.CreateTextNode(pw));
            userinfo.AppendChild(doc.CreateElement("Occupation")).AppendChild(doc.CreateTextNode(o));
            userinfo.AppendChild(doc.CreateElement("Age")).AppendChild(doc.CreateTextNode(age.ToString()));
            userinfo.AppendChild(doc.CreateElement("Gender")).AppendChild(doc.CreateTextNode(g));


            doc.Save(usersDB);

           


          //  StreamWriter w = File.AppendText(usersDB);
           // w.WriteLine(u+";"+pw+";"+o+";"+age+";"+g);
            //w.Close();
        }

        public static string MD5password(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

       
    }
}
