module FSharp.TV.Cards.Tests.Scoring

open FSharp.TV.Cards
open FSharp.TV.Cards.Poker.Scoring
open NUnit.Framework
open FsUnit

let shuffledDeck =
  ShuffledDeck
    [ Card (Hearts,Seven); Card (Clubs,Ten); Card (Clubs,Two);
      Card (Spades,Six); Card (Clubs,Eight); Card (Diamonds,Nine);
      Card (Spades,Two); Card (Diamonds,King); Card (Clubs,Three);
      Card (Hearts,Three); Card (Hearts,Five); Card (Diamonds,Jack);
      Card (Clubs,Four); Card (Spades,King); Card (Hearts,Eight);
      Card (Diamonds,Seven); Card (Diamonds,Five); Card (Hearts,Ten);
      Card (Clubs,Seven); Card (Hearts,Six); Card (Hearts,King);
      Card (Spades,Five); Card (Hearts,Two); Card (Hearts,Four);
      Card (Diamonds,Two); Card (Diamonds,Three); Card (Clubs,Jack);
      Card (Clubs,Six); Card (Diamonds,Six); Card (Spades,Queen);
      Card (Spades,Jack); Card (Diamonds,Ace); Card (Hearts,Nine);
      Card (Hearts,Ace); Card (Diamonds,Four); Card (Spades,Four);
      Card (Spades,Three); Card (Clubs,Queen); Card (Hearts,Queen);
      Card (Diamonds,Queen); Card (Spades,Seven); Card (Spades,Eight);
      Card (Clubs,Ace); Card (Spades,Nine); Card (Hearts,Jack);
      Card (Spades,Ten); Card (Clubs,Five); Card (Diamonds,Ten);
      Card (Clubs,Nine); Card (Clubs,King); Card (Spades,Ace);
      Card (Diamonds,Eight) ]

[<Test>]
let ``Should evaluate Player 2 to have the winning hand`` () =
  // Arrange
  // set up dealing
  let hands = dealHands 3 shuffledDeck

  // Act
  // setup call to evaluate hands
  let chosenWinner = evaluate hands

  // Assert
  fst chosenWinner |> should equal "Player 2"

[<Test>]
let ``Should deal 5 cards to each player`` () =

  // Arrange
  let deck = shuffledDeck

  // Act
  let hands = dealHands 2 deck
  let fstPlayerHand = hands.[0]
  let sndPlayerHand = hands.[1]

  // Assert
  fstPlayerHand |> should haveLength 5
  sndPlayerHand |> should haveLength 5

[<Test>]
let ``Player 2 and Player 3 should have certain cards in their hands`` () =

  // Arrange
  let deck = shuffledDeck

  // Act
  let hands = dealHands 3 deck
  let sndPlayerHand = hands.[1]
  let thdPlayerHand = hands.[2]

  // Assert
  sndPlayerHand |> should contain (Card (Diamonds, King))
  thdPlayerHand |> should contain (Card (Diamonds, Jack))

[<Test>]
let ``The hand should be in a specific order`` () =
  // Arrange
  let expected = 
    [ Card (Diamonds,King)
      Card (Spades,King)
      Card (Clubs,Ten)
      Card (Clubs,Eight)
      Card (Hearts,Five) ]
  
  let unsortedHands =
    [ [ Card (Hearts,Seven); Card (Spades,Six); Card (Spades,Two);
        Card (Hearts,Three); Card (Clubs,Four) ];
      [ Card (Clubs,Ten); Card (Clubs,Eight); Card (Diamonds,King);
        Card (Hearts,Five); Card (Spades,King) ];
      [ Card (Clubs,Two); Card (Diamonds,Nine); Card (Clubs,Three);
        Card (Diamonds,Jack); Card (Hearts,Eight) ] ]
  
  let unorderedHands = identifyPlayers unsortedHands

  // Act
  let orderedHands = orderCardsInEachHand unorderedHands
  let actual = snd orderedHands.[1]

  // Assert
  CollectionAssert.AreEqual(expected, actual)

[<Test>]
let ``Should return 4 of a Kind of Rank Queen`` () =

  // Arrange
  let hand = 
    [ Card (Diamonds, Queen)
      Card (Spades, Queen)
      Card (Clubs, Ten)
      Card (Hearts, Queen)
      Card (Clubs, Queen) ]
       
  // Act
  let result  = ofAKind hand

  //Assert
  result |> should be (equal (Queen, 4))

[<Test>]
let ``Should return 3 of a kind of Rank King`` () =

  // Arrange
  let hand = 
    [ Card (Diamonds, King)
      Card (Spades, King)
      Card (Clubs, Ten)
      Card (Hearts, King)
      Card (Clubs, Five) ]

  // Act
  let result = ofAKind hand

  // Assert
  result |> should be (equal (King, 3))

[<Test>]
let ``Should identify poker combinations`` () =
  // Arrange
  let threeKindHand = 
    [ Card (Diamonds, King)
      Card (Spades, King)
      Card (Clubs, Ten)
      Card (Hearts, King)
      Card (Clubs, Five) ]

  let fourKindHand = 
    [ Card (Diamonds, King)
      Card (Spades, King)
      Card (Clubs, King)
      Card (Hearts, King)
      Card (Clubs, Five) ]

  // Act
  let idThreeHand = identify threeKindHand
  let idFourHand = identify fourKindHand

  // Assert
  idThreeHand |> should equal (ThreeOfAKindRating, threeKindHand)
  idFourHand |> should equal  (FourOfAKindRating, fourKindHand)

[<Test>]
let ``Players and ratings are identified`` () =
  // Arrange
  let hands =
    [ [ Card (Hearts, Four);  Card (Clubs, Six);    Card (Hearts, Seven); Card (Spades, Eight);  Card (Clubs, King); ]
      [ Card (Clubs, Two);    Card (Spades, Six);   Card (Hearts, Jack);  Card (Diamonds, Jack); Card (Clubs, Jack); ]
      [ Card (Diamonds, Two); Card (Spades, Four);  Card (Hearts, Five);  Card (Spades, Nine);   Card (Clubs, Queen); ]
      [ Card (Clubs, Three);  Card (Clubs, Four);   Card (Clubs, Seven);  Card (Hearts, Six);    Card (Hearts, Queen); ]
      [ Card (Hearts, Two);   Card (Diamonds, Six); Card (Clubs, Ten);    Card (Hearts, Ten);    Card (Spades, Ten); ] ]

  let identifiedHands = identifyPlayers hands

  // Act
  let mappedHands = mapToRatedHands identifiedHands
  let tagsAndRatings = mappedHands |> List.map (fun (tag, (rate,_)) -> tag, rate)

  // Assert
  tagsAndRatings 
  |> should equal 
    [ "Player 1", HighCardRating
      "Player 2", ThreeOfAKindRating
      "Player 3", HighCardRating
      "Player 4", HighCardRating
      "Player 5", ThreeOfAKindRating ]