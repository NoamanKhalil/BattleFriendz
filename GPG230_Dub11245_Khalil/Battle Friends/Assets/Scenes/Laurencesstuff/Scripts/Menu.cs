using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    //simple menu switching script

	public void MenuChanger (string MenueSwitch)
    {

		SceneManager.LoadScene (MenueSwitch);

        
	}

	public void Exit()
    {
		Debug.Log ("Request Exit");
		Application.Quit ();

    }

   

}
