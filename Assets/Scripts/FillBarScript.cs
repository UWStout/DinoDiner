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
            CurrentValue = (linkedOven.timeLeft / linkedOven.bakeSpeed);
            if (CurrentValue < 0)
            {
                //slowly turn the bar red
                //temp comment
            }
        }
    }
}
