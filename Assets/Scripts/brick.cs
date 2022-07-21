using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public int hits = 1;
    public int score = 100;
    public Vector3 rotator;
    public Material hitMat;

    Material _originalMaterial;
    Renderer _renderer;
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y)*0.1f);
        _renderer = GetComponent<Renderer>();
        _originalMaterial = _renderer.sharedMaterial;
    }

    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        if (hits <= 0)
        {
            GameManager.Instance.Score += score;
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMat;
        Invoke("RestoreMaterial", 0.1f);
    }

    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _originalMaterial;
    }
}
