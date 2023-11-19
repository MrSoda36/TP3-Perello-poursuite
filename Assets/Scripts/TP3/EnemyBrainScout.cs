using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBrainScout : MonoBehaviour
{
    public Transform[] targets;
    public Transform currentTarget;
    public int currentTargetIndex = 0;
    public Transform[] doneTargets;
    public float speed = 5f;
    public bool isTargetTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targets[currentTargetIndex];
        doneTargets[currentTargetIndex] = targets[currentTargetIndex];
        doneTargets = new Transform[targets.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTargetTouched) {
            Vector3 direction = currentTarget.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

            if (MathHelper.VectorDistance(currentTarget.position, transform.position) <= 0.3f) {
                isTargetTouched = true;
                return;
            }

            Vector3 velocite = speed * Time.deltaTime * direction.normalized;

            transform.Translate(velocite, Space.World);
        }
        else {
            if(currentTargetIndex == targets.Length - 1 ) {
                currentTargetIndex = 0;
                Array.Clear(doneTargets, 0, targets.Length);
                currentTarget = targets[currentTargetIndex];
            } else {
                doneTargets[currentTargetIndex] = currentTarget;
                currentTargetIndex++;
                currentTarget = targets[currentTargetIndex];
            }
            isTargetTouched = false;
        }
    }
}
