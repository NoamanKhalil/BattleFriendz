using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class LoginSystem : MonoBehaviour {

    private string url_login = "http://lpeat.000webhostapp.com/login.php";

    public static int UserID;
   // public static string UserName, UserPassword, UserEmail, InputName, InputPassword;
    public string UserName, UserPassword, UserEmail, InputName, InputPassword;
    public static bool UserLoggedIn;

    public Text UserNameText, UserPasswordText, LoginText;

    // Use this for initialization
    void Start ()
    {
        UserLoggedIn = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (UserLoggedIn == true)
        {
            Application.LoadLevel("Connecting");
        }
	}

    public void DoLogin()
    {
        UserName = UserNameText.text;
        UserPassword = UserPasswordText.text;

        if (UserName == "" || UserPassword == "")
        {
            LoginText.text = "Please complete all fields";
        }
        else
        {
        WWWForm form = new WWWForm();
        form.AddField("Username", UserName);
        form.AddField("Userpassword", UserPassword);
        WWW w = new WWW(url_login, form);
        StartCoroutine(Login(w));
        }

      
    }
    IEnumerator Login(WWW w)
    {
        yield return w;
        if (w.error == null)
        {
                UserName = w.text;
                Debug.Log(w.text);
                // UserID = System.Int32.Parse(Regex.Match(w.text, "(?<=UserID=)[0-9]+").ToString());
                UserLoggedIn = true;
            // LoginText.text = "logged in successfully";
            // string[] values = w.text.Split("\t"[0]);
            //UserID = System.Int32.Parse(values[0]);
            //  UserName = values[0];
            //LoginText.text = UserName + "logged in successfully";
            LoginText.text = w.text;

        }
            else
            {
               LoginText.text = "ERROR: " + w.error;
            }
       
    }

    public void GetUserName()
    {
        InputName = UserNameText.text.ToString();
    }

    public void GetPassword()
    {
        InputPassword = UserPasswordText.text.ToString();
    }
}
