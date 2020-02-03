# PFE-Noe2999
[Chen Xiaotong](https://gitlab.com/xiaotong1996)

[Delavelle Quentin](https://gitlab.com/Docteur54)

[Lheureux Etienne](https://gitlab.com/Chtouille)

[Xu Ruitong](https://gitlab.com/Lyoko)

## Project introduction
This project is carried out in the academic framework of the third year of TSP
and ENSIIE.

This is project is a video game for children from 4 to 6 years old, developed by Unity. The main goal of the game Noe2999 is to make the youngest aware of the environmental issue while being as fun as possible.

The story takes place in the future, in the year 2999, and consists of a reinterpretation of the myth of Noah's Ark: following the melting of the ice, water covered the planet and forced humanity to leave Earth. Only a few scattered islets and their fauna remain, as well as N03, the robot that the player will embody! His mission ? Protect animals by taking care of them, and lower the sea level by reforming glaciers!

To do so, the player will travel to the various islands aboard his boat, islands on which there are animals that he can collect. Each island is defined by a specific ecosystem (plain, jungle, etc.), but the animals living on these islands are not necessarily adapted to the ecosystem in question. It is therefore up to the player to place the animals in their natural habitat! When the animals are on board his boat, the player can take care of them by giving them food, for example, in order to increase their satisfaction. By an incredible scriptwriting facility, it turns out that there is in 2999 a machine allowing to transform happiness into energy! Also happy animals produce the resource that allows the ship to move forward, but also to transform water into ice, action that the player can perform at any time and which serves to lower the sea level. This, in more to approach the player of his ultimate goal, makes appear new islands!

## Scenes

1. Start : Welcome Screen
2. Map3D : Show the earth, islands, ship.
3. vaisseau_Ile : Half showing islands, half showing space inside ship
4. Vaisseau : Show space inside ship
5. Introduction : Background and operating instructions
6. End : Game over screen

## Code Structure

### Architecture

**UML class diagram**

![Noe2999](.\Noe2999.jpg)

### Modules

**Manger**

Some management classes designed with singleton which contains **AudioManager, GameManager, MenuManager, MusicManager, SceneManager, UIManager, DataManager**

**Entity classes**

Some classes used to represent game entities and hold data which contains **Races(Animals), Salles(Rooms), Destination(Islands), Vaisseau(Ship) etc.**

**Map3D**

Contains all 3D map-related scripts to enable players to interact with the map.

**StorageBox**

Contains all food-related scripts to implement the function of storing items.

**Emotion**

Integrated in the entity class of animals, used to display the icons of different emotions of animals

**Others**

Some utility classes and scripts that help implement interaction and game logic

## References

1. Package Unity 2D Sprite Outline      --     Hanna Fiani 
2. Package Unity Blue Cartoon GUI Skin  --     3d.rain
3. Package Unity MyNotifications + Animated + Sound -- [Mario Haberle](https://assetstore.unity.com/publishers/20994)
4. All the musics and sounds effect -- http://www.aigei.com/
5. All the icons -- https://www.flaticon.com/  
6. Boat model -- https://3dwarehouse.sketchup.com/
7. Flag model -- http://www.cbprojs.com/





