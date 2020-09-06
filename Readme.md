﻿# Console Workflow for .NET Core

Console Workflow is a simple workflow framework lets your Console app **focus only it's business**. The application flow  will be handled by Console Workflow. You can create functional menu-based console clients when you test your backend code.    

# How it works

The diagram below shows a simple workflow. You should define your steps and relations between them. Each step might have works to do inside the step. You can manage this with the help of `Step Handler`s.

![alt text](https://i.ibb.co/6sn0y5C/workflow-diagram.png)

# Usage

## Define your application steps.
First, you should define your application steps by instantiating new `Step` objects. Step objects have `Name`, `Handler` class and a `Menu`.

Defining a step is simple and fluent as shown below.

    var mainStep = new Step(new StepConfigurationBuilder()
                .SetName("MAIN")
                .Build());
 
 ### Configure the Step
 Steps must be configured in order to
 - Let the program decide the `next step` to execute
 - Display the `menu` when step being executed.
 - Define a `step handler` to do some work when step being executed.

Step configuration can be defined fluent and straighforward:
 

    var mainStep = new Step(new StepConfigurationBuilder()
                .SetName("MAIN")
                .ExecuteAfter("CATALOG", "c")
                .ExecuteAfter("BASKET", "b")            
                .UseHandler<MainMenuStepHandler>()
                .AddMenuItem(1, "View catalog items", "c")
                .AddMenuItem(2, "View your basket", "b")
                .Build());

## Register steps to step container
Each step must be registered to the `StepContainer`. 

    
    StepContainer.Register(mainStep);
    StepContainer.Register(catalogStep);
    StepContainer.Register(basketStep);


## Use Process static class to start the program
To start the program's flow, just call the StartProcessFlow method of Process static class with the initial step name.

    Process.StartProcessFlow(initialStepName: "MAIN");

# Output
A sample output 

![alt text](https://i.ibb.co/VBKrcx9/sample-output.png)



