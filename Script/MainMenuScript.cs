
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void SelectPlayer()
    {
        SceneManager.LoadScene( 0 , LoadSceneMode.Single);
    }



    public void play()
    {

        SceneManager.LoadScene( 1 , LoadSceneMode.Single);
    }
}
