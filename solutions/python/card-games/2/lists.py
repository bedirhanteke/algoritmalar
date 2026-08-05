"""Functions for tracking poker hands and assorted card tasks.

Python list documentation: https://docs.python.org/3/tutorial/datastructures.html
"""


def get_rounds(number):
    """Create a list containing the current and next two round numbers.

    Parameters:
        number (int): The current round number.

    Returns:
        list: The current round number and the two that follow.
    """
    return [number, number+1, number+2]
    


def concatenate_rounds(rounds_1, rounds_2):
    """Concatenate two lists of round numbers.

    Parameters:
        rounds_1 (list): The first rounds played.
        rounds_2 (list): The second group of rounds played.

    Returns:
        list:  All rounds played.
    """
    return rounds_1 + rounds_2

    
def list_contains_round(rounds, round_number):
    return round_number in rounds




def card_average(hand):
    """Calcuate and returns the avelrage card value from the list.

    Parameters:
        hand (list): The cards in the hand.

    Returns:
        float: The average value of the cards in the hand.
    """
    return sum(hand) / len(hand)
    

def approx_average_is_average(hand):
    """Return if the (average of first and last card values) OR ('middle' card) == calculated average.

    Parameters:
        hand (list): The cards in the hand.

    Returns:
        bool: Does one of the approximate averages equal the `true average`?
    """
    
    # Gerçek ortalama
    real_avg = sum(hand) / len(hand)
    
    # Alternatif 1: İlk ve son kartın ortalaması
    first_last_avg = (hand[0] + hand[-1]) / 2
    
    # Alternatif 2: Ortadaki kart (medyan)
    middle_card = hand[len(hand) // 2]
    
    # Herhangi biri gerçek ortalamaya eşit mi?
    return real_avg in [middle_card, first_last_avg]


def average_even_is_average_odd(hand):
    """Return if the (average of even indexed card values) == (average of odd indexed card values).

    Parameters:
        hand (list): The cards in the hand.

    Returns:
        bool: Are the even and odd averages equal?
    """
    
    # Çift indeksteki kartlar (0, 2, 4, ...)
    even_cards = hand[::2]
    
    # Tek indeksteki kartlar (1, 3, 5, ...)
    odd_cards = hand[1::2]
    
    # Ortalamaları hesapla
    even_avg = sum(even_cards) / len(even_cards)
    odd_avg = sum(odd_cards) / len(odd_cards)
    
    # Eşit mi?
    return even_avg == odd_avg


def maybe_double_last(hand):
    """Multiply a Jack card value in the last index position by 2.

    Parameters:
        hand (list): The cards in the hand.

    Returns:
        list: The hand with Jacks (if present) value doubled.
    """
    
    # Son kartı kontrol et
    if hand[-1] == 11:  # Jack = 11
        hand[-1] = 22   # Değeri iki katına çıkar
    
    return hand
