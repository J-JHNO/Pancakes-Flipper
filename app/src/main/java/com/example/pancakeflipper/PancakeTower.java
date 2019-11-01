package com.example.pancakeflipper;



import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

import java.util.List;


public class PancakeTower{
    private List<Pos> positions;
    private List<Pancake> tower;
    // The screen length and width in pixels
    private int mScreenX;
    private int mScreenY;

    // Constructeur


    public PancakeTower(int numberOfPancakes,int x, int y) {
        positions=new ArrayList<>();
        tower = new ArrayList<>();
        mScreenX=x;
        mScreenY=y;
        float tempy=y-800;
        int templ=500;
        for (int i = 0; i < numberOfPancakes; i++) {
            Pos tempp=new Pos(i+1,x/4,tempy);
            Pancake pan = new Pancake(templ,tempp);
            positions.add(tempp);
            tower.add(pan);
            tempy=tempy - 100;
            templ=templ-50;
        }

    }

    // Accesseurs en lecture
    public List<Pancake> getTower() {
        return tower;
    }

    // MÃ©thodes

    public void reset(){
        Collections.shuffle(positions);
        int i=0;
        for(Pancake p: tower){
            p.changePos(positions.get(i));
            i++;
        }
        /*List<Pancake> shuffleList = new ArrayList<>();
        for (Pancake pan : tower) {
            Pancake p = new Pancake(pan.getmPancakeLength(), pan.getPos());
            shuffleList.add(pan);
        }
        //Collections.copy(shuffleList, tower);
        Collections.shuffle(shuffleList);

        for (int i=0; i<shuffleList.size(); i++) {
            Pancake p1 = tower.get(i);
            Pancake p2 = shuffleList.get(i);

            p1.changePos(p2.getPos());
        }*/
    }

    public void update(long mFPS) {

    }



    public boolean flip(Pancake pancake) {
        /*Pos posP = pancake.getPos();
        int indice = posP.getP();
        int size = tower.size();
        if (indice == 1) {
            return false;
        }
        else {
            indice--;
            ArrayList<Pancake> temp = new ArrayList<>();
            for (int i=0; i<size-(indice+1); i++) {
                int y = indice+1;
                Pancake pa = tower.get(y);
                temp.add(pa);
                tower.remove(pa);
            }
            int j=tower.size();
            for (int i=0; i<tower.size(); i++) {
                Pos p1 = tower.get(i).getPos();
                Pos p2 = tower.get(j).getPos();
                Pancake pancake1 = tower.get(i);
                Pancake pancake2 = tower.get(j);

                pancake1.changePos(p2);
                pancake2.changePos(p1);
                j--;
            }
            Collections.reverse(tower);

            for (int jj=0; jj<size-indice-1; jj++) {
                Pancake p = temp.get(jj);
                tower.add(p);
            }
            //Collections.copy(tower, temp);
            //tower = temp;
            return true;
        }*/
        /*Pos pos = new Pos();
        for(Pos p:positions){
            if(pancake.getRectF().top==p.getTop()){
                pos=p;
            }
        }*/
        int indice = pancake.getPos().getP();
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
}