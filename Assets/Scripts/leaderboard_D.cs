using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class leaderboard_D : MonoBehaviour {

    public struct Leader {
        private int highScore;
        public int Score {
            get {
                return highScore;
            }
            set {
                highScore = value;
            }
        }

        private string MyName;
        public string Name {
            get {
                return MyName;
            }
            set {
                MyName = value;
            }
        }


        public override string ToString() {
            return MyName + " : " + highScore;
        }
    }
    public TMP_InputField mainIn;
    public GameObject HiScoreText0;
    public GameObject HiScoreText1;
    public GameObject HiScoreText2;
    public GameObject HiScoreText3;
    public GameObject HiScoreText4;
    public string HighScore0;
    public string HighScore1;
    public string HighScore2;
    public string HighScore3;
    public string HighScore4;
    List<Leader> Leaders = new List<Leader>(5);
    public int points;



    // Start is called before the first frame update
    void Start() {


        points = Basket_D.Instance.scorePoints;

        HiScoreText0 = GameObject.FindGameObjectWithTag("0");
        HiScoreText1 = GameObject.FindGameObjectWithTag("1");
        HiScoreText2 = GameObject.FindGameObjectWithTag("2");
        HiScoreText3 = GameObject.FindGameObjectWithTag("3");
        HiScoreText4 = GameObject.FindGameObjectWithTag("4");



        Leaders.Add(new Leader() { Name = PlayerPrefs.GetString("HighScore_DSTR0", "ABC"), Score = PlayerPrefs.GetInt("HighScore_D0", 0) });
        Leaders.Add(new Leader() { Name = PlayerPrefs.GetString("HighScore_DSTR1", "DEF"), Score = PlayerPrefs.GetInt("HighScore_D1", 0) });
        Leaders.Add(new Leader() { Name = PlayerPrefs.GetString("HighScore_DSTR2", "GHI"), Score = PlayerPrefs.GetInt("HighScore_D2", 0) });
        Leaders.Add(new Leader() { Name = PlayerPrefs.GetString("HighScore_DSTR3", "JKL"), Score = PlayerPrefs.GetInt("HighScore_D3", 0) });
        Leaders.Add(new Leader() { Name = PlayerPrefs.GetString("HighScore_DSTR4", "MNO"), Score = PlayerPrefs.GetInt("HighScore_D4", 0) });

        HiScoreText0.GetComponent<TextMeshProUGUI>().text = Leaders[0].ToString();
        HiScoreText1.GetComponent<TextMeshProUGUI>().text = Leaders[1].ToString();
        HiScoreText2.GetComponent<TextMeshProUGUI>().text = Leaders[2].ToString();
        HiScoreText3.GetComponent<TextMeshProUGUI>().text = Leaders[3].ToString();
        HiScoreText4.GetComponent<TextMeshProUGUI>().text = Leaders[4].ToString();

    }

    // Update is called once per frame
    void Update() {

    }

    public void resetHighScores() {
        //resets on next reload
        PlayerPrefs.SetString("HighScore_DSTR0", "ABC");
        PlayerPrefs.SetString("HighScore_DSTR1", "DEF");
        PlayerPrefs.SetString("HighScore_DSTR2", "GHI");
        PlayerPrefs.SetString("HighScore_DSTR3", "JKL");
        PlayerPrefs.SetString("HighScore_DSTR4", "MNO");

        PlayerPrefs.SetInt("HighScore_D0", 0);
        PlayerPrefs.SetInt("HighScore_D1", 0);
        PlayerPrefs.SetInt("HighScore_D2", 0);
        PlayerPrefs.SetInt("HighScore_D3", 0);
        PlayerPrefs.SetInt("HighScore_D4", 0);


        PlayerPrefs.Save();

        /*
         * attempt to make scores reset immediately, giving up for now but ill be back
         * 
        for(int l = 0; l < Leaders.Count; l++) {
            string curPref = "HighScore" + l;
            string curPrefSTR = "HighScoreSTR" + l;

            Leaders[l].Name = PlayerPrefs.GetString(curPrefSTR);
            Leaders[l].Score = PlayerPrefs.GetInt(curPref);

        }
        */

        HiScoreText0.GetComponent<TextMeshProUGUI>().text = Leaders[0].ToString();
        HiScoreText1.GetComponent<TextMeshProUGUI>().text = Leaders[1].ToString();
        HiScoreText2.GetComponent<TextMeshProUGUI>().text = Leaders[2].ToString();
        HiScoreText3.GetComponent<TextMeshProUGUI>().text = Leaders[3].ToString();
        HiScoreText4.GetComponent<TextMeshProUGUI>().text = Leaders[4].ToString();
    }


    public void checkLeaderboard() {
        Leader temp = new Leader() { Name = mainIn.text.ToString(), Score = points };
        Debug.Log("temp: " + temp.ToString());
        int i = 0;
        foreach(Leader l in Leaders) {
            string curPref = "HighScore" + i;
            if(temp.Score > l.Score) {
                break;
            }


            //Debug.Log("1" + curPref + " : " + PlayerPrefs.GetString(curPref) + ", " + PlayerPrefs.GetInt(curPref));
            //Debug.Log("1Leaders " + i + " : " + l);
            i++;

        }
        Leaders.Insert(i, temp);
        //seperate for loop specifically for printing the full Leaders list
        int j = 0;
        foreach(Leader lead in Leaders) {
            string curPref = "HighScore_D" + j;
            string curPrefSTR = "HighScore_DSTR" + j;
            string nam = lead.Name;
            Debug.Log("nam = " + nam);
            if((lead.Name != PlayerPrefs.GetString(curPrefSTR)) || (lead.Score != PlayerPrefs.GetInt(curPref))) {
                //Debug.Log("ENters IF");
                PlayerPrefs.SetString(curPrefSTR, nam);
                PlayerPrefs.SetInt(curPref, lead.Score);
                PlayerPrefs.Save();
                //Debug.Log(PlayerPrefs.GetString(curPrefSTR));
            }


            Debug.Log("2" + curPref + " : " + PlayerPrefs.GetString(curPrefSTR) + ", " + PlayerPrefs.GetInt(curPref));
            Debug.Log("2Leaders " + j + " : " + lead);
            j++;
        }
        if(Leaders.Count > 0) { //prevent IndexOutOfRangeException for empty list
            Leaders.RemoveAt(Leaders.Count - 1);
        }
        PlayerPrefs.Save();

        HiScoreText0.GetComponent<TextMeshProUGUI>().text = Leaders[0].ToString();
        HiScoreText1.GetComponent<TextMeshProUGUI>().text = Leaders[1].ToString();
        HiScoreText2.GetComponent<TextMeshProUGUI>().text = Leaders[2].ToString();
        HiScoreText3.GetComponent<TextMeshProUGUI>().text = Leaders[3].ToString();
        HiScoreText4.GetComponent<TextMeshProUGUI>().text = Leaders[4].ToString();
    }
}

