using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDetector : MonoBehaviour
{
    [SerializeField]
    private SlimeController slimeController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Control de errores
        if (slimeController == null || !slimeController.gameObject.activeSelf)
        {
            return;
        }

        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            slimeController.SlimeTarget = collision.transform;
            slimeController.ChangeState(slimeController.ChaseState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Control de errores
        if (slimeController == null || !slimeController.gameObject.activeSelf)
        {
            return;
        }

        //if (collision.TryGetComponent(out Player _))
        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            slimeController.ChangeState(slimeController.PatrolState);
        }
    }
}
