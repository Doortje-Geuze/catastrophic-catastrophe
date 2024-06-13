# Classes

Een class is een soort blauwdruk voor objecten. In een class zitten methodes en attributen. Attributen beschrijven een eigenschap en methodes geven toegang tot deze attributen en beschrijven een bepaald gedrag.

Een class kan als volgt worden aangemaakt:
```csharp
class VoorbeeldClass
{

}
```

Om de class 'blauwdruk' uit te voeren kan je een object maken van de class door hem als volgt te instantiëren.

```csharp
VoorbeeldClass VC = new VoorbeeldClass();
```

Van een static class kan geen instantie (object) worden gemaakt. Om een static class te maken zet je het keyword static voor de class. Een static class kan geen constructor bevatten.

Met access modifiers kan je bepalen hoe toegangelijk de aangemaakte class is. 
De access modifiers in c# zijn:
- public
- protected
- private

Methods hebben invloed op de toestand van het object in de class. Je hebt verschillende soorten methods. 
- constructors
- destructors
- selectors/modifiers

Een constructor maakt een object aan.

```csharp
class VoorbeeldKlasse
{
   private string naam;
   public VoorbeeldKlasse()
   {
       this.naam = "default";
       //default constructor, zonder parameters
   }
}
```

Destructors vernietigen een object.  

Getters en setters vormen een property van een object. Met een setter geef je een waarde aan een object. Met een getter haal je deze waarde weer op. 

```csharp
class mijnKlasse
{
   private string _naam
   public string Naam
   {
       get { return _naam; }
       set { _naam = value; }
   }
}
```

Getters en setters worden gebruikt om te voorkomen dat code zomaar kan worden aangepast. Getters en setters zorgen voor encapsulation. Een getter leest de waarde die wordt meegegeven aan een variabele. De setter kan voorwaarden bevatten waar de variabele aan moet voldoen. Ook vertelt de setter dat er een waarde aan de variabele moet worden gegeven. Getters en setters zijn een tussenstap tussen variabelen en het toewijzen van een waarde aan de variabele

# Namespaces
Namespaces worden gebruikt voor het scheiden en organiseren van code. Met namespaces kan je variabelen en methods met dezelfde naam gebruiken in verschillende namespaces.  
Je kan een namespace instantiëren met de keywords namespace en using. Je kan ook meerdere namespaces in elkaar declareren. Dit worden nested namespaces genoemd.
Met de using keyword importeer je namen van een andere namespace.






# Bronnen

[sitemasters.be](http://www.sitemasters.be/tutorials/20/1/551/Gecombineerd/Classes)  
[Tutorialspoint](https://www.tutorialspoint.com/csharp/csharp_namespaces.htm)  
[Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/namespaces)  
[Programiz](https://www.programiz.com/csharp-programming/namespaces)  
[Bro Code](https://www.youtube.com/watch?v=8FmE_-QXg3Y)  
