# cis568Invaders

Space Invaders
================

This project is to recreate a space Invaders game in Unity as originally concieved in the Atari Space Invaders game as created in the 1980s.

Game Design
------------
The objective of Space invaders is to destroy an army of space invaders as they approach The invaders move in a grid where the bottom most fighter fires. They move in a snake pattern and at the end of a row, the aliens advance.  The idea is to shoot all the invaders before any of them kill the player. The objective is to eliminate all aliens, and thereby accumulate points. The aliens further from the ground are worth more points. There are special ships that move faster and are higher that are worth more points.   A loss is when there are remaining aliens.   

The challenges and conflicts  are related to the game play. One needs to shoot all the aliens before the aliens shoot you back. That involves shooting but at the same time avoiding alien bullets.  As the aliens get closer, the task gets more challenging.  Another conflict is that there is a fixed lag between shots.  One cannot shoot continuously.  One has to aim and anticipate when the bullet actually will strike. 

There are boundaries and constraints. The bullets are only relevant while on the screen.  There are baracades that prevent alien bullets from reaching you. In order to reach any alien, one must be between the boundaries.

To help play, one has three lives, or three times to get hit before the game is over.  One also has the baracades, which can protect the player, but those baracades get chipped away at with each invader bullet. Another limit is the rate of firing.  One needs to reload, so one has to pict the firing time.

The rules are that one can only move from side to side and can shoot whenever one wants but only after a delay compared with the prior shot.  If a bullet strikes you, you die.  The aliens move as a snake, and fire at a higher rate as they approach.  Bullets chip away at the barriers.  To win, one needs to get a high score.  One is inherently competing with past players.


Scene Descriptions
------------------

1.  Start Screen contains the following.  Its purpose is to introduce the game and entice the players.
    
    Object List
     A.  A Title.  "Space Invaders"  that introduces the  game.
     B.  A brief description of the game play and the key mapping.  This will be
         a text box with a brief summary of the goals.	
     C.	 A list of the point values for each type of alien.
     D.  The high scores.
     E.  Game start Button.  This button once hit will launch the Game Play Scene.
     F.  Game Exit Button. This will end the game
    
    Player Input Specification
     A. Game Start Button.  Trigger the Game Play Scene
     B. Exit Button:     Trigger the end of the game.

   

