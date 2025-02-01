using Godot;

public partial class Player : CharacterBody2D
{
	public const float BASE_MOVE_SPEED = 150.0f;
	public float move_speed = BASE_MOVE_SPEED;
	public float run_speed = 250.0f;
	public bool accept_input = true;

	[Signal]
	public delegate void debug_velocityEventHandler(Vector2 vector);

	[Signal]
	public delegate void debug_directionEventHandler(string direction);

	private RayCast2D EntityDetector;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EntityDetector = GetNode<RayCast2D>("EntityDetector");
		if(OS.IsDebugBuild()){
			EntityDetector.GetNode<Line2D>("EntityDetectorVisualization").Visible = true;
		}
		// health = 99
		// max_health = 101
		// max_stamina = 102

		// emit_signal("set_health", health)
		// emit_signal("set_max_health", max_health)
		// emit_signal("set_stamina", stamina)
		// emit_signal("set_max_stamina", max_stamina)

		// Set an arbitrary south direction for the debug ui
		EmitSignal(SignalName.debug_direction, 1.5);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (accept_input)
		{
			GetInput();
			MoveAndSlide();
		}
	}

	public void GetInput()
	{
		// Get input direction
		Vector2 input_direction = new Vector2(
			Input.GetAxis("move_left", "move_right"),
			Input.GetAxis("move_up", "move_down")
		);

		// Normalize input direction to prevent faster diagonal movement
		if (input_direction != Vector2.Zero)
		{
			input_direction = input_direction.Normalized();
		}

		// Speed up the movement for run, slow it down for walk
		if (Input.IsActionPressed("run"))
		{
			move_speed = run_speed;
		}
		else
		{
			move_speed = BASE_MOVE_SPEED;
		}

		// Set velocity based on input direction
		Velocity = input_direction * (float)move_speed;
		EmitSignal(SignalName.debug_velocity, Velocity);
		SetPlayerLookDirection(Velocity);
	}

	public void SetPlayerLookDirection(Vector2 vector)
	{
		if (vector != Vector2.Zero)
		{
			float angle = vector.Angle();
			EmitSignal(SignalName.debug_direction, angle);
			// Set the raycast rotation to whatever direction it is
			EntityDetector.Rotation = angle;
		}
	}
}
