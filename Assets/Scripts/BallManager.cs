using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallManager : MonoBehaviour
{
    public Transform block;
    public int _blockMax = 4;
    public int _xAxis = 15;
    public int _yAxis = 10;
    public float _speed = 80;
    public int _waveSet = 5;
    public float playerHp = 5;
    public GameObject text;
    int count;
    int wave;
    float[] pointElement;
    bool isBall;
    HashSet<Vector3> vec = new HashSet<Vector3>();
    Vector3 blockPosition;
    Vector3 minusBlockPosition;
    Quaternion q = Quaternion.identity;
    new Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        count = 0;
        wave = 0;
        isBall = false;
        rigidbody = GetComponent<Rigidbody>();
        pointElement = new float[3];
        pointElement[2] = playerHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBall)
        {
            isBall = true;
            rigidbody.AddForce((transform.forward + transform.right) * _speed, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        BallVelocityControl();
        rigidbody.velocity = rigidbody.velocity.normalized * 80;
        if (collision.collider.tag == "Bar" || collision.collider.tag == "UnderFrame" || collision.collider.tag == "Block"){
            if (collision.collider.tag == "Bar" && wave % _waveSet == 0)
            {
                BlockGenerator(vec);
                
            }
            if (collision.collider.tag == "Bar")
            {
                wave++;
            }
            else if (collision.collider.tag == "UnderFrame")
            {
                pointElement[1] = 0;
                pointElement[2]--;
                if (pointElement[2] == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            else
            {
                pointElement[0] += 10 + (10 * pointElement[1]);
                pointElement[1] += 0.1f;
                text.SendMessage("ScoreGetter", pointElement);
            }
        }
    }

    void BallVelocityControl()
    {
        Vector3 vector = rigidbody.velocity;

        if (vector.x > -5 && vector.x <= 0)
        {
            vector.x = -5;
        }
        else if (vector.x < 5 && vector.x > 0)
        {
            vector.x = 5;
        }

        if (vector.y > -10 && vector.y <= 0)
        {
            vector.x = -10;
        }
        else if (vector.y < 10 && vector.y > 0)
        {
            vector.x = 10;
        }
    }
    
    void BlockGenerator(HashSet<Vector3> vectors)
    {
        blockPosition = block.position;
        minusBlockPosition = blockPosition;
        //0~4まで
        if (count >= 4)
        {
            count = 0;
        }
        blockPosition.x -= _xAxis * count;

        for (int i = 0; i < _blockMax; i++)
        {
            minusBlockPosition = new Vector3(-blockPosition[0], blockPosition[1], blockPosition[2]);
            if (!vectors.Contains(blockPosition))
                Instantiate(block, blockPosition, q);
            if (!vectors.Contains(minusBlockPosition))
                Instantiate(block, minusBlockPosition, q);
            blockPosition.y -= _yAxis;
        }
        count++;
    }

    public HashSet<Vector3> BlockCheck(HashSet<Vector3> vectors)
    {
        vec = vectors;
        return vec;
    }
}
