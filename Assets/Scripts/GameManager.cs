using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject winUI;
    [SerializeField] Vector2 boxSize;
    [SerializeField] LayerMask enemyLayer;

    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
    }
    private void Update()
    {
        if(Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, enemyLayer).Length == 0)
        {
            Win();
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;
    }
    void Win()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
