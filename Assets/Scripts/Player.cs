using UnityEngine;

public class Player : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	
	public Sprite[] sprites; 

	public int spriteIndex;

	private Vector3 direction;
	
	public float gravity=-10f;
	
	public float strength = 5f;
	
	//tìm kiếm SpriteRenderer trong bảng Inspcetor
	private void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		
	}

	//Gọi gần như trong frame đầu tiên của animation mà object được kích hoạt  
	private void Start(){
		//lặp lại liên tục function
		InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
	}
	
	private void OnEnable()
	{
		Vector3 position = transform.position;
		position.y=0f;
		transform.position=position;
		direction=Vector3.zero;
	}
	private void Update(){
		if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)){
			direction = Vector3.up * strength;
		}

		direction.y += gravity * Time.deltaTime;
		transform.position += direction * Time.deltaTime;
	}
	
	private void AnimateSprite(){
		spriteIndex++;

		if(spriteIndex>=sprites.Length){
			spriteIndex=0;
		}
		if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Obstacle"){
			FindObjectOfType<GameManager>().GameOver();
		}else if(other.gameObject.tag=="Scoring"){
			FindObjectOfType<GameManager>().IncreaseScore();
		}

	}
		
}
