﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.XPath;

namespace GameServer_Manager
{
    public class GSM_SettingsManagement_Classes
    {
        //=====================================================================================//
        // Read & Write JSON Data Functions                                                    //
        // http://www.newtonsoft.com/json/help/html/ReadJsonWithJsonTextReader.htm             //
        // http://www.newtonsoft.com/json/help/html/WriteJsonWithJsonTextWriter.htm            //
        //=====================================================================================//
        /*public static string ReadJSONData(string jsonData)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonData));
            while (reader.Read())
                {
                if (reader.Value != null)
                    {
                    return ("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    }
                    else
                    {
                    return ("Token: {0}", reader.TokenType);
                    }
                }
        }
        */


        //=====================================================================================//
        // Read & Write XML Data Functions                                                     //
        // https://www.codeproject.com/Articles/30834/Storing-and-Retrieving-Settings-from-XML //
        //=====================================================================================//
        public static void CheckForConfigXML()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\config.xml"))
            {
                //Dont do anything!
            }
            else
            {
                //Generate a config file!
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                XmlWriter writer = XmlWriter.Create("config.xml", settings);
                writer.WriteStartDocument();
                writer.WriteComment("This file is generated by GSM.  Feel free to modify it if you know what you are doing.");

                writer.WriteStartElement("config");

                //Generate Global Settings
                writer.WriteComment("GLOBAL SETTINGS");
                writer.WriteStartElement("global_settings");
                writer.WriteElementString("operator_name", "Operator");
                writer.WriteElementString("gameserver_storage_directory", @"C:\GSM\");
                writer.WriteEndElement(); //End global_settings

                //Generate Gameserver Listing
                writer.WriteComment("GAMESERVER CONFIGURATION LISTING");
                writer.WriteStartElement("gameserver_listing");
                /**/
                writer.WriteStartElement("server");
                writer.WriteAttributeString("ID", "001");
                writer.WriteElementString("server_alias", "Phantom Insanity");
                writer.WriteElementString("server_type", "Garry's Mod");
                writer.WriteElementString("running_status", "Offline");
                writer.WriteElementString("install_location", @"C:\GSM\steamapps\common\GarrysModDS");
                writer.WriteEndElement();

                writer.WriteStartElement("server");
                writer.WriteAttributeString("ID", "002");
                writer.WriteElementString("server_alias", "Death Row");
                writer.WriteElementString("server_type", "Killing Floor 2");
                writer.WriteElementString("running_status", "Offline");
                writer.WriteElementString("install_location", @"C:\GSM\steamapps\common\killingfloor2");
                writer.WriteEndElement();

                writer.WriteEndElement(); //End gameserver_listing

                //writer.WriteAttributeString("Name", "Phantom Cthulu Hole");
                //writer.WriteElementString("Price", "10.00");

                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();

            }
        }

        /*
        public static string ReadValueFromXML(string pstrValueToRead)
        {
            
        }

        public static bool WriteValueToXML(string pstrValueToRead, string pstrValueToWrite)
        {
            
        }
        */
    }
}
