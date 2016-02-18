#The Specification
####Having a specification means we have something to test, to narrow the scope let's keep the problem small so we can make easy, incremental progress.


##*1 Terminology*

####The common terms we will use are listed here:

###`Suit` - which include:-
	
	Clubs, Diamonds, Hearts and Spades
	
###`Rank` - A rank is the value of the card:-
	
	Ace, Two, Three, Four,
	Five, Six, Seven, Eight,
	Nine, Ten, Jan, Queen, King

###`Card` - Combination of `Suit` and `Rank`	
###`Deck` - A collection of `Card`'s (`unshuffled` more detail below)
###`Deal` - The `Deal` is a action that operates on the `Deck` and takes the first `Card` within the `Deck`
###`Shuffle` - The `Shuffle` is an action that operates on the `Deck` and randomly shuffles the `Card`'s within the `Deck`

##*2 The unshuffled deck*
####An unshuffled deck will be in alphabetical suit order then for each suit in rank order ascending and starting from the Ace to King, like so:- 
	
**`Clubs = ♣, Diamonds = ♦, Hearts = ♥, Spades = ♠`**
	
	Deck consists of
		♣ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♦ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♥ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K]
		♠ with Ranks in order [A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K] 
		
This means that the first `Card` from an `Unshuffled Deck` is an `Ace` of `Clubs` and the last `Card` is a `King` of `Spades`.
		
##*3 Other cards*
A `Deck` will not contain any `Joker`'s