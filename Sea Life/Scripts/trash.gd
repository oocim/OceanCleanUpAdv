extends Area2D

var speed = 350
var initial_position = Vector2()
var score = 0

func _ready():
	initial_position = position

func _process(delta):
	position.x -= speed * delta

	if position.x < -get_viewport_rect().size.x / 2:
		position = initial_position

func _on_body_entered(body):
	if body.name == "submarine":
		position.y = randi() % 500
		position.x = initial_position.x
