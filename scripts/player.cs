using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export]
	public float Speed = 200.0f;
	public string current_dir = "none";

	public void play_animation(int movement) {
		var dir = current_dir;

	}

	public void GetInput()
	{
		Vector2 InputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = InputDirection * Speed;

		if (InputDirection == Vector2.Left) {
			current_dir = "left";
			play_animation(0);
		}
		if (InputDirection == Vector2.Right) {
			current_dir = "right";
			play_animation(1);
		}
		if (InputDirection == Vector2.Up) {
			current_dir = "up";
			play_animation(2);
		}
		if (InputDirection == Vector2.Down) {
			current_dir = "down";
			play_animation(3);
		}
	}

		public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
