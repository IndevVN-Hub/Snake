using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class Snake : CharacterBody2D
{
	
	


	/*0 = up
	1 = down
	2 = left
	3 = right*/
	public int s_direction;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Ready() {
	}
	public override void _PhysicsProcess(double delta)
	{
	
	}


// player movement logic
	public static int change_dir(Vector2 dir, int s_dir)
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


	//power up logic - just a variable to check current power up and apply effects?

	//boost logic - tier 2 - needs nothing, can be done rn

	//grow logic - tier 1 - collectable (maybe put in snake script)

	//spawn/delete body part - tier 1 (maybe put in snake script) - needs info (how to spawn nodes) and body part graphic

	//shoot logic - tier 4 - gun, bullets (just gonna be spawning the bullet entity and giving it a direction)
}


