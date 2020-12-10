# Combat-System

•	<b>Description:</b> Simulation of player interactions with enemy units. Player attacks to activate enemies. On enemy’s death, it activates more enemies. Number of enemies can directly be scaled up maintaining functionality.<br><br>

o	Cinemachine to follow player in third person test method to lock on to targets.<br>
o	Unity’s New Input System to move player, attack enemy units and lock on to targets.<br>
o	Added Hitboxes on enemy units to activate and deal damage, and showed damage inflicted using Coroutines.<br>
o	Delegates to provide variable functionality when attacking enemies: first activate enemies, then only damage.<br>
o	Enemy death to activates other enemies using Events and the Observer Design Pattern, to provide scalability<br>
