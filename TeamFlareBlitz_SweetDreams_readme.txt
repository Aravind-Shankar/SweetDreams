Start Scene: Menu

Requirements/How To Play: From the Menu, you can click Start Game to begin playing. You are tasked with fulfilling multiple drink orders in time by buying and gathering ingredients from a store combined with a "dream potion" located in the basement. You can control a 3D character in realtime with WASD, interact with objects on the counters, drop potions/chamber food (incomplete), picking up and placing ingredients. You can collide with the walls as well as go down stairs to the basement level. There are npc customers that are powered by real-time steering behaviors, entering the store and only leaving once you complete their orders. 

Problem Areas: When playing the tutorial, when a tutorial tip appears, you are still able to interact with the world while you're still occupied by the tooltip, leading to confusing interactions. Occasionally, the customers can get stuck against each other when trying to enter/exit the door simultaneously, and because the order doesn't queue up until the customer comes in and reaches the counter, the customer queue will remain empty until you have to walk over to them and push them through to relieve the "traffic jam". 

Manifest:
Steven: 
1. Worked on all scripts within Scripts/Customers folder including CustomerAI and CustomerQueue, Utility/BackgroundMusic script, implemented Customer and BarWaypoint/LeaveWaypoint prefabs, handled everything Audio, sound effects, music transitions, music intensity changes
2. Assets: BarWaypoint, LeaveWaypoint, Customer, NavMesh, customers.json, all of the audio tracks, 
3. C#: CustomerAI.cs, CustomerQueue.cs, BackgroundMusicManager.cs, audio functionality in the following files: ChamberHealthManager.cs, LiquidDispenser.cs, OrderSubmitter.cs, Dispenser.cs, Susbar.cs, MarketIngredientPanel.cs, 

Ryan:
1. I did the player movement, asset gathering and the design for the store and the basement, the UI for menus, and the suspicion meter
2. For assets, I basically added all the things in the Models' folder. 
3. I did the scripts in the Input and Camera folder and SusBar.cs

Brian:
1. Created the inventory and item system, gave users the ability to receive dispensed items, drop items, throw away items, and submit potion orders, created the tutorial along with the functionality for the path guidance and tutorial tool tips, modified game data for balance and quality of life
2. Assets: Everything inside DrinkSystemPrefabs, numerous triggers, markers, and NavMesh used for tutorial path guidance functionality, CustomersTutorial ScriptableObject 
3. C#: LiquidDispenser.cs, OrderSubmitter.cs, Inventory/** except for PotionPanel.cs, EventManager.cs, ChamberFoodDispenser.cs, Utility/Tutorial*.cs, ChamberHealthTutorialTipHandler.cs

Aravind:
1. I did the chamber health & food systems (logic + models), the HUD canvas elements (active orders, event log, potion panels, controls..), final market UI and logic, data flow logic via scriptable objects, and also made the final customer model and prefab.
2. I added Models/customer_model.obj (the new customer), animations for money UI updates, many prefabs for the HUD & Market UI elements as well as chamber system.. And created the assets in Data/ and UI/.
3. Created the scripts inside Scripts/Data/ and Scrips/ChamberSystem... And made multiple additions/modifications in the other folders which I can't remember exhaustively. (example additions: PotionPanel.cs, ControlsViewManager.cs. example modifications: everything in Scripts/Customers, and Interactable.cs)

Ke Gong:
1. Created frame for market UI and interaction with counter (need to be close to counter and press space to open market)
2. Assets: Market Canvas and Panel
3. C#: Market.cs, MarketController.cs