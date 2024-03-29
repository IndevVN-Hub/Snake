using Godot;
using System;

public partial class Snake : Node2D
{
	float spd;
	float dir;
	int len;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// check for direction pressed
		turn();
		
		//contact check
		contact();
		
		// move
		move();
	}
	
	public void move() {
		
	}
	
	public void contact() {
		
	}
	
	public void death() {
	
	}
	
	public void turn() {
		
	}
}
