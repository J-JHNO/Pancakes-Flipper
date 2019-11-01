package com.example.pancakeflipper;

class Pos implements Comparable<Pos>{
    int p;
    float top;
    float left;

    public Pos() {
        this.p = 0;
        this.top = 0;
        this.left = 0;
    }

    public Pos(int p, float left, float top) {
        this.p = p;
        this.top = top;
        this.left = left;
    }

    public Pos(float left, float top) {
        this.top = top;
        this.left = left;
    }

    public int getP() {
        return p;
    }

    public float getTop() {
        return top;
    }

    public float getLeft() {
        return left;
    }


    @Override
    public int compareTo(Pos o) {
        if(p>o.getP()){
            return 1;
        }
        else if(p<o.getP()){
            return -1;
        }
        else{
            return 0;
        }
    }
}
