extends Control

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	pass

func _on_player_debug_velocity(velocity: Variant) -> void:
	$velocityDebug.text = "Velocity: " + str(velocity)

func _on_player_debug_direction(angle: Variant) -> void:
	var selected_direction: String
	if -PI / 8 <= angle and angle < PI / 8:
		selected_direction = "E"
	elif angle >= PI / 8 and angle < 3 * PI / 8:
		selected_direction = "SE"
	elif angle >= 3 * PI / 8 and angle < 5 * PI / 8:
		selected_direction = "S"
	elif angle >= 5 * PI / 8 and angle < 7 * PI / 8:
		selected_direction = "SW"
	elif angle >= 7 * PI / 8 or angle < -7 * PI / 8:
		selected_direction = "W"
	elif angle >= -7 * PI / 8 and angle < -5 * PI / 8:
		selected_direction = "NW"
	elif angle >= -5 * PI / 8 and angle < -3 * PI / 8:
		selected_direction = "N"
	elif angle >= -3 * PI / 8 and angle < -PI / 8:
		selected_direction = "NE"

	$directionDebug.text = "Facing: " + selected_direction
