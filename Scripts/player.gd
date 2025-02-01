extends Entity

const BASE_MOVE_SPEED: float = 150.0
@export var move_speed: float = BASE_MOVE_SPEED
@export var run_speed: float = 250.0
@export var accept_input:bool = true

signal debug_velocity(velocity: Vector2)
signal debug_direction(direction)

signal set_max_health(value: int)
signal set_health(value: int)
signal set_max_stamina(value: int)
signal set_stamina(value: int)

# Called when the node enters the scene
func _ready() -> void:
	health = 99
	max_health = 101
	max_stamina = 102
	
	emit_signal("set_health", health)
	emit_signal("set_max_health", max_health)
	emit_signal("set_stamina", stamina)
	emit_signal("set_max_stamina", max_stamina)
	
	# Set an arbitrary south direction for the debug ui
	emit_signal("debug_direction", 1.5)

func _physics_process(_delta: float) -> void:
	if(accept_input):
		get_input()
		move_and_slide()

func get_input() -> void:
	# Get input direction
	var input_direction = Vector2(
		Input.get_axis("move_left", "move_right"),
		Input.get_axis("move_up", "move_down")
	)
	
	# Normalize input direction to prevent faster diagonal movement
	if input_direction != Vector2.ZERO:
		input_direction = input_direction.normalized()
	
	# Speed up the movement for run, slow it down for walk
	if Input.is_action_pressed("run"):
		move_speed = run_speed
	else:
		move_speed = BASE_MOVE_SPEED
	
	# Set velocity based on input direction
	velocity = input_direction * move_speed
	emit_signal("debug_velocity", velocity)
	set_player_look_direction((velocity))
	
func set_player_look_direction(vector: Vector2):
	if vector == Vector2.ZERO:
		return # No movement, don't update
	
	var angle = vector.angle()
	emit_signal("debug_direction", angle)
	# Set the raycast rotation to whatever direction it is
	$EntityDetector.rotation = angle
