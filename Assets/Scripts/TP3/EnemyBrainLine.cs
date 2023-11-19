using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainLine : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool isPlayerTouched;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerTouched) {
            if (target != null) {
                Vector3 direction = target.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

                if (MathHelper.VectorDistance(target.position, transform.position) <= 0.3f) {
                    isPlayerTouched = true;
                    return;
                }

                Vector3 velocite = speed * Time.deltaTime * direction.normalized;

                transform.Translate(velocite, Space.World);
            }
            
        }
    }
}
