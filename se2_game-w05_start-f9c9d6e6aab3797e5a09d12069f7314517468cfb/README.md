# SE2 Game

De applicatie heeft wat veranderingen ondergaan. In lijn met de aanpassingen
van afgelopen week, is er een base klasse aangemaakt: `Entity`. Het bewegen
van de speler wordt bepaald door bij iedere `Update` van het spel de `Move`
methode aan te roepen.

Deze `Move` methode is echter - net als de `Entity` klasse zelf - abstract.
Oftewel, de `Entity` klasse kan niet langer geïnstantieerd worden: alleen de
afgeleide klassen bieden nog deze mogelijkheid. In deze klassen dien je de
Move methode van een invulling te voorzien. In de `Player` klasse is dit al
gedaan: in de `Enemy` klasse moet dit nog gebeuren.

De constructor van de `Enemy` klasse is eveneens aangepast. Deze dient nu een
parameter te krijgen van het type `IMoveLogic`. Deze interface is eveneens al
geleverd, naast een uitwerking die willekeurige beweging mogelijk maakt.

## De opdracht voor deze week

 1. Maak de applicatie weer werkend zodat je kennis maakt met abstracte
    klassen. Deze stap is afgerond als het spel weer naar behoren werkt, en de
    tegenstander willekeurig over het scherm beweegt.
 1. Pas het spel aan zodat er meerdere enemies in het spel zijn. De gebruiker
    moet in de GUI op kunnen geven hoeveel enemies er gewenst zijn, en het
    spel met een knop kunnen starten.
 1. De volgorde van tekenen is nog niet helemaal correct. Nu zal de player
    altijd over de enemies getekend worden. Om dit op te lossen kunnen we een
    `IComparer` klasse aanmaken, die `Entity`s kan sorteren op basis van het
    Y-coordinaat. Door alle `Entity`s in een lijst te zetten en deze te
    sorteren, kunnen we eenvoudig alles in de juiste volgorde tekenen.
    Implementeer ook deze functionaliteit. Als tip hierbij: plaats alle
    `Entity`s in een lijst en sorteer deze om de juiste volgorde te bepalen.
 1. Voeg minstens één nieuwe "intelligentie" (AI) toe voor de tegenstander.
    Zie hiervoor de `MoveLogicRandom` klasse, maar maak een nieuwe klasse aan
    die eveneens de `IMoveLogic` interface implementeert. Laat alle enemies
    bewegen door ze gebruik te laten maken van deze nieuwe implementatie.
 1. Naast het aantal enemies, moet de gebruiker ook kunnen kiezen welke AI de
    tegenstanders moeten hebben. Ook moet een willekeurige AI per tegenstander
    mogelijk zijn. Iedere AI moet ook een duidelijke naam krijgen: voeg aan de
    `IMoveLogic` interface dus een `string` property toe om deze naam vanuit de
    code in op te slaan.
 1. Probeer voor jezelf de volgende vraag te beantwoorden: waarom maken we nu
    gebruik van een interface voor de AI?

