module FSharp.TV.Cards.Poker.Scoring

open FSharp.TV.Cards
  
let dealHand player : Hand list=
  [ 
    [ Card (Hearts,Seven)
      Card (Clubs,Two)
      Card (Clubs,Eight)
      Card (Spades,Two)
      Card (Clubs,Three) ]

    [ Card (Clubs,Ten)
      Card (Spades,Six)
      Card (Diamonds,Nine)
      Card (Diamonds,King)
      Card (Hearts,Three) ] ]

let evaluate hands =
  "Player 2"