using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class Snake : CharacterBody2D
{
	
	CharacterBody2D snakehead;

	public const float Speed = 60.0f;
	public const float JumpVelocity = -400.0f;

	//int[] inputs;

	List<int> inputs = new List<int>();

	/*0 = up
	1 = down
	2 = left
	3 = right*/
	public int s_direction;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Ready() {
		s_direction = 1;
		//snakehead = GetNode<Snake>("../SnakeHead");
		snakehead = this;

		inputs.Add(1);

		
		
	}
	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		//add to queue using change_dir(direction, s_direction)

		inputs.Add(change_dir(direction, inputs.Last()));

		//use end of queue as change_dir direction and wipe queue
		if (snakehead.Position.Y % 64 == 0 || snakehead.Position.Y % 64 == 0)
		{
			//s_direction = change_dir(direction, s_direction);
			s_direction = inputs.Last();
			GD.Print(inputs.Last());
			inputs.Clear();
			inputs.Add(s_direction);
		}

		velocity = Move(s_direction, Speed);

		//Vector2 vel = change_dir(direction);

		Velocity = velocity;

		MoveAndSlide();

	}


// player movement logic
	public int change_dir(Vector2 dir, int s_dir)
	{
		if (dir.Y == -1)
		{
			return 0;
		};

		if (dir.Y == 1)
		{
			return 1;
		};

		if (dir.X == -1)
		{
			return 2;
		};

		if (dir.X == 1)
		{
			return 3;
		};
		return s_dir;
	}

	public static Vector2 Move(int dir, float speed)

	
	{
		Vector2 vel = new Vector2(0, 0);

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

	//power up logic - just a variable to check current power up and apply effects?

	//boost logic - tier 2 - needs nothing, can be done rn

	//grow logic - tier 1 - collectable (maybe put in snake script)

	//spawn/delete body part - tier 1 (maybe put in snake script) - needs info (how to spawn nodes) and body part graphic

	//shoot logic - tier 4 - gun, bullets (just gonna be spawning the bullet entity and giving it a direction)
}


