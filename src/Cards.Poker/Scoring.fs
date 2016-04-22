module FSharp.TV.Cards.Poker.Scoring

open FSharp.TV.Cards

let dealHands numOfPlayers deck : Hand list =
  
  let cardsToDeal = numOfPlayers * 5 

  let optToCard opt = 
    match opt with
    | Some card -> card
    | None -> failwith "Input was None"

  let rec dealCards deck cards =
    if cards |> List.length = cardsToDeal
    then deck, cards |> List.rev
    else
      let shf, opt = dealCard deck
      let c = optToCard opt
      dealCards shf (c::cards)

  let _, cards = dealCards deck []

  let removeIndexes hand = 
    snd hand |> List.map (fun (_,c) -> c)

  let indexed = cards |> Seq.indexed |> Seq.toList
  let grouped = 
    indexed 
    |> List.groupBy (fun (i,c) -> (i%numOfPlayers)+1 |> sprintf "Player %i")
  let mapped = grouped |> List.map removeIndexes

  mapped

let rankScore card = 
  match card with
  | Card(_,Two)   -> 2
  | Card(_,Three) -> 3
  | Card(_,Four)  -> 4
  | Card(_,Five)  -> 5
  | Card(_,Six)   -> 6
  | Card(_,Seven) -> 7
  | Card(_,Eight) -> 8
  | Card(_,Nine)  -> 9
  | Card(_,Ten)   -> 10
  | Card(_,Jack)  -> 11
  | Card(_,Queen) -> 12
  | Card(_,King)  -> 13
  | Card(_,Ace)   -> 14

let identifyPlayers hands =
  hands
  |> List.mapi (fun i h -> i+1 |> sprintf "Player %i", h)

let orderCardsInEachHand hands : (string*Hand) list =
  let sort (hand:Hand) =
    hand
    |> List.sortByDescending rankScore
  [ for hand in hands ->
    fst hand, sort (snd hand)] 

let orderByHighestHand (hands:(string*Hand) list) =
  // order them descending
  // based upon the map of the rankscore of each card
  // E.G. [13;6;4;3;2] > [12;11;4;3;2] > [11;10;9;7;6] > [11;8;6;5;3]
  hands
  |> List.sortByDescending (fun (_, h) -> h |> List.map rankScore)

let chooseHighestPlayerHand (highestCards:(string*Hand) list) =
  List.head highestCards

let ofAKind hand =
  hand
  |> List.countBy (fun (Card(_,r)) -> r)
  |> List.maxBy snd

let (|FourOfAKind|_|) hand =
  if ofAKind hand |> snd = 4
  then Some hand
  else None

let (|ThreeOfAKind|_|) hand =
  if ofAKind hand |> snd = 3
  then Some hand
  else None


// This is where to start working
type Rate =
  | HighCardRating
  | ThreeOfAKindRating
  | FourOfAKindRating

let identify hand =
  match hand with
  | FourOfAKind hand -> FourOfAKindRating, hand
  | ThreeOfAKind hand -> ThreeOfAKindRating, hand // potential for fullhouse
  | _ -> HighCardRating, hand // Leave like this for now

let mapToRatedHands (hands:(string*Hand) list) : (string * (Rate * Hand)) list =
  hands
  |> List.map (fun (player, hand) -> player, identify hand )

let evaluate =
  identifyPlayers
  >> orderCardsInEachHand
  >> orderByHighestHand
  >> chooseHighestPlayerHand

