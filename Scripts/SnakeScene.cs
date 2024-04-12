using Godot;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class SnakeScene : Node2D
{


	Snake head;

	Stack<Godot.Vector2> directions = new Stack<Godot.Vector2>();
	
	List<int> inputs = new List<int>();

	List<int> bodyturn = new List<int>();
	uint BodyCount = 7;

	/*0 = up
	1 = down
	2 = left
	3 = right*/
	public int s_direction;


	public const float Speed = 60.0f;




	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		//head init
		head = GetNode<Snake>("SnakeHead");
		s_direction = 1;
		inputs.Add(1);
		directions.Push(new Godot.Vector2(0,0));

		//bodyturn = Array.Fill(bodyturn, 2, 0, 5);
		
		for(int i = 0; i < BodyCount; i++)
		{
			bodyturn.Add(5);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//head.MoveAndSlide();

		//call head movement
		HeadMovement();

		//iterate through body instances, do body movement (while passing in their turn)



		//(body 0 does turn 0, body 1 does turn 1 etc)
	}

	


	//head movement
	public void HeadMovement()
	{
			//create current velocity
		Godot.Vector2 velocity = head.Velocity;

		//get the currently held direction
		Godot.Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		//adds this frames input to a list
		inputs.Add(Snake.change_dir(direction, inputs.Last()));


		//use end of queue as change_dir direction and wipe queue
		if ((int)head.Position.Y % 64 == 0 || (int)head.Position.Y % 64 == 0)
		{
			s_direction = inputs.Last();
			inputs.Clear();
			inputs.Add(s_direction);
		}

		//movement calculated
		velocity = Move(s_direction, Speed);
		head.Velocity = velocity;
		head.MoveAndSlide();

	}

	//body movement

		public static Godot.Vector2 Move(int dir, float speed)

	
	{
		Godot.Vector2 vel = new Godot.Vector2(0, 0);

		switch(dir){
		case 0:
			vel.Y = -speed;
			vel.X = 0;
			break;

		case 1:
			vel.Y = speed;
			vel.X = 0;
			break;
		case 2:
			vel.X = -speed;
			vel.Y = 0;
			break;
		case 3:
			vel.X = speed;
			vel.Y = 0;
			break;

		}
		return vel;
	}
}
