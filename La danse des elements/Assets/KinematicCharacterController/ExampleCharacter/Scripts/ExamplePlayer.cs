using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace KinematicCharacterController.Examples
{
    public class ExamplePlayer : MonoBehaviour, IDataPersistence
    {
        public GameObject exampleCharacter;
        public int playerMaxHealth = 100;
        // public int fireHealth;
        //public int waterHealth;
        //public int windHealth;
        // public int earthHealth;
        public int playerCurrentHealth;

        public HealthBar playerHealthBar;
        public ExampleCharacterController Character;
        public ExampleCharacterCamera CharacterCamera;
        public Slider playerHealthSlider;
        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        public Transform bodyToTP;
        public GameObject Fire;
        public GameObject Water;
        public GameObject Wind;
        public GameObject Earth;
        public GameObject fireUI;
        public GameObject earthUi;
        public GameObject windUi;
        public GameObject waterUI;
        public int currentElement = 1;

        private void Start()
        {
            playerCurrentHealth = playerMaxHealth;
            playerHealthBar.SetMaxHealth(playerMaxHealth);
            Cursor.lockState = CursorLockMode.Locked;
            UpdateQuestText("Atteignez le haut de la Grotte");

            // Tell camera to follow transform
            CharacterCamera.SetFollowTransform(Character.CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            CharacterCamera.IgnoredColliders.Clear();
            CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
                // Détecte la touche d'interaction ici
                if (playerCurrentHealth < 0) { playerCurrentHealth = 0; }
                //Pour que la vie n'aille pas au dessus de 100
                if (playerCurrentHealth > playerMaxHealth) { playerCurrentHealth = 100; }

                //Tue le joueur si sa vie atteint 0
                if (playerCurrentHealth == 0) { Death(); }
                playerHealthSlider.gameObject.GetComponent<Slider>().value = playerCurrentHealth;

                if (currentEnergyEarth > 3)
                {
                    currentEnergyEarth = 3;
                }
                if (currentEnergyFire > 3)
                {
                    currentEnergyFire = 3;
                }
                if (currentEnergyWater > 3)
                {
                    currentEnergyWater = 3;
                }
                if (currentEnergyWind > 3)
                {
                    currentEnergyWind = 3;
                }
                if (fireIsOn == true)
                {
                    currentElement = 1;
                    currentEnergy = currentEnergyFire;
                    //fireHealth = playerCurrentHealth;
                }
                if (waterIsOn == true)
                {
                    currentElement = 4;
                    currentEnergy = currentEnergyWater;
                    //waterHealth = playerCurrentHealth;
                }
                if (windIsOn == true)
                {
                    currentElement = 3;
                    currentEnergy = currentEnergyWind;
                    //windHealth = playerCurrentHealth;
                }
                if (earthIsOn == true)
                {
                    currentElement = 2;
                    currentEnergy = currentEnergyEarth;
                   // earthHealth = playerCurrentHealth;
                }

                switch (currentElement)
                {
                    case 1:
                        energyBar.gameObject.GetComponent<Slider>().value = currentEnergyFire;
                        backgroundBar.GetComponent<Image>().color = new Color((float).77, 0, 0, 1);
                        playerHealthBar.fill.GetComponent<Image>().color = new Color((float).77, 0, 0, 1);
                        fireUI.SetActive(true);
                        waterUI.SetActive(false);
                        break;

                    case 2:
                        energyBar.gameObject.GetComponent<Slider>().value = currentEnergyEarth;
                        backgroundBar.GetComponent<Image>().color = new Color((float).17, (float).45, (float).14, 1);
                        playerHealthBar.fill.GetComponent<Image>().color = new Color((float).17, (float).45, (float).14, 1);
                        fireUI.SetActive(false);
                        earthUi.SetActive(true);
                    break;
                    case 3:
                        energyBar.gameObject.GetComponent<Slider>().value = currentEnergyWind;
                        backgroundBar.GetComponent<Image>().color = Color.white;
                        playerHealthBar.fill.GetComponent<Image>().color = Color.white;
                    windUi.SetActive(true);
                    earthUi.SetActive(false);
                    break;
                    case 4:
                        energyBar.gameObject.GetComponent<Slider>().value = currentEnergyWater;
                        backgroundBar.GetComponent<Image>().color = new Color((float).18, (float).66, 1, 1);
                        playerHealthBar.fill.GetComponent<Image>().color = new Color((float).18, (float).66, 1, 1);
                    windUi.SetActive(false);
                    waterUI.SetActive(true);
                    break;

                    default: break;
                }
            
                if (!isAvailable)
                {
                    swapeIcon.color = Color.gray;
                float timeSinceLastUsage = Time.time - lastUsageTime;

                    // If the elapsed time is greater than or equal to cooldown time, the ability is ready
                    if (timeSinceLastUsage >= cooldownTime)
                    {
                        isAvailable = true;
                    }
                }
                if (isAvailable)
            {
                swapeIcon.color = Color.white;
            }
                if (Input.GetMouseButtonDown(0) && !PauseMenu.gameIsPaused)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SwapElement();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    PerformSpecialSkill();
                }
                HandleCharacterInput();
            }

        public void LoadData(GameData data)
        {
            this.playerMaxHealth = data.playerMaxHealth;
            this.playerCurrentHealth = data.playerCurrentHealth;
        }

        public void SaveData(ref GameData data)
        {
            data.playerMaxHealth = this.playerMaxHealth;
            data.playerCurrentHealth = this.playerCurrentHealth;
        }
        
        public void Death()
        {
            exampleCharacter.SetActive(false);
            SceneManager.LoadScene("MainGameplay");
        }

        private void LateUpdate()
        {
            // Handle rotating the camera along with physics movers
            if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
            {
                CharacterCamera.PlanarDirection = Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * CharacterCamera.PlanarDirection;
                CharacterCamera.PlanarDirection = Vector3.ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
            }

            HandleCameraInput();
        }
        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                lookInputVector = Vector3.zero;
            }

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            float scrollInput = -Input.GetAxis(MouseScrollInput);
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            CharacterCamera.UpdateWithInput(Time.deltaTime, 0f, lookInputVector);

            // Handle toggling zoom level
           /* if (Input.GetMouseButtonDown(1))
            {
                CharacterCamera.TargetDistance = (CharacterCamera.TargetDistance == 0f) ? CharacterCamera.DefaultDistance : 0f;
            }*/
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = CharacterCamera.Transform.rotation;
            characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
            //characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.C);
            //characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.C);

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }
        public LayerMask lavaLayer;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ennemy"))
            {
                PlayerTakeDamage(5);
            }
            if (other.CompareTag("Lava"))
            {
                Death();

            }

        }
        
        public void PlayerTakeDamage(int damage)
        {
            playerCurrentHealth -= damage;

            
        }
        


        public bool fireIsOn = true;
        public bool waterIsOn = false;
        public bool windIsOn = false;
        public bool earthIsOn = false;

        public float cooldownTime = 2f; // Cooldown time in seconds
        private bool isAvailable = true;
        private float lastUsageTime;
        public GameObject petsFire;
        public GameObject petsWater;
        public GameObject petsWind;
        public GameObject petsEarth;
        public bool hasFragmentKey =false;
        public TextMeshProUGUI questText;
        public void UpdateQuestText(string text)
        {
            questText.text = text;
        }
        public void SwapElement()
        {
            if (isAvailable)
            {
                
                if (fireIsOn == true)
                {
                    Fire.gameObject.SetActive(false);
                    Earth.gameObject.SetActive(true);
                    earthIsOn = true;
                    fireIsOn = false;
                    petsEarth.gameObject.SetActive(true);
                    petsFire.gameObject.SetActive(false);
                    fireIcon.SetActive(false);
                    earthIcon.SetActive(true);
                    // playerCurrentHealth = earthHealth ;


                }
                else if (waterIsOn == true)
                {
                    Water.gameObject.SetActive(false);
                    waterIsOn = false;
                    Fire.gameObject.SetActive(true);
                    fireIsOn = true;
                    petsWater.gameObject.SetActive(false);
                    petsFire.gameObject.SetActive (true);
                    fireIcon.SetActive(true);
                    waterIcon.SetActive(false);
                    //  playerCurrentHealth = fireHealth;   
                }
                else if (earthIsOn == true)
                {
                    Earth.gameObject.SetActive(false);
                    earthIsOn = false;
                    Wind.gameObject.SetActive(true);
                    windIsOn = true;
                    petsEarth.gameObject.SetActive(false);
                    petsWind.gameObject.SetActive(true);
                    windIcon.SetActive(true);
                    earthIcon.SetActive(false);
                    //  playerCurrentHealth = windHealth;

                }
                else if (windIsOn == true)
                {
                    Wind.gameObject.SetActive(false);
                    windIsOn = false;
                    Water.gameObject.SetActive(true);
                    waterIsOn = true;
                    petsWind.gameObject.SetActive(false);
                    petsWater.gameObject.SetActive(true) ;
                    waterIcon.SetActive(true);
                    windIcon.SetActive(false);
                    // playerCurrentHealth = waterHealth;

                }
                lastUsageTime = Time.time;

                // Disable the ability during cooldown
                isAvailable = false;
            }
            else
            {
                
                // The ability is not available, you can add a sound or visual effect to indicate this to the player
                Debug.Log("Ability on cooldown...");
            }


        }
        public Image swapeIcon;
        [SerializeField] GameObject fireIcon;
        [SerializeField] GameObject earthIcon;
        [SerializeField] GameObject windIcon;
        [SerializeField] GameObject waterIcon;
        

        public GameObject energyBar;
        public GameObject backgroundBar;
        public float currentEnergyWater = 3;
        public float currentEnergyFire = 3;
        public float currentEnergyEarth = 3;
        public float currentEnergyWind = 3;
        public float currentEnergy;
        public FireBallSkill fireballSkill;
        public StoneBridgeSkill stoneBridgeSkill;
        public PropulsionSkill propulsionSkill;

        

        public float interactionDistance = 3f;

        public UnityAction<ExampleCharacterController> OnCharacterTeleport;
        public bool isBeingTeleportedTo { get; set; }

        public bool tpAuthorized = false;
        public void PerformSpecialSkill()
        {
            if (currentEnergy > 0)
            {
                energyBar.gameObject.GetComponent<Slider>().value = currentEnergy - 1;
                // Sélectionner l'attaque appropriée en fonction de l'élément actuel du joueur
                switch (currentElement)
                {
                    case 1:
                        currentEnergyFire = energyBar.GetComponent<Slider>().value;
                        fireballSkill.UseFireball();
                        break;
                    case 2:
                        currentEnergyEarth = energyBar.GetComponent<Slider>().value;
                        stoneBridgeSkill.CreateStoneBridge();
                        break;
                    case 3:
                        currentEnergyWind = energyBar.GetComponent<Slider>().value;
                        propulsionSkill.PropelInAir();
                        break;
                    case 4:
                        currentEnergyWater = energyBar.GetComponent<Slider>().value;
                        tpAuthorized = true;
                        break;
                    default:
                        break;

                        // Ajoutez d'autres cas pour les autres types d'attaque
                }
            }
        }
        [SerializeField] Image endFade;
        public void Endgame()
        {
            StartCoroutine(FadeImageToBlack(5.0f));

        }
        private IEnumerator FadeImageToBlack(float fadeDuration)
        {
            Color originalColor = endFade.color;
            Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1.0f); // Alpha à 1 (complètement opaque)

            float timer = 0.0f;
            while (timer < fadeDuration)
            {
                float progress = timer / fadeDuration;
                endFade.color = Color.Lerp(originalColor, targetColor, progress);
                timer += Time.deltaTime;
                yield return null;
            }

            endFade.color = targetColor; // Assure que l'alpha atteint bien 1 à la fin

            SceneManager.LoadScene("MainMenu");
        }
    }
}