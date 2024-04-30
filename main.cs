using Godot;
using System;

public partial class main : Node2D
{
	private void _on_button_2_pressed()
	{
		GetTree().Quit();
	}
	
	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://world.tscn");
	}
}

