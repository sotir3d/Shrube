using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    public float maxRange;
    public float intensity;
    public float time;

    float zOffset = -3;

    Light pointLight;

    Vector3 fixedPosition;

    bool minimize = false;

    // Use this for initialization
    void Start()
    {
        pointLight = GetComponent<Light>();

        pointLight.range = 0;

        maxRange = 25;

        //offset the position on the z axis
        fixedPosition = transform.position;
        fixedPosition.z = zOffset;
        transform.position = fixedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!minimize)
            pointLight.range = Mathf.Lerp(pointLight.range, maxRange, 0.1f);
        else
            pointLight.range = Mathf.Lerp(pointLight.range, 0, 0.1f);

        if ((maxRange - pointLight.range) < 0.1f)
            minimize = true;

        Invoke("Destroy", 1f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
