using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEfect : MonoBehaviour
{
    [SerializeField] private Transform followoingTarget;
    [SerializeField,Range(0f,1f)] private float paralax = 0.01f;

    [SerializeField] private bool disableVertical;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        if (!followoingTarget)
        {
            followoingTarget = Camera.main.transform;

            target = followoingTarget.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var delta = followoingTarget.position - target;

        if (disableVertical)
        {
            delta.y = 0;
            
        }

        target = followoingTarget.position;
        transform.position += delta * paralax;
    }
}
