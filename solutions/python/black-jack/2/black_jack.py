"""Functions to help play and score a game of blackjack."""


def value_of_card(card: str) -> int:
    """Determine the scoring value of a card."""
    if card in ('J', 'Q', 'K'):
        return 10
    if card == 'A':
        return 1
    return int(card)


def higher_card(card_one: str, card_two: str):
    """Determine which card has a higher value in the hand."""
    val_one = value_of_card(card_one)
    val_two = value_of_card(card_two)

    if val_one > val_two:
        return card_one
    if val_two > val_one:
        return card_two
    return card_one, card_two


def value_of_ace(card_one: str, card_two: str) -> int:
    """Calculate the most advantageous value for an upcoming ace card."""
    val_one = 11 if card_one == 'A' else value_of_card(card_one)
    val_two = 11 if card_two == 'A' else value_of_card(card_two)

    if val_one + val_two + 11 <= 21:
        return 11
    return 1


def is_blackjack(card_one: str, card_two: str) -> bool:
    """Determine if the hand is a 'natural' or 'blackjack'."""
    has_ace = card_one == 'A' or card_two == 'A'
    has_ten = value_of_card(card_one) == 10 or value_of_card(card_two) == 10
    return has_ace and has_ten


def can_split_pairs(card_one: str, card_two: str) -> bool:
    """Determine if a player can split their hand into two hands."""
    return value_of_card(card_one) == value_of_card(card_two)


def can_double_down(card_one: str, card_two: str) -> bool:
    """Determine if a blackjack player can place a double down bet."""
    total = value_of_card(card_one) + value_of_card(card_two)
    return 9 <= total <= 11