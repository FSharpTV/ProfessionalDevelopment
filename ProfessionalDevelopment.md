#Professional Development:
##Creating the domain with the F# Type System and unit testing with FsUnit

###Introduction

In this course our aim is to help the student **gain more FP concepts**, put those concepts into practice. We will also expose the the student to some **open source libraries**. We will be taking a specification, breaking it down so that the thought process for re-creating the specifications in F# source code can be experienced.

We will use the **rich typing system of F#** to constrain our types and demonstrate the succinctness of **developing a domain** using the F# type system. The main thing to be focused on during this section is unit testing with a popular **F# testing** framework. For this we will use a game of poker as our subject matter. The main areas to cover in this course will be the following:

* **Domain designing with types, following a specification**

* **Designing modules and functions that expose the developer to FP concepts**

* **Unit test the functionality using FsUnit**

Specification for lecture purposes to deliver the three parts identified.

A game of cards will first of all require that a deck of cards exists, for this we will need to create the deck of 52 standard playing cards. We will create an ***ubiquitous language*** to represent our domain and start from the very basic principles and building on those principles to create a usable domain.

Things we will encounter may include the Microsoft libraries for **reflecting** F# types, more specifically enumerating discriminated unions.

<hr>

###The Specification
Having a specification means we have something to test, to narrow the scope let's keep the problem small so we can make easy, incremental progress.


####*1 The Ubiquitous Language*

The ubiquitous language of terms are listed here:

#####`Suit` - which include:-
	
	Clubs, Diamonds, Hearts and Spades
	
#####`Rank` - A `Rank` is the value of the card:-
	
	Ace, Two, Three, Four,
	Five, Six, Seven, Eight,
	Nine, Ten, Jan, Queen, King

#####`Card` - Combination of `Suit` and `Rank`	
#####`Deck` - A collection of `Card`'s (`unshuffled` more detail below)
#####`Deal` - The `Deal` is a action that operates on the `Deck` and takes the first `Card` within the `Deck`
#####`Shuffle` - The `Shuffle` is an action that operates on the `Deck` and randomly shuffles the `Card`'s within the `Deck`

####*2 The unshuffled deck*
An unshuffled deck will be in alphabetical suit order then for each suit in rank order ascending and starting from the Ace to King, like so:- 
	
**`Clubs = ♣, Diamonds = ♦, Hearts = ♥, Spades = ♠`**
	
	Deck consists of
		♣ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♦ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♥ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♠ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K] 
		
This means that the first `Card` from an `Unshuffled Deck` is an `Ace` of `Clubs` and the last `Card` is a `King` of `Spades`.
		
####*3 Other cards*
A `Deck` will not contain any `Joker`'s

<hr>

###Educational Points

During the individual lectures the educational points need to be pulled out and 2-3 of those points need to be communicated during each video lecture.

#####Lecture One
* Describe the problem/situation 
* Explain the type system and how it will benefit us
* Explain the reasons why we should get to the very essence of the types we are modelling - make illegal states unrepresentable
* Explain about understanding the domain but contrast with the type system
* Show the spec
* Explain the FP techniques that will be encountered
* Talk about how we will use FsUnit to test the domain functionality

#####Lecture Two - Implementing a `Card`
* Explain that we need a `Deck` and we need `Card`'s to complete a `Deck`. We need to create the basics of a `Card`, which means we need to  implement the `Rank` and `Suit`.
* Explain that the type system will help us implement all of this.
* Challenge the student to create discriminated union types for the `Suit` and `Rank`

#####Lecture Three - Creating a `Deck` of `Card`'s
* We want to be able to deal a card
* Explain that we are now ready to start building our `Deck` now we have implemented a card
* Introduce the cast operator `:?>`
* Introduce the student to `Microsoft.FSharp.Reflection`
* Show them how to use `FSharpType.GetUnionCases`
* Show them how to use `FSharpValue.MakeUnion`
* Challenge the student to implement the entire deck using reflection
 
#####Lecture Four - Implementing `Deal`
* We still want to be able to deal a card
* What are the intrinsic behaviours of dealing a card from a deck - talk about when a deck is depleted how to represent non existent cards
* Explain that we will use more of the abilities of the type system, in this lecture we will alias our types and even create types to represent our functions
* Show how we can constrain our types as we build them, emphasizing the strengths of the F# type system
* Challenge the student to implement the `Deal` type

#####Lecture Five - Testing dealt `Card`'s
* We want to tighten the functionality around dealing cards
* How do we identify the `Suit` of a dealt card
* Challenge the student to write: `let getSuits = function Card(suit,rank) -> suit`