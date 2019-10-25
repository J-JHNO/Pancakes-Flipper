package com.example.pancakeflipper;

import androidx.appcompat.app.AppCompatActivity;


import android.graphics.Point;
import android.os.Bundle;
import android.view.Display;


public class MainActivity extends AppCompatActivity {
    PancakeView pancakeView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_main);
        // Get a Display object to access screen details

        Display display = getWindowManager().getDefaultDisplay();

        // Load the resolution into a Point object
        Point size = new Point();
        display.getSize(size);

        // Initialize pancakeView and set it as the view
        pancakeView = new PancakeView(this, size.x, size.y);
        setContentView(pancakeView);
    }
    // This method executes when the player starts the game
    @Override
    protected void onResume() {
        super.onResume();

        // Tell the pongView resume method to execute
        pancakeView.resume();
    }

    // This method executes when the player quits the game
    @Override
    protected void onPause() {
        super.onPause();

        // Tell the pongView pause method to execute
        pancakeView.pause();
    }
}
