using DataLayer;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VANPHONGPHAM
{
    static class Program
    {
        internal static string connoi;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            if (File.Exists("connectdb.dba")){
                string conStr = "";
                //Doc file connect
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                connect cp = (connect)bf.Deserialize(fs);

                //Decrypt noi dung
                string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                string pass = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
                string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);
                conStr += "Data Source=" + servername + "; Initial Catalog=" + database + ";User ID=" + username + ";Password = " + pass + ";";
                connoi = conStr;
                myFun._srv = servername;
                myFun._us = username;
                myFun._pw = pass;
                myFun._db = database;
                fs.Close();
            }
            Application.Run(new frmDangNhap());
        }
    }
}
