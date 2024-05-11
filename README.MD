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
        
    
