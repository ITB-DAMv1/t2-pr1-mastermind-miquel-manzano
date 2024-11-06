# PR1 - Mastermind

Benvilgut al ReadMe del meu Super Mega Guay Repositori o tambe SMGR.

En aquest Readme trobaràs els meus punts entregats i el meu Joc de Proves... a mes de molts gatets.

![miaw](/img/miaw.jpg)


## Joc de Probes

Segons la practica: La combinació secreta a de ser una constant, que ha de contenir 4 números amb un possible valor d'entre 1-6.


### Cas 1

Comprovem si l'extrem del rang, més petit, funciona correctament en la Combinació.

Variables:
- Combinacio secreta: 1111
- Combinacio d'usuari: 1111

Output:
- Valor esperat: OOOO
- Valor obtingut: OOOO


Sortida de consola:

![cas1](/img/cas1.png)


### Cas 2

Comprovem si l'extrem del rang, més gran, funciona correctament en la Combinació.

Variables:
- Combinacio secreta: 6666
- Combinacio d'usuari: 6666

Output:
- Valor esperat: OOOO
- Valor obtingut: OOOO


Sortida de consola:

![cas2](/img/cas2.png)


### Cas 3

Comprovem si dins del rang funciona correctament en la Combinació..

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: 4545

Output:
- Valor esperat: OOOO
- Valor obtingut: OOOO


Sortida de consola:

![cas3](/img/cas3.png)


### Cas 4

Comprovem que passa en inserir un número superior al rang.

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: 8888

Output:
- Valor esperat: Missatge d'error
- Valor obtingut: Missatge d'error


Sortida de consola:

![cas4](/img/cas4.png)


### Cas 5

Comprovem que passa en inserir un número inferior al rang.

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: -1-2-3-4

Output:
- Valor esperat: Missatge d'error
- Valor obtingut: Missatge d'error


Sortida de consola:

![cas5](/img/cas5.png)


### Cas 6

Comprovem que passa en inserir un string.

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: miaw

Output:
- Valor esperat: Missatge d'error
- Valor obtingut: Missatge d'error


Sortida de consola:

![cas6](/img/cas6.png)


### Cas 7

Comprovem que passa en inserir un número dins del rang però incorrecte completament.

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: 1111

Output:
- Valor esperat: ××××
- Valor obtingut: ××××


Sortida de consola:

![cas7](/img/cas7.png)


### Cas 8

Comprovem que passa en inserir un número dins del rang però incorrecta posició.

Variables:
- Combinacio secreta: 4545
- Combinacio d'usuari: 5454

Output:
- Valor esperat: ØØØØ
- Valor obtingut: ØØØØ


Sortida de consola:

![cas8](/img/cas8.png)




## Punts entregats

Basant-me en la rúbrica, punts que he realitzat i com.


### Configuració del joc

Al principi del codi he creat unes constants on es pot canviar varis paràmetres del joc: combinació secreta, mida de la combinació... i en ser constants declarades dins de la classe, he pogut compartir-les amb totes les funcions:

![GameSetingsCapture](/img/GameSettings.png "Game Settings")


### Modulació del codi

El codi està pensat de tal forma que cada pantalla del joc o menú sigui una funció independent, d'aquesta forma és mes fàcil a l'hora de llegir el codi, modificar errors o fer canvis dins d'aquest.

A mes, trossos de codi que es repetia al llarg del programa els he convertit en funcions, per exemple, he fet una funció anomenada "ArrayMaker", la qual recorre una array i depenent de quin mode introdueixes realitza vàries accions:

![ArrayMakerCapture](/img/ArrayMaker.png "Array Maker")

Per exemple, si volem mostrar per pantalla una array només hauríem d'indicar-li el mode 1.


### Robusteça

El programa no ens transmet cap mena d'error o d'alerta.

![NoErrorsCapture](/img/NoErrors.png "No Errors")


### Claredat i ordre

He tingut en compte que el programa sigui el mes ordenat i llegible que he pogut, qualsevol crítica per millorar aquest àmbit és acceptada.

He creat els comentaris que he vist convenients, i no crec que faci falta comentar tot el codi, només parts importants.


### Variables i Constants

Les variables i constants creades són clares i fàcils d'entendre per algú que no hagi fet el codi, o almenys és el que intentat, no o sabre fins que hem donat el vist bo.


### Estructures de control

Des del meu punt de vista són correctes, no utilitzo sentències break, només en els switchos, i no donen a lloc indefinicions.


### Gestió d'errors

Vaig pensar que com només introduïm números podia fer una funció per introduir inputs.
En aquesta funció demanem un número a l'usuari dins d'un rang predefinit en cridar la funció, i si l'usuari introdueix qualsevol altra cosa o un número fora del rang se l'avisa i se l'indica quin rang de números accepta.

Quant als intents, jo he tret intents en introduir una combinació errònia, no crec que s'hauria de treure intents en introduir un número erroni, però això ja és qüestió de disseny de joc i gustos, ja que no ho especifica a la pràctica.

![UserNumInputCapture](/img/UserNumInputCapture.png "User Num Input")


### UX/UI

Jo he intentat ser el més user-friendly possible, donant missatges clars i entenedors a l'usuari.

