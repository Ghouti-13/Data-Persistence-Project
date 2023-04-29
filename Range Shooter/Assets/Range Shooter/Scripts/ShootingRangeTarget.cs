using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeTarget : TargetScript
{
    [Header("Custom Fields")]
    [SerializeField] private float _xLimit = 4f;
    [SerializeField] private float _moveSpeed = 4f;

    protected override void Update()
    {
        base.Update();

        MoveTarget();
    }
    private void MoveTarget()
    {
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);

        if (transform.localPosition.x > _xLimit)
            _moveSpeed *= -1;
        else if (transform.localPosition.x < -_xLimit)
            _moveSpeed *= -1;
    }
}
