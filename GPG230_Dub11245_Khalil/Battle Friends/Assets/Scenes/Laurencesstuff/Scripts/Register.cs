using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//using Photon;
using UnityEngine;
using UnityEngine.UI;


public class Register : MonoBehaviour {

    private string url_Register = "http://lpeat.000webhostapp.com/Register.php";


    public static int UserID;
   // public static string UserName, UserPassword, UserEmail, InputName, InputPassword;
    public string UserName, UserPassword, userPassword2, UserEmail, InputEmail, InputName, InputPassword, InputPassword2, verifiedPassword;
    public static bool UserLoggedIn;
  //  public static bool goodPassword;

    public Text UserNameText, UserEmailText, UserPasswordText, UserPasswordText2, UserRegisterStatText;

    // Use this for initialization
    void Start ()
    {
      //  goodPassword = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoRegister()
    {
      //  GetUserPassword();

        UserPassword = UserPasswordText.text;
        userPassword2 = UserPasswordText2.text;
        UserName = UserNameText.text;
        UserEmail = UserEmailText.text;


        //if (goodPassword == false)
        //{
        //    return;
        //}
        if (UserName == "" || UserPassword == "" || userPassword2 == "" || UserEmail == "") {//IF THE PLAYER HASN'T ENTERED THE REQUIRED INFORMATION...TELL THEM TO
            UserRegisterStatText.text = "Please complete all fields."; }
        else
        {
            if (UserPassword == userPassword2)
            {
              WWWForm form = new WWWForm();
              form.AddField("username", UserName);
              form.AddField("userpassword", userPassword2);
              form.AddField("useremail", UserEmail);

              WWW w = new WWW("http://lpeat.000webhostapp.com/Register.php", form);
              StartCoroutine(UserRegister(w));
            }
            else
            {
                UserRegisterStatText.text = "Passwords dont match";
            }
       
        }
        
    }
    IEnumerator UserRegister (WWW w)
    {
        yield return w;
        if (w.error == null)
        {
            UserRegisterStatText.text = w.text;
        }
            else
            {
            UserRegisterStatText.text = "ERROR: " + w.error;
            }
       // }
    }

    //public void GetUserName()
    //{
    //    InputName = UserNameText.text.ToString();
    //}

    //public void GetPass1()
    //{
    //    InputPassword = UserPasswordText.text.ToString();
    //}
    //public void GetPass2()
    //{
    //    InputPassword2 = UserPasswordText2.text.ToString();
    //}

    //public void GetUserEmail()
    //{
    //    InputEmail = UserEmailText.text.ToString();
    //}

    //////public void GetUserPassword()
    //////{
    //////    verifiedPassword = string.Empty;
       
    //////    InputPassword2 = UserPasswordText2.text.ToString();
    //////    if (InputPassword == InputPassword2)
    //////    {
    //////        verifiedPassword = InputPassword;
    //////        goodPassword = true;
    //////    }
    //////    else
    //////    {
    //////        UserRegisterStatText.text = "Passwords don't match";
    //////    }

    //////}
}
