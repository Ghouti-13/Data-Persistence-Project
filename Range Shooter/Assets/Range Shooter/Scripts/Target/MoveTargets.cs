using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargets : MonoBehaviour
{
    [SerializeField] private float minimumXValue = 0f, maximumXValue = 0f;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        if (!GameManager.Instance.IsCountDown) return;

        MoveTargetsLine();
    }
    private void MoveTargetsLine()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.localPosition.x > maximumXValue)
            moveSpeed *= -1;
        else if (transform.localPosition.x < minimumXValue)
            moveSpeed *= -1;
    }
}
