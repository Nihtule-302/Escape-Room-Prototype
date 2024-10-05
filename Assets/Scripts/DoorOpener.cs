using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Transform originalPosition;
    [SerializeField] private Transform destinationPosition;
    [SerializeField] private float startDelayTime;
    [SerializeField] private float movementTime;

    private void Awake()
    {
        originalPosition = transform;
    }

    public void StartOpening()
    {
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(startDelayTime);
        LeanTween.move(gameObject, destinationPosition, movementTime);
        Debug.Log("Door Opened");
    }
}
