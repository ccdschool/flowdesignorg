# Übersetzungshilfen für Datenflüsse
![](../../../resources/images/in_arbeit.png)

Drawing bubbles and arrows is nice. But as you know: bubbles don't crash. So the question is how to implement the solutions shown under http://flow-design.org/design/. In this section we gonna show you how to implement *data flows:* *inputs* to and *outputs* from functional units. Each input will be implemented as a function. To be precise: each arrowhead is implemented as a function.

The functions and classes need names. It is critical to use the names from the solution. If you do so you can use the solution as a map to the implementation and vice versa. Think about a change in the requirements. The diagrams that represent the solution can be used to give you an orientation where the changes need to be done. Maybe the changes are so extensive that you first need to change the solution, maybe they are so small that you only need to change the implementation. Anyway you may use the solution as a map into the code if and only if you use the names from the solution in your implementation.

# How to implement inputs to a functional unit
## Single path inputs
How are data flows implemented? Lets look at the inputs first. If you have a simple functional unit *F* with an input dataflow that has *x* as a message this looks like the following in the solution:

![Single path input](https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/input/singlepath/diagram1.png)

An *x* is flowing into the functional unit *F*. This simple input flow is implemented as a function that is named after the functional unit:

<pre url="https://github.com/ccdschool/flowdesignorg/raw/master/source/csharp/implementation/implementation/input/singlepath/AsFunction.cs" range="7-9"></pre>

Its even possible to implement the input data flow as a static function if no state is required:

<pre url="https://github.com/ccdschool/flowdesignorg/raw/master/source/csharp/implementation/implementation/input/singlepath/AsFunction.cs" range="15-17"></pre>

The name of the function *F* corresponds with the name of the functional unit in the solution. The message *x* flowing into the functional unit is a parameter to the function and it is named after the message in the solution. I used *int* as the parameter type for *x*. The parameter type is not represented in the solution. This is for a good reason: the solution is much more abstract than the implementation. You have to decide which types you may use in the implementation for each given message.

In C# each function has to be contained in a class. So there is one name in the implementation that is not present in the solution, the class name. It has to be chosen to match the problem domain of the software system. If you implement the solution with a team of developers you have to find the names for the classes before starting to implement. We see it as a good practice to annotate all functional units in the solution with the class name it corresponds to. The following example shows how we typically do that:

![Single path input with class name](https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/input/singlepath/diagram2.png)

## Multi path inputs
A functional unit with multiple input data flows looks like the following:

![Multi path input](https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/input/multipath/diagram1.png)

The functional unit *F* now has two input data flows. On one of them a message *x* is delivered to the functional unit, the other data flow transports an *s* to *F*. Both inputs are independent so each of them can happen or not happen. We can't implement this as a function with two parameters (ok, we could implement it as a function with two parameters and give it *null* and a value for *s* if we have no *x*. But it would we be difficult to understand this logic). If we focus on implementing the arrowheads we have the problem that two arrowheads point to the functional unit *F*. So this time *F* could not be the name for both inputs. What we need are names for both arrowheads to be able to distinguish them. In the following diagram you see them added to the arrowheads.

![Multi path input with names](https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/input/multipath/diagram2.png)

The following listing shows how we could implement this scenario.
<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/input/multipath/AsClass.cs" mark="7-9,11-13" class=""></pre>

This time the class is named after the functional unit. The two input data flows are implemented as functions with the message as a parameter. Again we need to give them a name from the solution so we use the names given to the arrowheads.

## Joined inputs

Sometimes multiple messages are joined together to form one input flow as shown in the following diagram.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/input/join/diagram1.png" alt="Joined input" />

This is a single path input for functional unit *F* so we implement it as a function *F*. Both messages, namely *x* and *y*, are implemented as parameters to the function. Again note that the types for the parameters, *int* in this case, are not represented in the solution.

Our convention for joins is that all inputs form a tuple at the output side of the join. The example diagram shows a join with the two inputs *x* and *y* so the output from the join is a tuple *(x, y)*. We could have used the .NET type *Tuple&lt;,&gt;* but it is easier to use two parameters. Further note that the join is not represented explicitly in code. It is implemented implicitly.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/input/join/AsFunction.cs" mark="7-9"></pre>

# How to implement the outputs from functional units
## Single path outputs
<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/singlepath/diagram1.png" alt="Single path output" />

If a functional unit has one single output path we can implement it as a return value of a function. So if the functional unit *F* returns an *x* we can implement this as a function *F* returning *x* as shown in the following listing.
<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/singlepath/WithReturn.cs" mark="9" class=""></pre>

We can also implement the single path output as a *continuation*. The continuation is implemented as type *Action* in .NET. Think of it as a function pointer. The function *F* gets a pointer to a function as its parameter. It does its work and calls the continuation function without knowing the concrete function. So note that this does not introduce a dependency from *F* to its successor.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/singlepath/WithContinuation.cs" mark="9" class=""></pre>

