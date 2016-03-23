module FSharp.TV.Cards.Tests.Dealing

open NUnit.Framework
open FSharp.TV.Cards

[<Test>]
let ``Should return 51 cards when dealing a card from a new deck`` () =
  // Arrange
  let expected = 51
  let deck = shuffle newDeck 1

  // Act
  let rem,_ = dealCard deck
  let actual = rem |> shuffledDeckSize

  // Assert    
  Assert.AreEqual(expected, actual, "There were not 51 cards in the deck, after dealing")

[<Test>]
let ``Should return 0 cards when dealing a card from a depleted deck`` () =
  // Arrange
  let expected = 0
  let deck = shuffle [] 1

  // Act
  let rem,_ = dealCard deck
  let actual = rem |> shuffledDeckSize

  // Assert
  Assert.AreEqual(expected, actual, "There are still cards in the deck")



