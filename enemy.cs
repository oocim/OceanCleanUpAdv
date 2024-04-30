using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private Node2D player;
	private bool chase = false;
	public const float SPEED = 150.0f;

	public override void _Ready()
	{
		player = GetNode<Node2D>("../../Player/Player");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		if (chase)
		{
			Vector2 direction = (player.GlobalPosition - this.GlobalPosition).Normalized();
			GD.Print(player.GlobalPosition.X);
			GD.Print(this.GlobalPosition.X);
			if (direction.X > 0)
			{
				SetSpriteFlipH(false);
				GD.Print("Right");
			}
			else
			{
				SetSpriteFlipH(true);
				GD.Print("Left");
			}

			velocity.X = direction.X * SPEED;
		}
		else
		{
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void SetSpriteFlipH(bool flip)
	{
		AnimatedSprite2D sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite.FlipH = flip;
	}

	private void _on_area_2d_body_entered(Node body)
	{
		if (body.Name == "Player")
		{
			chase = true;
		}
	}

	private void _on_area_2d_body_exited(Node body)
	{
		if (body.Name == "Player")
		{
			chase = false;
		}
	}
}
