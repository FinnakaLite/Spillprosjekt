using UnityEngine;

public class MovingBlockTrap : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range; 
    [SerializeField] private float checkDelay;
    private float checkTimer;
    private Vector3 destination;

    private bool attacking;

    private Vector3[] directions = new Vector3[4];

    // Update is called once per frame
    void Update()
    {
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    void CheckForPlayer()
    {
        CalculateDirections();
        
        //Check if movingblocktrap sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Right Direction
        directions[1] = -transform.right * range; //Left Direction
        directions[2] = transform.up * range; //Up Direction
        directions[3] = -transform.up * range; //Down Direction
        
    }
}