There are solutions where more than one functional units needs the result from a preceding functional unit. See the following diagram for an example.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/singlepath/diagram2.png" alt="Single path output to multiple functional units" width="50%" height="50%" />

In this diagram the output of *F* is consumed by *G* and *H*. We can optimize this by implementing the output of *F* as an event instead of a continuation.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/singlepath/WithEvent.cs" mark="9,12" class=""></pre>

Now we can bind multiple successors to the event. Note that the API of this class needs a bit more care from the developer using it. This is because you have to bind something the event *OnResult* before calling the function *F*. If the output path is implemented as a continuation you can't call the function without passing it a continuation. And please note that we don't check the event on *null* before calling it intentionally. This is because F produces an output. We consider it as an error if nothing is bound to the event. So it is good to have the function *F* fail fast if erroneously nothing is bound to the event.

## Multi path outputs

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/multipath/diagram1.png" alt="Multi path output" />

If a functional unit has more than one output path we cannot implement it as a return value. Instead we can implement it as multiple continuations or with multiple events. The following listing shows how to implement it using multiple continuations passed in as parameters to the function.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/multipath/WithContinuation.cs" mark="9-10" class=""></pre>

Sometimes it is easier to use events instead of continuations. This is the case if multiple successors need the input from the functional unit. Implementing this scenario with events is an optimization in contrast to using continuations.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/multipath/WithEvent.cs" mark="9-10,13,15" class=""></pre>

&nbsp;

## Optional outputs

Optional output can be expressed by using a star outside the parenthesis as shown in the following diagram. The star means *multiple outputs*, ranging from zero to many. So this includes the optional case where the message either flows one time or doesn't flow at all.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/optional/diagram1.png" alt="Optional output" />

To better distinguish an optional data flow from a streamed data flow we use brackets for the optional case like shown in the following diagram.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/optional/diagram2.png" alt="Optional output" />

The optional output path cannot be implemented as a *return* value of a function. The return has to take place so we cannot express that it sometimes happens and is omitted other times. So we have two options: we can implement it as a continuation or as an event. The following listing shows the implementation using a continuation.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/optional/WithContinuation.cs" mark="9-11" class=""></pre>

If multiple successors are bound to the output we can optimize this by implementing the output path with an event as shown in the following listing.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/optional/WithEvent.cs" mark="9-11,14" class=""></pre>

&nbsp;

## Streamed outputs

Streamed outputs are expressed by using the star outside the parenthesis.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/optional/diagram1.png" alt="Streamed output" />

Again we can refine this to distinguish it from the optional case by using curly braces as shown in the following diagram.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/output/stream/diagram1.png" alt="Streamed output" />

As with optional output paths we can't implement a streamed output by a returning a value from the function. So we need to use either a continuation or an event. The following listing shows how to implement a streamed output by using a continuation that is passed to the function as a parameter. 

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/stream/WithContinuation.cs" mark="9-12" class=""></pre>

Please note that we need to define a protocol that signals the successor of the functional unit the end of the stream. The continuation is called for every datum the functional unit produces. But how does the successor know that the last datum was produced? Think of a functional unit that sums up integers. It receives integer by integer and adds each to the sum. But when is the time to deliver the sum to its successor? In the listing shown we use *null* to signal *end-of-stream*.

The following listing shows how to implement the streaming output path with an event.
<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/output/stream/WithEvent.cs" mark="9-12,15" class=""></pre>

Please note that this is an optimization that is useful if multiple successors need to receive the messages that the functional unit produces.

# Integration

In the preceding chapters we have shown how to implement *input* and *output* data flows. Software systems are build from many functional units that need to be connected according to the solution. In this chapter we show how to implement the connections between functional units.

## Simple data flows (1D)

The following diagram shows a simple data flow consisting of two functional units *F* and *G*.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/integration/diagram1.png" alt="Simple data flow" />

If we implement all input and output data flows as functions and return values then we can call the functions in the order given by the solution and pass the messages produced by one function to the next function as a parameter. The following listing shows how we can implement this flow.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/integration/SimpleDataFlow.cs"></pre>

As you can see we have implemented the flow as a function named *H*. The name *H* is not represented in the solution diagram. This is only the case in the top most flow. All other flows are hierarchical data flows which leads us to the next section.

## Hierarchical data flows (3D)
The following diagram shows the same solution as in the previous section but it contains the functional unit *H*. The flow consisting of *F* and *G* is a refinement of *H*.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/integration/diagram2.png" alt="Hierarchical data flow" />

The listing from the preceding section implements this hierarchical flow. Now lets see how we can implement this flow using continuations.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/integration/HierarchicalWithContinuations.cs"></pre>

Nothing spectacular here. If you connect single input and output flows its not technically necessary to do so by using continuations. So the implementation using continuations instead of return values makes it more complicated as necessary. Before we show examples where it is necessary to use continuations lets look at the same flow implemented using events.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/integration/HierarchicalWithEvents.cs"></pre>

