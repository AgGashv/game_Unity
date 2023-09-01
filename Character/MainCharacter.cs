using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{

    [SerializeField] private List<GameObject> list;

    [SerializeField] private Text flaskT;


    [SerializeField] private GameObject ragdoll;
    [SerializeField] private GameObject flaskdrink;
    [SerializeField] private GameObject swordLine;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject fireballIn;
    [SerializeField] private GameObject youDiedText;


    

    [SerializeField] private Image ImHP;
    [SerializeField] private Image ImMP;

    [SerializeField] public Animator anim;

    [SerializeField] public CharacterMovement characterMovement;

    [SerializeField] public CharacterStatus characterStatus;

    [SerializeField] private new CapsuleCollider collider;

    [SerializeField] private CameraConfig camCon;

    [SerializeField] private float colRadius;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForceWalk;
    [SerializeField] private float jumpForceRun;
    [SerializeField] public float HP = 1f;
    [SerializeField] private float mana = 1f;
    
    [SerializeField] public int HPflask;

    [SerializeField] private AudioSource musicStop;





    void Start() => collider = GetComponent<CapsuleCollider>();

    void Update()
    {

        list[HPflask].SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) && HP < 1f && HPflask > 0f && !Crouch() && characterStatus.isGround)
        {
            HP += 0.2f;
            HPflask -= 1;
            list[HPflask].SetActive(true);
            list[HPflask + 1].SetActive(false);
            anim.SetTrigger("Drinking");
        }

        if (HP > 1f)
            HP = 1f;

        if (HP <= 0)
        {
            youDiedText.SetActive(true);
            gameObject.SetActive(false);
            Instantiate(ragdoll, transform.position, transform.rotation);
            musicStop.Stop();
        }
        ImHP.fillAmount = HP;


        flaskT.text = "" + HPflask;

        if (mana > 1f)
            mana = 1f;
        if (mana < 0f)
            mana = 0f;

        mana += Time.deltaTime / 50f; 
        
        ImMP.fillAmount = mana;



        StartCoroutine(Casting());

        Crouch();

        Attack();

        Jump();

    }

    void FixedUpdate()
    {
        anim.SetBool("Sprint", characterStatus.isSprint);

        if (!characterStatus.isGround)
        {
            collider.radius = 0.2f;
            if (characterMovement.moveAmount != 0)
                transform.localPosition += Time.deltaTime * 4 * transform.forward;
            anim.SetBool("Ground", characterStatus.isGround);
        }
        else
        {
            anim.SetBool("Ground", characterStatus.isGround);
            collider.radius = colRadius;
        }

        characterStatus.isSprint = Run();
        characterStatus.isGround = Ground();


        if (!characterStatus.isSprint && characterStatus.isGround)
            StartCoroutine(AnimationWalk());

        else if (characterStatus.isGround && Crouch() && characterMovement.moveAmount != 0)
            transform.localPosition += walkSpeed * Time.fixedDeltaTime * transform.forward;

        else if (characterStatus.isSprint && characterStatus.isGround)
            StartCoroutine(AnimationRun());
    }

    IEnumerator AnimationWalk()
    {
        if (characterMovement.moveAmount != 0)
            transform.localPosition += walkSpeed * Time.fixedDeltaTime * transform.forward;
        yield return null;
        anim.SetFloat("vertical", characterMovement.moveAmount, 0f, Time.fixedDeltaTime);
    }
        

    IEnumerator AnimationRun()
    {
        if (characterMovement.moveAmount != 0)
            transform.localPosition += runSpeed * Time.fixedDeltaTime * transform.forward;
        yield return null;
        anim.SetFloat("vertical", characterMovement.moveAmount, 0.05f, Time.fixedDeltaTime);
    }

    bool Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && characterMovement.moveAmount != 0)
            return true;
        else
            return false;
    }

    bool Ground()
    {
        Vector3 origin = transform.position;
        origin.y += 0.6f;
        Vector3 dir = -Vector3.up;
        float dis = 0.7f;
        if (Physics.Raycast(origin, dir, out RaycastHit hit, dis))
        {
            Vector3 tp = hit.point;
            transform.position = tp;
            return true;
        }
        return false;

    }

    bool Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterStatus.isGround && !Crouch())
        {
            if (characterStatus.isSprint)
            {
                anim.SetBool("Jump", true);
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForceRun, ForceMode.Impulse);
                return true;
            }
            anim.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForceWalk, ForceMode.Impulse);
            return true;
        }
        else
        {
            anim.SetBool("Jump", false);
            return false;
        }

    }

    bool Crouch()
    {
        Vector3 origin = transform.position;
        origin.y += 0.6f;
        Vector3 dir = Vector3.up;
        float dis = 1f;
        if (Physics.Raycast(origin, dir, dis))
        {
            anim.SetBool("Crouch", true);
            collider.center = new Vector3(0f, 0.6f, 0f);
            collider.height = 1.24f;
            return true;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && characterStatus.isGround)
        {
            anim.SetBool("Crouch", true);
            collider.center = new Vector3(0f, 0.6f, 0f);
            collider.height = 1.24f;
            return true;
        }
        else
        {
            anim.SetBool("Crouch", false);
            collider.height = 1.8f;
            collider.center = new Vector3(0f, 0.9f, 0f);
            camCon.maxAngle = 60;
            return false;
        }
    }

    bool Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Crouch() && characterStatus.isGround && !characterStatus.isSprint)
        {
            anim.SetTrigger("Attack");
            return true;
        }
        return false;
    }

    IEnumerator Casting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && characterStatus.isGround && !Crouch() && walkSpeed != 0 && !characterStatus.isSprint && mana >= 0.4f)
        {
            anim.SetTrigger("Cast");
            mana -= 0.4f;
            yield return new WaitForSecondsRealtime(0.5f);
            Instantiate(fireball, fireballIn.transform.position, fireballIn.transform.rotation);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FireMinusHP"))
            HP -= Time.deltaTime / 10f;
            

        if (other.CompareTag("HPFlask") && Input.GetKey(KeyCode.E) && HPflask < 4f)
        {
            HPflask += 1;
            list[HPflask].SetActive(true);
            list[HPflask - 1].SetActive(false);
            anim.SetTrigger("Picking");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnSword"))
        {
            anim.SetTrigger("Impact");
            HP -= 0.35f;
        }

        if (other.CompareTag("Cast"))
        {
            anim.SetTrigger("Impact");
            HP -= 0.5f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FallDead"))
        {
            HP = 0f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("stone"))
        {
            anim.SetTrigger("Impact");
            HP -= 0.25f;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("minusHP"))
            HP -= Time.deltaTime / 10f;
        if (collision.gameObject.CompareTag("LatticeMinusHP"))
            HP -= Time.deltaTime / 30f;
    }




    public void MoveStop()
    {
        swordLine.SetActive(false);
        jumpForceWalk = 0f;
        jumpForceRun = 0f;
        runSpeed = 0f;
        walkSpeed = 0f;
    }
    public void MoveContinue()
    {
        jumpForceWalk = 450f;
        jumpForceRun = 550f;
        runSpeed = 6f;
        walkSpeed = 3f;
    }

    void Healing() => flaskdrink.SetActive(true);
    void EndHealing() => flaskdrink.SetActive(false);

    void Attacking() => swordLine.SetActive(true);
    void AfterAttack() => swordLine.SetActive(false);




}
