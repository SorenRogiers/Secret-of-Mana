using UnityEngine;

public class Key : MonoBehaviour {

    public bool IsPickedUp { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsPickedUp = true;
            Destroy(this.gameObject);
        }
    }
}
