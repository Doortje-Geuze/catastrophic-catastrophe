# Classes

Een class is een soort blauwdruk voor objecten. In een class zitten methodes en attributen. Attributen beschrijven een bepaald gedrag en methodes geven toegang tot deze attributen.

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






# Bronnen

[sitemasters.be](http://www.sitemasters.be/tutorials/20/1/551/Gecombineerd/Classes)