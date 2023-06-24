

using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    
    public GameObject FailsText;
    public GameObject compText;
    public GameObject SplashE;
    public Rigidbody rb= new Rigidbody();
    public Transform camPosition;
    private Vector3 storePosition;
    public Image loadBoost;
    private bool popit = false;
    public float score=0f;
    private bool fail=false;
    private float _ToStartTimer = 0f;
    private bool check=false;
    public bool isplay=false;
    public AudioClip BallHitClip;
    public AudioClip FailedHitClip;
    public AudioClip BoostClip;
    public AudioClip WinClip;
    public AudioSource ScndSource;
    private bool checkW;
    public Color splashColor;
    private void Start()
    {
        checkW=false;
        // FailsText = GameObject.Find("Failed");    
        rb = GetComponent<Rigidbody>();
        int level = PlayerPrefs.GetInt("Level");
        PlayerPrefs.DeleteAll();
        if (GlobalValues.playerNo == 0)
        {
            splashColor = Color.blue ;
        }
        else if (GlobalValues.playerNo == 1)
        {
            splashColor = Color.white;
        }
        else if (GlobalValues.playerNo == 2)
        {
            splashColor = Color.yellow;
        }
        else if (GlobalValues.playerNo == 3)
        {
            splashColor = Color.black;
        }

        // if (SceneManager.GetActiveScene().buildIndex!=level)
        // {
        //     SceneManager.LoadScene(level,LoadSceneMode.Single);
        // }
        // else
        // {
        //     PlayerPrefs.DeleteKey("Level");
        //     PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        // }
        //

        compText.gameObject.SetActive(false);
    
        // PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        if (isplay)
        {
            Time.timeScale = 1f;
            if (Input.anyKey && fail==false)
            {
                // CollidedSE(BallHitClip);
                rb.velocity = new Vector3(0f,-20f,0f);
                GlobalValues.missionStarted = true;
            }
            if (Input.anyKey && fail==true)
            {
                CollidedSE(FailedHitClip);
                Time.timeScale = 0f;
                Invoke("failed",0.68f);
            }
            if (fail!=true)
            {
                ToBoost();
            }
        }
        else
        {
            Time.timeScale = 0.7f;
        }
    }
    private void OnCollisionEnter(Collision obj)
    {
        GameObject splash = Instantiate(SplashE);
        splash.transform.position=new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        splash.transform.localScale = transform.localScale/3f;
        splash.transform.parent = obj.transform;
        splash.transform.localEulerAngles = new Vector3(90, Random.Range(0, 359), 0);
        splash.GetComponent<SpriteRenderer>().color = splashColor;
        if (splash.gameObject.tag == "splash")
        {
            Destroy(splash.gameObject,2f);
        }
        rb.velocity = new Vector3(0,30f,0);
        CollidedSE(BallHitClip);
        if (Input.anyKey && obj.gameObject.CompareTag("Object") && ( fail==false ) )
        {
            obj.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            // obj.collider.enabled = false;
            /*obj.transform.Rotate(xAngle:30f,);*/
            WaitDestroy(obj.gameObject);
            score++;
        }
        camPosition.position=obj.transform.position + new Vector3(0f,8f,-18f);
        camPosition.LookAt(obj.transform);
        if (obj.gameObject.CompareTag("Complete"))
        {
            while (checkW==false)
            {
                CollidedSE(WinClip);
                checkW=true;
            }
            loadBoost.gameObject.SetActive(false);
            compText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Level",SceneManager.GetActiveScene().buildIndex+1);
            Invoke("Complete_Mission",4f);
        }
        if (Input.anyKey && obj.gameObject.CompareTag("Obstecle"))
        {
            if (popit==true)
            {
                obj.transform.parent.gameObject.SetActive(false);
                score++;
            }
            else
            {
                fail = true;
                FailsText.gameObject.SetActive(true);
            }
        }
    }
    private void OnCollisionStay(Collision obj)
      {
         
          rb.velocity = new Vector3(0,1,0);
          if (Input.anyKey && obj.gameObject.CompareTag("Object") )
          {
              obj.gameObject.SetActive(false);
          }
      }
    private void OnCollisionExit(Collision obj)
    {
        rb.velocity = new Vector3(0,7,0);
    }
    private string Complete_Mission()
    {
        if (Input.GetMouseButton(0)||Input.GetMouseButton(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        return null;
    }
    private void ToBoost()
    {
        if (_ToStartTimer > 0f && check == false) 
        {
            _ToStartTimer -= Time.deltaTime * .3f; 
            loadBoost.fillAmount = _ToStartTimer;
            popit = false;
        }
        if (Input.anyKey && fail != true && check == false)
        {
            _ToStartTimer += Time.deltaTime * .9f; 
            if (_ToStartTimer >= 1f)
            {
                ScndSource.clip = BoostClip;
                ScndSource.Play();
                check = true;
            }
            popit = false;
            loadBoost.fillAmount = _ToStartTimer;
        }
        if (check == true)
        {
            _ToStartTimer -= Time.deltaTime * .5f; 
            loadBoost.fillAmount = _ToStartTimer; 
            if (_ToStartTimer <= 0f) 
            { 
                check = false;
            }
            popit = true;
        }
    }

    public void play()
    {
        isplay = true;
    }
    private void CollidedSE(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
    private void failed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator WaitDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj.transform.parent.gameObject);

    }
};
