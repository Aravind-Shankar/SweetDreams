Start Scene: Menu

Requirements/How To Play: From the Menu, you can click Start Game to begin playing. You are tasked with fulfilling multiple drink orders in time by buying and gathering ingredients from a store combined with a "dream potion" located in the basement. You can control a 3D character in realtime with WASD, interact with objects on the counters, drop potions/chamber food (incomplete), picking up and placing ingredients. You can collide with the walls as well as go down stairs to the basement level. There are npc "customers" that are powered by real-time steering behaviors, entering the store and only leaving once you complete their orders. 

Problem Areas: Customer clipping through walls, Gaps between certain walls, incomplete item holding, potion ordering/submitting, market, and chamber systems

Manifest:
Steven: 
1. Worked on all scripts within Scripts/Customer folder including CustomerAI and CustomerQueue, Utility/BackgroundMusic script, implemented Customer and BarWaypoint/LeaveWaypoint prefabs.
2. Assets: BarWaypoint, LeaveWaypoint, Customer, NavMesh, customers.json, both sound tracks
3. C#: CustomerAI.cs, CustomerQueue.cs, BackgroundMusicManager.cs

Ryan:
1. Created the suspicion meter for tracking the failure condition for the player
2. Assets: Loading bar and Player model taken online
3. C#: Everything in the Input folder, and Player/Susbar

Brian:
1. Created the inventory and item system, gave users the ability to receive dispensed items, drop items, throw away items, and submit potion orders
2. Assets: Everything inside DrinkSystemPrefabs
3. C#: Liquid Dispenser.cs, OrderSubmitter.cs, Inventory/**, EventManager.cs, ChamberFoodDispenser.cs

Aravind:
1. Worked on the chamber and food framework, and then fleshed out the design of the game
2. Assets: Human Chamber prefab, associated materials
3. C#: the scripts related to chamber health and food collection/usage to replenish chamber health

Ke Gong:
1. Created frame for market UI and interaction with counter (need to be close to counter and press space to open market)
2. Assets: Market Canvas and Panel
3. C#: Market.cs, MarketController.cs