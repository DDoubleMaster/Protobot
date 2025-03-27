using UnityEngine;

public class PlatformerZone : MonoBehaviour
{
    GameManager gMan;
    Renderer _render;
    Color nextColor = Color.black;

    private void Start()
    {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _render = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Color currentColor = _render.material.color;
        _render.material.color = Color.Lerp(currentColor, nextColor, Time.deltaTime * 25.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gMan.SetCurrentPlatform(GetComponentInParent<Platformer>());
            nextColor = Color.clear;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            nextColor = Color.black;
    }
}
