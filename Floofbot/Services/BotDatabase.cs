﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Floofbot.Services
{
    public class BotDatabase
    {
        SqliteConnection dbConnection;

        public BotDatabase()
        {
            dbConnection = new SqliteConnection(new SqliteConnectionStringBuilder {
                DataSource = "botdata.db"
            }.ToString());

            if (!File.Exists("botdata.db")) {

                FileStream fs = File.Create("botdata.db");
                fs.Close();

                string sql = @"
                CREATE TABLE `Tags` (
	                `TagID`	TEXT,
	                `UserID`	TEXT,
	                `Content`	TEXT,
	            PRIMARY KEY(`TagID`));";
                SqliteCommand command = new SqliteCommand(sql, dbConnection);
                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }
}