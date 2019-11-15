using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
public class SQLiteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";
		
		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();
		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query ="SELECT * FROM my_table";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
			Debug.Log("id: " + reader[0].ToString());
			Debug.Log("val: " + reader[1].ToString());
		}

		// Close connection
		dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
