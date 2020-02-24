using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderExplosion : MonoBehaviour
{
    [SerializeField] private int _loopDuration;

    [SerializeField] private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float r = Mathf.Sin((Time.time / _loopDuration) * (2 * Mathf.PI)) * 0.5f + 0.25f;
        float g = Mathf.Sin((Time.time / _loopDuration + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
        float b = Mathf.Sin((Time.time / _loopDuration + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
        float correction = 1 / (r + g + b);
        r *= correction;
        g *= correction;
        b *= correction;
        _meshRenderer.material.SetVector("_ChannelFactor", new Vector4(r, g, b, 0));
    }
}
