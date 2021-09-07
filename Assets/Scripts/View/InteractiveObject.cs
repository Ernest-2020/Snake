using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IExecute
{
    private bool _isInteractable = true;
    protected abstract void Interaction();
    protected abstract void Magnet();


    private void OnTriggerEnter(Collider other)
    {
        if (!_isInteractable || other.CompareTag("ConusCollider"))
        {
            Magnet();
        }
        if (!_isInteractable || other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Interaction();
        }
        if (!_isInteractable || other.CompareTag("Fever"))
        {
            Interaction();
            Destroy(gameObject);
        }



    }
    public abstract void Execute();
   
}
