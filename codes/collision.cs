private void Start(){
// This would make sure that score is 0 from the first frame
scoreText.GetComponent<Text>().text = " " + 0;
 }


void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player"){
        ScoringSystem.theScore += 1;

      // Destroy(collision.gameObject);
      }

