extends Area2D

var speed = 275
var initial_position = Vector2()

func _ready():
	initial_position = position
	position.y = randf_range(0, 500) 

func _process(delta):
	position.x -= speed * delta
	
	if position.x < -get_viewport_rect().size.x / 2:
		position = initial_position

func _on_body_entered(body):
	if body.name == "submarine": 
		get_tree().change_scene_to_file("res://Scenes/gameover.tscn")
