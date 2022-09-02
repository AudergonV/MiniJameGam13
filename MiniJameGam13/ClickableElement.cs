using Godot;
using System;

public class ClickableElement : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    public delegate void OnClick();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    
    public void _on_Area2D_input_event(Node node, InputEvent @event, int i) {
        if (@event.IsActionPressed("click")) {
            GD.Print(i);
            EmitSignal("OnClick");
        }
    }

}