﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

namespace DataBank
{
    public class SQLiteHelper
    {
        private const string Tag = "SqliteHelper:\t";

        private const string database_name = "test";

        public string db_connection_string;
        public IDbConnection db_connection;

        public SQLiteHelper()
        {
            db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
            Debug.Log("db_connection_string" + db_connection_string);
            db_connection = new SqliteConnection(db_connection_string);
            db_connection.Open();
        }

        ~SQLiteHelper()
        {
            db_connection.Close();
        }

        // virtual functions
        /*public virtual IDataReader getDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public virtual IDataReader getDataByString(string str)
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public virtual void deleteDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual void deleteDataByString(string id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual IDataReader getAllData()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }
        public virtual void deleteAllData()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }
        public virtual IDataReader getNumOfRows()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }*/

        //helper functions
        public IDbCommand getDbCommand()
        {
            return db_connection.CreateCommand();
        }

        /*public IDataReader getAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }*/

        /*public void deleteAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
            dbcmd.ExecuteNonQuery();
        }
        public IDataReader getNumOfRows(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }*/

        public void close()
        {
            db_connection.Close();
        }

        public void open()
        {
            db_connection.Open();
        }

        // ADDING BY OURSELVES
        public void createPlayerTable()
        {
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "CREATE TABLE IF NOT EXISTS player (id INTEGER PRIMARY KEY, username TEXT NOT NULL, pancakes_flipped INTEGER DEFAULT 0) " ;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();
        }
		public void seePlayerTable()
        {
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM player";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read()){
				Debug.Log("id: " + reader[0].ToString());
				Debug.Log("username: " + reader[1].ToString());
				Debug.Log("pancakes_flipped: " + reader[2].ToString());
			}
            reader.Dispose();
            reader.Close();

        }
		/*public void createLevelTable()
        {
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "CREATE TABLE IF NOT EXISTS level (id INTEGER PRIMARY KEY, level_number INTEGER, flips INTEGER, FOREIGN KEY(player_id) REFERENCES player(id)) " ;
            IDataReader reader = dbcmd.ExecuteReader();
        }*/
		
		public void addPlayer(String username){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "INSERT INTO player (username,pancakes_flipped) VALUES ('"+username+"',0)";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();

        }
        
        public void updatePlayer(String username, int flips){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "UPDATE player SET pancakes_flipped = "+flips+" WHERE username='"+username+"'";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();

        }
		public bool playerExists(String username){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM player WHERE username='"+username+"'";
            IDataReader reader = dbcmd.ExecuteReader();
            
            if (reader.Read()){
                reader.Dispose();
                reader.Close();
				return true;
			}
			else{
                reader.Dispose();
                reader.Close();
                return false;
			}
            //Debug.Log(reader.Read());
        }
		public int getTotalPlayerFlips(String username){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT pancakes_flipped FROM player WHERE username='"+username+"'"  ;
            IDataReader reader = dbcmd.ExecuteReader();
			reader.Read();
			
			//int i = 0;
			//if (!Int32.TryParse(reader[0].ToString(), out i)){
			//	i = -1;
			//}
			int c = reader.GetInt32(0);
            reader.Dispose();
            reader.Close();
            return c;

        }
		/*public void getPlayerFlips(String username,int level){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                ""  ;
            IDataReader reader = dbcmd.ExecuteReader();
			
		}*/
    }
}