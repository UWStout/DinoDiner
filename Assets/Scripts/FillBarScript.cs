using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarScript : MonoBehaviour
{
    // Unity UI references
    public Slider slider;
    //public Text displayText;
    public OvenScript linkedOven;
    public Image fillBar;
    private Color tempBarcolor = new Color32(0,1,0,1);
    public Image handleImage;
    private float opNum = 0;
    private float currentValue = 1f;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            slider.value = currentValue;
            //displayText.text = (slider.value * 100).ToString("0") + "%";
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (linkedOven.baking)
        {
            if (!linkedOven.burning) {
                CurrentValue = (linkedOven.timeLeft / linkedOven.bakeSpeed);
            }
            else if(linkedOven.burning)
            {
                CurrentValue = -1 * (linkedOven.timeLeft / linkedOven.bakeSpeed);
                opNum = CurrentValue / 50;
                tempBarcolor.r += opNum;
                tempBarcolor.g -= opNum; //color is from 0 to 1, so we need to divide Currentvalue by a larger number to get it in that range for gradual coloration
                tempBarcolor.b = 0;
                tempBarcolor.a = 1;
                fillBar.color = tempBarcolor;

            }
            else if (linkedOven.burned)
            {
                tempBarcolor.r = 1;
                tempBarcolor.g = 0;
                tempBarcolor.b = 0;
                tempBarcolor.a = 1;
                fillBar.color = tempBarcolor;
            }
        }
        else
        {
            CurrentValue = 1f;
            tempBarcolor.r = 0;
            tempBarcolor.g = 1;
            tempBarcolor.b = 0;
            tempBarcolor.a = 1;
            fillBar.color = tempBarcolor;
        }
    }
}
