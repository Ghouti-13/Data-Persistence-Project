using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargets : MonoBehaviour
{
    [Header("Line Limit on X Axis")]
    [SerializeField] private float _xLimit = 4f;
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        MoveTargetsLine();
    }
    private void MoveTargetsLine()
    {
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);

        if (transform.localPosition.x > _xLimit)
            _moveSpeed *= -1;
        else if (transform.localPosition.x < -_xLimit)
            _moveSpeed *= -1;
    }
}
