# Linked In cursus C#: Interfaces and Generics



## Overview

### What are interfaces?

"Interfaces specify a contract - any class that implements an interface must implement the logic of the functions defined in that interface"

- idicate that a class kan preforme a certain function
- Beschrijven gedrag, geen individuele classes
- Een interface kan gebruikt worden onder vershillende classes
- Classes kunnen meerdere interfaces implementeren
- Interfaces beiden zelf geen logica

### What are Generics?

"Generics are classes, structures, interfaces, and methods that have placeholders for one or more of the types that they store or use"


- Voordelen: Type safety, herbruikbaarheid, efficientie
- Meest gebruikt met data collections
  
## Interfaces

### Defining and implementing an interface

- `Interface` gebruiken als een `keyword` -> `interface IStorable`
- Aan geven bij de class naam: `class ... : IStorable`
- implementeer de interface in de class
- exercise de interface = succes :).

### Interfaces and casting

- `New Interface` werkt niet :(
- `Keywords` `Is` en `As` kunnen wel gebruikt worden (yippiee!)
- `is` operator 

  
  ```cs
  if (d is IStorable){
    d.save();
  }
  ```
- `as` operator
  
  ```cs
  IStorable istor = d as IStorable
  if (istor != null){
    istor.load();
  }

  ```

### Implementing multiple interfaces 

-  `class ... : IStorable, IEncryptable, .... , ....`
  
### Using explicit interface implementation

```cs
class ... : Interface1, Interface2
{
Void interface1.SomeMethode(){
    console.writeline( "interface1 works yippi!")
}
Void interface2.SomeMethode(){
    console.writeline( "interface2 works yippi!")
}

}
```
- Calling the  methode in the interface:
  
```cs

Interface1 i1 = testclass as Interface1;
i1.SomeMethode();
Interface2 i2 = testclass as Interface2;
i2.SomeMethode();

```

### Using .NET-defined interfaces

![.NET-Defined Interfaces](/docs/Doortje/LinkenIn-Cursus/Built%20in%20.NET%20interfaces.png)

## Generics

### The benefits of generics

- Generic List vooreeld:
  
  ```cs
  List<int> arrList = New list<int>();
  arrList.Add(1);
  arrList.Add(2);
  .etc
  ```

- In de `<>` kan je aangeven wat het datatype is zoals `<int>`
- Dit verbetert de prestaties

### Generic list collections

[Microsoft Generic list collections](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0)

### Queue and stack

- Queue = First in First out,
- Stack = Last in, First out 
- Stack:
  
  ```cs
  ...Stack.Push(" ");

  //examine item at the top of the stack
  string top = ...Stack.Peek();

  //Removes item from the top
  string item = ...Stack.pop()
  
  //Look for tem in stack
  Console.WriteLine(...Stack.Contains(" "));

  ```

- Queue:
  
```cs
...Queue.Enqueue("  ");

//examine item at the tfront of the Queue
  string str = ...Q.Peek();

  //Removes item from thefront of the queue
  str = ...Q.Dequeue();
  
  //Look for tem in stack
  Console.WriteLine(...Q.Contains(" "));

//remove all items
...Q.Clear();


```

### Dictionary

- mapping an unique key to an asociated value

propertys:
  ![](/docs/Doortje/LinkenIn-Cursus/Dictonary-genaric-interfaces.png)

## Resultaten LinkedIn Learning cursus

![](/docs/Doortje/LinkenIn-Cursus/C#%20Interfaces%20and%20Generics%20certivicaat.png) 

## Toepassing op eigen project


## Vragen voor expert review
- Wat zijn meer voorbeelden van hoe ik genarics kan gebruiken in mijn eigen project?