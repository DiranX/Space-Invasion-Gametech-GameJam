using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    public int ID1;
    public int ID2;
    public GameObject[] Slot;

    public int timeLimit1;
    public int timeLimit2;
    public bool isActive1;
    public bool isActive2;

    // Start is called before the first frame update
    void Start()
    {
        isActive1 = true;
        isActive2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        Slot[ID1].SetActive(true);
        if(timeLimit1 == 0)
        {
            ID1 = 0;
        }

        Slot[ID2].SetActive(true);
        if (timeLimit2 == 0)
        {
            ID2 = 0;
        }

        if (ID1 > 0 && ID2 > 0)
        {
            Slot[0].SetActive(false);
        }

    }

    public IEnumerator TimeOff1()
    {
        if (timeLimit1 > 0 && isActive1 == true)
        {
            isActive1 = false;
            yield return new WaitForSeconds(1);
            timeLimit1 -= 1;
            yield return new WaitForSeconds(1);
            isActive1 = true;
        }
    }
    public IEnumerator TimeOff2()
    {
        if (timeLimit2 > 0 && isActive2 == true)
        {
            isActive2 = false;
            yield return new WaitForSeconds(1);
            timeLimit2 -= 1;
            yield return new WaitForSeconds(1);
            isActive2 = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Modifikator"))
        {
            if (collision.gameObject.GetComponent<Modifikator>().ID == ID1 || collision.gameObject.GetComponent<Modifikator>().ID == ID2)
            {
                Destroy(collision.gameObject);
            }else if (ID1>0 && ID2>0)
            {
                Destroy(collision.gameObject);
            }

            if (ID1 == 0)
            {
                if(collision.gameObject.GetComponent<Modifikator>().ID != ID2)
                {
                    ID1 = collision.gameObject.GetComponent<Modifikator>().ID;
                    Destroy(collision.gameObject);
                    timeLimit1 = Slot[ID1].GetComponent<PowerUps>().activeTimeLimit;
                }
            }
            else if(ID1 > 0 && ID2 == 0)
            {
                if(collision.gameObject.GetComponent<Modifikator>().ID != ID1)
                {
                    ID2 = collision.gameObject.GetComponent<Modifikator>().ID;
                    Destroy(collision.gameObject);
                    timeLimit2 = Slot[ID2].GetComponent<PowerUps>().activeTimeLimit;
                }
            }
        }
    }
}
