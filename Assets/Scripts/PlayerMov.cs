using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public CharacterController myController;
    public float speed = 5f;
    public Vector3 velocity;
    //public float jumpForce = 5f;
    public float gravity = -9.81f;
    private bool grounded;


    // Update is called once per frame
    void FixedUpdate()
    {
      float Horizontal = Input.GetAxis("Horizontal");
      float Vertical = Input.GetAxis("Vertical");
      Vector3 move = new Vector3(Horizontal, 0, Vertical);
      myController.Move(move * speed * Time.deltaTime);
      /*Vector3 forward = Camera.main.transform.forward;
      Vector3 right = Camera.main.transform.right;
      forward.y = 0f;
      right.y = 0f;
      forward.Normalize();
      right.Normalize();
      Vector3 moveDirection = (forward * Vertical) + (right * Horizontal);

      if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            myController.Move(velocity * Time.deltaTime);
        }*/

    if (grounded == false)
        {
            velocity.y = gravity;
            myController.Move(velocity * Time.deltaTime);

        }
        //myController.Move(moveDirection * speed * Time.deltaTime);



    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Finish"))
    {
        FindObjectOfType <GameFlowManager> ().WinGame();
    }
}

}
