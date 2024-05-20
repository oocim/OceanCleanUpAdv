using Godot;
using System;

public partial class submarine : RigidBody2D
{
	private const float UP_IMPULSE = -350.0f;

	public override void _Ready()
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
		{
			if (eventKey.IsActionPressed("ui_select"))
			{
				SubmarineJump();
			}
		}
	}

	private void SubmarineJump()
	{
		LinearVelocity = new Vector2(0, 0);
		ApplyCentralImpulse(new Vector2(0, UP_IMPULSE));

		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("default");
	}
}
