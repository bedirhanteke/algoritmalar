#include "queen_attack.h"

#define BOARD_SIZE 8U

static int is_valid_position(position_t position)
{
    return position.row < BOARD_SIZE &&
           position.column < BOARD_SIZE;
}

attack_status_t can_attack(position_t queen_1, position_t queen_2)
{
    if (!is_valid_position(queen_1) ||
        !is_valid_position(queen_2))
    {
        return INVALID_POSITION;
    }

   
    if (queen_1.row == queen_2.row &&
        queen_1.column == queen_2.column)
    {
        return INVALID_POSITION;
    }

    /*
     * Aynı satır veya aynı sütun kontrolü.
     */
    if (queen_1.row == queen_2.row ||
        queen_1.column == queen_2.column)
    {
        return CAN_ATTACK;
    }

    /*
     * Köşegen kontrolü.
     *
     * uint8_t değerleri doğrudan çıkarılırsa negatif sonuçların
     * yönetimi kafa karıştırabilir. Bu nedenle önce int türüne
     * dönüştürüyoruz.
     */
    int row_difference =
        (int)queen_1.row - (int)queen_2.row;

    int column_difference =
        (int)queen_1.column - (int)queen_2.column;

    if (row_difference < 0)
    {
        row_difference = -row_difference;
    }

    if (column_difference < 0)
    {
        column_difference = -column_difference;
    }

    if (row_difference == column_difference)
    {
        return CAN_ATTACK;
    }

    return CAN_NOT_ATTACK;
}