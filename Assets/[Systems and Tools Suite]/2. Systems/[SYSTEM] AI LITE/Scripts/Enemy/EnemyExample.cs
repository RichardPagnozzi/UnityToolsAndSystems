using UnityEngine;
using UnityEngine.AI;

public class EnemyExample : EnemyBase
{
    #region Variables
    private NavMeshAgent agent;
    private GameObject Player;
    private Animator animController;
    private bool TargetingPlayer = false;
    private bool Wandering = false;
    private bool Attacking = false;
    private bool StateKilled = false;
    [SerializeField]
    private bool SpawnedIn = false;
    // AUDIO VARIABLES
    private AudioSource SFX;
    public AudioClip searchSFX;
    public AudioClip foundSFX;
    public AudioClip attackSFX;
    public AudioClip deathSFX;
    #endregion

    #region Monobehaviours
    void Awake()
    {
        // Initialize Variables
        InitializeEnemy();
        // Set Enemy Initial state to WANDER
        this.m_StateMachine.ChangeState(new State_Wander(this.gameObject, EnemyTargeting.m_wanderInterval, EnemyTargeting.m_wanderRadius, EnemyTargeting.m_chaseSpeed));
    }

    public void Update()
    {
        if (SpawnedIn)
        {
            // First we run the WANDER State
            this.m_StateMachine.RunCurrentState();

            // Then we proceed with our state machine logic

            if (!StateKilled)
            {
                if (ETargetingUtils.AI_Target(EnemyTargeting.Eyes, this.gameObject, EnemyTargeting.m_pursuitRange) && !TargetingPlayer)
                {
                    SFX?.PlayOneShot(foundSFX, 1.0f);
                    this.m_StateMachine.ChangeState(new State_Chase(this.gameObject));
                    TargetingPlayer = true;
                    Attacking = false;
                }
                TargetingLogic();
            }




            if (EnemyHealth.m_Alive == false && StateKilled == false)
            {
                SFX?.PlayOneShot(deathSFX, 1.0f);
                this.m_StateMachine.ChangeState(new State_Ragdoll(this.gameObject));
                StateKilled = true;
            }
            if (StateKilled)
            {
                DropXP(XP_Worth);
                Destroy(this.gameObject, 5f);
            }
        }
    }
    #endregion

    #region Methods
    private void InitializeEnemy()
    {
            //SFX = GetComponent<AudioSource>();

            agent = GetComponent<NavMeshAgent>();

            animController = GetComponent<Animator>();

            m_StateMachine = new StateMachine();

            EnemyDamage.m_baseDamage = 15;

            Player = GameObject.FindGameObjectWithTag("Player");

            EnemyTargeting.m_attackRange = 2.6f;
            EnemyTargeting.m_pursuitRange = 30;
            EnemyTargeting.m_chaseRange = 30f;
            EnemyTargeting.m_chaseSpeed = Random.Range(6, 8);
            EnemyTargeting.m_wanderRadius = 4f;
            EnemyTargeting.m_wanderInterval = Random.Range(2f, 4f);
            EnemyTargeting.Player = Player;

            agent.speed = EnemyTargeting.m_chaseSpeed;

            EnemyHealth.m_maxHealth = 100;
            EnemyHealth.m_currentHealth = 100;
            EnemyHealth.m_Alive = true;

            XP_Worth = 25;
    }

    private void TargetingLogic()
    {
        // Perfrom our 3 distance checks here
        // If We're in Attack Range - Attack
        if (Vector3.Distance(transform.position, Player.transform.position) <= EnemyTargeting.m_attackRange && !Attacking)
        {
            Attacking = true;
            this.m_StateMachine.ChangeState(new State_Attack(this.gameObject));
        }

        // If we're out of Attack Range but still in pursuit range -> Chase
        if (Vector3.Distance(transform.position, Player.transform.position) > EnemyTargeting.m_attackRange && Vector3.Distance(transform.position, Player.transform.position) < EnemyTargeting.m_pursuitRange)
        {
            Attacking = false;
            this.m_StateMachine.ChangeState(new State_Chase(this.gameObject));
        }
        // If we're out of Attack Range and out of Pursuit Range -> Wander
        else if (Vector3.Distance(transform.position, Player.transform.position) > EnemyTargeting.m_attackRange && Vector3.Distance(transform.position, Player.transform.position) > EnemyTargeting.m_pursuitRange)
        {
            Attacking = false;
            if (TargetingPlayer)
                this.m_StateMachine.ChangeState(new State_Wander(this.gameObject, EnemyTargeting.m_wanderInterval, EnemyTargeting.m_wanderRadius, EnemyTargeting.m_chaseSpeed));
            TargetingPlayer = false;
        }
    }

    public void ToggleSpawnedIn()
    {
        SpawnedIn = true;
    }
    #endregion 

}
