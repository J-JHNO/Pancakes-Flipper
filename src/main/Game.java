package main;

public class Game {
    private int numberOfPancakes;
    private PancakesTower pancakesTower;
    private int numberOfFlips;

    // Constructeurs
    public Game() {
        numberOfPancakes = 1;
        pancakesTower = new PancakesTower();
        numberOfFlips = 0;
    }

    public Game(int n) {
        numberOfPancakes = n;
        pancakesTower = new PancakesTower(n);
        pancakesTower.shuffle();
        numberOfFlips = 0;
    }

    // Accesseurs en lecture
    public int getNumberOfPancakes() {
        return numberOfPancakes;
    }

    public PancakesTower getPancakesTower() {
        return pancakesTower;
    }

    public int getNumberOfFlips() {
        return numberOfFlips;
    }

    // Méthodes
    public void flip(int indice) {
        if (!pancakesTower.flip(indice)) {
            System.out.println("Interdiction of flipping the top pancake");
        }
        else {
            numberOfFlips += 1;
        }
    }

    public boolean finished() {
        return pancakesTower.inOrder();
    }

    public void show() {
        pancakesTower.show();
    }
}
