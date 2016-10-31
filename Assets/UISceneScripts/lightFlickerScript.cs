using UnityEngine;
using System.Collections;


// DestroyBlock.cs 에서 프레임마다 제거할 블록을 계산하고 있으니까
// 거기서 제거할 블록이 생긴 프레임에서 이곳의 doFlicker() 를 부르게 하자.
public class lightFlickerScript : MonoBehaviour
{

    Light thisLight;
    public bool noFlicker = false;
    // Use this for initialization
    void Start()
    {
        thisLight = transform.GetComponent<Light>();
        thisLight.enabled = false;
    }

    public float lightTime = 0.0f;

    float testFlicker = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (thisLight.enabled)
        {
            lightTime -= Time.deltaTime;
            if (lightTime < 0) thisLight.enabled = false;
        }

        // to test flickering
        // testing()
    }
    void testing()
    {
        if (testFlicker < 0f)
        {
            doFlicker(.5f);
            testFlicker = 1f;
        }
        testFlicker -= Time.deltaTime;
    }

    public void doFlicker(float howLong)
    {
        if (noFlicker) return;
        thisLight.enabled = true;
        lightTime = howLong;
    }
}
