module FSharp.TV.Cards.Tests.Scoring

open FSharp.TV.Cards
open FSharp.TV.Cards.Poker.Scoring
open NUnit.Framework
open FsUnit

[<Test>]
let ``Should evaluate Player 2 to have the winning hand`` () =
  // Arrange
  // set up dealing
  let hands = dealHand 2

  // Act
  // setup call to evaluate hands
  let chosenWinner = evaluate hands

  // Assert
  chosenWinner |> should equal "Player 2"