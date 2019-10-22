package main;

import java.util.ArrayList;
import java.util.Collections;

public class PancakesTower {
    private ArrayList<Pancake> tower;

    // Constructeur
    public PancakesTower() {
        tower = new ArrayList<>();
    }

    public PancakesTower(ArrayList<Pancake> t) {
        tower = t;
    }

    public PancakesTower(int numberOfPancakes) {
        tower = new ArrayList<>();
        for (int i=0; i<numberOfPancakes; i++) {
            tower.add(new Pancake(i+1));
        }
    }

    // Accesseurs en lecture
    public ArrayList<Pancake> getTower() {
        return tower;
    }

    // Méthodes
    public void addPancake(Pancake p) {
        if (!tower.contains(p)) {
            tower.add(p);
        }
    }

    public boolean flip(int indice) {
        int size = tower.size();
        if (indice == 1) {
            return false;
        }
        else {
            indice--;
            ArrayList<Pancake> temp = new ArrayList<>();
            for (int i=0; i<size-(indice+1); i++) {
                int y = indice+1;
                Pancake p = tower.get(y);
                temp.add(p);
                tower.remove(p);
            }
            Collections.reverse(tower);

            for (int j=0; j<size-indice-1; j++) {
                Pancake p = temp.get(j);
                tower.add(p);
            }
            //Collections.copy(tower, temp);
            //tower = temp;
            return true;
        }
    }

    public void shuffle() {
        Collections.shuffle(tower);
    }

    public boolean inOrder() {
        if (tower.size() == 1) {
            return true;
        }
        else {
            Pancake p1;
            Pancake p2;
            for (int i = 0; i < tower.size() - 1; i++) {
                p1 = tower.get(i);
                p2 = tower.get(i+1);
                if (p1.compareTo(p2) > 0) {
                    return false;
                }
            }
            return true;
        }
    }

    public void show() {
        int i = 1;
        for (Pancake p : tower) {
            System.out.println(p.show() + " " + i);
            i++;
        }
    }
}
