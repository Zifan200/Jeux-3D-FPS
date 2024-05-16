Plan de test

Player Mouvement:
    1- La touche W permet au player d'avancer.
    2- La touche S permet au player de reculer.
    3- La touche A permet au player de déplacer latéralement a gauche.
    4- La touche D permet au player de déplacer latéralement a droite.
    
Player Camera:
    1- Bouger la sourie vers le haut déplace la caméra vers le haut.
    2- Bouger la sourie vers le bas déplace la caméra vers le haut.
    3- Bouger la souris vers la gauche fait tourner la caméra vers la gauche.
    4- Bouger la souris vers la droite fait tourner la caméra vers la droite.
    5- Lorsque la caméra se tourne vers une nouvelle direction, les touches WASD doivent se mettre à jour.

Inventaire:
    1- Être proche ou sur le documentA, le documentB et la clé doit faire dispaître les objets.
    2- Si le joueur touche le documentA, la case du documentA doit être cochée.
    3- Si le joueur touche le documentB, la case du documentB doit être cochée.
    4- Si le joueur touche la clé, la case de la clé doit être cochée.

Condition de victoire:
    1- Lorsque le joueur à tous les 3 objets et qu'il arrive à la porte, un message de victoire s'affiche avec un bouton rejouer et quitter.

Condition des objets manquant:
    1- Lorsque le joueur se rend à la porte et il manque des objets, un message apparaît pour lui dire des objets qu'il lui manque à    récupérer.
    2-Une fois le message affiché devant la porte, lorsque le joueur s'éloigne de la porte, le message des objets à récupurer disparaît. 

Gestion des tirs sur l'ennemi:
    1- Appuyer sur le click gauche de la souris devrait tirer/raycast
        Vérification avec un Debug.Log.
    *Test pour le pistolet:
    1- Head Shot 
        Tirer sur la tête/yeux de l'ennemi fait 100(25 * 4) dommages et les vies de l'ennemi devrait tomber à zéro.
    2- Body Shot
        Tirer sur le coprs de l'ennemi fait 25 dégâts et les vies de l'ennemi devrait tombé à 75,25,0.
    3- Reste du corps
        Tirer sur les mains de l'ennemi fait 6.25 dégâts(25 * 0.25) et les vies de l'ennemi devrait tombé à 93.75 vies après le 
        premier cours de feu.

    note: pour le moment j'ai implémenté seulement les dommages pour le pistolet. Je reviendrais plus tard pour implémenté le reste des armes. 

Grenade:
    1- Lorsque le joueur ramasse une grenade:
        a- La grenade doit disparaître du jeu.
        b- Une icône de grenade doit apparaître.
    2- Une grenade est instanciée en appuyant sur la touche "g".
    3- Lorsqu'une grenade entre en collision avec n'importe quoi, elle doit disparaître.
    4- Si la grenade touche un ennemi, la barre des vie de l'ennemi devrait diminuer.
    
Agression:
    1- Si le joueur est dans le champ de vision et proche de l'ennemi, il va commencer à poursuivre le joueur.
    2- L'ennemi ne doit pas toucher le joueur en le poursuivant et doit être à une distance raisonnable entre le player et lui.
    3- Lorsque l'ennemi tire, il a 33% de chance de toucher le joueur.
    4- Après que l'ennemi tire, il ne doit pas tirer après 2 secondes.
    5- Si le player est touché, les points de vie du player doit diminuer.
    
Condition de défaite :
    1- Le timer diminue. 
    2- Si la vie du joueur ou le timer tombent à 0, le message de défaite s'affiche.

Condition de victoire(suite):
    1- Dans le message de victoire, le temps écoulé devrait s'afficher.
    2- Lorsque le message de victoire s'affiche, le jeu devrais se mettre en pause.
    3- Appuyer sur le button quitter nous ramène au menu principal.

MenuPause:
    1- Appuyer sur le button ESC devrait mettre le jeu en pause.
    2- Lorsque le jeu est en pause, cliquer pour tirer ne doit pas faire perdre des vies à l'ennemi.
    3- Cliquer sur le boutton reprendre, devrait faire disparaitre le menu et reprendre le jeu.
    4- Cliquer sur le boutton quitter, devrait ramener au menu Principal.

Gestion de munition:
    1- Le HUD affiche les informations des munitions actuelle, des munitions totales du chargeur de l'arme et des munitions d'extra.
    2- Apuuyer sur le boutton tirer, update le hud des munitions actuelles.
    3- Appuyer sur le boutton "r", update et ajoute le nombre de munition extra dans munitions actuelle et le nombre de munition extra diminue.

Gestion des armes:
    1- Ramasser un assault rifle ou un SMG devrait disparaitre du jeu.
    2- Appuyer sur le boutton e doit changer l'arme en trouvant la prochaine arme dans le tableau.
    3- Appuyer sur le boutton q doit changer l'arme en trouvant l'arme qui précède dans le tableau.
    4- En scollant avec le boutton de la souris vers le haut, on doit soit trouver la prochaine arme.
    5- En scollant avec le boutton de la souris vers le bas, on doit trouver l'arme qui précède dans le tableau.
    6- En changeant d'arme, l'îcone de l'arme doit apparaître et correspondre à l'arme en main du joueur.
    7- Le nom des armes doivent s'affichent et correspondrent à l'arme en main du joueur.
    8- Tirer sur le corps d'un ennemi avec un fusil d'assaut doit enlever 30 dommages.
    9- Tirer sur la tête d'un ennemi avec un fusil d'assaut doit enlever 120 dommages. 
    10- Tirer sur la main d'un ennemi avec un fusil d'assaut doit enlever 7.5 dommages.
    11- Tirer sur le corps d'un ennemi avec un SMG doit enlever 10 dommages.
    12- Tirer sur la tête d'un ennemi avec un SMG  doit enlever 40 dommages. 
    13- Tirer sur la main d'un ennemi avec un SMG doit enlever 2.5 dommages.
        
    
