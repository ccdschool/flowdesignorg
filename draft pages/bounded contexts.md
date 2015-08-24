# Bounded contexts to encapsulate different data models
In the process of decomposing requirements check if a system consists of different [bounded contexts](http://martinfowler.com/bliki/BoundedContext.html) (BC).

This term was coined by Eric Evans in his book on Domain Driven Design (DDD)###. A bounded context can be understood as the scope of requirements sharing the same domain data model.

***fig1

A domain data model is how a software system deems data should be structured to fulfill functional, but more importantly non-functional requirements like performance and scalability. This pertains to in-memory data as well as persistent data.

The default is to try to cater to all needs with just a single domain data model. But this often leads to huge databases with intricate schemas, because many, sometimes contradicting needs have to be served. Such databases are hard to understand, evolve, and mostly fail to deliver optimally on all requirement aspects. One size simply doesn't fit it all despite all best intentions.

With bounded context this reality is acknowledged. They suggest to split the domain data model of a system up into multiple smaller data models for different contexts in which data are used.

This does not just mean distributing data across different databases, it means using different schemas. It also means possibly using different paradigms and technologies to store data, e.g. relational and document oriented or key-value store.

Each bounded context fully owns its data to optimally meet its sub-set of requirements.

Example: Think of a software system for a pizza shop. Its high level requirements could be:

* Let customers order online.
* Let a clerk take orders at a counter.
* Let the manager change the menu (pizzas, prices).
* Let the pizza boy get a delivery route.
* Let the owner see performance data.

Of course this could all be accomplished with a relational database and a single schema. It could even be done with a single instance of such a database in the cloud to be accessed by all in-house users as well as the customers.

Here's a system level software cell### for this scenario:

***fig2

But why put all the eggs in one basket? By splitting the system into several bounded contexts it would be easier to implement the system (with multiple developers in parallel) and to evolve it. Bounded context decouple data.

Here's how this could look:










