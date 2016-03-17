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

let newDeck : Deck =
    [ for suit in allSuits do
        for rank in allRanks do
            yield Card (suit, rank) ]

type ShuffledDeck = ShuffledDeck of Deck
type Deal = ShuffledDeck -> ShuffledDeck*Card option

let dealImpl deck = 
  match deck with
  | ShuffledDeck (top::rem) -> ShuffledDeck rem, Some top
  | ShuffledDeck [] -> ShuffledDeck [], None

let dealCard : Deal = dealImpl

let shuffle deck seed =
  let rnd = System.Random(seed)
  let rec shuffler unshuffled shuffled =
    let count = unshuffled |> List.length
    if count = 0 then 
      ShuffledDeck shuffled
    else
      let index = rnd.Next(count)
      let card = unshuffled.[index]
      let newUnshuffled = unshuffled |> List.filter (fun c -> c <> card)
      let newShuffled = card :: shuffled
      shuffler newUnshuffled newShuffled
  shuffler deck []

let shuffledDeckSize (ShuffledDeck deck) =
  List.length deck