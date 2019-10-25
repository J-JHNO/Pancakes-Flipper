package com.example.pancakeflipper;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PancakeTower {

    private List<Pancake> tower;
    // The screen length and width in pixels
    private int mScreenX;
    private int mScreenY;

    // Constructeur


    public PancakeTower(int numberOfPancakes,int x, int y) {
        tower = new ArrayList<>();
        mScreenX=x;
        mScreenY=y;
        float tempx=x/4;
        float tempy=y-500;
        int templ=150;
        for (int i = 0; i < numberOfPancakes; i++) {
            tower.add(new Pancake(templ, tempx, tempy));
            tempx=tempx+5;
            tempy=tempy - 50;
            templ=templ-20;
        }

    }

    // Accesseurs en lecture
    public List<Pancake> getTower() {
        return tower;
    }

    // MÃ©thodes

    public void reset(int numberOfPancakes,int x, int y){
        tower = new ArrayList<>();
        mScreenX=x;
        mScreenY=y;
        float tempx=x/4;
        float tempy=y-500;
        int templ=150;
        for (int i = 0; i < numberOfPancakes; i++) {
            tower.add(new Pancake(templ, tempx, tempy));
            tempx=tempx+5;
            tempy=tempy - 50;
            templ=templ-20;
        }
    }

    public void update(long mFPS) {

    }
}