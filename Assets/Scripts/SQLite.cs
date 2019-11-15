using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLite : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
		
	// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";
		
		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Create table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
		
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		// Insert values in table
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
		cmnd.ExecuteNonQuery();

		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
