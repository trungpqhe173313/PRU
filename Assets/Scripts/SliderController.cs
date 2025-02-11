using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    Slider slider;

    int index = 10; 
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(index < 1)
        {
            index = 1;
        } else if(index > 10)
        {
            index = 10;
        }
    }

    public void DecreaseHP()
    {
        slider.value = index--;
    }

    public int GetHP()
    {
        return index;
    }
}
