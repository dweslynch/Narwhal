# Narwhal

## Project Structure

This project contains the classes that do the heavy lifting, and `Program.cs` defines a console app that we can use to implement those classes.

The `datafiles` directory contains the MNIST dataset for digit recognition, and the `Test` directory contains a suite of unit and integ tests.

## Required reading if you only know Java

Promise I'll keep it short.  But these will really help.
* [Properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties).  You won't believe you ever went without them
* [Indexers](https://learn.microsoft.com/en-us/dotnet/csharp/indexers) let you write properties that are accessed with array-like indexes
* [Expression-Bodied Members](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members) let you write constructors, methods, or properties as single expressions, when applicable

## Setup

First step is to [download .NET 7](https://dotnet.microsoft.com/en-us/download).  From there, get the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for VSCode.

## Building and Running

To run the acutal console app defined in `Program.cs`, cd to the project directory and:

```
dotnet run
```

You may need to run `dotnet build` first if your latest changes aren't being reflected

## Unit Testing

To run the test suite, cd into the project directory and run:

```
dotnet test
```

Again, if latest changes aren't being reflected, first `dotnet build` the project, then `dotnet test`.