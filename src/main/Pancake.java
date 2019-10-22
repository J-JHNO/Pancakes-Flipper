package main;

public class Pancake implements Comparable<Pancake> {
    private int length;

    // Constructeurs
    public Pancake() {
        length = 1;
    }

    public Pancake(int l) {
        if (l == 0) {
            throw new ExceptionInInitializerError();
        }
        else {
            length = l;
        }
    }

    // Accesseurs en lecture
    public int getLength() {
        return length;
    }

    // Méthodes
    @Override
    public int compareTo(Pancake p) {
        int pLength = p.getLength();
        if (length < pLength) {
            return -1;
        }
        else if (length == pLength) {
            return 0;
        }
        else {
            return 1;
        }
    }

    public String show() {
        String pancake = "_";
        for (int i=0; i<length; i++) {
            pancake += "_";
        }
        return pancake;
    }
}
