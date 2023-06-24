using UnityEngine;
using Random = UnityEngine.Random;
using Random1 = System.Random;
namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public int totalScore;
        private Vector3 _v3;
        public Transform camPosition;
        public GameObject[] gObj;
        public GameObject pObj;
        public Material cubeclr;
        public Color[] clrArray;


        private void Awake()
        {
            pObj.transform.GetChild(GlobalValues.playerNo).gameObject.SetActive(true);
            GlobalValues.missionStarted = false;
            // pObj.SetActive(false);
            Generate();
            // Time.timeScale = 0f;
        }

        private void Generate()
        {
            cubeclr.color = clrArray[Random.Range(0, clrArray.Length)];
            Vector3 Pposition =new Vector3(0f,0f,0f);
            int index = 0;            
            Random1 rand = new Random1();
            totalScore= rand.Next((int)70, (int)100);
            float yaxis=0.8f;
            for (int i = 0; i < totalScore; i++)
            {
                Random1 rand1 = new Random1();
                index= rand.Next(0, (int)gObj.Length);
                
                if (i==0)
                {
                    _v3 = new Vector3(0f,yaxis,0f);
                    Instantiate(gObj[index],_v3,Quaternion.identity);
                    yaxis += -0.7f;  
                }
                else
                {
                    _v3 = new Vector3(0f,yaxis,0f);
                    _v3 += gObj[index].transform.position;
                    Pposition=Instantiate(gObj[index],_v3,Quaternion.identity).transform.position;
                    yaxis += .4f;   
                }

                pObj.transform.position =Pposition + new Vector3(0f, 4f, -2.04f);
            }


        }
    }
}
