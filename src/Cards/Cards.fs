module FSharp.TV.Cards

type Suit = 
    | Clubs
    | Diamonds
    | Hearts
    | Spades

type Rank = 
    | Two   | Three | Four  
    | Five  | Six   | Seven 
    | Eight | Nine  | Ten   
    | Jack  | Queen | King  
    | Ace

type Card = Card of Suit*Rank

type Deck = Card list