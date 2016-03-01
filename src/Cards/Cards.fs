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


let allSuits = [ Clubs; Diamonds; Hearts; Spades ]
let allRanks = [ Two; Three;Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace ]

let newDeck =
    [ for suit in allSuits do
        for rank in allRanks do
            yield Card (suit, rank) ]


type Deal = Deck -> Deck*Card

let dealImpl deck = 
  let top::rem = deck
  rem, Card (Clubs,Ten)

let dealCard : Deal = dealImpl
