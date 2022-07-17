using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public DiceScroller[] dicerollers;
    public float rollrate;

    public DiceScroller currentlySelected;
    public int currentlySelectedInt;
    public Image selectedBorder;
    public int currentlySelectedValue;

    public bool[] availableDice;

    public float mouseScroll = 0;

    // Start is called before the first frame update
    void Start()
    {
        dicerollers = GetComponentsInChildren<DiceScroller>();

        for (int i = 0; i < dicerollers.Length; i++)
        {
            dicerollers[i].rollRate = rollrate;
        }

        availableDice = new bool[] { true, true, true, true };
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) currentlySelectedInt = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentlySelectedInt = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentlySelectedInt = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentlySelectedInt = 3;

        currentlySelectedInt -= Mathf.RoundToInt(Input.mouseScrollDelta.y);

        if (currentlySelectedInt < 0) currentlySelectedInt = 0;
        if (currentlySelectedInt > 3) currentlySelectedInt = 3;

        currentlySelected = dicerollers[currentlySelectedInt];

        for (int i = 0; i < dicerollers.Length; i++)
        {
            DiceScroller diceroller = dicerollers[i];

            if (!availableDice[i])
            {
                diceroller.GetComponent<Image>().color = new Color(diceroller.GetComponent<Image>().color.r,
                                                                   diceroller.GetComponent<Image>().color.b,
                                                                   diceroller.GetComponent<Image>().color.g, 0.25f);
            }
            else
            {
                diceroller.GetComponent<Image>().color = new Color(diceroller.GetComponent<Image>().color.r,
                                                                   diceroller.GetComponent<Image>().color.b,
                                                                   diceroller.GetComponent<Image>().color.g, 1);
            }

            if (i == currentlySelectedInt)
            {
                selectedBorder.transform.position = currentlySelected.transform.position;
            }
        }

        currentlySelectedValue = currentlySelected.value;
    }
}
