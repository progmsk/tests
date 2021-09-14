package msk.prog;

public class Exponent {
    private int value = 0;

    public Exponent(int value) {
        if (value < 0) {
            throw new IllegalArgumentException("Exponent cannot be negative");
        }

        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