The simple flow although hierarchical lacks some complexity. That comes in if we have branching flows which are discussed in the next section.

## Branching data flows (2D)
If a functional unit has multiple output data flows the flow gets more complex. See the following diagram for an example.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/integration/diagram3.png" alt="Branching data flow" />

Lets see how we can implement this using the simplest possible language elements.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/integration/BranchingDataFlow.cs"></pre>

The operation "If customer has credit" needs to be implemented using continuations because it has multiple output data flows. Both other operations can be implemented as simple functions. Please note that it is necessary that the decision which path to follow has to be done by an operation. This is domain logic so it would be a violation of the IOSP if the functional unit "Checkout" would make the decision. On the other hand it would be a violation of the PoMO if the operation *If customer has credit* would directly call the operations *Checkout with credit card* or *Check out with cash*. The given implementation separates the three aspects of

<ul>
	<li>deciding which checkout method should be chosen,</li>
	<li>checkout with credit card and</li>
	<li>checkout with cash</li>
</ul>

&nbsp;

# Dependencies

&nbsp;

## Instantiation vs Injection

Lets look at the following data flow. It consists of a functional unit *F* that is decomposed into a flow consisting of functional units *A*, *B* and *C*.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/dependencies/diagram1.png" alt="Data flow diagram" />

We can look at the very same solution with a dependency diagram.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/dependencies/diagram2.png" alt="Dependency diagram" />

The dependency diagram shows that functional unit *F* is dependent on *A*, *B* and *C*. If we implement all flows by functions and put them all into the same class our implementation may look like this.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/dependencies/OneClass.cs"></pre>

How can we implement that if the functional units are in different classes?

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/dependencies/MultipleClasses.cs"></pre>

Please note that the necessary instances of *A*, *B* and *C* are created by *F* by means of calls to their constructor. Isn't that in violation to the dependency injection principle? Yes we may inject the instances. But what would be the benefit of injecting the instances? We could mock them in automated unit tests and verify that *F* behaves as expected, without calling the real implementations for *A*, *B* and *C*. We need an integration test anyway to make sure that *F*, *A*, *B* and *C* work together in the correct way. Because *F* contains no domain logic but is only responsible for integration we don't need any isolated unit tests for it. The functions *F*, *A*, *B* and *C* correspond to the *IOSP*, the *Integration Operation Segregation Principle* which states that a functional unit may be either an integration or an operation but not both. In the example F is integration whereas *A*, *B* and *C* are operations.

## Resource

&nbsp;

## State

Functional units may have state. We are not into pure functional programming here. So implementing functional units as functions does not mean they should not have state. The following diagram shows a functional unit *Sum* that uses internal state to sum up the value stream.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/dependencies/diagram3.png" alt="Functional unit with state" width="50%" height="50%" />

The following listing shows how to implement this functional unit.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/dependencies/InternalState.cs"></pre>

Please note that the input to the functional unit *Sum* is a stream. That means it is necessary to decide how to recognize the end of stream. The given implementation uses a *Nullable&lt;int&gt;* so that having no value means end of stream.

The following diagram shows a scenario where multiple functional units have to share state in order to work together properly.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/dependencies/diagram4.png" alt="Functional units with shared state in same class" width="50%" height="50%"  />

If it makes sense to implement the functions in the same class we can use class *fields* to represent the shared state as shown in the following listing.

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/dependencies/StateInSameClass.cs"></pre>

Here the fields *pageNo* and *lastPageNo* implement the state shared between the four functional units *FirstPage*, *NextPage*, *PrevPage* and *LastPage*.

# Iteration

Oftentimes we have functional units that get a collection of input values and produce a collection of output values. See the following diagram for an example.

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/iteration/diagram1.png" alt="Iteration over multiple elements" height="50%" width="50%" />

The functional unit *Convert to strings* gets a collection of *integers* and converts them to *strings*. You may see two aspects:
<ul>
  <li>Iterating over the elements and</li>
  <li>converting one element.</li>
</ul>

A typical implementation looks like this:

<pre url="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/source/csharp/implementation/implementation/iteration/Iteration.cs"></pre>

The function *Convert_to_strings* (note the plural) is responsible for iterating over the collection. It contains the *foreach* loop. Inside the body of the loop the function *Convert_to_string* (note the singular) is called. So you may visualize this in a dependency diagram as follows:

<img src="https://raw.githubusercontent.com/ccdschool/flowdesignorg/master/images/implementation/iteration/diagram2.png" alt="Dependencies of the iteration" height="50%" width="50%" />

We think it is an implementation detail to decompose the two aspects so that we normally don't show the dependency in the solution diagram. If the developer decides to implement it like this thats ok. For example sometimes it is easier to write unit tests for a function that works on one element instead of a collection of elements.

# Recursion

# Concurrency

## Threads

<h3>Synchronization</h3>

## Actors

<h3>Synchronization</h3>

# Exceptions
