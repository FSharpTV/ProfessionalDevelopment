module FSharp.TV.Cards

type Suit = Clubs | Diamonds | Hearts | Spades
type Rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
type Card = Card of Suit*Rank
type Deck = Card list
type ShuffledDeck = ShuffledDeck of Deck
type Deal = ShuffledDeck -> ShuffledDeck*Card option

let allSuits = [ Clubs; Diamonds; Hearts; Spades ]
let allRanks = [ Two; Three;Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace ]

let newDeck : Deck =
    [ for suit in allSuits do
        for rank in allRanks do
            yield Card (suit, rank) ]

let dealImpl deck = 
  match deck with
  | ShuffledDeck (top::rem) -> ShuffledDeck rem, Some top
  | ShuffledDeck [] -> ShuffledDeck [], None

let dealCard : Deal = dealImpl

let shuffle deck seed =
  let rnd = System.Random(seed)
  deck |> List.sortBy (fun _ -> rnd.Next()) |> ShuffledDeck

let shuffledDeckSize (ShuffledDeck deck) =
  List.length deck