using UnityEngine;

[RequireComponent(typeof(Dinosaur))]
public class DinosaurCollisionHandler : MonoBehaviour
{
    private Dinosaur _dinosaur;

    private void Start()
    {
        _dinosaur = GetComponent<Dinosaur>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        
            _dinosaur.IncreaseScore();
        else
            _dinosaur.Die();
    }
}
