plan du TP certificatif

Menus :
-   Layout.
-	Navigation.

GameScene:
-	Environnement(Plane, Portes, cabanes).

Player logique:
-	Prefab.
-	Mouvement.
-	Camera.
-   Point de vie.

Inventaire
-	Document.
-	Clé.
-	Ramasser.

Conditions de jeu :
-	Message de victoire ou message qui indique qu’il manque des objets à ramasser.
-   Message qui affiche les objets qui manquent.

Tir sur ennemi Ennemi
-	Prefab.
-   Nombre de vie.
-   Raycast.
-   Gestion des vies(dommage, perte de vie).
    *Note: Gestion des dégâts pour le pistolet seulement. Je reviendrais plus tard pour implémenter le reste des armes pour avoir 
    le plus de fonctionnalités faites.

Grenade
-   Prefab
-   Instanciate.
-   Collision.
-   Dommage.

Agression de l’ennemi:
-   Détection du player.
-   tirer.
-   cadence de tir.
-   Dégât au joueur.

Condition de défaite :
-   Layout.
-   Timer.
-   Affichage du message de défaite.

Condition de victoire(suite):
-   Ajout du temps écoulé dans la condition de victoire.
-   Arreter le jeu.
-   Navigation pour le button quitter.

MenuPause:
-	Layout
-   Button ESC pour mettre le jeu en pause.
-   Reprendre le jeu.
-   Quitter gameScene.

Gestion de munition:
-   Layout
-   Reload

Gestion des armes:
-   Prefab des deux autres armes pas encore implémentés dans le jeu.
-   Ramasser les deux autres armes.
-   Changer d'arme.
-   Îcone.
-   Afficher nom des armes.
-   Dégâts des deux autres armes.

Particle system:
- Tirer.
- Toucher.
- Explosion pour la grenade.

Audio:
- Son pour tirer.
- Son pour mort d'un ennemi.
- Son pour recharger.
- Son pour tirer mais fusil vide.
- Son pour toucher une surface(ennemi exclu). 
- Son pour changer l'arme.
- Son pour explosition de la grenade.
- Son pour ramasser des objets.

Récupération des munitions:
- Ramasser des munitions fait disparaitre les munitions récupérées.
- Ramasser des munitions update le hud des extra munitions.

Audio Main menu:
- Musique dans mainMenu en boucle.
- Musique dans Level_01 en boucle.
- Slider qui modifie son et musique.

