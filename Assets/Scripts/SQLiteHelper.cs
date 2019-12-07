using System;
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
                "CREATE TABLE IF NOT EXISTS player (id INTEGER PRIMARY KEY, username TEXT NOT NULL, pancakes_flipped INTEGER DEFAULT 0) ";
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
            while (reader.Read())
            {
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

        public void addPlayer(String username)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "INSERT INTO player (username,pancakes_flipped) VALUES ('" + username + "',0)";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();

        }

        public void updatePlayer(String username, int flips)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "UPDATE player SET pancakes_flipped = " + flips + " WHERE username='" + username + "'";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();

        }
        public bool playerExists(String username)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM player WHERE username='" + username + "'";
            IDataReader reader = dbcmd.ExecuteReader();

            if (reader.Read())
            {
                reader.Dispose();
                reader.Close();
                return true;
            }
            else
            {
                reader.Dispose();
                reader.Close();
                return false;
            }
            //Debug.Log(reader.Read());
        }
        public int getTotalPlayerFlips(String username)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT pancakes_flipped FROM player WHERE username='" + username + "'";
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
        public void createFriendsTable()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "CREATE TABLE IF NOT EXISTS friends (id INTEGER PRIMARY KEY, username TEXT NOT NULL, friend_name TEXT)";
            IDataReader reader = dbcmd.ExecuteReader();
        }
        public void seeFriendsTable()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM friends";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("id: " + reader[0].ToString());
                Debug.Log("username: " + reader[1].ToString());
                Debug.Log("friend_name: " + reader[2].ToString());
            }
            reader.Dispose();
            reader.Close();

        }
        public void createWaitingFriendsTable()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "CREATE TABLE IF NOT EXISTS waiting_friends (id INTEGER PRIMARY KEY, username TEXT NOT NULL, approved INETEGER DEFAULT 0, request TEXT)";
            IDataReader reader = dbcmd.ExecuteReader();
        }
        public void seeWaitngFriendsTable()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM waiting_friends";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("id: " + reader[0].ToString());
                Debug.Log("username: " + reader[1].ToString());
                Debug.Log("approved: " + reader[2].ToString());
                Debug.Log("request: " + reader[3].ToString());
            }
            reader.Dispose();
            reader.Close();

        }
        public bool pendingInvitationExists(String sender, String friend)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                                "SELECT  * FROM waiting_friends WHERE request='" + friend + "'" + " AND username='" + sender + "'" + " AND approved=0";

            IDataReader reader = dbcmd.ExecuteReader();

            if (reader.Read())
            {
                reader.Dispose();
                reader.Close();
                return true;
            }
            else
            {
                reader.Dispose();
                reader.Close();
                return false;
            }

        }

        public void addPlayerToWaiting(String username, String friend)
        {
            if (friend == username)
            {
                Debug.Log("u can't invite yourself");
            }
            else if ((pendingInvitationExists(friend, username) || pendingInvitationExists(username, friend)))
            {
                Debug.Log("invitation already exists");
            }
            else if (getApprovedFriends(username).Contains(friend))
            {
                Debug.Log("Already friends");
            }
            else
            {

                IDbCommand dbcmd = db_connection.CreateCommand();
                dbcmd.CommandText =
                    "INSERT INTO waiting_friends (username,request) VALUES ('" + username + "','" + friend + "')";
                IDataReader reader = dbcmd.ExecuteReader();
                reader.Dispose();
                reader.Close();
            }


        }
        public List<string> getPendingFriends(String username)
        {
            List<string> pending = new List<string>();
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT request FROM waiting_friends WHERE username='" + username + "'" + " AND approved=0";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                pending.Add(reader.GetString(0));
            }

            reader.Dispose();
            reader.Close();
            return pending;
        }
        public List<string> getFriendRequests(String username)
        {
            List<string> sent = new List<string>();
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT username FROM waiting_friends WHERE request='" + username + "'" + " AND approved=0";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                sent.Add(reader.GetString(0));
            }

            reader.Dispose();
            reader.Close();
            return sent;
        }
        public List<string> getApprovedFriends(String username)
        {
            List<string> friends = new List<string>();
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT friend_name FROM friends WHERE username='" + username + "'";
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {

                friends.Add(reader.GetString(0));
            }

            reader.Dispose();
            reader.Close();
            return friends;
        }

        public void approveFriend(String username, String waitingFriend)
        {
            if (pendingInvitationExists(waitingFriend, username))
            {
                IDbCommand dbcmd = db_connection.CreateCommand();
                dbcmd.CommandText =
                    "UPDATE waiting_friends SET approved = 1 WHERE request='" + username + "'" + " AND username='" + waitingFriend + "'";
                IDataReader reader = dbcmd.ExecuteReader();

                dbcmd = db_connection.CreateCommand();
                dbcmd.CommandText =
                    "INSERT INTO friends (username,friend_name) VALUES ('" + username + "','" + waitingFriend + "')";
                reader = dbcmd.ExecuteReader();

                dbcmd = db_connection.CreateCommand();
                dbcmd.CommandText =
                    "INSERT INTO friends (username,friend_name) VALUES ('" + waitingFriend + "','" + username + "')";
                reader = dbcmd.ExecuteReader();

                reader.Dispose();
                reader.Close();
            }
            else
            {
                Debug.Log("Friend already approved or invitation doesn't exist");
            }

        }
        public void dropFriend()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "DROP TABLE friends";
            IDataReader reader = dbcmd.ExecuteReader();
            Debug.Log("Removied friends table");
        }
        public void dropWaitingFriend()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "DROP TABLE waiting_friends";
            IDataReader reader = dbcmd.ExecuteReader();
            Debug.Log("Removied waiting_friends table");
        }
        /*public void getPlayerFlips(String username,int level){
			IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                ""  ;
            IDataReader reader = dbcmd.ExecuteReader();
			
		}*/
        public void removeFriend(String username, String friend)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "DELETE FROM friends WHERE username='" + username + "'" + " AND friend_name='" + friend + "'";
            IDataReader reader = dbcmd.ExecuteReader();

            dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "DELETE FROM friends WHERE username='" + friend + "'" + " AND friend_name='" + username + "'";
            reader = dbcmd.ExecuteReader();

            declineFriend(username, friend);
            declineFriend(friend, username);

            reader.Dispose();
            reader.Close();

        }

        public void declineFriend(String username, String waitingFriend)
        {
            if (pendingInvitationExists(waitingFriend, username))
            {
                IDbCommand dbcmd = db_connection.CreateCommand();
                dbcmd.CommandText =
                    "DELETE FROM waiting_friends WHERE username='" + waitingFriend + "'" + " AND request='" + username + "'";
                IDataReader reader = dbcmd.ExecuteReader();

                reader.Dispose();
                reader.Close();
            }
            else
            {
                Debug.Log("invitation doesn't exist");
            }

        }

        public void createLevelTable(int level)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "CREATE TABLE IF NOT EXISTS level" + level + " (id INTEGER PRIMARY KEY, username TEXT NOT NULL, score INTEGER, time TEXT)";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();
        }

        public void seeLevelTable(int level)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM level" + level + "";
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("id: " + reader[0].ToString());
                Debug.Log("username: " + reader[1].ToString());
                Debug.Log("score: " + reader[2].ToString());
                Debug.Log("time: " + reader[3].ToString());
            }
            reader.Dispose();
            reader.Close();

        }
        public void addScore(int level, string username, int score, TimeSpan time)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "INSERT INTO level" + level + " (username,score,time) VALUES ('" + username + "'," + score + ",'" + time.ToString() + "')";
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Dispose();
            reader.Close();
        }
        public List<int> getScores(int level, string username)
        {
            List<int> scores = new List<int>();
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT score FROM level" + level + " WHERE username='" + username + "'";
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {

                scores.Add(reader.GetInt32(0));
            }

            reader.Dispose();
            reader.Close();
            return scores;
        }
        public List<TimeSpan> getTimes(int level, string username)
        {
            List<TimeSpan> times = new List<TimeSpan>();
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT time FROM level" + level + " WHERE username='" + username + "'";
            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {

                times.Add(TimeSpan.Parse(reader.GetString(0)));
            }

            reader.Dispose();
            reader.Close();
            return times;
        }
    }
}