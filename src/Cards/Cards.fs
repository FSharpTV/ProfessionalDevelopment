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

type ShuffledDeck = ShuffledDeck of Deck

type Deal = ShuffledDeck -> ShuffledDeck * Card

let allSuits = [ Clubs; Diamonds; Hearts; Spades ]
let allRanks = [ Two; Three;Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace ]

let newDeck =
    [ for suit in allSuits do
        for rank in allRanks do
            yield Card (suit, rank) ]


let dealCard : Deal =
    fun deck ->
        match deck with
        | ShuffledDeck d -> ShuffledDeck d, Card(Spades,Ace)

