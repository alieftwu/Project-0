using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;
    float horizontalInput;
    [SerializeField] public float horizontalMultiplier = 2;
    [SerializeField] LayerMask groundMask;
    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    private void FixedUpdate ()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart",2);
    }
       void Restart ()
    {
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check if we're grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.1f, groundMask);
        //If we are, jump
        rb.AddForce(Vector3.up * jumpForce);
    }
}
