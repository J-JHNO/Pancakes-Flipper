package main;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int numberOfPancakes = 1;
        System.out.println("How many pancakes do you want ?");
        numberOfPancakes = sc.nextInt();
        Game game = new Game(numberOfPancakes);

        int indice = 1;
        while (!game.finished()) {
            game.show();
            System.out.println("Which one do you want to flip ? ");
            indice = sc.nextInt();
            game.flip(indice);
        }

        game.show();

        System.out.println("Finished with " + game.getNumberOfFlips() + " flips");
    }
}
