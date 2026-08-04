def value_of_card(card):
    """Determine the scoring value of a card."""
    if card == 'J':
        return 10
    elif card == 'Q':
        return 10
    elif card == 'K':
        return 10
    elif card == 'A':
        return 1
    else:
        return int(card)


def higher_card(card_one, card_two):
    """Determine which card has a higher value in the hand."""
    val_one = value_of_card(card_one)
    val_two = value_of_card(card_two)

    if val_one > val_two:
        return card_one
    elif val_two > val_one:
        return card_two
    else:
        return card_one, card_two


def value_of_ace(card_one, card_two):
    """Calculate the most advantageous value for an upcoming ace card."""
    # 1. İlk kart As ise değeri 11, değilse normal değerini al
    if card_one == 'A':
        val_one = 11
    else:
        val_one = value_of_card(card_one)

    # 2. İkinci kart As ise değeri 11, değilse normal değerini al
    if card_two == 'A':
        val_two = 11
    else:
        val_two = value_of_card(card_two)

    # 3. Eldekiler + Gelecek As (11) <= 21 kontrolü
    toplam = val_one + val_two + 11

    if toplam <= 21:
        return 11
    else:
        return 1


def is_blackjack(card_one, card_two):
    """Determine if the hand is a 'natural' or 'blackjack'."""
    # Kartlardan biri As mi?
    if card_one == 'A' or card_two == 'A':
        has_ace = True
    else:
        has_ace = False

    # Kartlardan biri 10 puanlık bir kart mı?
    val_one = value_of_card(card_one)
    val_two = value_of_card(card_two)

    if val_one == 10 or val_two == 10:
        has_ten = True
    else:
        has_ten = False

    # İkisi de True ise Blackjack olur
    if has_ace == True and has_ten == True:
        return True
    else:
        return False


def can_split_pairs(card_one, card_two):
    """Determine if a player can split their hand into two hands."""
    val_one = value_of_card(card_one)
    val_two = value_of_card(card_two)

    if val_one == val_two:
        return True
    else:
        return False


def can_double_down(card_one, card_two):
    """Determine if a blackjack player can place a double down bet."""
    val_one = value_of_card(card_one)
    val_two = value_of_card(card_two)
    total = val_one + val_two

    if total >= 9 and total <= 11:
        return True
    else:
        return False