2. Game Play Scene. This scene is the battle scene and its purpose is to allow 
the game play to go on. It has all the game objects and displays the current state of the game.  The top of the scene
	will have lives remaining and the Score.  
     Game Object List

     A,  The aliens.  Types of Aliens.  There will be two or more types of
     		aliens.  In the original games there are three types and a
		special ship that moves faster.
     B.  The baracades.  There are some four barriers that block bullets. Each
         time a bullet hits the barrier, it chips away at it. removing a piece
	 and making the barrier smaller. The barrier consists of say a grid of
	 say contiguous blocks, and if a bullet hits a block, it is destroyed. 
	 The baracades are objects that do not move and do not lauch bullets.
     
     C.  The player.  This is a player that is located an the baseline and can
     	 Move left or right.  There are three actions:  
	 	D or right arrow: move player to the right at a constant
			         Velocity.
		A or left arrow:  move player to the left at a constant
		velocity.
		Space bar or left Click:  Shoot a bullet.

     D.  Extra Player Tokens:  These are 0 to 2 player like objects at the top of the
         display.  When a player gets killed. These extra lives reduce by 1 and
	 a new player is placed at the baseline.
     
     E.  Bullets:  All types of aliens and the player can all launch bullets.
          Bullets move with Physics and upon a collision, they destroy the
	  object.  These will be spheres.

     F.  Game Play Manager.  This controls the update rate, and keeps track of
     	 the Score. Also keeps count of the number of aliens left.
     
     G.  Score Token.  This is a text object that displays the current score.
     H.  The main Camera.  This is used to render the game and display it to
     	 the screen.
     I.  The light source.  This casts shadows on all the objects in the scene
     	  so that they are rendered in 3D.

     E.  The Exit button to terminate the game early.

     F.  Loss Triggers.  When the player is destroyed and there are no extra
     	 lives. This is game over.
     G.  Win Trigger.  all aliens are destroyed and player is still alive.

   Player Input Specifications
     
     The right arrow/left arrow  or the (A/D keys will move the player to the 
     right or left. The space bar or the left click will trigger a bullet
     firing onto the aliens.

3. Win Screen
    Text across the window showing that the player won.

4. Loss Screen
     Text across the screen showing that the player lost.
    
  

Connectivity Graph
---------------------

 The Start and Game play scene are connected through the start button (on the
 scene graph) and the result of game play (win/loss) in the game play graph.
 The following diagram summarizes this:

 ![](Assets/ConnectivityGraph.png)

Object Descriptions
----------------------

  Assets
  1.  Player: 
       1 Geometry: Cube
       2 Texture :Arrow
       3 No sound
       4 No animation
       5 Lambert Standard
  
  2.  Aliens:
       1  Ovals
       2  Color: Yellow, purple Red
       3  No sound
       4  No animation
       5  Lambert Standard
  
  3.  Barrier
       
       1  array of adjacent cubes
       2  Color : Green
       3  No sound
       4  No animation
       5  Lambert Standard

  4.  Bullets
       
       1  Spheres
       2  Color: Yellow
       3  Sound: Brief pulse when emitted
       4  Shader: Lambertian

  Standard Components
  
  	Transforms:  All Assets have transforms that place the objects in the scene. No object has a rotation. 
    			The Player and the Aliens are reduced a little in side and the
			barrier is half as big.  The bullets are alse reduced so they
			look like bullets.

  	Rigid Bodies:  The Player, the Aliens, the bullets, the Barrier are rigid Bodies.

 	Colliders   :   Barrier and the Players all have a cube as their
               boundary.  The aliens have an oval and the bullets have a circle.
	
	StandardMethods:  Start (initialize and update (loop)).
  
  Custom Components:

        preFabs:  Aliens and players both have the ability to launch bullets.  To launch a bullet,
		 the object must instantiate the bullet and give it the correct
		 initial velocity, and the correct physics.  Gravity will not
		 be turned on for the bullets, but the bullets initial velocity
		 will be set by a constant.

       Player  : 
                 Data Members:
		       timeLastShot:  used to prevent too many bullets from
		       		being fired.
		 Methods:
		      FireShot.  launch a bullet and reset timeLastShot(). Also
		                 Abort if current time is too near
				 timeLastShot.

		      BlowUp     destroy oneself if hit with a collision.

		 Triggers: Fireshot:  left click or space bar.
		           BlowUp:   Bullet collides with object.
	
       Alien  :
       		 Data Members:
		 	bool:  FrontLine: True if this alien is on the front
					line. Aliens on the front line fire
					shots.

			       LeftMost:  true if this alien is the most left
			                so that in knows when to turn around.
			       RightMost:  true if this alien is the most
			       BackRow  :  Most protected alien.  This alien
			       		also controls when to turn.

		       int:    leftAlien:   the alien number to the left. Only
		   			true if this is a back row.
			       rightAlien:  Alien number to the right. Only
			                true if this is a back row.
			       front Alien: Alien in front of object
			       Back Alien:  Alien in back of object

		 Methods  :  
		        FireShot:  if front row fire shot with an exponential
			distribution with fixed parameter lambda.

			Blow Up:  Update the Alien to the right and left so
			that they are linked together.  Decrement the total
			Alien count.  Launch an explosion.

			MoveLeft:  Leftmost alien moves left based on a trigger 
			Move Left and Trigger aliens to the left and 
			below to move left.

		        MoveRight:  Move Right and Trigger Aliens to the right
			and down to move right.

			MoveDown:  Trigger aliens to the right, left and down
			to move down.

		  Triggers: 
		          FireShot: Random

			  Blow Up:  On Collision with Bullet.

			  RightEdge: if rightMost alien and on the edge of the
			  screen moveLeft.

			  LeftEdge: if leftMostAlien and on the leftEdge of the
			  screen MoveRight


	Bullet:
	    Triggers:
	       OnCollision: Die

	Barrier:

	        Triggers:
		      BlowUp: on Collision with Bullet.

        GamePlay Manager:
	      
	        Data Members:
		   Score:  The current Score:
		   AliensLeft: Number of Aliens Left.
		   PlayersLeft: Number of Players Left
	   
                Methods:

	        	init Aliens: Create a block of Aliens based on the current
			screen width and alien size.

			init Baracade: Create three Baracades Based on the size of the
			player, size of the Alien brigade and the space in between.

			Init Player:  Make three players.
			EndGame: Check if the game is over
		Triggers:

	                onCollision: if a collision with an Alien, decrement
			the Number of Aliens.  If collision is with the player.
			create new player and decrement the players left.

InterObject Communication
----------------------------

  The objects communicate in very specific ways.  The primary way objects
  communicate is through launching and recieving bullets and collisions.  The
  players and aliens launch bullets but do not know the outcome of those
  bullets. The global manager is invoked for each collision.


  Player -Bullet:
      Player instantiates bullets:
      Player dies on collision with bullet:

  Player-Manager:
      if Player dies, decrement players left and run Endgame.

  Barrier- Bullet:
        On Collision section of Barrier gets destroyed

  Alien -Bullet:
        Aliens instantiates bullets
	Alien dies on collision with Bullet

  Alien- Manager:
         if alien dies decrement the count of aliens and check
	 if endgame.
  Alien- Alien:
          if Alien dies, update neigbors with next left, right,
	  so right and left always work.

  


  
		





       






                
            
	
      


	





     


     	 








