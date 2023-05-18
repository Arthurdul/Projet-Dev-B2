using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BddConnection : MonoBehaviour
{
    public string host;
    public string database;
    public TMP_InputField playername;
    public string playernamestr;
    public string score;
    
    private int user_id = 8;
    private MySqlConnection con;
    [SerializeField]private string username;
    [SerializeField]private string passwd;
    public ScoreManager scoreManager;

    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        string constr = "Server=" + host + ";DATABASE=" + database + ";User ID=" + username + ";Password=" + passwd + ";Pooling=true;Charset=utf8;";
        try{
            con = new MySqlConnection(constr);
            con.Open();
        }
        catch(IOException Ex){
            Debug.Log(Ex.ToString());
        }
    }

    public void UpdateBdd(){
        MySqlCommand updater_cmd = new MySqlCommand("INSERT INTO Users VALUES (default,'" + playernamestr +"')", con);
        user_id ++;
        try{
            updater_cmd.ExecuteReader().Close();
        }
        catch (IOException Ex)
        {
            Debug.Log(Ex.ToString());
        }
        updater_cmd = new MySqlCommand("SELECT user_id FROM Score WHERE user_id = (SELECT MAX(user_id) FROM Score)", con);
        var test = updater_cmd.ExecuteReader();
        test.Close();
        updater_cmd = new MySqlCommand("INSERT INTO Score VALUES ("+ user_id +",'" + score +"')", con);
        try{
            updater_cmd.ExecuteReader().Close();
        }
        catch (IOException Ex)
        {
            Debug.Log(Ex.ToString());
        }
        updater_cmd.Dispose();
    }

    public void UpdateUsername(){
        playernamestr = playername.text;
    }

    public void LaunchGame(){
        SceneManager.LoadScene("level1");
    }

    private void Update(){
        Debug.Log(con.State.ToString());
        if(scoreManager == null){
            if(GameObject.FindGameObjectWithTag("scoreManager")){
                scoreManager = GameObject.FindGameObjectWithTag("scoreManager").GetComponent<ScoreManager>();
            }
        }
        if(Input.GetKeyDown(KeyCode.P)){
            UpdateUsername();
            LaunchGame();
        }
    }

    public void UpdateScoreBdd(){
        MySqlCommand updater_cmd = new MySqlCommand("INSERT INTO Score VALUES (default,'" + score +"')", con);
    }
}
