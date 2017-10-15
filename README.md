# autonomousAgents
This repository contains a Unity project created for the Autonomous Agents module of the Interactive Entertainment Technology Masters course. The project contains a simulation of "Westworld", a small fictional town populated by three inhabitants: the Sheriff, the Outlaw, and the Undertaker. There are scripts implementing agents (which are finite state machines), messaging, the world (which is a procedurally generated 8x8 2D gird), pathfinding (A\*), and sensing.


The agents of Westworld each have their role to play. The Sheriff wanders the town, keeping an eye out for the Outlaw, trying to find his secret hideout, but he never can. If he spots the Outlaw, he shoots him on sight. The Sheriff is a bit of a drunkard though, so if he checks for the Outlaw in the Saloon, he may stop for a drink or two, or three...

The Outlaw lurks in the seedy parts of town - the cemetery, the saloon, or the outlaw camp - until he's ready to rob the bank. He may take some time out for a smoke break. If he's caught and killed by the Sheriff, he reappears back at the Outlaw Camp.

The Undertaker of Westworld lives a simple life. He waits at his Undertaker's shop until he gets word of a dead body - i.e. the Outlaw after a run-in with the Sheriff - then fetches the body and takes it to the cemetary, before returning to his shop.