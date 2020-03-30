# Blazor

## Component

## Routing 

### Grundsätzlich

Grundsätzlich muss man beim Routing wissen das es, wie bei dem unten gezeigten Beispiel, gemacht werden kann.
Sprich es brauch ein @page und danach als string angeben, welchen Pfad die Seite hat.
Der Pfad muss immer mit einem / beginnen!

```cs
@page "/for"

for (int i = 0 ; i < 10; i++)
{
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