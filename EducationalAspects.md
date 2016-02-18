###Educational Points

During the individual lectures the educational points need to be pulled out and 2-3 of those points need to be communicated during each video lecture.

#####Lecture One - Talking Head
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