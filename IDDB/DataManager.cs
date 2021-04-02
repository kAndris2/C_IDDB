using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace IDDB
{
    public sealed class DataManager
    {
        const String LOGINS = "Logins.xml";
        const String ADDRESSES = "Addresses.xml";
        const String PASSWORDS = "Passwords.xml";

        public List<LoginID> Logins { get; private set; } = new List<LoginID>();
        public List<Email> Addresses { get; private set; } = new List<Email>();
        public List<Password> Passwords { get; private set; } = new List<Password>();

        Encrypt Encrypt = null;
        static DataManager instance = null;
        public static DataManager Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        private DataManager()
        {
            try
            {
                Addresses = ImportAddress();
                Passwords = ImportPasswords();
                Logins = ImportLogins();
            }
            catch (FileNotFoundException)
            {
                new ConsoleLogger().Info($"[INFO]: The database is empty!\n");
            }
            finally
            {
                Encrypt = new Encrypt();
            }
        }

        public void AddLogin(LoginID login) { Logins.Add(login); }
        public void AddAddress(Email email) { Addresses.Add(email); }
        public void AddPassword(Password password) { Passwords.Add(password); }

        public void RemoveLogin(LoginID login) { Logins.Remove(login); }
        public void RemoveAddress(Email email) { Addresses.Remove(email); }
        public void RemovePassword(Password password) { Passwords.Remove(password); }

        private List<LoginID> ImportLogins()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<LoginID>));
            List<LoginID> logins;
            using (FileStream readfile = File.OpenRead(LOGINS))
            {
                logins = (List<LoginID>)reader.Deserialize(readfile);
            }
            return logins;
        }

        public void SaveLogins()
        {
            if (File.Exists(LOGINS))
                File.SetAttributes(LOGINS, FileAttributes.Normal);

            XmlSerializer writer = new XmlSerializer(typeof(List<LoginID>));

            using (TextWriter writerfinal = new StreamWriter(LOGINS))
            {
                writer.Serialize(writerfinal, Logins);
            }

            if (!File.GetAttributes(LOGINS).HasFlag(FileAttributes.Hidden))
                File.SetAttributes(LOGINS, FileAttributes.Hidden);
        }

        //-----------------------------------------------------------------------------------------------------------------

        private List<Email> ImportAddress()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Email>));
            List<Email> addresses;
            using (FileStream readfile = File.OpenRead(ADDRESSES))
            {
                addresses = (List<Email>)reader.Deserialize(readfile);
            }
            return addresses;
        }

        public void SaveAddresses()
        {
            if (File.Exists(ADDRESSES))
                File.SetAttributes(ADDRESSES, FileAttributes.Normal);

            XmlSerializer writer = new XmlSerializer(typeof(List<Email>));

            using (TextWriter writerfinal = new StreamWriter(ADDRESSES))
            {
                writer.Serialize(writerfinal, Addresses);
            }

            if (!File.GetAttributes(ADDRESSES).HasFlag(FileAttributes.Hidden))
                File.SetAttributes(ADDRESSES, FileAttributes.Hidden);
        }

        //-----------------------------------------------------------------------------------------------------------------

        private List<Password> ImportPasswords()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Password>));
            List<Password> passwords;
            using (FileStream readfile = File.OpenRead(PASSWORDS))
            {
                passwords = (List<Password>)reader.Deserialize(readfile);
            }
            return passwords;
        }

        public void SavePasswords()
        {
            if (File.Exists(PASSWORDS))
                File.SetAttributes(PASSWORDS, FileAttributes.Normal);

            XmlSerializer writer = new XmlSerializer(typeof(List<Password>));

            using (TextWriter writerfinal = new StreamWriter(PASSWORDS))
            {
                writer.Serialize(writerfinal, Passwords);
            }

            if (!File.GetAttributes(PASSWORDS).HasFlag(FileAttributes.Hidden))
                File.SetAttributes(PASSWORDS, FileAttributes.Hidden);
        }
    }
}
