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
    private ParticleSystem particleSystemLanding;
    [SerializeField]
    private SenderScript senderScript;

    private bool isJumping;
    private Vector3 targetPosition;

    private Animator animator;
    private AudioSource audioSourceFoodStep;

	// Use this for initialization
	void Start ()
	{
	    animator = body.GetComponent<Animator>();
	    audioSourceFoodStep = body.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	    if (!isJumping)
	    {
	        if (Input.GetKeyDown(KeyCode.RightArrow))
	            MakeJump(Vector3.right);
	        else if (Input.GetKeyDown(KeyCode.LeftArrow))
	            MakeJump(Vector3.left);
	        if (Input.GetKeyDown(KeyCode.UpArrow))
	            MakeJump(Vector3.forward);
	        else if (Input.GetKeyDown(KeyCode.DownArrow))
	            MakeJump(Vector3.back);
	    }
        if (isJumping)
        {
            ProcedureJump();
        }
    }

    void MakeJump(Vector3 direction)
    {
        isJumping = true;
        animator.SetTrigger("Jump");
        targetPosition = transform.position + direction;
        if (direction == Vector3.forward)
            transform.rotation = Quaternion.Euler(0,0,0);
        if (direction == Vector3.right)
            transform.rotation = Quaternion.Euler(0, 90, 0);
        if (direction == Vector3.back)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        if (direction == Vector3.left)
            transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    void ProcedureJump()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Mathf.Abs(Vector3.Distance(transform.position, targetPosition)) <= precission)
        {
            audioSourceFoodStep.Play();
            particleSystemLanding.Play();
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
