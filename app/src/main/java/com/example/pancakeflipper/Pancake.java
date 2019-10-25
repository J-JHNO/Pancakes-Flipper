package com.example.pancakeflipper;

import android.graphics.Rect;
import android.graphics.RectF;

public class Pancake implements Comparable<Pancake>{
    private float mPancakeLength;
    private float mPancakeHeight;
    RectF rect;

    // Constructeurs
    public Pancake(int f,float mXCoord, float mYCoord ) {
        mPancakeLength=f;
        mPancakeHeight=10;
        rect = new RectF(mXCoord, mYCoord, mXCoord + mPancakeLength, mYCoord + mPancakeHeight);
    }

    // Accesseurs en lecture
    public RectF getRectF() {
        return rect;
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
