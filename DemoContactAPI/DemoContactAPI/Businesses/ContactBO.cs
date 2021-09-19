using DemoContactAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoContactAPI.Businesses
{
    public class ContactBO
    {
        public static string filePath = @"file.txt";

        public static List<ContactModel> Docfile()
        {
            List<ContactModel> Contacts = new List<ContactModel>(); 
            string[] lines;
            if (System.IO.File.Exists(filePath))
            {

                lines = System.IO.File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine("Line {0}: {1}", i, lines[i]);
                    var data = JsonConvert.DeserializeObject<ContactModel>(lines[i]);
                    try
                    {
                        Contacts.Add(data);
                    }
                    catch (Exception e)
                    { }
                }
                Console.WriteLine();

               
               
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            return Contacts;
        }

        public static bool Ghifile( string data )
        {
            StreamWriter w;
            string str = "";

            if (!File.Exists(filePath))
            {
                w = File.CreateText(filePath);
            }
            else w = File.AppendText(filePath);
            try
            {
                w.WriteLine(data);
                w.Flush();
                w.Close();
                return true;
            }
            catch (Exception ex)
            {
                w.Flush();
                w.Close();
                return false;
            }
        }

        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                //var r = new Regex(@"^\(84|0[3|5|7|8|9])+([0-9]{8})\b$");
                var r = new Regex(@"^([0])?[3|5|7|8|9][0-9]{8}$");
                bool result = r.IsMatch(Phone);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int RequestIP(string IP)
        {
            var response = ContactBO.Docfile();
            int soluong = response.Where(x=> x.ip != null && x.ip.ToString().Equals(IP.ToString())).Count();
            return soluong;
        }
    }
}
