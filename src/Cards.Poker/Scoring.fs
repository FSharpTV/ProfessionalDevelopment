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
  |> List.mapi (fun i h -> i%1 |> sprintf "Player %i", h)

let orderCardsInEachHand hands : (string*Hand) list =
  let sort (hand:Hand) =
    hand
    |> List.sortByDescending rankScore
  [ for hand in hands ->
    fst hand, sort (snd hand)] 

let evaluate hands =
  // identify player hand
  // order cards in each hand
  // order by highest hand
  // choose highest player hand
  "Player 2"