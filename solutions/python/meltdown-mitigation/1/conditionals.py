"""Functions to prevent a nuclear meltdown."""


def is_criticality_balanced(temperature, neutrons_emitted):
    """Verify criticality is balanced."""
    return (
        temperature < 800
        and neutrons_emitted > 500
        and (temperature * neutrons_emitted) < 500000
    )
def reactor_efficiency(voltage, current, theoretical_max_power):
    a = voltage * current
    b = (a / theoretical_max_power) * 100

    if b >= 80:
        return 'green'
    elif b >= 60:
        return 'orange'
    elif b >= 30:
        return 'red'
    else:
        return 'black'

def fail_safe(temperature, neutrons_produced_per_second, threshold):
    a = temperature * neutrons_produced_per_second
    
    if a < (threshold * 0.9):
        return 'LOW' 
    elif a <= (threshold * 1.1):
        return 'NORMAL'
    else:
        return 'DANGER'