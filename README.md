# Blazor

### Was ist Blazor ?

Blazor ist ein Framework, welches uns erlaubt interaktive Web-Applikation mit C# zu erstellen.
Sprich Blazor erlaubt es uns C# für das Frontend der Web-Applikation zu verwenden.

#### Vorteile

- .Net Ecosystem
- C#
- Code im Frontend und Backend zu verwenden
- Mit den Blazor Komponent zu arbeiten

## Component

### Allgemein

- Ein Komponent ist ein wiederverwenbares Stück von einem "User interface"
- Ein Komponent kann C# Code enthalten
- Ein Komponent ist eine Klasse

### Parameters

Grundsätzlich können Parameter Daten, Events oder Content sein.
Diese können dann übergeben werden, wenn der Komponent augerufen wird.

```cs

<di>
	<p>@Text</p>
</div>

@code {
	[Parameter] public string Text { get; set; }
}
```
So könnte ein Razor Komponent aussehen.

```cs

<Beispiel Text="Das ist ein Beispiel"></Beispiel>

@code {
}
```
Und der Komponent würde dann wie in diesem Beispiel aufgerufen werden.
An der Stelle, wo jetzt Beispiel steht müsste dann der Name von dem Komponent stehen.

### Events

Die Events die Blazor bei den HTML Elementen zur Verfügung stellt, können mit einem @ aufgerufen werden.

```cs

<button @onclick="Beispiel" ></button>

@code {
	private void Beispiel()
	{
		Console.WriteLine("Beispiel");
	}
}
```

Wie man am Beispiel sehen kann, muss einfach zwischen "" den Name von der Methode angegeben werden. 
So wird dann jedes mal bei dem Event die Methode ausgeführt.

### EventCallback

EventCallbacks sind z.B. dafür da, dass man Methoden ausserhalb von dem Komponent aufrufen kann.
Im Code drin würde das wie folgt aussehen, in dem Komponent wird ein Parameter von dem Typ EventCallback definiert.
An dem Punkt, wo man den Komponent aufruft, wird dann die Methode als Parameter übergeben.

```cs

<button @onclick="(() => WriteBeispiel.InvokeAsync(beispiel))" ></button>

@code {
	private Beispiel beispiel;
	[Parameter] public EventCallback<Beispiel> WriteBeispiel { get; set; }
}
```

In dem Beispiel wird wenn auf den Button geclickt wird der EventCallback ausgeführt. 
**Wichtig ist falls die Methode ein Parameter hat, muss in den <> den Datentyp angegeben werden.**

```cs

<BeispielComponent WriteBeispiel="WriteBeispiel"></BeispielComponent>

@code {
	private void WriteBeispiel(Beispiel beispiel)
	{
		Console.WriteLine(beispiel);
	}
}
```

In dem Beispiel wird gezeigt, wie man eine Methode übergibt.

## Routing 

### Allgemein

Grundsätzlich muss man beim Routing wissen das es, wie bei dem unten gezeigten Beispiel, gemacht werden kann.
Sprich es brauch ein @page und danach als string angeben, welchen Pfad die Seite hat.
Der Pfad muss immer mit einem / beginnen!

```cs
@page "/Beispiel"

@code {
	// Code to execute.
}
```

### App.razor

In dem App.razor kann man primär definieren, was passiert wenn die "Route" gefunden worden ist oder nicht.
Wenn man den Screenshot unten anschaut sieht man dort einerseits den Komponent Found und NotFound.
In den beiden Komponent wird definiert, welche Razor Seite aufgerufen wird und welches Layout die Seite hat.

![Alt text](/Images/App.razor.png?raw=true "App.razor Datei")

### NavigationManager

Der NavigationManager wird, wie schon der Name sagt, für die ganze Navigation von der Applikation gebraucht.
Man kann den NavigationManager brauchen in dem man ihn "injected", wie im Beispiel unten.

```cs
@page "/Beispiel"
@inject NavigationManager navigationManager

<button class="btn btn-primary" @onclick="Redirect">Click me</button>

@code {
	private void Redirect()
	{
		navigationManager.NavigateTo("Index");
	}
}
```

Bei dem NavigationManager kann auch die aktuelle URL ausgelesen werden und noch einiges weiteres rund um die URL.

### Route Params

Die "Route Params" können ausgelesen werden, in dem man in der Route geschweifte Klamern macht.
Diese Klamern müssen an dem Ort sein, wo man den Parameter erwartet.
Dann sollte in der Klamer der Name von dem Parameter sein ( **muss gleich heissen, wie der angeben Parameter im Code** ).

```cs
@page "/Beispiel/{BeispielId:int}"
@inject NavigationManager navigationManager

<button class="btn btn-primary" @onclick="Redirect">Click me</button>

@code {
	[Parameter] public int BeispielId { get; set; }
	
	private void Redirect()
	{
		navigationManager.NavigateTo("Index");
	}
}
```

**Falls der Datentyp nicht string ist muss dieser explizit angeben werden, wie in dem Beispiel gezeigt.**



