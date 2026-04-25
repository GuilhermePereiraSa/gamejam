using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float lifeTime = 3f;
    public float initialScale = 3f;

    private float _tempoPassado = 0f;

    void Start()
    {
        transform.localScale = Vector3.one * initialScale;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        _tempoPassado += Time.deltaTime;
        float t = _tempoPassado / lifeTime;
        transform.localScale = Vector3.one * Mathf.Lerp(initialScale, 0f, t);
    }
}