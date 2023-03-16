using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Material _defaultmaterial;
    [SerializeField] private Material _undamageableMaterial;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _confetti;


    public void SetDefaultMaterial()
    {
        _meshRenderer.material = _defaultmaterial;
    }

    public void SetUndamageableMaterial()
    {
        _meshRenderer.material = _undamageableMaterial;
    }

    public void StartConfetti()
    {
        _confetti.Play();
    }
}
