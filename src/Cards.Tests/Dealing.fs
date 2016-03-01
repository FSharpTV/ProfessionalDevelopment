module FSharp.TV.Cards.Tests

open NUnit.Framework
open Cards

[<Test>]
let ``Should return 51 cards when dealing a card from a new deck`` () =
  // Arrange
  let expected = 51
  let deck = newDeck

  // Act
  let rem,_ = dealCard deck
  let actual = rem |> List.length

  // Assert    
  Assert.AreEqual(expected, actual, "There were not 51 cards in the deck, after dealing")

[<Test>]
let ``Should return 0 cards when dealing a card from a depleted deck`` () =
  // Arrange
  let expected = 1
  let deck = []

  // Act
  let rem,_ = dealCard deck
  let actual = rem |> List.length

  // Assert
  Assert.AreEqual(expected, actual, "There are still cards in the deck")