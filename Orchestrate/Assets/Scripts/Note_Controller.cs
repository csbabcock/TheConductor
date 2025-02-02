using UnityEngine;

public class Note_Controller : MonoBehaviour
{
    private bool canBeDestroyed = false, JustDestroyed = false;

    private Game_Controller GameController;

    void Start()
    {
        GameController = GameObject.Find("GameController").GetComponent<Game_Controller>();
    }

    void Update()
    {
        if (GameController.Health <= 0 || GameController.Score >= GameController.ScoreMaximumValue)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other != null )
            canBeDestroyed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other != null )
            canBeDestroyed = false;
    }

    public void DestroyThisObject()
    {
        if (canBeDestroyed)
        {
            GameController.ChangeScore(100);
            JustDestroyed = true;
            Destroy(gameObject, 0.0001f);
        }
            
    }
    public bool GetCanBeDestroyed() => canBeDestroyed;

    public bool GetJustDestroyed() => JustDestroyed;
}
