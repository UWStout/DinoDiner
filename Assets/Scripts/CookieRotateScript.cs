using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieRotateScript : MonoBehaviour
{
    public float rSpeed;
    private RectTransform rect;
    private Vector3 rotator;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        rotator = new Vector3(0, 0, rSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rect.eulerAngles += rotator;
    }
}
