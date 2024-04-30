using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 225.0f;
	public const float JumpVelocity = -275.0f;

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
			velocity.Y = JumpVelocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;

			// Flip sprite based on horizontal movement
			if (direction.X > 0)
				GetNode<Sprite2D>("Submarine7105760").FlipH = true;
			else if (direction.X < 0)
				GetNode<Sprite2D>("Submarine7105760").FlipH = false;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
