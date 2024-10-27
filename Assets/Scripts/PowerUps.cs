using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int ID;
    public int timeLimit;
    public int activeTimeLimit;
    public bool isActive;
    SkillSlot skillSlot;
    // Start is called before the first frame update
    void Awake()
    {
        skillSlot = GetComponentInParent<SkillSlot>();
    }

    private void LateUpdate()
    {
        //if (skillSlot.ID1 == 0 && skillSlot.timeLimit1 == 0 || skillSlot.ID2 == 0 && skillSlot.timeLimit2 == 0)
        //{
        //    gameObject.SetActive(false);
        //}
        if (ID == skillSlot.ID1)
        {
            StartCoroutine(skillSlot.TimeOff1());
        }

        if (ID == skillSlot.ID2)
        {
            StartCoroutine(skillSlot.TimeOff2());
        }
    }
}
