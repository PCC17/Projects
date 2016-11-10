using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float precission = 0.1f;
    [SerializeField]
    private GameObject body;

    [SerializeField]
    private Transform endPoint1;
    [SerializeField]
    private Transform endPoint2;

    [SerializeField]
    private SenderScript senderScript;

    private bool isJumping;
    private Vector3 targetPosition;

    private Animator animator;
    private AudioSource audioSourceFoodStep;

    private TouchManager touchManager;

	// Use this for initialization
	void Start ()
	{
	    animator = body.GetComponent<Animator>();
	    audioSourceFoodStep = body.GetComponent<AudioSource>();
        touchManager = TouchManager.Instance;

	    //touchManager.delClickBegan += PlayAnimationSquat;
	    //touchManager.DelClickEnded += PlayAnimationStandUp;
        touchManager.delSwipeRight += MakeJumpRight;
        touchManager.delSwipeLeft += MakeJumpLeft;
        touchManager.delSwipeUp += MakeJumpForward;
        touchManager.delSwipeDown += MakeJumpBack;


    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    touchManager.Update();
	    if (isJumping)
        {
            ProcedureJump();
        }
    }

    void PlayAnimationSquat()
    {
        Debug.Log("Squat");
        if (!isJumping && animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAnimations"))
            animator.SetTrigger("Squat");
    }

    void PlayAnimationStandUp()
    {
        Debug.Log("AntiSquat");
       // if (!isJumping && animator.GetCurrentAnimatorStateInfo(0).IsName("BeforeJumpIdle"))
            animator.SetTrigger("AntiSquat");
    }

    void MakeJumpForward()
    {
        Debug.Log("Forward");
        if (!isJumping && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            MakeJump(Vector3.forward);
    }
    void MakeJumpBack()
    {
        Debug.Log("Back");
        if (!isJumping && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            MakeJump(Vector3.back);
    }
    void MakeJumpRight()
    {
        Debug.Log("Right");
        if (!isJumping && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            MakeJump(Vector3.right);
    }
    void MakeJumpLeft()
    {
        Debug.Log("Left");
        if (!isJumping && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            MakeJump(Vector3.left);
    }

    void MakeJump(Vector3 direction)
    {
        if(transform.position.x + direction.x < endPoint1.position.x && transform.position.x + direction.x > endPoint2.position.x)
            if (transform.position.z + direction.z > endPoint1.position.z &&
                transform.position.z + direction.z < endPoint2.position.z)
            {
                isJumping = true;
                animator.SetTrigger("Jump");
                targetPosition = transform.position + direction;
                if (direction == Vector3.forward)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                if (direction == Vector3.right)
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                if (direction == Vector3.back)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                if (direction == Vector3.left)
                    transform.rotation = Quaternion.Euler(0, -90, 0);
            }
    }

    void ProcedureJump()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Mathf.Abs(Vector3.Distance(transform.position, targetPosition)) <= precission)
        {
            audioSourceFoodStep.Play();
            Color c = GetColorUnderPlayer();
            senderScript.SendData(new[] { (byte)(c.r * 255), (byte)(c.g * 255), (byte)(c.b * 255) });
            isJumping = false;
        }
    }

    private Color GetColorUnderPlayer()
    {
        RaycastHit hit;
        Ray ray = new Ray(body.transform.position, Vector3.down);
        Physics.Raycast(transform.position, ray.direction, out hit, 15f);
    
        Texture2D tex = hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        return tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
       
    }
}
