using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {	
	public enum Mood
	{
		Angry, Sad, Happy, Neutral
	}
	
	public string name;
	public Mood mood;
	public float[] needs;
	
	// Use this for initialization
	void Start () {
		name = Namegenerator.GenerateName();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	private Vector2 Pos { get {return transform.position;} }
}