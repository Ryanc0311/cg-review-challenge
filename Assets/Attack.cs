using System.Collections;
using UnityEngine;



public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private float attackCooldown = 2f;

    private float _nextAttackTime;
    private Vector3 _camPos;
    private Camera _camera;

    private GameObject _otherEnemy;
    private GameObject _otherPlayer;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Time.time > _nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _otherEnemy = GameObject.FindWithTag("enemy");
                StartCoroutine(FlashColorEnemy(_otherEnemy));

                _otherPlayer = GameObject.FindWithTag("Player");
                StartCoroutine(FlashColorPlayer(_otherPlayer));

                _nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private IEnumerator FlashColorEnemy(GameObject hit)
    {
        hit.GetComponent<Renderer>().material.SetColor("_RimColor", Color.white);
        yield return new WaitForSeconds(0.1f);
        hit.GetComponent<Renderer>().material.SetColor("_RimColor", new Color32(0, 128, 128, 0));
    }
    private IEnumerator FlashColorPlayer(GameObject hit)
    {
        hit.GetComponent<Renderer>().material.SetColor("_RimColor", Color.white);
        yield return new WaitForSeconds(2f);
        hit.GetComponent<Renderer>().material.SetColor("_RimColor", new Color32(0, 128, 128, 0));
    }
}