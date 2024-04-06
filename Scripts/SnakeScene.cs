using Godot;
using System;
using System.Numerics;

public partial class SnakeScene : Node2D
{

	
	private Snake head;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		head = this.GetNode<Snake>("SnakeHead");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
