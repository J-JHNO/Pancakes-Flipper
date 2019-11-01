package com.example.pancakeflipper;

import android.graphics.Rect;
import android.graphics.RectF;

public class Pancake implements Comparable<Pancake>{
    private float mPancakeLength;
    private float mPancakeHeight;
    RectF rect;
    private Pos pos;
    //private int indice;

    // Constructeurs
    /*public Pancake(int f,float mXCoord, float mYCoord ) {
        mPancakeLength=f;
        mPancakeHeight=50;

        rect = new RectF(mXCoord, mYCoord, mXCoord + mPancakeLength, mYCoord + mPancakeHeight);
    }*/

    public Pancake(float f,Pos p) {
        mPancakeLength=f;
        mPancakeHeight=50;
        float mXCoord = p.getLeft()+p.getP()*50;
        float mYCoord = p.getTop();
        rect = new RectF(mXCoord, mYCoord, mXCoord + mPancakeLength, mYCoord + mPancakeHeight);
        pos=p;
        //indice = p.getP();
    }

    // Accesseurs en lecture
    public RectF getRectF() {
        return rect;
    }

    public Pos getPos() {

        return pos;
    }

    public float getmPancakeHeight() {
        return mPancakeHeight;
    }

    public float getmPancakeLength() {
        return mPancakeLength;
    }

    /*public int getIndice() {
        return indice;
    }*/

    public void changePos(Pos p) {
        float mXCoord = p.getLeft()+p.getP()*50;
        float mYCoord = p.getTop();
        rect = new RectF(mXCoord, mYCoord, mXCoord + mPancakeLength, mYCoord + mPancakeHeight);
        pos=p;
    }
    // MÃ©thodes
    @Override
    public int compareTo(Pancake p) {
        int pLength = (int)p.getRectF().width();
        if ((int)rect.width() < pLength) {
            return -1;
        }
        else if ((int)rect.width() == pLength) {
            return 0;
        }
        else {
            return 1;
        }
    }
}
