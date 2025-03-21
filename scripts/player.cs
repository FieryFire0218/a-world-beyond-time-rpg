using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export]
	public float Speed = 200.0f;
	public string current_dir = "none";

	public override void _Ready() {
		CallDeferred("startAnimation");
	}

	private void startAnimation() {
		var anim = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		anim.Play("front_idle");
	}

	//animation
	public void play_animation(int movement) {
		var dir = current_dir;
		var anim = (AnimatedSprite2D)GetNode("AnimatedSprite2D");

		if (dir == "right") {
			anim.FlipH = false;
			if (movement == 1) {
				anim.Play("side_walk");
			}
			else if (movement == 0) {
				anim.Play("side_idle");
			}
		}

		if (dir == "left") {
			anim.FlipH = true;
			if (movement == 1) {
				anim.Play("side_walk");
			}
			else if (movement == 0) {
				anim.Play("side_idle");
			}
		}

		if (dir == "up") {
			anim.FlipH = false;
			if (movement == 1) {
				anim.Play("back_walk");
			}
			else if (movement == 0) {
				anim.Play("back_idle");
			}
		}

		if (dir == "down") {
			anim.FlipH = false;
			if (movement == 1) {
				anim.Play("front_walk");
			}
			else if (movement == 0) {
				anim.Play("front_idle");
			}
		}
	}

	//input
	public void GetInput() {
		Vector2 InputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = InputDirection * Speed;

		if (InputDirection != Vector2.Zero) {
			if (Math.Abs(InputDirection.X) > Math.Abs(InputDirection.Y)) {
				current_dir = InputDirection.X > 0 ? "right" : "left";
			} else {
				current_dir = InputDirection.Y > 0 ? "down" : "up";
			}
			play_animation(1); // Walk animation
		}
		
		else {
			play_animation(0); // Idle animation
		}
	}

		public override void _PhysicsProcess(double delta) {
		GetInput();
		MoveAndSlide();
	}
}
